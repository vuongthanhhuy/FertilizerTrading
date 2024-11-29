using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;
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

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (pnChangePass.Visible == false)
            {
                pnChangePass.Visible = true;
                pnPC.Visible = true;
                btnLogin.Enabled = false;
                btnConfirm.Visible = true;
                tbNewPass.Text = "";
                tbNewPC.Text = "";
                btnChangePass.Text = "Quay về đăng nhập";
            }
            else
            {
                pnChangePass.Visible = false;
                pnPC.Visible = false;
                btnLogin.Enabled = true;
                btnConfirm.Visible = false;
                tbNewPass.Text = "";
                tbNewPC.Text = "";
                btnChangePass.Text = "Đổi mật khẩu";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text;
            string curP = txbPassword.Text;
            string newP = tbNewPass.Text;
            string confirmP = tbNewPC.Text;
            if(curP == null || newP == null) {
                MessageBox.Show("Hãy nhập mật khẩu");
                return; }
            if (!newP.Equals(confirmP)){
                MessageBox.Show("Mật khẩu không khớp");
                return;
            }
            if (_loginController.UpdatePassword(username, curP, newP)){
                MessageBox.Show("Cập nhập thành công");
            }
        }
    }
}
