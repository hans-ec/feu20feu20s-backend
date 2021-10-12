/*
	DATA TYPES
	JS				C#								SQL
	--------------------------------------------------------------------------------------------
	String			string							char,nchar,varchar,nvarchar,text
	Number			int,double,decimal,long,float	bit,tinyint,smallint,int,bigint,money,float,decimal
	Boolean			bool (Boolean)					bit


	char(10)		B O _ _ _ _ _ _ _ _		1 byte		(10 byte)
	varchar(10)		B O						2 byte		(4 byte)
	nchar(10)		Å H _ _ _ _ _ _ _ _		2 byte		(20 byte)
	nvarchar(10)	Å H						4 byte		(8 byte)

	MSSQL		=	identity
	MySQL etc.	=	auto_increment
*/


DROP TABLE OrderLines
DROP TABLE Orders
DROP TABLE UserAddresses
DROP TABLE UserHashes
DROP TABLE Users
DROP TABLE Addresses
DROP TABLE DeliveryTypes
DROP TABLE Products
GO

CREATE TABLE Products (
	Id int not null identity primary key,
	Name nvarchar(150) not null,
	Description nvarchar(max) not null,
	Price money not null,
	InStock bit not null
)

CREATE TABLE DeliveryTypes (
	Id int not null identity primary key,
	Name nvarchar(50) not null unique
)

CREATE TABLE Addresses (
	Id int not null identity primary key,
	AddressLine nvarchar(100) not null,
	HouseNr smallint null,
	ZipCode char(5) not null,
	City nvarchar(50) not null
)

CREATE TABLE Users (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null unique
)
GO

CREATE TABLE UserHashes (
	UserId int not null references Users(Id) primary key,
	UserHash varchar(max) not null,
	UserSalt varchar(max) not null
)

CREATE TABLE UserAddresses (
	Id int not null identity primary key,
	UserId int not null references Users(Id),
	AddressId int not null references Addresses(Id)
)

CREATE TABLE Orders (
	Id int not null identity primary key,
	UserId int not null references Users(id),
	OrderDate datetimeoffset not null,
	OurReference nvarchar(100) null,
	Status nvarchar(50) not null,
	DeliveryTypeId int not null references DeliveryTypes(Id)
)
GO

CREATE TABLE OrderLines (
	OrderId int not null references Orders(Id),
	ProductId int not null references Products(Id),
	Quantity int not null default 1,
	UnitPrice money not null default 0

	primary key (OrderId, ProductId)
)
GO