namespace ASM_Databases_Thiết_Kế_Lại
{
    partial class ProductViewerForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboFilterBy = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpProductDetail = new System.Windows.Forms.GroupBox();
            this.rtbProductDetail = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.picProductImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.BuyProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.grpProductDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblview
            // 
            this.lblview.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblview.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblview.Location = new System.Drawing.Point(0, 0);
            this.lblview.Name = "lblview";
            this.lblview.Size = new System.Drawing.Size(1232, 137);
            this.lblview.TabIndex = 25;
            this.lblview.Text = "Welcome To Product Viewer Form";
            this.lblview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 57);
            this.label2.TabIndex = 27;
            this.label2.Text = "Product list name :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1104, 630);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 43);
            this.button1.TabIndex = 28;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(21, 357);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(1051, 316);
            this.dgvProducts.TabIndex = 29;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(254, 173);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(433, 22);
            this.txtSearch.TabIndex = 30;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(707, 168);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 33);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.Text = "Search ";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.dgvProducts_Click);
            // 
            // cboFilterBy
            // 
            this.cboFilterBy.AutoCompleteCustomSource.AddRange(new string[] {
            "Product ID",
            "Name",
            "Min Price",
            "Max Price"});
            this.cboFilterBy.FormattingEnabled = true;
            this.cboFilterBy.Location = new System.Drawing.Point(270, 251);
            this.cboFilterBy.Name = "cboFilterBy";
            this.cboFilterBy.Size = new System.Drawing.Size(175, 24);
            this.cboFilterBy.TabIndex = 32;
            this.cboFilterBy.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(494, 245);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(97, 33);
            this.btnReset.TabIndex = 33;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(1104, 454);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(106, 52);
            this.btnViewDetail.TabIndex = 34;
            this.btnViewDetail.Text = "ViewDetail";
            this.btnViewDetail.UseVisualStyleBackColor = true;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1104, 551);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 52);
            this.button3.TabIndex = 35;
            this.button3.Text = "export PDF file";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 57);
            this.label1.TabIndex = 36;
            this.label1.Text = "Filter products :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpProductDetail
            // 
            this.grpProductDetail.Controls.Add(this.rtbProductDetail);
            this.grpProductDetail.Controls.Add(this.btnExit);
            this.grpProductDetail.Controls.Add(this.picProductImage);
            this.grpProductDetail.Location = new System.Drawing.Point(634, 207);
            this.grpProductDetail.Name = "grpProductDetail";
            this.grpProductDetail.Size = new System.Drawing.Size(413, 452);
            this.grpProductDetail.TabIndex = 37;
            this.grpProductDetail.TabStop = false;
            this.grpProductDetail.Text = "product information";
            this.grpProductDetail.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rtbProductDetail
            // 
            this.rtbProductDetail.Location = new System.Drawing.Point(6, 281);
            this.rtbProductDetail.Name = "rtbProductDetail";
            this.rtbProductDetail.Size = new System.Drawing.Size(401, 136);
            this.rtbProductDetail.TabIndex = 4;
            this.rtbProductDetail.Text = "";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(284, 423);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // picProductImage
            // 
            this.picProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProductImage.Location = new System.Drawing.Point(6, 23);
            this.picProductImage.Name = "picProductImage";
            this.picProductImage.Size = new System.Drawing.Size(401, 252);
            this.picProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProductImage.TabIndex = 0;
            this.picProductImage.TabStop = false;
            this.picProductImage.Click += new System.EventHandler(this.picProductImage_Click);
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
            this.pictureBox1.Location = new System.Drawing.Point(7, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 133);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1019, 140);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 38;
            // 
            // BuyProduct
            // 
            this.BuyProduct.Location = new System.Drawing.Point(1104, 357);
            this.BuyProduct.Name = "BuyProduct";
            this.BuyProduct.Size = new System.Drawing.Size(106, 52);
            this.BuyProduct.TabIndex = 39;
            this.BuyProduct.Text = "Buy Product";
            this.BuyProduct.UseVisualStyleBackColor = true;
            this.BuyProduct.Click += new System.EventHandler(this.BuyProduct_Click);
            // 
            // ProductViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1243, 681);
            this.Controls.Add(this.BuyProduct);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.grpProductDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnViewDetail);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cboFilterBy);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblview);
            this.Name = "ProductViewerForm";
            this.Text = "ProductViewerForm";
            this.Load += new System.EventHandler(this.ProductViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.grpProductDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboFilterBy;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpProductDetail;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.PictureBox picProductImage;
        private System.Windows.Forms.RichTextBox rtbProductDetail;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button BuyProduct;
    }
}