USE [myDB]
GO

-- ============================================================
-- XÓA BẢNG CŨ NẾU TỒN TẠI (chạy lại từ đầu an toàn)
-- ============================================================
IF OBJECT_ID('Score', 'U') IS NOT NULL
    DROP TABLE Score;
GO

-- ============================================================
-- TẠO BẢNG Score (cấu trúc mới: DiemQT + DiemCK + DiemTK)
-- ============================================================
CREATE TABLE Score (
    student_id  INT             NOT NULL,           -- Mã số sinh viên (Khóa ngoại)
    course_id   NVARCHAR(50)    NOT NULL,            -- Mã môn học
    course_name NVARCHAR(100)   NOT NULL,            -- Tên môn học
    DiemQT      FLOAT           NULL,               -- Điểm quá trình  (trọng số 40%)
    DiemCK      FLOAT           NULL,               -- Điểm cuối kỳ    (trọng số 60%)
    DiemTK      AS (ROUND(DiemQT * 0.4 + DiemCK * 0.6, 2)) PERSISTED, -- Tự tính, lưu vật lý
    description NVARCHAR(250)   NULL,               -- Ghi chú (VD: Học kỳ 2 - Lớp K22)

    -- Khóa chính tổ hợp
    CONSTRAINT PK_Score PRIMARY KEY (student_id, course_id),

    -- Khóa ngoại → Student
    CONSTRAINT FK_Score_Student FOREIGN KEY (student_id)
        REFERENCES Student(MSSV),
        -- Không ON DELETE CASCADE: SQL sẽ chặn xóa sinh viên còn điểm

    -- Ràng buộc giá trị hợp lệ
    CONSTRAINT CK_DiemQT CHECK (DiemQT IS NULL OR (DiemQT >= 0 AND DiemQT <= 10)),
    CONSTRAINT CK_DiemCK CHECK (DiemCK IS NULL OR (DiemCK >= 0 AND DiemCK <= 10))
);
GO

-- ============================================================
-- BƯỚC A: Chèn sinh viên mẫu (bỏ qua nếu đã tồn tại)
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 101)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (101, N'Nguyễn Văn', N'A', '2004-05-15', N'Nam', '0901234567', N'123 Nguyễn Trãi', N'Hà Nội', 'svA@gmail.com', NULL);

IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 102)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (102, N'Trần Thị', N'B', '2004-10-20', N'Nữ', '0912345678', N'456 Lê Lợi', N'Đà Nẵng', 'svB@gmail.com', NULL);

IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV = 103)
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES (103, N'Lê Hoàng', N'C', '2005-02-11', N'Nam', '0923456789', N'789 Nguyễn Huệ', N'TP.HCM', 'svC@gmail.com', NULL);
GO

-- ============================================================
-- BƯỚC B: Chèn điểm mẫu (DiemQT + DiemCK, DiemTK tự tính)
-- ============================================================
INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, description)
VALUES
-- SV 101: Windows Programming  → TK = 8.0*0.4 + 8.75*0.6 = 8.45
(101, 'INT2204', N'Windows Programming',  8.0,  8.75, N'Học kỳ 2 - Lớp K22'),

-- SV 101: Database Management  → TK = 9.5*0.4 + 8.75*0.6 = 9.05
(101, 'INT2205', N'Database Management',  9.5,  8.75, N'Học kỳ 2 - Lớp K22'),

-- SV 102: Windows Programming  → TK = 6.0*0.4 + 7.5*0.6  = 6.90
(102, 'INT2204', N'Windows Programming',  6.0,  7.5,  N'Học kỳ 2 - Lớp K22');
GO

-- ============================================================
-- KIỂM TRA KẾT QUẢ
-- ============================================================
SELECT
    s.student_id,
    s.course_id,
    s.course_name,
    s.DiemQT,
    s.DiemCK,
    s.DiemTK,
    CASE
        WHEN s.DiemTK >= 9.0 THEN N'Xuất sắc'
        WHEN s.DiemTK >= 8.0 THEN N'Giỏi'
        WHEN s.DiemTK >= 6.5 THEN N'Khá'
        WHEN s.DiemTK >= 5.0 THEN N'Trung bình'
        ELSE N'Yếu'
    END AS XepLoai,
    s.description
FROM Score s
ORDER BY s.student_id, s.course_id;
GO