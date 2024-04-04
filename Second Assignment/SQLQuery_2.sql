USE AdventureWorks2019
GO

Select * from Production.product;
-- 1. How many products can you find in the Production.Product table?

Select Count(p.ProductID) as "Number of Products" 
from Production.Product p;

-- 2 Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. 
-- The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.


Select Count(ProductID) as "Number of Products in SubCategory" 
from Production.product 
where ProductSubcategoryID IS NOT NULL;

--(OR)

Select Count(ProductID) as "Number of Products in SubCategory" 
from (
    
        Select ProductID, ProductSubcategoryID
        from Production.product 
        where ProductSubcategoryID IS NOT NULL
)
as ProductSubcategoryID;

--3.      How many Products reside in each SubCategory? Write a query to display the results with the following titles.

--ProductSubcategoryID CountedProducts

Select ProductSubcategoryID, Count(ProductSubcategoryID) as "CountedProducts" 
from Production.product 
GROUP BY (ProductSubcategoryID);


 -- 4. How many products that do not have a product subcategory.

Select Count(ProductID) as "Number of Products in SubCategory" 
from Production.product 
where ProductSubcategoryID IS NULL;


-- 5. Write a query to list the sum of products quantity in the Production.ProductInventory table.

-- Select * from Production.ProductInventory;

Select SUM(quantity) as "Number of ProductInventory" 
from Production.ProductInventory p;


-- 6.   Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.

--       ProductID    TheSum



Select ProductID,SUM(quantity) as "TheSum" 
from Production.ProductInventory 
where LocationID=40 
GROUP BY Shelf,ProductID
HAVING SUM(quantity) < 100



--7.    Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and 
-- limit the result to include just summarized quantities less than 100

Select Shelf,ProductID,SUM(quantity) as "TheSum" 
from Production.ProductInventory 
where LocationID=40 
GROUP BY Shelf,ProductID
HAVING SUM(quantity) < 100



-- 8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.

SELECT ProductID, AVG(quantity) as "The AVG"
from Production.ProductInventory 
where LocationID=10
GROUP BY ProductID


-- 9.    Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory

 --   ProductID   Shelf      TheAvg

SELECT ProductID,Shelf, AVG(quantity) as "The AVG"
from Production.ProductInventory 
GROUP BY ProductID,Shelf



-- 10.  Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory

 --   ProductID   Shelf      TheAvg

SELECT ProductID,Shelf, AVG(quantity) as "The AVG"
from Production.ProductInventory
where Shelf != 'N/A'
GROUP BY ProductID,Shelf


-- 11.  List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column.
 -- Exclude the rows where Color or Class are null.

--    Color                        Class              TheCount          AvgPrice



SELECT Color,Class, COUNT(*) as "The Count", AVG(ListPrice) as "AvgPrice"
from Production.Product
where Color IS NOT NULL and Class IS NOT NULL
GROUP BY Color,Class



-- Joins:

-- 12.   Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.

    -- Country                        Province

SELECT pc.Name as 'Country', ps.Name as 'Province'
From Person.CountryRegion pc
JOIN Person.StateProvince ps ON pc.CountryRegionCode = ps.CountryRegionCode


-- 13.  Write a query that lists the country and province names from person. CountryRegion and person. 
-- StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
--     Country                        Province


SELECT pc.Name AS 'Country', ps.Name AS 'Province'
FROM Person.CountryRegion pc
JOIN Person.StateProvince ps ON pc.CountryRegionCode = ps.CountryRegionCode
WHERE pc.Name IN ('Germany', 'Canada') ORDER BY pc.Name;



USE Northwind
GO
--  Using Northwnd Database: (Use aliases for all the Joins)

-- 14.  List all Products that has been sold at least once in last 25 years.

    -- select * from dbo.Products;
    -- SELECT * FROM [Order Details];
    -- SELECT * FROM dbo.Orders;


