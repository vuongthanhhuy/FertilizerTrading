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
        public ManageUserControl()
        {
            InitializeComponent();
			_customerController = new CustomerController();
			this.Load += CategoryControl_Load;
		}
		private void CategoryControl_Load(object sender, EventArgs e)
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

				/*if (fertilizer != null)
				{
					LoadImageIntoPictureBox(fertilizer.Image);
					lbName.Text = fertilizer.Name;
					label7.Text = fertilizer.Id;
					lbPrice.Text = fertilizer.Price.ToString();
					lbType.Text = fertilizer.Category.ToString();
					lbNumber.Text = fertilizer.Stock.ToString();
					lbDesc.Text = fertilizer.Description;
				}*/
			}
		}
	}
}
