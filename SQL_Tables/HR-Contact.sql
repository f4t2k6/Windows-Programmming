USE [myDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Tuần 12: Quản lý danh bạ theo nhóm
-- Tạo bảng Groups và Contact
-- =============================================

-- Xóa bảng cũ nếu tồn tại (Contact trước vì có FK)
DROP TABLE IF EXISTS [dbo].[Contact];
GO
DROP TABLE IF EXISTS [dbo].[Groups];
GO

-- =============================================
-- 1. TẠO BẢNG GROUPS
--    Mỗi user có nhóm danh bạ riêng
-- =============================================
CREATE TABLE [dbo].[Groups] (
    [ID]     INT           IDENTITY(1,1) NOT NULL,
    [Name]   NVARCHAR(100) NOT NULL,
    [UserID] INT           NOT NULL,

    CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO

-- =============================================
-- 2. TẠO BẢNG CONTACT
--    Lưu thông tin danh bạ cá nhân theo nhóm
-- =============================================
CREATE TABLE [dbo].[Contact] (
    [ID]       INT            IDENTITY(1,1) NOT NULL,
    [Fname]    NVARCHAR(50)   NOT NULL,
    [Lname]    NVARCHAR(50)   NOT NULL,
    [Dob]      DATETIME       NULL,
    [Gender]   NVARCHAR(10)   NULL,
    [Group_ID] INT            NOT NULL,
    [Phone]    NVARCHAR(15)   NULL,
    [Address]  NVARCHAR(200)  NULL,
    [Email]    NVARCHAR(100)  NULL,
    [Pic]      VARBINARY(MAX) NULL,       -- VARBINARY(MAX) thay cho IMAGE (deprecated)
    [UserID]   INT            NOT NULL,

    CONSTRAINT [PK_Contact]       PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Contact_Group] FOREIGN KEY ([Group_ID]) REFERENCES [dbo].[Groups]([ID])
);
GO

-- =============================================
-- 3. DỮ LIỆU MẪU BẢNG GROUPS
--    Tạo nhóm cho 5 HR đã có (login ID 101–105)
--    Mỗi HR có 3 nhóm: Đồng nghiệp, Sinh viên, Cá nhân
-- =============================================
INSERT INTO [dbo].[Groups] ([Name], [UserID])
VALUES
    -- GV001 – Nguyễn Văn An (UserID = 101)
    (N'Đồng nghiệp',  101),
    (N'Sinh viên',    101),
    (N'Cá nhân',      101),

    -- GV002 – Trần Thị Bích (UserID = 102)
    (N'Đồng nghiệp',  102),
    (N'Sinh viên',    102),
    (N'Cá nhân',      102),

    -- GV003 – Phạm Minh Đức (UserID = 103)
    (N'Đồng nghiệp',  103),
    (N'Sinh viên',    103),
    (N'Cá nhân',      103),

    -- GV004 – Lê Hoàng Cường (UserID = 104)
    (N'Đồng nghiệp',  104),
    (N'Sinh viên',    104),
    (N'Cá nhân',      104),

    -- GV005 – Võ Thị Hồng (UserID = 105)
    (N'Đồng nghiệp',  105),
    (N'Sinh viên',    105),
    (N'Cá nhân',      105);
GO

-- =============================================
-- 4. DỮ LIỆU MẪU BẢNG CONTACT
--    Dùng Group_ID theo thứ tự IDENTITY ở trên:
--      101: Đồng nghiệp=1, Sinh viên=2, Cá nhân=3
--      102: Đồng nghiệp=4, Sinh viên=5, Cá nhân=6
--      103: Đồng nghiệp=7, Sinh viên=8, Cá nhân=9
--      104: Đồng nghiệp=10, Sinh viên=11, Cá nhân=12
--      105: Đồng nghiệp=13, Sinh viên=14, Cá nhân=15
-- =============================================
INSERT INTO [dbo].[Contact] ([Fname], [Lname], [Dob], [Gender], [Group_ID], [Phone], [Address], [Email], [Pic], [UserID])
VALUES
    -- ---- Danh bạ của GV001 – Nguyễn Văn An ----
    -- Nhóm Đồng nghiệp (Group_ID = 1)
    (N'Trần Thị',   N'Bích',   '1985-03-22', N'Nữ',  1, '0912345678', N'Q.1, TP.HCM',    'tran.thi.bich@school.edu.vn',   NULL, 101),
    (N'Phạm Minh',  N'Đức',    '1980-07-15', N'Nam', 1, '0987654321', N'Q.3, TP.HCM',    'pham.minh.duc@school.edu.vn',   NULL, 101),
    -- Nhóm Sinh viên (Group_ID = 2)
    (N'Nguyễn Thị', N'Mai',    '2003-09-01', N'Nữ',  2, '0356789012', N'Q.Bình Thạnh',   'mai.nt@student.edu.vn',         NULL, 101),
    (N'Trần Văn',   N'Hùng',   '2003-11-20', N'Nam', 2, '0378901234', N'Q.Gò Vấp',       'hung.tv@student.edu.vn',        NULL, 101),
    (N'Lê Thị',     N'Lan',    '2004-02-14', N'Nữ',  2, '0390123456', N'Q.Phú Nhuận',    'lan.lt@student.edu.vn',         NULL, 101),
    -- Nhóm Cá nhân (Group_ID = 3)
    (N'Nguyễn Văn', N'Bình',   '1978-06-05', N'Nam', 3, '0901122334', N'Q.Tân Bình',     'binh.nv@gmail.com',             NULL, 101),

    -- ---- Danh bạ của GV002 – Trần Thị Bích ----
    -- Nhóm Đồng nghiệp (Group_ID = 4)
    (N'Nguyễn Văn', N'An',     '1982-01-10', N'Nam', 4, '0911223344', N'Q.1, TP.HCM',    'nguyen.van.an@school.edu.vn',   NULL, 102),
    (N'Lê Hoàng',   N'Cường',  '1979-12-25', N'Nam', 4, '0933445566', N'Q.5, TP.HCM',    'le.hoang.cuong@school.edu.vn',  NULL, 102),
    -- Nhóm Sinh viên (Group_ID = 5)
    (N'Phạm Thị',   N'Ngọc',   '2004-04-18', N'Nữ',  5, '0344556677', N'Q.Bình Tân',     'ngoc.pt@student.edu.vn',        NULL, 102),
    (N'Hoàng Văn',  N'Tú',     '2003-08-30', N'Nam', 5, '0366778899', N'Q.Tân Phú',      'tu.hv@student.edu.vn',          NULL, 102),
    -- Nhóm Cá nhân (Group_ID = 6)
    (N'Trần Minh',  N'Châu',   '1990-05-12', N'Nữ',  6, '0977889900', N'Q.Bình Chánh',   'chau.tm@gmail.com',             NULL, 102),

    -- ---- Danh bạ của GV003 – Phạm Minh Đức ----
    -- Nhóm Đồng nghiệp (Group_ID = 7)
    (N'Võ Thị',     N'Hồng',   '1988-09-03', N'Nữ',  7, '0944556677', N'Q.12, TP.HCM',   'vo.thi.hong@school.edu.vn',     NULL, 103),
    -- Nhóm Sinh viên (Group_ID = 8)
    (N'Bùi Thị',    N'Thảo',   '2004-01-25', N'Nữ',  8, '0355667788', N'Q.9, TP.HCM',    'thao.bt@student.edu.vn',        NULL, 103),
    (N'Đặng Văn',   N'Long',   '2003-06-11', N'Nam', 8, '0388990011', N'TP.Thủ Đức',     'long.dv@student.edu.vn',        NULL, 103),
    -- Nhóm Cá nhân (Group_ID = 9)
    (N'Phạm Quốc',  N'Toàn',   '1975-11-08', N'Nam', 9, '0966778899', N'Q.Hóc Môn',      'toan.pq@gmail.com',             NULL, 103),

    -- ---- Danh bạ của GV004 – Lê Hoàng Cường ----
    -- Nhóm Đồng nghiệp (Group_ID = 10)
    (N'Trần Thị',   N'Bích',   '1985-03-22', N'Nữ', 10, '0912345678', N'Q.1, TP.HCM',    'tran.thi.bich@school.edu.vn',   NULL, 104),
    (N'Phạm Minh',  N'Đức',    '1980-07-15', N'Nam',10, '0987654321', N'Q.3, TP.HCM',    'pham.minh.duc@school.edu.vn',   NULL, 104),
    -- Nhóm Sinh viên (Group_ID = 11)
    (N'Ngô Thị',    N'Hà',     '2004-07-07', N'Nữ', 11, '0377889900', N'Q.4, TP.HCM',    'ha.nt@student.edu.vn',          NULL, 104),
    -- Nhóm Cá nhân (Group_ID = 12)
    (N'Lê Văn',     N'Phúc',   '1983-02-20', N'Nam',12, '0955667788', N'Q.Nhà Bè',       'phuc.lv@gmail.com',             NULL, 104),

    -- ---- Danh bạ của GV005 – Võ Thị Hồng ----
    -- Nhóm Đồng nghiệp (Group_ID = 13)
    (N'Nguyễn Văn', N'An',     '1982-01-10', N'Nam',13, '0911223344', N'Q.1, TP.HCM',    'nguyen.van.an@school.edu.vn',   NULL, 105),
    -- Nhóm Sinh viên (Group_ID = 14)
    (N'Trương Thị', N'Kim',    '2003-10-05', N'Nữ', 14, '0399001122', N'Q.Củ Chi',       'kim.tt@student.edu.vn',         NULL, 105),
    (N'Vũ Minh',    N'Khoa',   '2004-03-15', N'Nam',14, '0311223344', N'Q.Cần Giờ',      'khoa.vm@student.edu.vn',        NULL, 105),
    -- Nhóm Cá nhân (Group_ID = 15)
    (N'Võ Thanh',   N'Tùng',   '1992-08-28', N'Nam',15, '0988001122', N'Q.Bình Chánh',   'tung.vt@gmail.com',             NULL, 105);
GO

-- =============================================
-- 5. KIỂM TRA KẾT QUẢ
-- =============================================

-- Xem tất cả nhóm kèm tên chủ sở hữu (JOIN với login)
SELECT
    g.ID,
    g.Name AS TenNhom,
    g.UserID,
    l.username AS TenDangNhap
FROM [dbo].[Groups] g
JOIN [dbo].[login]  l ON g.UserID = l.Id
ORDER BY g.UserID, g.ID;

-- Xem danh bạ của GV001 (UserID = 101), lọc theo từng nhóm
SELECT
    c.ID,
    c.Fname + N' ' + c.Lname AS HoTen,
    c.Phone,
    c.Email,
    c.Gender,
    c.Dob,
    g.Name AS TenNhom
FROM [dbo].[Contact] c
JOIN [dbo].[Groups]  g ON c.Group_ID = g.ID
WHERE c.UserID = 101
ORDER BY g.ID, c.Lname;

-- Đếm số contact theo nhóm của mỗi user
SELECT
    g.UserID,
    l.username     AS TenDangNhap,
    g.Name         AS TenNhom,
    COUNT(c.ID)    AS SoLienHe
FROM [dbo].[Groups]  g
JOIN [dbo].[login]   l ON g.UserID = l.Id
LEFT JOIN [dbo].[Contact] c ON c.Group_ID = g.ID AND c.UserID = g.UserID
GROUP BY g.UserID, l.username, g.ID, g.Name
ORDER BY g.UserID, g.ID;
GO

-- =============================================
-- Thêm nhóm cho UserID = 24110118
-- =============================================
INSERT INTO [dbo].[Groups] ([Name], [UserID])
VALUES
    (N'Đồng nghiệp', 24110118),
    (N'Sinh viên',   24110118),
    (N'Cá nhân',     24110118);
GO

-- Lấy ID của 3 nhóm vừa tạo
DECLARE @g1 INT, @g2 INT, @g3 INT;
SELECT @g1 = MIN(ID) FROM [dbo].[Groups] WHERE UserID = 24110118 AND Name = N'Đồng nghiệp';
SELECT @g2 = MIN(ID) FROM [dbo].[Groups] WHERE UserID = 24110118 AND Name = N'Sinh viên';
SELECT @g3 = MIN(ID) FROM [dbo].[Groups] WHERE UserID = 24110118 AND Name = N'Cá nhân';

-- =============================================
-- Thêm contact mẫu cho UserID = 24110118
-- =============================================
INSERT INTO [dbo].[Contact] ([Fname],[Lname],[Dob],[Gender],[Group_ID],[Phone],[Address],[Email],[Pic],[UserID])
VALUES
    -- Nhóm Đồng nghiệp
    (N'Nguyễn Văn', N'An',   '1982-01-10', N'Nam', @g1, '0911223344', N'Q.1, TP.HCM',  'an.nv@school.edu.vn',   NULL, 24110118),
    (N'Trần Thị',   N'Bích', '1985-03-22', N'Nữ',  @g1, '0912345678', N'Q.3, TP.HCM',  'bich.tt@school.edu.vn', NULL, 24110118),
    -- Nhóm Sinh viên
    (N'Lê Thị',     N'Mai',  '2003-09-01', N'Nữ',  @g2, '0356789012', N'Q.Bình Thạnh', 'mai.lt@student.edu.vn', NULL, 24110118),
    (N'Phạm Văn',   N'Hùng', '2003-11-20', N'Nam', @g2, '0378901234', N'Q.Gò Vấp',     'hung.pv@student.edu.vn',NULL, 24110118),
    -- Nhóm Cá nhân
    (N'Võ Thanh',   N'Tùng', '1992-08-28', N'Nam', @g3, '0988001122', N'Q.Bình Chánh', 'tung.vt@gmail.com',     NULL, 24110118);
GO

-- Kiểm tra lại
SELECT c.Fname + N' ' + c.Lname AS HoTen, c.Phone, g.Name AS Nhom
FROM [dbo].[Contact] c
JOIN [dbo].[Groups] g ON c.Group_ID = g.ID
WHERE c.UserID = 24110118;
GO

-- =============================================
-- 6. STORED PROCEDURE: usp_SeedDefaultGroups
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

-- Chạy ngay để seed cho tất cả user hiện tại (ví dụ: Admin, các học viên khác)
EXEC [dbo].[usp_SeedDefaultGroups];
GO

-- =============================================
-- Thêm nhóm cho tài khoản lehuyphat_hr (UserID = 123)
-- =============================================
INSERT INTO [dbo].[Groups] ([Name], [UserID])
VALUES
    (N'Đồng nghiệp', 123),
    (N'Sinh viên',   123),
    (N'Cá nhân',     123);
GO

-- Lấy ID các nhóm vừa tạo
DECLARE @g1 INT, @g2 INT, @g3 INT;

SELECT @g1 = MIN(ID)
FROM [dbo].[Groups]
WHERE UserID = 123 AND Name = N'Đồng nghiệp';

SELECT @g2 = MIN(ID)
FROM [dbo].[Groups]
WHERE UserID = 123 AND Name = N'Sinh viên';

SELECT @g3 = MIN(ID)
FROM [dbo].[Groups]
WHERE UserID = 123 AND Name = N'Cá nhân';

-- =============================================
-- Thêm danh bạ mẫu cho lehuyphat_hr
-- =============================================
INSERT INTO [dbo].[Contact]
(
    [Fname],[Lname],[Dob],[Gender],
    [Group_ID],[Phone],[Address],[Email],[Pic],[UserID]
)
VALUES
    -- Đồng nghiệp
    (N'Nguyễn Văn', N'An',
     '1982-01-10', N'Nam',
     @g1, '0911223344',
     N'Quận 1, TP.HCM',
     'an.nv@school.edu.vn',
     NULL, 123),

    (N'Trần Thị', N'Bích',
     '1985-03-22', N'Nữ',
     @g1, '0912345678',
     N'Quận 3, TP.HCM',
     'bich.tt@school.edu.vn',
     NULL, 123),

    -- Sinh viên
    (N'Lê Thị', N'Mai',
     '2003-09-01', N'Nữ',
     @g2, '0356789012',
     N'Bình Thạnh, TP.HCM',
     'mai.lt@student.edu.vn',
     NULL, 123),

    (N'Phạm Văn', N'Hùng',
     '2003-11-20', N'Nam',
     @g2, '0378901234',
     N'Gò Vấp, TP.HCM',
     'hung.pv@student.edu.vn',
     NULL, 123),

    (N'Nguyễn Thị', N'Lan',
     '2004-05-15', N'Nữ',
     @g2, '0390123456',
     N'Thủ Đức, TP.HCM',
     'lan.nt@student.edu.vn',
     NULL, 123),

    -- Cá nhân
    (N'Võ Thanh', N'Tùng',
     '1992-08-28', N'Nam',
     @g3, '0988001122',
     N'Bình Chánh, TP.HCM',
     'tung.vt@gmail.com',
     NULL, 123),

    (N'Nguyễn Minh', N'Khang',
     '1995-12-05', N'Nam',
     @g3, '0966554433',
     N'Tân Bình, TP.HCM',
     'khang.nm@gmail.com',
     NULL, 123);
GO

-- Kiểm tra kết quả
SELECT
    c.Fname + N' ' + c.Lname AS HoTen,
    c.Phone,
    c.Email,
    g.Name AS TenNhom
FROM [dbo].[Contact] c
JOIN [dbo].[Groups] g ON c.Group_ID = g.ID
WHERE c.UserID = 123
ORDER BY g.ID;

-- =============================================
-- Thêm nhóm cho Admin (UserID = 1)
-- =============================================
INSERT INTO [dbo].[Groups] ([Name], [UserID])
VALUES
    (N'Đồng nghiệp', 1),
    (N'Sinh viên',   1),
    (N'Cá nhân',     1);
GO

DECLARE @a1 INT, @a2 INT, @a3 INT;
SELECT @a1 = MIN(ID) FROM [dbo].[Groups] WHERE UserID = 1 AND Name = N'Đồng nghiệp';
SELECT @a2 = MIN(ID) FROM [dbo].[Groups] WHERE UserID = 1 AND Name = N'Sinh viên';
SELECT @a3 = MIN(ID) FROM [dbo].[Groups] WHERE UserID = 1 AND Name = N'Cá nhân';

INSERT INTO [dbo].[Contact] ([Fname],[Lname],[Dob],[Gender],[Group_ID],[Phone],[Address],[Email],[Pic],[UserID])
VALUES
    -- Đồng nghiệp
    (N'Nguyễn Văn', N'An',     '1982-01-10', N'Nam', @a1, '0911223344', N'Quận 1, TP.HCM',      'an.nv@school.edu.vn',       NULL, 1),
    (N'Trần Thị',   N'Bích',   '1985-03-22', N'Nữ',  @a1, '0912345678', N'Quận 3, TP.HCM',      'bich.tt@school.edu.vn',     NULL, 1),
    (N'Phạm Minh',  N'Đức',    '1980-07-15', N'Nam', @a1, '0987654321', N'Quận 3, TP.HCM',      'duc.pm@school.edu.vn',      NULL, 1),
    (N'Lê Hoàng',   N'Cường',  '1979-12-25', N'Nam', @a1, '0933445566', N'Quận 5, TP.HCM',      'cuong.lh@school.edu.vn',    NULL, 1),
    (N'Võ Thị',     N'Hồng',   '1988-09-03', N'Nữ',  @a1, '0944556677', N'Quận 12, TP.HCM',     'hong.vt@school.edu.vn',     NULL, 1),
    -- Sinh viên
    (N'Nguyễn Thị', N'Mai',    '2003-09-01', N'Nữ',  @a2, '0356789012', N'Bình Thạnh, TP.HCM',  'mai.nt@student.edu.vn',     NULL, 1),
    (N'Trần Văn',   N'Hùng',   '2003-11-20', N'Nam', @a2, '0378901234', N'Gò Vấp, TP.HCM',      'hung.tv@student.edu.vn',    NULL, 1),
    (N'Lê Thị',     N'Lan',    '2004-02-14', N'Nữ',  @a2, '0390123456', N'Phú Nhuận, TP.HCM',   'lan.lt@student.edu.vn',     NULL, 1),
    (N'Phạm Thị',   N'Ngọc',   '2004-04-18', N'Nữ',  @a2, '0344556677', N'Bình Tân, TP.HCM',    'ngoc.pt@student.edu.vn',    NULL, 1),
    (N'Hoàng Văn',  N'Tú',     '2003-08-30', N'Nam', @a2, '0366778899', N'Tân Phú, TP.HCM',     'tu.hv@student.edu.vn',      NULL, 1),
    -- Cá nhân
    (N'Nguyễn Văn', N'Bình',   '1978-06-05', N'Nam', @a3, '0901122334', N'Tân Bình, TP.HCM',    'binh.nv@gmail.com',         NULL, 1),
    (N'Trần Minh',  N'Châu',   '1990-05-12', N'Nữ',  @a3, '0977889900', N'Bình Chánh, TP.HCM',  'chau.tm@gmail.com',         NULL, 1),
    (N'Lê Văn',     N'Phúc',   '1983-02-20', N'Nam', @a3, '0955667788', N'Nhà Bè, TP.HCM',      'phuc.lv@gmail.com',         NULL, 1);
GO

-- Kiểm tra
SELECT c.Fname + N' ' + c.Lname AS HoTen, c.Phone, c.Email, g.Name AS TenNhom
FROM [dbo].[Contact] c
JOIN [dbo].[Groups] g ON c.Group_ID = g.ID
WHERE c.UserID = 1
ORDER BY g.ID;
GO

-- =============================================
-- Thêm nhóm cho lengochai_student (UserID = 24110089)
-- =============================================
INSERT INTO [dbo].[Groups] ([Name], [UserID])
VALUES
    (N'Bạn bè',      24110089),
    (N'Gia đình',    24110089),
    (N'Giảng viên',  24110089);
GO

DECLARE @s1 INT, @s2 INT, @s3 INT;
SELECT @s1 = MIN(ID) FROM [dbo].[Groups] WHERE UserID = 24110089 AND Name = N'Bạn bè';
SELECT @s2 = MIN(ID) FROM [dbo].[Groups] WHERE UserID = 24110089 AND Name = N'Gia đình';
SELECT @s3 = MIN(ID) FROM [dbo].[Groups] WHERE UserID = 24110089 AND Name = N'Giảng viên';

INSERT INTO [dbo].[Contact] ([Fname],[Lname],[Dob],[Gender],[Group_ID],[Phone],[Address],[Email],[Pic],[UserID])
VALUES
    -- Bạn bè
    (N'Trần Văn',    N'Hùng',   '2003-11-20', N'Nam', @s1, '0378901234', N'Gò Vấp, TP.HCM',      'hung.tv@student.edu.vn',    NULL, 24110089),
    (N'Phạm Thị',    N'Ngọc',   '2004-04-18', N'Nữ',  @s1, '0344556677', N'Bình Tân, TP.HCM',    'ngoc.pt@student.edu.vn',    NULL, 24110089),
    (N'Hoàng Văn',   N'Tú',     '2003-08-30', N'Nam', @s1, '0366778899', N'Tân Phú, TP.HCM',     'tu.hv@student.edu.vn',      NULL, 24110089),
    (N'Bùi Thị',     N'Thảo',   '2004-01-25', N'Nữ',  @s1, '0355667788', N'Quận 9, TP.HCM',      'thao.bt@student.edu.vn',    NULL, 24110089),
    (N'Đặng Văn',    N'Long',   '2003-06-11', N'Nam', @s1, '0388990011', N'Thủ Đức, TP.HCM',     'long.dv@student.edu.vn',    NULL, 24110089),
    -- Gia đình
    (N'Lê Văn',      N'Hải',    '1972-04-20', N'Nam', @s2, '0909112233', N'Quận 10, TP.HCM',     'hai.lv@gmail.com',          NULL, 24110089),
    (N'Nguyễn Thị',  N'Phương', '1975-08-15', N'Nữ',  @s2, '0918223344', N'Quận 10, TP.HCM',     'phuong.nt@gmail.com',       NULL, 24110089),
    (N'Lê Thị',      N'Hoa',    '2000-03-10', N'Nữ',  @s2, '0332445566', N'Quận 10, TP.HCM',     'hoa.lt@gmail.com',          NULL, 24110089),
    -- Giảng viên
    (N'Nguyễn Văn',  N'An',     '1982-01-10', N'Nam', @s3, '0911223344', N'Quận 1, TP.HCM',      'an.nv@school.edu.vn',       NULL, 24110089),
    (N'Trần Thị',    N'Bích',   '1985-03-22', N'Nữ',  @s3, '0912345678', N'Quận 3, TP.HCM',      'bich.tt@school.edu.vn',     NULL, 24110089),
    (N'Lê Hoàng',    N'Cường',  '1979-12-25', N'Nam', @s3, '0933445566', N'Quận 5, TP.HCM',      'cuong.lh@school.edu.vn',    NULL, 24110089),
    (N'Võ Thị',      N'Hồng',   '1988-09-03', N'Nữ',  @s3, '0944556677', N'Quận 12, TP.HCM',     'hong.vt@school.edu.vn',     NULL, 24110089);
GO

-- Kiểm tra
SELECT c.Fname + N' ' + c.Lname AS HoTen, c.Phone, c.Email, g.Name AS TenNhom
FROM [dbo].[Contact] c
JOIN [dbo].[Groups] g ON c.Group_ID = g.ID
WHERE c.UserID = 24110089
ORDER BY g.ID;
GO