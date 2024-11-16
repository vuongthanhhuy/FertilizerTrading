using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI.List
{
    public partial class ItemBasket : UserControl
    {
        public ItemBasket()
        {
            InitializeComponent();
        }

        #region Properties
        private string _name;
        private string _num;
        private Image _img;

        [Category("Data")]
        public string Name
        {
            get { return _name; }
            set { _name = value; lbName.Text = value; }
        }
        
        [Category("Data")]
        public string Num
        {
            get { return _num; }
            set { _num = value; lbNum.Text = value; }
        }

        [Category("Data")]
        public Image ImageItem
        {
            get { return _img; }
            set { _img = value; pbItem.Image = value; }
        }

        #endregion


        private void btnAdd_Click(object sender, EventArgs e)
        {
            int num = int.Parse(btnAdd.Text);
            btnAdd.Text = (num + 1).ToString();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            int num = int.Parse(btnAdd.Text);
            if (num > 1)
            {
                btnAdd.Text = (num - 1).ToString();
            }
        }
    }
}
