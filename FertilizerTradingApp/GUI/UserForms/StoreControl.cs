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
                fertilizers = fertilizers ?? _fertilizerController.GetAllFertilizers();
                flpItems.Controls.Clear();
                foreach (var fertilizer in fertilizers)
                {
                    ItemStore item = new ItemStore
                    {
                        Name = fertilizer.Name,
                        Price = $"${fertilizer.Price:F2}",
                        Image = LoadImage(fertilizer.Image),
                        Dock = DockStyle.Top
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
            try
            {
                string imagesPath = Path.Combine(@"D:/AppData/resource", imagePath);
                if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagesPath))
                {
                    throw new ArgumentException("Invalid or missing image path.");
                }
                return Image.FromFile(imagesPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Properties.Resources._20241116_052222_tawpf2qjnob_Fertilizer1; 
            }
        }
        private void AddToBasket(Fertilizer fertilizer)
        {
            try
            {
                ItemBasket itemBasket = new ItemBasket
                {
                    Name = fertilizer.Name,
                    Num = "1",
                    Id = fertilizer.Id,
                    ImageItem = LoadImage(fertilizer.Image),
                    Dock = DockStyle.Top,
                    Price = fertilizer.Price.ToString() + "vnd",
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
                lbTotal.Text = updatedPrice.ToString("F2");
                float total = 0;
                foreach (Control control in pnBasket.Controls)
                {
                    if (control is ItemBasket basket)
                    {
                        total += basket.GetUpdatedPrice();
                    }
                }

                lbTotal.Text = total.ToString("F2");
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
                    lbAccount.Text = "{name user logged}";
                    lbTotal.Text = (float.Parse(lbTotal.Text) + fertilizer.Price).ToString("F2");
                }
                else
                {
                    lbAccount.Text = "{name user logged}";
                    lbTotal.Text = (float.Parse(lbTotal.Text) - fertilizer.Price).ToString("F2");
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
                string outputDirectory = @"D:/AppData/output";
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

                MessageBox.Show($"The store bill has been exported to {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting bill: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
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

                    customer.Debt = updatedDebt < 0 ? 0 : updatedDebt; // Avoid negative debt
                    customer.TotalBought = updatedTotalBought;
                    customer.PurchaseTime = DateTime.Now;
                    customer.Name = tbName.Text; // Update name if provided

                    _customerController.UpdateCustomer(customer); // Ensure this method exists in your controller
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
            //try
            //{
            //    string key = txbSearch.Text.Trim().ToLower();
            //    if (!string.IsNullOrEmpty(key))
            //    {
            //        List<Fertilizer> filteredFertilizers = _fertilizerController.GetAllFertilizers()
            //            .FindAll(f => f.Name.ToLower().Contains(key));
            //        populateItems(filteredFertilizers);
            //    }
            //    else
            //    {
            //        populateItems();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error searching items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


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
                    float updatedDebt = customer.Debt + (totalPrice-totalPayment);
                    float updatedTotalBought = customer.TotalBought + totalPrice;
                    customer.Debt = updatedDebt < 0 ? 0 : updatedDebt;
                    customer.TotalBought = updatedTotalBought;
                    customer.PurchaseTime = DateTime.Now;
                    customer.Name = tbName.Text; 

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
    }
}
