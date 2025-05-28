using System;

namespace ShopFlowDesktop.Forms
{
    partial class LoginForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.isim = new System.Windows.Forms.Label();
            this.eposta_input = new Guna.UI2.WinForms.Guna2TextBox();
            this.sifre_input = new Guna.UI2.WinForms.Guna2TextBox();
            this.login_button = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // isim
            // 
            this.isim.AutoSize = true;
            this.isim.Font = new System.Drawing.Font("Microsoft YaHei", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isim.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.isim.Location = new System.Drawing.Point(127, 43);
            this.isim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.isim.Name = "isim";
            this.isim.Size = new System.Drawing.Size(254, 58);
            this.isim.TabIndex = 0;
            this.isim.Text = "Shop Flow";
            this.isim.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // eposta_input
            // 
            this.eposta_input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.eposta_input.DefaultText = "";
            this.eposta_input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.eposta_input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.eposta_input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.eposta_input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.eposta_input.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.eposta_input.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.eposta_input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.eposta_input.Location = new System.Drawing.Point(99, 149);
            this.eposta_input.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eposta_input.Name = "eposta_input";
            this.eposta_input.PlaceholderText = "e-posta";
            this.eposta_input.SelectedText = "";
            this.eposta_input.ShadowDecoration.Color = System.Drawing.Color.WhiteSmoke;
            this.eposta_input.Size = new System.Drawing.Size(333, 31);
            this.eposta_input.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.eposta_input.TabIndex = 1;
            // 
            // sifre_input
            // 
            this.sifre_input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.sifre_input.DefaultText = "";
            this.sifre_input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sifre_input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.sifre_input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.sifre_input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.sifre_input.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sifre_input.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sifre_input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sifre_input.Location = new System.Drawing.Point(99, 217);
            this.sifre_input.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sifre_input.Name = "sifre_input";
            this.sifre_input.PlaceholderText = "şifre";
            this.sifre_input.SelectedText = "";
            this.sifre_input.ShadowDecoration.Color = System.Drawing.Color.WhiteSmoke;
            this.sifre_input.Size = new System.Drawing.Size(333, 31);
            this.sifre_input.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.sifre_input.TabIndex = 2;
            this.sifre_input.UseSystemPasswordChar = true;
            // 
            // login_button
            // 
            this.login_button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.login_button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.login_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.login_button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.login_button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(79)))), ((int)(((byte)(77)))));
            this.login_button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.login_button.ForeColor = System.Drawing.Color.White;
            this.login_button.Location = new System.Drawing.Point(167, 287);
            this.login_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(188, 39);
            this.login_button.TabIndex = 7;
            this.login_button.Text = "Giriş Yap";
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(113)))), ((int)(((byte)(122)))));
            this.ClientSize = new System.Drawing.Size(512, 444);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.sifre_input);
            this.Controls.Add(this.eposta_input);
            this.Controls.Add(this.isim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
            private void LoginForm_Load(object sender, EventArgs e) {}








        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label isim;
        private Guna.UI2.WinForms.Guna2TextBox eposta_input;
        private Guna.UI2.WinForms.Guna2TextBox sifre_input;
        private Guna.UI2.WinForms.Guna2Button login_button;
    }
}