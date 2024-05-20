namespace ttcn
{
    partial class formNL
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
            this.components = new System.ComponentModel.Container();
            this.txt_ghichu = new System.Windows.Forms.TextBox();
            this.combo_maloai = new System.Windows.Forms.ComboBox();
            this.btn_hienthi = new System.Windows.Forms.Button();
            this.datagridview_nguyenlieu = new System.Windows.Forms.DataGridView();
            this.btn_open = new System.Windows.Forms.Button();
            this.txt_anh = new System.Windows.Forms.TextBox();
            this.txt_gia = new System.Windows.Forms.TextBox();
            this.txt_sl = new System.Windows.Forms.TextBox();
            this.txt_ten = new System.Windows.Forms.TextBox();
            this.txt_manl = new System.Windows.Forms.TextBox();
            this.lb_gchu = new System.Windows.Forms.Label();
            this.lb_anh = new System.Windows.Forms.Label();
            this.lb_gia = new System.Windows.Forms.Label();
            this.lb_sl = new System.Windows.Forms.Label();
            this.lb_maloai = new System.Windows.Forms.Label();
            this.lb_ten = new System.Windows.Forms.Label();
            this.lb_mahang = new System.Windows.Forms.Label();
            this.lb_danhmuc = new System.Windows.Forms.Label();
            this.combo_mancc = new System.Windows.Forms.ComboBox();
            this.lb_mancc = new System.Windows.Forms.Label();
            this.combo_matt = new System.Windows.Forms.ComboBox();
            this.lb_matt = new System.Windows.Forms.Label();
            this.combo_chinhanh = new System.Windows.Forms.ComboBox();
            this.lb_macn = new System.Windows.Forms.Label();
            this.btn_An = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip6 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip7 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip8 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip9 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_loainl = new System.Windows.Forms.Button();
            this.btn_tt = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.btn_dong = new System.Windows.Forms.Button();
            this.btn_tk = new System.Windows.Forms.Button();
            this.btn_boqua = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_nguyenlieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_ghichu
            // 
            this.txt_ghichu.Location = new System.Drawing.Point(532, 292);
            this.txt_ghichu.Multiline = true;
            this.txt_ghichu.Name = "txt_ghichu";
            this.txt_ghichu.Size = new System.Drawing.Size(292, 100);
            this.txt_ghichu.TabIndex = 85;
            this.toolTip9.SetToolTip(this.txt_ghichu, "Hãy nhập vào trường này");
            // 
            // combo_maloai
            // 
            this.combo_maloai.FormattingEnabled = true;
            this.combo_maloai.Location = new System.Drawing.Point(197, 206);
            this.combo_maloai.Name = "combo_maloai";
            this.combo_maloai.Size = new System.Drawing.Size(134, 24);
            this.combo_maloai.TabIndex = 84;
            this.toolTip3.SetToolTip(this.combo_maloai, "Vui lòng chọn mã loại");
            this.combo_maloai.KeyUp += new System.Windows.Forms.KeyEventHandler(this.combo_maloai_KeyUp);
            // 
            // btn_hienthi
            // 
            this.btn_hienthi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_hienthi.Location = new System.Drawing.Point(625, 630);
            this.btn_hienthi.Name = "btn_hienthi";
            this.btn_hienthi.Size = new System.Drawing.Size(92, 41);
            this.btn_hienthi.TabIndex = 83;
            this.btn_hienthi.Text = "Hiển thị DS";
            this.btn_hienthi.UseVisualStyleBackColor = false;
            this.btn_hienthi.Click += new System.EventHandler(this.btn_hienthi_Click);
            // 
            // datagridview_nguyenlieu
            // 
            this.datagridview_nguyenlieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridview_nguyenlieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_nguyenlieu.Location = new System.Drawing.Point(64, 410);
            this.datagridview_nguyenlieu.Name = "datagridview_nguyenlieu";
            this.datagridview_nguyenlieu.RowHeadersWidth = 51;
            this.datagridview_nguyenlieu.RowTemplate.Height = 24;
            this.datagridview_nguyenlieu.Size = new System.Drawing.Size(690, 142);
            this.datagridview_nguyenlieu.TabIndex = 75;
            this.datagridview_nguyenlieu.Click += new System.EventHandler(this.datagridview_nguyenlieu_Click);
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(532, 212);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(67, 37);
            this.btn_open.TabIndex = 74;
            this.btn_open.Text = "Open";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // txt_anh
            // 
            this.txt_anh.Location = new System.Drawing.Point(532, 156);
            this.txt_anh.Name = "txt_anh";
            this.txt_anh.Size = new System.Drawing.Size(134, 22);
            this.txt_anh.TabIndex = 73;
            // 
            // txt_gia
            // 
            this.txt_gia.Location = new System.Drawing.Point(197, 284);
            this.txt_gia.Name = "txt_gia";
            this.txt_gia.Size = new System.Drawing.Size(134, 22);
            this.txt_gia.TabIndex = 71;
            this.toolTip5.SetToolTip(this.txt_gia, "Hãy nhập vào trường này");
            this.txt_gia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_gia_KeyUp);
            // 
            // txt_sl
            // 
            this.txt_sl.Location = new System.Drawing.Point(197, 242);
            this.txt_sl.Name = "txt_sl";
            this.txt_sl.Size = new System.Drawing.Size(134, 22);
            this.txt_sl.TabIndex = 70;
            this.toolTip4.SetToolTip(this.txt_sl, "Hãy nhập vào trường này");
            this.txt_sl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_sl_KeyUp);
            // 
            // txt_ten
            // 
            this.txt_ten.Location = new System.Drawing.Point(197, 156);
            this.txt_ten.Name = "txt_ten";
            this.txt_ten.Size = new System.Drawing.Size(134, 22);
            this.txt_ten.TabIndex = 69;
            this.toolTip2.SetToolTip(this.txt_ten, "Hãy nhập vào trường này");
            this.txt_ten.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_ten_KeyUp);
            // 
            // txt_manl
            // 
            this.txt_manl.Location = new System.Drawing.Point(197, 113);
            this.txt_manl.Name = "txt_manl";
            this.txt_manl.Size = new System.Drawing.Size(134, 22);
            this.txt_manl.TabIndex = 68;
            this.toolTip1.SetToolTip(this.txt_manl, "Hãy nhập vào trường này");
            this.txt_manl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_manl_KeyUp);
            // 
            // lb_gchu
            // 
            this.lb_gchu.AutoSize = true;
            this.lb_gchu.Location = new System.Drawing.Point(425, 288);
            this.lb_gchu.Name = "lb_gchu";
            this.lb_gchu.Size = new System.Drawing.Size(54, 16);
            this.lb_gchu.TabIndex = 67;
            this.lb_gchu.Text = "Ghi chú:";
            // 
            // lb_anh
            // 
            this.lb_anh.AutoSize = true;
            this.lb_anh.Location = new System.Drawing.Point(427, 162);
            this.lb_anh.Name = "lb_anh";
            this.lb_anh.Size = new System.Drawing.Size(33, 16);
            this.lb_anh.TabIndex = 66;
            this.lb_anh.Text = "Ảnh:";
            // 
            // lb_gia
            // 
            this.lb_gia.AutoSize = true;
            this.lb_gia.Location = new System.Drawing.Point(61, 290);
            this.lb_gia.Name = "lb_gia";
            this.lb_gia.Size = new System.Drawing.Size(31, 16);
            this.lb_gia.TabIndex = 64;
            this.lb_gia.Text = "Giá:";
            // 
            // lb_sl
            // 
            this.lb_sl.AutoSize = true;
            this.lb_sl.Location = new System.Drawing.Point(61, 248);
            this.lb_sl.Name = "lb_sl";
            this.lb_sl.Size = new System.Drawing.Size(63, 16);
            this.lb_sl.TabIndex = 63;
            this.lb_sl.Text = "Số lượng:";
            // 
            // lb_maloai
            // 
            this.lb_maloai.AutoSize = true;
            this.lb_maloai.Location = new System.Drawing.Point(61, 206);
            this.lb_maloai.Name = "lb_maloai";
            this.lb_maloai.Size = new System.Drawing.Size(51, 16);
            this.lb_maloai.TabIndex = 62;
            this.lb_maloai.Text = "Mã loại";
            // 
            // lb_ten
            // 
            this.lb_ten.AutoSize = true;
            this.lb_ten.Location = new System.Drawing.Point(61, 162);
            this.lb_ten.Name = "lb_ten";
            this.lb_ten.Size = new System.Drawing.Size(105, 16);
            this.lb_ten.TabIndex = 61;
            this.lb_ten.Text = "Tên nguyên liệu:";
            // 
            // lb_mahang
            // 
            this.lb_mahang.AutoSize = true;
            this.lb_mahang.Location = new System.Drawing.Point(61, 120);
            this.lb_mahang.Name = "lb_mahang";
            this.lb_mahang.Size = new System.Drawing.Size(100, 16);
            this.lb_mahang.TabIndex = 60;
            this.lb_mahang.Text = "Mã nguyên liệu:";
            // 
            // lb_danhmuc
            // 
            this.lb_danhmuc.AutoSize = true;
            this.lb_danhmuc.BackColor = System.Drawing.SystemColors.Control;
            this.lb_danhmuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_danhmuc.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lb_danhmuc.Location = new System.Drawing.Point(275, 35);
            this.lb_danhmuc.Name = "lb_danhmuc";
            this.lb_danhmuc.Size = new System.Drawing.Size(424, 36);
            this.lb_danhmuc.TabIndex = 59;
            this.lb_danhmuc.Text = "DANH SÁCH NGUYÊN LIỆU";
            // 
            // combo_mancc
            // 
            this.combo_mancc.FormattingEnabled = true;
            this.combo_mancc.Location = new System.Drawing.Point(197, 324);
            this.combo_mancc.Name = "combo_mancc";
            this.combo_mancc.Size = new System.Drawing.Size(134, 24);
            this.combo_mancc.TabIndex = 88;
            this.toolTip6.SetToolTip(this.combo_mancc, "Vui lòng chọn nhà cung cấp");
            this.combo_mancc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.combo_mancc_KeyUp);
            // 
            // lb_mancc
            // 
            this.lb_mancc.AutoSize = true;
            this.lb_mancc.Location = new System.Drawing.Point(61, 324);
            this.lb_mancc.Name = "lb_mancc";
            this.lb_mancc.Size = new System.Drawing.Size(112, 16);
            this.lb_mancc.TabIndex = 87;
            this.lb_mancc.Text = "Mã nhà cung cấp:";
            // 
            // combo_matt
            // 
            this.combo_matt.FormattingEnabled = true;
            this.combo_matt.Location = new System.Drawing.Point(197, 368);
            this.combo_matt.Name = "combo_matt";
            this.combo_matt.Size = new System.Drawing.Size(134, 24);
            this.combo_matt.TabIndex = 90;
            this.toolTip8.SetToolTip(this.combo_matt, "Vui lòng chọn mã tình trạng");
            this.combo_matt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.combo_matt_KeyUp);
            // 
            // lb_matt
            // 
            this.lb_matt.AutoSize = true;
            this.lb_matt.Location = new System.Drawing.Point(61, 368);
            this.lb_matt.Name = "lb_matt";
            this.lb_matt.Size = new System.Drawing.Size(85, 16);
            this.lb_matt.TabIndex = 89;
            this.lb_matt.Text = "Mã tình trạng:";
            // 
            // combo_chinhanh
            // 
            this.combo_chinhanh.FormattingEnabled = true;
            this.combo_chinhanh.Location = new System.Drawing.Point(532, 112);
            this.combo_chinhanh.Name = "combo_chinhanh";
            this.combo_chinhanh.Size = new System.Drawing.Size(134, 24);
            this.combo_chinhanh.TabIndex = 92;
            this.toolTip8.SetToolTip(this.combo_chinhanh, "Vui lòng chọn mã chi nhánh");
            // 
            // lb_macn
            // 
            this.lb_macn.AutoSize = true;
            this.lb_macn.Location = new System.Drawing.Point(427, 115);
            this.lb_macn.Name = "lb_macn";
            this.lb_macn.Size = new System.Drawing.Size(88, 16);
            this.lb_macn.TabIndex = 91;
            this.lb_macn.Text = "Mã chi nhánh:";
            // 
            // btn_An
            // 
            this.btn_An.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_An.Location = new System.Drawing.Point(723, 630);
            this.btn_An.Name = "btn_An";
            this.btn_An.Size = new System.Drawing.Size(92, 41);
            this.btn_An.TabIndex = 93;
            this.btn_An.Text = "Ẩn DS";
            this.btn_An.UseVisualStyleBackColor = false;
            this.btn_An.Click += new System.EventHandler(this.btn_An_Click);
            // 
            // btn_loainl
            // 
            this.btn_loainl.Location = new System.Drawing.Point(819, 410);
            this.btn_loainl.Name = "btn_loainl";
            this.btn_loainl.Size = new System.Drawing.Size(110, 62);
            this.btn_loainl.TabIndex = 94;
            this.btn_loainl.Text = "Loại nguyên liệu";
            this.btn_loainl.UseVisualStyleBackColor = true;
            this.btn_loainl.Click += new System.EventHandler(this.btn_loainl_Click);
            // 
            // btn_tt
            // 
            this.btn_tt.Location = new System.Drawing.Point(819, 490);
            this.btn_tt.Name = "btn_tt";
            this.btn_tt.Size = new System.Drawing.Size(110, 62);
            this.btn_tt.TabIndex = 95;
            this.btn_tt.Text = "Tình trạng";
            this.btn_tt.UseVisualStyleBackColor = true;
            this.btn_tt.Click += new System.EventHandler(this.btn_tt_Click);
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(711, 101);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(174, 139);
            this.pic.TabIndex = 86;
            this.pic.TabStop = false;
            // 
            // btn_dong
            // 
            this.btn_dong.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_dong.Location = new System.Drawing.Point(819, 630);
            this.btn_dong.Name = "btn_dong";
            this.btn_dong.Size = new System.Drawing.Size(92, 41);
            this.btn_dong.TabIndex = 82;
            this.btn_dong.Text = "Đóng";
            this.btn_dong.UseVisualStyleBackColor = false;
            this.btn_dong.Click += new System.EventHandler(this.btn_dong_Click);
            // 
            // btn_tk
            // 
            this.btn_tk.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_tk.Location = new System.Drawing.Point(527, 630);
            this.btn_tk.Name = "btn_tk";
            this.btn_tk.Size = new System.Drawing.Size(92, 41);
            this.btn_tk.TabIndex = 81;
            this.btn_tk.Text = "Tìm kiếm";
            this.btn_tk.UseVisualStyleBackColor = false;
            this.btn_tk.Click += new System.EventHandler(this.btn_tk_Click);
            // 
            // btn_boqua
            // 
            this.btn_boqua.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_boqua.Location = new System.Drawing.Point(429, 630);
            this.btn_boqua.Name = "btn_boqua";
            this.btn_boqua.Size = new System.Drawing.Size(92, 41);
            this.btn_boqua.TabIndex = 80;
            this.btn_boqua.Text = "Bỏ qua";
            this.btn_boqua.UseVisualStyleBackColor = false;
            this.btn_boqua.Click += new System.EventHandler(this.btn_boqua_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_sua.Location = new System.Drawing.Point(223, 630);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(92, 41);
            this.btn_sua.TabIndex = 79;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = false;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_luu.Location = new System.Drawing.Point(331, 630);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(92, 41);
            this.btn_luu.TabIndex = 78;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.UseVisualStyleBackColor = false;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_xoa.Location = new System.Drawing.Point(125, 630);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(92, 41);
            this.btn_xoa.TabIndex = 77;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = false;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_them.Location = new System.Drawing.Point(27, 630);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(92, 41);
            this.btn_them.TabIndex = 76;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = false;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // formNL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 683);
            this.Controls.Add(this.btn_tt);
            this.Controls.Add(this.btn_loainl);
            this.Controls.Add(this.btn_An);
            this.Controls.Add(this.combo_chinhanh);
            this.Controls.Add(this.lb_macn);
            this.Controls.Add(this.combo_matt);
            this.Controls.Add(this.lb_matt);
            this.Controls.Add(this.combo_mancc);
            this.Controls.Add(this.lb_mancc);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.txt_ghichu);
            this.Controls.Add(this.combo_maloai);
            this.Controls.Add(this.btn_hienthi);
            this.Controls.Add(this.btn_dong);
            this.Controls.Add(this.btn_tk);
            this.Controls.Add(this.btn_boqua);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.datagridview_nguyenlieu);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.txt_anh);
            this.Controls.Add(this.txt_gia);
            this.Controls.Add(this.txt_sl);
            this.Controls.Add(this.txt_ten);
            this.Controls.Add(this.txt_manl);
            this.Controls.Add(this.lb_gchu);
            this.Controls.Add(this.lb_anh);
            this.Controls.Add(this.lb_gia);
            this.Controls.Add(this.lb_sl);
            this.Controls.Add(this.lb_maloai);
            this.Controls.Add(this.lb_ten);
            this.Controls.Add(this.lb_mahang);
            this.Controls.Add(this.lb_danhmuc);
            this.Name = "formNL";
            this.Text = "Nguyên liệu";
            this.Load += new System.EventHandler(this.formNL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_nguyenlieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.TextBox txt_ghichu;
        private System.Windows.Forms.ComboBox combo_maloai;
        private System.Windows.Forms.Button btn_hienthi;
        private System.Windows.Forms.Button btn_dong;
        private System.Windows.Forms.Button btn_tk;
        private System.Windows.Forms.Button btn_boqua;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.DataGridView datagridview_nguyenlieu;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.TextBox txt_anh;
        private System.Windows.Forms.TextBox txt_gia;
        private System.Windows.Forms.TextBox txt_sl;
        private System.Windows.Forms.TextBox txt_ten;
        private System.Windows.Forms.TextBox txt_manl;
        private System.Windows.Forms.Label lb_gchu;
        private System.Windows.Forms.Label lb_anh;
        private System.Windows.Forms.Label lb_gia;
        private System.Windows.Forms.Label lb_sl;
        private System.Windows.Forms.Label lb_maloai;
        private System.Windows.Forms.Label lb_ten;
        private System.Windows.Forms.Label lb_mahang;
        private System.Windows.Forms.Label lb_danhmuc;
        private System.Windows.Forms.ComboBox combo_mancc;
        private System.Windows.Forms.Label lb_mancc;
        private System.Windows.Forms.ComboBox combo_matt;
        private System.Windows.Forms.Label lb_matt;
        private System.Windows.Forms.ComboBox combo_chinhanh;
        private System.Windows.Forms.Label lb_macn;
        private System.Windows.Forms.Button btn_An;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip5;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip6;
        private System.Windows.Forms.ToolTip toolTip7;
        private System.Windows.Forms.ToolTip toolTip8;
        private System.Windows.Forms.ToolTip toolTip9;
        private System.Windows.Forms.Button btn_loainl;
        private System.Windows.Forms.Button btn_tt;
    }
}