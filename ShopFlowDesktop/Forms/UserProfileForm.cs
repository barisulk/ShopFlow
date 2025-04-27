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
    public partial class UserProfileForm : Form
    {
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=ShopFlowDB;Integrated Security=True;TrustServerCertificate=True";
        private int currentUserId;
        private string currentPassword;
        public UserProfileForm(int UserId)
        {
            InitializeComponent();
            currentUserId = UserId;
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Name,Email,Role,Password FROM Users WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) 
                {
                    txtName.Text = reader["Name"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtRole.Text = reader["Role"].ToString();
                }
            }
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text != currentPassword) { MessageBox.Show("Eski şifre yanlış!"); }
            if (txtOldPassword == null && txtNewPassword == null && txtConfirmPassword == null) { MessageBox.Show("Lütfen alanları eksiksiz doldurunuz"); }
            if (txtOldPassword == txtNewPassword) { MessageBox.Show("Yeni şifreniz eski şifrenizle aynı olamaz"); }
            if (txtNewPassword.Text.Length < 6 ) { MessageBox.Show("Şifreniz 6 karakterden fazla olmalı");}
            if (!txtNewPassword.Text.Any(char.IsLetter)) { MessageBox.Show("Şifrenizde en az 1 tane harf bulunmalı"); }

            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                string query = "UPDATE Users SET Password = @Password WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@Password", txtNewPassword.Text);
                cmd.Parameters.AddWithValue("@Id", currentUserId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Şifreniz başarıyla güncellendi. Lütfen tekrar giriş yapınız.", "Şifre Değiştirildi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.Exit();

        }


    }
}
