SELECT TOP 50
  FirstName,
  LastName,
  T.Name AS Town,
  A.AddressText
FROM Employees
  INNER JOIN Addresses A
    ON Employees.AddressID = A.AddressID
  INNER JOIN Towns T
    ON A.TownID = T.TownID
ORDER BY FirstName ASC, LastName