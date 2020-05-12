--1 task. Напишите SQL запросы  для решения задач ниже. 
CREATE TABLE pc (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	cpu INTEGER NOT NULL,
	memory INTEGER NOT NULL,
	hdd INTEGER NOT NULL
);

INSERT INTO pc (cpu, memory, hdd) VALUES (1600, 2000, 500);
INSERT INTO pc (cpu, memory, hdd) VALUES (2400, 3000, 800);
INSERT INTO pc (cpu, memory, hdd) VALUES (3200, 3000, 1200);
INSERT INTO pc (cpu, memory, hdd) VALUES (2400, 2000, 500);

--1.1 task. Тактовые частоты CPU тех компьютеров, у которых объем памяти 3000 Мб. Вывод: id, cpu, memory
SELECT id, cpu, memory
FROM pc
WHERE memory = 3000;

--1.2 task. Минимальный объём жесткого диска, установленного в компьютере на складе. Вывод: hdd.
SELECT MIN(hdd) AS min_hdd
FROM pc;

--1.3 task. Количество компьютеров с минимальным объемом жесткого диска, доступного на складе. Вывод: count, hdd.
SELECT COUNT(*) AS count, hdd
FROM pc
WHERE hdd IN (SELECT MIN(hdd) FROM pc);

--2 task
--Напишите SQL-запрос, возвращающий все пары (download_count, user_count), 
--удовлетворяющие следующему условию: 
--user_count — общее ненулевое число пользователей, сделавших 
--ровно download_count скачиваний 19 ноября 2010 года.

CREATE TABLE track_downloads ( 
      download_id INTEGER PRIMARY KEY AUTOINCREMENT, 
      track_id INTEGER NOT NULL, 
      user_id INTEGER NOT NULL, 
      download_time TEXT NOT NULL DEFAULT(datatime('now'))
    ); 

INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (2, 1, date('2010-11-19'));
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (3, 1, date('2010-11-19'));
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (5, 1, date('2010-11-19'));
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (4, 1, date('2010-11-20'));
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (5, 2, date('2010-11-19'));
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (1, 3, date('2010-11-19'));
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (5, 3, date('2010-11-19'));
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (4, 3, date('2010-11-20'));
INSERT INTO track_downloads (track_id, user_id, download_time) VALUES (1, 4, date('2010-11-19'));

SELECT download_count, COUNT(*) AS user_count
FROM (
	SELECT COUNT(*) AS download_count
	FROM track_downloads
	WHERE download_time = '2010-11-19'
	GROUP BY user_id
)
GROUP BY download_count;

--3 task. Опишите разницу типов данных DATETIME и TIMESTAMP
--DATETIME использует формат 'YYYY-MM-DD HH:MM:SS'. Хранится время в виде целого числа вида YYYYMMDDHHMMSS. 
--Поддерживается диапазон величин от '1000-01-01 00:00:00' до '9999-12-31 23:59:59'. 
--(это означает, что для величины с более ранними временными значениями нет гарантии 
--того, что они будут правильно храниться и отображаться). 
--Это время не зависит от временной зоны. Оно всегда отображается при выборке точно так же, как было сохранено, 
--независимо от того какой часовой пояс установлен.
--Использует 8 байт.

--TIMESTAMP хранит целое число, равное количеству секунд, прошедших с полуночи 1 января 1970 года по усреднённому
--времени Гринвича (т.е. нулевой часовой пояс, точка отсчёта часовых поясов). При получении из базы отображается 
--с учётом часового пояса. TIMESTAMP по умолчанию NOT NULL, и его значение по умолчанию равно NOW(). 
--Использует 4 байта.


--4 task
--Необходимо создать таблицу студентов (поля id, name) и таблицу курсов (поля id, name). 
--Каждый студент может посещать несколько курсов. Названия курсов и имена студентов - произвольны.
--Написать SQL запросы: 
--    1. отобразить количество курсов, на которые ходит более 5 студентов
--    2. отобразить все курсы, на которые записан определенный студент.

