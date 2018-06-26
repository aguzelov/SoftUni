SELECT
  g.Name,
  gt.Name,
  u.Username,
  ug.Level,
  ug.Cash,
  c.Name
FROM Users u
  LEFT JOIN UsersGames ug
    ON u.Id = ug.UserId
  LEFT JOIN Games g
    ON ug.GameId = g.Id
  LEFT JOIN GameTypes gt
    ON g.GameTypeId = gt.Id
  LEFT JOIN Characters c
    ON ug.CharacterId = c.Id
ORDER BY ug.Level DESC, u.Username, g.Name