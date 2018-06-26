SELECT
  c.Name      AS [City],
  count(h.Id) AS [Hotels]
FROM dbo.Cities c
  LEFT JOIN dbo.Hotels h
    ON h.CityId = c.Id
GROUP BY c.Name
ORDER BY Hotels DESC, c.Name
