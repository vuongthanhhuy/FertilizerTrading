using FertilizerTradingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FertilizerTradingApp.Repository
{
    public class ItemOrderedRepository
    {
        private readonly string _connectionString;

        public ItemOrderedRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ItemOrdered> GetItemsByOrderId(string orderId)
        {
            List<ItemOrdered> itemsOrdered = new List<ItemOrdered>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT _quantity, fertilizer_id, order_id FROM _ItemOrdered WHERE order_id = @OrderId";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var itemOrdered = new ItemOrdered(
                            (int)reader["_quantity"],  
                            reader["fertilizer_id"].ToString(),  
                            reader["order_id"].ToString() 
                        );
                        itemsOrdered.Add(itemOrdered);
                    }
                }
            }

            return itemsOrdered;
        }
        public void AddItemOrdered(ItemOrdered itemOrdered)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"INSERT INTO _ItemOrdered (_quantity, fertilizer_id, order_id) 
                              VALUES (@Quantity, @FertilizerId, @OrderId)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Quantity", itemOrdered.Quantity);
                command.Parameters.AddWithValue("@FertilizerId", itemOrdered.FertilizerId);
                command.Parameters.AddWithValue("@OrderId", itemOrdered.OrderId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
