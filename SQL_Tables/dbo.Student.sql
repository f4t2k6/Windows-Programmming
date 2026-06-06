USE [myDB]
GO

/****** Object: Table [dbo].[Student] Script Date: 5/11/2026 2:39:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[Student];
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
GO

-- Thêm Primary Key cho bảng Student (chạy 1 lần)
ALTER TABLE [dbo].[Student]
ADD CONSTRAINT PK_Student PRIMARY KEY (MSSV);
GO

ALTER TABLE [dbo].[Student]
ADD [PrintRequest] NVARCHAR(20) NULL;
GO
 
-- (Tuỳ chọn) Thêm cột lưu thời điểm gửi yêu cầu
ALTER TABLE [dbo].[Student]
ADD [PrintRequestDate] DATETIME NULL;
GO
 
PRINT N'Đã thêm cột PrintRequest và PrintRequestDate vào bảng Student thành công.';
GO


