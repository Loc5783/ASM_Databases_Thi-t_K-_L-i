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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ASM_Databases_Thiết_Kế_Lại
{

    public partial class Statistics : Form
    {
        private List<(DateTime Date, int Count)> orderCounts;
        private List<(DateTime Date, decimal Revenue)> revenues;


        string connectionString = @"Server=LAPTOP-MTJRU40T;Database=StoreX_DB;Trusted_Connection=True;";
        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            // Gán giá trị mặc định cho DateTimePicker (7 ngày gần nhất)
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today;

            // Gọi luôn khi mở form
            LoadStatistics(dtpFrom.Value.Date, dtpTo.Value.Date);

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;

            if (fromDate > toDate)
            {
                MessageBox.Show("The start date cannot be greater than the end date");
                return;
            }

            LoadStatistics(fromDate, toDate);
        }



        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF File|*.pdf",
                Title = "Export statistics to PDF"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToPDF(sfd.FileName);
            }
        }

        private void ExportToPDF(string path)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            doc.Add(new Paragraph("BÁO CÁO THỐNG KÊ ĐƠN HÀNG"));
            doc.Add(new Paragraph($"Từ ngày: {dtpFrom.Value.ToShortDateString()} - Đến ngày: {dtpTo.Value.ToShortDateString()}"));
            doc.Add(new Paragraph(lblTotalOrders.Text));
            doc.Add(new Paragraph(lblRevenue.Text));
            doc.Add(new Paragraph("\nBiểu đồ không thể chụp và đưa vào PDF trong phiên bản này."));

            doc.Close();
            MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void lblTotalOrders1_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalOrders_Click(object sender, EventArgs e)
        {

        }

        private void lblRevenue_Click(object sender, EventArgs e)
        {

        }

        private void dgvTopProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadStatistics(DateTime fromDate, DateTime toDate)
        {
            orderCounts = new List<(DateTime, int)>();
            revenues = new List<(DateTime, decimal)>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string queryGroupOrders = @"
                SELECT OrderDate, COUNT(*) AS OrderCount
                FROM StatisticOrders
                WHERE OrderDate BETWEEN @FromDate AND @ToDate
                GROUP BY OrderDate
                ORDER BY OrderDate";

                string querySales = @"
                SELECT o.OrderDate, SUM(oi.Quantity * oi.Price) AS TotalRevenue
                FROM StatisticOrders o
                JOIN StatisticOrderItems oi ON o.OrderID = oi.OrderID
                WHERE o.OrderDate BETWEEN @FromDate AND @ToDate
                GROUP BY o.OrderDate
                ORDER BY o.OrderDate";

                SqlCommand cmdGroupOrders = new SqlCommand(queryGroupOrders, conn);
                cmdGroupOrders.Parameters.AddWithValue("@FromDate", fromDate);
                cmdGroupOrders.Parameters.AddWithValue("@ToDate", toDate);
                SqlDataReader reader = cmdGroupOrders.ExecuteReader();
                while (reader.Read())
                {
                    orderCounts.Add((Convert.ToDateTime(reader["OrderDate"]), Convert.ToInt32(reader["OrderCount"])));
                }
                reader.Close();

                SqlCommand cmdSales = new SqlCommand(querySales, conn);
                cmdSales.Parameters.AddWithValue("@FromDate", fromDate);
                cmdSales.Parameters.AddWithValue("@ToDate", toDate);
                SqlDataReader reader2 = cmdSales.ExecuteReader();
                while (reader2.Read())
                {
                    revenues.Add((Convert.ToDateTime(reader2["OrderDate"]), Convert.ToDecimal(reader2["TotalRevenue"])));
                }
                reader2.Close();

            }

            panelChart.Invalidate(); // Vẽ lại
            lblTotalOrders.Text = "Total Orders: " + orderCounts.Sum(x => x.Count).ToString();
            lblRevenue.Text = "Revenue: " + revenues.Sum(x => x.Revenue).ToString("C0");
            panelOrdersChart.Invalidate(); // gọi vẽ lại

            LoadTopProducts(fromDate, toDate); // <-- GỌI HÀM MỚI

            panelOrdersChart.Invalidate(); // gọi vẽ lại
        }
        private void LoadTopProducts(DateTime fromDate, DateTime toDate)
        {
            string connectionString = "Server=LAPTOP-MTJRU40T;Database=StoreX_DB;Trusted_Connection=True;"; // thay thế bằng chuỗi kết nối thực tế
            string query = @"
                    SELECT 
                        ProductName,
                        SUM(Quantity) AS TotalSold,
                        SUM(Quantity * Price) AS TotalRevenue
                    FROM 
                        StatisticOrderItems
                    GROUP BY 
                        ProductName
                    ORDER BY 
                        TotalSold DESC;
                ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvTopProducts.DataSource = dataTable;

                // Tùy chọn hiển thị DataGridView
                dgvTopProducts.Columns["ProductName"].HeaderText = "Sản phẩm";
                dgvTopProducts.Columns["TotalSold"].HeaderText = "Số lượng bán";
                dgvTopProducts.Columns["TotalRevenue"].HeaderText = "Tổng doanh thu (VNĐ)";
            }
        }
        private void panelSalesChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (orderCounts == null || orderCounts.Count == 0)
                return;

            int width = panelChart.Width;
            int height = panelChart.Height;

            int margin = 40;
            int chartWidth = width - 2 * margin;
            int chartHeight = height - 2 * margin;

            int maxOrder = orderCounts.Max(x => x.Count);
            decimal maxRevenue = revenues.Max(x => x.Revenue);

            int barWidth = Math.Max(20, chartWidth / orderCounts.Count / 2);
            int spacing = barWidth;

            for (int i = 0; i < orderCounts.Count; i++)
            {
                int x = margin + i * (barWidth + spacing);

                // --- Vẽ cột đơn hàng
                int barHeight = (int)(orderCounts[i].Count / (float)maxOrder * chartHeight);
                System.Drawing.Rectangle barRect = new System.Drawing.Rectangle(x, height - margin - barHeight, barWidth, barHeight);
                g.FillRectangle(Brushes.OrangeRed, barRect);
                g.DrawString(orderCounts[i].Date.ToString("dd/MM"), new System.Drawing.Font("Arial", 8)
                    , Brushes.Black, x, height - margin + 2);

                // --- Vẽ đường doanh thu
                if (i < revenues.Count)
                {
                    float revenueY = height - margin - (float)(revenues[i].Revenue / maxRevenue * chartHeight);
                    g.FillEllipse(Brushes.Blue, x + barWidth / 2 - 3, revenueY - 3, 6, 6);

                    if (i > 0)
                    {
                        float prevX = margin + (i - 1) * (barWidth + spacing) + barWidth / 2;
                        float prevY = height - margin - (float)(revenues[i - 1].Revenue / maxRevenue * chartHeight);
                        g.DrawLine(Pens.Blue, prevX, prevY, x + barWidth / 2, revenueY);
                    }
                }
            }

            // Vẽ trục
            g.DrawLine(Pens.Black, margin, margin, margin, height - margin);
            g.DrawLine(Pens.Black, margin, height - margin, width - margin, height - margin);
        }

        private void panelOrdersChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (orderCounts == null || orderCounts.Count == 0)
                return;

            int width = panelOrdersChart.Width;
            int height = panelOrdersChart.Height;

            int margin = 40;
            int chartWidth = width - 2 * margin;
            int chartHeight = height - 2 * margin;

            int maxCount = orderCounts.Max(x => x.Count);

            int barWidth = Math.Max(20, chartWidth / orderCounts.Count / 2);
            int spacing = barWidth;

            for (int i = 0; i < orderCounts.Count; i++)
            {
                int x = margin + i * (barWidth + spacing);
                int barHeight = (int)(orderCounts[i].Count / (float)maxCount * chartHeight);

                System.Drawing.Rectangle barRect = new System.Drawing.Rectangle(x, height - margin - barHeight, barWidth, barHeight);
                g.FillRectangle(Brushes.SeaGreen, barRect);
                g.DrawRectangle(Pens.Black, barRect);

                // Số lượng đơn
                g.DrawString(orderCounts[i].Count.ToString(), new System.Drawing.Font("Arial", 8)
                    , Brushes.Black, x, height - margin - barHeight - 15);

                // Ngày
                g.DrawString(orderCounts[i].Date.ToString("dd/MM"), new System.Drawing.Font("Arial", 8)
                    , Brushes.Black, x - 5, height - margin + 2);
            }

            // Trục
            g.DrawLine(Pens.Black, margin, margin, margin, height - margin);
            g.DrawLine(Pens.Black, margin, height - margin, width - margin, height - margin);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();
        }
    }
}

