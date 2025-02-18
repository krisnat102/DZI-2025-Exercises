CREATE DATABASE tech_shop;
USE tech_shop;

CREATE TABLE laptops(
ID INT PRIMARY KEY AUTO_INCREMENT,
Марка VARCHAR(255),
Модел VARCHAR(255),
Наличност INT,
Цена INT
);

INSERT INTO laptops (Марка, Модел, Наличност, Цена)
VALUES ('Laptop 1', ' L29KAS', 10, 1100);
INSERT INTO laptops (Марка, Модел, Наличност, Цена)
VALUES ('Laptop 2', '15FDR7', 14, 1350);
INSERT INTO laptops (Марка, Модел, Наличност, Цена)
VALUES ('Laptop 1', 'L29GTA', 12, 1500);
INSERT INTO laptops (Марка, Модел, Наличност, Цена)
VALUES ('Laptop 1', 'L29DFT', 8, 1499);
INSERT INTO laptops (Марка, Модел, Наличност, Цена)
VALUES ('Laptop 2', '15FDM5', 11, 1600);

DELETE FROM laptops WHERE Модел = "15FDR7";

SELECT Модел, (Наличност * Цена * 1.2) as общо FROM laptops;

SELECT SUM(Наличност) FROM laptops
WHERE Марка = 'Laptop 1';



