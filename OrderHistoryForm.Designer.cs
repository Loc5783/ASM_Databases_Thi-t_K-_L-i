namespace ASM_Databases_Thiết_Kế_Lại
{
    partial class OrderHistoryForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblview = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.txtSearchOrderID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbOrderDetail = new System.Windows.Forms.RichTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.ErrorImage = global::ASM_Databases_Thiết_Kế_Lại.Properties.Resources._433FE050_2043_45B8_AABC_951FFAD06CF8_;
            this.pictureBox1.Image = global::ASM_Databases_Thiết_Kế_Lại.Properties.Resources._433FE050_2043_45B8_AABC_951FFAD06CF8_;
            this.pictureBox1.InitialImage = global::ASM_Databases_Thiết_Kế_Lại.Properties.Resources._433FE050_2043_45B8_AABC_951FFAD06CF8_;
            this.pictureBox1.Location = new System.Drawing.Point(5, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 137);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // lblview
            // 
            this.lblview.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblview.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblview.Location = new System.Drawing.Point(-2, -3);
            this.lblview.Name = "lblview";
            this.lblview.Size = new System.Drawing.Size(1232, 137);
            this.lblview.TabIndex = 27;
            this.lblview.Text = "Welcome To Order History Form";
            this.lblview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(290, 184);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.Size = new System.Drawing.Size(848, 482);
            this.dgvOrders.TabIndex = 29;
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);
            // 
            // txtSearchOrderID
            // 
            this.txtSearchOrderID.Location = new System.Drawing.Point(178, 156);
            this.txtSearchOrderID.Name = "txtSearchOrderID";
            this.txtSearchOrderID.Size = new System.Drawing.Size(154, 22);
            this.txtSearchOrderID.TabIndex = 30;
            this.txtSearchOrderID.TextChanged += new System.EventHandler(this.txtSearchOrderID_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(5, 201);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(122, 35);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(162, 201);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(122, 35);
            this.btnViewDetail.TabIndex = 32;
            this.btnViewDetail.Text = "ViewDetail";
            this.btnViewDetail.UseVisualStyleBackColor = true;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1144, 643);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 33;
            this.btnBack.Text = "Exit";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 61);
            this.label1.TabIndex = 34;
            this.label1.Text = "Order ID purchased :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbOrderDetail
            // 
            this.rtbOrderDetail.Location = new System.Drawing.Point(5, 242);
            this.rtbOrderDetail.Name = "rtbOrderDetail";
            this.rtbOrderDetail.Size = new System.Drawing.Size(279, 424);
            this.rtbOrderDetail.TabIndex = 36;
            this.rtbOrderDetail.Text = "";
            this.rtbOrderDetail.TextChanged += new System.EventHandler(this.rtbOrderDetail_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1030, 137);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 38;
            // 
            // OrderHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 678);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.rtbOrderDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnViewDetail);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchOrderID);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblview);
            this.Name = "OrderHistoryForm";
            this.Text = "OrderHistoryForm";
            this.Load += new System.EventHandler(this.OrderHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblview;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.TextBox txtSearchOrderID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbOrderDetail;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}