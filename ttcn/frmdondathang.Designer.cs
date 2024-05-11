namespace ttcn
{
    partial class frmdondathang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdondathang));
            this.lblMaHang = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dtngaytao = new System.Windows.Forms.DateTimePicker();
            this.dtgdondat = new System.Windows.Forms.DataGridView();
            this.txtMadon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbonv = new System.Windows.Forms.ComboBox();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblngayban = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.btntaophieu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnthemsanpham = new System.Windows.Forms.Button();
            this.lblMaHDban = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.cboncc = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtmancc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsl = new System.Windows.Forms.TextBox();
            this.txtmasp = new System.Windows.Forms.TextBox();
            this.cbtensp = new System.Windows.Forms.ComboBox();
            this.lblsl = new System.Windows.Forms.Label();
            this.lblTenHang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgchitiet = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgdondat)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgchitiet)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaHang
            // 
            this.lblMaHang.AutoSize = true;
            this.lblMaHang.Location = new System.Drawing.Point(266, 38);
            this.lblMaHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaHang.Name = "lblMaHang";
            this.lblMaHang.Size = new System.Drawing.Size(71, 13);
            this.lblMaHang.TabIndex = 0;
            this.lblMaHang.Text = "Mã sản phẩm";
            this.lblMaHang.Click += new System.EventHandler(this.lblMaHang_Click);
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
            // dtgdondat
            // 
            this.dtgdondat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgdondat.Location = new System.Drawing.Point(31, 200);
            this.dtgdondat.Margin = new System.Windows.Forms.Padding(2);
            this.dtgdondat.Name = "dtgdondat";
            this.dtgdondat.RowHeadersWidth = 62;
            this.dtgdondat.RowTemplate.Height = 28;
            this.dtgdondat.Size = new System.Drawing.Size(411, 160);
            this.dtgdondat.TabIndex = 40;
            this.dtgdondat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgdondat_CellClick);
            this.dtgdondat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgdondat_CellContentClick);
            this.dtgdondat.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgdondat_CellContentDoubleClick);
            // 
            // txtMadon
            // 
            this.txtMadon.Location = new System.Drawing.Point(110, 29);
            this.txtMadon.Margin = new System.Windows.Forms.Padding(2);
            this.txtMadon.Name = "txtMadon";
            this.txtMadon.ReadOnly = true;
            this.txtMadon.Size = new System.Drawing.Size(121, 20);
            this.txtMadon.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Nhà cung cấp";
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
            this.btnthemsanpham.Click += new System.EventHandler(this.btnthemsanpham_Click);
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
            this.lblMaHDban.Click += new System.EventHandler(this.lblMaHDban_Click);
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
            // cboncc
            // 
            this.cboncc.FormattingEnabled = true;
            this.cboncc.Location = new System.Drawing.Point(101, 64);
            this.cboncc.Margin = new System.Windows.Forms.Padding(2);
            this.cboncc.Name = "cboncc";
            this.cboncc.Size = new System.Drawing.Size(134, 21);
            this.cboncc.TabIndex = 52;
            this.cboncc.SelectedValueChanged += new System.EventHandler(this.cboncc_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtmancc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtsl);
            this.groupBox2.Controls.Add(this.txtmasp);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbtensp);
            this.groupBox2.Controls.Add(this.lblsl);
            this.groupBox2.Controls.Add(this.lblTenHang);
            this.groupBox2.Controls.Add(this.lblMaHang);
            this.groupBox2.Controls.Add(this.cboncc);
            this.groupBox2.Location = new System.Drawing.Point(314, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(459, 149);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết";
            // 
            // txtmancc
            // 
            this.txtmancc.Location = new System.Drawing.Point(361, 71);
            this.txtmancc.Margin = new System.Windows.Forms.Padding(2);
            this.txtmancc.Name = "txtmancc";
            this.txtmancc.ReadOnly = true;
            this.txtmancc.Size = new System.Drawing.Size(80, 20);
            this.txtmancc.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Mã nhà cung cấp";
            // 
            // txtsl
            // 
            this.txtsl.Location = new System.Drawing.Point(101, 105);
            this.txtsl.Margin = new System.Windows.Forms.Padding(2);
            this.txtsl.Name = "txtsl";
            this.txtsl.Size = new System.Drawing.Size(134, 20);
            this.txtsl.TabIndex = 9;
            // 
            // txtmasp
            // 
            this.txtmasp.Location = new System.Drawing.Point(361, 35);
            this.txtmasp.Margin = new System.Windows.Forms.Padding(2);
            this.txtmasp.Name = "txtmasp";
            this.txtmasp.ReadOnly = true;
            this.txtmasp.Size = new System.Drawing.Size(80, 20);
            this.txtmasp.TabIndex = 8;
            this.txtmasp.TextChanged += new System.EventHandler(this.txtmasp_TextChanged);
            // 
            // cbtensp
            // 
            this.cbtensp.FormattingEnabled = true;
            this.cbtensp.Location = new System.Drawing.Point(101, 30);
            this.cbtensp.Margin = new System.Windows.Forms.Padding(2);
            this.cbtensp.Name = "cbtensp";
            this.cbtensp.Size = new System.Drawing.Size(134, 21);
            this.cbtensp.TabIndex = 7;
            this.cbtensp.SelectedValueChanged += new System.EventHandler(this.cbtensp_SelectedValueChanged);
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
            this.label1.Location = new System.Drawing.Point(28, 367);
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
            this.groupBox1.Controls.Add(this.txtMadon);
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
            // dtgchitiet
            // 
            this.dtgchitiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgchitiet.Location = new System.Drawing.Point(459, 200);
            this.dtgchitiet.Margin = new System.Windows.Forms.Padding(2);
            this.dtgchitiet.Name = "dtgchitiet";
            this.dtgchitiet.RowHeadersWidth = 62;
            this.dtgchitiet.RowTemplate.Height = 28;
            this.dtgchitiet.Size = new System.Drawing.Size(314, 160);
            this.dtgchitiet.TabIndex = 51;
            this.dtgchitiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgchitiet_CellClick);
            this.dtgchitiet.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgchitiet_CellContentDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(22, 186);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(424, 179);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách phiếu";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(450, 186);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(339, 179);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chi tiết phiếu";
            // 
            // frmdondathang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgchitiet);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dtgdondat);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btntaophieu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnthemsanpham);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "frmdondathang";
            this.Text = "Đơn đặt hàng";
            this.Load += new System.EventHandler(this.frmdondathang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgdondat)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgchitiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaHang;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DateTimePicker dtngaytao;
        private System.Windows.Forms.DataGridView dtgdondat;
        private System.Windows.Forms.TextBox txtMadon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbonv;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label lblngayban;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btntaophieu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnthemsanpham;
        private System.Windows.Forms.Label lblMaHDban;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ComboBox cboncc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtsl;
        private System.Windows.Forms.TextBox txtmasp;
        private System.Windows.Forms.ComboBox cbtensp;
        private System.Windows.Forms.Label lblsl;
        private System.Windows.Forms.Label lblTenHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtmancc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dtgchitiet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}