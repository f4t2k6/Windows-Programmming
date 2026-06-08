USE [myDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Tự động xóa bảng cũ nếu đã tồn tại để tránh lỗi trùng tên khi bạn bấm chạy lại (Execute)
DROP TABLE IF EXISTS [dbo].[register_student];
GO

CREATE TABLE [dbo].[register_student] (
    [MSSV]    INT            NOT NULL, -- Mã số sinh viên
    [Fname]   NVARCHAR (50)  NOT NULL, -- Họ và tên đệm (Hỗ trợ tiếng Việt có dấu)
    [Lname]   NVARCHAR (30)  NOT NULL, -- Tên (Hỗ trợ tiếng Việt có dấu)
    [Email]   VARCHAR (100)  NOT NULL, -- Địa chỉ Email liên hệ
    [Pture]   IMAGE          NULL,     -- Ảnh đại diện (Được phép trống lúc mới đăng ký)

    -- Thiết lập MSSV va email làm Khóa chính (Primary Key) để phân biệt các sinh viên
    CONSTRAINT [PK_register_student] PRIMARY KEY CLUSTERED ([MSSV], [Email] ASC)
);
GO