
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/11/2019 10:59:32
-- Generated from EDMX file: C:\Users\aluno\Documents\Wesley_C#\C-\ESports\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbESports];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_JogadorTime]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JogadorSet] DROP CONSTRAINT [FK_JogadorTime];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[JogadorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JogadorSet];
GO
IF OBJECT_ID(N'[dbo].[TimeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'JogadorSet'
CREATE TABLE [dbo].[JogadorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Elo] nvarchar(max)  NOT NULL,
    [Lane] int  NOT NULL,
    [TimeId] int  NULL
);
GO

-- Creating table 'TimeSet'
CREATE TABLE [dbo].[TimeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [DataFundacao] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'JogadorSet'
ALTER TABLE [dbo].[JogadorSet]
ADD CONSTRAINT [PK_JogadorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TimeSet'
ALTER TABLE [dbo].[TimeSet]
ADD CONSTRAINT [PK_TimeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TimeId] in table 'JogadorSet'
ALTER TABLE [dbo].[JogadorSet]
ADD CONSTRAINT [FK_JogadorTime]
    FOREIGN KEY ([TimeId])
    REFERENCES [dbo].[TimeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JogadorTime'
CREATE INDEX [IX_FK_JogadorTime]
ON [dbo].[JogadorSet]
    ([TimeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------