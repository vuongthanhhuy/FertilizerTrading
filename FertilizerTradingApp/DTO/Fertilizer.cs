using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilizerTradingApp.Models
{
	public class Fertilizer
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public float Price { get; set; }
		public string Category { get; set; }
		public int Stock { get; set; }
		public string Description { get; set; }
		public Fertilizer(string id, string name, float price, string category, int stock, string description) 
		{
			this.Id = id;
			this.Name = name;
			this.Price = price;
			this.Category = category;
			this.Stock = stock;
			this.Description = description;
		}
	}
}
