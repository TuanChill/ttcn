namespace ttcn
{
    partial class frmphieuthuhoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmphieuthuhoi));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbonv = new System.Windows.Forms.ComboBox();
            this.dtngaytao = new System.Windows.Forms.DateTimePicker();
            this.txtMaPhieuThuHoi = new System.Windows.Forms.TextBox();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblMaHDban = new System.Windows.Forms.Label();
            this.lblngayban = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsl = new System.Windows.Forms.TextBox();
            this.cbtensp = new System.Windows.Forms.ComboBox();
            this.lblsl = new System.Windows.Forms.Label();
            this.lblTenHang = new System.Windows.Forms.Label();
            this.btnthemsanpham = new System.Windows.Forms.Button();
            this.dtgphieuthuhoi = new System.Windows.Forms.DataGridView();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btntaophieu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgphieuthuhoi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 385);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Kích đúp một dòng để xóa";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbonv);
            this.groupBox1.Controls.Add(this.dtngaytao);
            this.groupBox1.Controls.Add(this.txtMaPhieuThuHoi);
            this.groupBox1.Controls.Add(this.lblTenNV);
            this.groupBox1.Controls.Add(this.lblMaHDban);
            this.groupBox1.Controls.Add(this.lblngayban);
            this.groupBox1.Location = new System.Drawing.Point(31, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(252, 164);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // cbonv
            // 
            this.cbonv.FormattingEnabled = true;
            this.cbonv.Location = new System.Drawing.Point(110, 103);
            this.cbonv.Name = "cbonv";
            this.cbonv.Size = new System.Drawing.Size(121, 21);
            this.cbonv.TabIndex = 7;
            // 
            // dtngaytao
            // 
            this.dtngaytao.CustomFormat = "dd/MM/yyyy";
            this.dtngaytao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtngaytao.Location = new System.Drawing.Point(110, 67);
            this.dtngaytao.Margin = new System.Windows.Forms.Padding(2);
            this.dtngaytao.Name = "dtngaytao";
            this.dtngaytao.Size = new System.Drawing.Size(121, 20);
            this.dtngaytao.TabIndex = 6;
            // 
            // txtMaPhieuThuHoi
            // 
            this.txtMaPhieuThuHoi.Location = new System.Drawing.Point(110, 29);
            this.txtMaPhieuThuHoi.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaPhieuThuHoi.Name = "txtMaPhieuThuHoi";
            this.txtMaPhieuThuHoi.ReadOnly = true;
            this.txtMaPhieuThuHoi.Size = new System.Drawing.Size(121, 20);
            this.txtMaPhieuThuHoi.TabIndex = 2;
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Location = new System.Drawing.Point(29, 105);
            this.lblTenNV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(56, 13);
            this.lblTenNV.TabIndex = 4;
            this.lblTenNV.Text = "Nhân viên";
            // 
            // lblMaHDban
            // 
            this.lblMaHDban.AutoSize = true;
            this.lblMaHDban.Location = new System.Drawing.Point(29, 30);
            this.lblMaHDban.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaHDban.Name = "lblMaHDban";
            this.lblMaHDban.Size = new System.Drawing.Size(51, 13);
            this.lblMaHDban.TabIndex = 2;
            this.lblMaHDban.Text = "Mã phiếu";
            // 
            // lblngayban
            // 
            this.lblngayban.AutoSize = true;
            this.lblngayban.Location = new System.Drawing.Point(29, 67);
            this.lblngayban.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblngayban.Name = "lblngayban";
            this.lblngayban.Size = new System.Drawing.Size(50, 13);
            this.lblngayban.TabIndex = 0;
            this.lblngayban.Text = "Ngày tạo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtghichu);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtsl);
            this.groupBox2.Controls.Add(this.cbtensp);
            this.groupBox2.Controls.Add(this.lblsl);
            this.groupBox2.Controls.Add(this.lblTenHang);
            this.groupBox2.Location = new System.Drawing.Point(314, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(459, 164);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết";
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(101, 67);
            this.txtghichu.Margin = new System.Windows.Forms.Padding(2);
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(327, 78);
            this.txtghichu.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Chi tiết";
            // 
            // txtsl
            // 
            this.txtsl.Location = new System.Drawing.Point(383, 31);
            this.txtsl.Margin = new System.Windows.Forms.Padding(2);
            this.txtsl.Name = "txtsl";
            this.txtsl.Size = new System.Drawing.Size(45, 20);
            this.txtsl.TabIndex = 9;
            this.txtsl.Enter += new System.EventHandler(this.txtsl_Enter);
            // 
            // cbtensp
            // 
            this.cbtensp.FormattingEnabled = true;
            this.cbtensp.Location = new System.Drawing.Point(101, 30);
            this.cbtensp.Margin = new System.Windows.Forms.Padding(2);
            this.cbtensp.Name = "cbtensp";
            this.cbtensp.Size = new System.Drawing.Size(187, 21);
            this.cbtensp.TabIndex = 7;
            // 
            // lblsl
            // 
            this.lblsl.AutoSize = true;
            this.lblsl.Location = new System.Drawing.Point(309, 33);
            this.lblsl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblsl.Name = "lblsl";
            this.lblsl.Size = new System.Drawing.Size(52, 13);
            this.lblsl.TabIndex = 3;
            this.lblsl.Text = "Số lượng:";
            // 
            // lblTenHang
            // 
            this.lblTenHang.AutoSize = true;
            this.lblTenHang.Location = new System.Drawing.Point(4, 33);
            this.lblTenHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenHang.Name = "lblTenHang";
            this.lblTenHang.Size = new System.Drawing.Size(75, 13);
            this.lblTenHang.TabIndex = 1;
            this.lblTenHang.Text = "Tên sản phẩm";
            // 
            // btnthemsanpham
            // 
            this.btnthemsanpham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthemsanpham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthemsanpham.Location = new System.Drawing.Point(636, 181);
            this.btnthemsanpham.Margin = new System.Windows.Forms.Padding(2);
            this.btnthemsanpham.Name = "btnthemsanpham";
            this.btnthemsanpham.Size = new System.Drawing.Size(106, 26);
            this.btnthemsanpham.TabIndex = 64;
            this.btnthemsanpham.Text = "Thêm sản phẩm";
            this.btnthemsanpham.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnthemsanpham.UseVisualStyleBackColor = true;
            this.btnthemsanpham.Click += new System.EventHandler(this.btnthemsanpham_Click);
            // 
            // dtgphieuthuhoi
            // 
            this.dtgphieuthuhoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgphieuthuhoi.Location = new System.Drawing.Point(31, 211);
            this.dtgphieuthuhoi.Margin = new System.Windows.Forms.Padding(2);
            this.dtgphieuthuhoi.Name = "dtgphieuthuhoi";
            this.dtgphieuthuhoi.RowHeadersWidth = 62;
            this.dtgphieuthuhoi.RowTemplate.Height = 28;
            this.dtgphieuthuhoi.Size = new System.Drawing.Size(742, 160);
            this.dtgphieuthuhoi.TabIndex = 54;
            this.dtgphieuthuhoi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgphieuthuhoi_CellContentClick);
            this.dtgphieuthuhoi.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgphieuthuhoi_CellContentDoubleClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(598, 436);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(77, 26);
            this.btnThoat.TabIndex = 60;
            this.btnThoat.Text = "     Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(327, 436);
            this.btnIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(67, 26);
            this.btnIn.TabIndex = 59;
            this.btnIn.Text = "    In";
            this.btnIn.UseVisualStyleBackColor = true;
            // 
            // btntaophieu
            // 
            this.btntaophieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btntaophieu.Image = ((System.Drawing.Image)(resources.GetObject("btntaophieu.Image")));
            this.btntaophieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntaophieu.Location = new System.Drawing.Point(670, 385);
            this.btntaophieu.Margin = new System.Windows.Forms.Padding(2);
            this.btntaophieu.Name = "btntaophieu";
            this.btntaophieu.Size = new System.Drawing.Size(103, 26);
            this.btntaophieu.TabIndex = 58;
            this.btntaophieu.Text = "    Tạo phiếu";
            this.btntaophieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntaophieu.UseVisualStyleBackColor = true;
            this.btntaophieu.Click += new System.EventHandler(this.btntaophieu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(190, 436);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(72, 26);
            this.btnThem.TabIndex = 56;
            this.btnThem.Text = "    Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(459, 436);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(67, 26);
            this.btnHuy.TabIndex = 63;
            this.btnHuy.Text = "     Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmphieuthuhoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 477);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btntaophieu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnthemsanpham);
            this.Controls.Add(this.dtgphieuthuhoi);
            this.Name = "frmphieuthuhoi";
            this.Text = "Phiếu thu hồi";
            this.Load += new System.EventHandler(this.frmphieuthuhoi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgphieuthuhoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btntaophieu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbonv;
        private System.Windows.Forms.DateTimePicker dtngaytao;
        private System.Windows.Forms.TextBox txtMaPhieuThuHoi;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label lblMaHDban;
        private System.Windows.Forms.Label lblngayban;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtsl;
        private System.Windows.Forms.ComboBox cbtensp;
        private System.Windows.Forms.Label lblsl;
        private System.Windows.Forms.Label lblTenHang;
        private System.Windows.Forms.Button btnthemsanpham;
        private System.Windows.Forms.DataGridView dtgphieuthuhoi;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.Label label2;
    }
}