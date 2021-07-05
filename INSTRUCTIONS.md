# Mercado Eletrônico
Projeto de conhecimentos

### Instruções

O projeto tem o intuito de avaliar como foi desenvolvido o projeto. Com isso, foi usado um documento fornecido pelo Mercado Eletrônico.

Para conseguir rodar o projeto é necessário:

<ul>
<li> Baixar o projeto</li>
<li>Instalar MS Sql Server express 2019</li>
<li>Configurar Connection String</li>
<li>Criar tabelas do projeto</li>
<li>Inserir registros iniciais</li>
</ol>



#### 0) Baixando o projeto
git clone https://github.com/rayanscs/me.git

#### 1) Instalando o MS Sql Server express 2019
Para obter o Microsoft LocalDB 2019 express, baixa no link https://go.microsoft.com/fwlink/?LinkID=866658 .

Execute o programa SQL2019-SSEI-Expr.
Selecione DownloadMedia.
Escolha o idioma.
Selecione opção LocalDB.
Será baixando outra instalação, então selecione a pasta para download.
Execute o dowwnload SqlLocalDB.

A Instalação irá ocorrer.

Pronto! Banco de dados instalado

#### 2) Configurando a connection string

No arquivo <b>appsettings.Development</b> dentro do projeto ME.Api, favor setar chave SqlServerConnectionString com "Server=(localdb)\\mssqllocaldb;Database=me;Trusted_Connection=True;MultipleActiveResultSets=true;" caso necessário para localhost.

Caso possua já alguma versão do Sql Server instalada em sua máquina, configure a connection string com o banco de dados me.

#### 3) Criando as tabelas necessárias

Para criar as tabelas do projeto, fazor executar os scripts na ordem:


**Criar banco de dados:** 
CREATE DATABASE me;

Caso preferir, pode criar o database pelo Visual Studio.

Após a instalação, no visual studio clique em View > SQL Server Object Explorer
No lado esquerdo da tela aparecerá uma aba.
Abra o seu localdb.
Clique com o botão direito na pasta databases e selecione "Add new database".
Dê o nome de "me" (sem as aspas e minusculo).
Clique com botão direito em cima do "me" e clique em "new query".
Irá aparecer no visual studio uma arquivo "SQLQuery1.sql".


<b>Criar tabela Pedidos: </b>

USE [me]
GO
CREATE TABLE [dbo].[Pedido] (
    [PedidoId]     INT      NOT NULL,
    [DataInclusao] DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([PedidoId] ASC)
);

**Criar tabela Itens:**

USE [me]
GO
CREATE TABLE [dbo].[Item] (
    [ItemId]        INT            IDENTITY (1, 1) NOT NULL,
    [Descricao]     VARCHAR (255)  NOT NULL,
    [PrecoUnitario] DECIMAL (5, 2) NOT NULL,
    [Quantidade]    INT            DEFAULT ((0)) NOT NULL,
    [PedidoId]      INT            NULL,
    PRIMARY KEY CLUSTERED ([ItemId] ASC),
    FOREIGN KEY ([PedidoId]) REFERENCES [dbo].[Pedido] ([PedidoId])
);


**Inserindo registros iniciais:**

USE [me]
GO
INSERT INTO [dbo].[Pedido] (PedidoId) values (123456);

USE [me]
GO
INSERT INTO [dbo].[Item] (Descricao, PrecoUnitario, Quantidade, PedidoId) values ("Item A", 10, 1, 123456);

USE [me]
GO
INSERT INTO [dbo].[Item] (Descricao, PrecoUnitario, Quantidade, PedidoId) values ("Item B", 5, 2, 123456);