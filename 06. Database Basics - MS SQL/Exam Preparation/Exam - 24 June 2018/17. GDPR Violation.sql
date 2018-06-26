SELECT
  t.Id,
  concat(a.FirstName, ' ', isnull(MiddleName + ' ', ''), LastName) AS [Full Name],
  c.Name                                                           AS [From],
  c2.Name                                                          AS [To],
  CASE
  WHEN t.CancelDate IS NOT NULL
    THEN 'Canceled'
  ELSE cast(datediff(DAY, ArrivalDate, ReturnDate) AS VARCHAR(10)) + ' days'
  END
FROM Trips t
  JOIN AccountsTrips at2
    ON t.Id = at2.TripId
  JOIN Accounts a
    ON at2.AccountId = a.Id
  JOIN Cities c
    ON a.CityId = c.Id
  JOIN Rooms r
    ON t.RoomId = r.Id
  JOIN Hotels h
    ON r.HotelId = h.Id
  JOIN Cities c2
    ON h.CityId = c2.Id
ORDER BY [Full Name], t.Id