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
using ShopFlowDesktop.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace ShopFlowDesktop.Forms
{
    public partial class SalesForm : Form
    {
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=ShopFlowDB;Integrated Security=True;TrustServerCertificate=True";

        private List<CartItem> cart = new List<CartItem>();

        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }


        private void LoadProducts()
        {
            flowProductsPanel.Controls.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Price, ImageUrl FROM Products WHERE StockQuantity > 0";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = reader["Name"].ToString();
                    decimal price = Convert.ToDecimal(reader["Price"]);
                    string imageUrl = reader["ImageUrl"].ToString();

                    ProductCard card = new ProductCard();
                    card.ProductId = id;
                    card.SetProduct(name, price, LoadImage(imageUrl));

                    // Sepete Ekleme
                    card.btnAddToCart.Click += (s, e) => AddToCart(id, name, price);

                    // Resme tıklayınca detay
                    card.picProduct.Click += (s, e) =>
                    {
                        var detail = new ProductDetailForm(id);
                        if (detail.ShowDialog() == DialogResult.OK)
                        {
                            AddToCart(
                                detail.SelectedProductId,
                                detail.SelectedProductName,
                                detail.SelectedProductPrice,
                                detail.SelectedQuantity
                            );
                        }
                    };

                    flowProductsPanel.Controls.Add(card);
                }

                reader.Close();
            }
        }

        private Image LoadImage(string fileName)
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, "images", fileName);
                if (File.Exists(path))
                {
                    return Image.FromFile(path);
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

        private void AddToCart(int productId, string name, decimal price, int quantity)
        {
            var existing = cart.FirstOrDefault(c => c.ProductId == productId);
            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = name,
                    UnitPrice = price,
                    Quantity = quantity
                });
            }

            MessageBox.Show($"🛒 {name} sepete eklendi.", "Sepet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateCartTotal();
        }

        private void AddToCart(int productId, string name, decimal price)
        {
            AddToCart(productId, name, price, 1);
        }

        private void UpdateCartTotal()
        {
            decimal total = cart.Sum(x => x.UnitPrice * x.Quantity);
            lblTotalAmount.Text = $"₺{total:N2}";
        }

       


    }
}
