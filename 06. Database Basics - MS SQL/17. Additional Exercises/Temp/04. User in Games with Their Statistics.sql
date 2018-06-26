SELECT
  u.Username,
  g.Name,
  c.Name,
  s.Strength,
  s.Defence,
  s.Speed,
  s.Mind,
  s.Luck
FROM Games g
  JOIN UsersGames ug
    ON g.Id = ug.GameId
  JOIN Users u
    ON ug.UserId = u.Id
  JOIN Characters c
    ON ug.CharacterId = c.Id
  JOIN [Statistics] s
    ON c.StatisticId = s.Id

