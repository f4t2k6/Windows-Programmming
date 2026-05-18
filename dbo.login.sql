USE [myDB]
GO

/****** Object: Table [dbo].[login] Script Date: 5/5/2026 10:08:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[login] (
    [Id]       INT        NOT NULL,
    [username] NCHAR (10) NULL,
    [password] NCHAR (10) NULL
);


