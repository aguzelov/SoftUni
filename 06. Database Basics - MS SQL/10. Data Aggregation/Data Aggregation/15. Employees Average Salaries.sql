SELECT * INTO PlayingTable 
  FROM Employees
 WHERE Salary > 30000 

DELETE 
  FROM PlayingTable
 WHERE ManagerID = 42

UPDATE PlayingTable
   SET Salary += 5000
 WHERE DepartmentID = 1

 SELECT DepartmentID, 
		AVG(Salary) AS [AverageSalary]
   FROM PlayingTable
GROUP BY DepartmentID