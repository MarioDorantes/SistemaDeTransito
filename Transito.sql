USE [master]
GO
/****** Object:  Database [SistemaTransito]    Script Date: 22/05/2021 01:32:29 p. m. ******/
CREATE DATABASE [SistemaTransito]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaTransito', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SistemaTransito.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SistemaTransito_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SistemaTransito_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SistemaTransito] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaTransito].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaTransito] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaTransito] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaTransito] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaTransito] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaTransito] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaTransito] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SistemaTransito] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaTransito] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaTransito] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaTransito] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaTransito] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaTransito] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaTransito] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaTransito] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaTransito] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SistemaTransito] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaTransito] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaTransito] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaTransito] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaTransito] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaTransito] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaTransito] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaTransito] SET RECOVERY FULL 
GO
ALTER DATABASE [SistemaTransito] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaTransito] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaTransito] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaTransito] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaTransito] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SistemaTransito] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SistemaTransito] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SistemaTransito', N'ON'
GO
ALTER DATABASE [SistemaTransito] SET QUERY_STORE = OFF
GO
USE [SistemaTransito]
GO
/****** Object:  Table [dbo].[conductor]    Script Date: 22/05/2021 01:32:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[conductor](
	[cnd_numLicencia] [nchar](30) NOT NULL,
	[cnd_telefono] [nchar](30) NOT NULL,
	[cnd_fechaNacimiento] [datetime] NOT NULL,
	[cnd_nombre] [nchar](10) NOT NULL,
	[cnd_apaterno] [nchar](10) NOT NULL,
	[cnd_amaterno] [nchar](10) NOT NULL,
 CONSTRAINT [PK_conductor] PRIMARY KEY CLUSTERED 
(
	[cnd_numLicencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[delegacion]    Script Date: 22/05/2021 01:32:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[delegacion](
	[dlm_codigopostal] [nchar](10) NOT NULL,
	[dlm_nombrealias] [nchar](10) NOT NULL,
	[dlm_calle] [nchar](10) NULL,
	[dlm_numero] [nchar](10) NULL,
	[dlm_colonia] [nchar](10) NULL,
	[dlm_municipio] [nchar](10) NOT NULL,
	[dlm_correo] [nchar](10) NOT NULL,
	[dlm_telefono] [nchar](10) NOT NULL,
 CONSTRAINT [PK_delegacion] PRIMARY KEY CLUSTERED 
(
	[dlm_nombrealias] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dictamen]    Script Date: 22/05/2021 01:32:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dictamen](
	[dcm_perito] [nchar](10) NOT NULL,
	[dcm_folio] [nchar](10) NOT NULL,
	[dcm_fecha] [datetime] NOT NULL,
	[dcm_hora] [nchar](10) NOT NULL,
	[dcm_descripcion] [ntext] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reporte]    Script Date: 22/05/2021 01:32:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reporte](
	[rpt_conductor] [nvarchar](max) NOT NULL,
	[rpt_vehiculo] [nvarchar](max) NOT NULL,
	[rpt_lugarsiniestro] [varchar](max) NOT NULL,
	[rpt_fotografias] [binary](50) NULL,
	[rpt_id] [nchar](10) NOT NULL,
 CONSTRAINT [PK_reporte] PRIMARY KEY CLUSTERED 
(
	[rpt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 22/05/2021 01:32:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[usr_nombreUsuario] [uniqueidentifier] NOT NULL,
	[usr_nombre] [nchar](20) NOT NULL,
	[usr_apaterno] [nchar](20) NOT NULL,
	[usr_amaterno] [nchar](20) NULL,
	[usr_cargo] [nchar](20) NOT NULL,
	[usr_contraseña] [nchar](30) NOT NULL,
	[usr_delegacion] [nchar](20) NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[usr_nombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vehiculo]    Script Date: 22/05/2021 01:32:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehiculo](
	[vhc_marca] [nchar](10) NULL,
	[vhc_modelo] [nchar](10) NULL,
	[vhc_año] [nchar](10) NULL,
	[vhc_aseguradora] [nchar](30) NOT NULL,
	[vhc_color] [nchar](10) NULL,
	[vhc_polizaseguro] [nchar](30) NOT NULL,
	[vhz_placas] [nchar](50) NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [SistemaTransito] SET  READ_WRITE 
GO
