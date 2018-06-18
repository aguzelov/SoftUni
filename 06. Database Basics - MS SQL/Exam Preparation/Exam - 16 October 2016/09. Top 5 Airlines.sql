SELECT TOP 5 *
FROM (
  SELECT DISTINCT
    a.AirlineID,
    a.AirlineName,
    a.Nationality,
    a.Rating
  FROM Flights f
    LEFT JOIN Airlines a
      ON f.AirlineID = a.AirlineID
) AS a
ORDER BY a.Rating DESC, a.AirlineID