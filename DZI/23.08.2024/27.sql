CREATE TABLE Countries(
	ID SERIAL PRIMARY KEY,
	Name VARCHAR(30)
);

CREATE TABLE Destinations(
	ID SERIAL PRIMARY KEY,
	Town VARCHAR(30),
	Distance INT,
	Duration INT,
	Price DECIMAL(10, 2),
	CountryID INT,
	FOREIGN KEY (CountryID) REFERENCES Countries(ID)
);

INSERT INTO Countries (Name) VALUES 
('France'),
('Germany'),
('Italy'),
('Spain'),
('Austria');

INSERT INTO Destinations VALUES
(1, 'Paris' ,2169 ,4, 1800.00, 1),
(2, 'Berlin' ,4006, 6, 2100.00, 2),
(3, 'Rome' ,1666, 3, 1500.00, 3),
(4, 'Madrid' ,2966, 7, 1800.00, 4),
(5, 'Milan' ,1408, 4, 1900.00, 3),
(6, 'Venice' ,1152, 3, 1200.00, 3),
(7, 'Barcelona' ,2375, 7, 2800.00, 4);

UPDATE Destinations
SET Price = 1700
WHERE Town = 'Paris';

DELETE FROM Destinations
WHERE Town LIKE 'Ba%';

SELECT Town, Distance FROM Destinations
WHERE Distance > 1500 AND Distance < 2500;

SELECT Price, Town FROM Destinations
ORDER BY Price DESC
LIMIT 1;

SELECT Name, COUNT(Destinations.CountryID) AS Count FROM Countries
JOIN Destinations ON Countries.ID = Destinations.CountryID
GROUP BY Destinations.CountryID, Name
ORDER BY Count DESC, Name ASC;