  SELECT TOP 10 FirstName, 
         LastName, 
   	     DepartmentID 
    FROM Employees as e1
   WHERE Salary > (SELECT AVG(Salary) AS AvarageSalary 
   					 FROM Employees as e2
   				    WHERE e1.DepartmentID = e2.DepartmentID
   				 GROUP BY DepartmentID)
ORDER BY DepartmentID