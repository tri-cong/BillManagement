USE [master]
GO
/****** Object:  Database [BillManagement]    Script Date: 8/13/2022 2:31:40 PM ******/
CREATE DATABASE [BillManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BillManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BillManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BillManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BillManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BillManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BillManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BillManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BillManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BillManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BillManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BillManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [BillManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BillManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BillManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BillManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BillManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BillManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BillManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BillManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BillManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BillManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BillManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BillManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BillManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BillManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BillManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BillManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BillManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BillManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BillManagement] SET  MULTI_USER 
GO
ALTER DATABASE [BillManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BillManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BillManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BillManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BillManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BillManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BillManagement] SET QUERY_STORE = OFF
GO
USE [BillManagement]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 8/13/2022 2:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKh] [int] NOT NULL,
	[HoTenKh] [varchar](50) NULL,
	[DiaChiKh] [varchar](50) NULL,
	[QuocTich] [varchar](50) NULL,
	[DoiTuongKh] [varchar](50) NULL,
	[SoLuongTieuThu] [int] NULL,
	[DonGia] [money] NULL,
	[DinhMucTieuThu] [int] NULL,
 CONSTRAINT [PK__KhachHan__2725CF7EE76BEBF9] PRIMARY KEY CLUSTERED 
(
	[MaKh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[KhachHang] ([MaKh], [HoTenKh], [DiaChiKh], [QuocTich], [DoiTuongKh], [SoLuongTieuThu], [DonGia], [DinhMucTieuThu]) VALUES (1, N'Cong', N'TPHCM', N'Vietnamese', N'Sinh Hoat', 200, 25000.0000, 300)
INSERT [dbo].[KhachHang] ([MaKh], [HoTenKh], [DiaChiKh], [QuocTich], [DoiTuongKh], [SoLuongTieuThu], [DonGia], [DinhMucTieuThu]) VALUES (3, N'ababa', N'USA', N'USA', N'Kinh doanh', 120, 120000.0000, 100)
INSERT [dbo].[KhachHang] ([MaKh], [HoTenKh], [DiaChiKh], [QuocTich], [DoiTuongKh], [SoLuongTieuThu], [DonGia], [DinhMucTieuThu]) VALUES (4, N'phu', N'204', N'', N'Kinh doanh', 100, 2.0000, 300)
INSERT [dbo].[KhachHang] ([MaKh], [HoTenKh], [DiaChiKh], [QuocTich], [DoiTuongKh], [SoLuongTieuThu], [DonGia], [DinhMucTieuThu]) VALUES (5, N'abv', N'234', N'Vietnamese', N'San xuat', 200, 2.0000, 100)
GO
USE [master]
GO
ALTER DATABASE [BillManagement] SET  READ_WRITE 
GO
