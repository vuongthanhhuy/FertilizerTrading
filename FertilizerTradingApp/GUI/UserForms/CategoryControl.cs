using FertilizerTradingApp.Controllers;
using FertilizerTradingApp.GUI.Forms;
using FertilizerTradingApp.Models;
using System;
using System.Drawing;
using System.IO;
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the fertilizers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    if (fertilizer != null)
                    {
                        LoadImageIntoPictureBox(fertilizer.Image);
                        lbName.Text = fertilizer.Name;
                        label7.Text = fertilizer.Id;
                        lbPrice.Text = fertilizer.Price.ToString();
                        lbType.Text = fertilizer.Category.ToString();
                        lbNumber.Text = fertilizer.Stock.ToString();
                        lbDesc.Text = fertilizer.Description;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while selecting the fertilizer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadImageIntoPictureBox(string imageName)
        {
            try
            {
                string projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName;
                string imagesPath = Path.Combine(projectPath, "Resources/Fertilizer");
                string imagePath = Path.Combine(imagesPath, imageName);

                if (File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                else
                {
                    MessageBox.Show("Ảnh không tồn tại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddItem addItem = new AddItem();
                addItem.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the AddItem form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                AddItem addItem = new AddItem();
                addItem.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the AddItem form for editing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
