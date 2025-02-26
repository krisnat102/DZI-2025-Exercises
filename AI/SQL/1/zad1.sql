CREATE DATABASE library;
USE library;

CREATE TABLE Authors(
ID INT AUTO_INCREMENT PRIMARY KEY,
AuthorName NVARCHAR(50) NOT NULL,
Country NVARCHAR(30) NOT NULL
);

CREATE TABLE Genres(
ID INT AUTO_INCREMENT PRIMARY KEY,
GenreName NVARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE Books(
ID INT PRIMARY KEY AUTO_INCREMENT,
Title NVARCHAR(100) NOT NULL,
Year INT NOT NULL CHECK(Year > 0),
AuthorId INT NOT NULL,
GenreId INT NOT NULL,
FOREIGN KEY (GenreId) REFERENCES Genres(ID),
FOREIGN KEY (AuthorId) REFERENCES Authors(ID)
);

INSERT INTO Authors (AuthorName, Country) VALUES
('Иван Вазов', 'България'),
('Елин Пелин', 'България'),
('Чарлз Дикенс', 'Великобритания'),
('Лев Толстой', 'Русия'),
('Виктор Юго', 'Франция'),
('Джордж Оруел', 'Великобритания');

INSERT INTO Genres (GenreName) VALUES
('Роман'),
('Поезия'),
('Драма'),
('Фантастика'),
('Исторически роман');

INSERT INTO Books (Title, Year, AuthorId, GenreId) VALUES
('Под игото', 1894, 1, 5),
('Гераците', 1911, 2, 1),
('Големите надежди', 1861, 3, 1),
('Война и мир', 1869, 4, 5),
('Клетниците', 1862, 5, 5),
('1984', 1949, 6, 4),
('Хаджи Димитър', 1873, 1, 2),
('Приключенията на Оливър Туист', 1838, 3, 1);

UPDATE Books
SET Year = 1912
WHERE Title = 'Гераците';

SELECT AVG(Books.Year) FROM Books
JOIN Authors ON AuthorId = Authors.ID
WHERE Authors.AuthorName = 'Иван Вазов';

SELECT COUNT(*) FROM Books
WHERE Year > 1800 AND Year < 1900;

SELECT * FROM Books
JOIN Authors ON AuthorId = Authors.ID
WHERE Year > 1850
ORDER BY Authors.Country, Year ASC;

SELECT Country, COUNT(*) as AuthorsCount FROM Authors
GROUP BY Country
ORDER BY AuthorsCount DESC, Country;

SELECT * FROM Books
JOIN Genres ON GenreId = Genres.ID
WHERE Genres.GenreName LIKE("Роман");

SELECT Title, Genres.GenreName, Year FROM Books
JOIN Genres ON GenreId = Genres.ID
GROUP BY GenreId
HAVING MAX(Year);

SELECT Authors.AuthorName, COUNT(*) as Books FROM Books
JOIN Authors ON AuthorId = Authors.ID
GROUP BY AuthorId
HAVING Books > 1;