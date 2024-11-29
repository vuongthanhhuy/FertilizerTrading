using FertilizerTradingApp.Models;
using FertilizerTradingApp.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilizerTradingApp.Services
{
	public class CustomerService
	{
		private readonly CustomerRepository _customerRepository;
		public CustomerService(string connectionString)
		{
			_customerRepository = new CustomerRepository(connectionString);
		}
		public List<Customer> GetAllCustomers()
		{
			return _customerRepository.GetAllCustomers();
		}
		public Customer GetCustomerById(string id)
		{
			return _customerRepository.GetCustomerById(id);
		}
		public List<Order> GetAllOrdersByCustomer(string customerId)
		{
			return _customerRepository.GetAllOrdersByCustomer(customerId);
		}
		public void AddCustomer(Customer customer) {
			_customerRepository.AddCustomer(customer);
		}
		public void UpdateCustomer(Customer customer)
		{
			_customerRepository.UpdateCustomer(customer);
		}
		public void UpdateDebtById(string customerId, float debtReduction)
		{
			_customerRepository.UpdateDebtById(customerId, debtReduction);
		}
    }
}
