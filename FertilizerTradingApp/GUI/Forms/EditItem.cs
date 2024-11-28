using FertilizerTradingApp.Controllers;
using FertilizerTradingApp.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI.Forms
{
    public partial class EditItem : Form
    {
		private readonly FertilizerController _fertilizerController;
		private string fileName;
		private Image resizedImage;
        private string _currentId;
        private Fertilizer _currentFertilizer;
		public EditItem(string id)
        {
			InitializeComponent();
            _fertilizerController = new FertilizerController();
            _currentId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp) | *.jpg; *.jpeg; *.gif; *.bmp;";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
				Image originalImage = new Bitmap(openFileDialog.FileName);
				resizedImage = ResizeImage(originalImage, 200, 200);
				// pictureBox1.Image = resizedImage;
				fileName = Path.GetFileName(openFileDialog.FileName);
				originalImage.Dispose();
			}
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            fileName = GenerateUniqueImageName(Path.GetExtension(fileName));
            if (string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtPrice.Text) ||
                string.IsNullOrEmpty(txtCategory.Text) ||
                string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Thiếu dữ liệu");
                return;
            }
            if (_fertilizerController.updateFertilizer(_currentId, txtName.Text, txtPrice.Text, txtCategory.Text, txtQuantity.Text, txtDescription.Text, bool.Parse(button1.Text)))
            {
                MessageBox.Show("Sửa phân bón thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Sửa phân bón thất bại!");
            }
        }

        private Image ResizeImage(Image inputImage, int width, int height)
		{
			Bitmap resizedImage = new Bitmap(width, height);

			using (Graphics graphics = Graphics.FromImage(resizedImage))
			{
				graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
				graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

				graphics.DrawImage(inputImage, 0, 0, width, height);
			}

			return resizedImage;
		}

		private string GenerateUniqueImageName(string extension)
		{
			string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

			Random random = new Random();
			string randomString = Path.GetRandomFileName().Replace(".", "");

			string uniqueName = $"{timestamp}_{randomString}_{extension}";

			return uniqueName;
		}
        private bool IsValidNumericInput(TextBox textBox, char keyChar)
        {
            if (char.IsControl(keyChar))
                return true;
            if (char.IsDigit(keyChar))
                return true;
            if (keyChar == '.' && !textBox.Text.Contains("."))
                return true;
            return false;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!IsValidNumericInput(textBox, e.KeyChar))
            {
                MessageBox.Show("Chỉ chấp nhận số");
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!IsValidNumericInput(textBox, e.KeyChar))
            {
                MessageBox.Show("Chỉ chấp nhận số");
                e.Handled = true;
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string unformattedText = textBox.Text.Replace(",", "").Trim();
            if (decimal.TryParse(unformattedText, out decimal value))
            {
                textBox.Text = string.Format("{0:n0}", value);
                textBox.SelectionStart = textBox.Text.Length;
            }
            else if (!string.IsNullOrEmpty(unformattedText))
            {
                MessageBox.Show("Chỉ chấp nhận số");
                textBox.Text = string.Empty;
            }
        }


        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string unformattedText = textBox.Text.Replace(",", "").Trim();
            if (decimal.TryParse(unformattedText, out decimal value))
            {
                textBox.Text = string.Format("{0:n0}", value);
                textBox.SelectionStart = textBox.Text.Length;
            }
            else if (!string.IsNullOrEmpty(unformattedText))
            {
                MessageBox.Show("Chỉ chấp nhận số");
                textBox.Text = string.Empty;
            }
        }

        private void EditItem_Load(object sender, EventArgs e)
        {
            _currentFertilizer = _fertilizerController.GetFertilizerById(_currentId);
            _fillData();
        }
        private void _fillData()
        {
            if (_currentFertilizer != null)
            {
                txtName.Text = _currentFertilizer.Name;
                txtCategory.Text = _currentFertilizer.Category;
                txtQuantity.Text = _currentFertilizer.Stock.ToString();
                txtDescription.Text = _currentFertilizer.Description;
                txtPrice.Text = _currentFertilizer.Price.ToString();
                button1.Text = _currentFertilizer.Deleted.ToString();
            }
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

		private void button1_Click_1(object sender, EventArgs e)
		{
            _currentFertilizer.Deleted = !_currentFertilizer.Deleted;
            button1.Text = _currentFertilizer.Deleted.ToString();
		}
	}
}
