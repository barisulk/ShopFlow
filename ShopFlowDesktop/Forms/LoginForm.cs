using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopFlowDesktop.Forms
{
    public partial class LoginForm : Form
    {

        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=ShopFlowDB;Integrated Security=True;TrustServerCertificate=True";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string email = eposta_input.Text.Trim();
            string password = sifre_input.Text.Trim();

            if (string.IsNullOrEmpty(email)) { MessageBox.Show("Lütfen e-postanızı giriniz"); return;}
            if (string.IsNullOrEmpty(password)) { MessageBox.Show("Lütfen e-postanızı giriniz");return;}

            using(SqlConnection con = new SqlConnection(connectionString)) 
            {
                try
                {
                    con.Open();
                    string query = "SELECT Role FROM Users WHERE Email  = @Email  AND Password  = @Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string role = result.ToString();

                        this.Hide();
                        switch (role)
                        {
                            case "Yönetici":
                                new AdminForm("Admin Kullanıcı",1).Show();
                                break;
                            case "Satış":
                                new SalesForm(1).Show();
                                break;
                            case "Stok":
                                new StockForm("Admin Kullanıcı", 1).Show();
                                break;
                            default:
                                MessageBox.Show("Yetki tanımı bulunamadı.");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz e-posta veya şifre.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }
    }
}
