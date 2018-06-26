SELECT
  r.Id,
  r.Price,
  h.Name,
  c.Name
FROM Rooms r
  JOIN Hotels h
    ON r.HotelId = h.Id
  JOIN Cities c
    ON h.CityId = c.Id
WHERE Type = 'First Class'
ORDER BY r.Price DESC, r.Id