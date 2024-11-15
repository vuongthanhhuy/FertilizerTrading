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
	}
}
