
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/05/2026 19:50:37
-- Generated from EDMX file: D:\Учеба\Ado Net\проекты\PV_524\Lesson_4_УА_ЬА\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Publisher_P524];
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

-- Creating table 'CountrySet'
CREATE TABLE [dbo].[CountrySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameCountry] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'AutorSet'
CREATE TABLE [dbo].[AutorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FN] nvarchar(100)  NOT NULL,
    [LN] nvarchar(100)  NOT NULL,
    [CountryId] int  NOT NULL
);
GO

-- Creating table 'BookSet'
CREATE TABLE [dbo].[BookSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Page] int  NULL,
    [Price] decimal(18,0)  NULL,
    [AutorId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CountrySet'
ALTER TABLE [dbo].[CountrySet]
ADD CONSTRAINT [PK_CountrySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AutorSet'
ALTER TABLE [dbo].[AutorSet]
ADD CONSTRAINT [PK_AutorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BookSet'
ALTER TABLE [dbo].[BookSet]
ADD CONSTRAINT [PK_BookSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AutorId] in table 'BookSet'
ALTER TABLE [dbo].[BookSet]
ADD CONSTRAINT [FK_AutorBook]
    FOREIGN KEY ([AutorId])
    REFERENCES [dbo].[AutorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutorBook'
CREATE INDEX [IX_FK_AutorBook]
ON [dbo].[BookSet]
    ([AutorId]);
GO

-- Creating foreign key on [CountryId] in table 'AutorSet'
ALTER TABLE [dbo].[AutorSet]
ADD CONSTRAINT [FK_CountryAutor]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[CountrySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryAutor'
CREATE INDEX [IX_FK_CountryAutor]
ON [dbo].[AutorSet]
    ([CountryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------