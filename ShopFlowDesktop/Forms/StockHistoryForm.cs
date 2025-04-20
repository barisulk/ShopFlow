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
    public partial class StockHistoryForm : Form
    {
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=ShopFlowDB;Integrated Security=True;TrustServerCertificate=True";

        public StockHistoryForm(string productName)
        {
            InitializeComponent();
            LoadHistory(productName);
        }

        private void LoadHistory(string productName)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    SC.Date,
                    SC.ChangeType,
                    SC.Quantity,
                    U.Name AS ChangedBy
                FROM Stock_Changes SC
                INNER JOIN Products P ON SC.ProductId = P.Id
                INNER JOIN Users U ON SC.UserId = U.Id
                WHERE P.Name = @ProductName
                ORDER BY SC.Date DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductName", productName);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                stockHistoryGrid.DataSource = dt;
            }
        }
    }
}
