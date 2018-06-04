CREATE FUNCTION ufn_CalculateFutureValue(@Sum MONEY, @YearlyInterestRate FLOAT, @NumberOfYears INT)
  RETURNS MONEY
AS
  BEGIN
    RETURN @Sum * POWER(1 + @YearlyInterestRate, @NumberOfYears)
  END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.10, 5) AS FV