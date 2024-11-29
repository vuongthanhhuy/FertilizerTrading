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
			DateTime currentDate = DateTime.Now;  // Get the current date

			switch (period)
			{
				case "Week":
					query = @"
                SELECT 
                RIGHT('00' + CAST(DAY(_date) AS VARCHAR(2)), 2) + '-' +
                RIGHT('00' + CAST(MONTH(_date) AS VARCHAR(2)), 2) + '-' +
                CAST(YEAR(_date) AS VARCHAR(4)) AS DateAsString,
                SUM(_total_price) AS TotalRevenue,
                COUNT(*) AS TotalOrders

                FROM _Order
                WHERE _date >= DATEADD(DAY, -7, GETDATE())  -- Get orders from the last 7 days
                GROUP BY 
                    CAST(DAY(_date) AS VARCHAR(2)), 
                    CAST(MONTH(_date) AS VARCHAR(2)), 
                    CAST(YEAR(_date) AS VARCHAR(4))
                ORDER BY DateAsString DESC";
					break;

				case "Month":
					query = @"
                SELECT
                    -- Calculate the week number within the month (Week 1, Week 2, etc.)
                    DATEPART(WEEK, _date) - DATEPART(WEEK, DATEADD(MONTH, DATEDIFF(MONTH, 0, _date), 0)) + 1 AS WeekNumber,
                    -- Sum of total price for the week
                    SUM(_total_price) AS TotalRevenue,
                    -- Count of total orders for the week
                    COUNT(*) AS TotalOrders
                FROM _Order
                WHERE _date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)  -- Start of the current month
                AND _date < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)  -- End of the current month
                GROUP BY DATEPART(WEEK, _date) - DATEPART(WEEK, DATEADD(MONTH, DATEDIFF(MONTH, 0, _date), 0)) + 1
                ORDER BY WeekNumber";
					break;


				case "Quarter":
					query = @"
                SELECT
                DATEPART(MONTH, _date) AS MonthNumber,
                SUM(_total_price) AS TotalRevenue,
	            COUNT(*) AS TotalOrders
                FROM _Order
                WHERE _date >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)  -- Start of the current year
                AND _date < DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()) + 1, 0)  -- End of the current year
                AND DATEPART(QUARTER, _date) = DATEPART(QUARTER, GETDATE()) -- Filter for current quarter
                GROUP BY DATEPART(QUARTER, _date), DATEPART(MONTH, _date)
                ORDER BY MonthNumber";
					break;


				case "Year":
					query = @"
                ;WITH Months AS (
                SELECT 1 AS MonthNumber
                UNION ALL
                SELECT 2
                UNION ALL
                SELECT 3
                UNION ALL
                SELECT 4
                UNION ALL
                SELECT 5
                UNION ALL
                SELECT 6
                UNION ALL
                SELECT 7
                UNION ALL
                SELECT 8
                UNION ALL
                SELECT 9
                UNION ALL
                SELECT 10
                UNION ALL
                SELECT 11
                UNION ALL
                SELECT 12
            )
            SELECT
                m.MonthNumber,
                SUM(o._total_price) AS TotalRevenue,
                COUNT(o._total_price) AS TotalOrders
            FROM Months m
            INNER JOIN _Order o  -- Changed from LEFT JOIN to INNER JOIN
                ON DATEPART(MONTH, o._date) = m.MonthNumber
                AND o._date >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)  -- Start of the current year
                AND o._date < DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()) + 1, 0)  -- End of the current year
            GROUP BY m.MonthNumber
            ORDER BY m.MonthNumber;";
					break;


				default:
					throw new ArgumentException("Invalid period specified. Use 'Week', 'Month', 'Quarter', or 'Year'.");
			}

			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				try
				{
					SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
					System.Data.DataTable dataTable = new System.Data.DataTable();

					adapter.Fill(dataTable);

					if (dataTable.Rows.Count == 0)
					{
						Console.WriteLine("No data found for the specified period.");
					}

					return dataTable;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error: " + ex.Message);
					return null; // Return null if an error occurs
				}
			}
		}
	}
}
