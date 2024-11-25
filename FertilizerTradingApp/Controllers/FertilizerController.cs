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
	public class FertilizerController
	{
		private readonly FertilizerService _fertilizerService;
		public FertilizerController()
		{
			_fertilizerService = new FertilizerService(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
		}
		public bool AddFertilizer(string name, string price, string category, string stock, string description)
		{
			return _fertilizerService.AddFertilizer(name, ConvertToFloat(price), category, ConvertToInt(stock), description);
		}
		public List<Fertilizer> GetAllFertilizers()
		{
			return _fertilizerService.GetAllFertilizers();
		}
		public Fertilizer GetFertilizerById(string id)
		{
			return _fertilizerService.GetFertilizerById(id);
		}
		public List<Fertilizer> FindFertilizer(string str)
		{
			return _fertilizerService.FindFertilizer(str);
		}
		private int ConvertToInt(string input)
		{
			int result;
			if (int.TryParse(input, out result))
			{
				return result;
			}
			else
			{
				throw new ArgumentException("Invalid input: cannot convert to int.");
			}
		}
		private float ConvertToFloat(string input)
		{
			float result;
			if (float.TryParse(input, out result))
			{
				return result;
			}
			else
			{
				throw new ArgumentException("Invalid input: cannot convert to float.");
			}
		}
	}
}
