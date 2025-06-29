CREATE TABLE Products_TieExample (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

INSERT INTO Products_TieExample (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Camera', 'Electronics', 800.00),
(4, 'Tablet', 'Electronics', 600.00),
(5, 'Speaker', 'Electronics', 600.00),
(6, 'Sofa', 'Furniture', 1000.00),
(7, 'Dining Table', 'Furniture', 700.00),
(8, 'Chair', 'Furniture', 500.00),
(9, 'Bookshelf', 'Furniture', 500.00);