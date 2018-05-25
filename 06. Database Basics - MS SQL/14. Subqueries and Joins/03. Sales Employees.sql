SELECT
  EmployeeID,
  FirstName,
  LastName,
  D2.Name
FROM Employees
  JOIN Departments D2
    ON Employees.DepartmentID = D2.DepartmentID
WHERE D2.Name = 'Sales'
ORDER BY EmployeeID

