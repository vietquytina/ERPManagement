USE [master]
GO
/****** Object:  Database [ERPManagement]    Script Date: 01/03/2017 5:19:18 PM ******/
CREATE DATABASE [ERPManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
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
ALTER DATABASE [ERPManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ERPManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ERPManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ERPManagement]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 01/03/2017 5:19:18 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Company] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 01/03/2017 5:19:18 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Department] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[FamilyName] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Sex] [bit] NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[BirthPlace] [nvarchar](50) NULL,
	[Ethnic] [nvarchar](30) NOT NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Email] [nvarchar](150) NULL,
	[RegencyID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[Avatar] [image] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Employee] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[EquipmentTypeID] [int] NOT NULL,
	[UnitMeasureID] [int] NOT NULL,
	[Description] [nvarchar](350) NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[EquipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Equipment] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentBreak]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentBreak](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[Result] [nvarchar](350) NULL,
	[Advise] [nvarchar](350) NULL,
	[Assignment] [int] NOT NULL,
	[Repairer] [int] NOT NULL,
	[RecvInfoDate] [datetime] NULL,
	[RepairDate] [datetime] NULL,
 CONSTRAINT [PK_EquipmentBreak] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentBreakDetail]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentBreakDetail](
	[DetailID] [uniqueidentifier] NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[Note] [nvarchar](350) NULL,
	[Advise] [nvarchar](350) NULL,
 CONSTRAINT [PK_EquipmentBreakDetail] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentExportation]    Script Date: 01/03/2017 5:19:18 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_EquipmentExportation] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentExportationDetail]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentExportationDetail](
	[DetailID] [uniqueidentifier] NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[RestQuantity] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[EquipmentStatusID] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_EquipmentExportationDetail] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentHandOver]    Script Date: 01/03/2017 5:19:18 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_EquipmentHandOver] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentHandOverDetail]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentHandOverDetail](
	[DetailID] [uniqueidentifier] NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[EquipmentStatusID] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_EquipmentHandOverDetail] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentHandOverReceiver]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentHandOverReceiver](
	[DetailID] [uniqueidentifier] NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentHandOverReceiver_1] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentHandOverSender]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentHandOverSender](
	[DetailID] [uniqueidentifier] NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentHandOverDeliver] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentImportation]    Script Date: 01/03/2017 5:19:18 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_EquipmentImportation] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentImportationDetail]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentImportationDetail](
	[DetailID] [uniqueidentifier] NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[RestQuantity] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[EquipmentStatusID] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_EquipmentImportationDetail] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentReturning]    Script Date: 01/03/2017 5:19:18 PM ******/
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
/****** Object:  Table [dbo].[EquipmentReturningDetail]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentReturningDetail](
	[DetailID] [int] NOT NULL,
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
/****** Object:  Table [dbo].[EquipmentReturningReceiver]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentReturningReceiver](
	[DetailID] [uniqueidentifier] NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentReturningReceiver] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentReturningSender]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentReturningSender](
	[DetailID] [uniqueidentifier] NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentReturningSender] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentStatusNoteBook]    Script Date: 01/03/2017 5:19:18 PM ******/
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
/****** Object:  Table [dbo].[EquipmentStatusNoteBookDetail]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentStatusNoteBookDetail](
	[DetailID] [uniqueidentifier] NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[EquipmentStatusID] [int] NOT NULL,
	[Cause] [nvarchar](150) NULL,
	[Note] [nvarchar](150) NULL,
 CONSTRAINT [PK_EquipmentStatusNoteBookDetail] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EquipmentType]    Script Date: 01/03/2017 5:19:18 PM ******/
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
/****** Object:  Table [dbo].[Method]    Script Date: 01/03/2017 5:19:18 PM ******/
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
/****** Object:  Table [dbo].[Permission]    Script Date: 01/03/2017 5:19:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[MethodID] [int] NOT NULL,
	[CanRead] [bit] NOT NULL,
	[CanWrite] [bit] NOT NULL,
	[CanDelete] [bit] NOT NULL,
	[CanAccept] [bit] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Regency]    Script Date: 01/03/2017 5:19:18 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Regency] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnitMeasure]    Script Date: 01/03/2017 5:19:18 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_UnitMeasure] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WareHouse]    Script Date: 01/03/2017 5:19:18 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_WareHouse] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_Sex]  DEFAULT ((1)) FOR [Sex]
GO
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_CanRead]  DEFAULT ((1)) FOR [CanRead]
GO
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_CanWrite]  DEFAULT ((0)) FOR [CanWrite]
GO
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_CanDelete]  DEFAULT ((0)) FOR [CanDelete]
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
ALTER TABLE [dbo].[EquipmentBreakDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentBreakDetail_EquipmentBreak] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentBreak] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentBreakDetail] CHECK CONSTRAINT [FK_EquipmentBreakDetail_EquipmentBreak]
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
USE [master]
GO
ALTER DATABASE [ERPManagement] SET  READ_WRITE 
GO
