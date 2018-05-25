SELECT c.CountryCode, count(m.MountainRange)
FROM Countries AS c
  INNER JOIN MountainsCountries mc
    ON c.CountryCode = mc.CountryCode
  INNER JOIN Mountains m
    ON mc.MountainId = m.Id
WHERE c.CountryName in ('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode