CREATE DATABASE CarRental 
USE CarRental

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate DECIMAL(10, 2), 
	WeeklyRate DECIMAL(10, 2), 
	MonthlyRate DECIMAL(10, 2),
	WeekendRate DECIMAL(10, 2)
	)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) 
VALUES ('Slow', 3.55, 15.00, 70.00, 5.50), 
		('Fast', 5.55, 18.00, 88.00, 6.50),
		('Cruisin', 4.55, 17.00, 80.00, 6.50)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber VARCHAR(MAX) NOT NULL,
	Manufacturer VARCHAR(50),
	Model VARCHAR(50) NOT NULL,
	CarYear INT,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors INT,
	Picture VARBINARY(MAX),
	Condition VARCHAR(150),
	Available BIT NOT NULL
)

INSERT INTO Cars (PlateNumber, Model, CarYear, CategoryId, Available)
VALUES ('AA 1111 AA', 'PPPORSH', 2000, 2, 1),
		('BB 1111 BB', 'Benc', 2000, 2, 1),
		('AA 2222 AA', 'Turtle', 2005, 1, 0)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR (50) NOT NULL,
	LastName VARCHAR (50) NOT NULL,
	Title VARCHAR (50),
	Notes VARCHAR(MAX)
)


INSERT INTO Employees (FirstName, LastName, Title)
VALUES ('Peter', 'Smith', 'Driver'),
		 ('John', 'Doe', 'Assistant'),
		 ('Sam', 'Duncan', 'Manager')


CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenceNumber INT NOT NULL UNIQUE,
	FullName VARCHAR (100) NOT NULL,
	Address VARCHAR (200),
	City VARCHAR (100),
	ZIPCode INT,
	Notes VARCHAR (MAX)
)

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode)
VALUES ('12121212', 'Papoi Papoev', 'Some address', 'Varna', 9000), 
		('23232323', 'Papoi Papoev Jr', 'Same address', 'Varna', 9000),
		('12121234', 'Papoi Papoev Sr', 'Another address', 'Plovdiv', 4000)


CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT NOT NULL,
	TankLevel DECIMAL (10, 2),
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied VARCHAR (50),
	TaxRate DECIMAL(10, 2),
	OrderStatus VARCHAR(100),
	Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, StartDate, EndDate) 
VALUES (1, 1, 1, 32, '05/05/2000', '10/05/2000'),
		(1, 2, 1, 5, '05/05/2017', '10/05/2017'),
		(1, 3, 2, 6, '05/05/2010', '10/05/2010')