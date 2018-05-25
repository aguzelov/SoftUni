SELECT TOP 5
  e.EmployeeID,
  e.FirstName,
  p.Name
FROM Employees AS e
  INNER JOIN EmployeesProjects AS ep
    ON e.EmployeeID = ep.EmployeeID
  INNER JOIN Projects p
    ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002'
      AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC
