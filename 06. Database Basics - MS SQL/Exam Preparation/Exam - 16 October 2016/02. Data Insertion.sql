INSERT INTO Flights (FlightID, DepartureTime, ArrivalTime, Status, OriginAirportID, DestinationAirportID, AirlineID)
VALUES
  (1, '2016-10-13 06:00 AM', '2016-10-13 10:00 AM', 'Delayed', 1, 4, 1),
  (2, '2016-10-12 12:00 PM', '2016-10-12 12:01 PM', 'Departing', 1, 3, 2),
  (3, '2016-10-14 03:00 PM', '2016-10-20 04:00 AM', 'Delayed', 4, 2, 4),
  (4, '2016-10-12 01:24 PM', '2016-10-12 4:31 PM', 'Departing', 3, 1, 3),
  (5, '2016-10-12 08:11 AM', '2016-10-12 11:22 PM', 'Departing', 4, 1, 1),
  (6, '1995-06-21 12:30 PM', '1995-06-22 08:30 PM', 'Arrived', 2, 3, 5),
  (7, '2016-10-12 11:34 PM', '2016-10-13 03:00 AM', 'Departing', 2, 4, 2),
  (8, '2016-11-11 01:00 PM', '2016-11-12 10:00 PM', 'Delayed', 4, 3, 1),
  (9, '2015-10-01 12:00 PM', '2015-12-01 01:00 AM', 'Arrived', 1, 2, 1),
  (10, '2016-10-12 07:30 PM', '2016-10-13 12:30 PM', 'Departing', 2, 1, 7)

INSERT INTO Tickets (TicketID, Price, Class, Seat, CustomerID, FlightID) VALUES
  (1, 3000.00, 'First', '233-A', 3, 8),
  (2, 1799.90, 'Second', '123-D', 1, 1),
  (3, 1200.50, 'Second', '12-Z', 2, 5),
  (4, 410.68, 'Third', '45-Q', 2, 8),
  (5, 560.00, 'Third', '201-R', 4, 6),
  (6, 2100.00, 'Second', '13-T', 1, 9),
  (7, 5500.00, 'First', '98-O', 2, 7)