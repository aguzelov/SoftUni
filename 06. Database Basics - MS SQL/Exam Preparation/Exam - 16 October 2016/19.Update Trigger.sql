CREATE TRIGGER TR_ArrivedFlights
  ON Flights
  FOR UPDATE
AS
  BEGIN
    INSERT INTO ArrivedFlights (FlightID, ArrivalTime, Origin, Destination, Passengers)
      (SELECT
         i.FlightID,
         i.ArrivalTime,
         ao.AirportName,
         ad.AirportName,
         ISNULL(COUNT(ti.CustomerID), 0)
       FROM inserted AS i
         JOIN Airports AS ao
           ON ao.AirportID = i.OriginAirportID
         JOIN Airports AS ad
           ON ad.AirportID = i.DestinationAirportID
         LEFT JOIN Tickets AS ti
           ON ti.FlightID = i.FlightID
       WHERE i.Status = 'Arrived'
       GROUP BY i.FlightID, i.ArrivalTime, ao.AirportName, ad.AirportName
      )
  END
