WITH cte_lastChat (ChatId, Title) AS
(
    SELECT TOP 1
      Id,
      Title
    FROM Chats
    GROUP BY Id, Title
    ORDER BY max(StartDate) DESC
)

SELECT
  cte.Title,
  m.Content
FROM cte_lastchat cte
  LEFT JOIN Messages m
    ON cte.ChatId = m.ChatId
GROUP BY cte.Title, m.Content
ORDER BY MIN(m.SentOn) DESC