SELECT
  a.AirportID,
  a.AirportName,
  count(c.CustomerID) AS [Passengers]
FROM Airports a
  JOIN Flights f
    ON a.AirportID = f.OriginAirportID
  JOIN Tickets t
    ON f.FlightID = t.FlightID
  JOIN Customers c
    ON t.CustomerID = c.CustomerID
WHERE f.Status = 'Departing'
GROUP BY a.AirportID, a.AirportName
HAVING count(c.CustomerID) > 0
ORDER BY a.AirportID
