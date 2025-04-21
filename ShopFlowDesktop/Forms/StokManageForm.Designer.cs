namespace ShopFlowDesktop.Forms
{
    partial class StokManageForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbProduct = new Guna.UI2.WinForms.Guna2ComboBox();
            this.nudQuantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnStockIn = new Guna.UI2.WinForms.Guna2Button();
            this.btnStockOut = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(56, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürün:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(56, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Miktar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(56, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Açıklama:";
            // 
            // cmbProduct
            // 
            this.cmbProduct.BackColor = System.Drawing.Color.Transparent;
            this.cmbProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbProduct.ItemHeight = 30;
            this.cmbProduct.Location = new System.Drawing.Point(185, 75);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(385, 36);
            this.cmbProduct.TabIndex = 3;
            // 
            // nudQuantity
            // 
            this.nudQuantity.BackColor = System.Drawing.Color.Transparent;
            this.nudQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudQuantity.Location = new System.Drawing.Point(383, 249);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(187, 31);
            this.nudQuantity.TabIndex = 4;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(185, 417);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(385, 28);
            this.txtNote.TabIndex = 5;
            // 
            // btnStockIn
            // 
            this.btnStockIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStockIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStockIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStockIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStockIn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnStockIn.ForeColor = System.Drawing.Color.White;
            this.btnStockIn.Location = new System.Drawing.Point(241, 562);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Size = new System.Drawing.Size(135, 50);
            this.btnStockIn.TabIndex = 6;
            this.btnStockIn.Text = "Stok Ekle";
            this.btnStockIn.Click += new System.EventHandler(this.btnStockIn_Click);
            // 
            // btnStockOut
            // 
            this.btnStockOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStockOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStockOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStockOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStockOut.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnStockOut.ForeColor = System.Drawing.Color.White;
            this.btnStockOut.Location = new System.Drawing.Point(435, 562);
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.Size = new System.Drawing.Size(135, 50);
            this.btnStockOut.TabIndex = 7;
            this.btnStockOut.Text = "Stok Azalt";
            this.btnStockOut.Click += new System.EventHandler(this.btnStockOut_Click);
            // 
            // StokManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 806);
            this.Controls.Add(this.btnStockOut);
            this.Controls.Add(this.btnStockIn);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StokManageForm";
            this.Text = "Stok Yönetimi Ekranı";
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProduct;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudQuantity;
        private System.Windows.Forms.TextBox txtNote;
        private Guna.UI2.WinForms.Guna2Button btnStockIn;
        private Guna.UI2.WinForms.Guna2Button btnStockOut;
    }
}