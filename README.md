CREATE DATABASE StoreX_DB;
USE StoreX_DB;
GO

-- Tạo bảng Users
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL
);
CREATE TABLE Products (
    ProductID NVARCHAR(10) PRIMARY KEY,
    Name NVARCHAR(100),
    Price DECIMAL(18,2),
    Quantity INT
);
INSERT INTO Products (ProductID, Name, Price, Quantity) VALUES
('P001', 'Mouse', 200, 50),
('P002', 'Keyboard', 500, 30),
('P003', 'Monitor', 3000, 10);
INSERT INTO Products (ProductID, Name, Price, Quantity) VALUES
('P004', 'Webcam', 800, 15),
('P005', 'Speaker', 600, 20),
('P006', 'USB Hub', 150, 40),
('P007', 'Laptop Stand', 300, 25),
('P008', 'External HDD', 2500, 12),
('P009', 'Microphone', 450, 18),
('P010', 'Graphics Tablet', 2200, 8),
('P011', 'Wireless Charger', 350, 35),
('P012', 'Smartwatch', 1800, 14);
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT,
    ProductName NVARCHAR(100),
    Quantity INT,
    OrderDate DATETIME,
    CustomerName NVARCHAR(100)
);
USE StoreX_DB;
GO

ALTER TABLE Orders
ALTER COLUMN ProductID NVARCHAR(10);

CREATE TABLE AccountProfiles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(255),
    Password NVARCHAR(100) NOT NULL,
    CreatedDate DATE DEFAULT GETDATE()
);
CREATE TABLE OrderList (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100),
    OrderDate DATE,
    Status NVARCHAR(50)
);
DECLARE @i INT = 1;

WHILE @i <= 120
BEGIN
    INSERT INTO OrderList (CustomerName, OrderDate, Status)
    VALUES (
        CONCAT('Customer ', @i), -- Tên khách hàng giả lập
        DATEADD(DAY, -ABS(CHECKSUM(NEWID()) % 365), GETDATE()), -- Ngày ngẫu nhiên trong vòng 1 năm
        CHOOSE(ABS(CHECKSUM(NEWID()) % 4 + 1), 'Pending', 'Shipped', 'Delivered', 'Canceled') -- Trạng thái
    );
    SET @i = @i + 1;
END;
	CREATE TABLE ImportGoods (
		ImportID INT PRIMARY KEY IDENTITY(1,1),
		EmployeeName NVARCHAR(100),
		ImportDate DATE,
		ProductName NVARCHAR(100),
		Quantity INT
	)
	INSERT INTO ImportGoods (EmployeeName, ImportDate, ProductName, Quantity)
