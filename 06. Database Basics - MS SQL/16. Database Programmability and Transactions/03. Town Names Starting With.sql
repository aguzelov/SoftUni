CREATE PROCEDURE usp_GetTownsStartingWith @TownNamePrefix NVARCHAR(10)
AS
  SELECT Name
  FROM Towns
  WHERE Name LIKE @TownNamePrefix + '%'
