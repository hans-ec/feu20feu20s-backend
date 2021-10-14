using SqlClientApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlClientApp
{
    class Program
    {
        private static readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\EC\FEU20-FEU20S\backend\lektion-6\Repetition\SqlClientApp\Data\sqlclient_db.mdf;Integrated Security=True;Connect Timeout=30";

        static void Main(string[] args) {

            var user = new UserModel
            {
                FirstName = "Anki",
                LastName = "Mattin-Lassei",
                Email = "anki@domain.com",
                AddressLine = "Svenby 1",
                ZipCode = "761 41",
                City = "Hallstahammar"
            };

            var addressId = InsertAddress(new Address 
            { 
                AddressLine = user.AddressLine, 
                ZipCode = user.ZipCode, 
                City = user.City 
            });

            var userId = InsertUser(new User 
            { 
                FirstName = user.FirstName, 
                LastName = user.LastName, 
                Email = user.Email, 
                AddressId = addressId 
            });
            
            var users = SelectAll();
            foreach (var _user in users)
                Console.WriteLine($"{_user.Id} - {_user.FullName} ({_user.Email})\n{_user.FullAddress}\n");
        }



        static int InsertAddress(Address address)
        {
            using var conn = new SqlConnection(_connectionString);
            
            conn.Open();
            using var cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND ZipCode = @ZipCode) INSERT INTO Addresses (AddressLine, ZipCode, City) OUTPUT INSERTED.Id VALUES (@AddressLine, @ZipCode, @City) ELSE SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND ZipCode = @ZipCode", conn);
            cmd.Parameters.AddWithValue("@AddressLine", address.AddressLine);
            cmd.Parameters.AddWithValue("@ZipCode", address.ZipCode);
            cmd.Parameters.AddWithValue("@City", address.City);

            return int.Parse(cmd.ExecuteScalar().ToString());
        }

        static int InsertUser(User user)
        {
            using var conn = new SqlConnection(_connectionString);

            conn.Open();
            using var cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Users WHERE Email = @Email) INSERT INTO Users (FirstName, LastName, Email, AddressId) OUTPUT INSERTED.Id VALUES (@FirstName, @LastName, @Email, @AddressId) ELSE SELECT Id FROM Users WHERE Email = @Email", conn);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@AddressId", user.AddressId);

            return int.Parse(cmd.ExecuteScalar().ToString());
        }

        static List<UserModel> SelectAll()
        {
            using var conn = new SqlConnection(_connectionString);

            conn.Open();
            using var cmd = new SqlCommand("SELECT Users.Id, Users.FirstName, Users.LastName, Users.Email, Addresses.AddressLine, Addresses.ZipCode, Addresses.City FROM Users JOIN Addresses ON Users.AddressId = Addresses.Id", conn);
            var results = cmd.ExecuteReader();

            var users = new List<UserModel>();

            while(results.Read())
            {
                users.Add(new UserModel
                {
                    Id = int.Parse(results.GetValue(0).ToString()),
                    FirstName = results.GetValue(1).ToString(),
                    LastName = results.GetValue(2).ToString(),
                    Email = results.GetValue(3).ToString(),
                    AddressLine = results.GetValue(4).ToString(),
                    ZipCode = results.GetValue(5).ToString(),
                    City = results.GetValue(6).ToString()
                });
            }

            return users;
        } 
    }
}
