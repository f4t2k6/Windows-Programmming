USE [myDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Tự động xóa bảng cũ nếu đã tồn tại để tránh lỗi trùng tên khi bạn bấm chạy lại (Execute)
DROP TABLE IF EXISTS [dbo].[login];
GO

CREATE TABLE [dbo].[login] (
    [Id]            INT           NOT NULL,
    [username]      VARCHAR (50)  NOT NULL, -- Chuyển sang VARCHAR(50) để tài khoản linh hoạt và tối ưu bộ nhớ
    [password]      VARCHAR (64)  NOT NULL, -- BẮT BUỘC ĐỂ 64 KÝ TỰ để chứa trọn vẹn chuỗi mã hóa SHA-256 từ C#
    [role]          VARCHAR (20)  NULL,     -- BỔ SUNG: Lưu vai trò "HR" hoặc "Student" phục vụ phân quyền menu chính
    [email]         VARCHAR (100) NULL,     -- BỔ SUNG: Phục vụ logic kiểm tra trùng email (existEmail) và Quên mật khẩu
    [LoginAttempts] INT           DEFAULT 0 NOT NULL, -- BỔ SUNG: Biến đếm số lần nhập sai mật khẩu để khóa tài khoản
    
    -- Thiết lập Id làm Khóa chính (Primary Key) để đảm bảo tính toàn vẹn dữ liệu
    CONSTRAINT [PK_login] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO