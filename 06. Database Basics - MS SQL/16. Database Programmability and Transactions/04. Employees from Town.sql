CREATE PROCEDURE usp_GetEmployeesFromTown @TownName NVARCHAR(10)
AS
  SELECT
    e.FirstName,
    e.LastName
  FROM Employees AS e
    INNER JOIN Addresses AS a
      ON e.AddressID = a.AddressID
    INNER JOIN Towns AS t
      ON a.TownID = t.TownID
  WHERE t.Name = @TownName