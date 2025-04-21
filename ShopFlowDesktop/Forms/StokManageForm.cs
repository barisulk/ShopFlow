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
    public partial class StokManageForm : Form
    {
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=ShopFlowDB;Integrated Security=True;TrustServerCertificate=True";
        private readonly int userId;
        public StokManageForm(int UserId)
        {
            InitializeComponent();
            this.userId = UserId;
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id,Name FROM Products";
                SqlCommand cmd = new SqlCommand(query,con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                cmbProduct.DisplayMember = "Name";
                cmbProduct.ValueMember = "Id";
                cmbProduct.DataSource = dt;
            }
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            RecordStockChange("Giriş");
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            RecordStockChange("Çıkış");
        }

        private void RecordStockChange(string changeType)
        {
            if (cmbProduct.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.");
                return;
            }

            int quantity = Convert.ToInt32(nudQuantity.Value);
            int productId = Convert.ToInt32(cmbProduct.SelectedValue);
            string note = txtNote.Text.Trim();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlTransaction transaction;
                con.Open();
                transaction = con.BeginTransaction();

                try
                {
                    // 1. Stock_Changes tablosuna ekle
                    string insertQuery = @"
                        INSERT INTO Stock_Changes (ProductId, UserId, ChangeType, Quantity, Date)
                        VALUES (@ProductId, @UserId, @ChangeType, @Quantity, @Date)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, con, transaction);
                    insertCmd.Parameters.AddWithValue("@ProductId", productId);
                    insertCmd.Parameters.AddWithValue("@UserId", userId);
                    insertCmd.Parameters.AddWithValue("@ChangeType", changeType);
                    insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                    insertCmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    insertCmd.ExecuteNonQuery();

                    // 2. Products tablosunda stok güncelle
                    string updateQuery = changeType == "Giriş"
                        ? "UPDATE Products SET StockQuantity = StockQuantity + @Quantity WHERE Id = @ProductId"
                        : "UPDATE Products SET StockQuantity = StockQuantity - @Quantity WHERE Id = @ProductId";

                    SqlCommand updateCmd = new SqlCommand(updateQuery, con, transaction);
                    updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                    updateCmd.Parameters.AddWithValue("@ProductId", productId);
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Stok işlemi başarıyla gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearForm()
        {
            cmbProduct.SelectedIndex = -1;
            nudQuantity.Value = 1;
            txtNote.Clear();
        }
    }
}
