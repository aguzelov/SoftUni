SELECT
  g.Name     AS [Game],
  gt.Name    AS [Game Type],
  u.Username AS [Username],
  ug.Level   AS [Level],
  ug.Cash    AS [Cash],
  c.Name     AS [Character]
FROM Games AS g
  INNER JOIN GameTypes AS gt
    ON g.GameTypeId = gt.Id
  INNER JOIN UsersGames AS ug
    ON g.Id = ug.GameId
  INNER JOIN Users AS u
    ON ug.UserId = u.Id
  INNER JOIN Characters AS c
    ON ug.CharacterId = c.Id
ORDER BY ug.Level DESC, u.Username ASC, g.Name ASC