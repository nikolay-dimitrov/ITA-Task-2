USE [master]
GO
/****** Object:  Database [HRModule]    Script Date: 29-Feb-16 12:26:57 ******/
CREATE DATABASE [HRModule]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HRModule', FILENAME = N'C:\Programs\Microsoft SQL Server 2012\Install\MSSQL11.MSSQLSERVER\MSSQL\DATA\HRModule.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HRModule_log', FILENAME = N'C:\Programs\Microsoft SQL Server 2012\Install\MSSQL11.MSSQLSERVER\MSSQL\DATA\HRModule_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HRModule] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HRModule].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HRModule] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HRModule] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HRModule] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HRModule] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HRModule] SET ARITHABORT OFF 
GO
ALTER DATABASE [HRModule] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HRModule] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [HRModule] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HRModule] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HRModule] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HRModule] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HRModule] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HRModule] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HRModule] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HRModule] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HRModule] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HRModule] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HRModule] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HRModule] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HRModule] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HRModule] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HRModule] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HRModule] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HRModule] SET RECOVERY FULL 
GO
ALTER DATABASE [HRModule] SET  MULTI_USER 
GO
ALTER DATABASE [HRModule] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HRModule] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HRModule] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HRModule] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HRModule', N'ON'
GO
USE [HRModule]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 29-Feb-16 12:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PositionId] [int] NOT NULL,
	[Salary] [money] NOT NULL,
	[WorkPlace] [nvarchar](50) NULL,
	[Email] [ntext] NULL,
	[Phone] [text] NULL,
	[ProjectId] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Position]    Script Date: 29-Feb-16 12:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 29-Feb-16 12:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [Salary], [WorkPlace], [Email], [Phone], [ProjectId]) VALUES (18, N'Vili', 4, 2000.0000, N'Over the Rainbow', N'vili@ss.com', N'132131', NULL)
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [Salary], [WorkPlace], [Email], [Phone], [ProjectId]) VALUES (19, N'Nikolay', 1, 1000.0000, N'Sofia', N'NIkolay@ss.com', N'1234567', 6)
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [Salary], [WorkPlace], [Email], [Phone], [ProjectId]) VALUES (20, N'Zombie', 4, 5555.0000, N'BGO', N'ddd@ddd.ddd', N'45124', 6)
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [Salary], [WorkPlace], [Email], [Phone], [ProjectId]) VALUES (21, N'Mepho', 2, 7878.0000, N'Over the rainbow', N'dadsa@dsa.hh', N'6666', 1)
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [Salary], [WorkPlace], [Email], [Phone], [ProjectId]) VALUES (22, N'testov', 3, 7777.0000, N'dsad', N'ddsa', N'321312', 1)
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [Salary], [WorkPlace], [Email], [Phone], [ProjectId]) VALUES (23, N'Joro', 6, 777777.0000, N'Tam', N'dsa', N'321312', NULL)
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [Salary], [WorkPlace], [Email], [Phone], [ProjectId]) VALUES (24, N'Vasko', 7, 6666.0000, N'dada', N'dada', N'321312312', 6)
INSERT [dbo].[Employee] ([Id], [Name], [PositionId], [Salary], [WorkPlace], [Email], [Phone], [ProjectId]) VALUES (25, N'Deyan', 5, 5555.0000, N'dsadsa', N'dsa', N'321312', NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Position] ON 

INSERT [dbo].[Position] ([Id], [Name]) VALUES (1, N'Trainee')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (2, N'Junior')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (3, N'Intermediate')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (4, N'Senior')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (5, N'TL')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (6, N'PM')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (7, N'DD')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (8, N'CEO')
SET IDENTITY_INSERT [dbo].[Position] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Name]) VALUES (1, N'Test Project')
INSERT [dbo].[Project] ([Id], [Name]) VALUES (6, N'HR Project')
SET IDENTITY_INSERT [dbo].[Project] OFF
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Position]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Project]
GO
USE [master]
GO
ALTER DATABASE [HRModule] SET  READ_WRITE 
GO
