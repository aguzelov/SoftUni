WITH CTE_AccCount (TripId, Count)
AS
(
    SELECT
      TripId,
      count(AccountId) AS [Count]
    FROM AccountsTrips
    GROUP BY TripId
)

SELECT
  t.Id   AS [Id],
  h.Name AS [HotelName],
  r.Type AS [RoomType],
  CASE
  WHEN t.CancelDate IS NOT NULL
    THEN 0
  ELSE (h.BaseRate + r.Price) * cte.Count
  END    AS [Revenue]
FROM AccountsTrips at
  JOIN Trips t
    ON at.TripId = t.Id
  JOIN Rooms r
    ON t.RoomId = r.Id
  JOIN Hotels h
    ON r.HotelId = h.Id
  JOIN cte_acccount cte
    ON t.Id = cte.TripId
GROUP BY t.Id, h.Name, r.Type, t.CancelDate, (h.BaseRate + r.Price), cte.Count
ORDER BY r.Type, t.Id