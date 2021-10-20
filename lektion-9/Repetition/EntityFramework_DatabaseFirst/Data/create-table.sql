DROP TABLE Products
DROP TABLE Categories

CREATE TABLE Categories (
	Id int not null identity primary key,
	Category nvarchar(50) not null unique
)
GO

CREATE TABLE Products (
	ArticleNumber varchar(15) not null primary key,
	Name varchar(200) not null,	
	Description nvarchar(200) not null,
	UnitPrice money not null,
	Vendor nvarchar(200) not null,
	CategoryId int not null references Categories(Id)
)
GO

INSERT INTO Categories VALUES ('Ljud & bild'),('Datorer')
INSERT INTO Products VALUES ('KE85XH9096BAEP','KD85XH9096 85" HDR 4K LED Smart-TV','Se detaljer bättre i både skuggiga och soliga områden, och hör ljud från rätt ställe på skärmen. Minimalistiska 4K Ultra HD TV är perfekt för dina favoritfilmer.',19999,'Sony',1)
