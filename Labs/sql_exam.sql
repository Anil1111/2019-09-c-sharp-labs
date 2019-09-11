select top 1 *, 0 as Products from Products
select top 1 *, 0 as Customers from Customers
select top 1 *, 0 as Suppliers from Suppliers
select top 1 *, 0 as Categories from Categories

--1.1 Write a query that lists all Customers in either Paris or London. Include Customer ID, Company Name and all address fields.
--select CustomerID, CompanyName, Address, City, Region, PostalCode, Country from Customers

--1.2 List all products stored in bottle.
--select * from Products where QuantityPerUnit LIKE '%bottle%'

--1.3 Repeat question above, but add in the Supplier Name and Country.
--select Products.ProductName, Suppliers.CompanyName, Suppliers.Country from Products
--join Suppliers on Products.SupplierID = Suppliers.SupplierID
--where QuantityPerUnit LIKE '%bottle%' 

--1.4 Write an SQL Statement that shows how many products there are in each category. Include Category Name in result set and list the highest number first.
select count(ProductID) from Products 
join Categories on Products.CategoryID = Categories.CategoryID
group by Products.CategoryID