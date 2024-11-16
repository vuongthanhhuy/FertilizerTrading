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
	public class RevenueController
	{
		private readonly RevenueService _revenueService;
		public RevenueController()
		{
			_revenueService = new RevenueService(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
		}
		public System.Data.DataTable GetRevenueByPeriod(string period)
		{
			return _revenueService.GetRevenueByPeriod(period);
		}
	}
}
