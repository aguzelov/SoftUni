CREATE PROCEDURE usp_AssignProject(@employeeId INT, @projectID INT)
AS
  BEGIN
    BEGIN TRAN
    INSERT INTO EmployeesProjects
    VALUES (@employeeId, @projectID)
    IF (SELECT COUNT(ProjectID)
        FROM EmployeesProjects
        WHERE EmployeeID = @employeeId) > 3
      BEGIN
        RAISERROR ('The employee has too many projects!', 16, 1)
        ROLLBACK
        RETURN
      END
    COMMIT
  END