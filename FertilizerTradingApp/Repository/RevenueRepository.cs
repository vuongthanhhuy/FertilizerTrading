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
                SELECT CAST(_date AS DATE) AS Date, SUM(_total_price) AS TotalRevenue
                FROM _Order
                WHERE _date >= DATEADD(DAY, -7, GETDATE())  -- Get orders from the last 7 days
                GROUP BY CAST(_date AS DATE)
                ORDER BY Date DESC";
                    break;

                case "Month":
                    query = @"
                SELECT
                    DATEPART(WEEK, _date) AS WeekNumber,
                    SUM(_total_price) AS TotalRevenue
                FROM _Order
                WHERE _date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)  
                AND _date < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) 
                GROUP BY DATEPART(WEEK, _date)
                ORDER BY WeekNumber";
                    break;

                case "Quarter":
                    query = @"
                SELECT
                    DATEPART(QUARTER, _date) AS QuarterNumber,
                    SUM(_total_price) AS TotalRevenue
                FROM _Order
                WHERE _date >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)  
                AND _date < DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()) + 1, 0)  
                GROUP BY DATEPART(QUARTER, _date)
                ORDER BY QuarterNumber";
                    break;

                case "Year":
                    query = @"
                SELECT
                    DATEPART(MONTH, _date) AS MonthNumber,
                    SUM(_total_price) AS TotalRevenue
                FROM _Order
                WHERE _date >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)  
                AND _date < DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()) + 1, 0) 
                GROUP BY DATEPART(MONTH, _date)
                ORDER BY MonthNumber";
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
