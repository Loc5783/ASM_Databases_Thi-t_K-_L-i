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

namespace ASM_Databases_Thiết_Kế_Lại
{
    public partial class OrderHistoryForm : Form
    {
        private List<Order> orders = new List<Order>();
        public OrderHistoryForm()
        {
            InitializeComponent();
        }
        private string username;
        public OrderHistoryForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }


        public class Order
        {
            public int OrderID { get; set; }
            public string ProductID { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public DateTime OrderDate { get; set; }
            public string CustomerName { get; set; }
        }
        string connectionString = "Data Source=LAPTOP-MTJRU40T;Initial Catalog=StoreX_DB;Integrated Security=True";
        private void LoadOrders()
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Orders WHERE CustomerName = @username ORDER BY OrderDate DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", this.username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                OrderID = Convert.ToInt32(reader["OrderID"]),
                                ProductID = reader["ProductID"].ToString(),
                                ProductName = reader["ProductName"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                                CustomerName = reader["CustomerName"].ToString()
                            });
                        }
                    }
                }
            }

            // Cập nhật list toàn cục và DataGridView
            this.orders = orders;
            dgvOrders.DataSource = null;
            dgvOrders.DataSource = this.orders;
        }

        private void OrderHistoryForm_Load(object sender, EventArgs e)
        {
            LoadOrders(); // ← phải gọi để load dữ liệu từ DB   
            rtbOrderDetail.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string keyword = txtSearchOrderID.Text.Trim().ToLower();
            if (int.TryParse(keyword, out int id))
            {
                var filtered = orders.Where(o => o.OrderID == id).ToList();
                dgvOrders.DataSource = null;
                dgvOrders.DataSource = filtered;

                if (filtered.Count == 0)
                    MessageBox.Show("No orders found!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter a valid integer for the order ID!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedOrder = dgvOrders.SelectedRows[0].DataBoundItem as Order;

            // Hiển thị chi tiết
            rtbOrderDetail.Visible = true;

            rtbOrderDetail.Text =
                $"📦 Order ID: {selectedOrder.OrderID}\n" +
                $"🗓️ Order Date: {selectedOrder.OrderDate.ToShortDateString()}\n";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Quay lại MainMenu
        }

        private void txtSearchOrderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbOrderDetail_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
