CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan(@SearchedTotalMoney DECIMAL(16,2))
AS
  SELECT
    AH.FirstName AS [First Name],
    AH.LastName AS [Last Name]
  FROM AccountHolders AS ah
    INNER JOIN Accounts AS a
      ON ah.Id = a.AccountHolderId
  GROUP BY ah.FirstName, ah.LastName
  HAVING SUM(a.Balance) >= @SearchedTotalMoney
