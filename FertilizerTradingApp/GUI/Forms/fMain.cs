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

namespace FertilizerTradingApp
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }
        private void SetPageToContentPanel(Control page)
        {
            page.Dock = DockStyle.Fill;
            pnControl.Controls.Clear();
            pnControl.Controls.Add(page);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetPageToContentPanel(new SystemControl());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetPageToContentPanel(new StoreControl());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetPageToContentPanel(new ManageUserControl());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetPageToContentPanel(new BillsControl());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetPageToContentPanel(new categoryControl());
        }
    }
}
