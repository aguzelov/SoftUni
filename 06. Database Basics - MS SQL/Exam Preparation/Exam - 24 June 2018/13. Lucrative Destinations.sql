/*
Find the top 10 cities’ Total Revenue Sum (Hotel Base Rate + Room Price) and trip count.
Count only trips, which were booked in 2016.
Order them by Total Revenue (descending), then by Trip count (descending)
*/

SELECT TOP 10
  c.Id,
  c.Name,
  sum(h.BaseRate + r.Price) AS [Total Revenue],
  count(t.Id)               AS [Trips]
FROM Cities c
  JOIN Hotels h
    ON c.Id = h.CityId
  JOIN Rooms r
    ON h.Id = r.HotelId
  JOIN Trips t
    ON r.Id = t.RoomId
WHERE BookDate BETWEEN '2016-01-01' AND '2016-12-31'
GROUP BY c.Id, c.Name
ORDER BY [Total Revenue] DESC, Trips DESC