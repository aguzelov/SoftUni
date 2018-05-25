SELECT count(*) as [CountryCode]
FROM (
       SELECT mc.CountryCode
       FROM Countries AS c
         LEFT JOIN MountainsCountries AS mc
           ON c.CountryCode = mc.CountryCode
       WHERE mc.CountryCode IS NULL
     ) AS CountriesWithoutMountains
