SELECT
  e.FirstName + ' ' + e.LastName AS [Name],
  ISNULL(convert(VARCHAR, closesum.Sum), 0) + '/' +
  ISNULL(convert(VARCHAR, opensum.Sum), 0)
FROM Employees AS e
  JOIN (SELECT
          EmployeeId,
          count(*) AS [Sum]
        FROM Reports
        WHERE YEAR(OpenDate) = '2016'
        GROUP BY EmployeeId) AS OpenSum
    ON e.Id = opensum.EmployeeId
  LEFT JOIN (SELECT
               EmployeeId,
               count(*) AS [Sum]
             FROM Reports
             WHERE YEAR(CloseDate) = '2016'
             GROUP BY EmployeeId) AS CloseSum
    ON e.Id = closesum.EmployeeId
ORDER BY Name