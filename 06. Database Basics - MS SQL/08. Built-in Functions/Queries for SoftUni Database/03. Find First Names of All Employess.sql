SELECT FirstName 
  FROM Employees
 WHERE DepartmentID IN (SELECT DepartmentID 
						FROM Departments
					   WHERE DepartmentID = 3 
							 OR DepartmentID = 10)
   AND DATEDIFF(YEAR, '1995', HireDate) >=0
   AND  datediff(YEAR, HireDate,'2005') >=0
 
