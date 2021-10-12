CREATE TABLE Users (
	Id int not null identity primary key,
	FirstName nvarchar(max) not null,
	LastName nvarchar(max) not null,
	Email nvarchar(100) not null unique
)