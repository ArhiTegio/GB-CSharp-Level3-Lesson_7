
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/17/2020 22:31:37
-- Generated from EDMX file: D:\Программирование\Проекты\GB-CSharp-Level3-Lesson_7\CinemaOffice\CinemaOffice\Cinema.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CinemaBD];
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

-- Creating table 'MoviesSet'
CREATE TABLE [dbo].[MoviesSet] (
    [MovieId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [StartTime] datetime  NOT NULL
);
GO

-- Creating table 'TiketsSet'
CREATE TABLE [dbo].[TiketsSet] (
    [TiketsId] int IDENTITY(1,1) NOT NULL,
    [Count] int  NOT NULL,
    [Time] datetime  NOT NULL,
    [MoviesID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MovieId] in table 'MoviesSet'
ALTER TABLE [dbo].[MoviesSet]
ADD CONSTRAINT [PK_MoviesSet]
    PRIMARY KEY CLUSTERED ([MovieId] ASC);
GO

-- Creating primary key on [TiketsId] in table 'TiketsSet'
ALTER TABLE [dbo].[TiketsSet]
ADD CONSTRAINT [PK_TiketsSet]
    PRIMARY KEY CLUSTERED ([TiketsId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MoviesID] in table 'TiketsSet'
ALTER TABLE [dbo].[TiketsSet]
ADD CONSTRAINT [FK_MoviesTikets]
    FOREIGN KEY ([MoviesID])
    REFERENCES [dbo].[MoviesSet]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MoviesTikets'
CREATE INDEX [IX_FK_MoviesTikets]
ON [dbo].[TiketsSet]
    ([MoviesID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------