SELECT
  c.Id,
  c.Email,
  c.CountryCode,
  c.Count
FROM (
       SELECT
         a.Id,
         a.Email,
         c.CountryCode,
         ROW_NUMBER()
         OVER ( PARTITION BY c.CountryCode
           ORDER BY count(c.Id) DESC ) AS [Rank],
         count(c.Id)                   AS [Count]
       FROM Accounts a
         JOIN AccountsTrips at2
           ON a.Id = at2.AccountId
         JOIN Trips t
           ON at2.TripId = t.Id
         JOIN Rooms r
           ON t.RoomId = r.Id
         JOIN Hotels h
           ON r.HotelId = h.Id
         JOIN Cities c
           ON h.CityId = c.Id
       GROUP BY a.Id, c.CountryCode, a.Email
     ) AS c
WHERE Rank = 1
ORDER BY Count DESC, c.Id



