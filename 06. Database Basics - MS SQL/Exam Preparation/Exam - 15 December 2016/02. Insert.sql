INSERT INTO Messages (Content, SentOn, ChatId, UserId)
SELECT
  concat(u.Age, '-', u.Gender, '-', l.Latitude, '-', l.Longitude) AS [Content],
  CONVERT(DATE, getdate())                                        AS [SentOn],
  CASE
  WHEN u.Gender = 'F'
    THEN CEILING(sqrt(u.Age * 2))
  ELSE
    CEILING(power((u.Age /18),3))
  END                                                             AS [ChatId],
  u.Id                                                            AS [UserId]
FROM Users u
  JOIN Locations l
    ON u.LocationId = l.Id
WHERE u.Id BETWEEN 10 AND 20
