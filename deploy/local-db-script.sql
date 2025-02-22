USE [master]
GO
/****** Object:  Database [gldb]    Script Date: 2/13/2025 5:26:25 PM ******/
CREATE DATABASE [gldb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gldb', FILENAME = N'C:\Users\SayokBose\gldb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'gldb_log', FILENAME = N'C:\Users\SayokBose\gldb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [gldb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gldb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gldb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [gldb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [gldb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [gldb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [gldb] SET ARITHABORT OFF 
GO
ALTER DATABASE [gldb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [gldb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gldb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gldb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gldb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [gldb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [gldb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gldb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [gldb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gldb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [gldb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gldb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gldb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gldb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gldb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gldb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [gldb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gldb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [gldb] SET  MULTI_USER 
GO
ALTER DATABASE [gldb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [gldb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gldb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gldb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [gldb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [gldb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [gldb] SET QUERY_STORE = OFF
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [user]    Script Date: 2/13/2025 5:26:26 PM ******/
CREATE LOGIN [gldbuser] WITH PASSWORD=N'password', DEFAULT_DATABASE=[gldb], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [gldbuser]
GO
USE [gldb]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 2/13/2025 5:26:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Exchange] [nvarchar](100) NOT NULL,
	[Ticker] [nvarchar](50) NOT NULL,
	[Isin] [char](12) NOT NULL,
	[Website] [nvarchar](255) NULL,
 CONSTRAINT [PK__Companie__3214EC0756D0A244] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (1, N'Apple Inc.', N'NASDAQ', N'AAPL', N'US0378331005', N'http://www.apple.com')
INSERT [dbo].[Companies] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (2, N'British Airways Plc', N'Pink Sheets', N'BAIRY', N'US1104193065', NULL)
INSERT [dbo].[Companies] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (3, N'Heineken NV', N'Euronext Amsterdam', N'HEIA', N'NL0000009165', NULL)
INSERT [dbo].[Companies] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (4, N'Panasonic Corp', N'Tokyo Stock Exchange', N'6752', N'JP3866800000', N'http://www.panasonic.co.jp')
INSERT [dbo].[Companies] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (5, N'Porsche Automobil', N'Deutsche Börse', N'PAH3', N'DE000PAH0038', N'https://www.porsche.com/')
INSERT [dbo].[Companies] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (6, N'Acme Corporation', N'NASDAQ', N'ACME', N'US1234567890', N'https://www.acme.com')
INSERT [dbo].[Companies] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (7, N'Global Tech Industries', N'NYSE', N'GTI', N'US0987654321', N'https://www.globaltechindustries.com')
INSERT [dbo].[Companies] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (8, N'Innovative Solutions', N'NASDAQ', N'INNO', N'US1122334455', N'https://www.innovativesolutions.com')
INSERT [dbo].[Companies] ([Id], [Name], [Exchange], [Ticker], [Isin], [Website]) VALUES (9, N'Tech Dynamics', N'NYSE', N'TDYN', N'US5566778899', N'')
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Companies_Isin]    Script Date: 2/13/2025 5:26:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Companies_Isin] ON [dbo].[Companies]
(
	[Isin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [gldb] SET  READ_WRITE 
GO
