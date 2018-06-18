CREATE TABLE Flights (
  FlightID INT,
  DepartureTime DATETIME NOT NULL,
  ArrivalTime DATETIME NOT NULL,
  Status VARCHAR(9) NOT NULL CHECK (Status IN ('Departing', 'Delayed', 'Arrived', 'Cancelled')),
  OriginAirportID INT NOT NULL,
  DestinationAirportID INT NOT NULL,
  AirlineID INT NOT NULL,

  CONSTRAINT PK_Flights PRIMARY KEY (FlightID),
  CONSTRAINT FK_Flights_Airports_Origin FOREIGN KEY (OriginAirportID) REFERENCES Airports (AirportID),
  CONSTRAINT FK_Flights_Airports_Destination FOREIGN KEY (DestinationAirportID) REFERENCES Airports (AirportID),
  CONSTRAINT FK_Flights_Airports_Airlines FOREIGN KEY (AirlineID) REFERENCES Airlines (AirlineID)
)

CREATE TABLE Tickets (
  TicketID INT,
  Price DECIMAL(8, 2) NOT NULL,
  Class VARCHAR(6) NOT NULL CHECK (Class IN ('First', 'Second', 'Third')),
  Seat VARCHAR(5) NOT NULL,
  CustomerID INT NOT NULL,
  FlightID INT NOT NULL,

  CONSTRAINT PK_Tickets PRIMARY KEY (TicketID),
  CONSTRAINT FK_Tickets_Customers FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID),
  CONSTRAINT FK_Tickets_Flights FOREIGN KEY (FlightID) REFERENCES Flights (FlightID)
)