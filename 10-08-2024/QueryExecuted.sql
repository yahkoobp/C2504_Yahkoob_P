CREATE DATABASE TEST

USE TEST

CREATE TABLE Orders (
    CustomerID INT,
    OrderID INT,
    OrderValue DECIMAL(10, 2)
);

INSERT INTO Orders (CustomerID, OrderID, OrderValue)
VALUES 
(1, 101, 250.75),
(2, 102, 125.50),
(3, 103, 300.00),
(1, 104, 450.25),
(2, 105, 175.00);

/*
1)Find the Total Number of Orders and Total Order Value by Customer
Problem: Given an `Orders` table,
find the total number of orders and
total order value for each customer.
*/


 SELECT CustomerID, 
  COUNT(orderID) as Total_Order , 
  SUM (OrderValue) as TotalOrderValue
    FROM Orders
    GROUP BY CustomerID ;

------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Sales (
    ProductID INT,
    SaleAmount DECIMAL(10, 2),
    SaleDate DATE
);


INSERT INTO Sales (ProductID, SaleAmount, SaleDate)
VALUES 
(101, 150.50, '2024-08-01'),
(102, 200.75, '2024-08-02'),
(103, 120.00, '2024-08-03'),
(104, 310.40, '2024-08-04'),
(105, 250.00, '2024-08-05');


/*
2)Find the Top N Products by Sales Volume
Problem: Given a `Sales` table
with columns `ProductID`, `SaleAmount`, and `SaleDate`,
find the top 5 products by total sales volume.
*/

SELECT TOP 5 ProductID , SUM(SaleAmount)  as totalSalesVolume
FROM Sales
GROUP BY  ProductID
ORDER BY totalSalesVolume  DESC


/*
3)Find the Top N Salespersons by Sales
Problem:
Given a table `Sales`
with columns `SalesPersonID`, `SaleAmount`, and `SaleDate`,
find the top 3 salespersons by total sales amount.
*/

CREATE TABLE SalesPerson (
SalesPersonID INT,
SaleAmount DECIMAL(10, 2),
SaleDate DATE
);

INSERT INTO SalesPerson (SalesPersonID, SaleAmount, SaleDate)
VALUES 
(1, 500.75, '2024-08-01'),
(2, 300.50, '2024-08-02'),
(3, 750.00, '2024-08-03'),
(1, 650.25, '2024-08-04'),
(2, 400.00, '2024-08-05');

INSERT INTO SalesPerson (SalesPersonID, SaleAmount, SaleDate)
VALUES 
(1, 500.75, '2023-04-01'),
(2, 300.50, '2022-04-02'),
(3, 750.00, '2023-06-03'),
(1, 650.25, '2021-03-04'),
(2, 400.00, '2020-03-05');

SELECT TOP 3 SalesPersonID , SUM (SaleAmount) AS TotalSalesAmount
FROM SalesPerson
GROUP BY SalesPersonID
ORDER BY TotalSalesAmount DESC;

/* 
4)Find Departments with No Employees
Problem: Given a `Departments` table and an `Employees` table,
find departments that do not have any employees.
Table Structure:
*/

CREATE TABLE Departments (
DepartmentID INT,
DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
EmployeeID INT,
DepartmentID INT
);

INSERT INTO Departments (DepartmentID, DepartmentName)
VALUES 
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing'),
(5, 'Sales');

INSERT INTO Employees (EmployeeID, DepartmentID)
VALUES 
(101, 1),
(102, 2), 
(103, 3),  
(104, 3),  
(105, 5); 

--using correlated subqueries

SELECT DepartmentID , DepartmentName
FROM Departments D
WHERE NOT EXISTS (SELECT DepartmentID FROM Employees E WHERE E.DepartmentID = D.DepartmentID)

--using left join
SELECT D.DepartmentID , D.DepartmentName
FROM  Departments D LEFT JOIN Employees E
ON D.DepartmentID = E.DepartmentID
WHERE E.DepartmentID IS NULL

/*
5)Find the Monthly Average Sales for Each Salesperson
Problem: Given a `Sales` table
with columns `SalesPersonID`, `SaleAmount`, and `SaleDate`,
find the monthly average sales for each salesperson.
*/

SELECT 
    SalesPersonID,
    YEAR(SaleDate) as SaleYear,
    MONTH (SaleDate) as SaleMonth,
    AVG(SaleAmount) AS MonthlyAverageSales
FROM SalesPerson
GROUP BY SalesPersonID ,YEAR(SaleDate),MONTH (SaleDate) ;
