using FertilizerTradingApp.Models;
using PdfSharp.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                            Convert.ToDateTime(reader["_purchase_update"]),
                            Convert.ToSingle(reader["_debt"]),
                            Convert.ToSingle(reader["_total_bought"]),
                            reader["_name"].ToString(),
                            reader["_email"].ToString()
                        );
                        customer.PurchaseTime = (int)Convert.ToSingle(reader["purchase_times"]);
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
                            Convert.ToDateTime(reader["_purchase_update"]),
                            Convert.ToSingle(reader["_debt"]),
                            Convert.ToSingle(reader["_total_bought"]),
                            reader["_name"].ToString(),
                            reader["_email"].ToString()
                        );
                        customer.PurchaseTime = (int)Convert.ToSingle(reader["purchase_times"]);
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

        public void AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var insertQuery = @"
                    INSERT INTO _Customer 
                    (customer_phone, _purchase_update, _debt, _total_bought, _name, _email) 
                    VALUES 
                    (@customerPhone, @purchaseTime, @debt, @totalBought, @name, '')";

                var command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@customerPhone", customer.CustomerPhone);
                command.Parameters.AddWithValue("@purchaseTime", customer.PurchaseUpdate);
                command.Parameters.AddWithValue("@debt", customer.Debt);
                command.Parameters.AddWithValue("@totalBought", customer.TotalBought);
                command.Parameters.AddWithValue("@name", customer.Name);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdateCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var updateQuery = @"
            UPDATE _Customer
            SET 
                _debt = @debt, 
                _total_bought = @totalBought, 
                _purchase_time = GETDATE(), 
                _email = @email,
                _purchase_time = @purchaseTime,
            WHERE customer_phone = @customerPhone";  
                var command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@debt", customer.Debt);
                command.Parameters.AddWithValue("@totalBought", customer.TotalBought);
                command.Parameters.AddWithValue("@purchaseTime", customer.PurchaseUpdate);
                command.Parameters.AddWithValue("@email", customer.Email ?? (object)DBNull.Value);  
                command.Parameters.AddWithValue("@customerPhone", customer.CustomerPhone);
                command.Parameters.AddWithValue("@purchaseTime", customer.PurchaseTime);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
