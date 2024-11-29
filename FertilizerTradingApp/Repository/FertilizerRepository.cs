using FertilizerTradingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FertilizerTradingApp.Repository
{
	public class FertilizerRepository
	{
		private readonly string _connectionString;
		public FertilizerRepository(string connectionString)
		{
			_connectionString = connectionString;
		}
        public bool AddFertilizer(string name, float price, string category, int stock, string description)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "EXEC AddFertilizer @_description, @_name, @_category, @_price, @_stock";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@_description", description);
                command.Parameters.AddWithValue("@_name", name);
                command.Parameters.AddWithValue("@_category", category);
                command.Parameters.AddWithValue("@_price", price);
                command.Parameters.AddWithValue("@_stock", stock);
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
        public List<Fertilizer> GetAllFertilizers()
		{
			List<Fertilizer> fertilizers = new List<Fertilizer>();

			using (var connection = new SqlConnection(_connectionString))
			{
				var query = "SELECT * FROM _Fertilizer";
				var command = new SqlCommand(query, connection);

				connection.Open();

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var fertilizer = new Fertilizer
						(
							reader["fertilizer_id"].ToString(),
							reader["_name"].ToString(),
							Convert.ToSingle(reader["_price"]),
							reader["_category"].ToString(),
							Convert.ToInt32(reader["_stock"]),
							reader["_description"].ToString(),
							Convert.ToBoolean(reader["_isdeleted"])
						);

						fertilizers.Add(fertilizer);
					}
				}
			}

			return fertilizers;
		}
        public List<Fertilizer> GetAllFertilizersAvailble()
        {
            List<Fertilizer> fertilizers = new List<Fertilizer>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM _Fertilizer where _isdeleted = 0";
                var command = new SqlCommand(query, connection);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fertilizer = new Fertilizer
                        (
                            reader["fertilizer_id"].ToString(),
                            reader["_name"].ToString(),
                            Convert.ToSingle(reader["_price"]),
                            reader["_category"].ToString(),
                            Convert.ToInt32(reader["_stock"]),
                            reader["_description"].ToString(),
                            Convert.ToBoolean(reader["_isdeleted"])
                        );

                        fertilizers.Add(fertilizer);
                    }
                }
            }

            return fertilizers;
        }
        public Fertilizer GetFertilizerById(string id)
		{
			Fertilizer fertilizer = null;

			using (var connection = new SqlConnection(_connectionString))
			{
				var query = "SELECT * FROM _Fertilizer WHERE fertilizer_id = @id";
				var command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@id", id);

				connection.Open();

				using (var reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						fertilizer = new Fertilizer
						(
							reader["fertilizer_id"].ToString(),
							reader["_name"].ToString(),
							Convert.ToSingle(reader["_price"]),
							reader["_category"].ToString(),
							Convert.ToInt32(reader["_stock"]),
							reader["_description"].ToString(),
							Convert.ToBoolean(reader["_isdeleted"])
						);
					}
				}
			}

			return fertilizer;
		}
		public List<Fertilizer> FindFertilizer(string str)
		{
			List<Fertilizer> fertilizers = new List<Fertilizer>();

			using (var connection = new SqlConnection(_connectionString))
			{
				var query = "SELECT * FROM _Fertilizer WHERE fertilizer_id = @str OR _name LIKE '%' + @str + '%'";
				var command = new SqlCommand(query, connection);

				command.Parameters.AddWithValue("@str", str);

				connection.Open();

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var fertilizer = new Fertilizer
						(
							reader["fertilizer_id"].ToString(),
							reader["_name"].ToString(),
							Convert.ToSingle(reader["_price"]),
							reader["_category"].ToString(),
							Convert.ToInt32(reader["_stock"]),
							reader["_description"].ToString(),
							Convert.ToBoolean(reader["_isdeleted"])
						);

						fertilizers.Add(fertilizer);
					}
				}
			}

			return fertilizers;
		}
        public bool deleteFertilizer(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE _Fertilizer SET _isdeleted = 1 WHERE fertilizer_id = @id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false; 
                }
            }
        }
        public bool updateFertilizer(Fertilizer fertilizer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"
				UPDATE _Fertilizer
				SET
                _name = @name,
                _price = @price,
                _category = @category,
                _stock = @stock,
                _description = @description,
				_isDeleted = @deleted
				WHERE fertilizer_id = @id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", fertilizer.Id);
                command.Parameters.AddWithValue("@name", fertilizer.Name);
                command.Parameters.AddWithValue("@price", fertilizer.Price);
                command.Parameters.AddWithValue("@category", fertilizer.Category);
                command.Parameters.AddWithValue("@stock", fertilizer.Stock);
                command.Parameters.AddWithValue("@description", fertilizer.Description);
				command.Parameters.AddWithValue("@deleted", fertilizer.Deleted);
				try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
					MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.Message);
                    return false; 
                }
            }
        }


    }
}
