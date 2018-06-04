CREATE PROCEDURE usp_WithdrawMoney(@AccountId INT, @MoneyAmount MONEY)
AS
  BEGIN TRANSACTION
  UPDATE Accounts
  SET Balance -= @MoneyAmount
  WHERE Id = @AccountId
  COMMIT