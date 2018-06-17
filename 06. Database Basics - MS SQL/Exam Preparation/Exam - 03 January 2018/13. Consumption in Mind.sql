SELECT
  m.Manufacturer     AS [Manufacturer],
  avg(m.Consumption) AS [AverageConsumption]
FROM
  (SELECT TOP 7
     m.Id,
     count(o.VehicleId) AS [OrdersCount]
   FROM Orders o
     JOIN Vehicles v
       ON o.VehicleId = v.Id
     JOIN Models m
       ON v.ModelId = m.Id
   GROUP BY m.Id
   ORDER BY count(o.VehicleId) DESC
  ) AS mostOrdered
  JOIN Models m
    ON m.Id = mostordered.Id
GROUP BY m.Manufacturer
HAVING avg(m.Consumption) BETWEEN 5 AND 15