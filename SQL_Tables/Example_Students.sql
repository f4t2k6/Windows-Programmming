USE [myDB]
GO

-- ============================================================
-- THÊM SINH VIÊN MẪU VÀO BẢNG Student
-- (Chỉ INSERT nếu chưa tồn tại — giữ nguyên dữ liệu cũ)
-- ============================================================

-- SV 22110045 | Mật khẩu gốc: sv22110045pass 
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 22110045)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (22110045, N'Phạm Thị', N'Dung', '2004-03-22', N'Nữ', '0934567890', N'12 Lý Thường Kiệt', N'Hà Nội', 'pham.dung@gmail.com', NULL);

-- SV 22110078 | Mật khẩu gốc: sv22110078pass
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 22110078)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (22110078, N'Nguyễn Minh', N'Khoa', '2003-11-05', N'Nam', '0945678901', N'88 Trần Phú', N'Đà Nẵng', 'nguyen.khoa@gmail.com', NULL);

-- SV 23110032 | Mật khẩu gốc: sv23110032pass
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 23110032)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (23110032, N'Trần Hoàng', N'Long', '2004-07-18', N'Nam', '0956789012', N'45 Nguyễn Văn Cừ', N'TP.HCM', 'tran.long@gmail.com', NULL);

-- SV 23110156 | Mật khẩu gốc: sv23110156pass
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 23110156)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (23110156, N'Lê Thị', N'Mai', '2005-01-30', N'Nữ', '0967890123', N'77 Hai Bà Trưng', N'Huế', 'le.mai@gmail.com', NULL);

-- SV 24110089 | Mật khẩu gốc: sv24110089pass
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 24110089)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (24110089, N'Võ Thanh', N'Tùng', '2003-09-14', N'Nam', '0978901234', N'33 Điện Biên Phủ', N'Cần Thơ', 'vo.tung@gmail.com', NULL);
GO

-- ============================================================
-- THÊM TÀI KHOẢN LOGIN CHO SINH VIÊN MỚI
-- Mật khẩu đã băm SHA-256 (UTF-8, khớp chuẩn C#)
--
-- BẢNG MẬT KHẨU GỐC (lưu lại để test):
--   username=sv22110045 | password gốc: sv22110045pass
--   username=sv22110078 | password gốc: sv22110078pass
--   username=sv23110032 | password gốc: sv23110032pass
--   username=sv23110156 | password gốc: sv23110156pass
--   username=sv24110089 | password gốc: sv24110089pass
-- ============================================================

IF NOT EXISTS (SELECT 1 FROM login WHERE username = 'sv22110045')
    INSERT INTO login (Id, username, password, role, email, LoginAttempts)
    VALUES (ISNULL((SELECT MAX(Id) FROM login), 0) + 1,
        'sv22110045',
        CONVERT(NVARCHAR(64), HASHBYTES('SHA2_256', 'sv22110045pass'), 2),
        'Student', 'pham.dung@gmail.com', 0);

IF NOT EXISTS (SELECT 1 FROM login WHERE username = 'sv22110078')
    INSERT INTO login (Id, username, password, role, email, LoginAttempts)
    VALUES (ISNULL((SELECT MAX(Id) FROM login), 0) + 1,
        'sv22110078',
        CONVERT(NVARCHAR(64), HASHBYTES('SHA2_256', 'sv22110078pass'), 2),
        'Student', 'nguyen.khoa@gmail.com', 0);

IF NOT EXISTS (SELECT 1 FROM login WHERE username = 'sv23110032')
    INSERT INTO login (Id, username, password, role, email, LoginAttempts)
    VALUES (ISNULL((SELECT MAX(Id) FROM login), 0) + 1,
        'sv23110032',
        CONVERT(NVARCHAR(64), HASHBYTES('SHA2_256', 'sv23110032pass'), 2),
        'Student', 'tran.long@gmail.com', 0);

IF NOT EXISTS (SELECT 1 FROM login WHERE username = 'sv23110156')
    INSERT INTO login (Id, username, password, role, email, LoginAttempts)
    VALUES (ISNULL((SELECT MAX(Id) FROM login), 0) + 1,
        'sv23110156',
        CONVERT(NVARCHAR(64), HASHBYTES('SHA2_256', 'sv23110156pass'), 2),
        'Student', 'le.mai@gmail.com', 0);

IF NOT EXISTS (SELECT 1 FROM login WHERE username = 'sv24110089')
    INSERT INTO login (Id, username, password, role, email, LoginAttempts)
    VALUES (ISNULL((SELECT MAX(Id) FROM login), 0) + 1,
        'sv24110089',
        CONVERT(NVARCHAR(64), HASHBYTES('SHA2_256', 'sv24110089pass'), 2),
        'Student', 'vo.tung@gmail.com', 0);
GO

-- ============================================================
-- THÊM MÔN HỌC MẪU NẾU CHƯA CÓ
-- ============================================================

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'INT2206')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota)
    VALUES ('INT2206', N'Object-Oriented Programming', 3, 15, 1, N'Lập trình hướng đối tượng với C#');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'INT2207')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota)
    VALUES ('INT2207', N'Data Structures & Algorithms', 3, 15, 1, N'Cấu trúc dữ liệu và giải thuật');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'INT2208')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota)
    VALUES ('INT2208', N'Software Engineering', 2, 12, 2, N'Công nghệ phần mềm');
