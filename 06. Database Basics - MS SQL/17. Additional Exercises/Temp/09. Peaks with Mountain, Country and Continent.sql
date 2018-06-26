SELECT p.PeakName, m2.MountainRange, c.CountryName, c2.ContinentName
FROM Peaks p
JOIN Mountains m2 ON p.MountainId = m2.Id
JOIN MountainsCountries mc ON m2.Id = mc.MountainId
JOIN Countries c ON mc.CountryCode = c.CountryCode
JOIN Continents c2 ON c.ContinentCode = c2.ContinentCode
ORDER BY p.PeakName, c.CountryName

