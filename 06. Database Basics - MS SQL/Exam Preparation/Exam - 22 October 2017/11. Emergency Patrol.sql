SELECT
  r.OpenDate,
  r.Description,
  u.Email
FROM Reports AS r
  JOIN Users AS u
    ON r.UserId = u.Id
WHERE CloseDate IS NULL AND len(Description) > 20 AND Description LIKE '%str%' AND CategoryId IN (SELECT Id
                                                                                                  FROM Categories
                                                                                                  WHERE DepartmentId IN
                                                                                                        (SELECT Id
                                                                                                         FROM
                                                                                                           Departments
                                                                                                         WHERE Name IN
                                                                                                               ('Infrastructure', 'Emergency', 'Roads Maintenance')))
ORDER BY r.OpenDate, u.Email, r.Id