GO

-- ============================================================
-- THÊM ĐIỂM MẪU VÀO BẢNG Score
-- ============================================================

-- ── SV 22110045 – Phạm Thị Dung (Khá / Giỏi) ────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 22110045 AND course_id = 'INT2204')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (22110045, 'INT2204', N'Windows Programming', 7.5, 7.0, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 7.20 → Khá

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 22110045 AND course_id = 'INT2206')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (22110045, 'INT2206', N'Object-Oriented Programming', 8.0, 8.5, N'Học kỳ 1 - Lớp K22');
    -- DiemTK = 8.30 → Giỏi

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 22110045 AND course_id = 'INT2207')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (22110045, 'INT2207', N'Data Structures & Algorithms', 6.5, 7.0, N'Học kỳ 1 - Lớp K22');
    -- DiemTK = 6.80 → Khá

-- ── SV 22110078 – Nguyễn Minh Khoa (Xuất sắc) ───────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 22110078 AND course_id = 'INT2204')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (22110078, 'INT2204', N'Windows Programming', 9.5, 9.0, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 9.20 → Xuất sắc

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 22110078 AND course_id = 'INT2205')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (22110078, 'INT2205', N'Database Management', 9.0, 9.5, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 9.30 → Xuất sắc

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 22110078 AND course_id = 'INT2207')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (22110078, 'INT2207', N'Data Structures & Algorithms', 8.5, 9.0, N'Học kỳ 1 - Lớp K22');
    -- DiemTK = 8.80 → Giỏi

