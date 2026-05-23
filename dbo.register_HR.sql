USE [myDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Tự động xóa bảng cũ nếu đã tồn tại để tránh lỗi trùng tên khi bạn bấm chạy lại (Execute)
DROP TABLE IF EXISTS [dbo].[register_HR];
GO

CREATE TABLE [dbo].[register_HR] (
    [Id]       INT            NOT NULL, -- Mã số nhân sự
    [Username] VARCHAR (50)   NOT NULL, -- Tên tài khoản đăng nhập mong muốn
    [password] VARCHAR (64)   NOT NULL, -- BẮT BUỘC ĐỂ 64 KÝ TỰ để chứa trọn vẹn chuỗi mã hóa SHA-256 từ C# 
    [Fname]    NVARCHAR (50)  NOT NULL, -- Họ và tên đệm (Hỗ trợ tiếng Việt có dấu)
    [Lname]    NVARCHAR (50)  NOT NULL, -- Tên (Hỗ trợ tiếng Việt có dấu)
    [Email]    VARCHAR (100)  NOT NULL, -- Địa chỉ Email (Dùng để nhận mã OTP)
    [Picture]  IMAGE          NULL,     -- Ảnh đại diện cá nhân

    -- Thiết lập Id làm Khóa chính (Primary Key) để đảm bảo tính toàn vẹn dữ liệu
    CONSTRAINT [PK_register_HR] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO