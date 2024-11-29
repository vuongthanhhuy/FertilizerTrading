using FertilizerTradingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilizerTradingApp.Repository
{
	public class LoginRepository
	{
		private readonly string _connectionString;
		public LoginRepository(string connectionString)
		{
			_connectionString = connectionString;
		}
		public string GetAccountLogin(string username)
		{
			string storedHashedPassword;
			using (var connection = new SqlConnection(_connectionString))
			{
				var query = "SELECT _password FROM _Account WHERE _username = @username";
				var command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@username", username);

				connection.Open();
				using (var reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						storedHashedPassword = reader["_password"].ToString();
					}
					else
					{
						storedHashedPassword = null;
					}
				}
			}
			return storedHashedPassword;
		}
        public bool UpdatePassword(string username, string newHashedPassword)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var query = "UPDATE _Account SET _password = @password WHERE _username = @username";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", newHashedPassword);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating password: " + ex.Message);
            }
        }
    }
}
