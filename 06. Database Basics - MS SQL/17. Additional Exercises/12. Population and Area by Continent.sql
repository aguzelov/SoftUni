SELECT
  c.ContinentName  AS [ContinentName],
  sum(c2.AreaInSqKm) AS [CountriesArea],
  sum(cast(c2.Population AS FLOAT) ) AS [CountriesPopulation]
FROM Continents AS c
  JOIN Countries AS c2
    ON c2.ContinentCode = c.ContinentCode
GROUP BY c.ContinentName
ORDER BY CountriesPopulation DESC