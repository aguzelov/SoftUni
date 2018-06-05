SELECT
  u.Username   AS Username,
  g.Name       AS Game,
  COUNT(i.Id)  AS ItemsCount,
  SUM(i.Price) AS Cash
FROM Games AS g
  INNER JOIN UsersGames AS ug
    ON ug.GameId = g.Id
  INNER JOIN Users AS u
    ON u.Id = ug.UserId
  INNER JOIN UserGameItems AS ugt
    ON ugt.UserGameId = ug.Id
  INNER JOIN Items AS i
    ON i.Id = ugt.ItemId
GROUP BY u.Username, g.Name
HAVING COUNT(i.Id) >= 10
ORDER BY ItemsCount DESC, Cash DESC, u.Username