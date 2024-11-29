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
    public partial class Bill : UserControl
    {
        public Bill()
        {
            InitializeComponent();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            panel8.Size = new System.Drawing.Size(371, 118);
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            panel8.Size = new System.Drawing.Size(371, 28);
        }
    }
}
