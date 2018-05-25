SELECT
  E.EmployeeID,
  E.FirstName,
  CASE
  WHEN datepart(YEAR, P.StartDate) >= 2005
    THEN NULL
  ELSE P.Name
  END AS [ProjectName]
FROM Employees AS E
  INNER JOIN EmployeesProjects AS EP
    ON E.EmployeeID = EP.EmployeeID
  INNER JOIN Projects AS P
    ON EP.ProjectID = P.ProjectID
WHERE E.EmployeeID = 24