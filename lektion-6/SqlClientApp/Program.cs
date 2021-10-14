using SqlClientApp.Models;
using System;
using System.Data.SqlClient;

namespace SqlClientApp
{
    /*
        CRUD                        =  CREATE READ UPDATE DELETE
        HTTP Methods                =  POST, GET, PUT, DELETE

        cmd.ExecuteNonQuery()       =  används för CREATE, UPDATE, DELETE
        cmd.ExecuteScalar()         =  används för att hämta ett värde såsom Id, men hämtar endast värdet från första kolumnen från första raden oavsett hur många rader du än har.
        cmd.ExecuteReader()         =  används för READ och du får en lista med en eller flera rader i

    */

    class Program
    {
        private static readonly string _connectionString = @"ENTER_YOUR_SQL_CONNECTIONSTRING_HERE";

        static void Main(string[] args)
        {
            //Insert(new Product { Name = "Product 5", Description = "Description for Product 5", Price = 100 });
            //SelectAll();
            //SelectOneId_ByName("Product 5");
            //SelectOne_ById(3);
        }



        #region methods

        static void Insert(Product product)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using var cmd = new SqlCommand("INSERT INTO Products (Name, Description, Price) VALUES (@Name, @Description, @Price)", conn);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.ExecuteNonQuery();

                Console.WriteLine("1 Product Added to Database.");
            };        
        }

        static void SelectAll()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using var cmd = new SqlCommand("SELECT * FROM Products", conn);
                var results = cmd.ExecuteReader();

                while(results.Read())
                {
                    Console.WriteLine($"Id: {results.GetValue(0)}, {results.GetValue(1)}\nPrice: {results.GetValue(3)}kr\n{results.GetValue(2)}\n");
                }
            };
        }

        static void SelectOneId_ByName(string name)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using var cmd = new SqlCommand("SELECT Id FROM Products WHERE Name = @Name", conn);
                cmd.Parameters.AddWithValue("@Name", name);
                var results = cmd.ExecuteScalar();

                Console.WriteLine($"Product Id = {results}");
                
            };
        }

        static void SelectOne_ById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using var cmd = new SqlCommand("SELECT * FROM Products WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                var results = cmd.ExecuteReader();

                while (results.Read())
                {
                    Console.WriteLine($"Id: {results.GetValue(0)}, {results.GetValue(1)}\nPrice: {results.GetValue(3)}kr\n{results.GetValue(2)}\n");
                }

            };
        }



        #endregion





    }
}
