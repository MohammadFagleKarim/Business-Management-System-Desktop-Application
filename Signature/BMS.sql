create database BusinessManagementSystem
use BusinessManagementSystem

DROP DATABASE BusinessManagementSystem

CREATE TABLE Category(
Id INT IDENTITY(1,1)  PRIMARY KEY,
Code VARCHAR(50),
Name VARCHAR(50),
)

CREATE TABLE Product
(
Id INT IDENTITY(1,1) PRIMARY KEY,
CategoryId INT REFERENCES Category (Id),
Code VARCHAR(50),
Name VARCHAR(50),
ReorderLevel INT,
[Description] VARCHAR(50),
)

CREATE TABLE Customer(
Id INT IDENTITY(1,1)  PRIMARY KEY,
Code VARCHAR(50),
Name VARCHAR(50),
[Address] VARCHAR(50),
Email VARCHAR(50),
Contact VARCHAR(50),
LoyalityPoint INT,
)

CREATE TABLE Supplier(
Id INT IDENTITY(1,1)  PRIMARY KEY,
Code VARCHAR(50),
Name VARCHAR(50),
[Address] VARCHAR(50),
Email VARCHAR(50),
Contact VARCHAR(50),
ContactPerson VARCHAR(50),
)

CREATE TABLE Purchase(
Id INT IDENTITY(1,1)  PRIMARY KEY,
Code VARCHAR(50),
[Date] VARCHAR(50),
Bill VARCHAR(50),
SupplierId INT REFERENCES Supplier (Id),
)

CREATE TABLE PurchaseItems(
Id INT IDENTITY(1,1)  PRIMARY KEY,
CategoryId INT REFERENCES Category (Id),
ProductId INT REFERENCES Product (Id),
PurchaseId INT REFERENCES Purchase (Id),
AvailableQuantity INT,
ManufacturedDate VARCHAR(50),
[ExpireDate] VARCHAR(50),
Quantity INT,
UnitPrice Float,
TotalPrice Float,
PreviousUnitPrice Float,
PreviousMRP Float,
MRP Float,
Remarks VARCHAR(50)
)

CREATE TABLE Sales(
Id INT IDENTITY(1,1)  PRIMARY KEY,
Code VARCHAR(50),
CustomerId INT REFERENCES Customer (Id),
[Date] VARCHAR(50),
LoyalityPoint INT,
GrandTotal Float,
Discount int,
DiscountAmount Float,
PayableAmount Float,
)

CREATE TABLE SalesItem(
Id INT IDENTITY(1,1)  PRIMARY KEY,
CategoryId INT REFERENCES Category (Id),
ProductId INT REFERENCES Product (Id),
SalesId INT REFERENCES Sales (Id),
AvailableQuantity INT,
Quantity INT,
MRP Float,
TotalMRP Float,
)

drop table Category
drop table Product
drop table Customer
drop table Supplier
drop table Purchase
drop table PurchaseItems
drop table Sales
drop table SalesItem


INSERT INTO Login (Username, Password,Fullname,Contact,Email) Values ('Arafat','R%Z!','Arafat Bin Reza','01625420852','arafat.reza1997@gmail.com');
INSERT INTO Login (Username, Password,Fullname,Contact,Email) Values ('Rezwana','ananna','Rezwana Binte Reza','01676234640','rrananna@gmail.com');

CREATE TABLE Login(
Id INT IDENTITY(1,1)  PRIMARY KEY,
Username VARCHAR(50),
Password VARCHAR(50),
Fullname VARCHAR(50),
Contact VARCHAR(50),
Email VARCHAR(50),
)


CREATE VIEW [ProductDisplay] AS
SELECT p.Code, p.Name, c.Name as Category,p.ReorderLevel, p.Description FROM Product As p LEFT JOIN Category as c ON c.Id = p.CategoryId

