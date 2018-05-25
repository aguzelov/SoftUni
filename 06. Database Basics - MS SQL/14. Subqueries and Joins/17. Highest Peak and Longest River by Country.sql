SELECT TOP (5)
       Sorted.CountryName,
	   MAX(Sorted.PeakElevation) AS HighestPeakElevation,
	   MAX(Sorted.RiverLength) AS LongestRiverLength
  FROM (
         SELECT c.CountryName AS CountryName,
         	   p.Elevation AS PeakElevation,
         	   r.Length AS RiverLength
           FROM Countries AS c
         LEFT JOIN MountainsCountries AS mc
         ON c.CountryCode = mc.CountryCode
         LEFT JOIN Peaks AS p
         ON mc.MountainId = p.MountainId
         LEFT JOIN CountriesRivers AS cr
         ON c.CountryCode = cr.CountryCode
         LEFT JOIN Rivers AS r
         ON cr.RiverId = r.Id
        ) AS Sorted
 GROUP BY Sorted.CountryName
 ORDER BY MAX(Sorted.PeakElevation) DESC,
	      MAX(Sorted.RiverLength) DESC,
		  Sorted.CountryName