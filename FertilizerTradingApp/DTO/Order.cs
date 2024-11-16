using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilizerTradingApp.Models
{
	public class Order
	{
		public string OrderId { get; set; }
		public float TotalPrice { get; set; }
		public DateTime Date { get; set; }
		public int TotalPayment { get; set; }
		public string CustomerPhone { get; set; }
		public string AccountId { get; set; }
		public Order(string orderId, float totalPrice, DateTime date, int totalPayment, string customerPhone, string accountId)
		{
			OrderId = orderId;
			TotalPrice = totalPrice;
			Date = date;
			TotalPayment = totalPayment;
			CustomerPhone = customerPhone;
			AccountId = accountId;
		}
	}
}
