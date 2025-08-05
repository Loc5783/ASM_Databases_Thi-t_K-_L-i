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

namespace ASM_Databases_Thiết_Kế_Lại
{
    public partial class Employee_Management : Form
    {
        DataTable employeeTable = new DataTable();
        string connectionString = @"Server=LAPTOP-MTJRU40T;Database=StoreX_DB;Trusted_Connection=True;";
        public Employee_Management()
        {
            InitializeComponent();
            LoadEmployeeData();

        }
        private void LoadEmployeeData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees WHERE FullName LIKE @Search";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Search", "%" + txtSearch.Text + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void Employee_Management_Load(object sender, EventArgs e)
        {
            
        }
        private void ClearFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            comboBoxPosition.SelectedIndex = -1;
            dtpDOB.Value = DateTime.Now;
            comboBoxGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtAddress.Clear();
            txtSearch.Clear();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells["EmployeeID"].Value.ToString();
                txtName.Text = row.Cells["FullName"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                comboBoxPosition.Text = row.Cells["Position"].Value.ToString();
                dtpDOB.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
                comboBoxGender.Text = row.Cells["Gender"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Employees (FullName, Phone, Position, DateOfBirth, Gender, Email, Address)
                         VALUES (@FullName, @Phone, @Position, @DateOfBirth, @Gender, @Email, @Address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Position", comboBoxPosition.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", dtpDOB.Value);
                cmd.Parameters.AddWithValue("@Gender", comboBoxGender.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Employee added successfully!");
                LoadEmployeeData();
                ClearFields();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                    int employeeID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["EmployeeID"].Value);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee deleted successfully!");
                            LoadEmployeeData();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("The employee you want to delete was not found.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(" Please select an employee to delete.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Employees SET FullName=@FullName, Phone=@Phone, Position=@Position,
                         DateOfBirth=@DateOfBirth, Gender=@Gender, Email=@Email, Address=@Address
                         WHERE EmployeeID=@EmployeeID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", txtID.Text);
                cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Position", comboBoxPosition.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", dtpDOB.Value);
                cmd.Parameters.AddWithValue("@Gender", comboBoxGender.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Employee information updated successfully!");
                LoadEmployeeData();
                ClearFields();
            }
        }

        private void grpEmployeeInfo_Enter(object sender, EventArgs e)
        {

        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }
    }
}
