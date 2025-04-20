using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopFlowDesktop.Forms
{
    public partial class StokStatusForm : Form
    {
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=ShopFlowDB;Integrated Security=True;TrustServerCertificate=True";

        public StokStatusForm()
        {
            InitializeComponent();
        }

        private void  LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Tümü");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT Category FROM Products WHERE Category IS NOT NULL AND Category <> ''";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbCategory.Items.Add(reader["Category"].ToString());
                }

                reader.Close();
            }

            cmbCategory.SelectedIndex = 0;
        }

        private void LoadStockData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Name, Barcode, Category, StockQuantity FROM Products WHERE 1=1";

                // Ürün adı filtresi
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    query += " AND Name LIKE @Name";

                // Kategori filtresi
                if (cmbCategory.SelectedItem != null && cmbCategory.SelectedItem.ToString() != "Tümü")
                    query += " AND Category = @Category";

                // CheckBox: sadece kritik stoklar
                if (chkCriticalOnly.Checked)
                    query += " AND StockQuantity < @CriticalLevel";

                SqlCommand cmd = new SqlCommand(query, con);

                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    cmd.Parameters.AddWithValue("@Name", $"%{txtSearch.Text}%");

                if (cmbCategory.SelectedItem != null && cmbCategory.SelectedItem.ToString() != "Tümü")
                    cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem.ToString());

                if (chkCriticalOnly.Checked)
                    cmd.Parameters.AddWithValue("@CriticalLevel", Convert.ToInt32(nudCriticalLevel.Value));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                stockGrid.DataSource = dt;

                // Kritik stokları vurgula
                foreach (DataGridViewRow row in stockGrid.Rows)
                {
                    int stock = Convert.ToInt32(row.Cells["StockQuantity"].Value);
                    if (stock < 10)
                    {
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                }
            }
        }

        private void StockStatusForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadStockData();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadStockData();
        }

        private void stockGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string productName = stockGrid.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                var historyForm = new StockHistoryForm(productName);
                historyForm.ShowDialog();
            }
        }
    }
}
