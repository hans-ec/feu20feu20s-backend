SELECT 
	Users.Id, 
	Users.FirstName, 
	Users.LastName, 
	Users.Email, 
	Addresses.AddressLine, 
	Addresses.ZipCode, 
	Addresses.City 
FROM Users 
JOIN Addresses ON Users.AddressId = Addresses.Id