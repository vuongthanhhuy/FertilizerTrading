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
    }
}