VALUES 
(N'Nguyễn Thị Lan', '2025-07-01', N'Laptop Dell XPS 13', 5),
(N'Lê Văn Đức', '2025-07-02', N'iPhone 15 Pro', 10),
(N'Trần Minh Hoàng', '2025-07-03', N'Tai nghe AirPods Pro', 3),
(N'Nguyễn Thị Lan', '2025-07-04', N'Chuột Logitech MX Master 3', 7),
(N'Lê Văn Đức', '2025-07-05', N'Màn hình Samsung 27''', 9),
(N'Trần Minh Hoàng', '2025-07-06', N'Bàn phím cơ Razer BlackWidow', 2),
(N'Nguyễn Thị Lan', '2025-07-07', N'iPhone 15 Pro', 6),
(N'Lê Văn Đức', '2025-07-08', N'Chuột Logitech MX Master 3', 12),
(N'Trần Minh Hoàng', '2025-07-09', N'Màn hình Samsung 27''', 8),
(N'Nguyễn Thị Lan', '2025-07-10', N'Tai nghe AirPods Pro', 4),
(N'Lê Văn Đức', '2025-07-11', N'Laptop Dell XPS 13', 11),
(N'Trần Minh Hoàng', '2025-07-12', N'Bàn phím cơ Razer BlackWidow', 3),
(N'Nguyễn Thị Lan', '2025-07-13', N'Chuột Logitech MX Master 3', 5),
(N'Lê Văn Đức', '2025-07-14', N'iPhone 15 Pro', 7),
(N'Trần Minh Hoàng', '2025-07-15', N'Màn hình Samsung 27''', 6),
(N'Nguyễn Thị Lan', '2025-07-16', N'Bàn phím cơ Razer BlackWidow', 4),
(N'Lê Văn Đức', '2025-07-17', N'Tai nghe AirPods Pro', 9),
(N'Trần Minh Hoàng', '2025-07-18', N'Laptop Dell XPS 13', 14),
(N'Nguyễn Thị Lan', '2025-07-19', N'iPhone 15 Pro', 13),
(N'Trần Minh Hoàng', '2025-07-20', N'Màn hình Samsung 27''', 6);
CREATE TABLE SalesData (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100),
    QuantitySold INT,
    SaleDate DATE,
    Revenue MONEY
);
INSERT INTO SalesData (ProductName, QuantitySold, SaleDate, Revenue)
VALUES 
(N'Chuột Logitech M330', 120, '2025-07-01', 12000000),
(N'Tai nghe Sony WH-1000XM4', 90, '2025-07-02', 18000000),
(N'Bàn phím cơ AKKO 3098', 75, '2025-07-03', 9750000),
(N'Laptop Dell XPS 13', 30, '2025-07-04', 90000000),
(N'Màn hình Samsung 27''''', 45, '2025-07-05', 22500000),
(N'iPhone 15 Pro', 25, '2025-07-06', 62500000),
(N'Bàn phím cơ Razer BlackWidow', 60, '2025-07-07', 18000000);
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(100),
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(200),
    Gender NVARCHAR(10)
);
INSERT INTO Customers (CustomerName, Email, PhoneNumber, Address, Gender)
VALUES 
(N'Lê Văn A', 'a@example.com', '0901234567', N'Hà Nội', N'Nam'),
(N'Nguyễn Thị B', 'b@example.com', '0912345678', N'Đà Nẵng', N'Nữ'),
(N'Trần C', 'c@example.com', '0934567890', N'TP.HCM', N'Nam');
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    Phone NVARCHAR(20),
    Position NVARCHAR(50),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    Email NVARCHAR(100),
    Address NVARCHAR(200)
);

-- Dữ liệu test
INSERT INTO Employees (FullName, Phone, Position, DateOfBirth, Gender, Email, Address)
VALUES 
(N'Nguyễn Văn A', '0901234567', N'Nhân viên', '1995-05-01', N'Nam', 'a@example.com', N'Hà Nội'),
(N'Lê Thị B', '0912345678', N'Quản lý', '1990-03-15', N'Nữ', 'b@example.com', N'Đà Nẵng');



CREATE TABLE StatisticOrders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    OrderDate DATE NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL
);
CREATE TABLE StatisticOrderItems (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL FOREIGN KEY REFERENCES StatisticOrders(OrderID),
    ProductName NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL
);
DBCC CHECKIDENT ('StatisticOrderItems', RESEED, 0);
DBCC CHECKIDENT ('StatisticOrders', RESEED, 0);


-- Chèn dữ liệu vào StatisticOrders
INSERT INTO StatisticOrders (OrderDate, TotalAmount) VALUES
('2025-07-20', 1200000),
('2025-07-21', 2500000),
('2025-07-22', 1800000),
('2025-07-23', 3000000),
('2025-07-24', 500000),
('2025-07-25', 3200000),
('2025-07-26', 1600000),
('2025-07-27', 4000000),
('2025-07-28', 2200000),
('2025-07-29', 800000),
('2025-07-30', 2800000);

-- Chèn dữ liệu chi tiết tương ứng
INSERT INTO StatisticOrderItems (OrderID, ProductName, Quantity, Price) VALUES
(1, N'Tai nghe Bluetooth', 2, 600000),
(2, N'Màn hình Samsung', 1, 2500000),
(3, N'Chuột Logitech', 2, 900000),
(4, N'Laptop Dell', 1, 3000000),
(5, N'Cáp sạc nhanh', 5, 100000),
(6, N'Màn hình LG', 1, 3200000),
(7, N'Bàn phím cơ', 2, 800000),
(8, N'PC Gaming', 1, 4000000),
(9, N'SSD 1TB', 2, 1100000),
(10, N'Tai nghe chụp tai', 2, 400000),
(11, N'Camera hành trình', 1, 2800000);
-- Gán biến cần thiết
DECLARE @a INT = 1;
DECLARE @OrderDate DATE;
DECLARE @TotalAmount DECIMAL(18,2);
DECLARE @OrderID INT;

-- Biến cho sản phẩm trong mỗi đơn hàng
DECLARE @j INT;
DECLARE @NumItems INT;
DECLARE @ProductName NVARCHAR(100);
DECLARE @Quantity INT;
DECLARE @Price DECIMAL(18,2);

WHILE @a <= 500
BEGIN
    -- Tạo ngày ngẫu nhiên từ 2025-05-01 đến 2025-12-31
    SET @OrderDate = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 245, '2025-05-01');

    -- Tạo tổng tiền ngẫu nhiên
    SET @TotalAmount = ROUND(500000 + (ABS(CHECKSUM(NEWID())) % 4500001), -3);

    -- Thêm vào bảng StatisticOrders
    INSERT INTO StatisticOrders (OrderDate, TotalAmount)
    VALUES (@OrderDate, @TotalAmount);

    -- Lấy ID đơn hàng vừa thêm
    SET @OrderID = SCOPE_IDENTITY();

    -- Thêm từ 1 đến 3 sản phẩm vào mỗi đơn hàng
    SET @j = 1;
    SET @NumItems = 1 + ABS(CHECKSUM(NEWID())) % 3;

    WHILE @j <= @NumItems
    BEGIN
        SET @Quantity = 1 + ABS(CHECKSUM(NEWID())) % 5;
        SET @Price = ROUND(100000 + (ABS(CHECKSUM(NEWID())) % 4900001), -3);

        SET @ProductName = 
            CASE ABS(CHECKSUM(NEWID())) % 5
                WHEN 0 THEN N'Màn hình LG'
                WHEN 1 THEN N'Chuột Logitech'
                WHEN 2 THEN N'Bàn phím cơ Ducky'
                WHEN 3 THEN N'Tai nghe Razer'
                ELSE N'Loa Bluetooth Sony'
            END;

        INSERT INTO StatisticOrderItems (OrderID, ProductName, Quantity, Price)
        VALUES (@OrderID, @ProductName, @Quantity, @Price);

        SET @j += 1;
    END

    SET @a += 1;
END
SELECT 
    ProductName,
    SUM(Quantity) AS TotalSold,
    SUM(Quantity * Price) AS TotalRevenue
FROM 
    StatisticOrderItems
GROUP BY 
    ProductName
ORDER BY 
    TotalSold DESC;

