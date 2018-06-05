SELECT
  i.Name,
  i.Price,
  i.MinLevel,
  s.Strength,
  s.Defence,
  s.Speed,
  s.Luck,
  s.Mind
FROM (
       SELECT Id
       FROM [Statistics]
       WHERE Mind > (SELECT avg(Mind * 1.0)
                     FROM [Statistics]) AND
             Luck > (SELECT avg(Luck * 1.0)
                     FROM [Statistics]) AND
             Speed > (SELECT avg(Speed * 1.0)
                      FROM [Statistics])
     ) AS av
  INNER JOIN [Statistics] AS s
    ON av.Id = s.Id
  INNER JOIN Items AS i
    ON i.StatisticId = s.Id
ORDER BY Name