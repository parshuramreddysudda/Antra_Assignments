USE Northwind
GO

-- 1. List all cities that have both Employees and Customers.

SELECT DISTINCT c.city
from Employees e 
JOIN Customers c ON c.city = e.city



2.      List all cities that have Customers but no Employee.


select * from dbo.Employees;
select * from dbo.Customers;

-- a.      Use sub-query

SELECT DISTINCT City
FROM Customers 
WHERE City NOT IN (
    SELECT DISTINCT City 
    FROM Employees
)

b.      Do not use sub-query

SELECT DISTINCT c.city
from Customers c 
LEFT JOIN Employees e ON c.city != e.city
ORDER BY c.City



3.      List all products and their total order quantities throughout all orders.

4.      List all Customer Cities and total products ordered by that city.

5.      List all Customer Cities that have at least two customers.

a.      Use union

b.      Use sub-query and no union

6.      List all Customer Cities that have ordered at least two different kinds of products.

7.      List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

9.      List all cities that have never ordered something but we have employees there.

a.      Use sub-query

b.      Do not use sub-query

10.  List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)

11. How do you remove the duplicates record of a table?