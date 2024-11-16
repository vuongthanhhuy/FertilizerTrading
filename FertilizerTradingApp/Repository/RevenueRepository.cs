using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilizerTradingApp.Repository
{
	public class RevenueRepository
	{
		private readonly string _connectionString;

		public RevenueRepository(string connectionString)
		{
			_connectionString = connectionString;
		}
		public System.Data.DataTable GetRevenueByPeriod(string period)
		{
			string query = "";

			switch (period)
			{
				case "Week":
					query = @"
                    SELECT DATEPART(WEEK, _date) AS WeekNumber, SUM(_total_price) AS TotalRevenue
                    FROM _Order
                    GROUP BY DATEPART(WEEK, _date)
                    ORDER BY WeekNumber";
					break;
				case "Month":
					query = @"
                    SELECT DATEPART(MONTH, _date) AS MonthNumber, SUM(_total_price) AS TotalRevenue
                    FROM _Order
                    GROUP BY DATEPART(MONTH, _date)
                    ORDER BY MonthNumber";
					break;
				case "Quarter":
					query = @"
                    SELECT DATEPART(QUARTER, _date) AS QuarterNumber, SUM(_total_price) AS TotalRevenue
                    FROM _Order
                    GROUP BY DATEPART(QUARTER, _date)
                    ORDER BY QuarterNumber";
					break;
				case "Year":
					query = @"
                    SELECT DATEPART(YEAR, _date) AS YearNumber, SUM(_total_price) AS TotalRevenue
                    FROM _Order
                    GROUP BY DATEPART(YEAR, _date)
                    ORDER BY YearNumber";
					break;
				default:
					throw new ArgumentException("Invalid period specified. Use 'Week', 'Month', 'Quarter', or 'Year'.");
			}

			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
				System.Data.DataTable dataTable = new System.Data.DataTable();
				adapter.Fill(dataTable);
				return dataTable;
			}
		}
	}
}
