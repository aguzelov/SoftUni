CREATE DATABASE Bakery
GO

USE Bakery
GO

CREATE TABLE Countries (
  Id INT IDENTITY,
  Name NVARCHAR(50),

  CONSTRAINT PK_Countries PRIMARY KEY (Id),

  CONSTRAINT UQ_Countries_Name UNIQUE (Name)
)


CREATE TABLE Distributors (
  Id INT IDENTITY,
  Name NVARCHAR(25),
  AddressText NVARCHAR(30),
  Summary NVARCHAR(200),
  CountryId INT,

  CONSTRAINT PK_Distributors PRIMARY KEY (Id),

  CONSTRAINT UQ_Distributors_Name UNIQUE (Name),

  CONSTRAINT FK_Distributors_Countries FOREIGN KEY (CountryId) REFERENCES Countries (Id)
)


CREATE TABLE Ingredients (
  Id INT IDENTITY,
  Name NVARCHAR(30),
  Description NVARCHAR(200),
  OriginCountryId INT,
  DistributorId INT,

  CONSTRAINT PK_Ingredients PRIMARY KEY (Id),

  CONSTRAINT FK_Ingredients_Countries FOREIGN KEY (OriginCountryId) REFERENCES Countries (Id),

  CONSTRAINT FK_Ingredients_Distributors FOREIGN KEY (DistributorId) REFERENCES Distributors (Id)
)


CREATE TABLE Products (
  Id INT IDENTITY,
  Name NVARCHAR(25),
  Description NVARCHAR(250),
  Recipe NVARCHAR(MAX),
  Price MONEY,

  CONSTRAINT PK_Products PRIMARY KEY (Id),

  CONSTRAINT UQ_Products_Name UNIQUE (Name),

  CONSTRAINT CHK_Products_Price CHECK (Price >= 0)
)


CREATE TABLE ProductsIngredients (
  ProductId INT,
  IngredientId INT,

  CONSTRAINT PK_ProductsIngredients PRIMARY KEY (ProductId, IngredientId),

  CONSTRAINT FK_ProductsIngredients_Products FOREIGN KEY (ProductId) REFERENCES Products (Id),
  CONSTRAINT FK_ProductsIngredients_Ingredients FOREIGN KEY (IngredientId) REFERENCES Ingredients (Id)
)


CREATE TABLE Customers (
  Id INT IDENTITY,
  FirstName NVARCHAR(25),
  LastName NVARCHAR(25),
  Gender CHAR(1),
  Age INT,
  PhoneNumber CHAR(10),
  CountryId INT,

  CONSTRAINT PK_Customers PRIMARY KEY (Id),

  CONSTRAINT CHK_Customers_Gender CHECK (Gender IN ('M', 'F')),
  CONSTRAINT CHK_Customers_PhoneNumber CHECK (LEN(PhoneNumber) = 10),

  CONSTRAINT FK_Customers_Countries FOREIGN KEY (CountryId) REFERENCES Countries (Id)
)


CREATE TABLE Feedbacks (
  Id INT IDENTITY,
  Description NVARCHAR(255),
  Rate DECIMAL(10, 2),
  ProductId INT,
  CustomerId INT,

  CONSTRAINT PK_Feedbacks PRIMARY KEY (Id),

  CONSTRAINT CHK_Feedbacks_Rate CHECK (Rate BETWEEN 0 AND 10),

  CONSTRAINT FK_Feedbacks_Products FOREIGN KEY (ProductId) REFERENCES Products (Id),
  CONSTRAINT FK_Feedbacks_Customers FOREIGN KEY (CustomerId) REFERENCES Customers (Id)
)