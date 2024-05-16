namespace ttcn
{
    partial class frmphieuxuatkho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmphieuxuatkho));
            this.lblMaHang = new System.Windows.Forms.Label();
            this.dtngaytao = new System.Windows.Forms.DateTimePicker();
            this.dtgphieuxuatkho = new System.Windows.Forms.DataGridView();
            this.txtMaPhieuXuat = new System.Windows.Forms.TextBox();
            this.cboloaiphieu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbonv = new System.Windows.Forms.ComboBox();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblngayban = new System.Windows.Forms.Label();
            this.txttongtien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnthemsanpham = new System.Windows.Forms.Button();
            this.lblMaHDban = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtthanhtien = new System.Windows.Forms.TextBox();
            this.txtck = new System.Windows.Forms.TextBox();
            this.txtgia = new System.Windows.Forms.TextBox();
            this.txtsl = new System.Windows.Forms.TextBox();
            this.txtmasp = new System.Windows.Forms.TextBox();
            this.cbtensp = new System.Windows.Forms.ComboBox();
            this.lblthanhtien = new System.Windows.Forms.Label();
            this.lblck = new System.Windows.Forms.Label();
            this.lbldongia = new System.Windows.Forms.Label();
            this.lblsl = new System.Windows.Forms.Label();
            this.lblTenHang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btntaophieu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgphieuxuatkho)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMaHang
            // 
            this.lblMaHang.AutoSize = true;
            this.lblMaHang.Location = new System.Drawing.Point(6, 70);
            this.lblMaHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaHang.Name = "lblMaHang";
            this.lblMaHang.Size = new System.Drawing.Size(71, 13);
            this.lblMaHang.TabIndex = 0;
            this.lblMaHang.Text = "Mã sản phẩm";
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
            // dtgphieuxuatkho
            // 
            this.dtgphieuxuatkho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgphieuxuatkho.Location = new System.Drawing.Point(31, 186);
            this.dtgphieuxuatkho.Margin = new System.Windows.Forms.Padding(2);
            this.dtgphieuxuatkho.Name = "dtgphieuxuatkho";
            this.dtgphieuxuatkho.RowHeadersWidth = 62;
            this.dtgphieuxuatkho.RowTemplate.Height = 28;
            this.dtgphieuxuatkho.Size = new System.Drawing.Size(742, 160);
            this.dtgphieuxuatkho.TabIndex = 40;
            this.dtgphieuxuatkho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgphieuxuatkho_CellClick);
            this.dtgphieuxuatkho.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgphieuxuatkho_CellContentDoubleClick);
            // 
            // txtMaPhieuXuat
            // 
            this.txtMaPhieuXuat.Location = new System.Drawing.Point(110, 29);
            this.txtMaPhieuXuat.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaPhieuXuat.Name = "txtMaPhieuXuat";
            this.txtMaPhieuXuat.ReadOnly = true;
            this.txtMaPhieuXuat.Size = new System.Drawing.Size(121, 20);
            this.txtMaPhieuXuat.TabIndex = 2;
            // 
            // cboloaiphieu
            // 
            this.cboloaiphieu.FormattingEnabled = true;
            this.cboloaiphieu.Location = new System.Drawing.Point(502, 160);
            this.cboloaiphieu.Margin = new System.Windows.Forms.Padding(2);
            this.cboloaiphieu.Name = "cboloaiphieu";
            this.cboloaiphieu.Size = new System.Drawing.Size(92, 21);
            this.cboloaiphieu.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Xuất đi";
            // 
            // cbonv
            // 
            this.cbonv.FormattingEnabled = true;
            this.cbonv.Location = new System.Drawing.Point(110, 103);
            this.cbonv.Name = "cbonv";
            this.cbonv.Size = new System.Drawing.Size(121, 21);
            this.cbonv.TabIndex = 7;
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
            // txttongtien
            // 
            this.txttongtien.Location = new System.Drawing.Point(489, 364);
            this.txttongtien.Margin = new System.Windows.Forms.Padding(2);
            this.txttongtien.Name = "txttongtien";
            this.txttongtien.ReadOnly = true;
            this.txttongtien.Size = new System.Drawing.Size(162, 20);
            this.txttongtien.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 367);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Tổng tiền";
            // 
            // btnthemsanpham
            // 
            this.btnthemsanpham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthemsanpham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthemsanpham.Location = new System.Drawing.Point(636, 156);
            this.btnthemsanpham.Margin = new System.Windows.Forms.Padding(2);
            this.btnthemsanpham.Name = "btnthemsanpham";
            this.btnthemsanpham.Size = new System.Drawing.Size(106, 26);
            this.btnthemsanpham.TabIndex = 50;
            this.btnthemsanpham.Text = "Thêm sản phẩm";
            this.btnthemsanpham.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnthemsanpham.UseVisualStyleBackColor = true;
