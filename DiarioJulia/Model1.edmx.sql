
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/18/2019 09:47:04
-- Generated from EDMX file: C:\Users\aluno\Documents\Wesley_C#\C-\DiarioJulia\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbDiarioJulia];
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

-- Creating table 'RegistroSet'
CREATE TABLE [dbo].[RegistroSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] nvarchar(max)  NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Classificacao] int  NOT NULL,
    [Conteudo] nvarchar(max)  NOT NULL,
    [LocalId] int  NOT NULL
);
GO

-- Creating table 'PersonagemSet'
CREATE TABLE [dbo].[PersonagemSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GrauParentesco] nvarchar(max)  NOT NULL,
    [Idade] int  NULL,
    [Nota] int  NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Registro_PersonagemSet'
CREATE TABLE [dbo].[Registro_PersonagemSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PersonagemId] int  NULL,
    [RegistroId] int  NOT NULL
);
GO

-- Creating table 'LocalSet'
CREATE TABLE [dbo].[LocalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Endereco] nvarchar(max)  NOT NULL,
    [Referencia] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MelhoriaSet'
CREATE TABLE [dbo].[MelhoriaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Texto] nvarchar(max)  NOT NULL,
    [Possivel] bit  NOT NULL,
    [Registro_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RegistroSet'
ALTER TABLE [dbo].[RegistroSet]
ADD CONSTRAINT [PK_RegistroSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonagemSet'
ALTER TABLE [dbo].[PersonagemSet]
ADD CONSTRAINT [PK_PersonagemSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Registro_PersonagemSet'
ALTER TABLE [dbo].[Registro_PersonagemSet]
ADD CONSTRAINT [PK_Registro_PersonagemSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocalSet'
ALTER TABLE [dbo].[LocalSet]
ADD CONSTRAINT [PK_LocalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MelhoriaSet'
ALTER TABLE [dbo].[MelhoriaSet]
ADD CONSTRAINT [PK_MelhoriaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LocalId] in table 'RegistroSet'
ALTER TABLE [dbo].[RegistroSet]
ADD CONSTRAINT [FK_LocalRegistro]
    FOREIGN KEY ([LocalId])
    REFERENCES [dbo].[LocalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocalRegistro'
CREATE INDEX [IX_FK_LocalRegistro]
ON [dbo].[RegistroSet]
    ([LocalId]);
GO

-- Creating foreign key on [Registro_Id] in table 'MelhoriaSet'
ALTER TABLE [dbo].[MelhoriaSet]
ADD CONSTRAINT [FK_MelhoriaRegistro]
    FOREIGN KEY ([Registro_Id])
    REFERENCES [dbo].[RegistroSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MelhoriaRegistro'
CREATE INDEX [IX_FK_MelhoriaRegistro]
ON [dbo].[MelhoriaSet]
    ([Registro_Id]);
GO

-- Creating foreign key on [PersonagemId] in table 'Registro_PersonagemSet'
ALTER TABLE [dbo].[Registro_PersonagemSet]
ADD CONSTRAINT [FK_Registro_PersonagemPersonagem]
    FOREIGN KEY ([PersonagemId])
    REFERENCES [dbo].[PersonagemSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Registro_PersonagemPersonagem'
CREATE INDEX [IX_FK_Registro_PersonagemPersonagem]
ON [dbo].[Registro_PersonagemSet]
    ([PersonagemId]);
GO

-- Creating foreign key on [RegistroId] in table 'Registro_PersonagemSet'
ALTER TABLE [dbo].[Registro_PersonagemSet]
ADD CONSTRAINT [FK_RegistroRegistro_Personagem]
    FOREIGN KEY ([RegistroId])
    REFERENCES [dbo].[RegistroSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegistroRegistro_Personagem'
CREATE INDEX [IX_FK_RegistroRegistro_Personagem]
ON [dbo].[Registro_PersonagemSet]
    ([RegistroId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------