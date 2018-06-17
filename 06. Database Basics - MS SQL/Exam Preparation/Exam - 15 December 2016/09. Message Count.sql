SELECT TOP (5) c.Id, count(*) AS [TotalMessages]
FROM Chats c
  RIGHT JOIN Messages m2
    ON c.Id = m2.ChatId
WHERE m2.Id < 90
GROUP BY c.Id
ORDER BY TotalMessages DESC, c.Id ASC