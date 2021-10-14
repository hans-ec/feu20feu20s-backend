CREATE TABLE Addresses (
	Id int not null identity primary key,
	AddressLine nvarchar(150) not null,
	ZipCode varchar(10) not null,
	City nvarchar(50) not null
)
GO

CREATE TABLE Users (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null unique,
	AddressId int not null references Addresses(Id)
)