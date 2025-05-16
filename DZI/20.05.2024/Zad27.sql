CREATE TABLE Mountains(
	ID SERIAL PRIMARY KEY,
	MountainName VARCHAR(20) NOT NULL, --NVARCHAR(20) MYSQL
	CountryCode VARCHAR(3) NOT NULL,
	Country VARCHAR(20)
);

CREATE TABLE Peaks(
	ID SERIAL PRIMARY KEY,
	PeakName VARCHAR(20) NOT NULL, --NVARCHAR(20) MYSQL
	Elevation INT NOT NULL,
	CHECK(Elevation > 0),
	MountainId INT NOT NULL,
	FOREIGN KEY(MountainId) REFERENCES Mountains(ID)
);

INSERT INTO Mountains VALUES
(1 ,'Рила ','BUL' ,'България'),
(2 ,'Пирин ','BUL' ,'България'),
(3 ,'Стара планина', 'BUL' ,'България'),
(4 ,'Анди ','ARG' ,'Аржентина'),
(5 ,'Анди ','CHL' ,'Чили'),
(6 ,'Хималаи ','NPL' ,'Непал'),
(7 ,'Алпи ','SUI' ,'Швейцария'),
(8 ,'Алпи ','ITA' ,'Италия'),
(9 ,'Алпи' ,'AUT' ,'Австрия'),
(10,' Алпи' ,'FRA' ,'Франция'),
(11,' Елбрус ','RUS' ,'Русия'),
(12,' Елбрус' ,'GEO' ,'Грузия');

INSERT INTO Peaks VALUES
(1 ,'Аконкагуа', 6962, 4),
(2 ,'Ботев' ,2376, 3),
(3 ,'Мусала' ,2925, 1),
(4 ,'Еверест' ,8849, 6),
(5 ,'Вихрен' ,2914, 2),
(6 ,'Мальовица' ,2729, 1),
(7 ,'Монблан' ,4809, 10),
(8 ,'Матерхорн' ,4478, 8),
(9 ,'Дюфур' ,4634, 7),
(10, 'Елбрус' ,5642, 11), 
(11, 'Ком' ,2015, 3),
(12, 'Манаслу' ,2729, 6),
(13, 'Дено', 2790, 1);

UPDATE Peaks
SET Elevation = 2016
WHERE PeakName = 'Ком';

SELECT MountainId, AVG(Elevation) FROM Peaks
GROUP BY MountainId
HAVING MountainId = 1;

SELECT COUNT(*) FROM Peaks
WHERE Elevation >= 5000 AND Elevation <= 9000;

SELECT PeakName, Elevation, m.MountainName, m.Country FROM Peaks
JOIN Mountains as m ON MountainId = m.ID
WHERE Elevation > 2900
ORDER BY m.Country 
,Elevation DESC;

SELECT Country, COUNT(ID) as CountryCount FROM Mountains
GROUP BY Country
ORDER BY CountryCount DESC, Country;