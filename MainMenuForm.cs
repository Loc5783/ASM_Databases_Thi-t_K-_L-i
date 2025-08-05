using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM_Databases_Thiết_Kế_Lại
{
    public partial class MainMenuForm : Form
    {

        private string userRole;
        private string username;
        public MainMenuForm(string role, string username)
        {
            InitializeComponent();
            this.userRole = role;
            this.username = username;
            this.role = role;
            this.Text = "Main Menu - " + role;
        }
        public MainMenuForm()
        {
            InitializeComponent();
        }
        private string role;
        public MainMenuForm(string role)
        {
            InitializeComponent();
            this.role = role;
            this.Text = "Main Menu - " + role; // Test xem form mở chưa
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {   
            // Ẩn tất cả trước
            btnViewProduct.Visible = false;
            btnOrderHistory.Visible = false;
            btnProfile.Visible = false;
            btnLogout.Visible = false;

            btnProduct.Visible = false;
            btnImport.Visible = false;
            btnSales.Visible = false;
            btnCustomer.Visible = false;

            btnEmployee.Visible = false;
            btnStatistics.Visible = false;

            // Dùng cho tất cả roles
            btnProfile.Visible = true;
            btnLogout.Visible = true;

            if (role == "Customer")
            {
                btnViewProduct.Visible = true;
                btnOrderHistory.Visible = true;
            }
            else if (role == "Staff")
            {
                btnViewProduct.Visible = true;
                btnOrderHistory.Visible = true;

                btnProduct.Visible = true;
                btnImport.Visible = true;
                btnSales.Visible = true;
                btnCustomer.Visible = true;
            }
            else if (role == "Admin")
            {
                // kế thừa quyền staff
                btnViewProduct.Visible = true;
                btnOrderHistory.Visible = true;

                btnProduct.Visible = true;
                btnImport.Visible = true;
                btnSales.Visible = true;
                btnCustomer.Visible = true;

                // thêm quyền admin
                btnEmployee.Visible = true;
                btnStatistics.Visible = true;
            }
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {
            ProductViewerForm productViewer = new ProductViewerForm(username); // truyền username
            productViewer.ShowDialog(); // Hiển thị form sản phẩm dạng modal
            this.Show(); // Quay lại menu khi form kia đóng
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            OrderHistoryForm orderForm = new OrderHistoryForm(username);  // cần truyền username
            this.Hide();
            orderForm.ShowDialog();
            this.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn MainMenuForm
            AccountProfileForm accountForm = new AccountProfileForm();
            accountForm.ShowDialog();
            this.Show(); // Hiện lại sau khi đóng form account
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            OrderManagementForm orderForm = new OrderManagementForm();
            this.Hide(); // Ẩn MainMenuForm
            orderForm.ShowDialog(); // Mở OrderManagementForm ở dạng modal
            this.Show(); // Khi đóng OrderManagementForm thì hiện lại MainMenuForm
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CUSTOMER_MANAGEMENT orderForm = new CUSTOMER_MANAGEMENT();
            this.Hide(); // Ẩn MainMenuForm
            orderForm.ShowDialog(); // Mở OrderManagementForm ở dạng modal
            this.Show(); // Khi đóng OrderManagementForm thì hiện lại MainMenuForm
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import_Goods orderForm = new Import_Goods();
            this.Hide(); // Ẩn MainMenuForm
            orderForm.ShowDialog(); // Mở OrderManagementForm ở dạng modal
            this.Show(); // Khi đóng OrderManagementForm thì hiện lại MainMenuForm
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Employee_Management orderForm = new Employee_Management();
            this.Hide(); // Ẩn MainMenuForm
            orderForm.ShowDialog(); // Mở OrderManagementForm ở dạng modal
            this.Show(); // Khi đóng OrderManagementForm thì hiện lại MainMenuForm
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Sales orderForm = new Sales();
            this.Hide(); // Ẩn MainMenuForm
            orderForm.ShowDialog(); // Mở OrderManagementForm ở dạng modal
            this.Show(); // Khi đóng OrderManagementForm thì hiện lại MainMenuForm
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            Statistics orderForm = new Statistics();
            this.Hide(); // Ẩn MainMenuForm
            orderForm.ShowDialog(); // Mở OrderManagementForm ở dạng modal
            this.Show(); // Khi đóng OrderManagementForm thì hiện lại MainMenuForm
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }
    }
}
