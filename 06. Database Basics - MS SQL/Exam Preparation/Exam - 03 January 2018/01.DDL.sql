CREATE DATABASE RentACar;

USE RentACar;

CREATE TABLE Clients (
  Id INT IDENTITY,
  FirstName NVARCHAR(30) NOT NULL,
  LastName NVARCHAR(30) NOT NULL,
  Gender VARCHAR(1) CHECK(Gender = 'M' OR Gender = 'F'),
  BirthDate DATETIME,
  CreditCard NVARCHAR(30) NOT NULL,
  CardValidity DATETIME,
  Email NVARCHAR(50) NOT NULL,
  CONSTRAINT PK_Clients PRIMARY KEY (Id)
)

CREATE TABLE Towns (
  Id INT IDENTITY,
  Name NVARCHAR(50) NOT NULL,
  CONSTRAINT PK_Towns PRIMARY KEY (Id)
)

CREATE TABLE Offices (
  Id INT IDENTITY,
  Name NVARCHAR(40),
  ParkingPlaces INT,
  TownId INT,
  CONSTRAINT PK_Offices PRIMARY KEY (Id),
  CONSTRAINT FK_Offices_Towns FOREIGN KEY (TownId) REFERENCES Towns (Id)
)

CREATE TABLE Models (
  Id INT IDENTITY,
  Manufacturer NVARCHAR(50) NOT NULL,
  Model NVARCHAR(50) NOT NULL,
  ProductionYear DATETIME,
  Seats INT,
  Class NVARCHAR(10),
  Consumption DECIMAL(14, 2),
  CONSTRAINT PK_Models PRIMARY KEY (Id)
)

CREATE TABLE Vehicles (
  Id INT IDENTITY,
  ModelId INT,
  OfficeId INT,
  Mileage INT,
  CONSTRAINT PK_Vehicles PRIMARY KEY (Id),
  CONSTRAINT FK_Vehicles_Models FOREIGN KEY (ModelId) REFERENCES Models (Id),
  CONSTRAINT FK_Vehicles_Offices FOREIGN KEY (OfficeId) REFERENCES Offices (Id)
)

CREATE TABLE Orders (
  Id INT IDENTITY,
  ClientId INT,
  TownId INT,
  VehicleId INT,
  CollectionDate DATETIME NOT NULL,
  CollectionOfficeId INT,
  ReturnDate DATETIME,
  ReturnOfficeId INT,
  Bill DECIMAL(14, 2),
  TotalMileage INT,
  CONSTRAINT PK_Orders PRIMARY KEY (Id),
  CONSTRAINT FK_Orders_Clients FOREIGN KEY (ClientId) REFERENCES Clients (Id),
  CONSTRAINT FK_Orders_Towns FOREIGN KEY (TownId) REFERENCES Towns (Id),
  CONSTRAINT FK_Orders_Vehicles FOREIGN KEY (VehicleId) REFERENCES Vehicles (Id),
  CONSTRAINT FK_Orders_Offices_CollectionOffice FOREIGN KEY (CollectionOfficeId) REFERENCES Offices (Id),
  CONSTRAINT FK_Orders_Offices_ReturnOffice FOREIGN KEY (ReturnOfficeId) REFERENCES Offices (Id)
)