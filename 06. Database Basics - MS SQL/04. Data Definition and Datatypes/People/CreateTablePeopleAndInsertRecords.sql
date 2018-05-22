CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(15,2),
	Weight DECIMAL(15,2),
	Gender CHAR(1) NOT NULL,
	CHECK (Gender in ('m', 'f')),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People (Name, Height, Weight, Gender,Birthdate, Biography) VALUES
('Mincho', 1.00, 2.00, 'm', '1999-10-10', 'durabura'),
('Pencho', 3.00, 2.00, 'm', '1999-10-10', 'durabura'),
('Minka', 10.20, 20.10, 'f', '1999-1-1', 'durabura'),
('Pancho', 1.1, 2.2, 'm', '1999-2-2', 'durabura'),
('Manka', 3.4, 4.5, 'f', '1999-3-3', 'durabura')
