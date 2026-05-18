-- 1. Tạo bảng Score (Bảng Điểm)
CREATE TABLE Score (
    student_id INT NOT NULL,            -- Mã số sinh viên (Khóa ngoại)
    course_id NVARCHAR(50) NOT NULL,    -- Mã môn học
    course_name NVARCHAR(100) NOT NULL,  -- Tên môn học
    score FLOAT NOT NULL,               -- Điểm số (0.0 đến 10.0)
    description NVARCHAR(250),          -- Ghi chú (ví dụ: Học kỳ 1)
    
    -- Định nghĩa khóa chính tổ hợp
    CONSTRAINT PK_Score PRIMARY KEY (student_id, course_id),
    
    -- Định nghĩa khóa ngoại liên kết tới bảng Student của bạn
    CONSTRAINT FK_Score_Student FOREIGN KEY (student_id) 
        REFERENCES Student(MSSV)
        -- Lưu ý: Không dùng ON DELETE CASCADE ở đây để hệ thống SQL ngăn chặn hành vi xóa 
        -- sinh viên từ gốc nếu đang tồn tại bản ghi điểm của sinh viên đó.
);
GO

-- BƯỚC A: Chèn các sinh viên mẫu vào bảng Student trước (Nếu DB của bạn chưa có)
-- Chèn theo đúng thứ tự cột: MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture
INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
VALUES 
(101, N'Nguyễn Văn', N'A', '2004-05-15', N'Nam', '0901234567', N'123 Nguyễn Trãi', N'Hà Nội', 'svA@gmail.com', NULL),
(102, N'Trần Thị', N'B', '2004-10-20', N'Nữ', '0912345678', N'456 Lê Lợi', N'Đà Nẵng', 'svB@gmail.com', NULL),
(103, N'Lê Hoàng', N'C', '2005-02-11', N'Nam', '0923456789', N'789 Nguyễn Huệ', N'TP.HCM', 'svC@gmail.com', NULL);
GO

-- BƯỚC B: Chèn điểm mẫu vào bảng Score
INSERT INTO Score (student_id, course_id, course_name, score, description)
VALUES 
(101, 'INT2204', N'Windows Programming', 8.5, N'Học kỳ 2 - Lớp K22'),
(101, 'INT2205', N'Database Management', 9.0, N'Học kỳ 2 - Lớp K22'),
(102, 'INT2204', N'Windows Programming', 7.0, N'Học kỳ 2 - Lớp K22');
GO