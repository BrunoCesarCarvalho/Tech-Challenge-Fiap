USE [master]
GO
/****** Object:  Database [TechChallengeFIAP]    Script Date: 13/05/2024 22:29:54 ******/
CREATE DATABASE [TechChallengeFIAP]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'Cliente', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Cliente.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'Cliente_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Cliente_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
-- WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TechChallengeFIAP] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TechChallengeFIAP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TechChallengeFIAP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET ARITHABORT OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TechChallengeFIAP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TechChallengeFIAP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TechChallengeFIAP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TechChallengeFIAP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TechChallengeFIAP] SET  MULTI_USER 
GO
ALTER DATABASE [TechChallengeFIAP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TechChallengeFIAP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TechChallengeFIAP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TechChallengeFIAP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TechChallengeFIAP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TechChallengeFIAP] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TechChallengeFIAP] SET QUERY_STORE = OFF
GO
USE [TechChallengeFIAP]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 13/05/2024 22:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 13/05/2024 22:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cpf] [varchar](11) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Cliente__A9D10534AFEB410A] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 13/05/2024 22:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdStatusEtapa] [int] NULL,
	[IdStatusPagamento] [int] NOT NULL,
	[ValorTotal] [decimal](18, 2) NOT NULL,
	[QrData] [varchar](max) NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoProdutos]    Script Date: 13/05/2024 22:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoProdutos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPedido] [int] NOT NULL,
	[IdProduto] [int] NOT NULL,
	[Quantidade] [int] NOT NULL,
 CONSTRAINT [PK_PedidoProdutos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoStatusEtapa]    Script Date: 13/05/2024 22:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoStatusEtapa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PedidoEtapa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 13/05/2024 22:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoriaProduto] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProdutoImagens]    Script Date: 13/05/2024 22:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdutoImagens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProduto] [int] NOT NULL,
	[Foto] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_ProdutoImagens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusPagamento]    Script Date: 13/05/2024 22:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusPagamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StatusPagamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK__Pedido__IdClient__46E78A0C] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK__Pedido__IdClient__46E78A0C]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK__Pedido__IdStatus__48CFD27E] FOREIGN KEY([IdStatusEtapa])
REFERENCES [dbo].[PedidoStatusEtapa] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK__Pedido__IdStatus__48CFD27E]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK__Pedido__IdStatus__4E88ABD4] FOREIGN KEY([IdStatusPagamento])
REFERENCES [dbo].[StatusPagamento] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK__Pedido__IdStatus__4E88ABD4]
GO
ALTER TABLE [dbo].[PedidoProdutos]  WITH CHECK ADD  CONSTRAINT [FK__PedidoPro__IdPed__5AEE82B9] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[PedidoProdutos] CHECK CONSTRAINT [FK__PedidoPro__IdPed__5AEE82B9]
GO
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [Produto_Categoria_FK] FOREIGN KEY([IdCategoriaProduto])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [Produto_Categoria_FK]
GO
ALTER TABLE [dbo].[ProdutoImagens]  WITH CHECK ADD FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([Id])
GO
USE [master]
GO
ALTER DATABASE [TechChallengeFIAP] SET  READ_WRITE 
GO
