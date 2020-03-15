USE [master]
GO

/****** Object:  Database [MonteCarloSimulator]    Script Date: 3/15/2020 6:13:14 PM ******/
CREATE DATABASE [MonteCarloSimulator]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MonteCarloSimulator', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MonteCarloSimulator.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MonteCarloSimulator_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MonteCarloSimulator_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MonteCarloSimulator].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MonteCarloSimulator] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET ARITHABORT OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MonteCarloSimulator] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MonteCarloSimulator] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MonteCarloSimulator] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MonteCarloSimulator] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET RECOVERY FULL 
GO

ALTER DATABASE [MonteCarloSimulator] SET  MULTI_USER 
GO

ALTER DATABASE [MonteCarloSimulator] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MonteCarloSimulator] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MonteCarloSimulator] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MonteCarloSimulator] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MonteCarloSimulator] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MonteCarloSimulator] SET QUERY_STORE = OFF
GO

ALTER DATABASE [MonteCarloSimulator] SET  READ_WRITE 
GO




USE [MonteCarloSimulator]
GO

/****** Object:  Table [MonteSchema].[Instrument]    Script Date: 3/15/2020 6:36:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [MonteSchema].[Instrument](
	[InstrumentID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NULL,
	[Ticker] [varchar](50) NULL,
	[Exchange] [varchar](50) NOT NULL,
	[UnderlyingID] [int] NULL,
	[Strike] [float] NULL,
	[Tenor] [float] NULL,
	[IsCall] [bit] NULL,
	[TypeID] [int] NOT NULL,
 CONSTRAINT [PK_Instrument] PRIMARY KEY CLUSTERED 
(
	[InstrumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [MonteSchema].[Instrument]  WITH CHECK ADD  CONSTRAINT [FK_Instrument_InstType] FOREIGN KEY([TypeID])
REFERENCES [MonteSchema].[InstType] ([TypeID])
GO

ALTER TABLE [MonteSchema].[Instrument] CHECK CONSTRAINT [FK_Instrument_InstType]
GO

USE [MonteCarloSimulator]
GO

/****** Object:  Table [MonteSchema].[InstType]    Script Date: 3/15/2020 6:37:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [MonteSchema].[InstType](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_InstType] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [MonteCarloSimulator]
GO

/****** Object:  Table [MonteSchema].[InterestRate]    Script Date: 3/15/2020 6:37:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [MonteSchema].[InterestRate](
	[RateID] [int] IDENTITY(1,1) NOT NULL,
	[Tenor] [float] NOT NULL,
	[Rate] [float] NOT NULL,
 CONSTRAINT [PK_InterestRate] PRIMARY KEY CLUSTERED 
(
	[RateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [MonteCarloSimulator]
GO

/****** Object:  Table [MonteSchema].[Price]    Script Date: 3/15/2020 6:37:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [MonteSchema].[Price](
	[PriceID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[ClosingPrice] [float] NOT NULL,
 CONSTRAINT [PK_Price] PRIMARY KEY CLUSTERED 
(
	[PriceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [MonteCarloSimulator]
GO

/****** Object:  Table [MonteSchema].[Trade]    Script Date: 3/15/2020 6:38:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [MonteSchema].[Trade](
	[TradeID] [int] IDENTITY(1,1) NOT NULL,
	[IsBuy] [bit] NOT NULL,
	[Quantity] [int] NOT NULL,
	[InstrumentID] [int] NOT NULL,
	[TradePrice] [float] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Trade] PRIMARY KEY CLUSTERED 
(
	[TradeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [MonteSchema].[Trade]  WITH CHECK ADD  CONSTRAINT [FK_Trade_Instrument] FOREIGN KEY([InstrumentID])
REFERENCES [MonteSchema].[Instrument] ([InstrumentID])
GO

ALTER TABLE [MonteSchema].[Trade] CHECK CONSTRAINT [FK_Trade_Instrument]
GO

