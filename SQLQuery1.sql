use master

GO

if exists(select * FROM sys.database where name = 'brasilenha')
	drop database brasilenha

go

create database brasilenha
go

use brasilenha
go

create table Usuario (
	ID int identity primary key,
	Nome varchar(100) not null,
	Email varchar(100) not null,
	Senha varchar(MAX) not null,
	Salt varchar(200) not null,
	isADM tinyint not null,

)

create table Imagem (
	ID int identity primary key,
	Foto varbinary(MAX) not null
);
go

create table Produto(
	ID int identity primary key,
	NomeProduto varchar(100) not null,
	ImagemID int references Imagem(ID) not null,
	Descrição varchar(400) not null,
	Valor decimal (5,2),
);
go

create table Pedido(
	ID int identity primary key,
	CodigoPedido varchar(12) not null,

)

create table PedidoProduto (
	ID int identity primary key,
	PedidoID int references Pedido(ID) not null,
	ProdutoID int references Produto(ID)
)

create table Cupom (
	ID int identity primary key,
	Codigo varchar(12) not null
)
