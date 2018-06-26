SELECT
  con.ContinentName                 AS [ContinentName],
  sum(cast(c.AreaInSqKm AS BIGINT)) AS [CountriesArea],
  sum(cast(c.Population AS BIGINT)) AS [CountriesPopulation]
FROM Continents con
  JOIN Countries c
    ON con.ContinentCode = c.ContinentCode
GROUP BY con.ContinentName
ORDER BY CountriesPopulation DESC