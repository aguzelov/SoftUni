SELECT min(avg) AS [MinAverageSalary]
FROM (
       SELECT avg(Salary) AS [avg]
       FROM Employees
       GROUP BY DepartmentID
     ) AS AverageSalary

