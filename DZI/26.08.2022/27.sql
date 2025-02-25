CREATE DATABASE school;
USE school;

CREATE TABLE students(
ID INT PRIMARY KEY,
Name VARCHAR(255),
BEL INT,
English INT,
Math INT,
Informatics INT,
IT INT
);

INSERT INTO STUDENTS (ID, Name, BEL, English, Math, Informatics, IT) VALUES
(1, 'Антония Колева', 4, 5, 6, 5, 4),
(2, 'Асен Ангелов', 5, 5, 6, 4, 5),
(3, 'Борислав Ганев', 4, 4, 5, 5, 6),
(4, 'Бояна Тодорова', 5, 6, 6, 6, 6),
(5, 'Валери Илиев', 6, 6, 6, 6, 6);

SELECT * FROM students
WHERE ID = 4;

SELECT COUNT(*) FROM students
WHERE Math = 6 AND IT = 6 AND Informatics = 6;

SELECT AVG(Bel), AVG(Math) FROM students;

SELECT Name, (BEL + Math + English + Informatics + IT)/5 AS average FROM students
ORDER BY average DESC, Name ASC;

