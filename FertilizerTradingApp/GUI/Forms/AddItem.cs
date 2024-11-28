using FertilizerTradingApp.Controllers;
using FertilizerTradingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI.Forms
{
    public partial class AddItem : Form
    {
		private readonly FertilizerController _fertilizerController;
		private string fileName;
		private Image resizedImage;
		public AddItem()
        {
			InitializeComponent();
            _fertilizerController = new FertilizerController();
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
            if (_fertilizerController.AddFertilizer(txtName.Text, txtPrice.Text, txtCategory.Text, txtQuantity.Text, txtDescription.Text))
            {
                MessageBox.Show("Thêm phân bón thành công!");

            }
            else
            {
                MessageBox.Show("Thêm phân bón thất bại!");
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
    }
}
