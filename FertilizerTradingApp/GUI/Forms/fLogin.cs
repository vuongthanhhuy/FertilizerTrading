using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using FertilizerTradingApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FertilizerTradingApp.GUI
{
    public partial class fLogin : Form
    {
        private readonly LoginController _loginController;
        public fLogin()
        {
            InitializeComponent();
            _loginController = new LoginController();
            this.AcceptButton = btnLogin;
		}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text;
            string password = txbPassword.Text;
            if (username == null || password == null)
            {
                MessageBox.Show("Thiếu thông tin");
                return;
            }
            if(_loginController.LoginCheck(username, password))
            {
                this.Hide();
                fMain fMain = new fMain();
                fMain.ShowDialog();
                this.Show();
                txbPassword.Clear();
            }
			else
            {
                MessageBox.Show("Sai thông tin đăng nhập");
            }
        }
    }
}
