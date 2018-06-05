UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'


INSERT INTO Monasteries (Name, CountryCode)
  (SELECT
     'Hanga Abbey',
     CountryCode
   FROM Countries
   WHERE CountryName = 'Tanzania')

INSERT INTO Monasteries (Name, CountryCode)
  (SELECT
     'Myin-Tin-Daik',
     CountryCode
   FROM Countries
   WHERE CountryName = 'Myanmar')


SELECT
  con.ContinentName AS [ContinentName],
  c.CountryName     AS [CountryName],
  count(m.Id)       AS [MonasteriesCount]
FROM Continents AS con
  JOIN Countries AS c
    ON c.ContinentCode = con.ContinentCode
  LEFT JOIN Monasteries AS m
    ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
GROUP BY c.CountryName, con.ContinentName
ORDER BY MonasteriesCount DESC, CountryName ASC