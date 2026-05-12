USE [myDB]
GO

/****** Object: Table [dbo].[Student] Script Date: 5/11/2026 2:39:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student] (
    [MSSV]    INT            NOT NULL,
    [Fname]   NVARCHAR (50)  NOT NULL,
    [Lname]   NVARCHAR (30)  NOT NULL,
    [Dob]     DATETIME       NULL,
    [Gder]    NVARCHAR (10)  NULL,
    [Phone]   NVARCHAR (15)  NULL,
    [Address] NVARCHAR (200) NULL,
    [Htown]   NVARCHAR (100) NULL,
    [Email]   NVARCHAR (100) NULL,
    [Pture]   IMAGE          NULL
);


