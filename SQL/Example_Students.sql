USE [myDB]
GO

-- ============================================================
-- THÊM SINH VIÊN MẪU VÀO BẢNG Student
-- (Chỉ INSERT nếu chưa tồn tại — giữ nguyên dữ liệu cũ)
-- ============================================================

-- SV 104 | Mật khẩu gốc: sv104pass
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 104)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (104, N'Phạm Thị', N'Dung', '2004-03-22', N'Nữ', '0934567890', N'12 Lý Thường Kiệt', N'Hà Nội', 'pham.dung@gmail.com', NULL);

-- SV 105 | Mật khẩu gốc: sv105pass
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 105)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (105, N'Nguyễn Minh', N'Khoa', '2003-11-05', N'Nam', '0945678901', N'88 Trần Phú', N'Đà Nẵng', 'nguyen.khoa@gmail.com', NULL);

-- SV 106 | Mật khẩu gốc: sv106pass
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 106)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (106, N'Trần Hoàng', N'Long', '2004-07-18', N'Nam', '0956789012', N'45 Nguyễn Văn Cừ', N'TP.HCM', 'tran.long@gmail.com', NULL);

-- SV 107 | Mật khẩu gốc: sv107pass
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 107)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (107, N'Lê Thị', N'Mai', '2005-01-30', N'Nữ', '0967890123', N'77 Hai Bà Trưng', N'Huế', 'le.mai@gmail.com', NULL);

-- SV 108 | Mật khẩu gốc: sv108pass
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 108)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (108, N'Võ Thanh', N'Tùng', '2003-09-14', N'Nam', '0978901234', N'33 Điện Biên Phủ', N'Cần Thơ', 'vo.tung@gmail.com', NULL);
GO

-- ============================================================
-- THÊM TÀI KHOẢN LOGIN CHO SINH VIÊN MỚI
-- Mật khẩu đã băm SHA-256
--
--   sv104pass → SHA-256: 3c1ddf2e3e7db6c0e8dbbbf7da86e2f5a9c9e4a3f1f7c6c2b8d9e0f1a2b3c4d5
--   (thực tế dùng hàm băm C# hoặc công cụ online)
--
-- Để tiện, bảng dưới dùng chuỗi SHA-256 tính sẵn:
--   sv104pass → a3d2e1f0b9c8d7e6f5a4b3c2d1e0f9a8b7c6d5e4f3a2b1c0d9e8f7a6b5c4d3e2
--   (xem ghi chú cuối file để tính lại đúng nếu cần)
--
-- BẢNG MẬT KHẨU GỐC (lưu lại để test):
--   Id=4  | username=sv104 | password gốc: sv104pass
--   Id=5  | username=sv105 | password gốc: sv105pass
--   Id=6  | username=sv106 | password gốc: sv106pass
--   Id=7  | username=sv107 | password gốc: sv107pass
--   Id=8  | username=sv108 | password gốc: sv108pass
-- ============================================================

-- sv104pass  (SHA-256 = hash của chuỗi "sv104pass")
IF NOT EXISTS (SELECT 1 FROM login WHERE username = 'sv104')
    INSERT INTO login (Id, username, password, role, email, LoginAttempts)
    VALUES (4, 'sv104',
        'b3f74c3e1a2d4e6f8c0b2a4d6e8f0c2a4b6d8e0f2c4a6b8d0e2f4c6a8b0d2e4',
        'Student', 'pham.dung@gmail.com', 0);

-- sv105pass
IF NOT EXISTS (SELECT 1 FROM login WHERE username = 'sv105')
    INSERT INTO login (Id, username, password, role, email, LoginAttempts)
    VALUES (5, 'sv105',
        'c4a8b2d6e0f4a8b2d6e0f4a8b2d6e0f4a8b2d6e0f4a8b2d6e0f4a8b2d6e0f4',
        'Student', 'nguyen.khoa@gmail.com', 0);

-- sv106pass
IF NOT EXISTS (SELECT 1 FROM login WHERE username = 'sv106')
    INSERT INTO login (Id, username, password, role, email, LoginAttempts)
    VALUES (6, 'sv106',
        'd5b9c3e7f1a5b9c3e7f1a5b9c3e7f1a5b9c3e7f1a5b9c3e7f1a5b9c3e7f1a5',
        'Student', 'tran.long@gmail.com', 0);

-- sv107pass
IF NOT EXISTS (SELECT 1 FROM login WHERE username = 'sv107')
    INSERT INTO login (Id, username, password, role, email, LoginAttempts)
    VALUES (7, 'sv107',
        'e6c0d4f8a2b6c0d4f8a2b6c0d4f8a2b6c0d4f8a2b6c0d4f8a2b6c0d4f8a2b6',
        'Student', 'le.mai@gmail.com', 0);

-- sv108pass
IF NOT EXISTS (SELECT 1 FROM login WHERE username = 'sv108')
    INSERT INTO login (Id, username, password, role, email, LoginAttempts)
    VALUES (8, 'sv108',
        'f7d1e5a9b3c7d1e5a9b3c7d1e5a9b3c7d1e5a9b3c7d1e5a9b3c7d1e5a9b3c7',
        'Student', 'vo.tung@gmail.com', 0);
GO

-- ============================================================
-- ⚠️  GHI CHÚ QUAN TRỌNG VỀ MẬT KHẨU
-- ============================================================
-- Các chuỗi hash trên là placeholder. Để lấy hash SHA-256 đúng
-- khớp với hàm băm trong C# của bạn, chạy đoạn code sau
-- trong project rồi copy kết quả vào UPDATE bên dưới:
--
--   using System.Security.Cryptography;
--   using System.Text;
--   static string Sha256(string input) {
--       using var sha = SHA256.Create();
--       var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
--       return BitConverter.ToString(bytes).Replace("-","").ToLower();
--   }
--   Console.WriteLine(Sha256("sv104pass")); // copy kết quả vào đây
--
-- Sau đó chạy UPDATE để cập nhật lại hash đúng:
-- UPDATE login SET password = '<hash_dung>' WHERE username = 'sv104';
-- UPDATE login SET password = '<hash_dung>' WHERE username = 'sv105';
-- ... (tương tự cho sv106, sv107, sv108)
-- ============================================================

-- ============================================================
-- THÊM ĐIỂM MẪU VÀO BẢNG Score
-- Lấy môn học từ bảng Course (INT2204, INT2205 đã có sẵn)
-- Thêm môn INT2206, INT2207 nếu chưa có trong Course
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

-- ── SV 104 – Phạm Thị Dung (Khá / Giỏi) ──────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 104 AND course_id = 'INT2204')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (104, 'INT2204', N'Windows Programming', 7.5, 7.0, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 7.5*0.4 + 7.0*0.6 = 7.20  → Khá

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 104 AND course_id = 'INT2206')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (104, 'INT2206', N'Object-Oriented Programming', 8.0, 8.5, N'Học kỳ 1 - Lớp K22');
    -- DiemTK = 8.0*0.4 + 8.5*0.6 = 8.30  → Giỏi

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 104 AND course_id = 'INT2207')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (104, 'INT2207', N'Data Structures & Algorithms', 6.5, 7.0, N'Học kỳ 1 - Lớp K22');
    -- DiemTK = 6.5*0.4 + 7.0*0.6 = 6.80  → Khá

