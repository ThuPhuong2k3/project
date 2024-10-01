Create Database QLBTS;
Use QLBTS;
Go
--Tạo bảng tài khoản
Create Table tblTaiKhoan(
	TaiKhoan Nvarchar(10) primary key,
	MatKhau nvarchar(10) not null
)
Go

--Tạo Bảng Nguyên Liệu---
Create Table tblNguyenLieu(
   MaNguyenLieu nvarchar(10) not null,
   TenNguyenLieu nvarchar(50) not null,
   CONSTRAINT PK_MNL PRIMARY KEY (MaNguyenLieu)
)
Go
--Tạo Bảng Hàng Hoá--
Create Table tblHang(
   MaHang nvarchar(10)  not null,
   TenHang nvarchar(50) not null,
   MaNguyenLieu nvarchar(10) not null FOREIGN KEY(MaNguyenLieu) REFERENCES  tblNguyenLieu(MaNguyenLieu) ON DELETE CASCADE ON UPDATE CASCADE,
   SoLuong int not null,
   DonGiaNhap float not null,
   DonGiaBan float not null,
   GhiChu nvarchar(50) not null,
   CONSTRAINT PK_MH PRIMARY KEY (MaHang)
)
Go
--Tạo Bảng Khách Hàng --
Create Table tblKhach(
  MaKhach nvarchar(10)   not null,
  TenKhach nvarchar(50) not null,
  DiaChi nvarchar(10) not null,
  DienThoai nvarchar(10) not null,
  CONSTRAINT chk_DienThoai CHECK(DienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
  CONSTRAINT PK_MK PRIMARY KEY (MaKhach)
)
Go
--Tạo Bảng Nhân Viên --
Create Table tblNhanVien(
   MaNhanVien nvarchar(10)  not null,
   TenNhanVien nvarchar(50) not null,
   GioiTinh nvarchar(3) not null,
   DiaChi nvarchar(50) not null,
   NgaySinh Datetime not null,
   CONSTRAINT PK_MNV PRIMARY KEY (MaNhanVien)
)
Go
--Tạo Bảng Hoá Đơn Bán--
Create Table tblHDB(
   MaHDB nvarchar(10)  not null,
   MaNhanVien nvarchar(10) not null, FOREIGN KEY(MaNhanVien) REFERENCES  tblNhanVien(MaNhanVien) ON DELETE CASCADE ON UPDATE CASCADE,
   MaKhach nvarchar(10) not null, FOREIGN KEY(MaKhach) REFERENCES  tblKhach(MaKhach) ON DELETE CASCADE ON UPDATE CASCADE,
   NgayBan nvarchar(20) not null,
   TongTien float not null,
   CONSTRAINT PK_MHDB PRIMARY KEY (MaHDB)
)
Go
--Tạo Bảng Chỉ Tiết Hoá Đơn Bán --
Create Table tblCTHDB(
   MaHDB nvarchar(10) not null, FOREIGN KEY(MaHDB) REFERENCES  tblHDB(MaHDB) ON DELETE CASCADE ON UPDATE CASCADE,
   MaHang nvarchar(10) not null, FOREIGN KEY(MaHang) REFERENCES  tblHang(MaHang) ON DELETE CASCADE ON UPDATE CASCADE,
   SoLuong int not null,
   DonGia float not null,
   GiamGia float not null,
   ThanhTien float not null,
   Primary key(MaHDB, MaHang)
)
Go
--Thêm thông tin vào bảng chất liệu--
Insert Into tblNguyenLieu Values
('MNL01',N'TRÂN CHÂU ĐEN'),
('MNL02',N'BỘT SỮA'),
('MNL03',N'CỐC NHỰA'),
('MNL04',N'ỐNG HÚT'),
('MNL05',N'ĐƯỜNG'),
('MNL06',N'TRÀ'),
('MNL07',N'HƯƠNG LIỆU'),
('MNL08',N'MÀU THỰC PHẨM'),
('MNL09',N'KEM TRỨNG'),
('MNL10',N'KEM BASE');

SELECT * FROM tblNguyenLieu

--Thêm thông tin vào bảng hàng hoá
Insert Into tblHang Values
('MH01',N'TRÀ SỮA TRÂN CHÂU ĐƯỜNG ĐEN','MNL01',50,50000,65000,'NULL'),
('MH02',N'TRÀ SỮA BẠC HÀ','MNL02',10,50000,65000,'NULL' ),
('MH03',N'TRÀ SỮA DÂU','MNL03',80,5000,65000,'NULL'),
('MH04',N'TRÀ SỮA SOCOLA','MNL04',50,70000,85000,'NULL'),
('MH05',N'TRÀ SỮA OLONG','MNL05',300,500000,650000,'NULL'),
('MH06',N'TRÀ SỮA TRÀ XANH','MNL06',20,50000,90000,'NULL'),
('MH07',N'TRÀ SỮA KHOAI MÔN','MNL07',10,10000,15000,'NULL'),
('MH08',N'TRÀ SỮA KIWI','MNL08',60,50000,95000,'NULL'),
('MH09',N'TRÀ SỮA HOA NHÀI','MNL09',80,15000,25000,'NULL'),
('MH10',N'TRÀ SỮA KEM BÉO','MNL10',30,3000,5000,'NULL');

SELECT * FROM tblHang

--Thềm thông tin vào bảng nhân viên--
Insert Into tblNhanVien Values 
('NV01',N'ĐỖ TRUNG THÀNH',N'NAM',N'VĨNH PHÚC','03/05/2001'),
('NV02',N'NGUYỄN VĂN NAM',N'NAM',N'HÀ NỘI','01/08/2002'),
('NV03',N'HOÀNG THỊ HẰNG',N'NỮ',N'BẮC NINH','01/08/2004'),
('NV04',N'CHU THỊ HANH',N'NỮ',N'HƯNG YÊN ','01/08/2003'),
('NV05',N'LÊ THỊ PHƯƠNG',N'NỮ',N'HẢI PHÒNG','01/08/1999'),
('NV06',N'CAO VĂN LÂM',N'NAM',N'HÀ NAM','01/08/1995'),
('NV07',N'ĐỖ NHẤT LINH',N'NAM',N'QUẢNG NINH','01/08/1998'),
('NV08',N'LÊ BẢO',N'NAM',N'CAO BẰNG','01/08/1992'),
('NV09',N'ĐỖ THUỲ LINH',N'NỮ',N'SƠN LA','01/08/1990'),
('NV10',N'ĐỖ THỊ NHÂN',N'NỮ',N'LẠNG SƠN','01/08/2000');

SELECT * FROM tblNhanVien

--Thêm thônng tin vào bảng khách hàng--

Insert Into tblKhach Values
('MK01',N'CAO VÂN ANH',N'HÀ NỘI','0389665732'),
('MK02',N'CAO HỮU THÌN',N'HƯNG YÊN','0977787665'),
('MK03',N'LÊ ĐỨC THẮNG',N'HÀ NỘI','0388899999'),
('MK04',N'LÃ QUANG CƯỜNG',N'HÀ NAM','0389777777'),
('MK05',N'ĐỖ TRUNG THỰC',N'VĨNH PHÚC','0944329395'),
('MK06',N'ĐỖ VĂN NAM',N'HÀ NỘI','0328826010'),
('MK07',N'LÊ THẾ ANH',N'NAM ĐỊNH','0398652332'),
('MK08',N'NGUYỄN VĂN LÂM',N'HÀ NỘI','0389666732'),
('MK09',N'CAO HỮU OANH',N'HÀ NỘI','0386547892'),
('MK10',N'CAO BÁ LÂM',N'HÀ NỘI','0389661484');

SELECT * FROM tblKhach

--Thêm thông tin vao bảng hoá đơn bán--
Insert Into tblHDB Values 
('MHDB01','NV01','MK01','01/08/2021',15000000),
('MHDB02','NV02','MK02','17/05/2021',150000000),
('MHDB03','NV03','MK03','18/05/2021',25000000),
('MHDB04','NV04','MK04','19/05/2021',85000000),
('MHDB05','NV05','MK05','20/05/2021',15000000),
('MHDB06','NV06','MK06','21/05/2021',95000000),
('MHDB07','NV07','MK07','22/05/2021',15000000),
('MHDB08','NV08','MK08','23/05/2021',105000000),
('MHDB09','NV09','MK09','24/05/2020',155000000),
('MHDB10','NV10','MK10','25/05/2020',50000000);

SELECT * FROM tblHDB
--Thêm thông tin vào bảng chi tiết hoá đơn bán--
Insert Into tblCTHDB Values
('MHDB01','MH01',5,50000,0,2500000),
('MHDB02','MH02',5,20000,0,1000000),
('MHDB03','MH03',5,50000,0,2500000),
('MHDB04','MH04',5,60000,0,3000000),
('MHDB05','MH05',5,70000,0,3500000),
('MHDB06','MH06',5,80000,0,4000000),
('MHDB07','MH07',5,90000,0,4500000),
('MHDB08','MH08',5,10000,0,50000),
('MHDB09','MH09',5,20000,0,100000),
('MHDB10','MH10',5,50000,0,250000);

SELECT * FROM tblCTHDB

