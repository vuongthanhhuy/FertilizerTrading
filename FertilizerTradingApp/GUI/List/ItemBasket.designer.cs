namespace FertilizerTradingApp.GUI.List
{
    partial class ItemBasket
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
            this.pbItem = new System.Windows.Forms.PictureBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbNum = new System.Windows.Forms.Label();
            this.btnSub = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbItem
            // 
            this.pbItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbItem.Location = new System.Drawing.Point(114, 0);
            this.pbItem.Name = "pbItem";
            this.pbItem.Size = new System.Drawing.Size(729, 40);
            this.pbItem.TabIndex = 0;
            this.pbItem.TabStop = false;
            // 
            // btnDel
            // 
            this.btnDel.AutoSize = true;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.ForeColor = System.Drawing.Color.Red;
            this.btnDel.Location = new System.Drawing.Point(1256, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(36, 35);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "X";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lbPrice
            // 
            this.lbPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(605, 0);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbPrice.Size = new System.Drawing.Size(238, 40);
            this.lbPrice.TabIndex = 10;
            this.lbPrice.Text = "DON GIA";
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTotal
            // 
            this.lbTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(984, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbTotal.Size = new System.Drawing.Size(311, 40);
            this.lbTotal.TabIndex = 11;
            this.lbTotal.Text = "label2";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(843, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(141, 40);
            this.panel3.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbNum);
            this.panel2.Controls.Add(this.btnSub);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(135, 34);
            this.panel2.TabIndex = 2;
            // 
            // lbNum
            // 
            this.lbNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNum.Location = new System.Drawing.Point(31, 0);
            this.lbNum.Margin = new System.Windows.Forms.Padding(0);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(71, 32);
            this.lbNum.TabIndex = 1;
            this.lbNum.Text = "1";
            this.lbNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSub
            // 
            this.btnSub.AutoSize = true;
            this.btnSub.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSub.Location = new System.Drawing.Point(0, 0);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(31, 32);
            this.btnSub.TabIndex = 3;
            this.btnSub.Text = "-";
            this.btnSub.UseVisualStyleBackColor = true;
            this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(102, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(31, 32);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(491, 40);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbName
            // 
            this.lbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(114, 0);
            this.lbName.Name = "lbName";
            this.lbName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbName.Size = new System.Drawing.Size(491, 40);
            this.lbName.TabIndex = 14;
            this.lbName.Text = "TEN SP";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbId
            // 
            this.lbId.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbId.Location = new System.Drawing.Point(0, 0);
            this.lbId.Name = "lbId";
            this.lbId.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbId.Size = new System.Drawing.Size(114, 40);
            this.lbId.TabIndex = 15;
            this.lbId.Text = "MA SP";
            this.lbId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ItemBasket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.pbItem);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.lbId);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ItemBasket";
            this.Size = new System.Drawing.Size(1295, 40);
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbItem;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbId;
    }
}
