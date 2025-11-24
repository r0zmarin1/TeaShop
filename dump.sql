--
-- Скрипт сгенерирован Devart dbForge Studio 2020 for MySQL, Версия 9.0.391.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 24.11.2025 13:57:01
-- Версия сервера: 10.3.39
-- Версия клиента: 4.1
--

-- 
-- Отключение внешних ключей
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Установить режим SQL (SQL mode)
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 
-- Установка кодировки, с использованием которой клиент будет посылать запросы на сервер
--
SET NAMES 'utf8';

--
-- Установка базы данных по умолчанию
--
USE lanakaraokebar_copy7;

--
-- Удалить таблицу `reports`
--
DROP TABLE IF EXISTS reports;

--
-- Удалить таблицу `reporttypes`
--
DROP TABLE IF EXISTS reporttypes;

--
-- Удалить таблицу `productslists`
--
DROP TABLE IF EXISTS productslists;

--
-- Удалить таблицу `products`
--
DROP TABLE IF EXISTS products;

--
-- Удалить таблицу `categories`
--
DROP TABLE IF EXISTS categories;

--
-- Удалить таблицу `orders`
--
DROP TABLE IF EXISTS orders;

--
-- Удалить таблицу `bookings`
--
DROP TABLE IF EXISTS bookings;

--
-- Удалить таблицу `tables`
--
DROP TABLE IF EXISTS tables;

--
-- Удалить таблицу `statuses`
--
DROP TABLE IF EXISTS statuses;

--
-- Удалить таблицу `users`
--
DROP TABLE IF EXISTS users;

--
-- Удалить таблицу `roles`
--
DROP TABLE IF EXISTS roles;

--
-- Установка базы данных по умолчанию
--
USE lanakaraokebar_copy7;

--
-- Создать таблицу `roles`
--
CREATE TABLE roles (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Title varchar(255) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 3,
AVG_ROW_LENGTH = 8192,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать таблицу `users`
--
CREATE TABLE users (
  Id int(11) NOT NULL AUTO_INCREMENT,
  FirstName varchar(50) NOT NULL,
  LastName varchar(255) NOT NULL,
  Patronymic varchar(255) DEFAULT NULL,
  Is_Blocked tinyint(4) NOT NULL DEFAULT 0,
  Id_Role int(11) NOT NULL,
  BonusesCount int(11) NOT NULL,
  Password varchar(255) NOT NULL,
  PhoneNumber varchar(255) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 2,
AVG_ROW_LENGTH = 16384,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE users
ADD CONSTRAINT FK_users_roles_Id FOREIGN KEY (Id_Role)
REFERENCES roles (Id);

--
-- Создать таблицу `statuses`
--
CREATE TABLE statuses (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Title varchar(255) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать таблицу `tables`
--
CREATE TABLE tables (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Id_Status int(11) NOT NULL,
  MaxPeopleCount int(11) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE tables
ADD CONSTRAINT FK_rooms_statuses_Id FOREIGN KEY (Id_Status)
REFERENCES statuses (Id);

--
-- Создать таблицу `bookings`
--
CREATE TABLE bookings (
  Id int(11) NOT NULL AUTO_INCREMENT,
  TimeStamp datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  HoursCount int(11) NOT NULL DEFAULT 1,
  Id_Table int(11) NOT NULL,
  Id_User int(11) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE bookings
ADD CONSTRAINT FK_bookings_rooms_Id FOREIGN KEY (Id_Table)
REFERENCES tables (Id);

--
-- Создать внешний ключ
--
ALTER TABLE bookings
ADD CONSTRAINT FK_bookings_users_Id FOREIGN KEY (Id_User)
REFERENCES users (Id);

--
-- Создать таблицу `orders`
--
CREATE TABLE orders (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Cost decimal(19, 2) NOT NULL,
  Id_Booking int(11) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE orders
ADD CONSTRAINT FK_orders_bookings_Id FOREIGN KEY (Id_Booking)
REFERENCES bookings (Id);

--
-- Создать таблицу `categories`
--
CREATE TABLE categories (
  Id int(11) NOT NULL,
  Title varchar(255) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать таблицу `products`
--
CREATE TABLE products (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Title varchar(255) NOT NULL,
  Cost decimal(19, 2) NOT NULL,
  Id_Category int(11) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE products
ADD CONSTRAINT FK_products_categories_Id FOREIGN KEY (Id_Category)
REFERENCES categories (Id);

--
-- Создать таблицу `productslists`
--
CREATE TABLE productslists (
  Id_Order int(11) NOT NULL,
  Id_Product int(11) NOT NULL,
  ProductCount int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (Id_Order, Id_Product)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE productslists
ADD CONSTRAINT FK_prosuctslists_orders_Id FOREIGN KEY (Id_Order)
REFERENCES orders (Id);

--
-- Создать внешний ключ
--
ALTER TABLE productslists
ADD CONSTRAINT FK_prosuctslists_products_Id FOREIGN KEY (Id_Product)
REFERENCES products (Id);

--
-- Создать таблицу `reporttypes`
--
CREATE TABLE reporttypes (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Title varchar(255) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать таблицу `reports`
--
CREATE TABLE reports (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Id_User int(11) NOT NULL,
  Id_ReportType int(11) NOT NULL,
  TimeStamp datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  Path varchar(255) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE reports
ADD CONSTRAINT FK_reports_reporttypes_Id FOREIGN KEY (Id_ReportType)
REFERENCES reporttypes (Id);

--
-- Создать внешний ключ
--
ALTER TABLE reports
ADD CONSTRAINT FK_reports_users_Id FOREIGN KEY (Id_User)
REFERENCES users (Id);

-- 
-- Вывод данных для таблицы roles
--
INSERT INTO roles VALUES
(1, 'user'),
(2, 'EtoSamijKrutoiChel');

-- 
-- Вывод данных для таблицы statuses
--
-- Таблица lanakaraokebar_copy7.statuses не содержит данных

-- 
-- Вывод данных для таблицы users
--
INSERT INTO users VALUES
(1, '123', '123', '123', 0, 1, 0, '5665a4092242df97418e4e67cfdb4f08a14aff31ff0fa97ee98f8677f7a23aea', '');

-- 
-- Вывод данных для таблицы tables
--
-- Таблица lanakaraokebar_copy7.tables не содержит данных

-- 
-- Вывод данных для таблицы categories
--
-- Таблица lanakaraokebar_copy7.categories не содержит данных

-- 
-- Вывод данных для таблицы bookings
--
-- Таблица lanakaraokebar_copy7.bookings не содержит данных

-- 
-- Вывод данных для таблицы reporttypes
--
-- Таблица lanakaraokebar_copy7.reporttypes не содержит данных

-- 
-- Вывод данных для таблицы products
--
-- Таблица lanakaraokebar_copy7.products не содержит данных

-- 
-- Вывод данных для таблицы orders
--
-- Таблица lanakaraokebar_copy7.orders не содержит данных

-- 
-- Вывод данных для таблицы reports
--
-- Таблица lanakaraokebar_copy7.reports не содержит данных

-- 
-- Вывод данных для таблицы productslists
--
-- Таблица lanakaraokebar_copy7.productslists не содержит данных

-- 
-- Восстановить предыдущий режим SQL (SQL mode)
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;
