using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopFlowDesktop.Forms
{
    public partial class ProductManagment : Form
    {
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=ShopFlowDB;Integrated Security=True;TrustServerCertificate=True";
        private int selectedProductId = -1;
        private string selectedImageFileName = "";

        public ProductManagment()
        {
            InitializeComponent();
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("Tümü");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT Category FROM Products WHERE Category IS NOT NULL AND Category <> ''";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string category = reader["Category"].ToString();
                    cmbFilterCategory.Items.Add(category);
                    cmbFilterCategory.Items.Add(category);
                }
            }

            cmbFilterCategory.SelectedIndex = 0; // "Tümü"
        }

        private void LoadProducts(string search = "", string filterCategory = "Tümü")
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Barcode, Category, StockQuantity, Price, ImageUrl FROM Products WHERE 1=1";
                if (!string.IsNullOrWhiteSpace(search))
                    query += " AND Name LIKE @Search";

                if (filterCategory != "Tümü")
                    query += " AND Category = @Category";

                SqlCommand cmd = new SqlCommand(query, con);
                if (!string.IsNullOrWhiteSpace(search))
                    cmd.Parameters.AddWithValue("@Search", $"%{search}%");

                if (filterCategory != "Tümü")
                    cmd.Parameters.AddWithValue("@Category", filterCategory);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                productGrid.DataSource = dt;
            }
        }
        

        private void picturePreview_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imageFolder = Path.Combine(Application.StartupPath, "images");
                if (!Directory.Exists(imageFolder))
                    Directory.CreateDirectory(imageFolder);

                string fileName = Path.GetFileName(ofd.FileName);
                string targetPath = Path.Combine(imageFolder, fileName);

                if (!File.Exists(targetPath))
                    File.Copy(ofd.FileName, targetPath);

                selectedImageFileName = fileName;
                txtImagePath.Text = fileName;

                picturePreview.Image = Image.FromFile(targetPath);
                picturePreview.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text == "" || cmbFilterCategory.Text == "")
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Products (Name, Barcode, Category, StockQuantity, Price, ImageUrl) VALUES (@Name, @Barcode, @Category, @Stock, @Price, @ImageUrl)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtProductName.Text);
                cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                cmd.Parameters.AddWithValue("@Category", cmbFilterCategory.Text);
                cmd.Parameters.AddWithValue("@Stock", (int)numStock.Value);
                cmd.Parameters.AddWithValue("@Price", numPrice.Value);
                cmd.Parameters.AddWithValue("@ImageUrl", selectedImageFileName);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün eklendi.");
                ClearForm();
                LoadProducts();
                LoadCategories();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedProductId == -1)
            {
                MessageBox.Show("Lütfen güncellemek için bir ürün seçin.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET Name = @Name, Barcode = @Barcode, Category = @Category, StockQuantity = @Stock, Price = @Price, ImageUrl = @ImageUrl WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", selectedProductId);
                cmd.Parameters.AddWithValue("@Name", txtProductName.Text);
                cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                cmd.Parameters.AddWithValue("@Category", cmbFilterCategory.Text);
                cmd.Parameters.AddWithValue("@Stock", (int)numStock.Value);
                cmd.Parameters.AddWithValue("@Price", numPrice.Value);
                cmd.Parameters.AddWithValue("@ImageUrl", selectedImageFileName);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün güncellendi.");
                ClearForm();
                LoadProducts();
                LoadCategories();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductId == -1)
            {
                MessageBox.Show("Lütfen silmek için bir ürün seçin.");
                return;
            }

            var result = MessageBox.Show("Ürünü silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Products WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", selectedProductId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ürün silindi.");
                    ClearForm();
                    LoadProducts();
                    LoadCategories();
                }
            }
        }

        private void productGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedProductId = Convert.ToInt32(productGrid.Rows[e.RowIndex].Cells["Id"].Value);
            txtProductName.Text = productGrid.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            txtBarcode.Text = productGrid.Rows[e.RowIndex].Cells["Barcode"].Value.ToString();
            cmbFilterCategory.Text = productGrid.Rows[e.RowIndex].Cells["Category"].Value.ToString();
            numStock.Value = Convert.ToInt32(productGrid.Rows[e.RowIndex].Cells["StockQuantity"].Value);
            numPrice.Value = Convert.ToDecimal(productGrid.Rows[e.RowIndex].Cells["Price"].Value);

            selectedImageFileName = productGrid.Rows[e.RowIndex].Cells["ImageUrl"].Value.ToString();
            txtImagePath.Text = selectedImageFileName;

            string imagePath = Path.Combine(Application.StartupPath, "images", selectedImageFileName);
            if (File.Exists(imagePath))
                picturePreview.Image = Image.FromFile(imagePath);
            else
                picturePreview.Image = null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text, cmbFilterCategory.Text);
        }

        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text, cmbFilterCategory.Text);
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterCategory.SelectedIndex = 0;
            LoadProducts();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtProductName.Clear();
            txtBarcode.Clear();
            cmbFilterCategory.SelectedIndex = -1;
            numStock.Value = 0;
            numPrice.Value = 0;
            txtImagePath.Clear();
            picturePreview.Image = null;
            selectedProductId = -1;
            selectedImageFileName = "";
            productGrid.ClearSelection();
        }
    }
}
