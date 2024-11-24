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
				pictureBox1.Image = resizedImage;
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
            if (_fertilizerController.AddFertilizer(fileName, txtName.Text, txtPrice.Text, txtCategory.Text, txtQuantity.Text, txtDescription.Text))
            {
                string imagesPath = Path.Combine("D:/AppData/resource");
                if (!Directory.Exists(imagesPath))
                {
                    Directory.CreateDirectory(imagesPath);
                }
                string savePath = Path.Combine(imagesPath, fileName);
                resizedImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
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
	}
}