CREATE TABLE student (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE course (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE student_on_course (
	student_id INTEGER NOT NULL,
	course_id INTEGER NOT NULL,
	FOREIGN KEY(student_id) REFERENCES student(id),
	FOREIGN KEY(course_id) REFERENCES course(id)
);

INSERT INTO student (name) VALUES ('Александр');
INSERT INTO student (name) VALUES ('Иван');
INSERT INTO student (name) VALUES ('Андрей');
INSERT INTO student (name) VALUES ('Степан');
INSERT INTO student (name) VALUES ('Алексей');
INSERT INTO student (name) VALUES ('Валерий');

INSERT INTO course (name) VALUES ('ООП');
INSERT INTO course (name) VALUES ('Веб разработка');
INSERT INTO course (name) VALUES ('Базы данных');
INSERT INTO course (name) VALUES ('Frontend разработка');
INSERT INTO course (name) VALUES ('Комбинаторная математика');
INSERT INTO course (name) VALUES ('Английский язык');

INSERT INTO student_on_course (student_id, course_id) VALUES (1, 1);
INSERT INTO student_on_course (student_id, course_id) VALUES (2, 1);
INSERT INTO student_on_course (student_id, course_id) VALUES (3, 1);
INSERT INTO student_on_course (student_id, course_id) VALUES (4, 1);
INSERT INTO student_on_course (student_id, course_id) VALUES (5, 1);
INSERT INTO student_on_course (student_id, course_id) VALUES (6, 1);

INSERT INTO student_on_course (student_id, course_id) VALUES (1, 2);
INSERT INTO student_on_course (student_id, course_id) VALUES (2, 2);
INSERT INTO student_on_course (student_id, course_id) VALUES (3, 2);
INSERT INTO student_on_course (student_id, course_id) VALUES (4, 2);
INSERT INTO student_on_course (student_id, course_id) VALUES (5, 2);

INSERT INTO student_on_course (student_id, course_id) VALUES (3, 4);
INSERT INTO student_on_course (student_id, course_id) VALUES (3, 6);

INSERT INTO student_on_course (student_id, course_id) VALUES (4, 3);
INSERT INTO student_on_course (student_id, course_id) VALUES (4, 4);
INSERT INTO student_on_course (student_id, course_id) VALUES (4, 5);
INSERT INTO student_on_course (student_id, course_id) VALUES (4, 6);

INSERT INTO student_on_course (student_id, course_id) VALUES (6, 3);
INSERT INTO student_on_course (student_id, course_id) VALUES (6, 4);

-- отобразить количество курсов, на которые ходит более 5 студентов
SELECT COUNT(*) AS number_of_courses 
FROM (
	SELECT COUNT(*) AS number_of_students
	FROM student_on_course
	GROUP BY course_id
	HAVING number_of_students > 5
);
-- отобразить все курсы, на которые записан определенный студент

-- 1 вариант. по id студента
SELECT  name AS course_name
FROM student_on_course
INNER JOIN course ON student_on_course.course_id = course.id
WHERE student_id = 1;

-- 2 вариант. по имени студента
SELECT  course.name AS course_name
FROM student_on_course
INNER JOIN course ON student_on_course.course_id = course.id
INNER JOIN student ON student_on_course.student_id = student.id
WHERE student.name = 'Степан';


--5 task. Может ли значение в столбце(ах), на который наложено ограничение foreign key, равняться null? Привидите пример. 

--Если столбец не определен как NOT NULL, то может. 
--Пример:
--Когда мы только забронировали номер гостиницы, значение столбца в таблице 
--бронирования, определяющего конкретную комнату, имеет значение NULL. 
--Предположим, мы забронировали номер "Люкс", но из всех имеющихся номеров "Люкс", 
--в каком контретно будем проживать, узнаем только по приезде в гостиницу.


--6 task. Как удалить повторяющиеся строки с использованием ключевого слова Distinct? Приведите пример таблиц с данными и запросы. 

--SELECT DISTINCT columns FROM table; 
--где: 
--columns - имена столбцов, для которых рассматривается уникальность;
--table - имя таблицы, из которой выбираются эти столбцы.

--Если запрос содержит более 1 столбца, то уникальность записи определяется комбинацией всех 
--соответствующих значений.
--DISTINCT считает дубликатами значения NULL, поэтому всегда возвращается одно значение NULL.

--Для примера создам таблицу hotel:
CREATE TABLE hotel (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL,
	area INTEGER NOT NULL
);

INSERT INTO hotel (name, area) VALUES ('Космос', 2000);
INSERT INTO hotel (name, area) VALUES ('Кристалл', 3000);
INSERT INTO hotel (name, area) VALUES ('Космос', 3000);

-- Запрос вернет два значения из трех существующих: Космос, Кристалл
SELECT DISTINCT name FROM hotel;
-- Запрос вернет все три значения: Космос|2000, Кристалл|3000, Космос|3000
SELECT DISTINCT name, area FROM hotel;


--7 task
--Есть две таблицы:
--     users - таблица с пользователями (users_id, name)
--    orders - таблица с заказами (orders_id, users_id, status)
--    1) Выбрать всех пользователей из таблицы users, у которых ВСЕ записи в таблице orders имеют status = 0
--    2) Выбрать всех пользователей из таблицы users, у которых больше 5 записей в таблице orders имеют status = 1

