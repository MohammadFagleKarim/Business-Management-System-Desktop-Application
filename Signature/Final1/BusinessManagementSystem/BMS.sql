create database BusinessManagementSystem
USE [BusinessManagementSystem]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 27-Oct-19 3:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 27-Oct-19 3:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Contact] [varchar](50) NOT NULL,
	[LoyalityPoint] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 27-Oct-19 3:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Fullname] [varchar](50) NOT NULL,
	[Contact] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 27-Oct-19 3:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ReorderLevel] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 27-Oct-19 3:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Purchase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Bill] [varchar](50) NOT NULL,
	[SupplierId] [int] NOT NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseItems]    Script Date: 27-Oct-19 3:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[PurchaseId] [int] NOT NULL,
	[AvailableQuantity] [int] NOT NULL,
	[ManufacturedDate] [date] NOT NULL,
	[ExpireDate] [date] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[PreviousUnitPrice] [float] NOT NULL,
	[PreviousMRP] [float] NOT NULL,
	[MRP] [float] NOT NULL,
	[Remarks] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PurchaseItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 27-Oct-19 3:33:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[LoyalityPoint] [int] NOT NULL,
	[GrandTotal] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[DiscountAmount] [float] NOT NULL,
	[PayableAmount] [float] NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalesItem]    Script Date: 27-Oct-19 3:33:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[SalesId] [int] NOT NULL,
	[AvailableQuantity] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[MRP] [float] NOT NULL,
	[TotalMRP] [float] NOT NULL,
 CONSTRAINT [PK_SalesItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 27-Oct-19 3:33:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Contact] [varchar](50) NOT NULL,
	[ContactPerson] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Stock]    Script Date: 27-Oct-19 3:33:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Stock]
AS
SELECT pu.Code,pr.Name,c.Name as Category,pr.ReorderLevel,pui.ExpireDate,pui.AvailableQuantity as Opening_Balance,pui.Quantity as inn,si.Quantity as Out,si.AvailableQuantity as Closing_Balance From PurchaseItems as pui
LEFT JOIN Purchase as pu ON pu.Id = pui.PurchaseId 
LEFT JOIN Product as pr ON pr.Id = pui.ProductId
LEFT JOIN Category as c ON c.Id = pui.CategoryId
LEFT JOIN SalesItem as si ON si.AvailableQuantity = pui.AvailableQuantity
GO
/****** Object:  View [dbo].[InOut]    Script Date: 27-Oct-19 3:33:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[InOut]
AS
SELECT SUM(inn) as newinn,SUM(Out) as newout FROM Stock
GO
/****** Object:  View [dbo].[Sale]    Script Date: 27-Oct-19 3:33:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Sale]
AS
SELECT s.Code ,pr.Name,c.Name as Category,si.Quantity as SaleQ,pui.UnitPrice as CP, si.MRP as Sales_Price, (pui.UnitPrice-si.MRP) as Profit From SalesItem as si
LEFT JOIN Sales as s ON s.Id = si.SalesId
LEFT JOIN Product as pr ON pr.Id = si.ProductId
LEFT JOIN Category as c ON c.Id = si.CategoryId
LEFT JOIN PurchaseItems as pui ON  pui.AvailableQuantity = si.AvailableQuantity

GO
/****** Object:  View [dbo].[SoldQty]    Script Date: 27-Oct-19 3:33:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SoldQty]
AS
SELECT SUM(Sale.SaleQ) as SoldQty FROM Sale
GO
/****** Object:  View [dbo].[ProductDisplay]    Script Date: 27-Oct-19 3:33:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ProductDisplay] AS
SELECT p.Code, p.Name, c.Name as Category,p.ReorderLevel, p.Description FROM Product As p LEFT JOIN Category as c ON c.Id = p.CategoryId
GO
/****** Object:  View [dbo].[Purchases]    Script Date: 27-Oct-19 3:33:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Purchases]
AS
SELECT pu.Code ,pr.Name,c.Name as Category,pui.AvailableQuantity,pui.UnitPrice as CP, pui.MRP, (pui.UnitPrice-pui.MRP) as Profit From PurchaseItems as pui
LEFT JOIN Purchase as pu ON pu.Id = pui.PurchaseId 
LEFT JOIN Product as pr ON pr.Id = pui.ProductId
LEFT JOIN Category as c ON c.Id = pui.CategoryId
LEFT JOIN SalesItem as si ON si.AvailableQuantity = pui.AvailableQuantity
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [CategoryId] FOREIGN KEY([Id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [CategoryId]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Supplier] FOREIGN KEY([Id])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Supplier]
GO
ALTER TABLE [dbo].[PurchaseItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseItems_Category] FOREIGN KEY([Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[PurchaseItems] CHECK CONSTRAINT [FK_PurchaseItems_Category]
GO
ALTER TABLE [dbo].[PurchaseItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseItems_Product] FOREIGN KEY([Id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[PurchaseItems] CHECK CONSTRAINT [FK_PurchaseItems_Product]
GO
ALTER TABLE [dbo].[PurchaseItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseItems_Purchase] FOREIGN KEY([Id])
REFERENCES [dbo].[Purchase] ([Id])
GO
ALTER TABLE [dbo].[PurchaseItems] CHECK CONSTRAINT [FK_PurchaseItems_Purchase]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Customer] FOREIGN KEY([Id])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Customer]
GO
ALTER TABLE [dbo].[SalesItem]  WITH CHECK ADD  CONSTRAINT [FK_SalesItem_Category] FOREIGN KEY([Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[SalesItem] CHECK CONSTRAINT [FK_SalesItem_Category]
GO
ALTER TABLE [dbo].[SalesItem]  WITH CHECK ADD  CONSTRAINT [FK_SalesItem_Customer] FOREIGN KEY([Id])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[SalesItem] CHECK CONSTRAINT [FK_SalesItem_Customer]
GO
ALTER TABLE [dbo].[SalesItem]  WITH CHECK ADD  CONSTRAINT [FK_SalesItem_Product] FOREIGN KEY([Id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[SalesItem] CHECK CONSTRAINT [FK_SalesItem_Product]
GO
ALTER TABLE [dbo].[SalesItem]  WITH CHECK ADD  CONSTRAINT [FK_SalesItem_Sales] FOREIGN KEY([Id])
REFERENCES [dbo].[Sales] ([Id])
GO
ALTER TABLE [dbo].[SalesItem] CHECK CONSTRAINT [FK_SalesItem_Sales]
GO




create view[PurchaseDisplay] AS
SELECT pu.Code, pui.ManufacturedDate, pui.ExpireDate, pui.Quantity, pui.UnitPrice, pui.TotalPrice, pui.MRP, pui.Remarks FROM Purchase as pu LEFT JOIN PurchaseItems as pui ON pu.Id = pui.Id
