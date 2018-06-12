SELECT
  Department,
  Category,
  Percentage
FROM (
       SELECT
         d.Name AS Department,
         c.Name AS Category,
         cast(
             round(
                 count(*)
                 OVER ( PARTITION BY c.Id) * 100.00 /
                 count(*)
                 OVER ( PARTITION BY d.Id),
                 0
             ) AS INT
         )      AS Percentage
       FROM Departments AS d
         JOIN Categories c
           ON d.Id = c.DepartmentId
         JOIN Reports r
           ON c.Id = r.CategoryId
     ) AS Stats
GROUP BY department, category,percentage
ORDER BY department, category,percentage