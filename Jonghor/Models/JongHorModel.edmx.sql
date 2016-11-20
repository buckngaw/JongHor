
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/20/2016 20:21:05
-- Generated from EDMX file: C:\Users\WIN8.1\Source\Repos\JongHorGG\Jonghor\Models\JongHorModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [JongHorDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Dorm_Label_Dorm]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dorm_Label] DROP CONSTRAINT [FK_Dorm_Label_Dorm];
GO
IF OBJECT_ID(N'[JongHorDBModelStoreContainer].[FK_Dorm_Option_Dorm]', 'F') IS NOT NULL
    ALTER TABLE [JongHorDBModelStoreContainer].[Dorm_Option] DROP CONSTRAINT [FK_Dorm_Option_Dorm];
GO
IF OBJECT_ID(N'[dbo].[FK_Dorm_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dorm] DROP CONSTRAINT [FK_Dorm_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Dorm_Picture_Dorm]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dorm_Picture] DROP CONSTRAINT [FK_Dorm_Picture_Dorm];
GO
IF OBJECT_ID(N'[JongHorDBModelStoreContainer].[FK_Dorm_Rate_Dorm]', 'F') IS NOT NULL
    ALTER TABLE [JongHorDBModelStoreContainer].[Dorm_Rate] DROP CONSTRAINT [FK_Dorm_Rate_Dorm];
GO
IF OBJECT_ID(N'[JongHorDBModelStoreContainer].[FK_Dorm_Rate_Person]', 'F') IS NOT NULL
    ALTER TABLE [JongHorDBModelStoreContainer].[Dorm_Rate] DROP CONSTRAINT [FK_Dorm_Rate_Person];
GO
IF OBJECT_ID(N'[JongHorDBModelStoreContainer].[FK_Message_Person]', 'F') IS NOT NULL
    ALTER TABLE [JongHorDBModelStoreContainer].[Message] DROP CONSTRAINT [FK_Message_Person];
GO
IF OBJECT_ID(N'[JongHorDBModelStoreContainer].[FK_Message1_Person]', 'F') IS NOT NULL
    ALTER TABLE [JongHorDBModelStoreContainer].[Message] DROP CONSTRAINT [FK_Message1_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Person_Room]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Person] DROP CONSTRAINT [FK_Person_Room];
GO
IF OBJECT_ID(N'[JongHorDBModelStoreContainer].[FK_Room_Option_Room_Type]', 'F') IS NOT NULL
    ALTER TABLE [JongHorDBModelStoreContainer].[Room_Option] DROP CONSTRAINT [FK_Room_Option_Room_Type];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Room] DROP CONSTRAINT [FK_Room_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_Reserved_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Room_Reserved] DROP CONSTRAINT [FK_Room_Reserved_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_Reserved_Room]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Room_Reserved] DROP CONSTRAINT [FK_Room_Reserved_Room];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Dorm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dorm];
