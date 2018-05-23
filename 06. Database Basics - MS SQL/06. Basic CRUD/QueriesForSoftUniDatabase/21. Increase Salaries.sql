UPDATE Employees
SET Salary = Salary / 1.12
WHERE DepartmentID IN (SELECT DepartmentID FROM Departments
WHERE Name = 'Engineering' OR Name = 'Tool Design' OR Name = 'Marketing' OR Name = 'Information Services')

SELECT Salary FROM Employees