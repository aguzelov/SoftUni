SELECT
  TripId,
  sum(Luggage)            AS [Luggage],
  '$' + cast(
      CASE
      WHEN SUM(Luggage) > 5
        THEN (SUM(Luggage) * 5)
      ELSE 0
      END AS VARCHAR(10)) AS [Fee]
FROM AccountsTrips
WHERE Luggage > 0
GROUP BY TripId
ORDER BY Luggage DESC