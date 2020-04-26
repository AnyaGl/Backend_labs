-- 2. Добавление таблиц в БД
CREATE TABLE dvd (
	dvd_id INTEGER PRIMARY KEY AUTOINCREMENT,
	title TEXT NOT NULL,
	production_year TEXT NOT NULL
);
CREATE TABLE customer (
	customer_id INTEGER PRIMARY KEY AUTOINCREMENT,
	first_name TEXT NOT NULL,
	last_name TEXT NOT NULL,
	passport_code INTEGER NOT NULL,
	registration_date TEXT NOT NULL
);
CREATE TABLE offer (
	offer_id INTEGER PRIMARY KEY AUTOINCREMENT,
	dvd_id INTEGER NOT NULL,
	customer_id INTEGER NOT NULL,
	offer_date TEXT NOT NULL,
	return_date TEXT
);

-- 3. Заполнение таблиц данными
INSERT INTO dvd (title, production_year) VALUES ('Золушка', date('2010-01-01'));
INSERT INTO dvd (title, production_year) VALUES ('Алиса в стране чудес', date('2010-01-01'));
INSERT INTO dvd (title, production_year) VALUES ('Ёлки', date('2012-01-01'));
INSERT INTO dvd (title, production_year) VALUES ('Судьба человека', date('2005-01-01'));
INSERT INTO dvd (title, production_year) VALUES ('Любовь и голуби', date('2008-01-01'));
INSERT INTO dvd (title, production_year) VALUES ('Карнавал', date('2010-01-01'));
INSERT INTO dvd (title, production_year) VALUES ('Москва слезам не верит', date('2003-01-01'));
INSERT INTO dvd (title, production_year) VALUES ('Место встречи изменить нельзя', date('2011-01-01'));
INSERT INTO dvd (title, production_year) VALUES ('Приключения Буратино', date('2010-01-01'));

INSERT INTO customer (first_name, last_name, passport_code, registration_date) VALUES ('Иван', 'Иванов', 8810123456, date('2015-08-12'));
INSERT INTO customer (first_name, last_name, passport_code, registration_date) VALUES ('Петр', 'Петров', 8806654321, date('2016-11-03'));
INSERT INTO customer (first_name, last_name, passport_code, registration_date) VALUES ('Капитон', 'Яшуков', 8811456735, date('2018-10-05')); 
INSERT INTO customer (first_name, last_name, passport_code, registration_date) VALUES ('Емельян', 'Каширин', 8804178254, date('2009-05-01'));  
INSERT INTO customer (first_name, last_name, passport_code, registration_date) VALUES ('Борис', 'Киселев', 8854671230, date('2010-01-30'));    

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) VALUES (1, 1, date('2020-04-07'), date('2020-04-13'));
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) VALUES (1, 3, date('2020-03-15'), date('2020-04-01'));
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) VALUES (1, 2, date('2020-03-01'), date('2020-03-08'));
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) VALUES (2, 5, date('2020-02-15'), date('2020-03-20'));
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) VALUES (5, 1, date('2020-03-25'), date('2020-04-07'));
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) VALUES (3, 3, date('2019-11-25'), date('2019-12-01'));
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) VALUES (4, 2, date('2018-10-25'), date('2019-10-29'));
INSERT INTO offer (dvd_id, customer_id, offer_date) VALUES (9, 3, date('2020-04-01'));
INSERT INTO offer (dvd_id, customer_id, offer_date) VALUES (7, 2, date('2020-03-08'));
INSERT INTO offer (dvd_id, customer_id, offer_date) VALUES (8, 2, date('2020-03-08'));
INSERT INTO offer (dvd_id, customer_id, offer_date) VALUES (6, 4, date('2019-12-01'));
               
-- 4. Получение списка всех DVD, год выпуска которых 2010, отсортированных в алфавитном порядке по названию DVD.			   
SELECT dvd_id, title, strftime('%Y', production_year) 
FROM dvd 
WHERE strftime('%Y', production_year) = '2010' 
ORDER BY title;

--5. Получение списка DVD дисков, которые в настоящее время находятся у клиентов.
SELECT dvd_id, title, strftime('%Y', production_year)  
FROM dvd
WHERE EXISTS (
    SELECT * FROM offer 
    WHERE dvd.dvd_id = offer.dvd_id AND offer.return_date IS NULL
);

-- 6. Получение списка клиентов, которые брали какие-либо DVD диски в текущем году. 
-- В результатах запроса необходимо также отразить какие диски брали клиенты.
SELECT customer.first_name, customer.last_name, customer.passport_code, customer.registration_date,
       dvd.title, strftime('%Y', dvd.production_year) 
FROM customer 
LEFT JOIN offer ON offer.customer_id = customer.customer_id
LEFT JOIN dvd ON offer.dvd_id = dvd.dvd_id     
WHERE strftime('%Y', offer.offer_date) = strftime('%Y', 'now');


