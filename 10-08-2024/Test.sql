1)Find the Total Number of Orders and Total Order Value by Customer
Problem: Given an `Orders` table,
find the total number of orders and
total order value for each customer.


 SELECT CustomerID, 
  COUNT(orderID) as Total_Order , 
  SUM (OrderValue) as TotalOrderValue
    FROM Orders
    GROUP BY CustomerID ;



2)Find the Top N Products by Sales Volume
Problem: Given a `Sales` table
with columns `ProductID`, `SaleAmount`, and `SaleDate`,
find the top 5 products by total sales volume.

Table Structure:
```
CREATE TABLE Sales (
ProductID INT,
SaleAmount DECIMAL(10, 2),
SaleDate DATE
);
```

SELECT ProductID , SUM(SaleAmount)  as total_sales_volume
FROM Sales
GROUP BY  ProductID
ORDER BY totalSalesVolume  DESC LIMIT 5;


3)Find the Top N Salespersons by Sales
Problem:
Given a table `Sales`
with columns `SalesPersonID`, `SaleAmount`, and `SaleDate`,
find the top 3 salespersons by total sales amount.

Table Structure:
```
CREATE TABLE Sales (
SalesPersonID INT,
SaleAmount DECIMAL(10, 2),
SaleDate DATE
);

SELECT SalesPersonID , SUM (SaleAmount) AS TotalSalesAmount
FROM Sales
GROUP BY SalesPersonID
ORDER BY TotalSalesAmount DESC
LIMIT 3;


4)Find Departments with No Employees
Problem: Given a `Departments` table and an `Employees` table,
find departments that do not have any employees.
Table Structure:
```
CREATE TABLE Departments (
DepartmentID INT,
DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
EmployeeID INT,
DepartmentID INT
);

--using correlated subqueries

SELECT DepartmentID , DepartmentName
FROM Departments D
WHERE NOT EXISTS (SELECT DepartmentID FROM Employees E WHERE E.DepartmentID = D.DepartmentID)

--using LEFT JOIN

SELECT D.DepartmentID, D.DepartmentName
FROM Departments D
LEFT JOIN Employees E 
ON D.DepartmentID = E.DepartmentID
WHERE 
    E.EmployeeID IS NULL;

5)Find the Monthly Average Sales for Each Salesperson
Problem: Given a `Sales` table
with columns `SalesPersonID`, `SaleAmount`, and `SaleDate`,
find the monthly average sales for each salesperson.

SELECT 
    SalesPersonID,
    YEAR(SaleDate) AS SaleYear,
    MONTH (SaleDate) AS SaleMonth,
    AVG(SaleAmount) AS MonthlyAverageSales
FROM Sales
GROUP BY SalesPersonID, SaleYear, SaleMonth
ORDER BY SalesPersonID, SaleYear, SaleMonth;
