USE [master]
GO
/****** Object:  Database [ERPManagement]    Script Date: 07/04/2017 5:34:31 PM ******/
CREATE DATABASE [ERPManagement] ON  PRIMARY 
( NAME = N'ERPManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ERPManagement.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ERPManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ERPManagement_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ERPManagement] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ERPManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ERPManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ERPManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ERPManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ERPManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ERPManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ERPManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ERPManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ERPManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ERPManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ERPManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ERPManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ERPManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ERPManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ERPManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ERPManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ERPManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ERPManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ERPManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ERPManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ERPManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ERPManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ERPManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ERPManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ERPManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ERPManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ERPManagement] SET DB_CHAINING OFF 
GO
USE [ERPManagement]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Email] [nvarchar](150) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Note] [nvarchar](250) NULL,
	[CompanyID] [int] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[FamilyName] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Sex] [bit] NOT NULL CONSTRAINT [DF_Employee_Sex]  DEFAULT ((1)),
	[BirthDate] [datetime] NOT NULL,
	[BirthPlace] [nvarchar](50) NULL,
	[Ethnic] [nvarchar](30) NOT NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Email] [nvarchar](150) NULL,
	[RegencyID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[Avatar] [image] NULL,
	[IsManager] [bit] NOT NULL CONSTRAINT [DF_Employee_IsManager]  DEFAULT ((0)),
	[Password] [nvarchar](100) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Number] [nvarchar](30) NULL,
	[EquipmentTypeID] [int] NOT NULL,
	[UnitMeasureID] [int] NOT NULL,
	[NationalID] [int] NOT NULL CONSTRAINT [DF_Equipment_NationalID]  DEFAULT ((1)),
	[Description] [nvarchar](350) NULL,
	[ParentEquipmentID] [int] NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[EquipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentBreak]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentBreak](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[CurrentStatus] [nvarchar](350) NULL,
	[EmployeeAdvise] [nvarchar](350) NULL,
	[Assignment] [int] NOT NULL,
	[Repairer] [int] NULL,
	[RecvInfoDate] [datetime] NULL,
	[RepairDate] [datetime] NULL,
	[Result] [nvarchar](350) NULL,
	[Advise] [nvarchar](350) NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentBreak] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentBreakReport]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentBreakReport](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[EquipmentStatus] [nvarchar](350) NULL,
	[Cause] [nvarchar](350) NULL,
	[HowToRepair] [nvarchar](350) NULL,
	[EmployeeAdvise] [nvarchar](350) NULL,
	[ManagerAdvise] [nvarchar](350) NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentBreakReport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentBreakReportManager]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentBreakReportManager](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentBreakReportManager_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentBreakReportUser]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentBreakReportUser](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentBreakReportUser_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentDetail]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[SubEquipmentID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentExportation]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentExportation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](20) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Receiver] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentExportation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentExportationDetail]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentExportationDetail](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[RestQuantity] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[EquipmentStatusID] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_EquipmentExportationDetail_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentHandOver]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentHandOver](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Note] [nvarchar](250) NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentHandOver] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentHandOverDetail]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentHandOverDetail](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[EquipmentStatusID] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_EquipmentHandOverDetail_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentHandOverReceiver]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentHandOverReceiver](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentHandOverReceiver] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentHandOverSender]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentHandOverSender](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentHandOverSender] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentImportation]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentImportation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](20) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Deliver] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentImportation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentImportationDetail]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentImportationDetail](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[RestQuantity] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[EquipmentStatusID] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_EquipmentImportationDetail_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentReturning]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentReturning](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentReturning] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentReturningDetail]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentReturningDetail](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[EquipmentStatusID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentReturningDetail] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentReturningReceiver]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentReturningReceiver](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentReturningReceiver_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentReturningSender]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentReturningSender](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentReturningSender_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentStatusNoteBook]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentStatusNoteBook](
	[NoteID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentStatusNoteBook] PRIMARY KEY CLUSTERED 
(
	[NoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentStatusNoteBookDetail]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentStatusNoteBookDetail](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[EquipmentStatusID] [int] NOT NULL,
	[Cause] [nvarchar](150) NULL,
	[Note] [nvarchar](150) NULL,
 CONSTRAINT [PK_EquipmentStatusNoteBookDetail_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentTransfer]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentTransfer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Note] [nvarchar](350) NULL,
 CONSTRAINT [PK_EquipmentTransfer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentTransferDetail]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentTransferDetail](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[EquipmentStatusID] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_EquipmentTransferDetail_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentTransferITManager]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentTransferITManager](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentTransferITManager_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentTransferReceiver]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentTransferReceiver](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentTransferReceiver_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentTransferSender]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentTransferSender](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentTransferSender_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentType]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentType](
	[EquipmentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_EquipmentType] PRIMARY KEY CLUSTERED 
(
	[EquipmentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Method]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Method](
	[MethodID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Method] PRIMARY KEY CLUSTERED 
(
	[MethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[National]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[National](
	[NationalID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_National] PRIMARY KEY CLUSTERED 
(
	[NationalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permission]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[MethodID] [int] NOT NULL,
	[CanRead] [bit] NOT NULL CONSTRAINT [DF_Permission_CanRead]  DEFAULT ((1)),
	[CanWrite] [bit] NOT NULL CONSTRAINT [DF_Permission_CanWrite]  DEFAULT ((0)),
	[CanDelete] [bit] NOT NULL CONSTRAINT [DF_Permission_CanDelete]  DEFAULT ((0)),
	[CanAccept] [bit] NOT NULL CONSTRAINT [DF_Permission_CanAccept]  DEFAULT ((0)),
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Regency]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regency](
	[RegencyID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_Regency] PRIMARY KEY CLUSTERED 
(
	[RegencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnitMeasure]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitMeasure](
	[UnitMeasureID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_UnitMeasure] PRIMARY KEY CLUSTERED 
(
	[UnitMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WareHouse]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WareHouse](
	[WareHouseID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Note] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_WareHouse] PRIMARY KEY CLUSTERED 
(
	[WareHouseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyID], [Code], [Name], [PhoneNumber], [Email]) VALUES (1, N'CDSP', N'Trường CĐSP Quảng Trị', N'0979887067', N'vietquytina@gmail.com')
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentID], [Code], [Name], [Note], [CompanyID]) VALUES (1, N'PGD', N'Phòng Giám Đốc', N'Phòng Giám Đốc', 1)
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [Code], [FamilyName], [Name], [Sex], [BirthDate], [BirthPlace], [Ethnic], [PhoneNumber], [Email], [RegencyID], [DepartmentID], [Avatar], [IsManager], [Password]) VALUES (1, N'ADMIN', N'Nguyễn Văn', N'Nam', 1, CAST(N'1992-06-05 00:00:00.000' AS DateTime), N'Quảng Trị', N'Kinh', N'0979887067', N'vietquytina@gmail.com', 1, 1, NULL, 1, N'123456')
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([EquipmentID], [Code], [Name], [Number], [EquipmentTypeID], [UnitMeasureID], [NationalID], [Description], [ParentEquipmentID]) VALUES (1, N'VTA', N'Vật tư A', N'1234', 1, 1, 1, N'Chưa có', NULL)
INSERT [dbo].[Equipment] ([EquipmentID], [Code], [Name], [Number], [EquipmentTypeID], [UnitMeasureID], [NationalID], [Description], [ParentEquipmentID]) VALUES (2, N'VTB', N'Vật tư B', N'12345', 1, 1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Equipment] OFF
SET IDENTITY_INSERT [dbo].[EquipmentExportation] ON 

INSERT [dbo].[EquipmentExportation] ([ID], [Number], [Date], [Receiver], [StatusID]) VALUES (2, N'1', CAST(N'2017-03-22 22:04:26.880' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[EquipmentExportation] OFF
SET IDENTITY_INSERT [dbo].[EquipmentExportationDetail] ON 

INSERT [dbo].[EquipmentExportationDetail] ([DetailID], [ID], [Index], [EquipmentID], [RestQuantity], [Quantity], [EquipmentStatusID], [Note]) VALUES (1, 2, 0, 1, 0, 2, 1, N'dsadsa')
INSERT [dbo].[EquipmentExportationDetail] ([DetailID], [ID], [Index], [EquipmentID], [RestQuantity], [Quantity], [EquipmentStatusID], [Note]) VALUES (2, 2, 1, 1, 0, 1, 1, N'Ghi chu')
SET IDENTITY_INSERT [dbo].[EquipmentExportationDetail] OFF
SET IDENTITY_INSERT [dbo].[EquipmentHandOver] ON 

INSERT [dbo].[EquipmentHandOver] ([ID], [Number], [Date], [Note], [DepartmentID]) VALUES (1, N'1', CAST(N'2017-03-28 22:16:36.273' AS DateTime), NULL, 1)
INSERT [dbo].[EquipmentHandOver] ([ID], [Number], [Date], [Note], [DepartmentID]) VALUES (2, N'2', CAST(N'2017-03-14 22:20:28.360' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[EquipmentHandOver] OFF
SET IDENTITY_INSERT [dbo].[EquipmentHandOverDetail] ON 

INSERT [dbo].[EquipmentHandOverDetail] ([DetailID], [ID], [Index], [EquipmentID], [Quantity], [EquipmentStatusID], [Note]) VALUES (1, 1, 0, 1, 1, 1, N'Ghi chú')
INSERT [dbo].[EquipmentHandOverDetail] ([DetailID], [ID], [Index], [EquipmentID], [Quantity], [EquipmentStatusID], [Note]) VALUES (2, 1, 1, 1, 4, 2, N'')
INSERT [dbo].[EquipmentHandOverDetail] ([DetailID], [ID], [Index], [EquipmentID], [Quantity], [EquipmentStatusID], [Note]) VALUES (3, 2, 0, 1, 2, 1, N'')
SET IDENTITY_INSERT [dbo].[EquipmentHandOverDetail] OFF
SET IDENTITY_INSERT [dbo].[EquipmentHandOverReceiver] ON 

INSERT [dbo].[EquipmentHandOverReceiver] ([DetailID], [ID], [Index], [EmployeeID]) VALUES (1, 1, 0, 1)
SET IDENTITY_INSERT [dbo].[EquipmentHandOverReceiver] OFF
SET IDENTITY_INSERT [dbo].[EquipmentHandOverSender] ON 

INSERT [dbo].[EquipmentHandOverSender] ([DetailID], [ID], [Index], [EmployeeID]) VALUES (1, 1, 0, 1)
INSERT [dbo].[EquipmentHandOverSender] ([DetailID], [ID], [Index], [EmployeeID]) VALUES (2, 2, 0, 1)
INSERT [dbo].[EquipmentHandOverSender] ([DetailID], [ID], [Index], [EmployeeID]) VALUES (3, 2, 1, 1)
INSERT [dbo].[EquipmentHandOverSender] ([DetailID], [ID], [Index], [EmployeeID]) VALUES (4, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[EquipmentHandOverSender] OFF
SET IDENTITY_INSERT [dbo].[EquipmentImportation] ON 

INSERT [dbo].[EquipmentImportation] ([ID], [Number], [Date], [Deliver], [StatusID]) VALUES (1, N'1', CAST(N'2017-03-14 21:57:02.537' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[EquipmentImportation] OFF
SET IDENTITY_INSERT [dbo].[EquipmentImportationDetail] ON 

INSERT [dbo].[EquipmentImportationDetail] ([DetailID], [ID], [Index], [EquipmentID], [RestQuantity], [Quantity], [EquipmentStatusID], [Note]) VALUES (1, 1, 0, 1, 0, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[EquipmentImportationDetail] OFF
SET IDENTITY_INSERT [dbo].[EquipmentReturning] ON 

INSERT [dbo].[EquipmentReturning] ([ID], [Number], [Date], [DepartmentID]) VALUES (3, N'1', CAST(N'2017-03-14 23:08:07.750' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[EquipmentReturning] OFF
SET IDENTITY_INSERT [dbo].[EquipmentReturningDetail] ON 

INSERT [dbo].[EquipmentReturningDetail] ([DetailID], [ID], [Index], [EquipmentID], [Quantity], [EquipmentStatusID]) VALUES (1, 3, 1, 1, 2, 1)
INSERT [dbo].[EquipmentReturningDetail] ([DetailID], [ID], [Index], [EquipmentID], [Quantity], [EquipmentStatusID]) VALUES (2, 3, 0, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[EquipmentReturningDetail] OFF
SET IDENTITY_INSERT [dbo].[EquipmentReturningReceiver] ON 

INSERT [dbo].[EquipmentReturningReceiver] ([DetailID], [ID], [Index], [EmployeeID]) VALUES (1, 3, 0, 1)
SET IDENTITY_INSERT [dbo].[EquipmentReturningReceiver] OFF
SET IDENTITY_INSERT [dbo].[EquipmentReturningSender] ON 

INSERT [dbo].[EquipmentReturningSender] ([DetailID], [ID], [Index], [EmployeeID]) VALUES (1, 3, 1, 1)
INSERT [dbo].[EquipmentReturningSender] ([DetailID], [ID], [Index], [EmployeeID]) VALUES (2, 3, 0, 1)
SET IDENTITY_INSERT [dbo].[EquipmentReturningSender] OFF
SET IDENTITY_INSERT [dbo].[EquipmentStatusNoteBook] ON 

INSERT [dbo].[EquipmentStatusNoteBook] ([NoteID], [Date], [CompanyID], [EmployeeID]) VALUES (1, CAST(N'2017-03-14 22:42:36.883' AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[EquipmentStatusNoteBook] OFF
SET IDENTITY_INSERT [dbo].[EquipmentStatusNoteBookDetail] ON 

INSERT [dbo].[EquipmentStatusNoteBookDetail] ([DetailID], [ID], [Index], [EquipmentID], [EquipmentStatusID], [Cause], [Note]) VALUES (1, 1, 0, 1, 2, N'Thích', N'Ghi chú')
SET IDENTITY_INSERT [dbo].[EquipmentStatusNoteBookDetail] OFF
SET IDENTITY_INSERT [dbo].[EquipmentType] ON 

INSERT [dbo].[EquipmentType] ([EquipmentTypeID], [Name], [Note]) VALUES (1, N'Dụng cụ', N'Chỉ dùng cho vật tư')
SET IDENTITY_INSERT [dbo].[EquipmentType] OFF
SET IDENTITY_INSERT [dbo].[Method] ON 

INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (1, N'Company')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (2, N'Department')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (3, N'Equipment')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (4, N'EquipmentType')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (5, N'Regency')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (6, N'UnitMeasure')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (7, N'Employee')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (8, N'EquipmentBreak')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (9, N'EquipmentBreakReport')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (10, N'EquipmentExportation')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (11, N'EquipmentHandover')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (12, N'EquipmentImportation')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (13, N'EquipmentReturning')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (14, N'EquipmentStatusNoteBook')
INSERT [dbo].[Method] ([MethodID], [Name]) VALUES (15, N'EquipmentTransfer')
SET IDENTITY_INSERT [dbo].[Method] OFF
SET IDENTITY_INSERT [dbo].[National] ON 

INSERT [dbo].[National] ([NationalID], [Name], [Note]) VALUES (1, N'Việt Nam', NULL)
SET IDENTITY_INSERT [dbo].[National] OFF
SET IDENTITY_INSERT [dbo].[Permission] ON 

INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (2, 1, 2, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (3, 1, 3, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (4, 1, 4, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (5, 1, 5, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (6, 1, 6, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (7, 1, 7, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (8, 1, 8, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (9, 1, 9, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (10, 1, 10, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (11, 1, 11, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (12, 1, 12, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (13, 1, 13, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (14, 1, 14, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionID], [EmployeeID], [MethodID], [CanRead], [CanWrite], [CanDelete], [CanAccept]) VALUES (15, 1, 15, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Permission] OFF
SET IDENTITY_INSERT [dbo].[Regency] ON 

INSERT [dbo].[Regency] ([RegencyID], [Code], [Name], [Note]) VALUES (1, N'GD', N'Giám đốc', N'Tạm thời')
SET IDENTITY_INSERT [dbo].[Regency] OFF
SET IDENTITY_INSERT [dbo].[UnitMeasure] ON 

INSERT [dbo].[UnitMeasure] ([UnitMeasureID], [Code], [Name], [Note]) VALUES (1, N'Cai', N'Cái', N'Được sử dụngg')
SET IDENTITY_INSERT [dbo].[UnitMeasure] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Company]    Script Date: 07/04/2017 5:34:31 PM ******/
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [IX_Company] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department]    Script Date: 07/04/2017 5:34:31 PM ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [IX_Department] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Employee]    Script Date: 07/04/2017 5:34:31 PM ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [IX_Employee] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Equipment]    Script Date: 07/04/2017 5:34:31 PM ******/
ALTER TABLE [dbo].[Equipment] ADD  CONSTRAINT [IX_Equipment] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_EquipmentExportation]    Script Date: 07/04/2017 5:34:31 PM ******/
ALTER TABLE [dbo].[EquipmentExportation] ADD  CONSTRAINT [IX_EquipmentExportation] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_EquipmentHandOver]    Script Date: 07/04/2017 5:34:31 PM ******/
ALTER TABLE [dbo].[EquipmentHandOver] ADD  CONSTRAINT [IX_EquipmentHandOver] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_EquipmentImportation]    Script Date: 07/04/2017 5:34:31 PM ******/
ALTER TABLE [dbo].[EquipmentImportation] ADD  CONSTRAINT [IX_EquipmentImportation] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Regency]    Script Date: 07/04/2017 5:34:31 PM ******/
ALTER TABLE [dbo].[Regency] ADD  CONSTRAINT [IX_Regency] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UnitMeasure]    Script Date: 07/04/2017 5:34:31 PM ******/
ALTER TABLE [dbo].[UnitMeasure] ADD  CONSTRAINT [IX_UnitMeasure] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_WareHouse]    Script Date: 07/04/2017 5:34:31 PM ******/
ALTER TABLE [dbo].[WareHouse] ADD  CONSTRAINT [IX_WareHouse] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Company]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Regency] FOREIGN KEY([RegencyID])
REFERENCES [dbo].[Regency] ([RegencyID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Regency]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_EquipmentType] FOREIGN KEY([EquipmentTypeID])
REFERENCES [dbo].[EquipmentType] ([EquipmentTypeID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_EquipmentType]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_UnitMeasure] FOREIGN KEY([UnitMeasureID])
REFERENCES [dbo].[UnitMeasure] ([UnitMeasureID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_UnitMeasure]
GO
ALTER TABLE [dbo].[EquipmentBreakReportManager]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentBreakReportManager_EquipmentBreakReport] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentBreakReport] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentBreakReportManager] CHECK CONSTRAINT [FK_EquipmentBreakReportManager_EquipmentBreakReport]
GO
ALTER TABLE [dbo].[EquipmentBreakReportUser]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentBreakReportUser_EquipmentBreakReport] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentBreakReport] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentBreakReportUser] CHECK CONSTRAINT [FK_EquipmentBreakReportUser_EquipmentBreakReport]
GO
ALTER TABLE [dbo].[EquipmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentDetail_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentDetail] CHECK CONSTRAINT [FK_EquipmentDetail_Equipment]
GO
ALTER TABLE [dbo].[EquipmentExportationDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentExportationDetail_EquipmentExportation] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentExportation] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentExportationDetail] CHECK CONSTRAINT [FK_EquipmentExportationDetail_EquipmentExportation]
GO
ALTER TABLE [dbo].[EquipmentHandOver]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOver_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[EquipmentHandOver] CHECK CONSTRAINT [FK_EquipmentHandOver_Department]
GO
ALTER TABLE [dbo].[EquipmentHandOverDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOverDetail_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[EquipmentHandOverDetail] CHECK CONSTRAINT [FK_EquipmentHandOverDetail_Equipment]
GO
ALTER TABLE [dbo].[EquipmentHandOverDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOverDetail_EquipmentHandOver] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentHandOver] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentHandOverDetail] CHECK CONSTRAINT [FK_EquipmentHandOverDetail_EquipmentHandOver]
GO
ALTER TABLE [dbo].[EquipmentHandOverReceiver]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOverReceiver_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[EquipmentHandOverReceiver] CHECK CONSTRAINT [FK_EquipmentHandOverReceiver_Employee]
GO
ALTER TABLE [dbo].[EquipmentHandOverReceiver]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOverReceiver_EquipmentHandOver] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentHandOver] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentHandOverReceiver] CHECK CONSTRAINT [FK_EquipmentHandOverReceiver_EquipmentHandOver]
GO
ALTER TABLE [dbo].[EquipmentHandOverSender]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOverDeliver_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[EquipmentHandOverSender] CHECK CONSTRAINT [FK_EquipmentHandOverDeliver_Employee]
GO
ALTER TABLE [dbo].[EquipmentHandOverSender]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOverSender_EquipmentHandOver] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentHandOver] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentHandOverSender] CHECK CONSTRAINT [FK_EquipmentHandOverSender_EquipmentHandOver]
GO
ALTER TABLE [dbo].[EquipmentImportation]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentImportation_Employee] FOREIGN KEY([Deliver])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[EquipmentImportation] CHECK CONSTRAINT [FK_EquipmentImportation_Employee]
GO
ALTER TABLE [dbo].[EquipmentImportationDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentImportationDetail_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[EquipmentImportationDetail] CHECK CONSTRAINT [FK_EquipmentImportationDetail_Equipment]
GO
ALTER TABLE [dbo].[EquipmentImportationDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentImportationDetail_EquipmentImportation] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentImportation] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentImportationDetail] CHECK CONSTRAINT [FK_EquipmentImportationDetail_EquipmentImportation]
GO
ALTER TABLE [dbo].[EquipmentReturningDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentReturningDetail_EquipmentReturning] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentReturning] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentReturningDetail] CHECK CONSTRAINT [FK_EquipmentReturningDetail_EquipmentReturning]
GO
ALTER TABLE [dbo].[EquipmentReturningReceiver]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentReturningReceiver_EquipmentReturning] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentReturning] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentReturningReceiver] CHECK CONSTRAINT [FK_EquipmentReturningReceiver_EquipmentReturning]
GO
ALTER TABLE [dbo].[EquipmentReturningSender]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentReturningSender_EquipmentReturning] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentReturning] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentReturningSender] CHECK CONSTRAINT [FK_EquipmentReturningSender_EquipmentReturning]
GO
ALTER TABLE [dbo].[EquipmentStatusNoteBookDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentStatusNoteBookDetail_EquipmentStatusNoteBook] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentStatusNoteBook] ([NoteID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentStatusNoteBookDetail] CHECK CONSTRAINT [FK_EquipmentStatusNoteBookDetail_EquipmentStatusNoteBook]
GO
ALTER TABLE [dbo].[EquipmentTransferDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentTransferDetail_EquipmentTransfer] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentTransfer] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentTransferDetail] CHECK CONSTRAINT [FK_EquipmentTransferDetail_EquipmentTransfer]
GO
ALTER TABLE [dbo].[EquipmentTransferITManager]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentTransferITManager_EquipmentTransfer] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentTransfer] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentTransferITManager] CHECK CONSTRAINT [FK_EquipmentTransferITManager_EquipmentTransfer]
GO
ALTER TABLE [dbo].[EquipmentTransferReceiver]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentTransferReceiver_EquipmentTransfer] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentTransfer] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentTransferReceiver] CHECK CONSTRAINT [FK_EquipmentTransferReceiver_EquipmentTransfer]
GO
ALTER TABLE [dbo].[EquipmentTransferSender]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentTransferSender_EquipmentTransfer] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentTransfer] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentTransferSender] CHECK CONSTRAINT [FK_EquipmentTransferSender_EquipmentTransfer]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Employee]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Method] FOREIGN KEY([MethodID])
REFERENCES [dbo].[Method] ([MethodID])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Method]
GO
/****** Object:  Trigger [dbo].[TG_Employee_Insert]    Script Date: 07/04/2017 5:34:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TG_Employee_Insert] ON [dbo].[Employee]
AFTER INSERT AS
	INSERT INTO Permission(EmployeeID, MethodID) SELECT EmployeeID, MethodID FROM Method, inserted

GO
USE [master]
GO
ALTER DATABASE [ERPManagement] SET  READ_WRITE 
GO