//            this.btnthemsanpham.Click += new System.EventHandler(this.btnthemsanpham_Click);
            // 
            // lblMaHDban
            // 
            this.lblMaHDban.AutoSize = true;
            this.lblMaHDban.Location = new System.Drawing.Point(29, 30);
            this.lblMaHDban.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaHDban.Name = "lblMaHDban";
            this.lblMaHDban.Size = new System.Drawing.Size(74, 13);
            this.lblMaHDban.TabIndex = 2;
            this.lblMaHDban.Text = "Mã phiếu xuất";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtthanhtien);
            this.groupBox2.Controls.Add(this.txtck);
            this.groupBox2.Controls.Add(this.txtgia);
            this.groupBox2.Controls.Add(this.txtsl);
            this.groupBox2.Controls.Add(this.txtmasp);
            this.groupBox2.Controls.Add(this.cbtensp);
            this.groupBox2.Controls.Add(this.lblthanhtien);
            this.groupBox2.Controls.Add(this.lblck);
            this.groupBox2.Controls.Add(this.lbldongia);
            this.groupBox2.Controls.Add(this.lblsl);
            this.groupBox2.Controls.Add(this.lblTenHang);
            this.groupBox2.Controls.Add(this.lblMaHang);
            this.groupBox2.Location = new System.Drawing.Point(314, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(459, 149);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết";
            // 
            // txtthanhtien
            // 
            this.txtthanhtien.Location = new System.Drawing.Point(322, 106);
            this.txtthanhtien.Margin = new System.Windows.Forms.Padding(2);
            this.txtthanhtien.Name = "txtthanhtien";
            this.txtthanhtien.ReadOnly = true;
            this.txtthanhtien.Size = new System.Drawing.Size(106, 20);
            this.txtthanhtien.TabIndex = 13;
            // 
            // txtck
            // 
            this.txtck.Location = new System.Drawing.Point(322, 67);
            this.txtck.Margin = new System.Windows.Forms.Padding(2);
            this.txtck.Name = "txtck";
            this.txtck.Size = new System.Drawing.Size(106, 20);
            this.txtck.TabIndex = 12;
            this.txtck.TextChanged += new System.EventHandler(this.txtck_TextChanged);
            this.txtck.Enter += new System.EventHandler(this.txtck_Enter);
            // 
            // txtgia
            // 
            this.txtgia.Location = new System.Drawing.Point(322, 30);
            this.txtgia.Margin = new System.Windows.Forms.Padding(2);
            this.txtgia.Name = "txtgia";
            this.txtgia.Size = new System.Drawing.Size(106, 20);
            this.txtgia.TabIndex = 11;
            this.txtgia.TextChanged += new System.EventHandler(this.txtgia_TextChanged);
            this.txtgia.Enter += new System.EventHandler(this.txtgia_Enter);
            // 
            // txtsl
            // 
            this.txtsl.Location = new System.Drawing.Point(101, 105);
            this.txtsl.Margin = new System.Windows.Forms.Padding(2);
            this.txtsl.Name = "txtsl";
            this.txtsl.Size = new System.Drawing.Size(134, 20);
            this.txtsl.TabIndex = 9;
            this.txtsl.TextChanged += new System.EventHandler(this.txtsl_TextChanged);
            this.txtsl.Enter += new System.EventHandler(this.txtsl_Enter);
            // 
            // txtmasp
            // 
            this.txtmasp.Location = new System.Drawing.Point(101, 67);
            this.txtmasp.Margin = new System.Windows.Forms.Padding(2);
            this.txtmasp.Name = "txtmasp";
            this.txtmasp.Size = new System.Drawing.Size(134, 20);
            this.txtmasp.TabIndex = 8;
            // 
            // cbtensp
            // 
            this.cbtensp.FormattingEnabled = true;
            this.cbtensp.Location = new System.Drawing.Point(101, 30);
            this.cbtensp.Margin = new System.Windows.Forms.Padding(2);
            this.cbtensp.Name = "cbtensp";
            this.cbtensp.Size = new System.Drawing.Size(134, 21);
            this.cbtensp.TabIndex = 7;
            this.cbtensp.SelectedIndexChanged += new System.EventHandler(this.cbtensp_SelectedIndexChanged);
            // 
            // lblthanhtien
            // 
            this.lblthanhtien.AutoSize = true;
            this.lblthanhtien.Location = new System.Drawing.Point(257, 106);
            this.lblthanhtien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblthanhtien.Name = "lblthanhtien";
            this.lblthanhtien.Size = new System.Drawing.Size(61, 13);
            this.lblthanhtien.TabIndex = 6;
            this.lblthanhtien.Text = "Thành tiền:";
            // 
            // lblck
            // 
            this.lblck.AutoSize = true;
            this.lblck.Location = new System.Drawing.Point(257, 70);
            this.lblck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblck.Name = "lblck";
            this.lblck.Size = new System.Drawing.Size(61, 13);
            this.lblck.TabIndex = 5;
            this.lblck.Text = "Chiết khấu:";
            // 
            // lbldongia
            // 
            this.lbldongia.AutoSize = true;
            this.lbldongia.Location = new System.Drawing.Point(257, 32);
            this.lbldongia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldongia.Name = "lbldongia";
            this.lbldongia.Size = new System.Drawing.Size(23, 13);
            this.lbldongia.TabIndex = 4;
            this.lbldongia.Text = "Giá";
            // 
            // lblsl
            // 
            this.lblsl.AutoSize = true;
            this.lblsl.Location = new System.Drawing.Point(6, 106);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 360);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Kích đúp một dòng để xóa";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbonv);
            this.groupBox1.Controls.Add(this.dtngaytao);
            this.groupBox1.Controls.Add(this.txtMaPhieuXuat);
            this.groupBox1.Controls.Add(this.lblTenNV);
            this.groupBox1.Controls.Add(this.lblMaHDban);
            this.groupBox1.Controls.Add(this.lblngayban);
            this.groupBox1.Location = new System.Drawing.Point(31, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(252, 149);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(598, 411);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(77, 26);
            this.btnThoat.TabIndex = 46;
            this.btnThoat.Text = "     Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(327, 411);
            this.btnIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(67, 26);
            this.btnIn.TabIndex = 45;
            this.btnIn.Text = "    In";
            this.btnIn.UseVisualStyleBackColor = true;
            // 
            // btntaophieu
            // 
            this.btntaophieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btntaophieu.Image = ((System.Drawing.Image)(resources.GetObject("btntaophieu.Image")));
            this.btntaophieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntaophieu.Location = new System.Drawing.Point(670, 360);
            this.btntaophieu.Margin = new System.Windows.Forms.Padding(2);
            this.btntaophieu.Name = "btntaophieu";
            this.btntaophieu.Size = new System.Drawing.Size(103, 26);
            this.btntaophieu.TabIndex = 44;
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
            this.btnThem.Location = new System.Drawing.Point(190, 411);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(72, 26);
            this.btnThem.TabIndex = 42;
            this.btnThem.Text = "    Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(459, 411);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(67, 26);
            this.btnHuy.TabIndex = 49;
            this.btnHuy.Text = "     Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmphieuxuatkho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dtgphieuxuatkho);
            this.Controls.Add(this.cboloaiphieu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btntaophieu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txttongtien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnthemsanpham);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmphieuxuatkho";
            this.Text = "Phiếu xuất kho";
            this.Load += new System.EventHandler(this.frmphieuxuatkho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgphieuxuatkho)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaHang;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DateTimePicker dtngaytao;
        private System.Windows.Forms.DataGridView dtgphieuxuatkho;
        private System.Windows.Forms.TextBox txtMaPhieuXuat;
        private System.Windows.Forms.ComboBox cboloaiphieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbonv;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label lblngayban;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btntaophieu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txttongtien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnthemsanpham;
        private System.Windows.Forms.Label lblMaHDban;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtthanhtien;
        private System.Windows.Forms.TextBox txtck;
        private System.Windows.Forms.TextBox txtgia;
        private System.Windows.Forms.TextBox txtsl;
        private System.Windows.Forms.TextBox txtmasp;
        private System.Windows.Forms.ComboBox cbtensp;
        private System.Windows.Forms.Label lblthanhtien;
        private System.Windows.Forms.Label lblck;
        private System.Windows.Forms.Label lbldongia;
        private System.Windows.Forms.Label lblsl;
        private System.Windows.Forms.Label lblTenHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}