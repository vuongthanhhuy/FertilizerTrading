using FertilizerTradingApp.Controllers;
using FertilizerTradingApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI.UserForms
{
    public partial class ManageUserControl : UserControl
    {
        private CustomerController _customerController;
        private OrderController _orderController;
        private Customer _customerSelected;

        public ManageUserControl()
        {
            InitializeComponent();
            _customerController = new CustomerController();
            _orderController = new OrderController();
            _customerSelected = null;
            this.Load += CustomerControl_Load;
        }
        private void CustomerControl_Load(object sender, EventArgs e)
        {
            //try
            //{
                var customers = _customerController.GetAllCustomers();
                var formattedCustomers = customers.Select(c => new
                {
                    c.CustomerPhone,
                    c.Name,
                    c.PurchaseUpdate,
                    TotalBought = c.TotalBought.ToString("N0"), 
                    Debt = c.Debt.ToString("N0"),
                    c.Email,
                    c.PurchaseTime
				}).ToList();

                dataGridView1.DataSource = formattedCustomers;

                /*dataGridView1.Columns["CustomerPhone"].HeaderText = "Số điện thoại";
                dataGridView1.Columns["Name"].HeaderText = "Tên khách hàng";
                dataGridView1.Columns["TotalBought"].HeaderText = "Tổng tiền đã mua";
                dataGridView1.Columns["Debt"].HeaderText = "Tiền nợ";
                dataGridView1.Columns["Email"].HeaderText = "Email";
                dataGridView1.Columns["PurchaseTime"].HeaderText = "Số lần mua";*/
			    dataGridView1.Columns["CustomerPhone"].HeaderText = "Số điện thoại";
			    dataGridView1.Columns["Name"].HeaderText = "Tên khách hàng";
			    dataGridView1.Columns["PurchaseUpdate"].HeaderText = "Lần cuối mua";
			    dataGridView1.Columns["TotalBought"].HeaderText = "Tổng tiền đã mua";
			    dataGridView1.Columns["Debt"].HeaderText = "Tiền nợ";
			    dataGridView1.Columns["Email"].Visible = false;
			    dataGridView1.Columns["PurchaseTime"].HeaderText = "Số lần mua";
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show($"An error occurred while loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
		}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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

                    Customer customer = _customerController.GetCustomerById(rowData.Cells[0].Value.ToString());
                    _customerSelected = customer;

                    if (customer != null)
                    {
                        label5.Text = customer.Name;
                        label7.Text = customer.CustomerPhone;
                        label8.Text = customer.Email;
                        label12.Text = customer.PurchaseUpdate.ToString("N0");
                        label14.Text = customer.Debt.ToString("N0");
                        label15.Text = customer.TotalBought.ToString("N0");

                        var relatedData = _customerController.GetAllOrdersByCustomer(customer.CustomerPhone);
                        dataGridView2.DataSource = relatedData;
                        dataGridView2.Columns["OrderId"].HeaderText = "Mã Đơn";
                        dataGridView2.Columns["TotalPrice"].HeaderText = "Tổng hóa đơn";
                        dataGridView2.Columns["Date"].HeaderText = "Ngày Mua";
                        dataGridView2.Columns["CustomerPhone"].HeaderText = "Số điện thoại";
                        dataGridView2.Columns["AccountId"].HeaderText = "Người Phụ Trách";
                        dataGridView2.Columns["TotalPayment"].HeaderText = "Đã Trả";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while selecting a customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsDateRangeValid(dateTimePicker1, dateTimePicker2))
                {
                    if (textBox1.Text.Length > 0)
                    {
                        var data1 = _orderController.GetOrdersOfCustomer(dateTimePicker1.Value, dateTimePicker2.Value, textBox1.Text);
                        var formattedData1 = data1.Select(order => new
                        {
                            order.OrderId,
                            TotalPrice = order.TotalPrice.ToString("N0"), 
                            Date = order.Date.ToShortDateString(),
                            order.CustomerPhone,
                            order.AccountId,
                            TotalPayment = order.TotalPayment.ToString("N0") 
                        }).ToList();

                        dataGridView2.DataSource = formattedData1;
                    }
                    else
                    {
                        var data2 = _orderController.GetOrdersByTime(dateTimePicker1.Value, dateTimePicker2.Value);
                        var formattedData2 = data2.Select(order => new
                        {
                            order.OrderId,
                            TotalPrice = order.TotalPrice.ToString("N0"),
                            Date = order.Date.ToShortDateString(),
                            order.CustomerPhone,
                            order.AccountId,
                            TotalPayment = order.TotalPayment.ToString("N0") 
                        }).ToList();

                        dataGridView2.DataSource = formattedData2;
                    }

                    dataGridView2.Columns["OrderId"].HeaderText = "Mã Đơn";
                    dataGridView2.Columns["TotalPrice"].HeaderText = "Tổng hóa đơn";
                    dataGridView2.Columns["Date"].HeaderText = "Ngày Mua";
                    dataGridView2.Columns["CustomerPhone"].HeaderText = "Số điện thoại";
                    dataGridView2.Columns["AccountId"].HeaderText = "Người Phụ Trách";
                    dataGridView2.Columns["TotalPayment"].HeaderText = "Đã Trả";
                }
                else
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsDateRangeValid(DateTimePicker dateTimePicker1, DateTimePicker dateTimePicker2)
        {
            try
            {
                DateTime startDate = dateTimePicker1.Value.Date;
                DateTime endDate = dateTimePicker2.Value.Date;

                return startDate <= endDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while validating the date range: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                var customers = new List<object>(); 
                var customer = _customerController.GetCustomerById(txbSearch.Text);
                if (customer != null)
                {
                    customers.Add(new
                    {
                        customer.CustomerPhone,
                        customer.Name,
                        customer.PurchaseUpdate,
                        TotalBought = customer.TotalBought.ToString("N0"), 
                        Debt = customer.Debt.ToString("N0"),
                        customer.Email,
						customer.PurchaseTime
					});
					dataGridView1.DataSource = customers;
					dataGridView1.Columns["CustomerPhone"].HeaderText = "Số điện thoại";
					dataGridView1.Columns["Name"].HeaderText = "Tên khách hàng";
					dataGridView1.Columns["PurchaseUpdate"].HeaderText = "Lần cuối mua";
					dataGridView1.Columns["TotalBought"].HeaderText = "Tổng tiền đã mua";
					dataGridView1.Columns["Debt"].HeaderText = "Tiền nợ";
					dataGridView1.Columns["Email"].Visible = false;
					dataGridView1.Columns["PurchaseTime"].HeaderText = "Số lần mua";
				}
                else
                {
                    MessageBox.Show("Customer not found!", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

			}
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching for the customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string outputDirectory = Path.Combine("D:/AppData/output");
                Directory.CreateDirectory(outputDirectory);
                string filePath = Path.Combine(outputDirectory, "Customers.xlsx");

                using (var workbook = new ClosedXML.Excel.XLWorkbook())
                {
                    var customersSheet = workbook.AddWorksheet("Customers");
                    ExportGridToExcel(customersSheet, dataGridView1);
                    workbook.SaveAs(filePath);
                }
                MessageBox.Show($"Excel file has been saved to {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exporting to Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
