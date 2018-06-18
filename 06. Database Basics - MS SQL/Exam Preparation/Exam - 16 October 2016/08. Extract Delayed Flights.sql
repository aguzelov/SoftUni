SELECT FlightID, DepartureTime, ArrivalTime
FROM Flights
WHERE Status = 'Delayed'
ORDER BY FlightID