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
		public float TotalPayment { get; set; }
		public string CustomerPhone { get; set; }
		public string AccountId { get; set; }
		public Order(string orderId, float totalPrice, DateTime date, float totalPayment, string customerPhone, string accountId)
		{
			OrderId = orderId;
			TotalPrice = totalPrice;
			Date = date;
			TotalPayment = totalPayment;
			CustomerPhone = customerPhone;
			AccountId = accountId;
		}
        public override string ToString()
        {
            return $"Order ID: {OrderId}, Total Price: {TotalPrice:C}, Date: {Date.ToShortDateString()}, " +
                   $"Total Payment: {TotalPayment:C}, Customer Phone: {CustomerPhone}, Account ID: {AccountId}";
        }
    }
}
