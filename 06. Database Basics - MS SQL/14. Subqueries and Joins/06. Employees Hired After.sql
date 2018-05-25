SELECT
  e.FirstName,
  e.LastName,
  e.HireDate,
  d.Name
FROM Employees AS e
  JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '1.1.1999'
      AND d.Name IN ('Sales', 'Finance')
ORDER BY HireDate ASC