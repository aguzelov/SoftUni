CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(900),
	LastLoginTime DATETIME,
	IsDeleted BIT DEFAULT('False')
)


INSERT INTO Users (Username, Password) VALUES
('Mancho', '12345'),
('Pancho', '12345'),
('Nancho', '12345'),
('Bancho', '12345'),
('Tancho', '12345')
