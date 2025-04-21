namespace ShopFlowDesktop.Forms
{
    partial class StockForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnStockManage = new System.Windows.Forms.Button();
            this.btnStockStatus = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.profilePicture = new System.Windows.Forms.PictureBox();
            this.profileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.profileMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnStockManage);
            this.panel1.Controls.Add(this.btnStockStatus);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 843);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(17, 383);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(63, 64);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 261);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(68, 59);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // btnStockManage
            // 
            this.btnStockManage.BackColor = System.Drawing.Color.White;
            this.btnStockManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStockManage.Location = new System.Drawing.Point(111, 261);
            this.btnStockManage.Name = "btnStockManage";
            this.btnStockManage.Size = new System.Drawing.Size(210, 64);
            this.btnStockManage.TabIndex = 5;
            this.btnStockManage.Text = "Stok Yönetimi";
            this.btnStockManage.UseVisualStyleBackColor = false;
            this.btnStockManage.Click += new System.EventHandler(this.btnStockManage_Click);
            // 
            // btnStockStatus
            // 
            this.btnStockStatus.BackColor = System.Drawing.Color.White;
            this.btnStockStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStockStatus.Location = new System.Drawing.Point(111, 383);
            this.btnStockStatus.Name = "btnStockStatus";
            this.btnStockStatus.Size = new System.Drawing.Size(210, 59);
            this.btnStockStatus.TabIndex = 3;
            this.btnStockStatus.Text = "Stok Durumu\n";
            this.btnStockStatus.UseVisualStyleBackColor = false;
            this.btnStockStatus.Click += new System.EventHandler(this.btnStockStatus_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelName.Location = new System.Drawing.Point(12, 37);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(176, 25);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Hoş Geldiniz, Barış";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelMain.Controls.Add(this.profilePicture);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1426, 843);
            this.panelMain.TabIndex = 4;
            // 
            // profilePicture
            // 
            this.profilePicture.Image = ((System.Drawing.Image)(resources.GetObject("profilePicture.Image")));
            this.profilePicture.Location = new System.Drawing.Point(1377, 12);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(37, 50);
            this.profilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePicture.TabIndex = 1;
            this.profilePicture.TabStop = false;
            // 
            // profileMenu
            // 
            this.profileMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.profileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilToolStripMenuItem,
            this.çıkışYapToolStripMenuItem});
            this.profileMenu.Name = "profileMenu";
            this.profileMenu.Size = new System.Drawing.Size(137, 52);
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.profilToolStripMenuItem.Text = "Profil";
            // 
            // çıkışYapToolStripMenuItem
            // 
            this.çıkışYapToolStripMenuItem.Name = "çıkışYapToolStripMenuItem";
            this.çıkışYapToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.çıkışYapToolStripMenuItem.Text = "Çıkış Yap";
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 843);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMain);
            this.Name = "StockForm";
            this.Text = "Stokcu Ekranı";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.profileMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnStockManage;
        private System.Windows.Forms.Button btnStockStatus;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox profilePicture;
        private System.Windows.Forms.ContextMenuStrip profileMenu;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışYapToolStripMenuItem;
    }
}