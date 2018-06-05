SELECT
  u.Username,
  g.Name                                                 AS Game,
  Max(c.Name)                                            AS Character,
  MAX(s1.Strength) + MAX(s2.Strength) + SUM(s3.Strength) AS Strength,
  MAX(s1.Defence) + MAX(s2.Defence) + SUM(s3.Defence)    AS Defence,
  MAX(s1.Speed) + MAX(s2.Speed) + SUM(s3.Speed)          AS Speed,
  MAX(s1.Mind) + MAX(s2.Mind) + SUM(s3.Mind)             AS Mind,
  MAX(s1.Luck) + MAX(s2.Luck) + SUM(s3.Luck)             AS Luck
FROM UsersGames AS ug
  INNER JOIN Users AS u
    ON ug.UserId = u.Id
  INNER JOIN Games AS g
    ON ug.GameId = g.Id
  INNER JOIN Characters AS c
    ON ug.CharacterId = c.Id
  INNER JOIN [Statistics] AS s1
    ON c.StatisticId = s1.Id
  INNER JOIN GameTypes AS gt
    ON g.GameTypeId = gt.Id
  INNER JOIN [Statistics] s2
    ON gt.BonusStatsId = s2.Id
  INNER JOIN UserGameItems AS ugi
    ON ug.Id = ugi.UserGameId
  INNER JOIN Items AS i
    ON ugi.ItemId = i.Id
  INNER JOIN [Statistics] AS s3
    ON i.StatisticId = s3.Id
GROUP BY u.Username, g.Name
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC