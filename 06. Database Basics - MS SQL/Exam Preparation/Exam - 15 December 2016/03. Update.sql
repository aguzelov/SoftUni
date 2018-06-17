UPDATE Chats
SET StartDate = dates.Date
FROM (
       SELECT
         c.Id,
         min(m.SentOn) AS [Date]
       FROM Chats c
         JOIN Messages m
           ON c.Id = m.ChatId
       WHERE datediff(DAY, c.StartDate, m.SentOn) < 0
       GROUP BY c.Id
     ) AS dates
  JOIN Messages m
    ON m.ChatId = dates.Id
WHERE Chats.Id = dates.Id
