SELECT
  a.Id,
  a.Email,
  c.Name      AS [City],
  count(h.Id) AS [Trips]
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
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.Name
ORDER BY Trips DESC, a.Id