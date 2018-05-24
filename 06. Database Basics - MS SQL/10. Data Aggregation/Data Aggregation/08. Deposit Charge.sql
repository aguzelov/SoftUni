  SELECT DepositGroup, 
	     MagicWandCreator, 
	     MIN(DepositCharge)
    FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator ASC, DepositGroup ASC