CREATE TABLE users (
	users_id INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE orders (
	orders_id INTEGER PRIMARY KEY AUTOINCREMENT,
	users_id INTEGER NOT NULL, 
	status INTEGER NOT NULL,
	FOREIGN KEY(users_id) REFERENCES users(users_id)
);

INSERT INTO users (name) VALUES ('Александр');
INSERT INTO users (name) VALUES ('Иван');
INSERT INTO users (name) VALUES ('Андрей');
INSERT INTO users (name) VALUES ('Степан');
INSERT INTO users (name) VALUES ('Алексей');
INSERT INTO users (name) VALUES ('Валерий');

INSERT INTO orders (users_id, status) VALUES (1, 1);
INSERT INTO orders (users_id, status) VALUES (1, 1);
INSERT INTO orders (users_id, status) VALUES (1, 1);
INSERT INTO orders (users_id, status) VALUES (1, 1);
INSERT INTO orders (users_id, status) VALUES (1, 1);
INSERT INTO orders (users_id, status) VALUES (1, 1);
INSERT INTO orders (users_id, status) VALUES (1, 0);
INSERT INTO orders (users_id, status) VALUES (2, 0);
INSERT INTO orders (users_id, status) VALUES (2, 0);
INSERT INTO orders (users_id, status) VALUES (3, 0);
INSERT INTO orders (users_id, status) VALUES (4, 1);
INSERT INTO orders (users_id, status) VALUES (4, 1);
INSERT INTO orders (users_id, status) VALUES (4, 1);
INSERT INTO orders (users_id, status) VALUES (4, 1);
INSERT INTO orders (users_id, status) VALUES (4, 1);

--Выбрать всех пользователей из таблицы users, у которых ВСЕ записи в таблице orders имеют status = 0
SELECT DISTINCT users.users_id, users.name
FROM users
INNER JOIN orders ON orders.users_id = users.users_id
WHERE users.users_id NOT IN ( 
	SELECT users_id
	FROM orders
	WHERE status != 0
);

--Выбрать всех пользователей из таблицы users, у которых больше 5 записей в таблице orders имеют status = 1
SELECT users.users_id, name, COUNT(*) AS number_of_orders
FROM users
INNER JOIN orders ON users.users_id = orders.users_id
WHERE status = 1
GROUP BY orders.users_id
HAVING number_of_orders > 5;

--8 task. В чем различие между выражениями HAVING и WHERE?
--WHERE выполняется до того, как будет получен результат операции. 
--Выражения WHERE используются вместе с операциями SELECT, UPDATE, DELETE.

--HAVING применяется к результату операции и выполняется уже после того
--как этот результат будет получен. Используется вместе с GROUP BY.

--Таким образом, оператор HAVING аналогичен оператору WHERE за тем исключением, что
--применяется не для всего набора столбцов таблицы, а для набора созданного
--оператором GROUP BY и применяется всегда строго после него.
--Нельзя использовать WHERE в запросах с агрегатными функциями, для этого и был введен HAVING.
