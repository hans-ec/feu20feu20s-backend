using SqlDapperApp.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using SqlDapperApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SqlDapperApp
{
    class Program
    {
        private static readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\EC\FEU20-FEU20S\backend\lektion-6\Repetition\SqlDapperApp\Data\sqldapper_db.mdf;Integrated Security=True;Connect Timeout=30";

        static void Main(string[] args)
        {
            var user = new User();

            Console.Write("Förnamn: ");
                user.FirstName = Console.ReadLine();
            Console.Write("Efternamn: ");
                user.LastName = Console.ReadLine();
            Console.Write("E-Postadress: ");
                user.Email = Console.ReadLine();
            Console.Write("Gatuaddress: ");
                user.AddressLine = Console.ReadLine();
            Console.Write("Postnummer: ");
                user.ZipCode = Console.ReadLine();
            Console.Write("Ort: ");
                user.City = Console.ReadLine();


            var addressId = InsertAddress(new AddressEntity
            {
                AddressLine = user.AddressLine,
                ZipCode = user.ZipCode,
                City = user.City
            });

            var userId = InsertUser(new UserEntity
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                AddressId = addressId
            });

            foreach(var _user in SelectAll())
                Console.WriteLine($"{_user.Id} - {_user.FullName} ({_user.Email})\n{_user.FullAddress}\n");
        }


        static int InsertAddress(AddressEntity address)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            return int.Parse(conn.ExecuteScalar("IF NOT EXISTS (SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND ZipCode = @ZipCode) INSERT INTO Addresses (AddressLine, ZipCode, City) OUTPUT INSERTED.Id VALUES (@AddressLine, @ZipCode, @City) ELSE SELECT Id FROM Addresses WHERE AddressLine = @AddressLine AND ZipCode = @ZipCode", address).ToString());
        }

        static int InsertUser(UserEntity user)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            return int.Parse(conn.ExecuteScalar("IF NOT EXISTS (SELECT Id FROM Users WHERE Email = @Email) INSERT INTO Users (FirstName, LastName, Email, AddressId) OUTPUT INSERTED.Id VALUES (@FirstName, @LastName, @Email, @AddressId) ELSE SELECT Id FROM Users WHERE Email = @Email", user).ToString());
        }

        static List<User> SelectAll()
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            return conn.Query<User>("SELECT Users.Id, Users.FirstName, Users.LastName, Users.Email, Addresses.AddressLine, Addresses.ZipCode, Addresses.City FROM Users JOIN Addresses ON Users.AddressId = Addresses.Id").ToList();
        }
    }
}
