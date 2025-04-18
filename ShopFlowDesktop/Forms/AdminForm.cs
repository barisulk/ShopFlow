﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopFlowDesktop.Forms
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            profilePicture.ContextMenuStrip = profileMenu;

        }

        private void profilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Profil Ekranı Çok Yakında");
        }

        private void cikisYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Çıkış yapmak istediğinizden emin misiniz?",
                    "Çıkış Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            if (result == DialogResult.Yes) 
            {
                Application.Exit();

            }
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserManagementForm());
        }

        private Form aktif_form = null;

        private void OpenChildForm(Form childForm)
        {
            if (aktif_form != null) 
            {
                aktif_form = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelMain.Controls.Add(childForm);
                panelMain.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();

            }
        }
    }
}
