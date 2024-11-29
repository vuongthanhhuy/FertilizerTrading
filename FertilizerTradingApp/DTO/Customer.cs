using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilizerTradingApp.Models
{
	public class Customer
	{
		public string CustomerPhone { get; set; }  
		public DateTime PurchaseUpdate { get; set; }     
		public float Debt { get; set; }        
		public float TotalBought { get; set; }
		public string Name { get; set; }           
		public string Email { get; set; }
		public int PurchaseTime {  get; set; }
		public Customer(string customerPhone, DateTime purchaseUpdate, float debt, float totalBought, string name, string email)
		{
			CustomerPhone = customerPhone;
            PurchaseUpdate = purchaseUpdate;
			Debt = debt;
			TotalBought = totalBought;
			Name = name;
			Email = email;
		}
	}
}
