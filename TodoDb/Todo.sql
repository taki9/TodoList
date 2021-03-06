﻿CREATE TABLE [dbo].[Todo]
(
	[Id] UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [Priority] NVARCHAR(50) NOT NULL, 
    [Responsible] NVARCHAR(50) NULL, 
    [Deadline] DATETIME NULL, 
    [Status] NVARCHAR(50) NULL, 
    [Category] INT NULL, 
    [ParentId] INT NULL
)
