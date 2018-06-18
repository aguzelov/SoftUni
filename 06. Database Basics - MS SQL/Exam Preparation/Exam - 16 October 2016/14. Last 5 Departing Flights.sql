SELECT
  f.FlightID,
  f.DepartureTime,
  f.ArrivalTime,
  originA.AirportName AS [Origin],
  destA.AirportName   AS [Destination]
FROM (
       SELECT TOP 5 *
       FROM Flights f
       WHERE Status = 'Departing'
       ORDER BY DepartureTime DESC
     ) AS f
  JOIN Airports destA
    ON f.DestinationAirportID = destA.AirportID
  JOIN Airports originA
    ON f.OriginAirportID = originA.AirportID
ORDER BY f.DepartureTime, f.FlightID ASC

