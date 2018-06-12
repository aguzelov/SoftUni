WITH chp AS
(SELECT
   c.CountryName,
   p.PeakName,
   p.Elevation,
   m.MountainRange,
   ROW_NUMBER()
   OVER ( PARTITION BY c.CountryName
     ORDER BY p.Elevation DESC ) AS rn
 FROM Countries AS c
   LEFT JOIN CountriesRivers AS cr
     ON c.CountryCode = cr.CountryCode
   LEFT JOIN MountainsCountries AS mc
     ON mc.CountryCode = c.CountryCode
   LEFT JOIN Mountains AS m
     ON mc.MountainId = m.Id
   LEFT JOIN Peaks p
     ON p.MountainId = m.Id)

SELECT TOP 5
  chp.CountryName                           AS [Country],
  ISNULL(chp.PeakName, '(no highest peak)') AS [Highest Peak Name],
  ISNULL(chp.Elevation, 0)                  AS [Highest Peak Elevation],
  CASE WHEN chp.PeakName IS NOT NULL
    THEN chp.MountainRange
  ELSE '(no mountain)' END                  AS [Mountain]
FROM chp
WHERE rn = 1
ORDER BY chp.CountryName ASC, chp.PeakName ASC