GO
IF OBJECT_ID(N'[dbo].[Dorm_Label]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dorm_Label];
GO
IF OBJECT_ID(N'[dbo].[Dorm_Picture]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dorm_Picture];
GO
IF OBJECT_ID(N'[dbo].[Person]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person];
GO
IF OBJECT_ID(N'[dbo].[Room]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Room];
GO
IF OBJECT_ID(N'[dbo].[Room_Reserved]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Room_Reserved];
GO
IF OBJECT_ID(N'[dbo].[Room_Type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Room_Type];
GO
IF OBJECT_ID(N'[dbo].[Table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Table];
GO
IF OBJECT_ID(N'[JongHorDBModelStoreContainer].[Dorm_Option]', 'U') IS NOT NULL
    DROP TABLE [JongHorDBModelStoreContainer].[Dorm_Option];
GO
IF OBJECT_ID(N'[JongHorDBModelStoreContainer].[Dorm_Rate]', 'U') IS NOT NULL
    DROP TABLE [JongHorDBModelStoreContainer].[Dorm_Rate];
GO
IF OBJECT_ID(N'[JongHorDBModelStoreContainer].[Message]', 'U') IS NOT NULL
    DROP TABLE [JongHorDBModelStoreContainer].[Message];
GO
IF OBJECT_ID(N'[JongHorDBModelStoreContainer].[Room_Option]', 'U') IS NOT NULL
    DROP TABLE [JongHorDBModelStoreContainer].[Room_Option];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Dorm'
CREATE TABLE [dbo].[Dorm] (
    [Dorm_ID] int  NOT NULL,
    [Name] nchar(10)  NOT NULL,
    [M_username] varchar(50)  NOT NULL,
    [Lat] varchar(50)  NULL,
    [Long] varchar(50)  NULL,
    [information] varchar(2000)  NULL,
    [Line] varchar(50)  NULL,
    [Facebook] varchar(50)  NULL,
    [Instagram] varchar(50)  NULL,
    [Tel] varchar(50)  NOT NULL,
    [Address] varchar(2000)  NOT NULL,
    [Deposit] varchar(50)  NULL,
    [W_minimum] int  NULL,
    [W_Per_Unit] int  NULL,
    [Internet] varchar(50)  NULL,
    [E_Minimum] int  NULL,
    [E_Per_Unit] int  NULL
);
GO

-- Creating table 'Dorm_Label'
CREATE TABLE [dbo].[Dorm_Label] (
    [Dorm_ID] int  NOT NULL,
    [Label_text] varchar(50)  NOT NULL
);
GO

-- Creating table 'Dorm_Picture'
CREATE TABLE [dbo].[Dorm_Picture] (
    [Dorm_ID] int  NOT NULL,
    [URL_Picture] varchar(200)  NOT NULL
);
GO

-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [Username] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [Room_ID] int  NULL,
    [Name] varchar(50)  NOT NULL,
    [Surname] varchar(50)  NOT NULL,
    [Phone] varchar(50)  NOT NULL,
    [Ssn] varchar(50)  NOT NULL
);
GO

-- Creating table 'Room'
CREATE TABLE [dbo].[Room] (
    [Room_ID] int  NOT NULL,
    [Floor] nchar(10)  NOT NULL,
    [Dorm_ID] int  NOT NULL,
    [Type_ID] int  NOT NULL,
    [Status] varchar(50)  NOT NULL
);
GO

-- Creating table 'Room_Type'
CREATE TABLE [dbo].[Room_Type] (
    [Type_Id] int  NOT NULL,
    [Type_Name] varchar(50)  NOT NULL,
    [Price] int  NOT NULL,
    [Max] int  NOT NULL
);
GO

-- Creating table 'Table'
CREATE TABLE [dbo].[Table] (
    [Id] int  NOT NULL,
    [Username] varchar(50)  NULL,
    [Password] varchar(50)  NULL,
    [Number] nchar(10)  NULL,
    [Floor] nchar(10)  NULL,
    [Name] nchar(10)  NULL,
    [Surname] nchar(10)  NULL,
    [Phone] nchar(10)  NULL
);
GO

-- Creating table 'Dorm_Option'
CREATE TABLE [dbo].[Dorm_Option] (
    [Dorm_ID] int  NOT NULL,
    [Option] varchar(50)  NOT NULL
);
GO

-- Creating table 'Dorm_Rate'
CREATE TABLE [dbo].[Dorm_Rate] (
    [Username] varchar(50)  NOT NULL,
    [Dorm_ID] int  NOT NULL,
    [Score] float  NOT NULL,
    [Text] varchar(200)  NULL
);
GO

-- Creating table 'Message'
CREATE TABLE [dbo].[Message] (
    [Sender_Username] varchar(50)  NOT NULL,
    [Receiver_Username] varchar(50)  NOT NULL,
    [Title] varchar(50)  NOT NULL,
    [Date] varchar(50)  NOT NULL,
    [Text] varchar(1000)  NOT NULL
);
GO

-- Creating table 'Room_Option'
CREATE TABLE [dbo].[Room_Option] (
    [Room_type] int  NOT NULL,
    [Option] varchar(100)  NOT NULL
);
GO

-- Creating table 'Room_Reserved'
CREATE TABLE [dbo].[Room_Reserved] (
    [Username] varchar(50)  NOT NULL,
    [Room_ID] int  NOT NULL,
    [Count] int  NOT NULL,
    [Reserved_ID] nchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Dorm_ID] in table 'Dorm'
ALTER TABLE [dbo].[Dorm]
ADD CONSTRAINT [PK_Dorm]
    PRIMARY KEY CLUSTERED ([Dorm_ID] ASC);
GO

-- Creating primary key on [Dorm_ID] in table 'Dorm_Label'
ALTER TABLE [dbo].[Dorm_Label]
ADD CONSTRAINT [PK_Dorm_Label]
    PRIMARY KEY CLUSTERED ([Dorm_ID] ASC);
GO

-- Creating primary key on [Dorm_ID] in table 'Dorm_Picture'
ALTER TABLE [dbo].[Dorm_Picture]
ADD CONSTRAINT [PK_Dorm_Picture]
    PRIMARY KEY CLUSTERED ([Dorm_ID] ASC);
GO

-- Creating primary key on [Username] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [PK_Person]
    PRIMARY KEY CLUSTERED ([Username] ASC);
GO

-- Creating primary key on [Room_ID] in table 'Room'
ALTER TABLE [dbo].[Room]
ADD CONSTRAINT [PK_Room]
    PRIMARY KEY CLUSTERED ([Room_ID] ASC);
GO

-- Creating primary key on [Type_Id] in table 'Room_Type'
ALTER TABLE [dbo].[Room_Type]
ADD CONSTRAINT [PK_Room_Type]
    PRIMARY KEY CLUSTERED ([Type_Id] ASC);
GO

-- Creating primary key on [Id] in table 'Table'
ALTER TABLE [dbo].[Table]
ADD CONSTRAINT [PK_Table]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Dorm_ID], [Option] in table 'Dorm_Option'
ALTER TABLE [dbo].[Dorm_Option]
ADD CONSTRAINT [PK_Dorm_Option]
    PRIMARY KEY CLUSTERED ([Dorm_ID], [Option] ASC);
GO

-- Creating primary key on [Username], [Dorm_ID], [Score] in table 'Dorm_Rate'
ALTER TABLE [dbo].[Dorm_Rate]
ADD CONSTRAINT [PK_Dorm_Rate]
    PRIMARY KEY CLUSTERED ([Username], [Dorm_ID], [Score] ASC);
GO

-- Creating primary key on [Sender_Username], [Receiver_Username], [Title], [Date], [Text] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [PK_Message]
    PRIMARY KEY CLUSTERED ([Sender_Username], [Receiver_Username], [Title], [Date], [Text] ASC);
GO

-- Creating primary key on [Room_type], [Option] in table 'Room_Option'
ALTER TABLE [dbo].[Room_Option]
ADD CONSTRAINT [PK_Room_Option]
    PRIMARY KEY CLUSTERED ([Room_type], [Option] ASC);
GO

-- Creating primary key on [Username], [Room_ID], [Count], [Reserved_ID] in table 'Room_Reserved'
ALTER TABLE [dbo].[Room_Reserved]
ADD CONSTRAINT [PK_Room_Reserved]
    PRIMARY KEY CLUSTERED ([Username], [Room_ID], [Count], [Reserved_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Dorm_ID] in table 'Dorm_Label'
ALTER TABLE [dbo].[Dorm_Label]
ADD CONSTRAINT [FK_Dorm_Label_Dorm]
    FOREIGN KEY ([Dorm_ID])
    REFERENCES [dbo].[Dorm]
        ([Dorm_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Dorm_ID] in table 'Dorm_Option'
ALTER TABLE [dbo].[Dorm_Option]
ADD CONSTRAINT [FK_Dorm_Option_Dorm]
    FOREIGN KEY ([Dorm_ID])
    REFERENCES [dbo].[Dorm]
        ([Dorm_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [M_username] in table 'Dorm'
ALTER TABLE [dbo].[Dorm]
ADD CONSTRAINT [FK_Dorm_Person]
    FOREIGN KEY ([M_username])
    REFERENCES [dbo].[Person]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Dorm_Person'
CREATE INDEX [IX_FK_Dorm_Person]
ON [dbo].[Dorm]
    ([M_username]);
GO

-- Creating foreign key on [Dorm_ID] in table 'Dorm_Picture'
ALTER TABLE [dbo].[Dorm_Picture]
ADD CONSTRAINT [FK_Dorm_Picture_Dorm]
    FOREIGN KEY ([Dorm_ID])
    REFERENCES [dbo].[Dorm]
        ([Dorm_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Dorm_ID] in table 'Dorm_Rate'
ALTER TABLE [dbo].[Dorm_Rate]
ADD CONSTRAINT [FK_Dorm_Rate_Dorm]
    FOREIGN KEY ([Dorm_ID])
    REFERENCES [dbo].[Dorm]
        ([Dorm_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Dorm_Rate_Dorm'
CREATE INDEX [IX_FK_Dorm_Rate_Dorm]
ON [dbo].[Dorm_Rate]
    ([Dorm_ID]);
GO

-- Creating foreign key on [Username] in table 'Dorm_Rate'
ALTER TABLE [dbo].[Dorm_Rate]
ADD CONSTRAINT [FK_Dorm_Rate_Person]
    FOREIGN KEY ([Username])
    REFERENCES [dbo].[Person]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Sender_Username] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [FK_Message_Person]
    FOREIGN KEY ([Sender_Username])
    REFERENCES [dbo].[Person]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Receiver_Username] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [FK_Message1_Person]
    FOREIGN KEY ([Receiver_Username])
    REFERENCES [dbo].[Person]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Message1_Person'
CREATE INDEX [IX_FK_Message1_Person]
ON [dbo].[Message]
    ([Receiver_Username]);
GO

-- Creating foreign key on [Room_ID] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [FK_Person_Room]
    FOREIGN KEY ([Room_ID])
    REFERENCES [dbo].[Room]
        ([Room_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Person_Room'
CREATE INDEX [IX_FK_Person_Room]
ON [dbo].[Person]
    ([Room_ID]);
GO

-- Creating foreign key on [Username] in table 'Room_Reserved'
ALTER TABLE [dbo].[Room_Reserved]
ADD CONSTRAINT [FK_Room_Reserved_Person]
    FOREIGN KEY ([Username])
    REFERENCES [dbo].[Person]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Type_ID] in table 'Room'
ALTER TABLE [dbo].[Room]
ADD CONSTRAINT [FK_Room_Person]
    FOREIGN KEY ([Type_ID])
    REFERENCES [dbo].[Room_Type]
        ([Type_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Room_Person'
CREATE INDEX [IX_FK_Room_Person]
ON [dbo].[Room]
    ([Type_ID]);
GO

-- Creating foreign key on [Room_ID] in table 'Room_Reserved'
ALTER TABLE [dbo].[Room_Reserved]
ADD CONSTRAINT [FK_Room_Reserved_Room]
    FOREIGN KEY ([Room_ID])
    REFERENCES [dbo].[Room]
        ([Room_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Room_Reserved_Room'
CREATE INDEX [IX_FK_Room_Reserved_Room]
ON [dbo].[Room_Reserved]
    ([Room_ID]);
GO

-- Creating foreign key on [Room_type] in table 'Room_Option'
ALTER TABLE [dbo].[Room_Option]
ADD CONSTRAINT [FK_Room_Option_Room_Type]
    FOREIGN KEY ([Room_type])
    REFERENCES [dbo].[Room_Type]
        ([Type_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------