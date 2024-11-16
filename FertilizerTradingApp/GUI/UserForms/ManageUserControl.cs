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
		private OrderController _orderController;
		private Customer _customerSelected;
        public ManageUserControl()
        {
            InitializeComponent();
			_customerController = new CustomerController();
			_orderController = new OrderController();
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
					dataGridView2.Columns["CustomerPhone"].HeaderText = "Số điện thoại";
					dataGridView2.Columns["AccountId"].HeaderText = "Người Phụ Trách";
					dataGridView2.Columns["TotalPayment"].HeaderText = "Đã Trả";
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			if(IsDateRangeValid(dateTimePicker1, dateTimePicker2))
			{
				if (textBox1.Text.Length > 0)
				{
					var data1 = _orderController.GetOrdersOfCustomer(dateTimePicker1.Value, dateTimePicker2.Value, textBox1.Text);
					dataGridView2.DataSource = data1;
					dataGridView2.Columns["OrderId"].HeaderText = "Mã Đơn";
					dataGridView2.Columns["TotalPrice"].HeaderText = "Tổng hóa đơn";
					dataGridView2.Columns["Date"].HeaderText = "Ngày Mua";
					dataGridView2.Columns["CustomerPhone"].HeaderText = "Số điện thoại";
					dataGridView2.Columns["AccountId"].HeaderText = "Người Phụ Trách";
					dataGridView2.Columns["TotalPayment"].HeaderText = "Đã Trả";
				}
				else
				{
					var data2 = _orderController.GetOrdersByTime(dateTimePicker1.Value, dateTimePicker2.Value);
					dataGridView2.DataSource = data2;
					dataGridView2.Columns["OrderId"].HeaderText = "Mã Đơn";
					dataGridView2.Columns["TotalPrice"].HeaderText = "Tổng hóa đơn";
					dataGridView2.Columns["Date"].HeaderText = "Ngày Mua";
					dataGridView2.Columns["CustomerPhone"].HeaderText = "Số điện thoại";
					dataGridView2.Columns["AccountId"].HeaderText = "Người Phụ Trách";
					dataGridView2.Columns["TotalPayment"].HeaderText = "Đã Trả";
				}
			}
			else
			{
				MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
			}
			
		}

		private bool IsDateRangeValid(DateTimePicker dateTimePicker1, DateTimePicker dateTimePicker2)
		{
			DateTime startDate = dateTimePicker1.Value.Date;
			DateTime endDate = dateTimePicker2.Value.Date;

			if (startDate <= endDate)
			{
				return true;
			}
			else
			{
				
				return false;
			}
		}

		private void btnFind_Click(object sender, EventArgs e)
		{
			List<Customer> customers = new List<Customer>();
			customers.Add(_customerController.GetCustomerById(txbSearch.Text));
			dataGridView1.DataSource = customers;
			dataGridView1.Columns["CustomerPhone"].HeaderText = "Số điện thoại";
			dataGridView1.Columns["Name"].HeaderText = "Tên khách hàng";
			dataGridView1.Columns["PurchaseTime"].HeaderText = "Số lần mua";
			dataGridView1.Columns["TotalBought"].HeaderText = "Tổng tiền đã mua";
			dataGridView1.Columns["Debt"].HeaderText = "Tiền nợ";
			dataGridView1.Columns["Email"].HeaderText = "Email";
		}
	}
}
