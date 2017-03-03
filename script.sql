USE [master]
GO
/****** Object:  Database [Equipment]    Script Date: 03/03/2017 5:21:02 PM ******/
CREATE DATABASE [Equipment] ON  PRIMARY 
( NAME = N'Equipment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Equipment.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Equipment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Equipment_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Equipment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Equipment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Equipment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Equipment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Equipment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Equipment] SET ARITHABORT OFF 
GO
ALTER DATABASE [Equipment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Equipment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Equipment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Equipment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Equipment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Equipment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Equipment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Equipment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Equipment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Equipment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Equipment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Equipment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Equipment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Equipment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Equipment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Equipment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Equipment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Equipment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Equipment] SET  MULTI_USER 
GO
ALTER DATABASE [Equipment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Equipment] SET DB_CHAINING OFF 
GO
USE [Equipment]
GO
/****** Object:  Table [dbo].[Building]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Building](
	[BuildingID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](15) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[SchoolID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BuildingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](15) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Email] [varchar](150) NULL,
	[BuildingID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[RegencyID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[OfficeID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[ImportDate] [datetime] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[NationalID] [int] NOT NULL,
	[ManufacturerID] [int] NOT NULL,
	[ProviderID] [int] NOT NULL,
	[GuaranteeTo] [datetime] NOT NULL,
	[StatusID] [int] NOT NULL,
	[CPU] [nvarchar](300) NULL,
	[MainBoard] [nvarchar](300) NULL,
	[Ram] [nvarchar](300) NULL,
	[HDD] [nvarchar](300) NULL,
	[OpticalDriver] [nvarchar](300) NULL,
	[Display] [nvarchar](300) NULL,
	[Nic] [nvarchar](300) NULL,
	[PowerSupply] [nvarchar](300) NULL,
	[Monitor] [nvarchar](300) NULL,
	[Keyboard] [nvarchar](300) NULL,
	[Mouse] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[EquipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EquipmentLiquidation]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentLiquidation](
	[LiquidationID] [int] IDENTITY(1,1) NOT NULL,
	[LiquidationDate] [datetime] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentLiquidation] PRIMARY KEY CLUSTERED 
(
	[LiquidationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentStatusNoteBook]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentStatusNoteBook](
	[NoteID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[NoteDate] [datetime] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[Reason] [nvarchar](350) NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_EquipmentStatusNoteBook] PRIMARY KEY CLUSTERED 
(
	[NoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentTransfer]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentTransfer](
	[TransferID] [int] IDENTITY(1,1) NOT NULL,
	[TransferDate] [datetime] NOT NULL,
	[FirstSenderID] [int] NOT NULL,
	[SecondSenderID] [int] NULL,
	[FirstRecvID] [int] NOT NULL,
	[SecondRecvID] [int] NULL,
 CONSTRAINT [PK__Equipmen__95490171920B10CC] PRIMARY KEY CLUSTERED 
(
	[TransferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentTransferDetail]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentTransferDetail](
	[TransferID] [int] NOT NULL,
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentTransferDetail] PRIMARY KEY CLUSTERED 
(
	[TransferID] ASC,
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExportWareHouse]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportWareHouse](
	[ExportID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[ExportDate] [datetime] NOT NULL,
	[ReceiverID] [int] NOT NULL,
 CONSTRAINT [PK__ExportWa__E5C997A491298DEF] PRIMARY KEY CLUSTERED 
(
	[ExportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__ExportWa__78A1A19D91E172D6] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExportWareHouseDetail]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportWareHouseDetail](
	[ExportID] [int] NOT NULL,
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[UnitMeasure] [nvarchar](150) NULL,
	[Quantity] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_ExportWareHouseDetail] PRIMARY KEY CLUSTERED 
(
	[ExportID] ASC,
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Handover]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Handover](
	[HandoverID] [int] IDENTITY(1,1) NOT NULL,
	[HandoverDate] [datetime] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[FirstSenderID] [int] NOT NULL,
	[SecondSenderID] [int] NULL,
	[FirstRecvID] [int] NOT NULL,
	[SecondRecvID] [int] NULL,
 CONSTRAINT [PK_Handover] PRIMARY KEY CLUSTERED 
(
	[HandoverID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HandoverDetail]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HandoverDetail](
	[HandoverID] [int] NOT NULL,
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_HandoverDetail] PRIMARY KEY CLUSTERED 
(
	[HandoverID] ASC,
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImportWareHouse]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportWareHouse](
	[ImportID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[ImportDate] [datetime] NOT NULL,
	[Note] [nvarchar](550) NULL,
	[SenderID] [int] NOT NULL,
 CONSTRAINT [PK__ImportWa__8697678ACEDCE7A6] PRIMARY KEY CLUSTERED 
(
	[ImportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__ImportWa__78A1A19D7A6382AD] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImportWareHouseDetail]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportWareHouseDetail](
	[ImportID] [int] NOT NULL,
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[UnitMeasure] [nvarchar](150) NULL,
	[Quantity] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_ImportWareHouseDetail] PRIMARY KEY CLUSTERED 
(
	[ImportID] ASC,
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[ManufacturerID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[NationalID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ManufacturerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[National]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[National](
	[NationalID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](15) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NationalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Office]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Office](
	[OfficeID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](15) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[BuildingID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OfficeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provider](
	[ProviderID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Addr] [nvarchar](250) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Email] [varchar](150) NULL,
	[Fax] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProviderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Regency]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Regency](
	[RegencyID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](15) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RegencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReturnEquipment]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnEquipment](
	[ReturnID] [int] IDENTITY(1,1) NOT NULL,
	[ReturnDate] [datetime] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[FirstSenderID] [int] NOT NULL,
	[SecondSenderID] [int] NULL,
	[FirstRecvID] [int] NOT NULL,
	[SecondRecvID] [int] NULL,
 CONSTRAINT [PK_ReturnEquipment] PRIMARY KEY CLUSTERED 
(
	[ReturnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReturnEquipmentDetail]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnEquipmentDetail](
	[ReturnID] [int] NOT NULL,
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_ReturnEquipmentDetail] PRIMARY KEY CLUSTERED 
(
	[ReturnID] ASC,
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[School]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[School](
	[SchoolID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Addr] [nvarchar](350) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Email] [varchar](160) NULL,
	[Fax] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[SchoolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Status]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](15) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transfer]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transfer](
	[TransferID] [int] IDENTITY(1,1) NOT NULL,
	[TransferDate] [datetime] NOT NULL,
	[SenderID] [int] NOT NULL,
	[RecvID] [int] NOT NULL,
	[FirstEmployeeID] [int] NULL,
	[SecondEmployeeID] [int] NULL,
 CONSTRAINT [PK_Transfer] PRIMARY KEY CLUSTERED 
(
	[TransferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransferDetail]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferDetail](
	[TransferID] [int] NOT NULL,
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_TransferDetail] PRIMARY KEY CLUSTERED 
(
	[TransferID] ASC,
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ReturnEquipmentDetail] ADD  CONSTRAINT [DF_ReturnEquipmentDetail_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Building]  WITH CHECK ADD FOREIGN KEY([SchoolID])
REFERENCES [dbo].[School] ([SchoolID])
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD FOREIGN KEY([BuildingID])
REFERENCES [dbo].[Building] ([BuildingID])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([OfficeID])
REFERENCES [dbo].[Office] ([OfficeID])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([RegencyID])
REFERENCES [dbo].[Regency] ([RegencyID])
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD FOREIGN KEY([ManufacturerID])
REFERENCES [dbo].[Manufacturer] ([ManufacturerID])
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD FOREIGN KEY([NationalID])
REFERENCES [dbo].[National] ([NationalID])
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD FOREIGN KEY([ProviderID])
REFERENCES [dbo].[Provider] ([ProviderID])
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[EquipmentLiquidation]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentLiquidation_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[EquipmentLiquidation] CHECK CONSTRAINT [FK_EquipmentLiquidation_Equipment]
GO
ALTER TABLE [dbo].[EquipmentLiquidation]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentLiquidation_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[EquipmentLiquidation] CHECK CONSTRAINT [FK_EquipmentLiquidation_Status]
GO
ALTER TABLE [dbo].[EquipmentStatusNoteBook]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentStatusNoteBook_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[EquipmentStatusNoteBook] CHECK CONSTRAINT [FK_EquipmentStatusNoteBook_Company]
GO
ALTER TABLE [dbo].[EquipmentStatusNoteBook]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentStatusNoteBook_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[EquipmentStatusNoteBook] CHECK CONSTRAINT [FK_EquipmentStatusNoteBook_Equipment]
GO
ALTER TABLE [dbo].[EquipmentStatusNoteBook]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentStatusNoteBook_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[EquipmentStatusNoteBook] CHECK CONSTRAINT [FK_EquipmentStatusNoteBook_Status]
GO
ALTER TABLE [dbo].[EquipmentTransferDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentTransferDetail_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[EquipmentTransferDetail] CHECK CONSTRAINT [FK_EquipmentTransferDetail_Equipment]
GO
ALTER TABLE [dbo].[EquipmentTransferDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentTransferDetail_EquipmentTransfer] FOREIGN KEY([TransferID])
REFERENCES [dbo].[EquipmentTransfer] ([TransferID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentTransferDetail] CHECK CONSTRAINT [FK_EquipmentTransferDetail_EquipmentTransfer]
GO
ALTER TABLE [dbo].[EquipmentTransferDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentTransferDetail_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[EquipmentTransferDetail] CHECK CONSTRAINT [FK_EquipmentTransferDetail_Status]
GO
ALTER TABLE [dbo].[ExportWareHouse]  WITH CHECK ADD  CONSTRAINT [FK_ExportWareHouse_Employee] FOREIGN KEY([ReceiverID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[ExportWareHouse] CHECK CONSTRAINT [FK_ExportWareHouse_Employee]
GO
ALTER TABLE [dbo].[ExportWareHouseDetail]  WITH CHECK ADD  CONSTRAINT [FK_ExportWareHouseDetail_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[ExportWareHouseDetail] CHECK CONSTRAINT [FK_ExportWareHouseDetail_Equipment]
GO
ALTER TABLE [dbo].[ExportWareHouseDetail]  WITH CHECK ADD  CONSTRAINT [FK_ExportWareHouseDetail_ExportWareHouse] FOREIGN KEY([ExportID])
REFERENCES [dbo].[ExportWareHouse] ([ExportID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExportWareHouseDetail] CHECK CONSTRAINT [FK_ExportWareHouseDetail_ExportWareHouse]
GO
ALTER TABLE [dbo].[ExportWareHouseDetail]  WITH CHECK ADD  CONSTRAINT [FK_ExportWareHouseDetail_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[ExportWareHouseDetail] CHECK CONSTRAINT [FK_ExportWareHouseDetail_Status]
GO
ALTER TABLE [dbo].[Handover]  WITH CHECK ADD  CONSTRAINT [FK_Handover_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Handover] CHECK CONSTRAINT [FK_Handover_Company]
GO
ALTER TABLE [dbo].[Handover]  WITH CHECK ADD  CONSTRAINT [FK_Handover_Employee] FOREIGN KEY([FirstSenderID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Handover] CHECK CONSTRAINT [FK_Handover_Employee]
GO
ALTER TABLE [dbo].[Handover]  WITH CHECK ADD  CONSTRAINT [FK_Handover_Employee1] FOREIGN KEY([HandoverID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Handover] CHECK CONSTRAINT [FK_Handover_Employee1]
GO
ALTER TABLE [dbo].[Handover]  WITH CHECK ADD  CONSTRAINT [FK_Handover_Employee2] FOREIGN KEY([FirstRecvID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Handover] CHECK CONSTRAINT [FK_Handover_Employee2]
GO
ALTER TABLE [dbo].[Handover]  WITH CHECK ADD  CONSTRAINT [FK_Handover_Employee3] FOREIGN KEY([SecondRecvID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Handover] CHECK CONSTRAINT [FK_Handover_Employee3]
GO
ALTER TABLE [dbo].[HandoverDetail]  WITH CHECK ADD  CONSTRAINT [FK_HandoverDetail_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[HandoverDetail] CHECK CONSTRAINT [FK_HandoverDetail_Equipment]
GO
ALTER TABLE [dbo].[HandoverDetail]  WITH CHECK ADD  CONSTRAINT [FK_HandoverDetail_Handover] FOREIGN KEY([HandoverID])
REFERENCES [dbo].[Handover] ([HandoverID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HandoverDetail] CHECK CONSTRAINT [FK_HandoverDetail_Handover]
GO
ALTER TABLE [dbo].[HandoverDetail]  WITH CHECK ADD  CONSTRAINT [FK_HandoverDetail_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[HandoverDetail] CHECK CONSTRAINT [FK_HandoverDetail_Status]
GO
ALTER TABLE [dbo].[ImportWareHouse]  WITH CHECK ADD  CONSTRAINT [FK_ImportWareHouse_Employee] FOREIGN KEY([SenderID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[ImportWareHouse] CHECK CONSTRAINT [FK_ImportWareHouse_Employee]
GO
ALTER TABLE [dbo].[ImportWareHouseDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportWareHouseDetail_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[ImportWareHouseDetail] CHECK CONSTRAINT [FK_ImportWareHouseDetail_Equipment]
GO
ALTER TABLE [dbo].[ImportWareHouseDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportWareHouseDetail_ImportWareHouse] FOREIGN KEY([ImportID])
REFERENCES [dbo].[ImportWareHouse] ([ImportID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImportWareHouseDetail] CHECK CONSTRAINT [FK_ImportWareHouseDetail_ImportWareHouse]
GO
ALTER TABLE [dbo].[ImportWareHouseDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportWareHouseDetail_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[ImportWareHouseDetail] CHECK CONSTRAINT [FK_ImportWareHouseDetail_Status]
GO
ALTER TABLE [dbo].[Manufacturer]  WITH CHECK ADD FOREIGN KEY([NationalID])
REFERENCES [dbo].[National] ([NationalID])
GO
ALTER TABLE [dbo].[Office]  WITH CHECK ADD FOREIGN KEY([BuildingID])
REFERENCES [dbo].[Building] ([BuildingID])
GO
ALTER TABLE [dbo].[Office]  WITH CHECK ADD FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[ReturnEquipment]  WITH CHECK ADD  CONSTRAINT [FK_ReturnEquipment_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[ReturnEquipment] CHECK CONSTRAINT [FK_ReturnEquipment_Company]
GO
ALTER TABLE [dbo].[ReturnEquipment]  WITH CHECK ADD  CONSTRAINT [FK_ReturnEquipment_Employee] FOREIGN KEY([FirstSenderID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[ReturnEquipment] CHECK CONSTRAINT [FK_ReturnEquipment_Employee]
GO
ALTER TABLE [dbo].[ReturnEquipment]  WITH CHECK ADD  CONSTRAINT [FK_ReturnEquipment_Employee1] FOREIGN KEY([SecondSenderID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[ReturnEquipment] CHECK CONSTRAINT [FK_ReturnEquipment_Employee1]
GO
ALTER TABLE [dbo].[ReturnEquipment]  WITH CHECK ADD  CONSTRAINT [FK_ReturnEquipment_Employee2] FOREIGN KEY([FirstRecvID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[ReturnEquipment] CHECK CONSTRAINT [FK_ReturnEquipment_Employee2]
GO
ALTER TABLE [dbo].[ReturnEquipment]  WITH CHECK ADD  CONSTRAINT [FK_ReturnEquipment_Employee3] FOREIGN KEY([SecondRecvID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[ReturnEquipment] CHECK CONSTRAINT [FK_ReturnEquipment_Employee3]
GO
ALTER TABLE [dbo].[ReturnEquipmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_ReturnEquipmentDetail_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[ReturnEquipmentDetail] CHECK CONSTRAINT [FK_ReturnEquipmentDetail_Equipment]
GO
ALTER TABLE [dbo].[ReturnEquipmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_ReturnEquipmentDetail_ReturnEquipment] FOREIGN KEY([ReturnID])
REFERENCES [dbo].[ReturnEquipment] ([ReturnID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReturnEquipmentDetail] CHECK CONSTRAINT [FK_ReturnEquipmentDetail_ReturnEquipment]
GO
ALTER TABLE [dbo].[ReturnEquipmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_ReturnEquipmentDetail_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[ReturnEquipmentDetail] CHECK CONSTRAINT [FK_ReturnEquipmentDetail_Status]
GO
ALTER TABLE [dbo].[TransferDetail]  WITH CHECK ADD  CONSTRAINT [FK_TransferDetail_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[TransferDetail] CHECK CONSTRAINT [FK_TransferDetail_Equipment]
GO
ALTER TABLE [dbo].[TransferDetail]  WITH CHECK ADD  CONSTRAINT [FK_TransferDetail_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[TransferDetail] CHECK CONSTRAINT [FK_TransferDetail_Status]
GO
ALTER TABLE [dbo].[TransferDetail]  WITH CHECK ADD  CONSTRAINT [FK_TransferDetail_Transfer] FOREIGN KEY([TransferID])
REFERENCES [dbo].[Transfer] ([TransferID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TransferDetail] CHECK CONSTRAINT [FK_TransferDetail_Transfer]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetEquipmentInfomation]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetEquipmentInfomation](@equipmentID AS int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT Code, ImportDate, 
			(SELECT TOP 1 ExportDate 
			 FROM ExportWareHouseDetail JOIN ExportWareHouse ON ExportWareHouseDetail.ExportID = ExportWareHouse.ExportID
			 WHERE ExportWareHouseDetail.EquipmentID = @equipmentID 
			 ORDER BY ExportWareHouse.ExportDate DESC) AS 'LiquidatDate',
			 Name, NationalID, ManufacturerID, ProviderID, GuaranteeTo, CompanyID 
	FROM Equipment 
	WHERE EquipmentID = @equipmentID 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetEquipmentList]    Script Date: 03/03/2017 5:21:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetEquipmentList]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT EquipmentID, Equipment.Name, Equipment.ImportDate,
			(SELECT TOP 1 Office.Name
			 FROM TransferDetail JOIN [Transfer] ON TransferDetail.TransferID = [Transfer].TransferID 
				  JOIN Employee ON [Transfer].RecvID = Employee.EmployeeID 
				  JOIN Office ON Office.OfficeID = Employee.OfficeID 
			 WHERE TransferDetail.EquipmentID = Equipment.EquipmentID 
			 ORDER BY [Transfer].TransferDate DESC) AS 'Position',
			 (
				(SELECT SUM(Quantity) FROM ImportWareHouseDetail WHERE EquipmentID = Equipment.EquipmentID)
				- (SELECT SUM(Quantity) FROM ExportWareHouseDetail WHERE EquipmentID = Equipment.EquipmentID) 
				- (SELECT COUNT(EquipmentID) FROM EquipmentLiquidation WHERE EquipmentID = Equipment.EquipmentID)
			 ) AS 'Number'
	FROM Equipment 
END

GO
USE [master]
GO
ALTER DATABASE [Equipment] SET  READ_WRITE 
GO
