SELECT
  Content,
  SentOn
FROM Messages
WHERE Content LIKE '%just%' AND datediff(DAY, SentOn, '2014-05-12') < 0
ORDER BY Id DESC