SELECT
  c.Name AS [CategoryName],
  count(r.Id) AS [ReportsNumber]
FROM Categories AS c
  JOIN Reports r
    ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY count(r.Id) DESC, c.Name ASC