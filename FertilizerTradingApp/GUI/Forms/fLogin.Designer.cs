namespace FertilizerTradingApp.GUI
{
    partial class fLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.pnChangePass = new System.Windows.Forms.Panel();
            this.tbNewPass = new System.Windows.Forms.TextBox();
            this.lbNewPass = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnPC = new System.Windows.Forms.Panel();
            this.tbNewPC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnChangePass.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnPC.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbUsername
            // 
            this.txbUsername.Location = new System.Drawing.Point(179, 11);
            this.txbUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(137, 20);
            this.txbUsername.TabIndex = 3;
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(179, 10);
            this.txbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(137, 20);
            this.txbPassword.TabIndex = 4;
            this.txbPassword.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 119);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 55);
            this.label1.TabIndex = 5;
            this.label1.Text = "Đăng nhập";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnPC);
            this.panel2.Controls.Add(this.btnConfirm);
            this.panel2.Controls.Add(this.btnChangePass);
            this.panel2.Controls.Add(this.pnChangePass);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Location = new System.Drawing.Point(9, 133);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 223);
            this.panel2.TabIndex = 6;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(468, 191);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(94, 19);
            this.btnConfirm.TabIndex = 12;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Visible = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Location = new System.Drawing.Point(294, 191);
            this.btnChangePass.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(149, 19);
            this.btnChangePass.TabIndex = 11;
            this.btnChangePass.Text = "Đổi mật khẩu";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // pnChangePass
            // 
            this.pnChangePass.Controls.Add(this.tbNewPass);
            this.pnChangePass.Controls.Add(this.lbNewPass);
            this.pnChangePass.Location = new System.Drawing.Point(115, 85);
            this.pnChangePass.Margin = new System.Windows.Forms.Padding(2);
            this.pnChangePass.Name = "pnChangePass";
            this.pnChangePass.Size = new System.Drawing.Size(355, 37);
            this.pnChangePass.TabIndex = 10;
            this.pnChangePass.Visible = false;
            // 
            // tbNewPass
            // 
            this.tbNewPass.Location = new System.Drawing.Point(179, 10);
            this.tbNewPass.Margin = new System.Windows.Forms.Padding(2);
            this.tbNewPass.Name = "tbNewPass";
            this.tbNewPass.Size = new System.Drawing.Size(137, 20);
            this.tbNewPass.TabIndex = 4;
            this.tbNewPass.UseSystemPasswordChar = true;
            // 
            // lbNewPass
            // 
            this.lbNewPass.AutoSize = true;
            this.lbNewPass.Location = new System.Drawing.Point(28, 12);
            this.lbNewPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNewPass.Name = "lbNewPass";
            this.lbNewPass.Size = new System.Drawing.Size(74, 13);
            this.lbNewPass.TabIndex = 6;
            this.lbNewPass.Text = "Mật khẩu mới:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txbPassword);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(115, 44);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(355, 37);
            this.panel4.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txbUsername);
            this.panel3.Location = new System.Drawing.Point(115, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(355, 38);
            this.panel3.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên đăng nhập";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(181, 191);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(94, 19);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnPC
            // 
            this.pnPC.Controls.Add(this.tbNewPC);
            this.pnPC.Controls.Add(this.label4);
            this.pnPC.Location = new System.Drawing.Point(115, 126);
            this.pnPC.Margin = new System.Windows.Forms.Padding(2);
            this.pnPC.Name = "pnPC";
            this.pnPC.Size = new System.Drawing.Size(355, 37);
            this.pnPC.TabIndex = 11;
            this.pnPC.Visible = false;
            // 
            // tbNewPC
            // 
            this.tbNewPC.Location = new System.Drawing.Point(179, 10);
            this.tbNewPC.Margin = new System.Windows.Forms.Padding(2);
            this.tbNewPC.Name = "tbNewPC";
            this.tbNewPC.Size = new System.Drawing.Size(137, 20);
            this.tbNewPC.TabIndex = 4;
            this.tbNewPC.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhập lại mật khẩu mới:";
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mua bán phân bón";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnChangePass.ResumeLayout(false);
            this.pnChangePass.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnPC.ResumeLayout(false);
            this.pnPC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnChangePass;
        private System.Windows.Forms.TextBox tbNewPass;
        private System.Windows.Forms.Label lbNewPass;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel pnPC;
        private System.Windows.Forms.TextBox tbNewPC;
        private System.Windows.Forms.Label label4;
    }
}

