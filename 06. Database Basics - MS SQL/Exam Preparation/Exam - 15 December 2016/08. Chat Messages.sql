SELECT
  c.Id,
  c.Title,
  m2.Id
FROM Chats c
  JOIN Messages m2
    ON c.Id = m2.ChatId
WHERE datediff(DAY, m2.SentOn, '2012-03-26') > 0
      AND right(c.Title, 1) = 'x'
ORDER BY c.Id, m2.Id



