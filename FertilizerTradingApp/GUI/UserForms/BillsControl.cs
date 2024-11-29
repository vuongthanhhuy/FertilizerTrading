using FertilizerTradingApp.Controllers;
using FertilizerTradingApp.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI.UserForms
{
    public partial class BillsControl : UserControl
    {
        private readonly OrderController _orderController;
        private readonly ItemOrderedController _itemOrderedController;
        private readonly FertilizerController _fertilizerController;
        private readonly CustomerController _customerController;

        public BillsControl()
        {
            InitializeComponent();
            _orderController = new OrderController();
            _itemOrderedController = new ItemOrderedController();
            _fertilizerController = new FertilizerController();
            _customerController = new CustomerController();
            this.Load += BillsControl_Load;
        }

        private void BillsControl_Load(object sender, EventArgs e)
        {
            PopulateOrderGrid();
        }

        private void PopulateOrderGrid()
        {
            var orders = _orderController.GetAllOrders();
            var formattedOrders = orders.Select(order => new
            {
                order.OrderId,
                TotalPrice = order.TotalPrice.ToString("N0"),
                Date = order.Date.ToShortDateString(),
                TotalPayment = order.TotalPayment.ToString("N0"),
                order.CustomerPhone,
                order.AccountId
            }).ToList();

            dataGridView1.DataSource = formattedOrders;
            SetOrderGridColumnHeaders();
        }

        private void SetOrderGridColumnHeaders()
        {
            var headers = new Dictionary<string, string>
            {
                { "OrderId", "Mã hóa đơn" },
                { "TotalPrice", "Tổng giá" },
                { "Date", "Ngày đặt hàng" },
                { "TotalPayment", "Tổng thanh toán" },
                { "CustomerPhone", "Số điện thoại khách hàng" },
                { "AccountId", "Mã tài khoản nhân viên" }
            };

            foreach (var header in headers)
            {
                dataGridView1.Columns[header.Key].HeaderText = header.Value;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                HandleOrderSelection(e.RowIndex);
            }
        }

        private void HandleOrderSelection(int rowIndex)
        {
            var selectedRow = dataGridView1.Rows[rowIndex];
            var orderId = selectedRow.Cells["OrderId"].Value.ToString();
            var order = _orderController.GetOrderById(orderId);

            if (order != null)
            {
                DisplayOrderDetails(order);
                LoadFertilizerDetails(orderId);
            }
        }

        private void DisplayOrderDetails(Order order)
        {
            var paymis = order.TotalPrice - order.TotalPayment;

            lbBill.Text = order.OrderId;
            lbPrice.Text = order.TotalPrice.ToString("N0"); 
            lbDate.Text = order.Date.ToShortDateString();
            lbDeposit.Text = order.TotalPayment.ToString("N0"); 
            lbTotal.Text = order.TotalPrice.ToString("N0");
            lbPhone.Text = order.CustomerPhone;
            lbAcc.Text = order.AccountId;
            tbPaid.Text = order.TotalPayment.ToString("N0");
            int price = int.Parse(lbPrice.Text.Replace(",", "")); 
            int deposit = int.Parse(lbDeposit.Text.Replace(",", ""));
            lb_paymis.Text = (price - deposit).ToString("N0");
            var customer = _customerController.GetCustomerById(order.CustomerPhone);
            lblCusName.Text = customer?.Name ?? "Unknown";
        }

        private void LoadFertilizerDetails(string orderId)
        {
            var itemsOrdered = _itemOrderedController.GetItemsByOrderId(orderId);
            var fertilizersInfo = new List<FertilizerInfo>();

            foreach (var item in itemsOrdered)
            {
                var fertilizer = _fertilizerController.GetFertilizerById(item.FertilizerId);
                if (fertilizer != null)
                {
                    fertilizersInfo.Add(new FertilizerInfo
                    {
                        FertilizerId = item.FertilizerId,
                        Quantity = item.Quantity,
                        FertilizerName = fertilizer.Name,
                        FertilizerPrice = fertilizer.Price
                    });
                }
            }

            dataGridView2.DataSource = fertilizersInfo;
            SetFertilizerGridColumnHeaders();
        }

        private void SetFertilizerGridColumnHeaders()
        {
            var headers = new Dictionary<string, string>
            {
                { "FertilizerId", "Mã sản phẩm" },
                { "FertilizerName", "Tên sản phẩm" },
                { "Quantity", "Số lượng" },
                { "FertilizerPrice", "Giá sản phẩm" }
            };

            foreach (var header in headers)
            {
                dataGridView2.Columns[header.Key].HeaderText = header.Value;
            }
        }

        private void btn_excel(object sender, EventArgs e)
        {
			try
			{
				ExportToExcel();
			}
			catch (Exception ex)
			{
				ShowError("An error occurred while exporting to Excel", ex);
			}
		}

		private void ExportToExcel()
        {
            
            string outputDirectory = Path.Combine("D:/FertilizerTrading/output");
            Directory.CreateDirectory(outputDirectory); // Ensure directory exists

            string filePath = Path.Combine(outputDirectory, "OrdersAndFertilizers.xlsx");
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var ordersSheet = workbook.AddWorksheet("Orders");
                var fertilizersSheet = workbook.AddWorksheet("Fertilizers");
                ExportGridToExcel(ordersSheet, dataGridView1);
                ExportGridToExcel(fertilizersSheet, dataGridView2);
                workbook.SaveAs(filePath);
            }

            
            MessageBox.Show($"Excel file has been saved to {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ExportBillToPdf()
        {
			btnExportBill.Visible = false;
			btnEdit.Visible = false;
			string outputDirectory = Path.Combine("D:/FertilizerTrading/output");
            Directory.CreateDirectory(outputDirectory); 
            string filePath = Path.Combine(outputDirectory, "BillExport.pdf");
            string tempImagePath = Path.Combine(outputDirectory, "tempImage.png");
            var document = new PdfDocument { Info = { Title = "Exported Bill" } };
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var bmp = new Bitmap(pnBill.Width, pnBill.Height);
            pnBill.DrawToBitmap(bmp, new Rectangle(0, 0, pnBill.Width, pnBill.Height));
            bmp.Save(tempImagePath, System.Drawing.Imaging.ImageFormat.Png);
            var xImage = XImage.FromFile(tempImagePath);
            gfx.DrawImage(xImage, 0, 0, page.Width, page.Height);
            document.Save(filePath);
            File.Delete(tempImagePath); // Clean up temporary image
			btnExportBill.Visible = true;
			btnEdit.Visible = true;
			MessageBox.Show($"The bill has been exported to {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int paid;
            if (!int.TryParse(tbPaid.Text.ToString().Replace(",", ""), out paid))
            {
                MessageBox.Show("Please enter a valid number for the paid amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string order_id = lbBill.Text;
            string cus_id = lbPhone.Text;
            if(paid < 0 || paid > _orderController.GetOrderById(order_id).TotalPrice) {
                MessageBox.Show("Giá trị không hợp lệ");
                return;
            }
            var confirmationResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn chỉnh sửa hóa đơn: {order_id}?",
                "Confirm Action",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmationResult == DialogResult.Yes)
            {
                try
                {
                    float currentPayMiss = _orderController.GetOrderById(order_id).TotalPrice - _orderController.GetOrderById(order_id).TotalPayment;
                    _customerController.GetCustomerById(cus_id).Debt = _customerController.GetCustomerById(cus_id).Debt - currentPayMiss;
					_orderController.UpdateTotalPayment(order_id, paid);

					float currentPayMissN = _orderController.GetOrderById(order_id).TotalPrice - _orderController.GetOrderById(order_id).TotalPayment;
					_customerController.UpdateDebtById(cus_id, currentPayMissN + currentPayMiss);                    

                    MessageBox.Show("Cập nhập thành công");
                    PopulateOrderGrid();
                    DisplayOrderDetails(_orderController.GetOrderById(order_id));
				}
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi trong quá trình cập nhập");
                }
            }
        }
   
		private void btnExportBill_Click(object sender, EventArgs e)
		{
			try
			{
				ExportBillToPdf();
			}
			catch (Exception ex)
			{
				ShowError("An error occurred while exporting to PDF", ex);
			}
		}

		private void btnFind_Click(object sender, EventArgs e)
		{
			if (txbSearch.Text.Length > 0)
			{
				dataGridView1.DataSource = _orderController.FindOrder(txbSearch.Text);
				dataGridView1.Columns["OrderId"].HeaderText = "Mã hóa đơn";
				dataGridView1.Columns["TotalPrice"].HeaderText = "Tổng giá";
				dataGridView1.Columns["Date"].HeaderText = "Ngày đặt hàng";
				dataGridView1.Columns["TotalPayment"].HeaderText = "Tổng thanh toán";
				dataGridView1.Columns["CustomerPhone"].HeaderText = "Số điện thoại khách hàng";
				dataGridView1.Columns["AccountId"].HeaderText = "Mã tài khoản nhân viên";
			}
		}

        private void tbPaid_TextChanged(object sender, EventArgs e)
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
