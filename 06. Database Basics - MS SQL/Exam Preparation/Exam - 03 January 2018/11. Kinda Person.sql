WITH chp AS
(SELECT
   c.FirstName + ' ' + c.LastName   AS [Name],
   m.Class                          AS [Class],
   DENSE_RANK()
   OVER ( PARTITION BY c.FirstName + ' ' + c.LastName
     ORDER BY count(m.Class) DESC ) AS rn
 FROM Clients AS c
   LEFT JOIN Orders AS o
     ON c.Id = o.ClientId
   LEFT JOIN Vehicles AS v
     ON o.VehicleId = v.Id
   LEFT JOIN Models AS m
     ON v.ModelId = m.Id
 GROUP BY c.FirstName + ' ' + c.LastName, m.Class)

SELECT
  chp.Name  AS [Name],
  chp.Class AS [Class]
FROM chp
WHERE rn = 1 AND chp.Class IS NOT NULL
ORDER BY chp.Name ASC, chp.Class ASC
