USE Northwind
GO
-- 1. List all cities that have both Employees and Customers.

SELECT DISTINCT c.city
from Employees e 
JOIN Customers c ON c.city = e.city;

-- 2.      List all cities that have Customers but no Employee.

-- a.      Use sub-query

SELECT DISTINCT City
FROM Customers 
WHERE City NOT IN (
    SELECT DISTINCT City 
    FROM Employees
);

-- b.      Do not use sub-query

SELECT DISTINCT c.city
from Customers c 
LEFT JOIN Employees e ON c.city = e.city
where e.employeeID IS NULL;


-- 3.      List all products and their total order quantities throughout all orders.

select p.ProductID, p.ProductName, SUM(od.Quantity) as "Quantity of Products"
From products AS p 
JOIN [Order Details] od on od.ProductID = p.ProductID
GROUP BY p.ProductID,p.ProductName;

 
select p.ProductID, p.ProductName,od.Totals as "Quantity of Products"
From products AS p 
LEFT JOIN (
Select od.productID,SUM(od.Quantity) as Totals
from [Order Details] od
GROUP BY od.ProductID) as od on od.ProductID = p.ProductID;


-- 4.      List all Customer Cities and total products ordered by that city.


SELECT doc.City, ISNULL(SUM(CountOrders.Quantity),0) as "Order Sum"
From dbo.Customers as doc 
JOIN  
(   SELECT dos.CustomerID,od.Quantity
    FROM dbo.Orders as dos
    JOIN [Order Details] od ON od.OrderID=dos.OrderID
) as CountOrders on CountOrders.CustomerID = doc.CustomerID
GROUP BY doc.City;


-- 5.      List all Customer Cities that have at least two customers.

Select dc.city,COUNT(dc.ContactName) as CustomerCount
FROM dbo.customers as dc
GROUP BY dc.city
HAVING COUNT(dc.ContactName) >= 2;


-- a. Use union

SELECT c1.City
FROM Customers c1, Customers c2
WHERE c1.City = c2.City AND c1.CustomerID < c2.CustomerID
UNION
SELECT c2.City
FROM Customers c1, Customers c2
WHERE c1.City = c2.City AND c1.CustomerID > c2.CustomerID;


-- b.      Use sub-query and no union


SELECT DISTINCT c1.City
FROM Customers c1
WHERE c1.city  IN (
    SELECT c2.City
    FROM Customers c1, Customers c2
    WHERE c1.City = c2.City AND c1.CustomerID > c2.CustomerID
    );

-- 6. List all Customer Cities that have ordered at least two different kinds of products.



WITH temp AS (
    SELECT DISTINCT c.City, od.ProductID
    FROM Customers c 
    LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
    LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
)
SELECT City
FROM temp
GROUP BY City
HAVING COUNT(DISTINCT ProductID) > 1;


-- 7.      List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

SELECT DISTINCT c.ContactName as "Customer Name"
FROM Customers AS c LEFT JOIN Orders AS o ON c.CustomerID = o.CustomerID
WHERE c.City != o.ShipCity;

-- 8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.


WITH Temp AS (
    SELECT od.ProductID, od.UnitPrice AS Price, od.Quantity, c.City,
           ROW_NUMBER() OVER (PARTITION BY od.ProductID ORDER BY SUM(od.Quantity) DESC) AS RowNum
    FROM [Order Details] od 
    LEFT JOIN Orders o ON od.OrderID = o.OrderID
    LEFT JOIN Customers c ON o.CustomerID = c.CustomerID
    GROUP BY od.ProductID, od.UnitPrice, od.Quantity, c.City
)
SELECT TOP 5 ProductID, AVG(Price) AS AvgPrice,
       (SELECT City FROM Temp t2 WHERE t1.ProductID = t2.ProductID AND t2.RowNum = 1) AS City
FROM Temp t1
GROUP BY ProductID
ORDER BY SUM(Quantity) DESC;


-- 9.      List all cities that have never ordered something but we have employees there.

-- a.      Use sub-query

SELECT DISTINCT City
FROM Employees
WHERE City NOT IN (
                    SELECT DISTINCT City 
                    FROM Customers
                  );

--9b. Do not use sub-query
SELECT e.City
FROM Employees e 
LEFT JOIN Customers c ON e.City = c.City
WHERE CustomerID IS NULL;

-- 10.  List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, 
-- and also the city of most total quantity of products ordered from. (tip: join  sub-query)

WITH MostOrderedCity AS (
    SELECT TOP 1 c.City
    FROM Customers AS c 
    LEFT JOIN (
        SELECT o.CustomerID, SUM(od.Quantity) AS TotalQuantity
        FROM Orders AS o 
        LEFT JOIN [Order Details] AS od ON o.OrderID = od.OrderID
        GROUP BY o.CustomerID
    ) AS ood ON c.CustomerID = ood.CustomerID
    GROUP BY c.City
    ORDER BY SUM(ood.TotalQuantity) DESC
), MostOrderingCity AS (
    SELECT TOP 1 c.City
    FROM Orders AS o 
    LEFT JOIN Customers AS c ON o.CustomerID = c.CustomerID
    GROUP BY c.City
    ORDER BY COUNT(o.OrderID) DESC
)
SELECT MostOrderedCity.City
FROM MostOrderedCity, MostOrderingCity
Where MostOrderedCity.city = MostOrderingCity.city;


-- 11. How do you remove the duplicates record of a table?

-- 1. Using union we can remove the select only what we need
-- 2. Also using DISTINCT keyword we can make sure we don't have any repeated values
-- 3. Also using GroupBy clause we can make a unique values column of which we are performing the groupby