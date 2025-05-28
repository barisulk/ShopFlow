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
using OfficeOpenXml;
using System.IO;
using ShopFlowDesktop.Models;
using static ShopFlowDesktop.Forms.SalesForm;
using System.Net.NetworkInformation;

namespace ShopFlowDesktop.Forms
{
    public partial class CartForm : Form
    {
        private List<CartItem> cart;
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=ShopFlowDB;Integrated Security=True;TrustServerCertificate=True";
        private readonly int userId;
        public CartForm(List<CartItem> currentCart, int currentUserId)
        {
            InitializeComponent();
            cart = currentCart;
            InitializeGrid();
            LoadCart();
            this.userId = currentUserId;
        }

        private void LoadCart()
        {
            gridCart.Rows.Clear();
            decimal total = 0;

            foreach (var item in cart)
            {
                int index = gridCart.Rows.Add();
                gridCart.Rows[index].Cells["ProductName"].Value = item.ProductName;
                gridCart.Rows[index].Cells["Price"].Value = item.UnitPrice.ToString("C2");
                gridCart.Rows[index].Cells["Quantity"].Value = item.Quantity;
                gridCart.Rows[index].Cells["Total"].Value = (item.UnitPrice * item.Quantity).ToString("C2");

                total += item.UnitPrice * item.Quantity;
            }

            lblGrandTotal.Text = $"Toplam: {total:C2}";

        }

        private void InitializeGrid()
        {
            gridCart.Columns.Clear();
            gridCart.Columns.Add("ProductName", "Ürün Adı");
            gridCart.Columns.Add("Price", "Fiyat");
            gridCart.Columns.Add("Quantity", "Adet");
            gridCart.Columns.Add("Total", "Toplam Tutar");

            gridCart.Columns["ProductName"].ReadOnly = true;
            gridCart.Columns["Price"].ReadOnly = true;
            gridCart.Columns["Total"].ReadOnly = true;

            gridCart.EditMode = DataGridViewEditMode.EditOnEnter;
            gridCart.AllowUserToAddRows = false;
            gridCart.CellValueChanged += GridCart_CellValueChanged;
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (gridCart.SelectedRows.Count > 0)
            {
                string selectedProduct = gridCart.SelectedRows[0].Cells["ProductName"].Value.ToString();
                var itemToRemove = cart.FirstOrDefault(c => c.ProductName == selectedProduct);
                if (itemToRemove != null)
                {
                    cart.Remove(itemToRemove);
                    LoadCart();
                }
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Siparişi iptal etmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cart.Clear();
                LoadCart();
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Sepet boş, satış tamamlanamaz.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    string insertSale = "INSERT INTO Sales (UserId, TotalAmount, Date, Status) OUTPUT INSERTED.Id VALUES (@UserId, @Total, @Date, 'Tamamlandi')";
                    SqlCommand cmd = new SqlCommand(insertSale, con, tran);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Total", cart.Sum(x => x.UnitPrice * x.Quantity));
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    int saleId = (int)cmd.ExecuteScalar();

                    foreach (var item in cart)
                    {
                        string insertItem = "INSERT INTO Sales_Items (SaleId, ProductId, Quantity, PriceAtSale) VALUES (@SaleId, @ProductId, @Qty, @Price)";
                        SqlCommand itemCmd = new SqlCommand(insertItem, con, tran);
                        itemCmd.Parameters.AddWithValue("@SaleId", saleId);
                        itemCmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                        itemCmd.Parameters.AddWithValue("@Qty", item.Quantity);
                        itemCmd.Parameters.AddWithValue("@Price", item.UnitPrice);
                        itemCmd.ExecuteNonQuery();

                        string updateStock = "UPDATE Products SET StockQuantity = StockQuantity - @Qty WHERE Id = @ProductId";
                        SqlCommand updateCmd = new SqlCommand(updateStock, con, tran);
                        updateCmd.Parameters.AddWithValue("@Qty", item.Quantity);
                        updateCmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                        updateCmd.ExecuteNonQuery();
                    }

                    ExportExcel();
                    tran.Commit();
                    MessageBox.Show("Satış başarıyla tamamlandı.");
                    CheckCriticalStock();


                    cart.Clear();
                    LoadCart();
                }
                catch
                {
                    tran.Rollback();
                    MessageBox.Show("Satış sırasında hata oluştu.");
                }
            }
        }
        private void ExportExcel()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "Fatura Olarak Kaydet";
                sfd.FileName = "Fatura.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (var pck = new ExcelPackage())
                    {
                        var ws = pck.Workbook.Worksheets.Add("Fatura");

                        ws.Cells[1, 1].Value = "Ürün";
                        ws.Cells[1, 2].Value = "Fiyat";
                        ws.Cells[1, 3].Value = "Adet";
                        ws.Cells[1, 4].Value = "Tutar";

                        for (int i = 0; i < cart.Count; i++)
                        {
                            ws.Cells[i + 2, 1].Value = cart[i].ProductName;
                            ws.Cells[i + 2, 2].Value = cart[i].UnitPrice;
                            ws.Cells[i + 2, 3].Value = cart[i].Quantity;
                            ws.Cells[i + 2, 4].Value = cart[i].UnitPrice * cart[i].Quantity;
                        }

                        ws.Cells.AutoFitColumns();
                        File.WriteAllBytes(sfd.FileName, pck.GetAsByteArray());
                        MessageBox.Show("Excel fatura dosyası kaydedildi.");
                    }
                }
            }
        }
        private void UpdateGrandTotal()
        {
            decimal total = cart.Sum(x => x.UnitPrice * x.Quantity);
            lblGrandTotal.Text = $"Toplam: {total:C2}";
        }
        private void GridCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && gridCart.Columns[e.ColumnIndex].Name == "Quantity")
            {
                string productName = gridCart.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                var item = cart.FirstOrDefault(c => c.ProductName == productName);

                if (item != null)
                {
                    if (int.TryParse(gridCart.Rows[e.RowIndex].Cells["Quantity"].Value?.ToString(), out int newQty))
                    {
                        item.Quantity = newQty;
                        gridCart.Rows[e.RowIndex].Cells["Total"].Value = (item.UnitPrice * item.Quantity).ToString("C2");
                        UpdateGrandTotal();
                    }
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            cart.Clear();
            this.Close();
        }

        private void CheckCriticalStock()
        {
            List<string> lowStockMessages = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string stockQuery = "SELECT Name, StockQuantity FROM Products WHERE StockQuantity <10";

                SqlCommand stockCmd = new SqlCommand(stockQuery, con);
                SqlDataReader stockReader = stockCmd.ExecuteReader();

                while (stockReader.Read())
                {
                    string name = stockReader["Name"].ToString();
                    int qty = Convert.ToInt32(stockReader["StockQuantity"]);
                    lowStockMessages.Add($"• {name} (Kalan: {qty})");
                }
                stockReader.Close();

                if (lowStockMessages.Count == 0) return;

                string subject = "Kritik Stok Uyarısı";
                string body = "Aşağıdaki ürünlerin stoğu kritik seviyeye düşmüştür:\n\n" +
                              string.Join("\n", lowStockMessages);

                /*
                foreach (string email in emails)
                {
                    EmailHelper.Send(email, subject, body);
                }
                */

                EmailHelper.Send("barisyusufulak@gmail.com",subject,body);
            }
        }
    }
}
