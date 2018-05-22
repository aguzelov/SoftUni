CREATE DATABASE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear DATE NOT NULL,
	Length DECIMAL(15,2) NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating INT,
	Notes NVARCHAR(MAX)
)


INSERT INTO Directors (DirectorName,Notes) VALUES
('Pancho', 'Pancho Note'),
('Mancho', 'Mancho Note'),
('Bancho', 'Bancho Note'),
('Nancho', 'Nancho Note'),
('Tancho', 'Tancho Note')

INSERT INTO Genres (GenreName, Notes) VALUES
('FirstGenre' , 'FirstGenre Note'),
('SecondGenre' , 'SecondGenre Note'),
('ThirdGenre' , 'ThirdGenre Note'),
('FourthGenre' , 'FourthGenre Note'),
('FifthGenre' , 'FifthGenre Note')

INSERT INTO Categories (CategoryName, Notes) VALUES
('FirstCategory', 'FirstCategory Note'),
('SecondCategory', 'SecondCategory Note'),
('ThirdCategory', 'ThirdCategory Note'),
('FourthCategory', 'FourthCategory Note'),
('FifthCategory', 'FifthCategory Note')

INSERT INTO Movies (Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId,Rating, Notes) VALUES
('FirstTitle', 1,GETDATE(), 1.3, 1, 1, NULL, NULL),
('SecondTitle', 3,GETDATE(), 123.2, 2, 4, 2, NULL),
('ThirdTitle', 5,GETDATE(), 1222, 5, 3, NULL, 'ThirdTitle Note'),
('FourthTitle', 2,GETDATE(), 0.1, 3, 5, 123, NULL),
('FifthTitle', 4,GETDATE(), 13, 4, 4, 1, NULL)
