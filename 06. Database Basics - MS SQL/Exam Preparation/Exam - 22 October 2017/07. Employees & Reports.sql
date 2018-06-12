SELECT e.FirstName,
  e.LastName,
  r.Description,
  FORMAT(r.OpenDate, 'yyyy-MM-dd') AS [OpenDate]
FROM Reports AS r
 JOIN Employees e
    ON r.EmployeeId = e.Id
ORDER BY e.Id ASC , OpenDate ASC , r.Id ASC