USE [myDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Tự động xóa bảng cũ nếu đã tồn tại
-- Xóa Assign trước vì có FK tham chiếu HR
DROP TABLE IF EXISTS [dbo].[Assign];
GO
DROP TABLE IF EXISTS [dbo].[HR];
GO

-- =============================================
-- 1. TẠO BẢNG HR
-- =============================================
CREATE TABLE [dbo].[HR] (
    [MSGV]     NVARCHAR(20)   NOT NULL,
    [Fname]    NVARCHAR(50)   NOT NULL,
    [Lname]    NVARCHAR(50)   NOT NULL,
    [Username] VARCHAR(50)    NOT NULL,
    [Pass]     VARCHAR(100)   NOT NULL,   -- SHA-256, VARCHAR(64) cũng đủ nhưng để 100 cho linh hoạt
    [Email]    VARCHAR(100)   NULL,
    [Pic]      VARBINARY(MAX) NULL,       -- VARBINARY(MAX) thay cho IMAGE (IMAGE đã deprecated)
    [VALID]    BIT            NOT NULL DEFAULT 1,

    CONSTRAINT [PK_HR] PRIMARY KEY CLUSTERED ([MSGV] ASC)
);
GO

-- =============================================
-- 2. TẠO BẢNG ASSIGN (nhiều-nhiều: HR <-> Course)
-- =============================================
CREATE TABLE [dbo].[Assign] (
    [MSGV]  NVARCHAR(20) NOT NULL,
    [MaMH]  CHAR(10)     NOT NULL,

    CONSTRAINT [PK_Assign]        PRIMARY KEY CLUSTERED ([MSGV] ASC, [MaMH] ASC),
    CONSTRAINT [FK_Assign_HR]     FOREIGN KEY ([MSGV]) REFERENCES [dbo].[HR]([MSGV]),
    CONSTRAINT [FK_Assign_Course] FOREIGN KEY ([MaMH]) REFERENCES [dbo].[Course]([MaMH])
);
GO

-- =============================================
-- 3. DỮ LIỆU MẪU BẢNG HR
--    Pass = SHA-256 của "12345" = 5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5
-- =============================================
INSERT INTO [dbo].[HR] ([MSGV], [Fname], [Lname], [Username], [Pass], [Email], [Pic], [VALID])
VALUES
    (N'GV001', N'Nguyễn Văn', N'An',    'gv_nvan',   '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'nguyen.van.an@school.edu.vn',   NULL, 1),
    (N'GV002', N'Trần Thị',   N'Bích',  'gv_ttbich', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'tran.thi.bich@school.edu.vn',  NULL, 1),
    (N'GV003', N'Phạm Minh',  N'Đức',   'gv_pmduc',  '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'pham.minh.duc@school.edu.vn',  NULL, 1),
    (N'GV004', N'Lê Hoàng',   N'Cường', 'gv_lhcuong','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'le.hoang.cuong@school.edu.vn', NULL, 1),
    (N'GV005', N'Võ Thị',     N'Hồng',  'gv_vthong', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'vo.thi.hong@school.edu.vn',    NULL, 1);
GO

-- =============================================
-- 4. THÊM TÀI KHOẢN HR TƯƠNG ỨNG VÀO BẢNG LOGIN
--    Id bắt đầu từ 100 để không đụng Id hiện có (1 = Admin)
--    Pass = SHA-256 của "12345"
-- =============================================
INSERT INTO [dbo].[login] ([Id], [username], [password], [role], [email], [LoginAttempts])
VALUES
    (101, 'gv_nvan',    '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'HR', 'nguyen.van.an@school.edu.vn',   0),
    (102, 'gv_ttbich',  '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'HR', 'tran.thi.bich@school.edu.vn',  0),
    (103, 'gv_pmduc',   '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'HR', 'pham.minh.duc@school.edu.vn',  0),
    (104, 'gv_lhcuong', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'HR', 'le.hoang.cuong@school.edu.vn', 0),
    (105, 'gv_vthong',  '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'HR', 'vo.thi.hong@school.edu.vn',    0);
GO

-- =============================================
-- 5. DỮ LIỆU MẪU BẢNG ASSIGN
--    Phân công thử để test JOIN với Course
--    Các MaMH lấy từ bảng Course đã có sẵn
-- =============================================
INSERT INTO [dbo].[Assign] ([MSGV], [MaMH])
VALUES
    (N'GV001', 'INT2206   '),   -- Nguyễn Văn An -> Object-Oriented Programming
    (N'GV001', 'INT2207   '),   -- Nguyễn Văn An -> Data Structures & Algorithms
    (N'GV002', 'DBMS_2026 '),   -- Trần Thị Bích  -> Database Management System
    (N'GV002', 'INT2208   '),   -- Trần Thị Bích  -> Software Engineering
    (N'GV003', 'WP_2026   '),   -- Phạm Minh Đức  -> Windows Programming
    (N'GV004', 'CAAL_2026 '),   -- Lê Hoàng Cường -> Computer Architecture
    (N'GV005', 'INT2206   '),   -- Võ Thị Hồng    -> Object-Oriented Programming
    (N'GV005', 'INT2207   ');   -- Võ Thị Hồng    -> Data Structures & Algorithms
GO

-- =============================================
-- KIỂM TRA KẾT QUẢ
-- =============================================
-- Xem danh sách HR
SELECT * FROM [dbo].[HR];

-- Xem phân công JOIN để test LoadAssignGrid()
SELECT
    h.MSGV,
    h.Fname + N' ' + h.Lname AS HoTenHR,
    c.MaMH,
    c.TenMH,
    c.SoTC
FROM [dbo].[Assign] a
JOIN [dbo].[HR]     h ON a.MSGV = h.MSGV
JOIN [dbo].[Course] c ON a.MaMH = c.MaMH
ORDER BY h.MSGV, c.MaMH;

-- Đếm số môn mỗi HR đang phụ trách (kiểm tra rule tối đa 5 môn)
SELECT
    h.MSGV,
    h.Fname + N' ' + h.Lname AS HoTenHR,
    COUNT(*) AS SoMonDayHien
FROM [dbo].[Assign] a
JOIN [dbo].[HR] h ON a.MSGV = h.MSGV
GROUP BY h.MSGV, h.Fname, h.Lname
ORDER BY SoMonDayHien DESC;
GO