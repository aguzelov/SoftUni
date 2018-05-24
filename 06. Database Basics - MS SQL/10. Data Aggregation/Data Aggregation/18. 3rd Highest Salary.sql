SELECT OrderedSalaries.DepartmentID, 
	   OrderedSalaries.Salary AS ThirdHighestSalary 
  FROM (
	     SELECT DepartmentId,
	            MAX(Salary) AS Salary,
	            DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS Rank
	       FROM Employees
	   GROUP BY DepartmentID, Salary
	   )
	   AS OrderedSalaries
WHERE Rank=3