using FertilizerTradingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FertilizerTradingApp.Repository
{
	public class CustomerRepository
	{
		private readonly string _connectionString;
		public CustomerRepository(string connectionString)
		{
			_connectionString = connectionString;
		}
		
		public List<Customer> GetAllCustomers()
		{
			List<Customer> customers = new List<Customer>();

			using (var connection = new SqlConnection(_connectionString))
			{
				var query = "SELECT * FROM _Customer";
				var command = new SqlCommand(query, connection);

				connection.Open();

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var customer = new Customer
						(
							reader["customer_phone"].ToString(),         
							Convert.ToInt32(reader["_purchase_time"]),  
							Convert.ToSingle(reader["_debt"]),              
							Convert.ToSingle(reader["_total_bought"]),  
							reader["_name"].ToString(),                  
							reader["_email"].ToString()					
						);

						customers.Add(customer);
					}
				}
			}

			return customers;
		}
		public Customer GetCustomerById(string id)
		{
			Customer customer = null;

			using (var connection = new SqlConnection(_connectionString))
			{
				var query = "SELECT * FROM _Customer WHERE customer_phone = @id";
				var command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@id", id);

				connection.Open();

				using (var reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						customer = new Customer
						(
							reader["customer_phone"].ToString(),
							Convert.ToInt32(reader["_purchase_time"]),
							Convert.ToSingle(reader["_debt"]),
							Convert.ToSingle(reader["_total_bought"]),
							reader["_name"].ToString(),
							reader["_email"].ToString()
						);
					}
				}
			}

			return customer;
		}
		public List<Order> GetAllOrdersByCustomer(string customerId)
		{
			List<Order> orders = new List<Order>();

			using (var connection = new SqlConnection(_connectionString))
			{
				var query = "SELECT * FROM _Order WHERE customer_phone = @customerId";
				var command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@customerId", customerId);

				connection.Open();

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var order = new Order
						(
							reader["order_id"].ToString(),              
							Convert.ToSingle(reader["_total_price"]),   
							Convert.ToDateTime(reader["_date"]),         
							Convert.ToInt32(reader["_total_payment"]),   
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
