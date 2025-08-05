using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace ASM_Databases_Thiết_Kế_Lại
{
    public partial class ProductViewerForm : Form
    {
        string connectionString = "Data Source=LAPTOP-MTJRU40T;Initial Catalog=StoreX_DB;Integrated Security=True";
        private Dictionary<string, System.Drawing.Image> productImages = new Dictionary<string, System.Drawing.Image>
{
    { "P001", Properties.Resources.mouse },
    { "P002", Properties.Resources.keyboard },
    { "P003", Properties.Resources.monitor },
    { "P004", Properties.Resources.webcam },
    { "P005" , Properties.Resources.speaker},
    { "P006", Properties.Resources.USBHub },
    { "P007", Properties.Resources.LaptopStand },
    { "P008", Properties.Resources.ExternalHDD },
    { "P009", Properties.Resources.Microphone },
    { "P010", Properties.Resources.GraphicsTablet },
    { "P011", Properties.Resources.WirelessCharger },
    { "P012", Properties.Resources.Smartwatch },
    // 👉 Thêm các ảnh vào Resources trước
};

        private string loggedInUsername;

        private List<Product> allProducts = new List<Product>();

        public ProductViewerForm()
        {
            InitializeComponent();

        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            allProducts.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductID = reader["ProductID"].ToString(),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Quantity = Convert.ToInt32(reader["Quantity"])
                    };

                    allProducts.Add(product);
                }

                reader.Close();
            }

            dgvProducts.DataSource = null;
            dgvProducts.DataSource = allProducts;
        }
       
        
        private void dgvProducts_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        public class Product
        {
            public string ProductID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void LoadProductsFromDatabase()
        {
            allProducts.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductID = reader["ProductID"].ToString(),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Quantity = Convert.ToInt32(reader["Quantity"])
                    };

                    allProducts.Add(product);
                }

                reader.Close();
            }

            dgvProducts.DataSource = null;
            dgvProducts.DataSource = allProducts;
        }
        public ProductViewerForm(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
        }


        private void ProductViewerForm_Load(object sender, EventArgs e)
        {

            grpProductDetail.Visible = false;
            cboFilterBy.Items.AddRange(new string[] { "Product ID", "Name", "Min Price", "Max Price" });
            cboFilterBy.SelectedIndex = 0;
            LoadProductsFromDatabase();

            // 👉 Lấy thông tin người dùng
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT FullName FROM Users WHERE Username = @username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", loggedInUsername);

                    var fullName = cmd.ExecuteScalar()?.ToString();
                    
                }
            }
            grpProductDetail.Visible = false;
            cboFilterBy.Items.AddRange(new string[] { "Product ID", "Name", "Min Price", "Max Price" });
            cboFilterBy.SelectedIndex = 0;
            LoadProductsFromDatabase(); // 👉 Load từ CSDL thay vì dữ liệu giả
        }
        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string filter = cboFilterBy.SelectedItem?.ToString();
            var filtered = allProducts;

            switch (filter)
            {
                case "Product ID":
                    filtered = allProducts.Where(p => p.ProductID.ToLower().Contains(keyword)).ToList();
                    break;
                case "Name":
                    filtered = allProducts.Where(p => p.Name.ToLower().Contains(keyword)).ToList();
                    break;
                case "Min Price":
                    if (decimal.TryParse(keyword, out decimal minPrice))
                        filtered = allProducts.Where(p => p.Price >= minPrice).ToList();
                    break;
                case "Max Price":
                    if (decimal.TryParse(keyword, out decimal maxPrice))
                        filtered = allProducts.Where(p => p.Price <= maxPrice).ToList();
                    break;
            }

            dgvProducts.DataSource = null;
            dgvProducts.DataSource = filtered;

            if (filtered.Count == 0)
                MessageBox.Show("No matching products found!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại → quay lại form gọi trước (MainMenuForm)
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = allProducts;
        }
        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            ShowProductDetail();
        }
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            ShowProductDetail();
        }
        private void ShowProductDetail()
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var product = dgvProducts.SelectedRows[0].DataBoundItem as Product;

                if (product != null)
                {
                    // Hiện ảnh
                    if (productImages.ContainsKey(product.ProductID))
                        picProductImage.Image = productImages[product.ProductID];
                    else
                        picProductImage.Image = null;

                    // Hiện thông tin chi tiết
                    rtbProductDetail.Text = $"🧾 Product details: " +
                                            $"🔹 Item ID: {product.ProductID}\n" +
                                            $"🔹 Name: {product.Name}\n" +
                                            $"🔹 Price: {product.Price:N0} VND\n" +
                                            $"🔹 Warehouse: {product.Quantity}";
                }
            }
            else
            {
                picProductImage.Image = null;
                rtbProductDetail.Clear();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            grpProductDetail.Visible = false;           // Ẩn GroupBox
            picProductImage.Image = null;        // Xóa ảnh
            rtbProductDetail.Clear();            // Xóa nội dung chi tiết
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void picProductImage_Click(object sender, EventArgs e)
        {

            string keyword = txtSearch.Text.Trim().ToLower();
            string filter = cboFilterBy.SelectedItem?.ToString();
            var filtered = allProducts;

            switch (filter)
            {
                case "Product ID":
                    filtered = allProducts.Where(p => p.ProductID.ToLower().Contains(keyword)).ToList();
                    break;
                case "Name":
                    filtered = allProducts.Where(p => p.Name.ToLower().Contains(keyword)).ToList();
                    break;
                case "Min Price":
                    if (decimal.TryParse(keyword, out decimal minPrice))
                        filtered = allProducts.Where(p => p.Price >= minPrice).ToList();
                    break;
                case "Max Price":
                    if (decimal.TryParse(keyword, out decimal maxPrice))
                        filtered = allProducts.Where(p => p.Price <= maxPrice).ToList();
                    break;
            }
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = filtered;

            if (filtered.Count == 0)
            {
                MessageBox.Show("No matching products found!", "Infomation!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnViewDetail_Click_1(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var product = dgvProducts.SelectedRows[0].DataBoundItem as Product;

                if (product != null)
                {
                    grpProductDetail.Visible = true; // 👉 Hiện GroupBox khi có sản phẩm được chọn

                    // Hiện ảnh
                    if (productImages.ContainsKey(product.ProductID))
                        picProductImage.Image = productImages[product.ProductID];
                    else
                        picProductImage.Image = null;

                    // Hiện thông tin chi tiết
                    rtbProductDetail.Text = $"🧾 Product details:\n\n" +
                                            $"🔹 Item ID: {product.ProductID}\n" +
                                            $"🔹 name: {product.Name}\n" +
                                            $"🔹 Price: {product.Price:N0} VND\n" +
                                            $"🔹 Warehouse: {product.Quantity}";
                }
            }
            else
            {
                MessageBox.Show("Please select a product to view details!", "Infomation!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF files (*.pdf)|*.pdf";
            sfd.FileName = "Products.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();

                PdfPTable table = new PdfPTable(dgvProducts.Columns.Count);

                foreach (DataGridViewColumn column in dgvProducts.Columns)
                {
                    table.AddCell(new Phrase(column.HeaderText));
                }

                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (row.IsNewRow) continue;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        table.AddCell(cell.Value?.ToString() ?? "");
                    }
                }

                doc.Add(table);
                doc.Close();

                MessageBox.Show("PDF has been saved to:\n" + sfd.FileName, "succeeded");

                // Mở file sau khi lưu
                System.Diagnostics.Process.Start("explorer.exe", sfd.FileName);
            }
        }

        private void BuyProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var selectedProduct = dgvProducts.SelectedRows[0].DataBoundItem as Product;
                if (selectedProduct == null) return;

                // Giả sử mặc định mua 1 sản phẩm, bạn có thể mở dialog chọn số lượng
                int quantity = 1;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Orders (ProductID, ProductName, Quantity, OrderDate, CustomerName) " +
                                   "VALUES (@ProductID, @ProductName, @Quantity, @OrderDate, @CustomerName)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", selectedProduct.ProductID);
                        cmd.Parameters.AddWithValue("@ProductName", selectedProduct.Name);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@CustomerName", loggedInUsername); // ← thêm dòng này
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("🛒 Order successfully placed!", "Thành công");
            }
            else
            {
                MessageBox.Show("❌ Please select a product to purchase!");
            }
        }
    }
}
