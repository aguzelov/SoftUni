SELECT
  E.Firstname + ' ' + E.Lastname AS FullName,
  COUNT(DISTINCT R.Userid)       AS UsersCount
FROM Employees AS E
  LEFT JOIN Reports AS R
    ON R.Employeeid = E.Id
GROUP BY E.Firstname + ' ' + E.Lastname
ORDER BY UsersCount DESC,
  FullName;