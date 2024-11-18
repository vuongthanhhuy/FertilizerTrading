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
        private string _price;
        private string _id;
        private float _unitPrice; // to store the unit price

        [Category("Data")]
        public new string Name
        {
            get { return _name; }
            set { _name = value; lbName.Text = value; }
        }
        [Category("Data")]
        public string Id
        {
            get { return _id; }
            set { _id = value; lbId.Text = value; }
        }
        [Category("Data")]
        public string Price
        {
            get { return _price; }
            set { _price = value; lbPrice.Text = value; }
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

        public float UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        #endregion

        public event EventHandler ItemUpdate;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int num = int.Parse(lbNum.Text);
            lbNum.Text = (num + 1).ToString();
            ItemUpdate?.Invoke(this, EventArgs.Empty);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            int num = int.Parse(lbNum.Text);
            if (num > 1)
            {
                lbNum.Text = (num - 1).ToString();
                ItemUpdate?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler ItemDeleted;
        private void btnDel_Click(object sender, EventArgs e)
        {
            ItemDeleted?.Invoke(this, EventArgs.Empty);
        }

        // To get the updated price
        public float GetUpdatedPrice()
        {
            return float.Parse(lbNum.Text) * _unitPrice; // updated price = quantity * unit price
        }
    }
}
