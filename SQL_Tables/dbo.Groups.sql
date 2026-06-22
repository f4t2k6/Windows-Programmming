USE [myDB]
GO

/****** Object: Table [dbo].[Groups] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Xóa bảng cũ nếu tồn tại
-- (Phải xóa Contact trước vì Contact có FK tham chiếu Groups)
DROP TABLE IF EXISTS [dbo].[Contact];
GO
DROP TABLE IF EXISTS [dbo].[Groups];
GO

-- =============================================
-- 1. TẠO BẢNG GROUPS
--    Mỗi user (HR) có tập nhóm danh bạ riêng
-- =============================================
CREATE TABLE [dbo].[Groups] (
    [ID]     INT           IDENTITY(1,1) NOT NULL,
    [Name]   NVARCHAR(100) NOT NULL,
    [UserID] INT           NOT NULL,

    CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO

-- =============================================
-- 2. DỮ LIỆU MẪU – 3 nhóm mặc định cho mỗi HR
--    UserID 101-105 tương ứng login các HR đã có
-- =============================================
INSERT INTO [dbo].[Groups] ([Name], [UserID])
VALUES
    -- GV001 – Nguyễn Văn An (UserID = 101)
    (N'Đồng nghiệp', 101),
    (N'Sinh viên',   101),
    (N'Cá nhân',     101),

    -- GV002 – Trần Thị Bích (UserID = 102)
    (N'Đồng nghiệp', 102),
    (N'Sinh viên',   102),
    (N'Cá nhân',     102),

    -- GV003 – Phạm Minh Đức (UserID = 103)
    (N'Đồng nghiệp', 103),
    (N'Sinh viên',   103),
    (N'Cá nhân',     103),

    -- GV004 – Lê Hoàng Cường (UserID = 104)
    (N'Đồng nghiệp', 104),
    (N'Sinh viên',   104),
    (N'Cá nhân',     104),

    -- GV005 – Võ Thị Hồng (UserID = 105)
    (N'Đồng nghiệp', 105),
    (N'Sinh viên',   105),
    (N'Cá nhân',     105);
GO

-- =============================================
-- 3. STORED PROCEDURE: usp_SeedDefaultGroups
--    Tự động tạo 3 nhóm mặc định cho bất kỳ
--    user nào trong bảng login chưa có nhóm nào.
--    Idempotent – gọi lại nhiều lần không bị lỗi.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[usp_SeedDefaultGroups]
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Groups] ([Name], [UserID])
    SELECT nhom.[Name], l.[Id]
    FROM [dbo].[login] l
    CROSS JOIN (
        VALUES (N'Đồng nghiệp'), (N'Sinh viên'), (N'Cá nhân')
    ) AS nhom([Name])
    WHERE NOT EXISTS (
        SELECT 1 FROM [dbo].[Groups] g
        WHERE g.[UserID] = l.[Id]
    );

    PRINT N'Đã seed nhóm mặc định cho các user chưa có nhóm.';
END
GO

-- Chạy ngay để seed cho tất cả user hiện tại
EXEC [dbo].[usp_SeedDefaultGroups];
GO

-- =============================================
-- 4. KIỂM TRA KẾT QUẢ
-- =============================================
SELECT
    g.[ID],
    g.[Name]   AS TenNhom,
    g.[UserID],
    l.[username] AS TenDangNhap
FROM [dbo].[Groups] g
JOIN [dbo].[login]  l ON g.[UserID] = l.[Id]
ORDER BY g.[UserID], g.[ID];
GO
