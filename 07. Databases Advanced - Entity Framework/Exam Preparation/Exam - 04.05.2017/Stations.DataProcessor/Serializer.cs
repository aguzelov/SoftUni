using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stations.Data;
using Stations.DataProcessor.Dto.Export;
using Stations.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Stations.DataProcessor
{
    public class Serializer
    {
        public static string ExportDelayedTrains(StationsDbContext context, string dateAsString)
        {
            var departureTime =
                    DateTime.ParseExact(dateAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var trainDtos = context.Trips
                .Include(t => t.Train)
                .Where(t => t.Status == TripStatus.Delayed && t.DepartureTime <= departureTime)
                .Select(e => new
                {
                    e.Train.TrainNumber,
                    DelayedTime = e.TimeDifference
                })
                .ToArray();

            var grouped = new Dictionary<string, TrainExportDto>();
            foreach (var dto in trainDtos)
            {
                if (grouped.ContainsKey(dto.TrainNumber))
                {
                    grouped[dto.TrainNumber].DelayedTimes++;

                    var newTime = dto.DelayedTime ?? default(TimeSpan);
                    var oldTime = grouped[dto.TrainNumber].MaxDelayedTime;
                    if (newTime > oldTime)
                    {
                        grouped[dto.TrainNumber].MaxDelayedTime = newTime;
                    }
                }
                else
                {
                    grouped.Add(dto.TrainNumber, new TrainExportDto
                    {
                        TrainNumber = dto.TrainNumber,
                        DelayedTimes = 1,
                        MaxDelayedTime = dto.DelayedTime ?? default(TimeSpan)
                    });
                }
            }

            var trains = grouped.Values
                .ToList()
                .OrderByDescending(t => t.DelayedTimes)
                .ThenByDescending(t => t.MaxDelayedTime)
                .ThenBy(t => t.TrainNumber);

            var jsonString = JsonConvert.SerializeObject(trains, Newtonsoft.Json.Formatting.Indented);

            return jsonString;
        }

        public static string ExportCardsTicket(StationsDbContext context, string cardType)
        {
            var sb = new StringBuilder();

            var type = Enum.Parse<CardType>(cardType);

            var cards = context
                .Cards
                .Where(c => c.Type == type && c.BoughtTickets.Any())
                .Select(c => new CardExportDto
                {
                    Name = c.Name,
                    Type = c.Type.ToString(),
                    Tickets = c.BoughtTickets.Select(t => new TicketExportDto
                    {
                        OriginStation = t.Trip.OriginStation.Name,
                        DestinationStation = t.Trip.DestinationStation.Name,
                        DepartureTime = t.Trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    })
                    .ToArray()
                })
                .OrderBy(c => c.Name)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CardExportDto[]), new XmlRootAttribute("Cards"));
            serializer.Serialize(new StringWriter(sb),
                cards,
                new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty, }));

            return sb.ToString();
        }
    }
}