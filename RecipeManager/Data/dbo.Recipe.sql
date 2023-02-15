USE [recipemanagerdemodb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Recipe] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (256) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Ingredients] NVARCHAR (MAX) NOT NULL,
    [Directions]  NVARCHAR (MAX) NOT NULL
);


