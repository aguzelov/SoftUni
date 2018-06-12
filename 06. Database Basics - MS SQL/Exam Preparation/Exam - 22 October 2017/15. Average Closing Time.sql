SELECT
  d.Name,
  isnull(convert(VARCHAR,avg(DATEDIFF(DAY, r.OpenDate, r.CloseDate))), 'no info') AS [Closed Open Reports]
FROM Departments AS d
  JOIN Categories c
    ON d.Id = c.DepartmentId
  JOIN Reports r
    ON c.Id = r.CategoryId
GROUP BY d.Name
ORDER BY d.Name