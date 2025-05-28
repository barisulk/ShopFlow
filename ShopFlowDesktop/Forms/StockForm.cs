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

        private Form aktif_form = null;
        private void LoadForm(Form childForm)
        {
            if (aktif_form != null)
            {
                aktif_form.Close(); // varsa eski ekranı kapat
            }

            aktif_form = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Clear(); // paneli temizle
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
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
            new UserProfileForm(_userId).ShowDialog();
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

        private void profilePicture_Click(object sender, EventArgs e)
        {

        }
    }
}
