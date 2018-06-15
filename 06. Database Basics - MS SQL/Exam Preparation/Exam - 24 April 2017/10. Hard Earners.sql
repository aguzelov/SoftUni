SELECT TOP (3)
  m.FirstName + ' ' + m.LastName AS [Mechanic],
  count(*)                       AS [Jobs]
FROM Mechanics m
  JOIN Jobs j
    ON m.MechanicId = j.MechanicId
GROUP BY m.FirstName + ' ' + m.LastName, j.Status, j.MechanicId
HAVING j.Status <> 'Finished' AND count(*) > 1
ORDER BY Jobs DESC, j.MechanicId ASC