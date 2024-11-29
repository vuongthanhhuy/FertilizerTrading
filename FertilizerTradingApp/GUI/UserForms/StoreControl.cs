using FertilizerTradingApp.Controllers;
using FertilizerTradingApp.GUI.List;
using FertilizerTradingApp.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI.UserForms
{
    public partial class StoreControl : UserControl
    {
        private readonly FertilizerController _fertilizerController;
        private readonly OrderController _orderController;
        private readonly ItemOrderedController _itemOrderedController;
        private readonly CustomerController _customerController;
        public StoreControl()
        {
            InitializeComponent();
            _fertilizerController = new FertilizerController();
            _orderController = new OrderController();
            _itemOrderedController = new ItemOrderedController();
            _customerController = new CustomerController();
            populateItems(); 
        }

        private void populateItems(List<Fertilizer> fertilizers = null)
        {
            try
            {
                fertilizers = fertilizers ?? _fertilizerController.GetAllFertilizersAvailble();
                flpItems.Controls.Clear();
                foreach (var fertilizer in fertilizers)
                {
                    ItemStore item = new ItemStore
                    {
                        Name = fertilizer.Name,
                        Price = $"{fertilizer.Price.ToString("N0")} VND",
/*                        Image = LoadImage(fertilizer.Image),
*/                        Dock = DockStyle.Top
                    };

                    item.ItemAdded += (s, e) => AddToBasket(fertilizer);
                    flpItems.Controls.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Image LoadImage(string imagePath)
        {
           return Properties.Resources._20241116_052222_tawpf2qjnob_Fertilizer1; 
        }
        private void AddToBasket(Fertilizer fertilizer)
        {
            try
            {
                foreach (Control control in pnBasket.Controls)
                {
                    if (control is ItemBasket existingItem && existingItem.Id == fertilizer.Id)
                    {
                        MessageBox.Show("Đã có trong hóa đơn, vui lòng cập nhập số lượng trong hóa đơn");
                        return;
                    }
                }
                ItemBasket itemBasket = new ItemBasket
                {
                    Name = fertilizer.Name,
                    Num = "1",
                    Id = fertilizer.Id,
                    /*          ImageItem = LoadImage(fertilizer.Image), */
                    Dock = DockStyle.Top,
                    Price = fertilizer.Price.ToString("N0") + "vnd",
                    UnitPrice = fertilizer.Price
                };

                itemBasket.ItemUpdate += (s, e) => UpdateBillOnItemUpdate(itemBasket);
                itemBasket.ItemDeleted += (s, e) => RemoveFromBasket(itemBasket, fertilizer);

                pnBasket.Controls.Add(itemBasket);
                updateBill(fertilizer, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item to basket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RemoveFromBasket(ItemBasket itemBasket, Fertilizer fertilizer)
        {
            try
            {
                pnBasket.Controls.Remove(itemBasket);
                updateBill(fertilizer, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing item from basket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateBillOnItemUpdate(ItemBasket itemBasket)
        {
            try
            {
                float updatedPrice = itemBasket.GetUpdatedPrice();
                lbTotal.Text = updatedPrice.ToString("N0");
                float total = 0;
                foreach (Control control in pnBasket.Controls)
                {
                    if (control is ItemBasket basket)
                    {
                        total += basket.GetUpdatedPrice();
                    }
                }

                lbTotal.Text = total.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating bill: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void updateBill(Fertilizer fertilizer, bool flag)
        {
            try
            {
                if (flag)
                {
                    //lbAccount.Text = "{name user logged}";
                    lbTotal.Text = (float.Parse(lbTotal.Text) + fertilizer.Price).ToString("N0");
                }
                else
                {
                    //lbAccount.Text = "{name user logged}";
                    lbTotal.Text = (float.Parse(lbTotal.Text) - fertilizer.Price).ToString("N0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating bill: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExportBill_Click(object sender, EventArgs e)
        {
            try
            {
                btnExportBill.Visible = false;
                btnPay.Visible = false;
                string outputDirectory = @"D:/FertilizerTrading/output";
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                string filePath = Path.Combine(outputDirectory, "StoreBillExport.pdf");
                string tempImagePath = Path.Combine(outputDirectory, "tempImage.png");

                PdfDocument document = new PdfDocument();
                document.Info.Title = "Exported Store Bill";

                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                Bitmap bmp = new Bitmap(pnBill.Width, pnBill.Height);
                pnBill.DrawToBitmap(bmp, new Rectangle(0, 0, pnBill.Width, pnBill.Height));
                bmp.Save(tempImagePath, System.Drawing.Imaging.ImageFormat.Png);

                XImage xImage = XImage.FromFile(tempImagePath);
                gfx.DrawImage(xImage, 0, 0, page.Width, page.Height);

                document.Save(filePath);
                File.Delete(tempImagePath);
                btnExportBill.Visible = true;
                btnPay.Visible = true;
                MessageBox.Show($"The store bill has been exported to {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Kiểm tra chắc chắn bạn có ổ đĩa D:/; Hoặc tắt file export đang mở");
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Thiếu tên khách hàng");
                return;
            }
            else if (tbPhone.Text == "")
            {
                MessageBox.Show("Thiếu số điện thoại hàng");
                return;
            }
            try
            {
                if (pnBasket.Controls.Count == 0)
                {
                    MessageBox.Show("Basket is empty. Please add items before proceeding to payment.", "Empty Basket", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbPhone.Text) || string.IsNullOrWhiteSpace(tbPaid.Text))
                {
                    MessageBox.Show("Customer phone and payment amount are required.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                float totalPrice = float.Parse(lbTotal.Text);
                float totalPayment = float.Parse(tbPaid.Text);
                string customerPhone = tbPhone.Text;
                string accountId = "{account_logged}";
                var customer = _customerController.GetCustomerById(customerPhone);
                if (customer == null)
                {
                    customer = new Customer(customerPhone, DateTime.Now, totalPrice - totalPayment, totalPrice, tbName.Text, null);
                    _customerController.AddCustomer(customer);
                }
                else
                {
                    float updatedDebt = customer.Debt - totalPayment;
                    float updatedTotalBought = customer.TotalBought + totalPrice;

                    customer.Debt = updatedDebt < 0 ? 0 : updatedDebt; 
                    customer.TotalBought = updatedTotalBought;
                    customer.PurchaseUpdate = DateTime.Now;
                    customer.Name = tbName.Text;
                    customer.PurchaseTime = customer.PurchaseTime + 1;
                    if(customer.Name != _customerController.GetCustomerById(customer.CustomerPhone).Name)
                    {
                        MessageBox.Show("Sai tên khách hàng");
                        return;
                    }
                    _customerController.UpdateCustomer(customer); 
                }
                Order order = new Order(null, totalPrice, DateTime.Now, totalPayment, customerPhone, accountId);
                _orderController.AddOrder(order);
                string orderId = _orderController.getNewestOrderId();
                if (string.IsNullOrEmpty(orderId))
                {
                    MessageBox.Show("Failed to create order. Please try again.", "Order Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (Control control in pnBasket.Controls)
                {
                    if (control is ItemBasket basket)
                    {
                        int quantity = int.Parse(basket.Num);
                        string fertilizerId = basket.Id;
                        ItemOrdered item = new ItemOrdered(quantity, fertilizerId, orderId);
                        _itemOrderedController.AddItemOrdered(item);
                    }
                }
                MessageBox.Show("Payment processed successfully. Order and items saved.", "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnBasket.Controls.Clear();
                lbTotal.Text = "0.00";
                tbPaid.Text = "0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void tbPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!IsValidNumericInput(textBox, e.KeyChar))
            {
                MessageBox.Show("Chỉ chấp nhận số");
                e.Handled = true; 
            }
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

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!IsValidNumericInput(textBox, e.KeyChar))
            {
                MessageBox.Show("Chỉ chấp nhận số");
                e.Handled = true;
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
