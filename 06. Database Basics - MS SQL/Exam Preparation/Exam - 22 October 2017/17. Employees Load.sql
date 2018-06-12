CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
  RETURNS INT
AS
  BEGIN
    DECLARE @count INT = (SELECT count(*)
                          FROM Reports AS e
                          WHERE StatusId = @statusId AND EmployeeId = @employeeId)

    RETURN @count
  END

SELECT
  Id,
  FirstName,
  LastName,
  dbo.udf_GetReportsCount(Id, 2)
FROM Employees
ORDER BY Id
