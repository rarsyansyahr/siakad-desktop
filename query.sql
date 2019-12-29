USE [master]
GO
/****** Object:  Database [db_siakad]    Script Date: 29/12/2019 20:54:50 ******/
CREATE DATABASE [db_siakad]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_siakad', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.RAR\MSSQL\DATA\db_siakad.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_siakad_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.RAR\MSSQL\DATA\db_siakad_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_siakad] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_siakad].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_siakad] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_siakad] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_siakad] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_siakad] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_siakad] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_siakad] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_siakad] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [db_siakad] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_siakad] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_siakad] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_siakad] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_siakad] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_siakad] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_siakad] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_siakad] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_siakad] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_siakad] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_siakad] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_siakad] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_siakad] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_siakad] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_siakad] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_siakad] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_siakad] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_siakad] SET  MULTI_USER 
GO
ALTER DATABASE [db_siakad] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_siakad] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_siakad] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_siakad] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [db_siakad]
GO
/****** Object:  UserDefinedTableType [dbo].[IDList]    Script Date: 29/12/2019 20:54:51 ******/
CREATE TYPE [dbo].[IDList] AS TABLE(
	[id] [tinyint] NULL
)
GO
/****** Object:  StoredProcedure [dbo].[SaveKRS]    Script Date: 29/12/2019 20:54:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SaveKRS]
	(@List as IDList READONLY)
as
begin
	set NOCOUNT ON;

	select id from @List;
end
GO
/****** Object:  Table [dbo].[dosen]    Script Date: 29/12/2019 20:54:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dosen](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[nidn] [char](10) NOT NULL,
	[nama] [varchar](30) NOT NULL,
	[alamat] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[nidn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kelas]    Script Date: 29/12/2019 20:54:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kelas](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[nama] [char](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[nama] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[krm]    Script Date: 29/12/2019 20:54:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[krm](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[iddosen] [tinyint] NOT NULL,
	[idmatakuliah] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[krs]    Script Date: 29/12/2019 20:54:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[krs](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[idmahasiswa] [smallint] NOT NULL,
	[idkrm] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[mahasiswa]    Script Date: 29/12/2019 20:54:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mahasiswa](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[nim] [char](10) NOT NULL,
	[nama] [varchar](30) NOT NULL,
	[alamat] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[nim] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[matakuliah]    Script Date: 29/12/2019 20:54:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[matakuliah](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[kode] [varchar](5) NOT NULL,
	[nama] [varchar](30) NOT NULL,
	[sks] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[kode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[pengguna]    Script Date: 29/12/2019 20:54:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[pengguna](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[nama] [varchar](30) NOT NULL,
	[username] [varchar](10) NULL,
	[password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[v_krm]    Script Date: 29/12/2019 20:54:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_krm] as
select krm.id, matakuliah.nama, matakuliah.sks, krm.iddosen from krm, matakuliah where matakuliah.id=krm.idmatakuliah
GO
/****** Object:  View [dbo].[v_krs]    Script Date: 29/12/2019 20:54:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_krs] as
select krs.id, concat(matakuliah.nama, ' (', matakuliah.sks, 'sks)') as matkul, dosen.nama as dosen, krs.idmahasiswa from krs, matakuliah, krm, dosen where krm.id=krs.idkrm and matakuliah.id=krm.idmatakuliah and dosen.id=krm.iddosen
GO
ALTER TABLE [dbo].[krm]  WITH CHECK ADD FOREIGN KEY([iddosen])
REFERENCES [dbo].[dosen] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[krm]  WITH CHECK ADD FOREIGN KEY([idmatakuliah])
REFERENCES [dbo].[matakuliah] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[krs]  WITH CHECK ADD FOREIGN KEY([idkrm])
REFERENCES [dbo].[krm] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[krs]  WITH CHECK ADD FOREIGN KEY([idmahasiswa])
REFERENCES [dbo].[mahasiswa] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [db_siakad] SET  READ_WRITE 
GO
