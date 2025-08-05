using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;


namespace ASM_Databases_Thiết_Kế_Lại
{
    public partial class FormRegister : Form
    {
        List<string> existingUsernames = new List<string> { "admin", "staff", "customer" };

        public FormRegister()
        {
            InitializeComponent();
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();

                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2")); // chuyển từng byte thành hex
                }

                return builder.ToString();
            }
        }
        string connectionString = "Data Source=LAPTOP-MTJRU40T;Initial Catalog=StoreX_DB;Integrated Security=True";
        private void FormRegister_Load(object sender, EventArgs e)
        {

        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-MTJRU40T;Initial Catalog=StoreX_DB;Integrated Security=True";
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string hashedPassword = HashPassword(password); // Mã hóa SHA256
            string fullName = txtFullName.Text.Trim();
            string role = "Customer"; // Vì bạn muốn chỉ đăng ký tài khoản khách hàng

            // Kiểm tra rỗng
            if (username == "" || password == "" || fullName == "")
            {
                MessageBox.Show("Please fill in all required information.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Kiểm tra trùng username
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Username", username);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists.");
                        return;
                    }
                }

                // 2. Thêm người dùng mới với vai trò là Customer
                string query = "INSERT INTO Users (Username, Password, FullName, Role) " +
                               "VALUES (@Username, @Password, @FullName, @Role)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Role", role);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Registration successful!");
                        this.Close(); // hoặc chuyển về Form Login
                    }
                    else
                    {
                        MessageBox.Show("Registration failed");
                    }
                }
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        
    }
}
