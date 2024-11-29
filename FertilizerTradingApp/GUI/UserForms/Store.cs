using FertilizerTradingApp.GUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI.UserForms
{
    public partial class Store : UserControl
    {
        public Store()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PurcherBill purcherBill = new PurcherBill();
            purcherBill.Show();  
        }
    }
}
