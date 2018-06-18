SELECT t.TicketID,
  a.AirportName AS [Destination],
  concat(c.FirstName,' ', c.LastName) AS [CustomerName]
FROM (
  SELECT *
  FROM Tickets
  WHERE Price < 5000 AND Class = 'First'
) AS t
left JOIN Flights f ON f.FlightID = t.FlightID
LEFT JOIN Airports a ON f.DestinationAirportID = a.AirportID
LEFT JOIN Customers c ON c.CustomerID = t.CustomerID
ORDER BY t.TicketID