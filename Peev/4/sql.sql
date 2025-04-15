CREATE DATABASE foods;
USE foods;

CREATE TABLE types(
ID SMALLINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
type VARCHAR(20) NOT NULL
);

CREATE TABLE foods(
ID SMALLINT NOT NULL PRIMARY KEY AUTO_INCREMENT,
type_id SMALLINT NOT NULL,
FOREIGN KEY(type_id) REFERENCES types(ID),
food VARCHAR(30) NOT NULL,
quantity SMALLINT UNSIGNED NOT NULL,
price DECIMAL(5,2) NOT NULL
);

INSERT INTO types VALUES
(1,	'Fruits'    ),
(2,	'Vegetables'),
(3,	'Grains	   '),
(4,	'Dairy	   '),
(5,	'Meats	   '),
(6,	'Nuts	   '),
(7,	'Seeds	   '),
(8,	'Legumes   ');

INSERT INTO foods(ID, type_id,food,quantity,price) VALUES
(1	,1,	'apples',	1000	,8.45),
(2	,1,	'bananas',	1000	,9.7),
(3	,1,	'oranges',	1000	,9.71),
(4	,1,	'strawberries',	100	,11.55),
(5	,1,	'blueberries',	100	,11.69),
(6	,2,	'broccoli',	250	,7.75),
(7	,2,	'spinach',	100	,4.14),
(8	,2,	'carrots',	1000	,7.04),
(9	,2,	'tomatoes',	1000	,4.25),
(10,2,	'potatoes',	1000	,3.08),
(11,3,	'oranges',	1000	,4.95),
(12,3,	'rice',	1000	,4.48),
(13,3,	'wheat',	1000	,8.2),
(14,3,	'oats',	1000	,6.23),
(15,3,	'barley',	1000	,4.39),
(16,3,	'quinoa',	1000	,10.43),
(17,4,	'milk',	1000	,5.17),
(18,4,	'cheese',	1000	,4.87),
(19,4,	'yogurt',	1000	,9.27),
(20,4,	'butter',	1000	,8.58),
(21,5,	'beef',	1000	,11.31),
(22,5,	'chicken',	1000	,6.04),
(23,5,	'pork',	1000	,5.58),
(24,5,	'lamb',	1000	,10.49),
(25,5,	'fish',	1000	,11.09),
(26,6,	'almonds',	200	,3.33),
(27,6,	'walnuts',	200	,3.32),
(28,6,	'pistachios',	200	,6.85),
(29,6,	'cashews',	200	,6.38),
(30,7,	'almonds',	200	,9.72),
(31,7,	'walnuts',	200	,10.52),
(32,7,	'pistachios',	200	,10.21),
(33,7,	'cashews',	200	,3.78),
(34,8,	'beans',	1000	,9.18),
(35,8,	'lentils',	1000	,5.43),
(36,8,	'peas',	1000	,7.09),
(37,8,	'chickpeas',	1000	,11.01),
(38,8,	'soybeans',	250	,10.32);

SELECT food, types.type FROM foods
JOIN types ON type_id = types.ID
WHERE food LIKE '_a%'
ORDER BY foods.price ASC;

UPDATE types
SET ID = 10
WHERE type = 'Meats';

UPDATE types
SET ID = 10
WHERE type = 'Meats';

SELECT * FROM foods
JOIN types ON type_id = types.ID
WHERE types.type = 'Meats'
ORDER BY food DESC;

SELECT types.type, COUNT(type_id) as cnt, SUM(price) as price_sum FROM foods
JOIN types ON type_id = types.ID
GROUP BY type_id
HAVING price_sum > 30
ORDER BY price_sum DESC;
