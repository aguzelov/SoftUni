SELECT
  c.CountryName,
  c2.ContinentName,
  isnull(count(r.Id),0)   AS [RiversCount],
  isnull(sum(r.Length),0) AS [TotalLength]
FROM Countries c
  LEFT JOIN CountriesRivers cr
    ON c.CountryCode = cr.CountryCode
  LEFT JOIN Rivers r
    ON cr.RiverId = r.Id
  LEFT JOIN Continents c2
    ON c.ContinentCode = c2.ContinentCode
GROUP BY c.CountryName, c2.ContinentName
ORDER BY RiversCount DESC , TotalLength DESC, c.CountryName