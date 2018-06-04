CREATE PROCEDURE usp_EmployeesBySalaryLevel @LevelOfSalary NVARCHAR(10)
AS
  SELECT
    FirstName,
    LastName
  FROM Employees
  WHERE @LevelOfSalary = dbo.ufn_GetSalaryLevel(Salary)