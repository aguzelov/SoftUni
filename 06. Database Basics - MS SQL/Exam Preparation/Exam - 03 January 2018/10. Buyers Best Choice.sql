SELECT
  m.Manufacturer     AS [Manufacturer],
  m.Model            AS [Model],
  count(o.VehicleId) AS [TimesOrdered]
FROM Vehicles AS v
  JOIN Models AS m
    ON v.ModelId = m.Id
  LEFT JOIN Orders AS o
    ON v.Id = o.VehicleId
GROUP BY m.Manufacturer, m.Model
ORDER BY TimesOrdered DESC, Manufacturer DESC, Model ASC