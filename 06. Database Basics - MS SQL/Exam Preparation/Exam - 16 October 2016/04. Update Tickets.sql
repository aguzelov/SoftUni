UPDATE Tickets
SET Price *= 1.50
WHERE TicketID IN (
  SELECT t.TicketID
  FROM Airlines a
    JOIN Flights f
      ON a.AirlineID = f.AirlineID
    JOIN Tickets t
      ON f.FlightID = t.FlightID
  WHERE a.AirlineID = (
    SELECT TOP 1 AirlineID
    FROM Airlines
    ORDER BY Rating DESC
  )
)