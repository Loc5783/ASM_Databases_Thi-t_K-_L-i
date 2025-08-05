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
using System.Windows.Forms.DataVisualization.Charting;


namespace ASM_Databases_Thiết_Kế_Lại
{
    public partial class Sales : Form
    {
        string connectionString = @"Server=LAPTOP-MTJRU40T;Database=StoreX_DB;Trusted_Connection=True;";
        private DataTable salesData = new DataTable();
        public Sales()
        {
            InitializeComponent();
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
            LoadSalesData(dtpFrom.Value, dtpTo.Value);
        }
        private void LoadSalesData(DateTime fromDate, DateTime toDate)
        {
            this.panelChart.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChart_Paint);
            string connectionString = "Server=LAPTOP-MTJRU40T;Database=StoreX_DB;Trusted_Connection=True;"; // ← Điền chuỗi kết nối thật
            string query = @"
                SELECT 
                    ProductName, 
                    QuantitySold, 
                    SaleDate, 
                    Revenue 
                FROM 
                    SalesData
                WHERE 
                    SaleDate BETWEEN @FromDate AND @ToDate
                ORDER BY 
                    SaleDate DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                salesData.Clear();
                adapter.Fill(salesData);
                dgvTopProducts.DataSource = salesData;

                // Đặt lại header
                dgvTopProducts.Columns["ProductName"].HeaderText = "Sản phẩm";
                dgvTopProducts.Columns["QuantitySold"].HeaderText = "Số lượng";
                dgvTopProducts.Columns["SaleDate"].HeaderText = "Ngày bán";
                dgvTopProducts.Columns["Revenue"].HeaderText = "Doanh thu";
                dgvTopProducts.Columns["Revenue"].DefaultCellStyle.Format = "c0";
            }

            panelChart.Invalidate(); // Vẽ lại biểu đồ sau khi load
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Sales_Load(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;

            if (from > to)
            {
                MessageBox.Show("Start date must be less than or equal to end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadSalesData(from, to);
            LoadTopProducts(from, to);  // ← chỉ gọi khi ngày hợp lệ    
        }
        private void LoadTopProducts(DateTime fromDate, DateTime toDate)
        {
            string connectionString = @"Server=LAPTOP-MTJRU40T;Database=StoreX_DB;Trusted_Connection=True;";

                    string query = @"
                SELECT TOP 5 
                    ProductName,
                    SUM(QuantitySold) AS TotalSold,
                    SUM(Revenue) AS TotalRevenue
                FROM SalesData
                WHERE SaleDate BETWEEN @FromDate AND @ToDate
                GROUP BY ProductName
                ORDER BY TotalSold DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Nếu bạn có DataGridView riêng cho top sản phẩm thì gán vào đó,
                // không nên dùng lại dgvSalesData
                dgvTopProducts.DataSource = dt; // Giả sử bạn có thêm dgvTopProducts

                dgvTopProducts.Columns["ProductName"].HeaderText = "Product";
                dgvTopProducts.Columns["TotalSold"].HeaderText = "Sold";
                dgvTopProducts.Columns["TotalRevenue"].HeaderText = "Revenue";
                dgvTopProducts.Columns["TotalRevenue"].DefaultCellStyle.Format = "c0";
            }
        }
        private void panelChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(panelChart.BackColor);

            if (dgvTopProducts.DataSource == null || dgvTopProducts.Rows.Count == 0) return;

            var top5 = new List<(string Name, int Quantity)>();

            foreach (DataGridViewRow row in dgvTopProducts.Rows)
            {
                if (row.IsNewRow) continue;

                string name = row.Cells["ProductName"].Value.ToString();
                int total = Convert.ToInt32(row.Cells["QuantitySold"].Value);
                top5.Add((name, total));
            }

            if (top5.Count == 0) return;

            int chartWidth = panelChart.Width - 60;
            int chartHeight = panelChart.Height - 40;

            int barWidth = chartWidth / top5.Count - 20;
            int maxQuantity = top5.Max(p => p.Quantity);

            for (int i = 0; i < top5.Count; i++)
            {
                var p = top5[i];
                int barHeight = (int)((double)p.Quantity / maxQuantity * (chartHeight - 50));
                int x = 40 + i * (barWidth + 20);
                int y = chartHeight - barHeight + 20;

                g.FillRectangle(Brushes.SteelBlue, x, y, barWidth, barHeight);
                g.DrawString(p.Name, new Font("Arial", 9), Brushes.Black, x, chartHeight + 5);
                g.DrawString(p.Quantity.ToString(), new Font("Arial", 9, FontStyle.Bold), Brushes.Black, x, y - 15);
            }

            g.DrawString("Top 5 sản phẩm bán chạy", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 10, 5);
        }

        private void lblview_Click(object sender, EventArgs e)
        {

        }

        private void chartSales_Click(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }
    }
    
}
