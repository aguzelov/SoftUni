SELECT Username, IpAddress AS [IP Address] 
  FROM Users
 WHERE IpAddress LIKE '___.1[0-9]%.[0-9]%.___'
 ORDER BY Username ASC