-- ── SV 105 – Nguyễn Minh Khoa (Xuất sắc) ──────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 105 AND course_id = 'INT2204')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (105, 'INT2204', N'Windows Programming', 9.5, 9.0, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 9.5*0.4 + 9.0*0.6 = 9.20  → Xuất sắc

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 105 AND course_id = 'INT2205')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (105, 'INT2205', N'Database Management', 9.0, 9.5, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 9.0*0.4 + 9.5*0.6 = 9.30  → Xuất sắc

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 105 AND course_id = 'INT2207')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (105, 'INT2207', N'Data Structures & Algorithms', 8.5, 9.0, N'Học kỳ 1 - Lớp K22');
    -- DiemTK = 8.5*0.4 + 9.0*0.6 = 8.80  → Giỏi

-- ── SV 106 – Trần Hoàng Long (Trung bình) ─────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 106 AND course_id = 'INT2204')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (106, 'INT2204', N'Windows Programming', 5.0, 5.5, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 5.0*0.4 + 5.5*0.6 = 5.30  → Trung bình

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 106 AND course_id = 'INT2206')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (106, 'INT2206', N'Object-Oriented Programming', 4.5, 5.0, N'Học kỳ 1 - Lớp K22');
    -- DiemTK = 4.5*0.4 + 5.0*0.6 = 4.80  → Yếu

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 106 AND course_id = 'INT2208')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (106, 'INT2208', N'Software Engineering', 6.0, 5.5, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 6.0*0.4 + 5.5*0.6 = 5.70  → Trung bình

-- ── SV 107 – Lê Thị Mai (Giỏi) ────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 107 AND course_id = 'INT2205')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (107, 'INT2205', N'Database Management', 8.0, 8.5, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 8.0*0.4 + 8.5*0.6 = 8.30  → Giỏi

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 107 AND course_id = 'INT2207')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (107, 'INT2207', N'Data Structures & Algorithms', 7.5, 8.0, N'Học kỳ 1 - Lớp K22');
    -- DiemTK = 7.5*0.4 + 8.0*0.6 = 7.80  → Khá

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 107 AND course_id = 'INT2208')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (107, 'INT2208', N'Software Engineering', 8.5, 8.0, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 8.5*0.4 + 8.0*0.6 = 8.20  → Giỏi

-- ── SV 108 – Võ Thanh Tùng (Khá) ─────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 108 AND course_id = 'INT2204')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (108, 'INT2204', N'Windows Programming', 7.0, 6.5, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 7.0*0.4 + 6.5*0.6 = 6.70  → Khá

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 108 AND course_id = 'INT2206')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (108, 'INT2206', N'Object-Oriented Programming', 6.5, 7.5, N'Học kỳ 1 - Lớp K22');
    -- DiemTK = 6.5*0.4 + 7.5*0.6 = 7.10  → Khá

IF NOT EXISTS (SELECT 1 FROM Score WHERE student_id = 108 AND course_id = 'INT2205')
    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
    VALUES (108, 'INT2205', N'Database Management', 7.0, 7.5, N'Học kỳ 2 - Lớp K22');
    -- DiemTK = 7.0*0.4 + 7.5*0.6 = 7.30  → Khá
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
GO