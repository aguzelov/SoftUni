SELECT DISTINCT
  c.CustomerID,
  concat(c.FirstName, ' ', c.LastName)      AS [FullName],
  datediff(YEAR, c.DateOfBirth, '2016-1-1') AS [Age]
FROM Customers c
  JOIN Tickets t
    ON c.CustomerID = t.CustomerID
  LEFT JOIN Flights f
    ON t.FlightID = f.FlightID
WHERE datediff(YEAR, c.DateOfBirth, '2016-1-1') < 21
      AND f.Status = 'Arrived'
ORDER BY Age DESC, c.CustomerID