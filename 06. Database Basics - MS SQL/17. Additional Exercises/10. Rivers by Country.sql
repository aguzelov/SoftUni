SELECT
  c.CountryName,
  c2.ContinentName,
  count(r.Id)              AS [RiverCount],
  isnull(SUM(r.Length), 0) AS [TotalLength]
FROM Countries AS c
  LEFT JOIN CountriesRivers AS cr
    ON c.CountryCode = cr.CountryCode
  LEFT JOIN Rivers r
    ON cr.RiverId = r.Id
  INNER JOIN Continents AS c2
    ON c.ContinentCode = c2.ContinentCode
GROUP BY c.CountryName, c2.ContinentName
ORDER BY RiverCount DESC, TotalLength DESC, CountryName ASC


