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
	public class RevenueService
	{
		private readonly RevenueRepository _revenueRepository;
		public RevenueService(string connectionString)
		{
			_revenueRepository = new RevenueRepository(connectionString);
		}
		public System.Data.DataTable GetRevenueByPeriod(string period)
		{
			return _revenueRepository.GetRevenueByPeriod(period);
		}
	}
}
