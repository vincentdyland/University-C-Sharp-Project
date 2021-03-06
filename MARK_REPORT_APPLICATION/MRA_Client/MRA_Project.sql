USE [master]
GO
/****** Object:  Database [MRA_Project]    Script Date: 4/21/2021 11:33:47 AM ******/
CREATE DATABASE [MRA_Project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN292_ProjectFinal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.KEYT\MSSQL\DATA\PRN292_ProjectFinal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN292_ProjectFinal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.KEYT\MSSQL\DATA\PRN292_ProjectFinal_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MRA_Project] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MRA_Project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MRA_Project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MRA_Project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MRA_Project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MRA_Project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MRA_Project] SET ARITHABORT OFF 
GO
ALTER DATABASE [MRA_Project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MRA_Project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MRA_Project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MRA_Project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MRA_Project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MRA_Project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MRA_Project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MRA_Project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MRA_Project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MRA_Project] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MRA_Project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MRA_Project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MRA_Project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MRA_Project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MRA_Project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MRA_Project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MRA_Project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MRA_Project] SET RECOVERY FULL 
GO
ALTER DATABASE [MRA_Project] SET  MULTI_USER 
GO
ALTER DATABASE [MRA_Project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MRA_Project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MRA_Project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MRA_Project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MRA_Project] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MRA_Project] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MRA_Project', N'ON'
GO
ALTER DATABASE [MRA_Project] SET QUERY_STORE = OFF
GO
USE [MRA_Project]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 4/21/2021 11:33:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[roll] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[roll] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassDetail]    Script Date: 4/21/2021 11:33:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassDetail](
	[rollclass] [nchar](10) NOT NULL,
	[rollstudent] [nchar](10) NOT NULL,
 CONSTRAINT [PK_ClassDetail] PRIMARY KEY CLUSTERED 
(
	[rollclass] ASC,
	[rollstudent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrandItemDetail]    Script Date: 4/21/2021 11:33:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrandItemDetail](
	[rolltype] [nchar](10) NOT NULL,
	[rollsubject] [nchar](10) NOT NULL,
	[rollgranditemtype] [nchar](10) NOT NULL,
 CONSTRAINT [PK_GrandItemDetail] PRIMARY KEY CLUSTERED 
(
	[rolltype] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrandItemType]    Script Date: 4/21/2021 11:33:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrandItemType](
	[roll] [nchar](10) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[weight] [float] NOT NULL,
 CONSTRAINT [PK_GrandItemType] PRIMARY KEY CLUSTERED 
(
	[roll] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScoreDetail]    Script Date: 4/21/2021 11:33:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScoreDetail](
	[rollstudent] [nchar](10) NOT NULL,
	[rolltype] [nchar](10) NOT NULL,
	[score] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 4/21/2021 11:33:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[roll] [nchar](10) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[gender] [nvarchar](50) NOT NULL,
	[address] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[roll] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 4/21/2021 11:33:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[roll] [nchar](10) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[credit] [int] NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[roll] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectClass]    Script Date: 4/21/2021 11:33:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectClass](
	[rollteacher] [nchar](10) NULL,
	[rollsubject] [nchar](10) NOT NULL,
	[rollclass] [nchar](10) NOT NULL,
 CONSTRAINT [PK_SubjectClass] PRIMARY KEY CLUSTERED 
(
	[rollsubject] ASC,
	[rollclass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 4/21/2021 11:33:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[roll] [nchar](10) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[gender] [nvarchar](50) NOT NULL,
	[address] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[amount] [money] NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[roll] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClassDetail]  WITH CHECK ADD  CONSTRAINT [FK_ClassDetail_Class] FOREIGN KEY([rollclass])
REFERENCES [dbo].[Class] ([roll])
GO
ALTER TABLE [dbo].[ClassDetail] CHECK CONSTRAINT [FK_ClassDetail_Class]
GO
ALTER TABLE [dbo].[ClassDetail]  WITH CHECK ADD  CONSTRAINT [FK_ClassDetail_Student] FOREIGN KEY([rollstudent])
REFERENCES [dbo].[Student] ([roll])
GO
ALTER TABLE [dbo].[ClassDetail] CHECK CONSTRAINT [FK_ClassDetail_Student]
GO
ALTER TABLE [dbo].[GrandItemDetail]  WITH CHECK ADD  CONSTRAINT [FK_GrandItemDetail_GrandItemType] FOREIGN KEY([rollgranditemtype])
REFERENCES [dbo].[GrandItemType] ([roll])
GO
ALTER TABLE [dbo].[GrandItemDetail] CHECK CONSTRAINT [FK_GrandItemDetail_GrandItemType]
GO
ALTER TABLE [dbo].[GrandItemDetail]  WITH CHECK ADD  CONSTRAINT [FK_GrandItemDetail_Subject] FOREIGN KEY([rollsubject])
REFERENCES [dbo].[Subject] ([roll])
GO
ALTER TABLE [dbo].[GrandItemDetail] CHECK CONSTRAINT [FK_GrandItemDetail_Subject]
GO
ALTER TABLE [dbo].[ScoreDetail]  WITH CHECK ADD  CONSTRAINT [FK_ScoreDetail_GrandItemDetail] FOREIGN KEY([rolltype])
REFERENCES [dbo].[GrandItemDetail] ([rolltype])
GO
ALTER TABLE [dbo].[ScoreDetail] CHECK CONSTRAINT [FK_ScoreDetail_GrandItemDetail]
GO
ALTER TABLE [dbo].[ScoreDetail]  WITH CHECK ADD  CONSTRAINT [FK_ScoreDetail_Student] FOREIGN KEY([rollstudent])
REFERENCES [dbo].[Student] ([roll])
GO
ALTER TABLE [dbo].[ScoreDetail] CHECK CONSTRAINT [FK_ScoreDetail_Student]
GO
ALTER TABLE [dbo].[SubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectClass_Class] FOREIGN KEY([rollclass])
REFERENCES [dbo].[Class] ([roll])
GO
ALTER TABLE [dbo].[SubjectClass] CHECK CONSTRAINT [FK_SubjectClass_Class]
GO
ALTER TABLE [dbo].[SubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectClass_Subject] FOREIGN KEY([rollsubject])
REFERENCES [dbo].[Subject] ([roll])
GO
ALTER TABLE [dbo].[SubjectClass] CHECK CONSTRAINT [FK_SubjectClass_Subject]
GO
ALTER TABLE [dbo].[SubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectClass_Teacher] FOREIGN KEY([rollteacher])
REFERENCES [dbo].[Teacher] ([roll])
GO
ALTER TABLE [dbo].[SubjectClass] CHECK CONSTRAINT [FK_SubjectClass_Teacher]
GO
USE [master]
GO
ALTER DATABASE [MRA_Project] SET  READ_WRITE 
GO
