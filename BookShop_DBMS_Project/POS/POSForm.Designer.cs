namespace BookShop_DBMS_Project.POS
{
    partial class POSForm
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
            this.pnHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnOrder = new System.Windows.Forms.Panel();
            this.lvOrder = new System.Windows.Forms.ListView();
            this.no_ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itm_ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qty_ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cost_ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPay = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lbTotalCost = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flpOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.cbCate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnHeader.SuspendLayout();
            this.pnOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            this.pnHeader.Controls.Add(this.cbCate);
            this.pnHeader.Controls.Add(this.label4);
            this.pnHeader.Controls.Add(this.label1);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(10, 10);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1260, 94);
            this.pnHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kode Mono", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(518, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "SELECT ITEM HERE";
            // 
            // pnOrder
            // 
            this.pnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(176)))), ((int)(((byte)(170)))));
            this.pnOrder.Controls.Add(this.lvOrder);
            this.pnOrder.Controls.Add(this.btnPay);
            this.pnOrder.Controls.Add(this.btnClear);
            this.pnOrder.Controls.Add(this.lbTotalCost);
            this.pnOrder.Controls.Add(this.label3);
            this.pnOrder.Controls.Add(this.label2);
            this.pnOrder.Controls.Add(this.dgvData);
            this.pnOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnOrder.Location = new System.Drawing.Point(1280, 10);
            this.pnOrder.Name = "pnOrder";
            this.pnOrder.Size = new System.Drawing.Size(400, 930);
            this.pnOrder.TabIndex = 1;
            // 
            // lvOrder
            // 
            this.lvOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no_,
            this.itm_,
            this.qty_,
            this.cost_});
            this.lvOrder.Font = new System.Drawing.Font("Kode Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvOrder.HideSelection = false;
            this.lvOrder.Location = new System.Drawing.Point(12, 66);
            this.lvOrder.Name = "lvOrder";
            this.lvOrder.Size = new System.Drawing.Size(375, 734);
            this.lvOrder.TabIndex = 4;
            this.lvOrder.UseCompatibleStateImageBehavior = false;
            this.lvOrder.View = System.Windows.Forms.View.Details;
            // 
            // no_
            // 
            this.no_.Text = "NO";
            // 
            // itm_
            // 
            this.itm_.Text = "ITEMS";
            this.itm_.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.itm_.Width = 150;
            // 
            // qty_
            // 
            this.qty_.Text = "QTY";
            this.qty_.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cost_
            // 
            this.cost_.Text = "COST";
            this.cost_.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cost_.Width = 105;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Kode Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(12, 875);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(375, 37);
            this.btnPay.TabIndex = 3;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Kode Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(273, 11);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(114, 37);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lbTotalCost
            // 
            this.lbTotalCost.AutoSize = true;
            this.lbTotalCost.Font = new System.Drawing.Font("Kode Mono", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalCost.ForeColor = System.Drawing.Color.Red;
            this.lbTotalCost.Location = new System.Drawing.Point(268, 818);
            this.lbTotalCost.Name = "lbTotalCost";
            this.lbTotalCost.Size = new System.Drawing.Size(101, 37);
            this.lbTotalCost.TabIndex = 1;
            this.lbTotalCost.Text = "$ 0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kode Mono", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 823);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "TOTAL :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kode Mono", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "ODERED ITEM";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(54, 201);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(240, 150);
            this.dgvData.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1270, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 930);
            this.panel2.TabIndex = 2;
            // 
            // flpOrder
            // 
            this.flpOrder.AutoScroll = true;
            this.flpOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOrder.Location = new System.Drawing.Point(10, 104);
            this.flpOrder.Name = "flpOrder";
            this.flpOrder.Padding = new System.Windows.Forms.Padding(10);
            this.flpOrder.Size = new System.Drawing.Size(1260, 836);
            this.flpOrder.TabIndex = 3;
            // 
            // cbCate
            // 
            this.cbCate.Font = new System.Drawing.Font("Kode Mono", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCate.FormattingEnabled = true;
            this.cbCate.Location = new System.Drawing.Point(36, 50);
            this.cbCate.Name = "cbCate";
            this.cbCate.Size = new System.Drawing.Size(270, 28);
            this.cbCate.TabIndex = 2;
            this.cbCate.SelectedIndexChanged += new System.EventHandler(this.cbCate_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kode Mono", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(32, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "CATEGORY";
            // 
            // POSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1690, 960);
            this.Controls.Add(this.flpOrder);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "POSForm";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POSForm";
            this.Load += new System.EventHandler(this.POSForm_Load);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.pnOrder.ResumeLayout(false);
            this.pnOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnOrder;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvOrder;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label lbTotalCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flpOrder;
        private System.Windows.Forms.ColumnHeader no_;
        private System.Windows.Forms.ColumnHeader itm_;
        private System.Windows.Forms.ColumnHeader qty_;
        private System.Windows.Forms.ColumnHeader cost_;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ComboBox cbCate;
        private System.Windows.Forms.Label label4;
    }
}