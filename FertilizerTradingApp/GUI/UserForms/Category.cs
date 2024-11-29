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
    public partial class Category : UserControl
    {
        public Category()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (btn0.BackColor != SystemColors.ControlLightLight)
            {
                btn0.BackColor = SystemColors.ControlLightLight;
            } else
            {
                btn0.BackColor = SystemColors.ControlLight;
            }
        }
    }
}
