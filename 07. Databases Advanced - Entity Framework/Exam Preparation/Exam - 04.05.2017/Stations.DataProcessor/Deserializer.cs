using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stations.Data;
using Stations.DataProcessor.Dto.Import;
using Stations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Stations.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";
        private const string SuccessTripMessage = "Trip from {0} to {1} imported.";
        private const string SuccessTicketMessage = "Ticket from {0} to {1} departing at {2} imported.";

        public static string ImportStations(StationsDbContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<StationImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var stations = new List<Station>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) ||
                    stations.Any(s => s.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (dto.Town == null)
                {
                    dto.Town = dto.Name;
                }

                var station = new Station
                {
                    Name = dto.Name,
                    Town = dto.Town
                };

                stations.Add(station);

                sb.AppendLine(String.Format(SuccessMessage, station.Name));
            }

            context.Stations.AddRange(stations);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportClasses(StationsDbContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<SeatingClassImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var classes = new List<SeatingClass>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) ||
                    classes.Any(c =>
                        c.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase) ||
                        c.Abbreviation.Equals(dto.Abbreviation, StringComparison.OrdinalIgnoreCase)
                    ))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatingClass = new SeatingClass
                {
                    Name = dto.Name,
                    Abbreviation = dto.Abbreviation
                };

                classes.Add(seatingClass);

                sb.AppendLine(String.Format(SuccessMessage, seatingClass.Name));
            }

            context.SeatingClasses.AddRange(classes);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportTrains(StationsDbContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<TrainImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var trains = new List<Train>();

            Func<TrainImportDto, bool> ValidateDto = new Func<TrainImportDto, bool>((dto) =>
            {
                if (dto.Seats == null) return false;
                if (dto.Seats.Select(s => s.Name).Distinct().Count() != dto.Seats.Count())
                    return false;
                if (dto.Seats.Select(s => s.Quantity).Any(q => q == null || q < 0)) return false;
                if (trains.Any(t => t.TrainNumber == dto.TrainNumber)) return false;
                if (dto.Type == null) dto.Type = TrainType.HighSpeed;

                return true;
            });

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || !ValidateDto(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var hasSeat = true;
                var trainSeats = new List<TrainSeat>();
                foreach (var trainSeatDto in dto.Seats)
                {
                    var seat = context.SeatingClasses
                        .FirstOrDefault(s => s.Name == trainSeatDto.Name && s.Abbreviation == trainSeatDto.Abbreviation);
                    if (seat == null)
                    {
                        hasSeat = false;
                        break;
                    }

                    var trainSeat = new TrainSeat
                    {
                        Quantity = trainSeatDto.Quantity ?? default(int),
                        SeatingClassId = seat.Id
                    };

                    trainSeats.Add(trainSeat);
                }

                if (!hasSeat)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var train = new Train
                {
                    TrainNumber = dto.TrainNumber,
                    Type = dto.Type,
                    TrainSeats = trainSeats
                };

                trains.Add(train);
                sb.AppendLine(String.Format(SuccessMessage, train.TrainNumber));
            }

            context.Trains.AddRange(trains);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<TripImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var trips = new List<Trip>();

            Func<string, Station> GetStation = new Func<string, Station>((stationName) =>
            {
                var station = context.Stations.FirstOrDefault(s => s.Name == stationName);

                return station;
            });

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var train = context.Trains.FirstOrDefault(t => t.TrainNumber == dto.Train);

                var originStation = GetStation(dto.OriginStation);

                var destinationStation = GetStation(dto.DestinationStation);

                var isArrivalTimeValid = DateTime.TryParseExact(dto.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime arrivalTime);

                var isDepartureTimeValid = DateTime.TryParseExact(dto.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime departureTime);

                if (train == null || originStation == null || destinationStation == null ||
                    !isArrivalTimeValid || !isDepartureTimeValid || departureTime >= arrivalTime)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var trip = new Trip
                {
                    OriginStationId = originStation.Id,
                    DestinationStationId = destinationStation.Id,
                    ArrivalTime = arrivalTime,
                    DepartureTime = departureTime,
                    TrainId = train.Id,
                    Status = dto.Status
                };

                var isTimeDifferenceValid = TimeSpan.TryParse(dto.TimeDifference, out TimeSpan timeDifference);
                if (isTimeDifferenceValid)
                {
                    trip.TimeDifference = timeDifference;
                }

                trips.Add(trip);
                sb.AppendLine(String.Format(SuccessTripMessage, originStation.Name, destinationStation.Name));
            }

            context.Trips.AddRange(trips);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportCards(StationsDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(CustomerCardImportDto[]), new XmlRootAttribute("Cards"));
            var dtos = (CustomerCardImportDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();

            var cards = new List<CustomerCard>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var card = new CustomerCard
                {
                    Name = dto.Name,
                    Age = dto.Age,
                    Type = dto.Type
                };

                cards.Add(card);

                sb.AppendLine(String.Format(SuccessMessage, card.Name));
            }

            context.Cards.AddRange(cards);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(TicketImportDto[]), new XmlRootAttribute("Tickets"));
            var dtos = (TicketImportDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();

            var tickets = new List<Ticket>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var departureTime =
                    DateTime.ParseExact(dto.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var trip = context.Trips
                    .Include(t => t.OriginStation)
                    .Include(t => t.DestinationStation)
                    .Include(t => t.Train)
                    .ThenInclude(t => t.TrainSeats)
                    .SingleOrDefault(t =>
                        t.OriginStation.Name == dto.Trip.OriginStation &&
                t.DestinationStation.Name == dto.Trip.DestinationStation &&
                t.DepartureTime == departureTime);

                if (trip == null || !ValidatedSeat(context, dto.SeatingPlace, trip))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CustomerCard card = null;
                if (dto.Card != null)
                {
                    card = context.Cards.SingleOrDefault(c => c.Name == dto.Card.Name);

                    if (card == null)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }
                }

                var ticket = new Ticket
                {
                    Price = dto.Price,
                    SeatingPlace = dto.SeatingPlace,
                    Trip = trip,
                    CustomerCard = card
                };

                tickets.Add(ticket);

                sb.AppendLine(String.Format(SuccessTicketMessage,
                    trip.OriginStation.Name,
                    trip.DestinationStation.Name,
                    trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
            }

            context.Tickets.AddRange(tickets);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
        }

        private static bool ValidatedSeat(StationsDbContext context, string seatingPlace, Trip trip)
        {
            var abbreviation = seatingPlace.Substring(0, 2);

            var quantity = int.Parse(seatingPlace.Substring(2));

            var seat = context.SeatingClasses.SingleOrDefault(s => s.Abbreviation == abbreviation);

            var trainSeat = trip.Train.TrainSeats.SingleOrDefault(ts => ts.SeatingClassId == seat.Id && quantity <= ts.Quantity);

            if (trainSeat == null) return false;

            return true;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);

            return isValid;
        }
    }
}