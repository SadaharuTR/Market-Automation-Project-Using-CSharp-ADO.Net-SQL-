USE [master]
GO
/****** Object:  Database [MarketDatabase]    Script Date: 5.11.2022 15:48:25 ******/
CREATE DATABASE [MarketDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MarketDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MarketDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MarketDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MarketDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MarketDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MarketDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MarketDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MarketDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MarketDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MarketDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MarketDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [MarketDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MarketDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MarketDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MarketDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MarketDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MarketDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MarketDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MarketDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MarketDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MarketDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MarketDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MarketDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MarketDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MarketDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MarketDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MarketDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MarketDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MarketDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MarketDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [MarketDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MarketDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MarketDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MarketDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MarketDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MarketDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MarketDatabase] SET QUERY_STORE = OFF
GO
USE [MarketDatabase]
GO
/****** Object:  Table [dbo].[loginTable]    Script Date: 5.11.2022 15:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loginTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kullaniciAdi] [varchar](50) NOT NULL,
	[sifre] [varchar](30) NOT NULL,
	[yetki] [varchar](30) NOT NULL,
	[bolge] [varchar](50) NULL,
	[emailAdres] [varchar](100) NOT NULL,
	[guvenlikSorusu] [varchar](200) NULL,
	[guvenlikCevabi] [varchar](50) NULL,
 CONSTRAINT [PK_loginTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unique_user] UNIQUE NONCLUSTERED 
(
	[kullaniciAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[urun]    Script Date: 5.11.2022 15:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[urun](
	[id] [varchar](10) NOT NULL,
	[qrkod] [varchar](50) NULL,
	[barkodKod] [varchar](50) NULL,
	[olusturulma_Tarih] [datetime] NULL,
	[guncellenme_Tarih] [datetime] NULL,
	[urunIsim] [varchar](50) NULL,
	[kilo] [float] NULL,
	[fiyat] [int] NULL,
	[ciro] [int] NULL,
 CONSTRAINT [PK_urun] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unique_barkod] UNIQUE NONCLUSTERED 
(
	[barkodKod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[guvenlikSorusuGetir_sp]    Script Date: 5.11.2022 15:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[guvenlikSorusuGetir_sp]
as
begin
	select * from loginTable
end
GO
/****** Object:  StoredProcedure [dbo].[login_sp]    Script Date: 5.11.2022 15:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[login_sp]
(
@kullaniciAdi varchar(50),
@sifre varchar(30)
)
as
begin
	select count(*) from loginTable where kullaniciAdi = @kullaniciAdi and sifre = @sifre
	--koşulu sağlayan kayıt varsa 1 döner. yoksa sıfır döner. Çünkü iki değerin de eşleşmesi lazım.
end
GO
/****** Object:  StoredProcedure [dbo].[sifreGuncelle_sp]    Script Date: 5.11.2022 15:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sifreGuncelle_sp]
(
@kullaniciAdi varchar(50),
@sifre varchar(30)
)
as
begin
	update loginTable set sifre=@sifre where kullaniciAdi = @kullaniciAdi
end
GO
/****** Object:  StoredProcedure [dbo].[sp_kullaniciEkle]    Script Date: 5.11.2022 15:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_kullaniciEkle]
(
@kullaniciAdi varchar(50),
@sifre varchar(30),
@yetki varchar(20),
@bolge varchar(50),
@emailAdres varchar(100),
@guvenlikSorusu varchar(200),
@guvenlikCevabi varchar(70)
)
as
begin
	insert into loginTable (kullaniciAdi, sifre, yetki , bolge, emailAdres, guvenlikSorusu, guvenlikCevabi)
	values(@kullaniciAdi, @sifre, @yetki, @bolge, @emailAdres, @guvenlikSorusu, @guvenlikCevabi)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_kullaniciGuncelle]    Script Date: 5.11.2022 15:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_kullaniciGuncelle]
(
@id varchar(50),
@kullaniciAdi varchar(50),
@sifre varchar(30),
@yetki varchar(20),
@bolge varchar(50),
@emailAdres varchar(100),
@guvenlikSorusu varchar(200),
@guvenlikCevabi varchar(70)
)
as
begin
	update loginTable set kullaniciAdi=@kullaniciAdi, sifre=@sifre, 
	yetki=@yetki , bolge=@bolge, emailAdres=@emailAdres, 
	guvenlikSorusu=@guvenlikSorusu, guvenlikCevabi=@guvenlikCevabi
	where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_urunEkle]    Script Date: 5.11.2022 15:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_urunEkle]
(
@id varchar(10),
@qrkod varchar(50),
@barkodKod varchar(10),
@olusturulma_Tarih datetime,
@guncellenme_Tarih datetime,
@urunIsim varchar(50),
@kilo float,
@fiyat int,
@ciro int
)
as
begin
	insert into urun values(@id, @qrkod,@barkodKod,@olusturulma_Tarih,@guncellenme_Tarih,@urunIsim,@kilo,@fiyat,@ciro)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_urunGuncelle]    Script Date: 5.11.2022 15:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_urunGuncelle]
(
@id varchar(10),
@qrkod varchar(50),
@barkodKod varchar(10),
@olusturulma_Tarih datetime,
@guncellenme_Tarih datetime,
@urunIsim varchar(50),
@kilo float,
@fiyat int,
@ciro int
)
as
begin
	update urun set qrkod=@qrkod, barkodKod=@barkodKod, olusturulma_tarih=@olusturulma_Tarih,
	guncellenme_Tarih=@guncellenme_Tarih, urunIsim=@urunIsim, kilo=@kilo,fiyat=@fiyat,ciro=@ciro
	where id=@id
end
GO
USE [master]
GO
ALTER DATABASE [MarketDatabase] SET  READ_WRITE 
GO
