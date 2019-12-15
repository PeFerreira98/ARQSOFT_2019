USE master;
GO

IF DB_ID (N'mealDB') IS NOT NULL
DROP DATABASE mealDB;
GO
CREATE DATABASE mealDB;
GO

IF DB_ID (N'pointOfSaleDB') IS NOT NULL
DROP DATABASE pointOfSaleDB;
GO
CREATE DATABASE pointOfSaleDB;
GO

IF DB_ID (N'mealItemDB') IS NOT NULL
DROP DATABASE mealItemDB;
GO
CREATE DATABASE mealItemDB;
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Meal](
	[MealID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Prefix] [nvarchar](50) NOT NULL,
	[Suffix] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MealID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PointOfSale](
	[PointOfSaleID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Building] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PointOfSaleID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[MealItem](
	[MealItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductionDate] [datetime2](7) NOT NULL,
	[ExpirationDate] [datetime2](7) NOT NULL,
	[AvailableStatus] [bit] NOT NULL,
	[MealIdentificationNumber] [nvarchar](50) NOT NULL,
	[MealID] [bigint] NOT NULL,
	[PointOfSaleID] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MealItemID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO