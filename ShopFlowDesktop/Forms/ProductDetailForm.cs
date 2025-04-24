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
    public partial class ProductDetailForm : Form
    {
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=ShopFlowDB;Integrated Security=True;TrustServerCertificate=True";

        private int productId;
        private string productName;
        private decimal productPrice;
        private int quantity = 1;

        public int SelectedQuantity => quantity;
        public int SelectedProductId => productId;
        public string SelectedProductName => productName;
        public decimal SelectedProductPrice => productPrice;

        public ProductDetailForm(int id)
        {
            InitializeComponent();
            productId = id;
            LoadProductDetail();
        }

        private void LoadProductDetail()
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Name,Price,ImageUrl FROM Products WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@Id", productId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    productName = reader["Name"].ToString();
                    productPrice = Convert.ToDecimal(reader["Price"]);
                    string imgPath = reader["ImageUrl"].ToString();

                    lblProductName.Text = productName;
                    lblQuantity.Text = quantity.ToString();
                    picProduct.Image = LoadImage(imgPath);

                }
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private Image LoadImage(string fileName)
        {
            try
            {
                string imagePath = Path.Combine(Application.StartupPath, "images", fileName);
                if (File.Exists(imagePath))
                {
                    return Image.FromFile(imagePath);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }


        private void btnMinus_Click(object sender, EventArgs e)
        {
            if(quantity > 1) 
            {
                quantity--;
                lblQuantity.Text = quantity.ToString();
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            quantity++;
            lblQuantity.Text = quantity.ToString();
        }
    }
}
