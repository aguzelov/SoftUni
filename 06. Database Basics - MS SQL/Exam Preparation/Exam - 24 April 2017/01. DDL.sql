CREATE DATABASE WMS
GO

USE WMS
GO


CREATE TABLE Clients (
  ClientId INT NOT NULL IDENTITY,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  Phone CHAR(12) NOT NULL,

  CONSTRAINT PK_Clients PRIMARY KEY (ClientId)
)


CREATE TABLE Mechanics (
  MechanicId INT NOT NULL IDENTITY,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  Address VARCHAR(255) NOT NULL,

  CONSTRAINT PK_Mechanics PRIMARY KEY (MechanicId)
)


CREATE TABLE Models (
  ModelId INT NOT NULL IDENTITY,
  Name VARCHAR(50) NOT NULL,

  CONSTRAINT PK_Models PRIMARY KEY (ModelId),

  CONSTRAINT UQ_Models_Name UNIQUE (Name)
)


CREATE TABLE Jobs (
  JobId INT NOT NULL IDENTITY,
  ModelId INT NOT NULL,
  Status VARCHAR(11) NOT NULL DEFAULT 'Pending',
  ClientId INT NOT NULL,
  MechanicId INT,
  IssueDate DATE NOT NULL,
  FinishDate DATE,

  CONSTRAINT PK_Jobs PRIMARY KEY (JobId),

  CONSTRAINT FK_Jobs_Models FOREIGN KEY (ModelId) REFERENCES Models (ModelId),

  CONSTRAINT FK_Jobs_Clients FOREIGN KEY (ClientId) REFERENCES Clients (ClientId),

  CONSTRAINT FK_Jobs_Mechanics FOREIGN KEY (MechanicId) REFERENCES Mechanics (MechanicId),

  CONSTRAINT CHK_Jobs_Status CHECK (Status = 'Pending' OR Status = 'In Progress' OR Status = 'Finished')
)


CREATE TABLE Orders (
  OrderId INT NOT NULL IDENTITY,
  JobId INT NOT NULL,
  IssueDate DATETIME,
  Delivered BIT NOT NULL DEFAULT 'False',

  CONSTRAINT PK_Orders PRIMARY KEY (OrderId),

  CONSTRAINT FK_Orders_Jobs FOREIGN KEY (JobId) REFERENCES Jobs (JobId)
)


CREATE TABLE Vendors (
  VendorId INT NOT NULL IDENTITY,
  Name VARCHAR(50) NOT NULL,

  CONSTRAINT PK_Vendors PRIMARY KEY (VendorId),

  CONSTRAINT UQ_Vendors_Name UNIQUE (Name)
)


CREATE TABLE Parts (
  PartId INT NOT NULL IDENTITY,
  SerialNumber VARCHAR(50) NOT NULL,
  Description VARCHAR(255),
  Price DECIMAL(8, 2) NOT NULL,
  VendorId INT NOT NULL,
  StockQty INT DEFAULT 0,

  CONSTRAINT PK_Parts PRIMARY KEY (PartId),

  CONSTRAINT UQ_Parts_SerialNumber UNIQUE (SerialNumber),

  CONSTRAINT CHK_Parts_Price CHECK (Price > 0),

  CONSTRAINT FK_Parts_Vendors FOREIGN KEY (VendorId) REFERENCES Vendors (VendorId),

  CONSTRAINT CHK_Parts_StockQty CHECK (StockQty >= 0)
)


CREATE TABLE OrderParts (
  OrderId INT,
  PartId INT,
  Quantity INT DEFAULT 1,

  CONSTRAINT PK_OrderParts_Orders_Parts PRIMARY KEY (OrderId, PartId),

  CONSTRAINT FK_OrderParts_Orders FOREIGN KEY (OrderId) REFERENCES Orders (OrderId),
  CONSTRAINT FK_OrderParts_Parts FOREIGN KEY (PartId) REFERENCES Parts (PartId),

  CONSTRAINT CHK_OrderParts CHECK (Quantity > 0)
)


CREATE TABLE PartsNeeded (
  JobId INT,
  PartId INT,
  Quantity INT DEFAULT 1,

  CONSTRAINT PK_PartsNeeded_Jobs_Parts PRIMARY KEY (JobId, PartId),

  CONSTRAINT FK_PartsNeeded_Orders FOREIGN KEY (JobId) REFERENCES Jobs (JobId),
  CONSTRAINT FK_PartsNeeded_Parts FOREIGN KEY (PartId) REFERENCES Parts (PartId),

  CONSTRAINT CHK_PartsNeeded CHECK (Quantity > 0)

)
