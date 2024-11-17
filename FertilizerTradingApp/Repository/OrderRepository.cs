using DocumentFormat.OpenXml.Wordprocessing;
using FertilizerTradingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FertilizerTradingApp.Repository
{
    public class OrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT order_id, _total_price, _date, _total_payment, customer_phone, account_id FROM _Order";
                var command = new SqlCommand(query, connection);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                        var order = new Order
                        (
                            reader["order_id"].ToString(),
                            float.Parse(reader["_total_price"].ToString()),
                            DateTime.Parse(reader["_date"].ToString()),
                            float.Parse(reader["_total_payment"].ToString()),
                            reader["customer_phone"].ToString(),
                            reader["account_id"].ToString()
                        );
                        
                        orders.Add(order);
                    }
                }
            }

            return orders;
        }
		public List<Order> GetOrdersOfCustomer(DateTime startDate, DateTime endDate, string customer_phone)
		{
			List<Order> orders = new List<Order>();

			using (var connection = new SqlConnection(_connectionString))
			{
				var query = "SELECT * FROM _Order WHERE _date BETWEEN @startDate AND @endDate AND customer_phone = @customer_phone";
				var command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@customer_phone", customer_phone);
				command.Parameters.AddWithValue("@startDate", startDate);
				command.Parameters.AddWithValue("@endDate", endDate);
				connection.Open();

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var order = new Order
						(
							reader["order_id"].ToString(),
							float.Parse(reader["_total_price"].ToString()),
							DateTime.Parse(reader["_date"].ToString()),
							float.Parse(reader["_total_payment"].ToString()),
							reader["customer_phone"].ToString(),
							reader["account_id"].ToString()
						);

						orders.Add(order);
					}
				}
			}

			return orders;
		}
		public List<Order> GetOrdersByTime(DateTime startDate, DateTime endDate)
		{
			List<Order> orders = new List<Order>();

			using (var connection = new SqlConnection(_connectionString))
			{
				var query = "SELECT * FROM _Order WHERE _date BETWEEN @startDate AND @endDate";
				var command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@startDate", startDate);
				command.Parameters.AddWithValue("@endDate", endDate);
				connection.Open();

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var order = new Order
						(
							reader["order_id"].ToString(),
							float.Parse(reader["_total_price"].ToString()),
							DateTime.Parse(reader["_date"].ToString()),
							float.Parse(reader["_total_payment"].ToString()),
							reader["customer_phone"].ToString(),
							reader["account_id"].ToString()
						);

						orders.Add(order);
					}
				}
			}
			return orders;
		}
        public void AddOrder(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "EXEC AddOrder @TotalPrice, @Date, @TotalPayment, @CustomerPhone, @AccountId";
				var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                command.Parameters.AddWithValue("@Date", order.Date);
                command.Parameters.AddWithValue("@TotalPayment", order.TotalPayment);
                command.Parameters.AddWithValue("@CustomerPhone", order.CustomerPhone);
                command.Parameters.AddWithValue("@AccountId", "A0000001");
				connection.Open();
				command.ExecuteNonQuery();
			}
        }
        public string GetNewestOrderId()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT TOP 1 order_id FROM _Order ORDER BY _date DESC";
                var command = new SqlCommand(query, connection);
                connection.Open();
                var newestOrderId = command.ExecuteScalar()?.ToString();
                return newestOrderId;
            }
        }
		public List<Order> FindOrder(string str)
		{
			List<Order> orders = new List<Order>();
			using (var connection = new SqlConnection(_connectionString))
			{
				var query = "SELECT * FROM _Order WHERE order_id = @str OR customer_phone LIKE '%' + @str + '%'";
				var command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@str", str);
				connection.Open();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var order = new Order
						(
							reader["order_id"].ToString(),
							float.Parse(reader["_total_price"].ToString()),
							DateTime.Parse(reader["_date"].ToString()),
							float.Parse(reader["_total_payment"].ToString()),
							reader["customer_phone"].ToString(),
							reader["account_id"].ToString()
						);
						orders.Add(order);
					}
				}
			}
			return orders;
		}
	}
}
