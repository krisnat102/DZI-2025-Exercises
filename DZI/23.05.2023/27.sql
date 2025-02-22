CREATE DATABASE university;
USE university;

CREATE TABLE students(
Admission_no INT,
First_name varchar(25),
Last_name varchar(25),
City varchar(25)
);

CREATE TABLE fee(
Admission_no INT,
Course varchar(25),
Amount_paid INT
);

INSERT INTO students VALUES
(3354, "Георги", "Георгиев", "Варна"),
(4321, "Милена", "Красимирова", "Стара Загора"),
(8345, "Михаил", "Мартинов", "Пловдив"),
(7555, "Антонио", "Тачев", "Стара Загора"),
(2135, "Мартин", "Иванов", "София");

INSERT INTO fee VALUES
(3354, 'Java', 2000),
(7555, 'C#', 1800),
(4321, 'SQL', 1600),
(4321, 'Java', 2000),
(8345, 'C++', 1700);

SELECT city FROM students 
WHERE Admission_no = 8345;

SELECT Course, AVG(Amount_paid) FROM fee
GROUP BY Course;

UPDATE fee
SET Course = "Java"
WHERE Amount_paid = 1800;

SELECT Course ,COUNT(students.Admission_id) FROM fee
 