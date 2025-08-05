using Microsoft.VisualBasic;
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
    public partial class OrderManagementForm : Form
    {
        string connectionString = "Data Source=LAPTOP-MTJRU40T;Initial Catalog=StoreX_DB;Integrated Security=True";
        public OrderManagementForm()
        {
            InitializeComponent();
        }

        private void OrderManagementForm_Load(object sender, EventArgs e)
        {
            cboFilterStatus.Items.AddRange(new string[] { "All", "Pending", "Shipped", "Cancelled" });
            cboFilterStatus.SelectedIndex = 0;
            LoadOrders();
        }
        private void LoadOrders(string status = "All")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = (status == "All")
                    ? "SELECT * FROM OrderList"
                    : "SELECT * FROM OrderList WHERE Status = @Status";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (status != "All")
                    cmd.Parameters.AddWithValue("@Status", status);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvOrders.DataSource = table;
            }
        }
        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = cboFilterStatus.SelectedItem.ToString();
            LoadOrders(selectedStatus);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to view details");
                return;
            }

            var row = dgvOrders.SelectedRows[0];
            string orderInfo = $"Order ID: {row.Cells["OrderID"].Value}\n" +
                               $"Custommer: {row.Cells["CustomerName"].Value}\n" +
                               $"Day: {Convert.ToDateTime(row.Cells["OrderDate"].Value).ToShortDateString()}\n" +
                               $"Status: {row.Cells["Status"].Value}";
            MessageBox.Show(orderInfo, "Order Details");
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
                return;

            var row = dgvOrders.SelectedRows[0];
            int orderId = Convert.ToInt32(row.Cells["OrderID"].Value);

            var confirm = MessageBox.Show($"Are you sure you want to delete this order? {orderId}?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM OrderList WHERE OrderID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.ExecuteNonQuery();
                }
                LoadOrders(cboFilterStatus.SelectedItem.ToString());
                MessageBox.Show("Order deleted successfully");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Quay lại MainMenuForm
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to update");
                return;
            }

            string newStatus = cboFilterStatus.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(newStatus) || newStatus == "All")
            {
                MessageBox.Show("Vui lòng chọn trạng thái cụ thể (không phải 'All').");
                return;
            }

            var row = dgvOrders.SelectedRows[0];
            int orderId = Convert.ToInt32(row.Cells["OrderID"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE OrderList SET Status = @status, OrderDate = @date WHERE OrderID = @id", conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@date", dtpOrderDate.Value.Date);
                cmd.Parameters.AddWithValue("@id", orderId);
                cmd.ExecuteNonQuery();
            }

            LoadOrders(cboFilterStatus.SelectedItem.ToString());
            MessageBox.Show("Status updated successfully");
        }

        private void dtpOrderDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtOrderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var row = dgvOrders.SelectedRows[0];
                if (DateTime.TryParse(row.Cells["OrderDate"].Value?.ToString(), out DateTime orderDate))
                {
                    dtpOrderDate.Value = orderDate;
                }
            }
        }
    }
}
