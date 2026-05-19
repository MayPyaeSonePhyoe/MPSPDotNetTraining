CREATE DATABASE MyShop;
GO


USE MyShop;
GO


CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Qty INT NOT NULL
);
GO


INSERT INTO Products (Name, Price, Qty)
VALUES 
('Coca Cola', 1500, 10),
('Pepsi', 1400, 20),
('Bread', 2000, 15);
GO


SELECT * FROM Products;
GO

UPDATE Products
SET Price = 1600
WHERE Id = 1;
GO


DELETE FROM Products
WHERE Id = 3;
GO