SELECT DISTINCT
  c.CustomerID,
  concat(c.FirstName, ' ', c.LastName)      AS [FullName],
  datediff(YEAR, c.DateOfBirth, '2016-1-1') AS [Age]
FROM Tickets t
  JOIN Flights f
    ON t.FlightID = f.FlightID
  JOIN Customers c
    ON t.CustomerID = c.CustomerID
WHERE f.Status = 'Departing'
ORDER BY Age, c.CustomerID
