CREATE TABLE CustomerReviews (
  ReviewID INT PRIMARY KEY,
  ReviewContent VARCHAR(255) NOT NULL,
  ReviewGrade INT CHECK (ReviewGrade BETWEEN 0 AND 10),
  AirlineID INT FOREIGN KEY REFERENCES Airlines (AirlineID),
  CustomerID INT FOREIGN KEY REFERENCES Customers (CustomerID),

)

CREATE TABLE CustomerBankAccounts (
  AccountID INT PRIMARY KEY,
  AccountNumber VARCHAR(10) NOT NULL UNIQUE,
  Balance DECIMAL(10, 2) NOT NULL,
  CustomerID INT FOREIGN KEY REFERENCES Customers (CustomerID)
)