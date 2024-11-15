using FertilizerTradingApp.Controllers;
using FertilizerTradingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI.UserForms
{
    public partial class categoryControl : UserControl
    {
		private readonly FertilizerController _fertilizerController;
		public categoryControl()
        {
            InitializeComponent();
			_fertilizerController = new FertilizerController();
			this.Load += CategoryControl_Load;
		}
		private void CategoryControl_Load(object sender, EventArgs e)
		{
			dgvFertilizers.DataSource = _fertilizerController.GetAllFertilizers();
			dgvFertilizers.Columns["Id"].HeaderText = "Mã SP";
			dgvFertilizers.Columns["Name"].HeaderText = "Tên SP";
			dgvFertilizers.Columns["Price"].HeaderText = "Giá";
			dgvFertilizers.Columns["Category"].HeaderText = "Phân Loại";
			dgvFertilizers.Columns["Stock"].HeaderText = "Số lượng tồn kho";
			dgvFertilizers.Columns["Description"].HeaderText = "Mô tả";
			dgvFertilizers.Columns["Image"].Visible = false;
		}

		private void dgvFertilizers_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				dgvFertilizers.Rows[e.RowIndex].Selected = true;

				foreach (DataGridViewRow row in dgvFertilizers.Rows)
				{
					if (row.Index != e.RowIndex)
					{
						row.Selected = false;
					}
				}

				var rowData = dgvFertilizers.Rows[e.RowIndex];

				Fertilizer fertilizer = _fertilizerController.GetFertilizerById(rowData.Cells[0].Value.ToString());

				if (fertilizer != null)
				{
					lbName.Text = fertilizer.Name;
					label7.Text = fertilizer.Id;
					lbPrice.Text = fertilizer.Price
				}
			}
		}
	}
}
