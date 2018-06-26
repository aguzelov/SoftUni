SELECT TOP 5
  c.Id,
  c.Name        AS [City],
  c.CountryCode AS [Country],
  count(a.Id)   AS [Accounts]
FROM Cities c
  JOIN Accounts a
    ON c.Id = a.CityId
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC
