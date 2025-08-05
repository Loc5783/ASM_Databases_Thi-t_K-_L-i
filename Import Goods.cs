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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ASM_Databases_Thiết_Kế_Lại
{
    public partial class Import_Goods : Form
    {
        string connectionString = @"Server=LAPTOP-MTJRU40T;Database=StoreX_DB;Trusted_Connection=True;";

        public Import_Goods()
        {
            InitializeComponent();
            LoadEmployees();
            LoadProducts();
        }
        private void LoadEmployees()
        {
            cboEmployee.Items.AddRange(new string[]
            {
                "Nguyễn Thị Lan",
                "Trần Minh Hoàng",
                "Lê Văn Đức"
            });
        }

        private void LoadProducts()
        {
            cboProduct.Items.AddRange(new string[]
            {
                "Laptop Dell XPS 13",
                "iPhone 15 Pro",
                "Tai nghe AirPods Pro",
                "Chuột Logitech MX Master 3",
                "Màn hình Samsung 27''",
                "Bàn phím cơ Razer BlackWidow"
            });
        }

        private void Import_Goods_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
        }
        private string GenerateNewImportID()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(MAX(CAST(ImportID AS INT)), 0) + 1 FROM ImportGoods";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result.ToString();
                }
                catch
                {
                    return "1";
                }
            }
        }
        private void LoadDataFromDatabase()
        {
            dgvImportList.Rows.Clear();
            dgvImportList.Columns.Clear();

            dgvImportList.Columns.Add("ImportID", "Import code");
            dgvImportList.Columns.Add("EmployeeName", "Employee");
            dgvImportList.Columns.Add("ImportDate", "Import Date");
            dgvImportList.Columns.Add("ProductName", "Product");
            dgvImportList.Columns.Add("Quantity", "Quantity");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ImportGoods";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvImportList.Rows.Add(
                            reader["ImportID"].ToString(),
                            reader["EmployeeName"].ToString(),
                            Convert.ToDateTime(reader["ImportDate"]).ToString("dd/MM/yyyy"),
                            reader["ProductName"].ToString(),
                            reader["Quantity"].ToString()
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string employee = cboEmployee.Text;
            string product = cboProduct.Text;
            int quantity = (int)nudQuantity.Value;
            DateTime importDate = dtpImportDate.Value;

            if (string.IsNullOrEmpty(employee) || string.IsNullOrEmpty(product) || quantity <= 0)
            {
                MessageBox.Show(" Please enter all required information and ensure quantity is greater than 0.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO ImportGoods (EmployeeName, ImportDate, ProductName, Quantity) " +
                                     "VALUES (@EmployeeName, @ImportDate, @ProductName, @Quantity)";

                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@EmployeeName", employee);
                cmd.Parameters.AddWithValue("@ImportDate", importDate);
                cmd.Parameters.AddWithValue("@ProductName", product);
                cmd.Parameters.AddWithValue("@Quantity", quantity);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added successfully!");
                    LoadDataFromDatabase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding data:" + ex.Message);
                }
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvImportList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to delete");
                return;
            }

            string importID = dgvImportList.SelectedRows[0].Cells["ImportID"].Value.ToString();

            DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM ImportGoods WHERE ImportID = @ImportID";
                SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@ImportID", importID);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Deleted successfully!");
                        LoadDataFromDatabase();
                    }
                    else
                    {
                        MessageBox.Show("No row found to delete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboEmployee.SelectedIndex = -1;
            cboProduct.SelectedIndex = -1;
            nudQuantity.Value = 1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvImportList.Rows.Count == 0)
            {
                MessageBox.Show("No data to export!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF file (*.pdf)|*.pdf";
            saveFileDialog.FileName = "ImportGoods_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 20f, 10f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    pdfDoc.Open();

                    // Tiêu đề
                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    Paragraph title = new Paragraph("Goods Receipt List", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20f
                    };
                    pdfDoc.Add(title);

                    // Bảng dữ liệu
                    PdfPTable pdfTable = new PdfPTable(dgvImportList.Columns.Count);
                    pdfTable.WidthPercentage = 100;

                    // Thêm tiêu đề cột
                    foreach (DataGridViewColumn column in dgvImportList.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText))
                        {
                            BackgroundColor = BaseColor.LIGHT_GRAY
                        };
                        pdfTable.AddCell(cell);
                    }

                    // Thêm dữ liệu từng dòng
                    foreach (DataGridViewRow row in dgvImportList.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                pdfTable.AddCell(cell.Value?.ToString() ?? "");
                            }
                        }
                    }

                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();

                    MessageBox.Show("PDF file exported successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while exporting PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvImportList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtImportID_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpImportDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
