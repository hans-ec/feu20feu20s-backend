DECLARE @FirstName nvarchar(50) SET @FirstName = 'Hans'
DECLARE @LastName nvarchar(50) SET @LastName = 'Mattin-Lassei'
DECLARE @Email varchar(100) SET @Email = 'hans@domain.com'
DECLARE @AddressLine nvarchar(50) SET @AddressLine = 'Nordkapsvägen 1'
DECLARE @ZipCode varchar(50) SET @ZipCode = '136 57'
DECLARE @City nvarchar(50) SET @City = 'Vega'
DECLARE @AddressId int SET @AddressId = 1

IF NOT EXISTS (SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND ZipCode = @ZipCode) INSERT INTO Addresses (AddressLine, ZipCode, City) OUTPUT INSERTED.Id VALUES (@AddressLine, @ZipCode, @City) ELSE SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND ZipCode = @ZipCode	
IF NOT EXISTS (SELECT Id FROM Users WHERE Email = @Email) INSERT INTO Users (FirstName, LastName, Email, AddressId) OUTPUT INSERTED.Id VALUES (@FirstName, @LastName, @Email, @AddressId) ELSE SELECT Id FROM Users WHERE Email = @Email
