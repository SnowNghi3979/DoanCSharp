USE [QLBanHang]
GO
/****** Object:  Table [dbo].[Chatlieu1]    Script Date: 11/16/2023 8:54:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Chatlieu1](
	[Machatlieu] [varchar](10) NOT NULL,
	[Tenchatlieu] [nvarchar](50) NULL,
 CONSTRAINT [PK_Chatlieu1] PRIMARY KEY CLUSTERED 
(
	[Machatlieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 11/16/2023 8:54:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHDBan] [int] NOT NULL,
	[Mahang] [int] NULL,
	[Soluong] [int] NULL,
	[Dongia] [int] NULL,
	[Giamgia] [int] NULL,
	[Thanhtien] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hang1]    Script Date: 11/16/2023 8:54:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hang1](
	[Mahang] [int] NOT NULL,
	[Tenhang] [nvarchar](50) NULL,
	[Machatlieu] [nvarchar](10) NULL,
	[Soluong] [int] NULL,
	[Dongianhap] [int] NULL,
	[Dongiaban] [int] NULL,
	[Anh] [image] NULL,
	[Ghichu] [nvarchar](50) NULL,
 CONSTRAINT [PK_Hang1] PRIMARY KEY CLUSTERED 
(
	[Mahang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonBan]    Script Date: 11/16/2023 8:54:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBan](
	[MaHDBan] [int] NOT NULL,
	[Manhanvien] [int] NULL,
	[Ngayban] [date] NULL,
	[Makhach] [int] NULL,
	[Tongtien] [float] NULL,
 CONSTRAINT [PK_HoaDonBan] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonBan1]    Script Date: 11/16/2023 8:54:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBan1](
	[MaHDBan] [int] NULL,
	[Ngayban] [datetime] NULL,
	[MaNV] [int] NULL,
	[TenNV] [nvarchar](50) NULL,
	[MaKH] [int] NULL,
	[TenKH] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[Mahanghoa] [int] NULL,
	[Tenhanghoa] [nvarchar](50) NULL,
	[Dongia] [int] NULL,
	[Soluong] [int] NULL,
	[Giamgia] [int] NULL,
	[Tongtien] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Khach2]    Script Date: 11/16/2023 8:54:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khach2](
	[Makhach] [int] NOT NULL,
	[Tenkhach] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Dienthoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Khach2] PRIMARY KEY CLUSTERED 
(
	[Makhach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiDung1]    Script Date: 11/16/2023 8:54:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung1](
	[TenDN] [nvarchar](200) NOT NULL,
	[MatKhau] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_NguoiDung1] PRIMARY KEY CLUSTERED 
(
	[TenDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/16/2023 8:54:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[Manhanvien] [int] NOT NULL,
	[Tennhanvien] [nvarchar](50) NULL,
	[Gioitinh] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Dienthoai] [nvarchar](50) NULL,
	[Ngaysinh] [date] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[Manhanvien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
