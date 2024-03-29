USE [master]
GO
/****** Object:  Database [challengeintuit]    Script Date: 28/2/2024 18:36:41 ******/
CREATE DATABASE [challengeintuit] ON  PRIMARY 
( NAME = N'challengeintuit', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\challengeintuit.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'challengeintuit_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\challengeintuit_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [challengeintuit].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [challengeintuit] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [challengeintuit] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [challengeintuit] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [challengeintuit] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [challengeintuit] SET ARITHABORT OFF 
GO
ALTER DATABASE [challengeintuit] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [challengeintuit] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [challengeintuit] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [challengeintuit] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [challengeintuit] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [challengeintuit] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [challengeintuit] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [challengeintuit] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [challengeintuit] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [challengeintuit] SET  DISABLE_BROKER 
GO
ALTER DATABASE [challengeintuit] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [challengeintuit] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [challengeintuit] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [challengeintuit] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [challengeintuit] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [challengeintuit] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [challengeintuit] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [challengeintuit] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [challengeintuit] SET  MULTI_USER 
GO
ALTER DATABASE [challengeintuit] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [challengeintuit] SET DB_CHAINING OFF 
GO
USE [challengeintuit]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 28/2/2024 18:36:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	[FechaDeNacimiento] [date] NOT NULL,
	[CUIT] [varchar](20) NOT NULL,
	[Domicilio] [varchar](50) NOT NULL,
	[TelefonoCelular] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spActualizarCliente]    Script Date: 28/2/2024 18:36:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spActualizarCliente]
	-- Add the parameters for the stored procedure here
	@id as int,
	@Nombres as varchar(50),
	@Apellidos as varchar(100),
	@FechaDeNacimiento as date,
	@CUIT as varchar(20),
	@Domicilio as varchar(50),
	@TelefonoCelular as varchar(50),
	@Email as varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Clientes 
	SET
	Nombres = @Nombres,
	Apellidos = @Apellidos,
	FechaDeNacimiento = @FechaDeNacimiento,
	CUIT = @CUIT,
	Domicilio = @Domicilio,
	TelefonoCelular = @TelefonoCelular,
	Email = @Email
	where ID = @id
	
END
GO
/****** Object:  StoredProcedure [dbo].[spBuscarPorNombre]    Script Date: 28/2/2024 18:36:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spBuscarPorNombre]
	-- Add the parameters for the stored procedure here
	@nombre as varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 1 * FROM Clientes WHERE LOWER(Nombres) LIKE '%' + LOWER(@nombre) + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarCliente]    Script Date: 28/2/2024 18:36:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertarCliente] 
	-- Add the parameters for the stored procedure here
	@ID as int,
	@Nombres as varchar(50),
	@Apellidos as varchar(100),
	@FechaDeNacimiento as date,
	@CUIT as varchar(20),
	@Domicilio as varchar(50),
	@TelefonoCelular as varchar(50),
	@Email as varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Clientes 
	(Nombres,Apellidos,FechaDeNacimiento,CUIT,Domicilio,TelefonoCelular,Email)
	VALUES
	(@Nombres,@Apellidos,@FechaDeNacimiento,@CUIT, @Domicilio,@TelefonoCelular,@Email)
	
	DECLARE @NuevoClienteID AS INT
	SELECT @NuevoClienteID = SCOPE_IDENTITY()

	SET @ID = @NuevoClienteID

END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerClienteID]    Script Date: 28/2/2024 18:36:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spObtenerClienteID]
	-- Add the parameters for the stored procedure here
	@id as int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from Clientes where ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerClientes]    Script Date: 28/2/2024 18:36:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spObtenerClientes]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from Clientes
END
GO
USE [master]
GO
ALTER DATABASE [challengeintuit] SET  READ_WRITE 
GO
