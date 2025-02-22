CREATE DATABASE music;
USE music;

CREATE TABLE singers(
id INT PRIMARY KEY,
name VARCHAR(45),
songs INT,
rank INT,
networth INT
);

INSERT INTO singers(id, name, songs, rank, networth) VALUES
(1, 'Ivan Ivanov', 50, 1, 1000000),
(2, 'Maria Ivanova', 55, 3, 900000),
(3, 'Georgi Georgiev', 20, 4, 800000),
(4, 'Gergana Petrova', 55, 2, 1000000),
(5, 'Boris Borisov', 20, 5, 900000);

SELECT name, rank FROM singers
WHERE rank <= 3
ORDER BY rank;

SELECT SUM(songs) as number_songs, AVG(networth * 1.95583) AS average_networth_Euro FROM singers;

UPDATE singers
SET networth = networth * 1.1
WHERE id = 2 OR id = 4;