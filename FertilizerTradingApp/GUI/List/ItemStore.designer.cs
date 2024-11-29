namespace FertilizerTradingApp.GUI.List
{
    partial class ItemStore
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.lbName = new System.Windows.Forms.Label();
			this.btAdd = new System.Windows.Forms.Button();
			this.lbPrice = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbName.Location = new System.Drawing.Point(4, 0);
			this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(98, 36);
			this.lbName.TabIndex = 0;
			this.lbName.Text = "Name";
			// 
			// btAdd
			// 
			this.btAdd.BackColor = System.Drawing.SystemColors.Highlight;
			this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btAdd.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.btAdd.Location = new System.Drawing.Point(149, 122);
			this.btAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btAdd.Name = "btAdd";
			this.btAdd.Size = new System.Drawing.Size(91, 32);
			this.btAdd.TabIndex = 2;
			this.btAdd.Text = "Add";
			this.btAdd.UseVisualStyleBackColor = false;
			this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
			// 
			// lbPrice
			// 
			this.lbPrice.AutoSize = true;
			this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbPrice.Location = new System.Drawing.Point(-5, 69);
			this.lbPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbPrice.Name = "lbPrice";
			this.lbPrice.Size = new System.Drawing.Size(54, 25);
			this.lbPrice.TabIndex = 3;
			this.lbPrice.Text = "price";
			this.lbPrice.Click += new System.EventHandler(this.lbPrice_Click);
			// 
			// ItemStore
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbPrice);
			this.Controls.Add(this.btAdd);
			this.Controls.Add(this.lbName);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "ItemStore";
			this.Size = new System.Drawing.Size(244, 154);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label lbPrice;
    }
}
