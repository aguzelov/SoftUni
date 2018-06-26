SELECT
  i.Name,
  i.Price,
  i.MinLevel,
  s.Strength,
  s.Defence,
  s.Speed,
  s.Luck,
  s.Mind
FROM Items i
  JOIN [Statistics] s
    ON i.StatisticId = s.Id
WHERE s.Mind > (
  SELECT avg(Mind) AS [avgMin]
  FROM [Statistics]
)
      AND s.Luck > (
  SELECT avg(Mind) AS [avgMin]
  FROM [Statistics]
)
      AND s.Speed > (
  SELECT avg(Mind) AS [avgMin]
  FROM [Statistics]
)
ORDER BY i.Name ASC