-- ── SV 23110032 – Trần Hoàng Long (Trung bình / Yếu) ─────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 23110032 AND course_id = 'INT2204')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (23110032, 'INT2204', N'Windows Programming', 5.0, 5.5, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 5.30 → Trung bình

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 23110032 AND course_id = 'INT2206')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (23110032, 'INT2206', N'Object-Oriented Programming', 4.5, 5.0, N'Học kỳ 1 - Lớp K22');
    -- DiemTK = 4.80 → Yếu

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 23110032 AND course_id = 'INT2208')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (23110032, 'INT2208', N'Software Engineering', 6.0, 5.5, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 5.70 → Trung bình

-- ── SV 23110156 – Lê Thị Mai (Giỏi) ─────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 23110156 AND course_id = 'INT2205')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (23110156, 'INT2205', N'Database Management', 8.0, 8.5, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 8.30 → Giỏi

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 23110156 AND course_id = 'INT2207')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (23110156, 'INT2207', N'Data Structures & Algorithms', 7.5, 8.0, N'Học kỳ 1 - Lớp K22');
    -- DiemTK = 7.80 → Khá

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 23110156 AND course_id = 'INT2208')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (23110156, 'INT2208', N'Software Engineering', 8.5, 8.0, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 8.20 → Giỏi

-- ── SV 24110089 – Võ Thanh Tùng (Khá) ───────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 24110089 AND course_id = 'INT2204')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (24110089, 'INT2204', N'Windows Programming', 7.0, 6.5, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 6.70 → Khá

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 24110089 AND course_id = 'INT2206')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (24110089, 'INT2206', N'Object-Oriented Programming', 6.5, 7.5, N'Học kỳ 1 - Lớp K22');
    -- DiemTK = 7.10 → Khá

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 24110089 AND course_id = 'INT2205')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (24110089, 'INT2205', N'Database Management', 7.0, 7.5, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 7.30 → Khá
GO

-- ============================================================
-- THÊM LỚP HỌC MẪU VÀO BẢNG Classroom
-- ============================================================

IF NOT EXISTS (SELECT 1 FROM Classroom WHERE MaLop = 'CNTT2201')
    INSERT INTO Classroom (MaLop, TenLop, SiSo, GVCN)
    VALUES ('CNTT2201', N'Công nghệ thông tin K22 - Lớp 1', 35, N'Nguyễn Văn An');

IF NOT EXISTS (SELECT 1 FROM Classroom WHERE MaLop = 'CNTT2202')
    INSERT INTO Classroom (MaLop, TenLop, SiSo, GVCN)
    VALUES ('CNTT2202', N'Công nghệ thông tin K22 - Lớp 2', 33, N'Trần Thị Bích');

IF NOT EXISTS (SELECT 1 FROM Classroom WHERE MaLop = 'KTPM2201')
    INSERT INTO Classroom (MaLop, TenLop, SiSo, GVCN)
    VALUES ('KTPM2201', N'Kỹ thuật phần mềm K22', 38, N'Lê Hoàng Cường');

IF NOT EXISTS (SELECT 1 FROM Classroom WHERE MaLop = 'HTTT2201')
    INSERT INTO Classroom (MaLop, TenLop, SiSo, GVCN)
    VALUES ('HTTT2201', N'Hệ thống thông tin K22', 40, N'Phạm Minh Đức');

IF NOT EXISTS (SELECT 1 FROM Classroom WHERE MaLop = 'ATTT2201')
    INSERT INTO Classroom (MaLop, TenLop, SiSo, GVCN)
    VALUES ('ATTT2201', N'An toàn thông tin K22', 30, N'Võ Thị Hoa');
GO

-- ============================================================
-- KIỂM TRA KẾT QUẢ
-- ============================================================
SELECT s.MSSV, s.Lname + N' ' + s.Fname AS HoTen, s.Gder, s.Email FROM Student s ORDER BY s.MSSV;

SELECT l.Id, l.username, l.role, l.email FROM login l ORDER BY l.Id;

SELECT
    sc.student_id,
    st.Lname + N' ' + st.Fname AS HoTen,
    sc.course_id,
    sc.course_name,
    sc.DiemQT, sc.DiemCK, sc.DiemTK,
    CASE
        WHEN sc.DiemTK >= 9.0 THEN N'Xuất sắc'
        WHEN sc.DiemTK >= 8.0 THEN N'Giỏi'
        WHEN sc.DiemTK >= 6.5 THEN N'Khá'
        WHEN sc.DiemTK >= 5.0 THEN N'Trung bình'
        ELSE N'Yếu'
    END AS XepLoai
FROM Score sc
INNER JOIN Student st ON sc.student_id = st.MSSV
ORDER BY sc.student_id, sc.course_id;

SELECT MaLop, TenLop, SiSo, GVCN FROM Classroom ORDER BY MaLop;
GO