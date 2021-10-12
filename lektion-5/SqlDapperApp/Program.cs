using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using SqlDapperApp.Models;

namespace SqlDapperApp
{
    class Program
    {
        private static readonly string _connectionString = @"S";

        static void Main(string[] args)
        {

            //InsertOne(new CreateUserModel { FirstName = "Tommy", LastName = "Mattin-Lassei", Email = "tommy@domain.com" });
            //SelectAll();
            //SelectOne_ByEmail("hans@domain.com");
            //SelectOne_ById(2);
            //SelectId_ByEmail("hans@domain.com");

            SelectAll();
            UpdateEmail(1, "hans.mattin-lassei@domain.com");
            UpdateEmail(new UpdateUserEmailModel { SearchId = 2, Email = "tommy.mattin-lassei@domain.com" });
            SelectAll();
        }


        #region Methods

        static void InsertOne(CreateUserModel model)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute("INSERT INTO Users (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email)", model);
                Console.WriteLine("1 User has been added to the Database");
            }
        }

        static void SelectAll()
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var results = conn.Query<User>("SELECT * FROM Users").ToList();
                foreach (var user in results)
                {
                    Console.WriteLine($"UserId: {user.Id}\n{user.FullName}\n{user.Email}\n");
                }
                    
            }
        }

        static void SelectOne_ByEmail(string email)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var result = conn.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Email = @Email", new { Email = email });
                Console.WriteLine($"UserId: {result.Id}\n{result.FullName}\n{result.Email}\n");
            }
        }

        static void SelectOne_ById(int id)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var result = conn.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });
                Console.WriteLine($"UserId: {result.Id}\n{result.FullName}\n{result.Email}\n");
            }
        }

        static void SelectId_ByEmail(string email)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var result = conn.QueryFirstOrDefault<int>("SELECT Id FROM Users WHERE Email = @Email", new { Email = email });
                Console.WriteLine($"UserId: {result}\n");
            }
        }


        static void UpdateEmail(int id, string email)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute("UPDATE Users SET Email = @Email WHERE Id = @SearchId", new { SearchId = id, Email = email });
                Console.WriteLine("1 User has been added to the Database");
            }
        }

        static void UpdateEmail(UpdateUserEmailModel model)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute("UPDATE Users SET Email = @Email WHERE Id = @SearchId", model);
                Console.WriteLine("1 User has been added to the Database");
            }
        }



        #endregion



    }
}
