namespace ShopFlowDesktop.Forms
{
    partial class CartForm
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
            this.gridCart = new System.Windows.Forms.DataGridView();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.btnDeleteItem = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelOrder = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCart)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCart
            // 
            this.gridCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.Price,
            this.Quantity,
            this.Total});
            this.gridCart.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridCart.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridCart.Location = new System.Drawing.Point(0, 0);
            this.gridCart.Name = "gridCart";
            this.gridCart.Size = new System.Drawing.Size(441, 286);
            this.gridCart.TabIndex = 0;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGrandTotal.Location = new System.Drawing.Point(12, 321);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(27, 20);
            this.lblGrandTotal.TabIndex = 1;
            this.lblGrandTotal.Text = "0₺";
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteItem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteItem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteItem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteItem.ForeColor = System.Drawing.Color.White;
            this.btnDeleteItem.Location = new System.Drawing.Point(249, 317);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(180, 45);
            this.btnDeleteItem.TabIndex = 2;
            this.btnDeleteItem.Text = "Seçili ürünü sil\n";
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(249, 582);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 45);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Çıkış";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCheckout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(249, 458);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(180, 45);
            this.btnCheckout.TabIndex = 4;
            this.btnCheckout.Text = "Siparişi Tamamla";
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelOrder.ForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.Location = new System.Drawing.Point(249, 388);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(180, 45);
            this.btnCancelOrder.TabIndex = 5;
            this.btnCancelOrder.Text = "Sepeti Temizle";
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(249, 519);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(180, 45);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "Excel\'e Aktar";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Ürün Adı";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Fiyat";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Adet";
            this.Quantity.Name = "Quantity";
            // 
            // Total
            // 
            this.Total.HeaderText = "Toplam Tutar";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 637);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.gridCart);
            this.Name = "CartForm";
            this.Text = "Sepet";
            ((System.ComponentModel.ISupportInitialize)(this.gridCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCart;
        private System.Windows.Forms.Label lblGrandTotal;
        private Guna.UI2.WinForms.Guna2Button btnDeleteItem;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnCheckout;
        private Guna.UI2.WinForms.Guna2Button btnCancelOrder;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}