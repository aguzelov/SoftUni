CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees (
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		FirstName NVARCHAR(50) NOT NULL,
		LastName NVARCHAR(100) NOT NULL,
		Title NVARCHAR(100),
		Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName) 
VALUES ('Papoi', 'Papoev'),
        ('Douglas', 'Adams'),
		('Terry', 'Pratchet')

CREATE TABLE Customers (
		AccountNumber INT PRIMARY KEY IDENTITY NOT NULL,
		FirstName NVARCHAR(50) NOT NULL,
		LastName NVARCHAR(50) NOT NULL,
		PhoneNumber INT,
		EmergencyName NVARCHAR(100),
		EmergencyNumber INT,
		Notes NVARCHAR(MAX)
)
INSERT INTO Customers (FirstName, LastName) 
VALUES ('Granny', 'Weatherwax'),
		('Maggrat', 'Garlic'),
		('Aunt', 'Ogg')

CREATE TABLE RoomStatus (
		RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
		Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus) 
VALUES ('Ready to use'),
		('Available'),
		('Occupied')

CREATE TABLE RoomTypes (
		RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
		Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes (RoomType) 
VALUES ('Apartment'),
		('Studio'),
		('Double')

CREATE TABLE BedTypes (
		BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
		Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes (BedType) 
VALUES ('Single'),
		('Double'),
		('KingSize')

CREATE TABLE Rooms (
		RoomNumber INT PRIMARY KEY IDENTITY NOT NULL,
		RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
		BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
		Rate DECIMAL(10,2),
		RoomStatus NVARCHAR(50),
		Notes NVARCHAR(MAX)
)

INSERT INTO Rooms (Rate) 
VALUES (25.00),
		(38.00),
		(49.99)

CREATE TABLE Payments (
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		EmployeeId INT,
		PaymentDate DATE,
		AccountNumber INT,
		FirstDateOccipied DATE,
		LastDateOccupied DATE,
		TotalDays AS DATEDIFF(DAY, FirstDateOccipied, LastDateOccupied),
		AmountCharged DECIMAL(10, 2),
		TaxRate DECIMAL(10, 2),
		TaxAmount DECIMAL(10, 2),
		PaymentTotal DECIMAL(15, 2),
		Notes NVARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, PaymentDate, AmountCharged) 
VALUES (1, GETDATE(), 100.00),
		(2, GETDATE(), 2000.00),
		(3, GETDATE(), 2500.00)

CREATE TABLE Occupancies (
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		EmployeeId INT,
		DateOccipied DATE,
		AccountNumber INT,
		RoomNumber INT,
		RateApplied DECIMAL(10, 2),
		PhoneCharge DECIMAL(10, 2),
		Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeId, RoomNumber, RateApplied, Notes) 
VALUES (1, 49.99, 13, 'Granny'),
		(2, 49.99, 23,  'Maggrat'),
		(3, 49.99, 32, 'Aunty')
