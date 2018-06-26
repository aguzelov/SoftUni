UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'


INSERT INTO Monasteries (Name, CountryCode)
  (
    SELECT
      'Hanga Abbey',
      Countries.CountryCode
    FROM Countries
    WHERE CountryName = 'Tanzania'
  )


INSERT INTO Monasteries (Name, CountryCode)
  (
    SELECT
      'Myin-Tin-Daik',
      CountryCode
    FROM Countries
    WHERE CountryName = 'Myanmar')


SELECT
  c2.ContinentName AS [ContinentName],
  c.CountryName    AS [CountryName],
  count(m2.Id)     AS [MonasteriesCount]
FROM Countries c
  LEFT JOIN Monasteries m2
    ON c.CountryCode = m2.CountryCode
  JOIN Continents c2
    ON c.ContinentCode = c2.ContinentCode
WHERE c.IsDeleted = 0
GROUP BY c.CountryName, c2.ContinentName
ORDER BY MonasteriesCount DESC, CountryName