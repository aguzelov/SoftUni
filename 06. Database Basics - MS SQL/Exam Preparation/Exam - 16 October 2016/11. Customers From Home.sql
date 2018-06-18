SELECT DISTINCT
  c.CustomerID                         AS [CustomerID],
  concat(c.FirstName, ' ', c.LastName) AS [FullName],
  t2.TownName                          AS [HomeTown]
FROM Customers c
  JOIN Tickets t
    ON c.CustomerID = t.CustomerID
  JOIN Flights f
    ON t.FlightID = f.FlightID
  JOIN Airports a
    ON f.OriginAirportID = a.AirportID
  JOIN Towns t2
    ON a.TownID = t2.TownID AND c.HomeTownID = a.TownID
ORDER BY c.CustomerID