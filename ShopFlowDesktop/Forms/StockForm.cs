using ShopFlowDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ShopFlowDesktop.Forms
{
   
    public partial class StockForm : Form
    {
        private readonly string _userName;
        private readonly int _userId;
        public StockForm(string userName, int userId)
        {
            InitializeComponent();
            _userName = userName;
            _userId = userId;
            labelName.Text = _userName;
            profilePicture.ContextMenuStrip = profileMenu;
        }

        private void LoadForm(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void btnStockManage_Click(object sender, EventArgs e)
        {
            LoadForm(new StokManageForm(_userId));
        }

        private void btnStockStatus_Click(object sender, EventArgs e)
        {
            LoadForm(new StokStatusForm());
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
    }
}
