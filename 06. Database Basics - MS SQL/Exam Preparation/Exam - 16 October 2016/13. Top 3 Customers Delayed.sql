SELECT TOP 3
  c.CustomerID,
  concat(c.FirstName, ' ', c.LastName) AS [FullName],
  t.Price                              AS [TicketPrice],
  a.AirportName                        AS [Destination]
FROM Tickets t
  JOIN Flights f
    ON t.FlightID = f.FlightID
  JOIN Customers c
    ON t.CustomerID = c.CustomerID
  JOIN Airports a
    ON f.DestinationAirportID = a.AirportID
WHERE f.Status = 'Delayed'
ORDER BY TicketPrice DESC