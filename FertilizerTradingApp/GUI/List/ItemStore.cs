using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI.List
{
    public partial class ItemStore : UserControl
    {
        public ItemStore()
        {
            InitializeComponent();
        }

        #region Properties
        private string _name;
        private string _price;
        private Image _image;

        [Category("Data")]
        public new string Name
        {
            get { return _name; }
            set { _name = value; lbName.Text = value; }
        }

        [Category("Data")]
        public string Price
        {
            get { return _price; }
            set { _price = value; lbPrice.Text = value; }
        }

        [Category("Data")]
        public Image Image
        {
            get { return _image; }
            set { _image = value; pbImage.Image = value; }
        }
        #endregion
        public event EventHandler ItemAdded;
        private void btAdd_Click(object sender, EventArgs e)
        {
            ItemAdded?.Invoke(this, EventArgs.Empty);
        }
    }
}
