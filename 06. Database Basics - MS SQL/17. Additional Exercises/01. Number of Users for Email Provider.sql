SELECT
  substring(Email, charindex('@', Email) + 1, len(Email) - charindex('@', Email) + 1) AS [Email Provider],
  count(*)                                                                            AS [Number Of Users]
FROM Users
GROUP BY substring(Email, charindex('@', Email) + 1, len(Email) - charindex('@', Email) + 1)
ORDER BY [Number Of Users] DESC, [Email Provider] ASC