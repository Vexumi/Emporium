CREATE DATABASE [Gaag_Lab1];
GO
use [Gaag_Lab1];

GO

-- Данные пользователей для входа
CREATE TABLE [Users] (
	ID INT PRIMARY KEY,
	FullName NVARCHAR(100) NOT NULL,
	Phone NVARCHAR(20) NOT NULL,
	Email NVARCHAR(40) NOT NULL,
	Password NVARCHAR(40) NOT NULL,
	AccountType TINYINT NOT NULL  -- 0-admin, 1-employee, 2-seller, 3-customer
);

-- Таблица продавцов
CREATE TABLE [Sellers] (
    ID INT PRIMARY KEY,
    Address NVARCHAR(255),
	ITIN BIGINT,
	UserID INT NOT NULL,
	FOREIGN KEY (ID) REFERENCES [Users](UserID)
);

-- Таблица товаров
CREATE TABLE [Products] (
    ID INT PRIMARY KEY,
	SellerID INT,
    Name NVARCHAR(255) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Category NVARCHAR(50),
	Rating INT,
    Description NTEXT,
	FOREIGN KEY (ID) REFERENCES [Sellers](SellerID)
);

-- Таблица пунктов выдачи
CREATE TABLE [PickupPoints] (
    ID INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),
    Phone NVARCHAR(20),
	WorkingHours NVARCHAR(11),
	Rating DECIMAL(2,1)
);

-- Таблица клиентов
CREATE TABLE [Customers] (
    ID INT PRIMARY KEY,
	CardNumber NVARCHAR(19),
	UserID INT NOT NULL,
	FOREIGN KEY (ID) REFERENCES [Users](UserID)
);

-- Таблица сотрудников
CREATE TABLE [Employees] (
    ID INT PRIMARY KEY,
    Position NVARCHAR(50),
    Salary DECIMAL(10,2),
	PickupPointID INT NULL,
	UserID INT NOT NULL,
	FOREIGN KEY (ID) REFERENCES [PickupPoints] (PickupPointID) ON DELETE SET NULL,
	FOREIGN KEY (ID) REFERENCES [Users](UserID)
);

-- Таблица заказов
CREATE TABLE [Orders] (
    ID INT PRIMARY KEY,
    CustomerID INT NULL,
    EmployeeID INT NULL,
    OrderDate DATE,
    TotalAmount DECIMAL(10,2),
    FOREIGN KEY (ID) REFERENCES [Customers] (CustomerID) ON DELETE SET NULL,
    FOREIGN KEY (ID) REFERENCES [Employees] (EmployeeID) ON DELETE SET NULL
);

-- Таблица содержащая связь между заказами и товарами в заказе
CREATE TABLE [OrderDetails] (
    ID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    PickupPointID INT NULL,
    Quantity INT,
    FOREIGN KEY (ID) REFERENCES [Orders] (OrderID),
    FOREIGN KEY (ID) REFERENCES [Products] (ProductID),
    FOREIGN KEY (ID) REFERENCES [PickupPoints] (PickupPointID) ON DELETE SET NULL
);