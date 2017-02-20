USE [master]
GO
/****** Object:  Database [ERPManagement]    Script Date: 02/20/2017 23:03:31 ******/
CREATE DATABASE [ERPManagement] ON  PRIMARY 
( NAME = N'ERPManagement', FILENAME = N'F:\ERPManagement\ERPManagement.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ERPManagement_log', FILENAME = N'F:\ERPManagement\ERPManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [ERPManagement] SET AUTO_CREATE_STATISTICS ON
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
ALTER DATABASE [ERPManagement] SET  READ_WRITE
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
/****** Object:  Table [dbo].[Company]    Script Date: 02/20/2017 23:03:31 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Company] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EquipmentExportation]    Script Date: 02/20/2017 23:03:31 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_EquipmentExportation] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WareHouse]    Script Date: 02/20/2017 23:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WareHouse](
	[WareHouseID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Note] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_WareHouse] PRIMARY KEY CLUSTERED 
(
	[WareHouseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnitMeasure]    Script Date: 02/20/2017 23:03:31 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_UnitMeasure] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regency]    Script Date: 02/20/2017 23:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regency](
	[RegencyID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_Regency] PRIMARY KEY CLUSTERED 
(
	[RegencyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentImportation]    Script Date: 02/20/2017 23:03:31 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_EquipmentImportation] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Method]    Script Date: 02/20/2017 23:03:31 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentType]    Script Date: 02/20/2017 23:03:31 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentImportationDetail]    Script Date: 02/20/2017 23:03:31 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentExportationDetail]    Script Date: 02/20/2017 23:03:31 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 02/20/2017 23:03:31 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Equipment] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 02/20/2017 23:03:31 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Department] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentHandOver]    Script Date: 02/20/2017 23:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentHandOver](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Note] [nvarchar](250) NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentHandOver] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_EquipmentHandOver] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 02/20/2017 23:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Employee] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 02/20/2017 23:03:31 ******/
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
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentHandOverReceiver]    Script Date: 02/20/2017 23:03:31 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentHandOverDetail]    Script Date: 02/20/2017 23:03:31 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentHandOverDeliver]    Script Date: 02/20/2017 23:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentHandOverDeliver](
	[DetailID] [uniqueidentifier] NOT NULL,
	[ID] [int] NOT NULL,
	[Index] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentHandOverDeliver] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Employee_Sex]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_Sex]  DEFAULT ((1)) FOR [Sex]
GO
/****** Object:  Default [DF_Permission_CanRead]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_CanRead]  DEFAULT ((1)) FOR [CanRead]
GO
/****** Object:  Default [DF_Permission_CanWrite]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_CanWrite]  DEFAULT ((0)) FOR [CanWrite]
GO
/****** Object:  Default [DF_Permission_CanDelete]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_CanDelete]  DEFAULT ((0)) FOR [CanDelete]
GO
/****** Object:  ForeignKey [FK_EquipmentImportationDetail_EquipmentImportation]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[EquipmentImportationDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentImportationDetail_EquipmentImportation] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentImportation] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentImportationDetail] CHECK CONSTRAINT [FK_EquipmentImportationDetail_EquipmentImportation]
GO
/****** Object:  ForeignKey [FK_EquipmentExportationDetail_EquipmentExportation]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[EquipmentExportationDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentExportationDetail_EquipmentExportation] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentExportation] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentExportationDetail] CHECK CONSTRAINT [FK_EquipmentExportationDetail_EquipmentExportation]
GO
/****** Object:  ForeignKey [FK_Equipment_EquipmentType]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_EquipmentType] FOREIGN KEY([EquipmentTypeID])
REFERENCES [dbo].[EquipmentType] ([EquipmentTypeID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_EquipmentType]
GO
/****** Object:  ForeignKey [FK_Equipment_UnitMeasure]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_UnitMeasure] FOREIGN KEY([UnitMeasureID])
REFERENCES [dbo].[UnitMeasure] ([UnitMeasureID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_UnitMeasure]
GO
/****** Object:  ForeignKey [FK_Department_Company]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Company]
GO
/****** Object:  ForeignKey [FK_EquipmentHandOver_Department]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[EquipmentHandOver]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOver_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[EquipmentHandOver] CHECK CONSTRAINT [FK_EquipmentHandOver_Department]
GO
/****** Object:  ForeignKey [FK_Employee_Department]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
/****** Object:  ForeignKey [FK_Employee_Regency]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Regency] FOREIGN KEY([RegencyID])
REFERENCES [dbo].[Regency] ([RegencyID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Regency]
GO
/****** Object:  ForeignKey [FK_Permission_Employee]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Employee]
GO
/****** Object:  ForeignKey [FK_Permission_Method]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Method] FOREIGN KEY([MethodID])
REFERENCES [dbo].[Method] ([MethodID])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Method]
GO
/****** Object:  ForeignKey [FK_EquipmentHandOverReceiver_Employee]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[EquipmentHandOverReceiver]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOverReceiver_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[EquipmentHandOverReceiver] CHECK CONSTRAINT [FK_EquipmentHandOverReceiver_Employee]
GO
/****** Object:  ForeignKey [FK_EquipmentHandOverReceiver_EquipmentHandOver1]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[EquipmentHandOverReceiver]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOverReceiver_EquipmentHandOver1] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentHandOver] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentHandOverReceiver] CHECK CONSTRAINT [FK_EquipmentHandOverReceiver_EquipmentHandOver1]
GO
/****** Object:  ForeignKey [FK_EquipmentHandOverDetail_Equipment]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[EquipmentHandOverDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOverDetail_Equipment] FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[EquipmentHandOverDetail] CHECK CONSTRAINT [FK_EquipmentHandOverDetail_Equipment]
GO
/****** Object:  ForeignKey [FK_EquipmentHandOverDetail_EquipmentHandOver]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[EquipmentHandOverDetail]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOverDetail_EquipmentHandOver] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentHandOver] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentHandOverDetail] CHECK CONSTRAINT [FK_EquipmentHandOverDetail_EquipmentHandOver]
GO
/****** Object:  ForeignKey [FK_EquipmentHandOverDeliver_Employee]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[EquipmentHandOverDeliver]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOverDeliver_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[EquipmentHandOverDeliver] CHECK CONSTRAINT [FK_EquipmentHandOverDeliver_Employee]
GO
/****** Object:  ForeignKey [FK_EquipmentHandOverDeliver_EquipmentHandOver]    Script Date: 02/20/2017 23:03:31 ******/
ALTER TABLE [dbo].[EquipmentHandOverDeliver]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentHandOverDeliver_EquipmentHandOver] FOREIGN KEY([ID])
REFERENCES [dbo].[EquipmentHandOver] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquipmentHandOverDeliver] CHECK CONSTRAINT [FK_EquipmentHandOverDeliver_EquipmentHandOver]
GO