SELECT DISTINCT p.ProductName
FROM dbo.Products p
JOIN  [Order Details] od ON p.ProductID = od.ProductID
JOIN dbo.Orders o ON od.OrderID = o.OrderID
WHERE o.OrderDate <= DATEADD(year, -25, GETDATE());



-- 15.  List top 5 locations (Zip Code) where the products sold most.

SELECT top 5 o.ShipPostalCode, SUM(od.Quantity) AS QuantityofOrders
FROM Orders AS o LEFT JOIN [Order Details] AS od ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY o.ShipPostalCode
ORDER BY QuantityofOrders DESC



-- 16.  List top 5 locations (Zip Code) where the products sold most in last 25 years.


SELECT top 5 o.ShipPostalCode, SUM(od.Quantity) AS QuantityofOrders
FROM Orders AS o LEFT JOIN [Order Details] AS od ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL and o.OrderDate <= DATEADD(year, -25, GETDATE())
GROUP BY o.ShipPostalCode
ORDER BY QuantityofOrders DESC


-- 17.   List all city names and number of customers in that city.     

    Select city, count(*) as Customers
    from dbo.customers
    GROUP by city



-- 18.  List city names which have more than 2 customers, and number of customers in that city

   Select city, count(*) as Customers
    from dbo.customers
    GROUP by city
    Having count(*) > 2


-- 19.  List the names of customers who placed orders after 1/1/98 with order date.


Select dc.ContactName
from dbo.customers AS dc
JOIN dbo.Orders AS o ON dc.customerID = o.customerID
where o.orderDate > '1/1/98'
    


-- 20.  List the names of all customers with most recent order dates



Select dc.ContactName,o.orderdate
from dbo.customers AS dc
JOIN dbo.Orders AS o ON dc.customerID = o.customerID
-- GROUP BY dc.ContactName
order by o.OrderDate desc


-- 21.  Display the names of all customers  along with the  count of products they bought


SELECT c.ContactName, SUM(od.Quantity) AS "Count of Product"
FROM Orders AS o LEFT JOIN [Order Details] AS od ON o.OrderID = od.OrderID 
LEFT JOIN Customers AS c ON o.CustomerID = c.CustomerID
GROUP BY c.ContactName


-- 22.  Display the customer ids who bought more than 100 Products with count of products.


SELECT o.CustomerID, SUM(od.Quantity) AS "Count of Product"
FROM Orders AS o LEFT JOIN [Order Details] AS od ON o.OrderID = od.OrderID 
LEFT JOIN Customers AS c ON o.CustomerID = c.CustomerID
GROUP BY o.CustomerID
HAVING SUM(od.Quantity) > 100



-- 23.  List all of the possible ways that suppliers can ship their products. Display the results as below

    -- Supplier Company Name                Shipping Company Name


SELECT DISTINCT sp.CompanyName AS 'Supplier Company Name  ', sh.CompanyName AS 'Shipping Company Name'
FROM Suppliers AS sp LEFT JOIN Products AS p ON sp.SupplierID = p.SupplierID
LEFT JOIN [Order Details] AS od ON p.ProductID = od.ProductID
LEFT JOIN Orders AS o ON od.OrderID = o.OrderID
LEFT JOIN Shippers AS sh ON o.ShipVia = sh.ShipperID


-- 24. Display the products order each day. Show Order date and Product Name.

SELECT o.OrderDate, p.ProductName
FROM Orders AS o LEFT JOIN [Order Details] AS od ON o.OrderID = od.OrderID 
LEFT JOIN Products AS p ON od.ProductID = p.ProductID


-- 25.  Displays pairs of employees who have the same job title.

SELECT e1.Title, e1.FirstName+' '+e1.LastName AS "Employee 1", e2.FirstName+' '+e2.LastName AS "Employee 2"
FROM Employees e1  JOIN Employees e2 ON e1.Title = e2.Title
WHERE e1.EmployeeID < e2.EmployeeID

26.  Display all the Managers who have more than 2 employees reporting to them.

27.  Display the customers and suppliers by city. The results should have the following columns