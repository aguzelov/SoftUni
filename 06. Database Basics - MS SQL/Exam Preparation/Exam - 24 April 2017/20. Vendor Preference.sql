SELECT
  m.FirstName + ' ' + m.LastName AS [Mechanic],
  v.Name                         AS [Vendor],
  sum(
      part.Quantity)             AS [Parts],
  cast(cast((cast(sum(part.Quantity) AS DECIMAL(6, 2)) / totalcount.TotalCount) * 100 AS INT) AS VARCHAR(50)) +
  '%'                            AS [Preference]
FROM Mechanics AS m
  JOIN Jobs j
    ON m.MechanicId = j.MechanicId
  JOIN Orders o
    ON j.JobId = o.JobId
  JOIN OrderParts part
    ON o.OrderId = part.OrderId
  JOIN Parts p
    ON part.PartId = p.PartId
  JOIN Vendors v
    ON p.VendorId = v.VendorId
  JOIN (
         SELECT
           m.MechanicId,
           sum(part.Quantity) AS [TotalCount]
         FROM Mechanics AS m
           JOIN Jobs j
             ON m.MechanicId = j.MechanicId
           JOIN Orders o
             ON j.JobId = o.JobId
           JOIN OrderParts part
             ON o.OrderId = part.OrderId
           JOIN Parts p
             ON part.PartId = p.PartId
           JOIN Vendors v
             ON p.VendorId = v.VendorId
         GROUP BY m.MechanicId
       ) AS TotalCount
    ON totalcount.MechanicId = m.MechanicId
GROUP BY m.FirstName + ' ' + m.LastName, v.Name, totalcount.TotalCount
ORDER BY Mechanic ASC, Parts DESC, Vendor ASC
