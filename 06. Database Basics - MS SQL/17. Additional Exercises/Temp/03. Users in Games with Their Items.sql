SELECT
  u.Username,
  g.Name,
  count(item.ItemId) AS [Items Count],
  sum(i.Price)       AS [Items Price]
FROM Users u
  LEFT JOIN UsersGames game
    ON u.Id = game.UserId
  LEFT JOIN Games g
    ON game.GameId = g.Id
  LEFT JOIN UserGameItems item
    ON game.Id = item.UserGameId
  LEFT JOIN Items i
    ON item.ItemId = i.Id
GROUP BY u.Username, g.Name
HAVING count(item.ItemId) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username ASC