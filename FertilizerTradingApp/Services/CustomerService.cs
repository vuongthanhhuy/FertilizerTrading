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
	}
}
