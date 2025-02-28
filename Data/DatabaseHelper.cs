using MySql.Data.MySqlClient;
using MyIncomeExpenseApp.Models;
using Microsoft.Extensions.Configuration;

namespace MyIncomeExpenseApp.Data
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Fetch users from MySQL database
        public List<User> GetUsers()
        {
            var users = new List<User>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Users";  // Change this query to match your actual table name
                var cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        UserID = reader.GetInt32("UserID"),
                        Username = reader.GetString("Username"),
                        Password = reader.GetString("Password"),  // Consider password hashing in real systems
                        Email = reader.GetString("Email"),
                        CreatedAt = reader.GetDateTime("CreatedAt")
                    });
                }
            }

            return users;
        }
    }
}
