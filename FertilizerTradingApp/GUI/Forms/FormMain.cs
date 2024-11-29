using FertilizerTradingApp.GUI.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI.Forms
{
    public partial class FormMain : Form
    {
        private void SetPageToContentPanel(Control page)
        {
            page.Dock = DockStyle.Fill;
            pnControl.Controls.Clear();
            pnControl.Controls.Add(page);
        }

        public FormMain()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;

            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            SetPageToContentPanel(new OverviewControl());
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            SetPageToContentPanel(new OverviewControl());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            SetPageToContentPanel(new Category());
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            SetPageToContentPanel(new Bill());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetPageToContentPanel(new Store());
        }
    }
}
