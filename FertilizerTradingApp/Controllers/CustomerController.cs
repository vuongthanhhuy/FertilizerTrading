using FertilizerTradingApp.Models;
using FertilizerTradingApp.Repository;
using FertilizerTradingApp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilizerTradingApp.Controllers
{
	public class CustomerController
	{
		private readonly CustomerService _customerService;
		public CustomerController()
		{
			_customerService = new CustomerService(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
		}
		public List<Customer> GetAllCustomers()
		{
			return _customerService.GetAllCustomers();
		}
		public Customer GetCustomerById(string id)
		{
			return _customerService.GetCustomerById(id);
		}
		public List<Order> GetAllOrdersByCustomer(string customerId)
		{
			return _customerService.GetAllOrdersByCustomer(customerId);
		}
		public void AddCustomer(Customer customer)
		{
			_customerService.AddCustomer(customer);
		}
		public void UpdateCustomer(Customer customer)
		{
			_customerService.UpdateCustomer(customer);
		}
		public void UpdateDebtById(string customerId, float debtReduction)
		{
			_customerService.UpdateDebtById(customerId, debtReduction);
		}
    }
}
