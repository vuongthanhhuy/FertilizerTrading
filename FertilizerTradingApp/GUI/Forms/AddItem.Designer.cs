namespace FertilizerTradingApp.GUI.Forms
{
    partial class AddItem
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItem));
			this.panel5 = new System.Windows.Forms.Panel();
			this.txtName = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.txtCategory = new System.Windows.Forms.TextBox();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.btnConfirm = new System.Windows.Forms.Button();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
			this.panel5.Controls.Add(this.button1);
			this.panel5.Controls.Add(this.pictureBox1);
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Margin = new System.Windows.Forms.Padding(0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(752, 745);
			this.panel5.TabIndex = 3;
			// 
			// txtName
			// 
			this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtName.Location = new System.Drawing.Point(206, 285);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(350, 45);
			this.txtName.TabIndex = 13;
			this.txtName.Text = "Tên sản phẩm";
			this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(573, 232);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(85, 28);
			this.button1.TabIndex = 12;
			this.button1.Text = "Chọn ảnh";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(206, 10);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(350, 250);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// panel7
			// 
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.txtDescription);
			this.panel7.Controls.Add(this.panel10);
			this.panel7.Controls.Add(this.label6);
			this.panel7.Controls.Add(this.panel8);
			this.panel7.Controls.Add(this.panel9);
			this.panel7.Location = new System.Drawing.Point(84, 348);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(574, 353);
			this.panel7.TabIndex = 11;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.txtQuantity);
			this.panel10.Controls.Add(this.label5);
			this.panel10.Location = new System.Drawing.Point(33, 136);
			this.panel10.Margin = new System.Windows.Forms.Padding(0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(501, 38);
			this.panel10.TabIndex = 13;
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
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(282, 5);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(198, 22);
			this.txtPrice.TabIndex = 14;
			// 
			// txtCategory
			// 
			this.txtCategory.Location = new System.Drawing.Point(282, 9);
			this.txtCategory.Name = "txtCategory";
			this.txtCategory.Size = new System.Drawing.Size(198, 22);
			this.txtCategory.TabIndex = 14;
			// 
			// txtQuantity
			// 
			this.txtQuantity.Location = new System.Drawing.Point(282, 9);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.Size = new System.Drawing.Size(198, 22);
			this.txtQuantity.TabIndex = 14;
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(33, 219);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(501, 116);
			this.txtDescription.TabIndex = 14;
			// 
			// btnConfirm
			// 
			this.btnConfirm.Location = new System.Drawing.Point(623, 709);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(116, 23);
			this.btnConfirm.TabIndex = 14;
			this.btnConfirm.Text = "Xác nhận";
			this.btnConfirm.UseVisualStyleBackColor = true;
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// AddItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(752, 745);
			this.Controls.Add(this.panel5);
			this.Name = "AddItem";
			this.Text = "AddItem";
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TextBox txtQuantity;
		private System.Windows.Forms.TextBox txtCategory;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.Button btnConfirm;
	}
}