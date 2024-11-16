using FertilizerTradingApp.Controllers;
using FertilizerTradingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI.UserForms
{
    public partial class ManageUserControl : UserControl
    {
        private CustomerController _customerController;
		private Customer _customerSelected;
        public ManageUserControl()
        {
            InitializeComponent();
			_customerController = new CustomerController();
			_customerSelected = null;
			this.Load += CustomerControl_Load;
		}
		private void CustomerControl_Load(object sender, EventArgs e)
		{
			dataGridView1.DataSource = _customerController.GetAllCustomers();
			dataGridView1.Columns["CustomerPhone"].HeaderText = "Số điện thoại";
			dataGridView1.Columns["Name"].HeaderText = "Tên khách hàng";
			dataGridView1.Columns["PurchaseTime"].HeaderText = "Số lần mua";
			dataGridView1.Columns["TotalBought"].HeaderText = "Tổng tiền đã mua";
			dataGridView1.Columns["Debt"].HeaderText = "Tiền nợ";
			dataGridView1.Columns["Email"].HeaderText = "Email";
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				dataGridView1.Rows[e.RowIndex].Selected = true;

				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					if (row.Index != e.RowIndex)
					{
						row.Selected = false;
					}
				}

				var rowData = dataGridView1.Rows[e.RowIndex];

				Customer customer = _customerController.GetCustomerById(rowData.Cells[0].Value.ToString());
				_customerSelected = customer;

				if (customer != null)
				{
					label5.Text = customer.Name;
					label7.Text = customer.CustomerPhone;
					label8.Text = customer.Email;
					label12.Text = customer.PurchaseTime.ToString();
					label14.Text = customer.Debt.ToString();
					label15.Text = customer.TotalBought.ToString();

					var relatedData = _customerController.GetAllOrdersByCustomer(customer.CustomerPhone);
					dataGridView2.DataSource = relatedData;
					dataGridView2.Columns["OrderId"].HeaderText = "Mã Đơn";
					dataGridView2.Columns["TotalPrice"].HeaderText = "Tổng hóa đơn";
					dataGridView2.Columns["Date"].HeaderText = "Ngày Mua";
					dataGridView2.Columns["CustomerPhone"].Visible = false;
					dataGridView2.Columns["AccountId"].HeaderText = "Người Phụ Trách";
					dataGridView2.Columns["TotalPayment"].HeaderText = "Đã Trả";
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(_customerSelected != null)
			{

			}
		}

		public List<DateTime> GetDatesBetween(DateTimePicker dateTimePicker1, DateTimePicker dateTimePicker2)
		{
			DateTime startDate = dateTimePicker1.Value.Date;
			DateTime endDate = dateTimePicker2.Value.Date;

			List<DateTime> dateRange = new List<DateTime>();

			if (startDate <= endDate)
			{
				for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
				{
					dateRange.Add(date);
				}
			}
			else
			{
				MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return dateRange;
		}

	}
}
