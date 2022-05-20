USE [master]
GO
/****** Object:  Database [Lipstick2]    Script Date: 20-May-22 2:55:06 PM ******/
CREATE DATABASE [Lipstick2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Lipstick2', FILENAME = N'C:\Software\Microsoft SQL Sever 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\Lipstick2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Lipstick2_log', FILENAME = N'C:\Software\Microsoft SQL Sever 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\Lipstick2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Lipstick2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Lipstick2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Lipstick2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Lipstick2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Lipstick2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Lipstick2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Lipstick2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Lipstick2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Lipstick2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Lipstick2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Lipstick2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Lipstick2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Lipstick2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Lipstick2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Lipstick2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Lipstick2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Lipstick2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Lipstick2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Lipstick2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Lipstick2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Lipstick2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Lipstick2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Lipstick2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Lipstick2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Lipstick2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Lipstick2] SET  MULTI_USER 
GO
ALTER DATABASE [Lipstick2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Lipstick2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Lipstick2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Lipstick2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Lipstick2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Lipstick2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Lipstick2] SET QUERY_STORE = OFF
GO
USE [Lipstick2]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 20-May-22 2:55:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[Images] [nvarchar](50) NULL,
	[Gia] [decimal](18, 0) NULL,
	[MauSacSP] [nvarchar](50) NULL,
	[KichCoSP] [nvarchar](50) NULL,
	[IDHoaDon] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Soluong] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietSanPham]    Script Date: 20-May-22 2:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietSanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDSanPham] [int] NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[IDLoaiSanPham] [int] NULL,
	[Images] [nvarchar](50) NULL,
	[Gia] [decimal](18, 0) NULL,
	[Mota] [nvarchar](50) NULL,
	[MauSacSP] [nvarchar](50) NULL,
	[KichCoSP] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[LuotXem] [int] NULL,
 CONSTRAINT [PK_ChiTietSanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGia]    Script Date: 20-May-22 2:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[ID] [nchar](10) NULL,
	[IDSanPham] [int] NULL,
	[Rating] [int] NULL,
	[NoiDung] [nvarchar](max) NULL,
	[Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 20-May-22 2:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[IDHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [int] NULL,
	[Gia] [decimal](18, 0) NULL,
	[UserName] [nvarchar](50) NULL,
	[NgayGio] [datetime] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KichCo]    Script Date: 20-May-22 2:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KichCo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KichCoSP] [nvarchar](50) NULL,
 CONSTRAINT [PK_KichCo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LienHe]    Script Date: 20-May-22 2:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LienHe](
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Mess] [nvarchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_LienHe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 20-May-22 2:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[IDLoaiSanPham] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NULL,
	[Alias] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[IDLoaiSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MauSac]    Script Date: 20-May-22 2:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MauSac](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MauSacSP] [nvarchar](50) NULL,
 CONSTRAINT [PK_MauSac] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 20-May-22 2:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[UserName] [nvarchar](50) NULL,
	[PassWord] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [int] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Image] [nvarchar](50) NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 20-May-22 2:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[IDSanPham] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[IDLoaiSanPham] [int] NULL,
	[Images] [nvarchar](50) NULL,
	[Gia] [decimal](18, 0) NULL,
	[Mota] [nvarchar](50) NULL,
	[Rating] [int] NULL,
	[GiaNhap] [decimal](18, 0) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[IDSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongKe]    Script Date: 20-May-22 2:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongKe](
	[Nam] [int] NULL,
	[Tong] [decimal](18, 0) NULL,
	[Thang] [int] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ThongKe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinTuc]    Script Date: 20-May-22 2:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinTuc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[TieuDe] [nvarchar](50) NULL,
	[NoiDung] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] ON 

INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (NULL, CAST(111 AS Decimal(18, 0)), NULL, NULL, 1, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (NULL, CAST(111 AS Decimal(18, 0)), NULL, NULL, 1, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (NULL, CAST(111 AS Decimal(18, 0)), NULL, NULL, 2, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (NULL, CAST(111 AS Decimal(18, 0)), NULL, NULL, 2, 4, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (NULL, CAST(111 AS Decimal(18, 0)), NULL, NULL, 3, 5, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (NULL, CAST(111 AS Decimal(18, 0)), NULL, NULL, 3, 6, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Đỏ', N'42', 4, 7, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Xanh', N'38', 5, 8, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Xanh', N'38', 6, 9, 2)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Vàng', N'36', 6, 10, 7)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Đỏ', N'42', 6, 11, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Xanh', N'38', 7, 12, 4)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Vàng', N'36', 8, 13, 4)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Vàng', N'36', 9, 14, 2)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Đỏ', N'42', 9, 15, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Xanh', N'38', 9, 16, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Xanh', N'38', 10, 17, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Xanh', N'38', 11, 18, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Đỏ', N'42', 12, 19, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Vàng', N'36', 13, 20, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Xanh', N'38', 14, 21, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Vàng', N'36', 15, 22, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Xanh', N'38', 16, 23, 2)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Đỏ', N'42', 16, 24, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Vàng', N'36', 17, 25, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Vàng', N'36', 18, 26, 5)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Đỏ', N'42', 19, 27, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang9.jpg', CAST(333 AS Decimal(18, 0)), N'Đen', N'XL', 20, 28, 1)
INSERT [dbo].[ChiTietHoaDon] ([Images], [Gia], [MauSacSP], [KichCoSP], [IDHoaDon], [ID], [Soluong]) VALUES (N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Vàng', N'36', 20, 29, 1)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietSanPham] ON 

INSERT [dbo].[ChiTietSanPham] ([ID], [IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [MauSacSP], [KichCoSP], [SoLuong], [LuotXem]) VALUES (5, 9, N'Áo hồng - 1', NULL, N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'không có', N'Xanh', N'36', 0, 0)
INSERT [dbo].[ChiTietSanPham] ([ID], [IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [MauSacSP], [KichCoSP], [SoLuong], [LuotXem]) VALUES (6, 9, N'Áo hồng - 2', NULL, N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'không có', N'Xanh', N'38', 0, 0)
INSERT [dbo].[ChiTietSanPham] ([ID], [IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [MauSacSP], [KichCoSP], [SoLuong], [LuotXem]) VALUES (7, 9, N'Áo hồng - 3', NULL, N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'không có', N'Đỏ', N'42', 8, 0)
INSERT [dbo].[ChiTietSanPham] ([ID], [IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [MauSacSP], [KichCoSP], [SoLuong], [LuotXem]) VALUES (8, 9, N'Áo hồng - 4', NULL, N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'khong co', N'Vàng', N'36', 5, 0)
INSERT [dbo].[ChiTietSanPham] ([ID], [IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [MauSacSP], [KichCoSP], [SoLuong], [LuotXem]) VALUES (1008, 11, N'Áo Da - 1', NULL, N'hang9.jpg', CAST(333 AS Decimal(18, 0)), N'không có', N'Nâu', N'XL', 0, 0)
INSERT [dbo].[ChiTietSanPham] ([ID], [IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [MauSacSP], [KichCoSP], [SoLuong], [LuotXem]) VALUES (1010, 11, N'Áo Da - 2', NULL, N'hang9.jpg', CAST(333 AS Decimal(18, 0)), N'không có', N'Đen', N'XL', 10, 0)
SET IDENTITY_INSERT [dbo].[ChiTietSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (1, N'qwerwer643', 235346, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-01-06T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (2, N'qwerwer685', 235346, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-02-10T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (3, N'qwerwer407', 235346, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-03-15T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (4, N'qwerwer979', 235346, CAST(111 AS Decimal(18, 0)), NULL, CAST(N'2021-03-15T05:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (5, N'HN732', 980923523, CAST(111 AS Decimal(18, 0)), NULL, CAST(N'2021-04-16T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (6, N'HN875', 123124, CAST(1110 AS Decimal(18, 0)), NULL, CAST(N'2021-04-19T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (7, NULL, 0, CAST(444 AS Decimal(18, 0)), NULL, CAST(N'2022-01-15T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (8, NULL, 0, CAST(444 AS Decimal(18, 0)), NULL, CAST(N'2022-01-26T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (9, N'HCM', 235346, CAST(444 AS Decimal(18, 0)), NULL, CAST(N'2022-02-01T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (10, N'HAHAHAHAH', 235346, CAST(111 AS Decimal(18, 0)), NULL, CAST(N'2022-02-10T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (11, N'qwerwer', 235346, CAST(111 AS Decimal(18, 0)), NULL, CAST(N'2022-02-11T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (12, N'hghg', 235346, CAST(111 AS Decimal(18, 0)), NULL, CAST(N'2022-02-15T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (13, N'qwerwer', 67806785, CAST(111 AS Decimal(18, 0)), NULL, CAST(N'2022-02-25T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (14, N'qwerwer', 1, CAST(111 AS Decimal(18, 0)), NULL, CAST(N'2022-02-26T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (15, N'qwerwer', 773278867, CAST(111 AS Decimal(18, 0)), NULL, CAST(N'2022-02-27T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (16, N'UWU', 773278867, CAST(333 AS Decimal(18, 0)), NULL, CAST(N'2022-03-01T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (17, N'okok', 773278867, CAST(111 AS Decimal(18, 0)), NULL, CAST(N'2022-03-02T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (18, N'lol', 773278867, CAST(555 AS Decimal(18, 0)), NULL, CAST(N'2022-03-06T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (19, N'Hanoi', 213129, CAST(111 AS Decimal(18, 0)), NULL, CAST(N'2022-03-08T03:41:25.433' AS DateTime))
INSERT [dbo].[HoaDon] ([IDHoaDon], [DiaChi], [SDT], [Gia], [UserName], [NgayGio]) VALUES (20, N'nhà Quân ngu', 833421578, CAST(444 AS Decimal(18, 0)), NULL, CAST(N'2022-05-20T07:49:33.673' AS DateTime))
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[KichCo] ON 

INSERT [dbo].[KichCo] ([ID], [KichCoSP]) VALUES (1, N'36')
INSERT [dbo].[KichCo] ([ID], [KichCoSP]) VALUES (2, N'38')
INSERT [dbo].[KichCo] ([ID], [KichCoSP]) VALUES (3, N'40')
INSERT [dbo].[KichCo] ([ID], [KichCoSP]) VALUES (4, N'42')
INSERT [dbo].[KichCo] ([ID], [KichCoSP]) VALUES (5, N'XL')
SET IDENTITY_INSERT [dbo].[KichCo] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([IDLoaiSanPham], [Ten], [Alias], [TrangThai]) VALUES (1, N'Áo', N'Ao', 1)
INSERT [dbo].[LoaiSanPham] ([IDLoaiSanPham], [Ten], [Alias], [TrangThai]) VALUES (2, N'Quần', N'Quan', 1)
INSERT [dbo].[LoaiSanPham] ([IDLoaiSanPham], [Ten], [Alias], [TrangThai]) VALUES (3, N'Váy', N'Vay', 1)
INSERT [dbo].[LoaiSanPham] ([IDLoaiSanPham], [Ten], [Alias], [TrangThai]) VALUES (4, N'Mũ', N'Mu', 1)
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[MauSac] ON 

INSERT [dbo].[MauSac] ([ID], [MauSacSP]) VALUES (1, N'Xanh')
INSERT [dbo].[MauSac] ([ID], [MauSacSP]) VALUES (2, N'Đỏ')
INSERT [dbo].[MauSac] ([ID], [MauSacSP]) VALUES (3, N'Vàng')
INSERT [dbo].[MauSac] ([ID], [MauSacSP]) VALUES (4, N'Gay')
INSERT [dbo].[MauSac] ([ID], [MauSacSP]) VALUES (5, N'Nâu')
INSERT [dbo].[MauSac] ([ID], [MauSacSP]) VALUES (6, N'Đen')
SET IDENTITY_INSERT [dbo].[MauSac] OFF
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([UserName], [PassWord], [Email], [Phone], [ID], [DiaChi], [Image]) VALUES (N'quan', N'202cb962ac59075b964b07152d234b70', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[NguoiDung] ([UserName], [PassWord], [Email], [Phone], [ID], [DiaChi], [Image]) VALUES (N'kinh', N'caf1a3dfb505ffed0d024130f58c5cfa ', NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[NguoiDung] ([UserName], [PassWord], [Email], [Phone], [ID], [DiaChi], [Image]) VALUES (N'khang', N'202cb962ac59075b964b07152d234b70', N'hmmmm@gmail.com', NULL, 3, NULL, NULL)
INSERT [dbo].[NguoiDung] ([UserName], [PassWord], [Email], [Phone], [ID], [DiaChi], [Image]) VALUES (N'minh', N'202cb962ac59075b964b07152d234b70', N'minh@gmail.com', NULL, 4, NULL, NULL)
INSERT [dbo].[NguoiDung] ([UserName], [PassWord], [Email], [Phone], [ID], [DiaChi], [Image]) VALUES (N'duy', N'202cb962ac59075b964b07152d234b70', N'duy@gmail.com', NULL, 5, NULL, NULL)
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [Rating], [GiaNhap]) VALUES (9, N'Áo hồng', 1, N'hang1.jpg', CAST(111 AS Decimal(18, 0)), N'Sale', NULL, CAST(100 AS Decimal(18, 0)))
INSERT [dbo].[SanPham] ([IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [Rating], [GiaNhap]) VALUES (10, N'Áo Xám', 1, N'hang4.jpg', CAST(222 AS Decimal(18, 0)), N'New', NULL, CAST(200 AS Decimal(18, 0)))
INSERT [dbo].[SanPham] ([IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [Rating], [GiaNhap]) VALUES (11, N'Áo Da ', 1, N'hang9.jpg', CAST(333 AS Decimal(18, 0)), N'New', NULL, CAST(300 AS Decimal(18, 0)))
INSERT [dbo].[SanPham] ([IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [Rating], [GiaNhap]) VALUES (12, N'Quần', 2, N'hang14.jpg', CAST(666 AS Decimal(18, 0)), N'New', NULL, CAST(600 AS Decimal(18, 0)))
INSERT [dbo].[SanPham] ([IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [Rating], [GiaNhap]) VALUES (13, N'Hoodie - No1', 1, N'hang19.jpg', CAST(200 AS Decimal(18, 0)), N'Sale', NULL, CAST(150 AS Decimal(18, 0)))
INSERT [dbo].[SanPham] ([IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [Rating], [GiaNhap]) VALUES (14, N'Hoodie - No2', 1, N'hang20.jpg', CAST(300 AS Decimal(18, 0)), N'New', NULL, CAST(250 AS Decimal(18, 0)))
INSERT [dbo].[SanPham] ([IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [Rating], [GiaNhap]) VALUES (15, N'Jean - No1', 2, N'hang18.jpg', CAST(100 AS Decimal(18, 0)), N'Sale', NULL, CAST(50 AS Decimal(18, 0)))
INSERT [dbo].[SanPham] ([IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [Rating], [GiaNhap]) VALUES (16, N'Jacket - No1', 1, N'hang13.jpg', CAST(400 AS Decimal(18, 0)), N'Sale', NULL, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[SanPham] ([IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [Rating], [GiaNhap]) VALUES (17, N'T-Shirt - No1', 1, N'hang7.jpg', CAST(150 AS Decimal(18, 0)), NULL, NULL, CAST(100 AS Decimal(18, 0)))
INSERT [dbo].[SanPham] ([IDSanPham], [Ten], [IDLoaiSanPham], [Images], [Gia], [Mota], [Rating], [GiaNhap]) VALUES (18, N'T-Shirt - No2', 1, N'hang5.jpg', CAST(250 AS Decimal(18, 0)), NULL, NULL, CAST(200 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[TinTuc] ON 

INSERT [dbo].[TinTuc] ([ID], [Image], [CreatedDate], [TieuDe], [NoiDung]) VALUES (1, N'blog-4.jpg', CAST(N'2022-03-13T10:29:24.887' AS DateTime), N'Tiêu đề 1', N'Nội dung 1')
INSERT [dbo].[TinTuc] ([ID], [Image], [CreatedDate], [TieuDe], [NoiDung]) VALUES (2, N'blog-4.jpg', CAST(N'2022-03-13T10:30:24.887' AS DateTime), N'Tiêu đề 2', N'Nội dung 2')
INSERT [dbo].[TinTuc] ([ID], [Image], [CreatedDate], [TieuDe], [NoiDung]) VALUES (3, N'blog-1.jpg', CAST(N'2022-03-13T10:32:27.817' AS DateTime), N'Tiêu đề 3', N'Nội dung 3')
INSERT [dbo].[TinTuc] ([ID], [Image], [CreatedDate], [TieuDe], [NoiDung]) VALUES (4, N'blog-1.jpg', CAST(N'2022-03-13T10:33:27.817' AS DateTime), N'Tiêu đề 4', N'Nội dung 4')
INSERT [dbo].[TinTuc] ([ID], [Image], [CreatedDate], [TieuDe], [NoiDung]) VALUES (5, N'blog-8.jpg', CAST(N'2022-03-13T10:35:39.443' AS DateTime), N'Tiêu đề 5', N'Nội dung 5')
INSERT [dbo].[TinTuc] ([ID], [Image], [CreatedDate], [TieuDe], [NoiDung]) VALUES (6, N'blog-9.jpg', CAST(N'2022-03-13T10:41:21.423' AS DateTime), N'What Curling Irons Are The Best Ones', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry.')
INSERT [dbo].[TinTuc] ([ID], [Image], [CreatedDate], [TieuDe], [NoiDung]) VALUES (7, N'blog-3.jpg', CAST(N'2022-03-13T10:44:54.877' AS DateTime), N'The Health Benefits Of Sunglasses', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry')
INSERT [dbo].[TinTuc] ([ID], [Image], [CreatedDate], [TieuDe], [NoiDung]) VALUES (8, N'blog-2.jpg', CAST(N'2022-03-13T10:45:21.473' AS DateTime), N'Eternity Bands Do Last Forever', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry')
SET IDENTITY_INSERT [dbo].[TinTuc] OFF
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([IDHoaDon])
REFERENCES [dbo].[HoaDon] ([IDHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietSanPham]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietSanPham_SanPham] FOREIGN KEY([IDSanPham])
REFERENCES [dbo].[SanPham] ([IDSanPham])
GO
ALTER TABLE [dbo].[ChiTietSanPham] CHECK CONSTRAINT [FK_ChiTietSanPham_SanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([IDLoaiSanPham])
REFERENCES [dbo].[LoaiSanPham] ([IDLoaiSanPham])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
USE [master]
GO
ALTER DATABASE [Lipstick2] SET  READ_WRITE 
GO
