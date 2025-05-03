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
using System.Xml.Linq;

namespace ShopFlowDesktop.Forms
{
    public partial class UserManagementForm : Form
    {
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=ShopFlowDB;Integrated Security=True;TrustServerCertificate=True";
        private int selectedUserId = -1;
        public UserManagementForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Email, Password, Role FROM Users";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                userGrid.DataSource = dt;
            }
        }

        private void userGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedUserId = Convert.ToInt32(userGrid.Rows[e.RowIndex].Cells["Id"].Value);
            textBoxName.Text = userGrid.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            textBoxMail.Text = userGrid.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            textBoxPassword.Text = userGrid.Rows[e.RowIndex].Cells["Password"].Value.ToString();
            comboBoxRole.Text = userGrid.Rows[e.RowIndex].Cells["Role"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBoxMail.Text == "" || textBoxPassword.Text == "" || comboBoxRole.Text == "" || textBoxName.Text == "")
            {
                MessageBox.Show("Lütfen gerekli alanları eksiksiz doldurunuz.");
                return;
            }

            using(SqlConnection con = new SqlConnection(connectionString)) 
            {
                string query = "INSERT INTO Users (Name, Email, Password, Role) VALUES (@Name, @Email, @Password, @Role)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                cmd.Parameters.AddWithValue("@Email", textBoxMail.Text);
                cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text); // ileride hash yapılmalı
                cmd.Parameters.AddWithValue("@Role", comboBoxRole.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı başarıyla eklendi.");
                ClearForm();
                LoadUsers();
            }

        }

        private void btnDelate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Lütfen silmek için bir kullanıcı seçin.");
                return;
            }

            DialogResult result = MessageBox.Show("Bu kullanıcıyı silmek istediğinizden emin misiniz?",
                                                  "Silme Onayı",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Users WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", selectedUserId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı silindi.");
                    ClearForm();
                    LoadUsers();
                }
            }
        }

        private void ClearForm()
        {
            textBoxName.Clear();
            textBoxMail.Clear();
            textBoxPassword.Clear();
            comboBoxRole.SelectedIndex = -1;
            selectedUserId = -1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Lütfen güncellemek için bir kullanıcı seçin.");
                return;
            }

            if (textBoxMail.Text == "" || comboBoxRole.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Lütfen güncelleme yapmak için gerekli alanları eksiksiz doldurunuz.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Name = @Name, Email = @Email, Role = @Role";

                if (!string.IsNullOrWhiteSpace(textBoxPassword.Text))
                {
                    query += ", Password = @Password";
                }

                query += " WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", selectedUserId);
                cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                cmd.Parameters.AddWithValue("@Email", textBoxMail.Text);
                cmd.Parameters.AddWithValue("@Role", comboBoxRole.Text);

                if (!string.IsNullOrWhiteSpace(textBoxPassword.Text))
                {
                    cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                }

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi.");
                ClearForm();
                LoadUsers();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
