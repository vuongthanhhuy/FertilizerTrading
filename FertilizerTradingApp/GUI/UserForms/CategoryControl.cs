using FertilizerTradingApp.Controllers;
using FertilizerTradingApp.GUI.Forms;
using FertilizerTradingApp.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI.UserForms
{
    public partial class categoryControl : UserControl
    {
        private readonly FertilizerController _fertilizerController;
        private Fertilizer _fertilizerCurrent;
        public categoryControl()
        {
            InitializeComponent();
            _fertilizerController = new FertilizerController();
            this.Load += CategoryControl_Load;
        }

        private void CategoryControl_Load(object sender, EventArgs e)
        {
            try
            {
                var fertilizers = _fertilizerController.GetAllFertilizersAvailble();
                var formattedFertilizers = fertilizers.Select(f => new
                {
                    f.Id,
                    f.Name,
                    Price = f.Price.ToString("N0"), 
                    f.Category,
                    f.Stock,
                    f.Description,
                    f.Image,
                    f.Deleted
                }).ToList();
                dgvFertilizers.DataSource = formattedFertilizers;
                dgvFertilizers.Columns["Id"].HeaderText = "Mã SP";
                dgvFertilizers.Columns["Name"].HeaderText = "Tên SP";
                dgvFertilizers.Columns["Price"].HeaderText = "Giá";
                dgvFertilizers.Columns["Category"].HeaderText = "Phân Loại";
                dgvFertilizers.Columns["Stock"].HeaderText = "Số lượng tồn kho";
                dgvFertilizers.Columns["Description"].HeaderText = "Mô tả";
                dgvFertilizers.Columns["Image"].Visible = false;
				dgvFertilizers.Columns["Deleted"].HeaderText = "Đã xóa";
			}
			catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi truy vấn sản phẩm: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvFertilizers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                    _fertilizerCurrent = fertilizer;
                    if (fertilizer != null)
                    {
                        LoadImageIntoPictureBox(fertilizer.Image);
                        lbName.Text = fertilizer.Name;
                        label7.Text = fertilizer.Id;
                        lbPrice.Text = fertilizer.Price.ToString("N0");
                        lbType.Text = fertilizer.Category.ToString();
                        lbNumber.Text = fertilizer.Stock.ToString("N0");
                        lbDesc.Text = fertilizer.Description;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra với sản phẩm đã chọn: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadImageIntoPictureBox(string imageName)
        {
           //pictureBox1.Image = Properties.Resources._20241116_052222_tawpf2qjnob_Fertilizer1;
        }
		private void ReloadMainFormData()
		{
			try
			{
				var data = _fertilizerController.GetAllFertilizersAvailble();
				dgvFertilizers.DataSource = data;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error while reloading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddItem addItem = new AddItem();
				addItem.FormClosed += (s, args) =>
				{
					ReloadMainFormData();
				};
				addItem.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra với cập nhập: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_fertilizerCurrent != null)
                {

                    EditItem addItem = new EditItem(_fertilizerCurrent.Id);
                    addItem.FormClosed += (s, args) =>
                    {
                        ReloadMainFormData();
                    };
                    addItem.Show();

                }
                else
                {
                    MessageBox.Show("Chưa chọn loại hàng nào");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra với cập nhập: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                dgvFertilizers.DataSource = _fertilizerController.FindFertilizer(textBox1.Text);
                dgvFertilizers.Columns["Id"].HeaderText = "Mã SP";
                dgvFertilizers.Columns["Name"].HeaderText = "Tên SP";
                dgvFertilizers.Columns["Price"].HeaderText = "Giá";
                dgvFertilizers.Columns["Category"].HeaderText = "Phân Loại";
                dgvFertilizers.Columns["Stock"].HeaderText = "Số lượng tồn kho";
                dgvFertilizers.Columns["Description"].HeaderText = "Mô tả";
                dgvFertilizers.Columns["Image"].Visible = false;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xuất file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel()
        {
            string outputDirectory = Path.Combine("D:/FertilizerTrading/output");
            Directory.CreateDirectory(outputDirectory);

            string filePath = Path.Combine(outputDirectory, "Sanpham.xlsx");

            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var fertilizersSheet = workbook.AddWorksheet("Fertilizers");
                ExportGridToExcel(fertilizersSheet, dgvFertilizers);
                workbook.SaveAs(filePath);
            }

            MessageBox.Show($"Đã xuất file Sanpham.xlsx ở thư mục {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ExportGridToExcel(ClosedXML.Excel.IXLWorksheet sheet, DataGridView grid)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                sheet.Cell(1, i + 1).Value = grid.Columns[i].HeaderText;
            }
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    sheet.Cell(i + 2, j + 1).Value = grid.Rows[i].Cells[j].Value?.ToString();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            

        }

        private void lbDesc_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
             "Bạn có chắc chắn muốn xóa mục này không?",
             "Xác nhận xóa",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (_fertilizerCurrent.Id != null)
                {
                    if (_fertilizerController.RemoveFertilizer(_fertilizerCurrent.Id))
                    {
                        MessageBox.Show("Mục đã được xóa thành công.");
						
						ReloadMainFormData();
                    }
                    else
                    {
                        MessageBox.Show("Mục đã được xóa thất bại.");

                    }

                }
                else
                {
                    MessageBox.Show("Chưa chọn sản phẩm");

                }
            }
            else
            {
                MessageBox.Show("Hủy bỏ xóa mục.");
            }
        }
    }
}
