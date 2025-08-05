using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace ASM_Databases_Thiết_Kế_Lại
{
    public partial class AccountProfileForm : Form
    {
        // Kết nối CSDL – chỉnh sửa lại 1 nơi duy nhất
        string connectionString = "Data Source=LAPTOP-MTJRU40T;Initial Catalog=StoreX_DB;Integrated Security=True";

        private void SetEditable(bool editable)
        {
            txtFullName.ReadOnly = !editable;
            txtEmail.ReadOnly = !editable;
            txtPhone.ReadOnly = !editable;
            txtAddress.ReadOnly = !editable;
            txtPassword.ReadOnly = !editable;
        }

        public AccountProfileForm()
        {
            InitializeComponent();
        }
        private void AccountProfileForm_Load(object sender, EventArgs e)
        {

        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEditable(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Full Name, Email, and Password cannot be left blank!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);

                string query = "INSERT INTO dbo.AccountProfiles (FullName, Email, PhoneNumber, Address, Password) " +
                               "VALUES (@FullName, @Email, @PhoneNumber, @Address, @Password)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = txtFullName.Text;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
                    command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = txtPhone.Text;
                    command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtAddress.Text;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = hashedPassword;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Profile saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetEditable(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại → quay lại form gọi trước (MainMenuForm)
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
