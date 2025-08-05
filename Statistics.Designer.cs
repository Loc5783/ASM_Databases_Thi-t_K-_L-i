namespace ASM_Databases_Thiết_Kế_Lại
{
    partial class Statistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblview = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTotalOrders1 = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.panelChart = new System.Windows.Forms.Panel();
            this.panelOrdersChart = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblview
            // 
            this.lblview.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblview.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblview.Location = new System.Drawing.Point(-1, 0);
            this.lblview.Name = "lblview";
            this.lblview.Size = new System.Drawing.Size(1232, 137);
            this.lblview.TabIndex = 43;
            this.lblview.Text = "Welcome To Statistics From";
            this.lblview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.ErrorImage = global::ASM_Databases_Thiết_Kế_Lại.Properties.Resources._433FE050_2043_45B8_AABC_951FFAD06CF8_;
            this.pictureBox1.Image = global::ASM_Databases_Thiết_Kế_Lại.Properties.Resources._433FE050_2043_45B8_AABC_951FFAD06CF8_;
            this.pictureBox1.InitialImage = global::ASM_Databases_Thiết_Kế_Lại.Properties.Resources._433FE050_2043_45B8_AABC_951FFAD06CF8_;
            this.pictureBox1.Location = new System.Drawing.Point(6, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(279, 137);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(1087, 651);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(92, 36);
            this.btnexit.TabIndex = 57;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // dgvTopProducts
            // 
            this.dgvTopProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopProducts.Location = new System.Drawing.Point(6, 457);
            this.dgvTopProducts.Name = "dgvTopProducts";
            this.dgvTopProducts.RowHeadersWidth = 51;
            this.dgvTopProducts.RowTemplate.Height = 24;
            this.dgvTopProducts.Size = new System.Drawing.Size(1173, 188);
            this.dgvTopProducts.TabIndex = 56;
            this.dgvTopProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTopProducts_CellContentClick);
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(892, 169);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(119, 32);
            this.btnFilter.TabIndex = 55;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(614, 172);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 22);
            this.dtpTo.TabIndex = 54;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(184, 172);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 22);
            this.dtpFrom.TabIndex = 53;
            // 
            // lblTotalOrders1
            // 
            this.lblTotalOrders1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrders1.Location = new System.Drawing.Point(456, 153);
            this.lblTotalOrders1.Name = "lblTotalOrders1";
            this.lblTotalOrders1.Size = new System.Drawing.Size(152, 62);
            this.lblTotalOrders1.TabIndex = 52;
            this.lblTotalOrders1.Text = "Until the day:";
            this.lblTotalOrders1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalOrders1.Click += new System.EventHandler(this.lblTotalOrders1_Click);
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenue.Location = new System.Drawing.Point(26, 153);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(152, 62);
            this.lblTotalRevenue.TabIndex = 51;
            this.lblTotalRevenue.Text = "From date:";
            this.lblTotalRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(30, 651);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(92, 36);
            this.btnExport.TabIndex = 60;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrders.Location = new System.Drawing.Point(426, 260);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(333, 49);
            this.lblTotalOrders.TabIndex = 62;
            this.lblTotalOrders.Text = "Total Orders : ";
            this.lblTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalOrders.Click += new System.EventHandler(this.lblTotalOrders_Click);
            // 
            // lblRevenue
            // 
            this.lblRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenue.Location = new System.Drawing.Point(426, 374);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(333, 49);
            this.lblRevenue.TabIndex = 63;
            this.lblRevenue.Text = "Revenue :";
            this.lblRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRevenue.Click += new System.EventHandler(this.lblRevenue_Click);
            // 
            // panelChart
            // 
            this.panelChart.Location = new System.Drawing.Point(765, 218);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(377, 214);
            this.panelChart.TabIndex = 64;
            this.panelChart.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSalesChart_Paint);
            // 
            // panelOrdersChart
            // 
            this.panelOrdersChart.Location = new System.Drawing.Point(30, 227);
            this.panelOrdersChart.Name = "panelOrdersChart";
            this.panelOrdersChart.Size = new System.Drawing.Size(390, 205);
            this.panelOrdersChart.TabIndex = 65;
            this.panelOrdersChart.Paint += new System.Windows.Forms.PaintEventHandler(this.panelOrdersChart_Paint);
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1216, 688);
            this.Controls.Add(this.panelOrdersChart);
            this.Controls.Add(this.panelChart);
            this.Controls.Add(this.lblRevenue);
            this.Controls.Add(this.lblTotalOrders);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.dgvTopProducts);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblTotalOrders1);
            this.Controls.Add(this.lblTotalRevenue);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblview);
            this.Name = "Statistics";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.Statistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblview;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView dgvTopProducts;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTotalOrders1;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOrdersByDate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.Panel panelOrdersChart;
    }
}