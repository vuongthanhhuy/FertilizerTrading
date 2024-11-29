using FertilizerTradingApp.Controllers;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FertilizerTradingApp.GUI.UserForms
{
    public partial class SystemControl : UserControl
    {
        private readonly RevenueController _revenueController;
        public SystemControl()
        {
            InitializeComponent();
            _revenueController = new RevenueController();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable revenueData = _revenueController.GetRevenueByPeriod("Week");
            BindDataToChart(revenueData, "Week");
        }
		private void BindDataToChart(DataTable dataTable, string period)
		{
			chart1.Series.Clear();

			Series series = new Series
			{
				Name = "Revenue",
				ChartType = SeriesChartType.Column,
				XValueType = ChartValueType.String,
				YValueType = ChartValueType.Double
			};

			chart1.Series.Add(series);
			double total_price = 0;
			int total_order = 0;
			if (dataTable != null)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					string xValue = Convert.ToString(row[0]);
					double yValue = Convert.ToDouble(row[1]);
					total_order += Convert.ToInt32(row[2]);
					total_price += yValue;
					series.Points.AddXY(xValue, yValue);
				}

				chart1.ChartAreas[0].AxisX.Title = period;
				chart1.ChartAreas[0].AxisY.Title = "Total Revenue";
				chart1.ChartAreas[0].RecalculateAxesScale();
				txt_order_number.Text = total_order.ToString();
				txt_order_price.Text = total_price.ToString("N0") + " VND";
			}
			else
			{
				MessageBox.Show("Chưa có dữ liệu ngày hôm nay");
			}

		}

		private void button2_Click(object sender, EventArgs e)
        {
            DataTable revenueData = _revenueController.GetRevenueByPeriod("Month");
            BindDataToChart(revenueData, "Month");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable revenueData = _revenueController.GetRevenueByPeriod("Quarter");
            BindDataToChart(revenueData, "Quarter");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable revenueData = _revenueController.GetRevenueByPeriod("Year");
            BindDataToChart(revenueData, "Year");
        }
    }
}
