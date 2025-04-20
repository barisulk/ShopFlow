namespace ShopFlowDesktop.Forms
{
    partial class StockHistoryForm
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
            this.stockHistoryGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.stockHistoryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // stockHistoryGrid
            // 
            this.stockHistoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockHistoryGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockHistoryGrid.Location = new System.Drawing.Point(0, 0);
            this.stockHistoryGrid.Name = "stockHistoryGrid";
            this.stockHistoryGrid.RowHeadersWidth = 51;
            this.stockHistoryGrid.RowTemplate.Height = 24;
            this.stockHistoryGrid.Size = new System.Drawing.Size(800, 450);
            this.stockHistoryGrid.TabIndex = 0;
            // 
            // StockHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stockHistoryGrid);
            this.Name = "StockHistoryForm";
            this.Text = "StockHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.stockHistoryGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView stockHistoryGrid;
    }
}