SELECT DISTINCT c.Name AS [Category Name]
FROM Categories AS c
  JOIN Reports AS r
    ON c.Id = r.CategoryId
  JOIN Users AS u
    ON r.UserId = u.Id
WHERE DAY(r.OpenDate) = DAY(u.BirthDate)
      AND month(r.OpenDate) = month(u.BirthDate)
ORDER BY c.Name