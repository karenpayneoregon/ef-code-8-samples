USE [master]
GO
/****** Object:  Database [EF.ShadowEntityCore]    Script Date: 5/9/2022 8:02:55 AM ******/
CREATE DATABASE [EF.ShadowEntityCore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EF.ShadowEntityCore', FILENAME = N'C:\Users\paynek\EF.ShadowEntityCore.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EF.ShadowEntityCore_log', FILENAME = N'C:\Users\paynek\EF.ShadowEntityCore_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EF.ShadowEntityCore] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EF.ShadowEntityCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EF.ShadowEntityCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET  MULTI_USER 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EF.ShadowEntityCore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EF.ShadowEntityCore] SET DELAYED_DURABILITY = DISABLED 
GO
USE [EF.ShadowEntityCore]
GO
/****** Object:  User [OED\paynek]    Script Date: 5/9/2022 8:02:56 AM ******/
CREATE USER [OED\paynek] FOR LOGIN [OED\paynek] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_datareader] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [OED\paynek]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 5/9/2022 8:02:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[LastUpdated] [datetime2](7) NULL,
	[LastUser] [nvarchar](max) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact1]    Script Date: 5/9/2022 8:02:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact1](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[LastUpdated] [datetime2](7) NULL,
	[LastUser] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Contact1] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contact1] ON 

INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (1, N'Claude', N'Murray', CAST(N'2022-04-22T16:38:08.7636853' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7714327' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (2, N'Lamar', N'Sporer', CAST(N'2022-04-22T16:38:08.7723615' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7727438' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (3, N'Alicia', N'Murphy', CAST(N'2022-04-22T16:38:08.7729828' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7732037' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (4, N'Kirk', N'Stiedemann', CAST(N'2022-04-22T16:38:08.7734284' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7736909' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (5, N'Matthew', N'Abernathy', CAST(N'2022-04-22T16:38:08.7739325' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7742232' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (6, N'Elena', N'Okuneva', CAST(N'2022-04-22T16:38:08.7744511' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7746712' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (7, N'Luz', N'Feest', CAST(N'2022-04-22T16:38:08.7748969' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7751223' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (8, N'Kenneth', N'Conn', CAST(N'2022-04-22T16:38:08.7753336' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7755557' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (9, N'Jeffery', N'Collins', CAST(N'2022-04-22T16:38:08.7757921' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7760053' AS DateTime2), N'PayneK', 0)
INSERT [dbo].[Contact1] ([ContactId], [FirstName], [LastName], [LastUpdated], [LastUser], [CreatedAt], [CreatedBy], [isDeleted]) VALUES (10, N'Seth', N'Sipes', CAST(N'2022-04-22T16:38:08.7762164' AS DateTime2), N'PayneK', CAST(N'2022-04-22T16:38:08.7764254' AS DateTime2), N'PayneK', 0)
SET IDENTITY_INSERT [dbo].[Contact1] OFF
USE [master]
GO
ALTER DATABASE [EF.ShadowEntityCore] SET  READ_WRITE 
GO
