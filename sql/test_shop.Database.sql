USE [master]
GO
/****** Object:  Database [test_shop]    Script Date: 09.03.2020 8:17:34 ******/
CREATE DATABASE [test_shop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'test_shop', FILENAME = N'E:\SQL\MSSQL14.SQLEXPRESS\MSSQL\DATA\test_shop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'test_shop_log', FILENAME = N'E:\SQL\MSSQL14.SQLEXPRESS\MSSQL\DATA\test_shop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [test_shop] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [test_shop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [test_shop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [test_shop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [test_shop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [test_shop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [test_shop] SET ARITHABORT OFF 
GO
ALTER DATABASE [test_shop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [test_shop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [test_shop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [test_shop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [test_shop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [test_shop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [test_shop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [test_shop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [test_shop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [test_shop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [test_shop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [test_shop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [test_shop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [test_shop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [test_shop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [test_shop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [test_shop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [test_shop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [test_shop] SET  MULTI_USER 
GO
ALTER DATABASE [test_shop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [test_shop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [test_shop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [test_shop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [test_shop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [test_shop] SET QUERY_STORE = OFF
GO
ALTER DATABASE [test_shop] SET  READ_WRITE 
GO
