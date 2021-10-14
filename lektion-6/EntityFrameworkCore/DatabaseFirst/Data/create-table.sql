CREATE TABLE Addresses (
	Id int not null identity primary key,
	AddressLine nvarchar(150) not null,
	ZipCode nvarchar(6) not null,
	City nvarchar(100) not null
)
GO

CREATE TABLE Users (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(100) not null unique,
	Password nvarchar(100) not null,
	AddressId int not null references Addresses(Id)
)