using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilizerTradingApp.Models
{
	public class ItemOrdered
	{
		public int Quantity { get; set; }
		public string FertilizerId { get; set; }
		public string OrderId { get; set; }
	}
}
