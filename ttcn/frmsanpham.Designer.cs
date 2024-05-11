namespace ttcn
{
    partial class frmsanpham
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
            this.btndong = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btninsert = new System.Windows.Forms.Button();
            this.sanPhamBindingSource = new System.Windows.Forms.BindingSource(this.components);
         //   this.tldDataSet = new ttcn.tldDataSet();
           // this.sanPhamTableAdapter = new ttcn.tldDataSetTableAdapters.SanPhamTableAdapter();
            this.txtmasp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtgia = new System.Windows.Forms.TextBox();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.txtchitietsanpham = new System.Windows.Forms.TextBox();
            this.dtgsanpham = new System.Windows.Forms.DataGridView();
            this.cbhang = new System.Windows.Forms.ComboBox();
            this.cbloai = new System.Windows.Forms.ComboBox();
            this.cbtinhtrang = new System.Windows.Forms.ComboBox();
            this.txttensanpham = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource)).BeginInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.tldDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgsanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // btndong
            // 
            this.btndong.Location = new System.Drawing.Point(654, 463);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(75, 23);
            this.btndong.TabIndex = 58;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.Location = new System.Drawing.Point(543, 463);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(75, 23);
            this.btnhuy.TabIndex = 57;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(417, 463);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(75, 23);
            this.btnluu.TabIndex = 56;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(291, 463);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(75, 23);
            this.btnxoa.TabIndex = 53;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(173, 463);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(75, 23);
            this.btnsua.TabIndex = 52;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btninsert
            // 
            this.btninsert.Location = new System.Drawing.Point(55, 463);
            this.btninsert.Name = "btninsert";
            this.btninsert.Size = new System.Drawing.Size(75, 23);
            this.btninsert.TabIndex = 51;
            this.btninsert.Text = "Thêm";
            this.btninsert.UseVisualStyleBackColor = true;
            this.btninsert.Click += new System.EventHandler(this.btninsert_Click);
            // 
            // sanPhamBindingSource
            // 
            this.sanPhamBindingSource.DataMember = "SanPham";
         //   this.sanPhamBindingSource.DataSource = this.tldDataSet;
            // 
            // tldDataSet
            // 
          //  this.tldDataSet.DataSetName = "tldDataSet";
            //this.tldDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sanPhamTableAdapter
            // 
        //    this.sanPhamTableAdapter.ClearBeforeFill = true;
            // 
            // txtmasp
            // 
            this.txtmasp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtmasp.Location = new System.Drawing.Point(338, 94);
            this.txtmasp.Multiline = true;
            this.txtmasp.Name = "txtmasp";
            this.txtmasp.Size = new System.Drawing.Size(125, 27);
            this.txtmasp.TabIndex = 33;
            this.txtmasp.Text = "Mã sản phẩm";
            this.txtmasp.TextChanged += new System.EventHandler(this.txtmasp_TextChanged);
            this.txtmasp.Leave += new System.EventHandler(this.txtmasp_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Tình trạng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Hãng sản xuất";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Phân loại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(288, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Giá";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(288, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Ghi chú";
            // 
            // txtgia
            // 
            this.txtgia.Location = new System.Drawing.Point(338, 147);
            this.txtgia.Name = "txtgia";
            this.txtgia.Size = new System.Drawing.Size(125, 20);
            this.txtgia.TabIndex = 47;
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(338, 191);
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtghichu.Size = new System.Drawing.Size(125, 66);
            this.txtghichu.TabIndex = 48;
            // 
            // txtchitietsanpham
            // 
            this.txtchitietsanpham.Location = new System.Drawing.Point(508, 65);
            this.txtchitietsanpham.Multiline = true;
            this.txtchitietsanpham.Name = "txtchitietsanpham";
            this.txtchitietsanpham.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtchitietsanpham.Size = new System.Drawing.Size(221, 371);
            this.txtchitietsanpham.TabIndex = 49;
            // 
            // dtgsanpham
            // 
            this.dtgsanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgsanpham.Location = new System.Drawing.Point(55, 275);
            this.dtgsanpham.Name = "dtgsanpham";
            this.dtgsanpham.Size = new System.Drawing.Size(408, 161);
            this.dtgsanpham.TabIndex = 50;
            this.dtgsanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgsanpham_CellClick);
            this.dtgsanpham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgsanpham_CellContentClick);
            // 
            // cbhang
            // 
            this.cbhang.FormattingEnabled = true;
            this.cbhang.Location = new System.Drawing.Point(148, 144);
            this.cbhang.Name = "cbhang";
            this.cbhang.Size = new System.Drawing.Size(100, 21);
            this.cbhang.TabIndex = 59;
            // 
            // cbloai
            // 
            this.cbloai.FormattingEnabled = true;
            this.cbloai.Location = new System.Drawing.Point(148, 192);
            this.cbloai.Name = "cbloai";
            this.cbloai.Size = new System.Drawing.Size(100, 21);
            this.cbloai.TabIndex = 60;
            // 
            // cbtinhtrang
            // 
            this.cbtinhtrang.FormattingEnabled = true;
            this.cbtinhtrang.Location = new System.Drawing.Point(148, 236);
            this.cbtinhtrang.Name = "cbtinhtrang";
            this.cbtinhtrang.Size = new System.Drawing.Size(100, 21);
            this.cbtinhtrang.TabIndex = 61;
            // 
            // txttensanpham
            // 
            this.txttensanpham.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txttensanpham.Location = new System.Drawing.Point(55, 94);
            this.txttensanpham.Multiline = true;
            this.txttensanpham.Name = "txttensanpham";
            this.txttensanpham.Size = new System.Drawing.Size(256, 27);
            this.txttensanpham.TabIndex = 62;
            this.txttensanpham.Text = "Tên sản phẩm";
            this.txttensanpham.TextChanged += new System.EventHandler(this.txttensanpham_TextChanged);
            this.txttensanpham.Enter += new System.EventHandler(this.txttensanpham_Enter);
            this.txttensanpham.Leave += new System.EventHandler(this.txttensanpham_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Thông số kỹ thuật";
            // 
            // txttimkiem
            // 
            this.txttimkiem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txttimkiem.Location = new System.Drawing.Point(55, 42);
            this.txttimkiem.Multiline = true;
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(327, 27);
            this.txttimkiem.TabIndex = 64;
            this.txttimkiem.Text = "Nhập từ khóa để tìm kiếm";
            this.txttimkiem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txttimkiem_MouseClick);
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            this.txttimkiem.Enter += new System.EventHandler(this.txttimkiem_Enter);
            this.txttimkiem.Leave += new System.EventHandler(this.txttimkiem_Leave);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(388, 42);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(75, 27);
            this.btntimkiem.TabIndex = 65;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(743, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 72);
            this.button1.TabIndex = 66;
            this.button1.Text = "Loại sản phẩm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(743, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 72);
            this.button2.TabIndex = 67;
            this.button2.Text = "Hãng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(743, 364);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 72);
            this.button3.TabIndex = 68;
            this.button3.Text = "Tình trạng";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmsanpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 509);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.txttimkiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttensanpham);
            this.Controls.Add(this.cbtinhtrang);
            this.Controls.Add(this.cbloai);
            this.Controls.Add(this.cbhang);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btninsert);
            this.Controls.Add(this.dtgsanpham);
            this.Controls.Add(this.txtchitietsanpham);
            this.Controls.Add(this.txtghichu);
            this.Controls.Add(this.txtgia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtmasp);
            this.Name = "frmsanpham";
            this.Text = "Sản phẩm";
            this.Load += new System.EventHandler(this.frmsanpham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource)).EndInit();
          //  ((System.ComponentModel.ISupportInitialize)(this.tldDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgsanpham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btninsert;
      //  private tldDataSet tldDataSet;
        private System.Windows.Forms.BindingSource sanPhamBindingSource;
      //  private tldDataSetTableAdapters.SanPhamTableAdapter sanPhamTableAdapter;
        private System.Windows.Forms.TextBox txtmasp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtgia;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.TextBox txtchitietsanpham;
        private System.Windows.Forms.DataGridView dtgsanpham;
        private System.Windows.Forms.ComboBox cbhang;
        private System.Windows.Forms.ComboBox cbloai;
        private System.Windows.Forms.ComboBox cbtinhtrang;
        private System.Windows.Forms.TextBox txttensanpham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}