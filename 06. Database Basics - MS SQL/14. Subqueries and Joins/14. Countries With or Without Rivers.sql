SELECT TOP 5
  c.CountryName,
  r.RiverName
FROM Countries AS c
  INNER JOIN Continents AS con
    ON c.ContinentCode = con.ContinentCode
  LEFT JOIN CountriesRivers cr
    ON c.CountryCode = cr.CountryCode
  LEFT JOIN Rivers r
    ON cr.RiverId = r.Id
WHERE con.ContinentName = 'Africa'
ORDER BY c.CountryName ASC