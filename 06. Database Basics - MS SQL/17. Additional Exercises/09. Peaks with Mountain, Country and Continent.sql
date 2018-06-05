SELECT
  p.PeakName,
  m.MountainRange,
  c.CountryName,
  c2.ContinentName
FROM Peaks AS p
  JOIN Mountains AS m
    ON p.MountainId = m.Id
  JOIN MountainsCountries mc
    ON m.Id = mc.MountainId
  JOIN Countries c
    ON mc.CountryCode = c.CountryCode
  JOIN Continents c2
    ON c.ContinentCode = c2.ContinentCode
ORDER BY p.PeakName ASC, c.CountryName ASC