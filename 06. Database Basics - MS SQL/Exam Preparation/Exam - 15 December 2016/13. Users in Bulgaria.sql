SELECT
  u.Nickname,
  c.Title,
  l.Latitude,
  l.Longitude
FROM Users u
  JOIN Locations l
    ON u.LocationId = l.Id
  JOIN UsersChats uc
    ON uc.UserId = u.Id
  JOIN Chats c
    ON uc.ChatId = c.Id
WHERE (l.Latitude >= 41.139999 AND l.Latitude <= 44.12999) AND
      (l.Longitude >= 22.20999 AND l.Longitude <= 28.35999)
ORDER BY c.Title ASC
