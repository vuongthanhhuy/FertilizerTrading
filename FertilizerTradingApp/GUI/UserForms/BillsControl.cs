using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FertilizerTradingApp.Controllers;
using FertilizerTradingApp.Models;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Drawing;

namespace FertilizerTradingApp.GUI.UserForms
{
    public partial class BillsControl : UserControl
    {
        private OrderController _orderController;
        private ItemOrderedController _itemOrderedController;
        private FertilizerController _fertilizerController;
        private CustomerController _customerController;
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
            dataGridView1.DataSource = _orderController.GetAllOrders();
            dataGridView1.Columns["OrderId"].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns["TotalPrice"].HeaderText = "Tổng giá";
            dataGridView1.Columns["Date"].HeaderText = "Ngày đặt hàng";
            dataGridView1.Columns["TotalPayment"].HeaderText = "Tổng thanh toán";
            dataGridView1.Columns["CustomerPhone"].HeaderText = "Số điện thoại khách hàng";
            dataGridView1.Columns["AccountId"].HeaderText = "Mã tài khoản nhân viên";
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
                string orderId = rowData.Cells[0].Value.ToString();

                Order order = _orderController.GetOrderById(orderId);

                if (order != null)
                {

                    int paymis = ((int)order.TotalPrice) - ((int)order.TotalPayment);
                    lbBill.Text = order.OrderId;
                    lbPrice.Text = order.TotalPrice.ToString("C");
                    lbDate.Text = order.Date.ToShortDateString();
                    lbDeposit.Text = order.TotalPayment.ToString("C");
                    lb_paymis.Text = paymis.ToString();
                    lbl_cusPhone.Text = order.CustomerPhone;
                    lbAcc.Text = order.AccountId;
                    lbl_cusID.Text = order.CustomerPhone;
                    Customer customer = _customerController.GetCustomerById(order.CustomerPhone);
                    if (customer != null)
                    {
                        lblCusName.Text = customer.Name; 
                    }
                    List<ItemOrdered> itemsOrdered = _itemOrderedController.GetItemsByOrderId(orderId);
                    List<FertilizerInfo> fertilizersInfo = new List<FertilizerInfo>();
                    foreach (var item in itemsOrdered)
                    {
                        Fertilizer fertilizer = _fertilizerController.GetFertilizerById(item.FertilizerId);
                        if (fertilizer != null)
                        {
                            // Add the fertilizer's name and price to the list
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
                    dataGridView2.Columns["FertilizerId"].HeaderText = "Mã sản phẩm";
                    dataGridView2.Columns["FertilizerName"].HeaderText = "Tên sản phẩm";
                    dataGridView2.Columns["Quantity"].HeaderText = "Số lượng";
                    dataGridView2.Columns["FertilizerPrice"].HeaderText = "Giá sản phẩm";
                }
            }
        }

        private void btn_excel(object sender, EventArgs e)
        {
            string outputDirectory = Path.Combine(Application.StartupPath, "output");
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            string filePath = Path.Combine(outputDirectory, "OrdersAndFertilizers.xlsx");
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var ordersSheet = workbook.AddWorksheet("Orders");
                var fertilizersSheet = workbook.AddWorksheet("Fertilizers");
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    ordersSheet.Cell(1, i + 1).Value = dataGridView1.Columns[i].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        ordersSheet.Cell(i + 2, j + 1).Value = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                    }
                }
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    fertilizersSheet.Cell(1, i + 1).Value = dataGridView2.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView2.Columns.Count; j++)
                    {
                        fertilizersSheet.Cell(i + 2, j + 1).Value = dataGridView2.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                workbook.SaveAs(filePath);
            }
            MessageBox.Show($"Excel file has been saved to {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportBill_Click(object sender, EventArgs e)
        {
            // Define the output directory and file path
            string outputDirectory = Path.Combine(Application.StartupPath, "output");
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string filePath = Path.Combine(outputDirectory, "BillExport.pdf");
            string tempImagePath = Path.Combine(outputDirectory, "tempImage.png");

            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Exported Bill";

            // Create a new page in the PDF document
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            Bitmap bmp = new Bitmap(pnBill.Width, pnBill.Height);
            pnBill.DrawToBitmap(bmp, new Rectangle(0, 0, pnBill.Width, pnBill.Height));
            bmp.Save(tempImagePath, System.Drawing.Imaging.ImageFormat.Png);
            XImage xImage = XImage.FromFile(tempImagePath);
            gfx.DrawImage(xImage, 0, 0, page.Width, page.Height);
            document.Save(filePath);
            File.Delete(tempImagePath);
            MessageBox.Show($"The bill has been exported to {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    public class FertilizerInfo
    {
        public string FertilizerId { get; set; }
        public string FertilizerName { get; set; }
        public float FertilizerPrice { get; set; }
        public int Quantity { get; set; }
    }
}
