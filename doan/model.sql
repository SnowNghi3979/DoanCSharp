CREATE TABLE [dbo].[Chatlieu1] (
    [Machatlieu]  VARCHAR (10)  NOT NULL,
    [Tenchatlieu] NVARCHAR (50) NULL
);

GO
CREATE TABLE [dbo].[ChiTietHoaDon] (
    [MaHDBan]   INT NOT NULL,
    [Mahang]    INT NULL,
    [Soluong]   INT NULL,
    [Dongia]    INT NULL,
    [Giamgia]   INT NULL,
    [Thanhtien] INT NULL
);

GO
CREATE TABLE [dbo].[Hang1] (
    [Mahang]     INT           NOT NULL,
    [Tenhang]    NVARCHAR (50) NULL,
    [Machatlieu] NVARCHAR (10) NULL,
    [Soluong]    INT           NULL,
    [Dongianhap] INT           NULL,
    [Dongiaban]  INT           NULL,
    [Anh]        IMAGE         NULL,
    [Ghichu]     NVARCHAR (50) NULL
);

GO
CREATE TABLE [dbo].[HoaDonBan] (
    [MaHDBan]    INT        NOT NULL,
    [Manhanvien] INT        NULL,
    [Ngayban]    DATE       NULL,
    [Makhach]    INT        NULL,
    [Tongtien]   FLOAT (53) NULL
);

GO
CREATE TABLE [dbo].[HoaDonBan1] (
    [MaHDBan]    INT           NULL,
    [Ngayban]    DATETIME      NULL,
    [MaNV]       INT           NULL,
    [TenNV]      NVARCHAR (50) NULL,
    [MaKH]       INT           NULL,
    [TenKH]      NVARCHAR (50) NULL,
    [Diachi]     NVARCHAR (50) NULL,
    [SDT]        NVARCHAR (50) NULL,
    [Mahanghoa]  INT           NULL,
    [Tenhanghoa] NVARCHAR (50) NULL,
    [Dongia]     INT           NULL,
    [Soluong]    INT           NULL,
    [Giamgia]    INT           NULL,
    [Tongtien]   INT           NULL
);

GO
CREATE TABLE [dbo].[Khach2] (
    [Makhach]   INT           NOT NULL,
    [Tenkhach]  NVARCHAR (50) NULL,
    [Diachi]    NVARCHAR (50) NULL,
    [Dienthoai] NVARCHAR (50) NULL
);

GO
CREATE TABLE [dbo].[NguoiDung1] (
    [TenDN]   NVARCHAR (200) NOT NULL,
    [MatKhau] NVARCHAR (200) NOT NULL
);

GO
CREATE TABLE [dbo].[NhanVien] (
    [Manhanvien]  INT           NOT NULL,
    [Tennhanvien] NVARCHAR (50) NULL,
    [Gioitinh]    NVARCHAR (50) NULL,
    [Diachi]      NVARCHAR (50) NULL,
    [Dienthoai]   NVARCHAR (50) NULL,
    [Ngaysinh]    DATE          NULL
);

GO
ALTER TABLE [dbo].[Chatlieu1]
    ADD CONSTRAINT [PK_Chatlieu1] PRIMARY KEY CLUSTERED ([Machatlieu] ASC);

GO
ALTER TABLE [dbo].[ChiTietHoaDon]
    ADD CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED ([MaHDBan] ASC);

GO
ALTER TABLE [dbo].[Hang1]
    ADD CONSTRAINT [PK_Hang1] PRIMARY KEY CLUSTERED ([Mahang] ASC);

GO
ALTER TABLE [dbo].[HoaDonBan]
    ADD CONSTRAINT [PK_HoaDonBan] PRIMARY KEY CLUSTERED ([MaHDBan] ASC);

GO
ALTER TABLE [dbo].[Khach2]
    ADD CONSTRAINT [PK_Khach2] PRIMARY KEY CLUSTERED ([Makhach] ASC);

GO
ALTER TABLE [dbo].[NguoiDung1]
    ADD CONSTRAINT [PK_NguoiDung1] PRIMARY KEY CLUSTERED ([TenDN] ASC);

GO
ALTER TABLE [dbo].[NhanVien]
    ADD CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED ([Manhanvien] ASC);

GO
