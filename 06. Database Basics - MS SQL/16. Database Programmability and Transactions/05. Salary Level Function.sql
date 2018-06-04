CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18, 4))
  RETURNS NVARCHAR(10)
AS
  BEGIN
    DECLARE @SalaryLevel NVARCHAR(10);

    IF (@salary < 30000)
      BEGIN
        SET @SalaryLevel = 'Low'
      END
    ELSE IF (@salary BETWEEN 30000 AND 50000)
      BEGIN
        SET @SalaryLevel = 'Average'
      END
    ELSE
      BEGIN
        SET @SalaryLevel = 'High'
      END

    RETURN @SalaryLevel
  END

SELECT
  Salary,
  dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
FROM Employees
ORDER BY Salary ASC