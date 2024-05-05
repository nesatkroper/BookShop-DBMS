namespace BookShop_DBMS_Project.POS
{
    partial class OrderList
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
            this.pcOrderPic = new System.Windows.Forms.PictureBox();
            this.lbOrderTitle = new System.Windows.Forms.Label();
            this.lbOrderPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbOrderCate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcOrderPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pcOrderPic
            // 
            this.pcOrderPic.Location = new System.Drawing.Point(180, 22);
            this.pcOrderPic.Name = "pcOrderPic";
            this.pcOrderPic.Size = new System.Drawing.Size(119, 99);
            this.pcOrderPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcOrderPic.TabIndex = 0;
            this.pcOrderPic.TabStop = false;
            // 
            // lbOrderTitle
            // 
            this.lbOrderTitle.AutoSize = true;
            this.lbOrderTitle.Font = new System.Drawing.Font("Kode Mono", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbOrderTitle.Location = new System.Drawing.Point(8, 22);
            this.lbOrderTitle.Name = "lbOrderTitle";
            this.lbOrderTitle.Size = new System.Drawing.Size(24, 29);
            this.lbOrderTitle.TabIndex = 1;
            this.lbOrderTitle.Text = "?";
            // 
            // lbOrderPrice
            // 
            this.lbOrderPrice.AutoSize = true;
            this.lbOrderPrice.Font = new System.Drawing.Font("Kode Mono", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrderPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbOrderPrice.Location = new System.Drawing.Point(28, 84);
            this.lbOrderPrice.Name = "lbOrderPrice";
            this.lbOrderPrice.Size = new System.Drawing.Size(31, 37);
            this.lbOrderPrice.TabIndex = 1;
            this.lbOrderPrice.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Kode Mono", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(8, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "$";
            // 
            // lbOrderCate
            // 
            this.lbOrderCate.AutoSize = true;
            this.lbOrderCate.Font = new System.Drawing.Font("Kode Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrderCate.Location = new System.Drawing.Point(10, 55);
            this.lbOrderCate.Name = "lbOrderCate";
            this.lbOrderCate.Size = new System.Drawing.Size(22, 25);
            this.lbOrderCate.TabIndex = 1;
            this.lbOrderCate.Text = "?";
            // 
            // OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbOrderPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbOrderCate);
            this.Controls.Add(this.lbOrderTitle);
            this.Controls.Add(this.pcOrderPic);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "OrderList";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(312, 143);
            this.Load += new System.EventHandler(this.OrderList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcOrderPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcOrderPic;
        private System.Windows.Forms.Label lbOrderTitle;
        private System.Windows.Forms.Label lbOrderPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbOrderCate;
    }
}
