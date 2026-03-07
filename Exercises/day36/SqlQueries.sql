select p.ProductName,c.CategoryName
from Products p
inner join Categories c
on p.CategoryID = c.CategoryID;

select o.OrderID,c.CompanyName
from Orders o
inner join Customers c
on o.CustomerID = c.CustomerID;

select p.ProductName, s.CompanyName
from Products p
inner join Suppliers s
on p.SupplierID = s.SupplierID;

select o.OrderID,o.OrderDate,e.FirstName,e.LastName
from Orders o
inner join Employees e
on e.EmployeeID = o.EmployeeID;

select o.OrderID , s.CompanyName AS ShipperName
from Orders o
inner join shippers s
on o.ShipVia = s.ShipperID
where o.shipCountry ='France';

select c.CategoryName, SUM(p.UnitsInStock) AS UnitsInStock
from Products p
inner join Categories c
on c.CategoryID = p.CategoryID
group by c.CategoryName;

select c.CompanyName, SUM(od.UnitPrice*od.Quantity) AS TotalSpent
from Customers c
inner join Orders o on c.CustomerID= o.CustomerID
inner join [Order Details] od on o.OrderID = od.OrderID
Group by c.CompanyName;


SELECT e.LastName, COUNT(o.OrderID) AS TotalOrders
FROM Employees e
INNER JOIN Orders o
ON e.EmployeeID = o.EmployeeID
GROUP BY e.LastName;


select s.CompanyName, SUM(o.Freight) AS TotalFreight
from Orders o
inner join Shippers s
on s.ShipperID = o.ShipVia
group by CompanyName;

select top 5 p.ProductName ,
SUM(od.Quantity) AS TotalSold
from Products p
inner join [Order Details] od 
on p.ProductID = od.ProductID
group by p.ProductName
order by TotalSold DESC
;

select ProductName
from Products p
where UnitPrice > (select avg(UnitPrice) from Products);

SELECT E.FirstName AS Employee,
M.FirstName AS Manager
FROM Employees E
LEFT JOIN Employees M
ON E.ReportsTo = M.EmployeeID;

select c.CompanyName 
from Customers c
where CustomerID NOT IN
(select CustomerID from Orders);


select ProductName
from Products p where ProductID not in
(
select od.ProductID
from [Order Details] od
inner join Orders o
on od.OrderID = o.OrderID
where YEAR(o.OrderDate) > 1997
);

select e.FirstName, r.RegionDescription
from Employees e
inner join EmployeeTerritories et
on e.EmployeeID = et.EmployeeID
inner join Territories t
on et.TerritoryID = t.TerritoryID
inner join Region r
on t.RegionID = r.RegionID;

SELECT C.CompanyName AS Customer,
S.CompanyName AS Supplier,
C.City
FROM Customers C
INNER JOIN Suppliers S
ON C.City = S.City;


select C.CompanyName as Customer 
where (
select CategoryID from 