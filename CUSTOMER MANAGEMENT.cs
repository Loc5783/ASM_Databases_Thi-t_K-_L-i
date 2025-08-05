using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;



namespace ASM_Databases_Thiết_Kế_Lại
{
    public partial class CUSTOMER_MANAGEMENT : Form
    {
        string connectionString = @"Server=LAPTOP-MTJRU40T;Database=StoreX_DB;Trusted_Connection=True;";

        public CUSTOMER_MANAGEMENT()
        {
            InitializeComponent();
        }
        private void ClearCustomerFields()
        {
            txtCustomerID.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            cboGender.SelectedIndex = 0; // Chọn lại "Nam"
        }

        private void CUSTOMER_MANAGEMENT_Load(object sender, EventArgs e)
        {
            cboGender.Items.Clear();
            cboGender.Items.Add("Nam");
            cboGender.Items.Add("Nữ");
            cboGender.Items.Add("Khác");
            cboGender.SelectedIndex = 0; // Chọn "Nam" làm mặc định
            cboSearchBy.Items.AddRange(new string[] { "CustomerName", "Email", "PhoneNumber", "Gender" });
            cboSearchBy.SelectedIndex = 0; // chọn mặc định khi form mở
            LoadCustomerData();
        }
        private void LoadCustomerData()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-MTJRU40T;Database=StoreX_DB;Trusted_Connection=True;"))
            {
                string query = "SELECT * FROM Customers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvCustomers.DataSource = table;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGender = cboGender.SelectedItem.ToString();
            if (cboGender.SelectedIndex == -1)
            {
                MessageBox.Show(" Please select a gender!");
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtCustomerID.Text = row.Cells["CustomerID"].Value.ToString();
                txtName.Text = row.Cells["CustomerName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["PhoneNumber"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                cboGender.Text = row.Cells["Gender"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (CustomerName, Email, PhoneNumber, Address, Gender) VALUES (@Name, @Email, @Phone, @Address, @Gender)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Gender", cboGender.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer added successfully");
                LoadCustomerData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Customers SET CustomerName=@Name, Email=@Email, PhoneNumber=@Phone, Address=@Address, Gender=@Gender WHERE CustomerID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", txtCustomerID.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Gender", cboGender.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update successful");
                LoadCustomerData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy CustomerID từ dòng đang chọn
            int customerID = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Server=LAPTOP-MTJRU40T;Database=StoreX_DB;Trusted_Connection=True;"))
                    {
                        conn.Open();
                        string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CustomerID", customerID);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show(" Customer deleted successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadCustomerData(); // Hàm load lại dữ liệu sau khi xóa
                            }
                            else
                            {
                                MessageBox.Show("The customer you want to delete was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string field = cboSearchBy.SelectedItem.ToString();
            string keyword = txtSearch.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM Customers WHERE {field} LIKE @keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvCustomers.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF file (*.pdf)|*.pdf";
            saveFile.Title = "Chọn nơi lưu file PDF";
            saveFile.FileName = "DanhSachKhachHang.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document document = new Document(PageSize.A4, 10, 10, 10, 10);
                    PdfWriter.GetInstance(document, new FileStream(saveFile.FileName, FileMode.Create));
                    document.Open();

                    // Tiêu đề
                    BaseFont bf = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font unicodeFont = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                    Paragraph title = new Paragraph("DANH SÁCH KHÁCH HÀNG", unicodeFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);
                    document.Add(new Paragraph(" ")); // dòng trắng

                    // Bảng dữ liệu
                    PdfPTable table = new PdfPTable(dgvCustomers.Columns.Count);
                    table.WidthPercentage = 100;

                    // Thêm header
                    foreach (DataGridViewColumn column in dgvCustomers.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                    }

                    // Thêm dữ liệu
                    foreach (DataGridViewRow row in dgvCustomers.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                table.AddCell(cell.Value?.ToString() ?? "");
                            }
                        }
                    }

                    document.Add(table);
                    document.Close();

                    MessageBox.Show("PDF exported successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while exporting the PDF:" + ex.Message);
                }
            }
        }

        private void lblview_Click(object sender, EventArgs e)
        {

        }

        private void cboSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý khi người dùng thay đổi lựa chọn, ví dụ:
            string selectedField = cboSearchBy.SelectedItem.ToString();
            // Có thể thêm logic tùy theo selectedField ở đây
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }
    }
}
