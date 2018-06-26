SELECT substring(Email,charindex('@',Email)+1,len(Email) - charindex('@',Email)) AS [Email Provider],
  count(*) AS [Number Of Users]
FROM Users
GROUP BY substring(Email,charindex('@',Email)+1,len(Email) - charindex('@',Email))
ORDER BY [Number Of Users] DESC, [Email Provider] ASC