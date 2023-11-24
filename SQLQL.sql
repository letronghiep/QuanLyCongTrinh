IF EXISTS(SELECT * FROM master.DBO.SYSDATABASES WHERE NAME ='QlyCongTrinh')
	DROP DATABASE QlyCongTrinh
CREATE DATABASE QlyCongTrinh
USE QlyCongTrinh
CREATE TABLE Quyen (
	IdQuyen int IDENTITY NOT NULL, 
	TenQuyen nvarchar(255) NOT NULL, 
	PRIMARY KEY (IdQuyen)
);
	CREATE TABLE TaiKhoan (MaTaiKhoan int IDENTITY NOT NULL, 
	TenTaiKhoan varchar(255) NOT NULL UNIQUE, 
	MatKhau varchar(255) NOT NULL, 
	TenNguoiDung nvarchar(255) NOT NULL, 
	IdQuyen int NOT NULL, 
	PRIMARY KEY (MaTaiKhoan)
);
CREATE TABLE CongTrinh (
	MaCT int IDENTITY NOT NULL, 
	TenCT nvarchar(255) NOT NULL, 
	MaTaiKhoan int NOT NULL, 
	NgayBatDau date NULL, 
	NgayKetThuc date NULL, 
	ChuThau nvarchar(255) NULL, 
	ThoChinh int NULL, 
	ThoPhu int NULL, 
	SoDu money NULL, 
	PRIMARY KEY (MaCT)
);
CREATE TABLE NganSach (
	MaNganSach int IDENTITY NOT NULL, 
	NganSachBD money NOT NULL, 
	MaCT int NOT NULL, 
	TrangThai bit DEFAULT 0 NOT NULL, 
	PRIMARY KEY (MaNganSach, MaCT)
);
CREATE TABLE NhanVien (
	MaNV int IDENTITY NOT NULL, 
	TenNV nvarchar(255) NOT NULL, 
	Luong money NOT NULL, 
	MaVT varchar(255) NOT NULL, 
	PRIMARY KEY (MaNV));
	CREATE TABLE PhanCong (
	MaCT int NOT NULL, 
	MaNV int NOT NULL, 
	NgayThamGia date NULL, 
	NgayKetThuc date NULL, 
	PRIMARY KEY (MaCT, MaNV));

CREATE TABLE TienDo (
	MaCT int IDENTITY NOT NULL, 
	MaTienDo int NOT NULL, 
	TinhTrang tinyint NOT NULL, 
	PRIMARY KEY (MaCT, MaTienDo)
);
CREATE TABLE VatLieu (
	MaVL int IDENTITY NOT NULL, 
	MaCT int NOT NULL, 
	NgayCungCap date NULL, 
	SoLuong int NULL, 
	DonGia money NULL, 
	ThanhTien money NULL, 
	PRIMARY KEY (MaVL, MaCT)
);
CREATE TABLE ViTri (
	MaVT varchar(255) NOT NULL, 
	TenVT nvarchar(255) NOT NULL, 
	PRIMARY KEY (MaVT)
);
ALTER TABLE PhanCong ADD CONSTRAINT FKPhanCong402207 FOREIGN KEY (MaCT) REFERENCES CongTrinh (MaCT);
ALTER TABLE PhanCong ADD CONSTRAINT FKPhanCong114008 FOREIGN KEY (MaNV) REFERENCES NhanVien (MaNV);
ALTER TABLE TienDo ADD CONSTRAINT FKTienDo163949 FOREIGN KEY (MaCT) REFERENCES CongTrinh (MaCT);
ALTER TABLE VatLieu ADD CONSTRAINT FKVatLieu670170 FOREIGN KEY (MaCT) REFERENCES CongTrinh (MaCT);
ALTER TABLE TaiKhoan ADD CONSTRAINT FK_TaiKhoan_Quyen FOREIGN KEY (IdQuyen) REFERENCES Quyen (IdQuyen);
ALTER TABLE NhanVien ADD CONSTRAINT FK_nv_vitri FOREIGN KEY (MaVT) REFERENCES ViTri (MaVT);
ALTER TABLE CongTrinh ADD CONSTRAINT Fk_CongTrinh_Tk FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan (MaTaiKhoan);
ALTER TABLE NganSach ADD CONSTRAINT FK_NganSach_Ct FOREIGN KEY (MaCT) REFERENCES CongTrinh (MaCT);

