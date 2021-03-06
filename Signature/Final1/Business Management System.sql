USE [master]
GO
/****** Object:  Database [BusinessManagementSystem]    Script Date: 26-Oct-19 7:53:08 PM ******/
CREATE DATABASE [BusinessManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BusinessManagementSystem', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BusinessManagementSystem.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BusinessManagementSystem_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BusinessManagementSystem_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BusinessManagementSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BusinessManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BusinessManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BusinessManagementSystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BusinessManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BusinessManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BusinessManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BusinessManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BusinessManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BusinessManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [BusinessManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BusinessManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BusinessManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BusinessManagementSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [BusinessManagementSystem]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 26-Oct-19 7:53:08 PM ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 26-Oct-19 7:53:08 PM ******/
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
/****** Object:  Table [dbo].[Login]    Script Date: 26-Oct-19 7:53:08 PM ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 26-Oct-19 7:53:08 PM ******/
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
/****** Object:  Table [dbo].[Purchase]    Script Date: 26-Oct-19 7:53:08 PM ******/
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
/****** Object:  Table [dbo].[PurchaseItems]    Script Date: 26-Oct-19 7:53:08 PM ******/
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
/****** Object:  Table [dbo].[Sales]    Script Date: 26-Oct-19 7:53:08 PM ******/
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
/****** Object:  Table [dbo].[SalesItem]    Script Date: 26-Oct-19 7:53:08 PM ******/
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
/****** Object:  Table [dbo].[Supplier]    Script Date: 26-Oct-19 7:53:08 PM ******/
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
USE [master]
GO
ALTER DATABASE [BusinessManagementSystem] SET  READ_WRITE 
GO
