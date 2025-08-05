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

namespace ASM_Databases_Thiết_Kế_Lại
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private string selectedRole = "";
        string connectionString = "Data Source=LAPTOP-MTJRU40T;Initial Catalog=StoreX_DB;Integrated Security=True";

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError.Text = "";
            lblError.Text = "Your account or password is incorrect. Please log in again !";
            lblError.Visible = true;
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister registerForm = new FormRegister();
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            lblError.Visible = false;
            lblError.Text = "";

        } 

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter all required information!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Role FROM Users WHERE Username = @username AND Password = @password";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString();
                        MessageBox.Show($"Successfully logged in as: {role}");

                        // Không khai báo lại mà gán lại
                        username = txtUsername.Text.Trim();

                        MainMenuForm mainMenu = new MainMenuForm(role, username);
                        this.Hide();
                        mainMenu.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        lblError.Text = "Your account or password is incorrect. Please log in again!";
                        lblError.Visible = true;
                        MessageBox.Show("Wrong username or password !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection error: " + ex.Message);
                }
            }

        }
    }
}
