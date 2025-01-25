CREATE DATABASE marks;
USE marks;

CREATE TABLE students(
ID INT PRIMARY KEY,
 Names VARCHAR(45),
 BEL INT, CHECK(BEL BETWEEN 2 AND 6),
 English INT, CHECK(English BETWEEN 2 AND 6),
 Math INT, CHECK(Math BETWEEN 2 AND 6),
 Inf INT, CHECK(Inf BETWEEN 2 AND 6),
 IT INT, CHECK(IT BETWEEN 2 AND 6)
 );
 
 INSERT INTO students(ID, Names, BEL, English, Math, Inf, IT) VALUES
 (1,'Liliana Svetoslavova Koseva',4,5,	6,	5,	4),
 (2,'Dragomir Marinov Kirilov',	5,	5,	5,	6,	5),
 (3,'Zhiveslav Dimitrov Vlasakiev',	4,	4,	5,	5,	6),
 (4,'Martina Dinkova Koleva',	5,	6,	6,	6,	6),
 (5,'Nikolay Todorov Iliev',	6,	6,	6,	6,	6),
 (6,'Lyubomir Zlatev Bozhilov',	3,	6,	5,	5,	6),
 (7,'Martina Dinkova Koleva',	6,	6,	6,	6,	6),
 (8,'Siana Ivanova Kovacheva',6,	5,	5,	6,	6);
 
 SELECT Names, BEL, English, Math, Inf, IT FROM students
 WHERE students.ID = '6';
 
 SELECT COUNT(*) as count FROM students as st
 WHERE st.Math = '6' AND st.Inf = '6' AND st.IT = '6';
 
 SELECT TRUNCATE(SUM(Math)/COUNT(Math), 2) AS mathAvg, TRUNCATE(SUM(BEL)/COUNT(BEL), 2) AS belAvg FROM students;
 
 SELECT Names, (Math + Bel + IT + Inf + English)/5 as gradeAvg FROM students
 ORDER BY gradeAvg DESC, Names;
 
 
 