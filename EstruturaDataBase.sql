USE [master]
GO

/****** Object:  Database [TechChallengeFIAP]    Script Date: 23/05/2024 22:54:33 ******/
CREATE DATABASE [TechChallengeFIAP]

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
EXEC sys.sp_db_vardecimal_storage_format N'TechChallengeFIAP', N'ON'
GO
ALTER DATABASE [TechChallengeFIAP] SET QUERY_STORE = OFF
GO
USE [TechChallengeFIAP]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 23/05/2024 22:54:33 ******/
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
/****** Object:  Table [dbo].[Cliente]    Script Date: 23/05/2024 22:54:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cpf] [varchar](11) NULL,
	[Nome] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[DataNascimento] [datetime] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 23/05/2024 22:54:33 ******/
SET ANSI_NULLS ON
GO

CREATE TABLE [dbo].[TipoGatewayPagamento]
(
   [Id] [int] IDENTITY(1,1) NOT NULL,
   [IdTipo] [int] NOT NULL,
   [Descricao] VARCHAR(50) NOT NULL
)

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdStatusEtapa] [int] NULL,
	[IdStatusPagamento] [int] NOT NULL,
	[IdTipoGatewayPagamento] [int] NOT NULL,
	[ValorTotal] [decimal](18, 2) NOT NULL,
	[QrData] [varchar](max) NULL,
	[IdPedidoExternal] [varchar](max) NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoProdutos]    Script Date: 23/05/2024 22:54:33 ******/
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
/****** Object:  Table [dbo].[PedidoStatusEtapa]    Script Date: 23/05/2024 22:54:33 ******/
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
/****** Object:  Table [dbo].[Produto]    Script Date: 23/05/2024 22:54:33 ******/
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
/****** Object:  Table [dbo].[ProdutoImagens]    Script Date: 23/05/2024 22:54:33 ******/
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
/****** Object:  Table [dbo].[StatusPagamento]    Script Date: 23/05/2024 22:54:33 ******/
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
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([IdTipoGatewayPagamento])
REFERENCES [dbo].[TipoGatewayPagamento] ([Id])

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
ALTER TABLE [dbo].[ProdutoImagens]  WITH CHECK ADD FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([Id])
GO
USE [master]
GO
ALTER DATABASE [TechChallengeFIAP] SET  READ_WRITE 
GO

use TechChallengeFIAP
go
--DOMINIOS
INSERT INTO categoria (nome)
values('Lanche')
GO
INSERT INTO categoria (nome)
values('Acompanhamento')
GO
INSERT INTO categoria (nome)
values('Bebida')
GO
INSERT INTO categoria (nome)
values('Sobremesa')
GO
insert into PedidoStatusEtapa(descricao)
values('Recebido')
GO
insert into PedidoStatusEtapa(descricao)
values('Em Preparação')
GO
insert into PedidoStatusEtapa(descricao)
values('Pronto')
GO
insert into PedidoStatusEtapa(descricao)
values('Finalizado')

GO
insert into StatusPagamento(Descricao)
values('Pendente')
GO
insert into StatusPagamento(Descricao)
values('Pago')

go

-- Limpa a tabela Produto antes de inserir novos dados
DELETE FROM [dbo].[Produto];

-- Variáveis para armazenar nomes e descrições dos produtos
DECLARE @ProdutoNomes TABLE (IdCategoria INT, Nome VARCHAR(50), Descricao VARCHAR(50));
INSERT INTO @ProdutoNomes (IdCategoria, Nome, Descricao) VALUES
(1, 'Hamburguer', 'Delicioso hamburguer artesanal'),
(1, 'Cheeseburguer', 'Hamburguer com queijo cheddar'),
(1, 'Frango Frito', 'Frango crocante e suculento'),
(1, 'Hot Dog', 'Cachorro quente com molho especial'),
(1, 'Pizza', 'Pizza de queijo e pepperoni'),
(1, 'Tacos', 'Tacos recheados com carne e queijo'),
(1, 'Quesadilla', 'Quesadilla com frango e queijo'),
(1, 'Nachos', 'Nachos com queijo derretido e guacamole'),
(1, 'Burrito', 'Burrito de carne com feijão e arroz'),
(1, 'Sushi', 'Sushi variado de peixe fresco'),
(2, 'Batata Frita', 'Batata frita crocante'),
(2, 'Salada', 'Salada fresca com diversos legumes'),
(2, 'Onion Rings', 'Anéis de cebola empanados e fritos'),
(2, 'Batata Assada', 'Batata assada com recheio de creme de leite'),
(2, 'Mozzarella Sticks', 'Palitos de mozzarella empanados e fritos'),
(2, 'Coxinha', 'Coxinha de frango com catupiry'),
(2, 'Kibe', 'Kibe frito com recheio de carne'),
(2, 'Esfiha', 'Esfiha aberta de carne'),
(2, 'Pastel', 'Pastel de queijo e presunto'),
(2, 'Bolinho de Bacalhau', 'Bolinho de bacalhau frito'),
(3, 'Refrigerante', 'Refrigerante de cola gelado'),
(3, 'Suco de Laranja', 'Suco natural de laranja'),
(3, 'Água Mineral', 'Água mineral sem gás'),
(3, 'Café', 'Café preto sem açúcar'),
(3, 'Chá Gelado', 'Chá gelado de limão'),
(3, 'Smoothie', 'Smoothie de frutas vermelhas'),
(3, 'Milkshake', 'Milkshake de chocolate com chantilly'),
(3, 'Limonada', 'Limonada fresca e gelada'),
(3, 'Cerveja', 'Cerveja artesanal'),
(3, 'Vinho', 'Taça de vinho tinto'),
(4, 'Sorvete', 'Sorvete de baunilha com cobertura de chocolate'),
(4, 'Bolo de Chocolate', 'Bolo de chocolate com recheio de brigadeiro'),
(4, 'Pudim', 'Pudim de leite condensado com calda de caramelo'),
(4, 'Torta de Maçã', 'Torta de maçã com canela'),
(4, 'Mousse de Maracujá', 'Mousse de maracujá com cobertura de chantilly'),
(4, 'Brigadeiro', 'Brigadeiro de chocolate granulado'),
(4, 'Beijinho', 'Beijinho de coco com cravo'),
(4, 'Palha Italiana', 'Palha italiana de chocolate com biscoito'),
(4, 'Petit Gateau', 'Petit gateau com sorvete de baunilha'),
(4, 'Creme Brulee', 'Creme brulee com crosta de açúcar queimado');

-- Insere dados reais na tabela Produto
DECLARE @i INT = 1;

-- Loop para inserir 50 produtos
WHILE @i <= 50
BEGIN
    -- Seleciona um produto aleatório da tabela @ProdutoNomes
    INSERT INTO [dbo].[Produto] (IdCategoriaProduto, Nome, Descricao, Valor)
    SELECT TOP 1 IdCategoria, Nome, Descricao, 
        -- Valor aleatório entre 1.00 e 100.00
        CAST(ROUND(RAND(CHECKSUM(NEWID())) * 100, 2) AS DECIMAL(18, 2))
    FROM @ProdutoNomes
    ORDER BY NEWID();

    SET @i = @i + 1;
END

GO
insert into TipoGatewayPagamento(IdTipo, Descricao)
values(1,'MercadoPago')
GO
insert into TipoGatewayPagamento(IdTipo, Descricao)
values(2,'Paypal')
