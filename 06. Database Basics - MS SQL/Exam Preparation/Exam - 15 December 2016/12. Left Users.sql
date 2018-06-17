SELECT
  Id,
  ChatId,
  UserId
FROM Messages
WHERE ChatId = 17 AND UserId NOT IN (
  SELECT UserId
  FROM UsersChats
  WHERE ChatId = 17
) OR UserId IS NULL
ORDER BY Id DESC