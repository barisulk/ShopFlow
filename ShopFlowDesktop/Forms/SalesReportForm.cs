using OfficeOpenXml;
using System.IO;
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
    public partial class SalesReportForm : Form
    {
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=ShopFlowDB;Integrated Security=True;TrustServerCertificate=True";

        public SalesReportForm()
        {
            InitializeComponent();
        }

        private void LoadUsers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id,Name FROM Users";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                dt.Rows.InsertAt(dt.NewRow(), 0);
                dt.Rows[0]["Id"] = DBNull.Value;
                dt.Rows[0]["Name"] = "Tümü";

             
            }
        }

        private void LoadSales(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                S.Id,
                U.Name AS UserName,
                S.TotalAmount,
                S.Date,
                S.Status
            FROM Sales S
            INNER JOIN Users U ON S.UserId = U.Id
            WHERE S.Date BETWEEN @StartDate AND @EndDate
            ORDER BY S.Date DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StartDate", startDate.Date);
                cmd.Parameters.AddWithValue("@EndDate", endDate.Date.AddDays(1).AddSeconds(-1));

               

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                salesGrid.DataSource = dt;

                // Ciro ve satış sayısı hesapla
                decimal totalRevenue = 0;
                int totalSalesCount = dt.Rows.Count;

                foreach (DataRow row in dt.Rows)
                {
                    totalRevenue += Convert.ToDecimal(row["TotalAmount"]);
                }

                lblTotalSales.Text = $"{totalSalesCount}";
                lblTotalRevenue.Text = $"₺{totalRevenue:N2}";
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime start = dtStart.Value;
            DateTime end = dtEnd.Value;
            LoadSales(start, end);
            LoadSaleDetails(start, end);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtStart.Value = DateTime.Today.AddDays(-30);
            dtEnd.Value = DateTime.Today;

            // ⬇️ Grid'leri sıfırla
            salesGrid.DataSource = null;
            salesDetailsGrid.DataSource = null;

            // ⬇️ Sayısal etiketleri sıfırla
            lblTotalSales.Text = "0";
            lblTotalRevenue.Text = "₺0.00";
            lblTotalQuantity.Text = "0";

            // ⬇️ Yeniden veri yükle (istersen)
            // LoadSales(dtStart.Value, dtEnd.Value);
            // LoadSaleDetails(dtStart.Value, dtEnd.Value);
        }


        private void SalesReportForm_Load(object sender, EventArgs e)
        {
            dtStart.Value = DateTime.Today.AddDays(-30);
            dtEnd.Value = DateTime.Today;
            LoadSales(dtStart.Value, dtEnd.Value);
            LoadSaleDetails(dtStart.Value, dtEnd.Value);
            LoadUsers();
        }

        private void LoadSaleDetails(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                S.Date,
                P.Name AS ProductName,
                I.Quantity,
                I.PriceAtSale,
                (I.Quantity * I.PriceAtSale) AS Total
            FROM Sales S
            INNER JOIN Sales_Items I ON S.Id = I.SaleId
            INNER JOIN Products P ON I.ProductId = P.Id
            WHERE S.Date BETWEEN @StartDate AND @EndDate
            ORDER BY S.Date DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StartDate", startDate.Date);
                cmd.Parameters.AddWithValue("@EndDate", endDate.Date.AddDays(1).AddSeconds(-1));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                salesDetailsGrid.DataSource = dt;

                // Toplam adet hesapla
                int totalQuantity = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalQuantity += Convert.ToInt32(row["Quantity"]);
                }

                lblTotalQuantity.Text = totalQuantity.ToString();
            }
        }
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "Satış Verilerini Dışa Aktar";
                sfd.FileName = $"SatisRaporu_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";


                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (var pck = new ExcelPackage())
                    {
                        var ws = pck.Workbook.Worksheets.Add("Satış Raporu");

                        // Başlıklar
                        for (int i = 0; i < salesGrid.Columns.Count; i++)
                        {
                            ws.Cells[1, i + 1].Value = salesGrid.Columns[i].HeaderText;
                            ws.Cells[1, i + 1].Style.Font.Bold = true;
                        }

                        // Satırlar
                        for (int i = 0; i < salesGrid.Rows.Count; i++)
                        {
                            for (int j = 0; j < salesGrid.Columns.Count; j++)
                            {
                                ws.Cells[i + 2, j + 1].Value = salesGrid.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        // Otomatik sütun genişliği
                        ws.Cells.AutoFitColumns();

                        // Kaydet
                        File.WriteAllBytes(sfd.FileName, pck.GetAsByteArray());
                        MessageBox.Show("Excel dosyası başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
