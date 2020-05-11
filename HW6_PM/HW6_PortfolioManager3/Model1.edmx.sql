
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/09/2020 16:46:47
-- Generated from EDMX file: C:\Users\Yuqiong Ji\source\repos\HW6_PortfolioManager3\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PortfolioDataModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Instruments'
CREATE TABLE [dbo].[Instruments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Strike] float  NULL,
    [Tenor] float  NULL,
    [CallPut] nvarchar(max)  NULL,
    [Rebate] float  NULL,
    [Barrier] float  NULL,
    [BarrierType] nvarchar(max)  NULL,
    [Exchange] nvarchar(max)  NOT NULL,
    [InstrumentName] nvarchar(max)  NOT NULL,
    [InstTypeId] int  NOT NULL,
    [UnderlyingId] int  NOT NULL
);
GO

-- Creating table 'Underlyings'
CREATE TABLE [dbo].[Underlyings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [Ticker] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Prices'
CREATE TABLE [dbo].[Prices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [ClosingPrice] float  NOT NULL,
    [UnderlyingId] int  NOT NULL
);
GO

-- Creating table 'InstTypes'
CREATE TABLE [dbo].[InstTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Trades'
CREATE TABLE [dbo].[Trades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BuySell] nvarchar(max)  NOT NULL,
    [Quantity] int  NOT NULL,
    [TradePrice] float  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [InstrumentId] int  NOT NULL
);
GO

-- Creating table 'InterestRates'
CREATE TABLE [dbo].[InterestRates] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tenor] float  NOT NULL,
    [Rate] float  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Instruments'
ALTER TABLE [dbo].[Instruments]
ADD CONSTRAINT [PK_Instruments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Underlyings'
ALTER TABLE [dbo].[Underlyings]
ADD CONSTRAINT [PK_Underlyings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [PK_Prices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InstTypes'
ALTER TABLE [dbo].[InstTypes]
ADD CONSTRAINT [PK_InstTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Trades'
ALTER TABLE [dbo].[Trades]
ADD CONSTRAINT [PK_Trades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InterestRates'
ALTER TABLE [dbo].[InterestRates]
ADD CONSTRAINT [PK_InterestRates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UnderlyingId] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_UnderlyingPrice]
    FOREIGN KEY ([UnderlyingId])
    REFERENCES [dbo].[Underlyings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnderlyingPrice'
CREATE INDEX [IX_FK_UnderlyingPrice]
ON [dbo].[Prices]
    ([UnderlyingId]);
GO

-- Creating foreign key on [InstTypeId] in table 'Instruments'
ALTER TABLE [dbo].[Instruments]
ADD CONSTRAINT [FK_InstrumentInstType]
    FOREIGN KEY ([InstTypeId])
    REFERENCES [dbo].[InstTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InstrumentInstType'
CREATE INDEX [IX_FK_InstrumentInstType]
ON [dbo].[Instruments]
    ([InstTypeId]);
GO

-- Creating foreign key on [UnderlyingId] in table 'Instruments'
ALTER TABLE [dbo].[Instruments]
ADD CONSTRAINT [FK_InstrumentUnderlying]
    FOREIGN KEY ([UnderlyingId])
    REFERENCES [dbo].[Underlyings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InstrumentUnderlying'
CREATE INDEX [IX_FK_InstrumentUnderlying]
ON [dbo].[Instruments]
    ([UnderlyingId]);
GO

-- Creating foreign key on [InstrumentId] in table 'Trades'
ALTER TABLE [dbo].[Trades]
ADD CONSTRAINT [FK_InstrumentTrade]
    FOREIGN KEY ([InstrumentId])
    REFERENCES [dbo].[Instruments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InstrumentTrade'
CREATE INDEX [IX_FK_InstrumentTrade]
ON [dbo].[Trades]
    ([InstrumentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------