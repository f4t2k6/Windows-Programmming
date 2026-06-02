CREATE TABLE DKMH (
    MSSV INT, -- Thay đổi từ NVARCHAR(20) thành INT để khớp với bảng Student
    MaMH CHAR(10), -- Thay đổi từ NVARCHAR(10) thành CHAR(10) để khớp với Course
    PRIMARY KEY (MSSV, MaMH),
    FOREIGN KEY (MSSV) REFERENCES Student(MSSV),
    FOREIGN KEY (MaMH) REFERENCES Course(MaMH)
);