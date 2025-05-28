namespace ShopFlowDesktop.Forms
{
    partial class StokStatusForm
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
            this.stockGrid = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.chkCriticalOnly = new Guna.UI2.WinForms.Guna2CheckBox();
            this.nudCriticalLevel = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stockGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCriticalLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürün Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(28, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kategori:";
            // 
            // stockGrid
            // 
            this.stockGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stockGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stockGrid.Location = new System.Drawing.Point(0, 261);
            this.stockGrid.Name = "stockGrid";
            this.stockGrid.ReadOnly = true;
            this.stockGrid.RowHeadersWidth = 51;
            this.stockGrid.RowTemplate.Height = 24;
            this.stockGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.stockGrid.Size = new System.Drawing.Size(1160, 542);
            this.stockGrid.TabIndex = 4;
            this.stockGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stockGrid_CellDoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(124, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(218, 22);
            this.txtSearch.TabIndex = 5;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(127, 81);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(155, 24);
            this.cmbCategory.TabIndex = 6;
            this.Load += new System.EventHandler(this.StockStatusForm_Load);

            // 
            // btnFilter
            // 
            this.btnFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(219, 204);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(123, 38);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Filtrele";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // chkCriticalOnly
            // 
            this.chkCriticalOnly.AutoSize = true;
            this.chkCriticalOnly.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkCriticalOnly.CheckedState.BorderRadius = 0;
            this.chkCriticalOnly.CheckedState.BorderThickness = 0;
            this.chkCriticalOnly.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkCriticalOnly.Location = new System.Drawing.Point(30, 219);
            this.chkCriticalOnly.Name = "chkCriticalOnly";
            this.chkCriticalOnly.Size = new System.Drawing.Size(151, 20);
            this.chkCriticalOnly.TabIndex = 8;
            this.chkCriticalOnly.Text = "Kritik Stokları Filtrele ";
            this.chkCriticalOnly.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkCriticalOnly.UncheckedState.BorderRadius = 0;
            this.chkCriticalOnly.UncheckedState.BorderThickness = 0;
            this.chkCriticalOnly.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // nudCriticalLevel
            // 
            this.nudCriticalLevel.BackColor = System.Drawing.Color.Transparent;
            this.nudCriticalLevel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudCriticalLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudCriticalLevel.Location = new System.Drawing.Point(223, 134);
            this.nudCriticalLevel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudCriticalLevel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCriticalLevel.Name = "nudCriticalLevel";
            this.nudCriticalLevel.Size = new System.Drawing.Size(114, 28);
            this.nudCriticalLevel.TabIndex = 9;
            this.nudCriticalLevel.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(28, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Stok Uyarı Seviyesi:";
            // 
            // StokStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 803);
            this.Controls.Add(this.nudCriticalLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkCriticalOnly);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.stockGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StokStatusForm";
            this.Text = "Stok Durumu";
            ((System.ComponentModel.ISupportInitialize)(this.stockGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCriticalLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView stockGrid;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbCategory;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2CheckBox chkCriticalOnly;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudCriticalLevel;
        private System.Windows.Forms.Label label3;
    }
}