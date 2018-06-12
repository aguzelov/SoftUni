CREATE PROCEDURE usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
  BEGIN
    BEGIN TRANSACTION
    DECLARE @categoryId INT = (SELECT CategoryId
                               FROM Reports
                               WHERE Id = @reportId);


    DECLARE @emploeeyDepId INT = (SELECT DepartmentId
                                  FROM Employees
                                  WHERE Id = @employeeId);


    DECLARE @categoryDepId INT = (SELECT DepartmentId
                                  FROM Categories
                                  WHERE Id = @categoryId)

    UPDATE Reports
    SET EmployeeId = @employeeId
    WHERE Id = @reportId

    IF (@employeeId IS NOT NULL AND @categoryDepId <> @emploeeyDepId)
      BEGIN
        ROLLBACK;
        THROW 50013, 'Employee doesn''t belong to the appropriate department!', 1;
      END
    COMMIT
  END

EXEC usp_AssignEmployeeToReport 17, 2;
SELECT EmployeeId FROM Reports WHERE id = 2