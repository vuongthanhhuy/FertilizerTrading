namespace FertilizerTradingApp.GUI.Forms
{
    partial class EditItem
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
			this.panel5 = new System.Windows.Forms.Panel();
			this.btnConfirm = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.panel10 = new System.Windows.Forms.Panel();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.txtCategory = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.panel5.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.btnConfirm);
			this.panel5.Controls.Add(this.txtName);
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Margin = new System.Windows.Forms.Padding(0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(752, 745);
			this.panel5.TabIndex = 3;
			// 
			// btnConfirm
			// 
			this.btnConfirm.Location = new System.Drawing.Point(623, 709);
			this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(116, 23);
			this.btnConfirm.TabIndex = 14;
			this.btnConfirm.Text = "Xác nhận";
			this.btnConfirm.UseVisualStyleBackColor = true;
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// txtName
			// 
			this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtName.Location = new System.Drawing.Point(205, 286);
			this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(351, 45);
			this.txtName.TabIndex = 13;
			this.txtName.Text = "Tên sản phẩm";
			this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// panel7
			// 
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.button1);
			this.panel7.Controls.Add(this.txtDescription);
			this.panel7.Controls.Add(this.panel10);
			this.panel7.Controls.Add(this.label6);
			this.panel7.Controls.Add(this.panel8);
			this.panel7.Controls.Add(this.panel9);
			this.panel7.Location = new System.Drawing.Point(84, 348);
			this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(574, 353);
			this.panel7.TabIndex = 11;
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(33, 219);
			this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(501, 116);
			this.txtDescription.TabIndex = 14;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.txtQuantity);
			this.panel10.Controls.Add(this.label5);
			this.panel10.Location = new System.Drawing.Point(33, 135);
			this.panel10.Margin = new System.Windows.Forms.Padding(0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(501, 38);
			this.panel10.TabIndex = 13;
			// 
			// txtQuantity
			// 
			this.txtQuantity.Location = new System.Drawing.Point(283, 9);
			this.txtQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.Size = new System.Drawing.Size(199, 22);
			this.txtQuantity.TabIndex = 14;
			this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
			this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(3, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(159, 25);
			this.label5.TabIndex = 4;
			this.label5.Text = "Số lượng tồn kho";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(260, 185);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 5;
			this.label6.Text = "Mô tả";
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.txtCategory);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Location = new System.Drawing.Point(33, 76);
			this.panel8.Margin = new System.Windows.Forms.Padding(0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(501, 37);
			this.panel8.TabIndex = 11;
			// 
			// txtCategory
			// 
			this.txtCategory.Location = new System.Drawing.Point(283, 9);
			this.txtCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtCategory.Name = "txtCategory";
			this.txtCategory.Size = new System.Drawing.Size(199, 22);
			this.txtCategory.TabIndex = 14;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 25);
			this.label3.TabIndex = 2;
			this.label3.Text = "Phân loại";
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.txtPrice);
			this.panel9.Controls.Add(this.label4);
			this.panel9.Location = new System.Drawing.Point(33, 27);
			this.panel9.Margin = new System.Windows.Forms.Padding(0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(501, 33);
			this.panel9.TabIndex = 12;
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(283, 5);
			this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(199, 22);
			this.txtPrice.TabIndex = 14;
			this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
			this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(3, 5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 25);
			this.label4.TabIndex = 3;
			this.label4.Text = "Giá";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(450, 183);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(86, 31);
			this.button1.TabIndex = 15;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// EditItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(752, 745);
			this.Controls.Add(this.panel5);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "EditItem";
			this.Text = "AddItem";
			this.Load += new System.EventHandler(this.EditItem_Load);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnConfirm;
		private System.Windows.Forms.Button button1;
	}
}