namespace ttcn
{
    partial class NV
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
            this.btntimkiem = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.msksdt = new System.Windows.Forms.MaskedTextBox();
            this.mskngaysinh = new System.Windows.Forms.MaskedTextBox();
            this.cbochinhanh = new System.Windows.Forms.ComboBox();
            this.cbochucvu = new System.Windows.Forms.ComboBox();
            this.cbogioitinh = new System.Windows.Forms.ComboBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.btndong = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.txtmanv = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgridnhanvien = new System.Windows.Forms.DataGridView();
            this.btnhuy = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip6 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip7 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip8 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip9 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridnhanvien)).BeginInit();
            this.SuspendLayout();
            // 
            // btntimkiem
            // 
            this.btntimkiem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btntimkiem.Location = new System.Drawing.Point(707, 617);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(105, 44);
            this.btntimkiem.TabIndex = 27;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = false;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label12.Location = new System.Drawing.Point(360, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(367, 36);
            this.label12.TabIndex = 26;
            this.label12.Text = "DANH MỤC NHÂN VIÊN";
            // 
            // msksdt
            // 
            this.msksdt.Location = new System.Drawing.Point(590, 116);
            this.msksdt.Mask = "(999) 000-0000";
            this.msksdt.Name = "msksdt";
            this.msksdt.Size = new System.Drawing.Size(128, 22);
            this.msksdt.TabIndex = 25;
            this.toolTip8.SetToolTip(this.msksdt, "Hãy điền vào trường này");
            this.msksdt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.msksdt_KeyUp);
            // 
            // mskngaysinh
            // 
            this.mskngaysinh.Location = new System.Drawing.Point(590, 201);
            this.mskngaysinh.Mask = "00/00/0000";
            this.mskngaysinh.Name = "mskngaysinh";
            this.mskngaysinh.Size = new System.Drawing.Size(128, 22);
            this.mskngaysinh.TabIndex = 24;
            this.toolTip9.SetToolTip(this.mskngaysinh, "Hãy điền vào trường này");
            this.mskngaysinh.ValidatingType = typeof(System.DateTime);
            // 
            // cbochinhanh
            // 
            this.cbochinhanh.FormattingEnabled = true;
            this.cbochinhanh.Location = new System.Drawing.Point(324, 119);
            this.cbochinhanh.Name = "cbochinhanh";
            this.cbochinhanh.Size = new System.Drawing.Size(131, 24);
            this.cbochinhanh.TabIndex = 21;
            this.toolTip5.SetToolTip(this.cbochinhanh, "Hãy chọn chi nhánh");
            this.cbochinhanh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbochinhanh_KeyUp);
            // 
            // cbochucvu
            // 
            this.cbochucvu.FormattingEnabled = true;
            this.cbochucvu.Location = new System.Drawing.Point(324, 45);
            this.cbochucvu.Name = "cbochucvu";
            this.cbochucvu.Size = new System.Drawing.Size(131, 24);
            this.cbochucvu.TabIndex = 20;
            this.toolTip4.SetToolTip(this.cbochucvu, "Hãy chọn chức vụ");
            this.cbochucvu.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbochucvu_KeyUp);
            // 
            // cbogioitinh
            // 
            this.cbogioitinh.FormattingEnabled = true;
            this.cbogioitinh.Location = new System.Drawing.Point(76, 201);
            this.cbogioitinh.Name = "cbogioitinh";
            this.cbogioitinh.Size = new System.Drawing.Size(131, 24);
            this.cbogioitinh.TabIndex = 19;
            this.toolTip3.SetToolTip(this.cbogioitinh, "Hãy chọn giới tính");
            this.cbogioitinh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbogioitinh_KeyUp);
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(324, 201);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(131, 22);
            this.txtemail.TabIndex = 18;
            this.toolTip6.SetToolTip(this.txtemail, "Hãy điền vào trường này");
            this.txtemail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtemail_KeyUp);
            // 
            // txtdiachi
            // 
            this.txtdiachi.Location = new System.Drawing.Point(590, 42);
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(128, 22);
            this.txtdiachi.TabIndex = 15;
            this.toolTip7.SetToolTip(this.txtdiachi, "Hãy điền vào trường này");
            this.txtdiachi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdiachi_KeyUp);
            // 
            // btndong
            // 
            this.btndong.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btndong.Location = new System.Drawing.Point(860, 617);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(75, 44);
            this.btndong.TabIndex = 25;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = false;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.msksdt);
            this.groupBox1.Controls.Add(this.mskngaysinh);
            this.groupBox1.Controls.Add(this.cbochinhanh);
            this.groupBox1.Controls.Add(this.cbochucvu);
            this.groupBox1.Controls.Add(this.cbogioitinh);
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.txtdiachi);
            this.groupBox1.Controls.Add(this.txthoten);
            this.groupBox1.Controls.Add(this.txtmanv);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(42, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(929, 242);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // txthoten
            // 
            this.txthoten.Location = new System.Drawing.Point(76, 119);
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(131, 22);
            this.txthoten.TabIndex = 13;
            this.toolTip2.SetToolTip(this.txthoten, "Hãy điền vào trường này");
            this.txthoten.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txthoten_KeyUp);
            // 
            // txtmanv
            // 
            this.txtmanv.Location = new System.Drawing.Point(76, 47);
            this.txtmanv.Name = "txtmanv";
            this.txtmanv.Size = new System.Drawing.Size(131, 22);
            this.txtmanv.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtmanv, "Hãy điền vào trường này");
            this.txtmanv.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtmanv_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(517, 207);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "Ngày sinh";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(253, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(517, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "SĐT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(517, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Chi nhánh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chức vụ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giới tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ và tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã NV";
            // 
            // btnluu
            // 
            this.btnluu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnluu.Location = new System.Drawing.Point(444, 617);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(75, 44);
            this.btnluu.TabIndex = 23;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = false;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnxoa.Location = new System.Drawing.Point(320, 617);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(75, 44);
            this.btnxoa.TabIndex = 22;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = false;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnsua.Location = new System.Drawing.Point(206, 617);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(75, 44);
            this.btnsua.TabIndex = 21;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = false;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnthem.Location = new System.Drawing.Point(87, 617);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(75, 44);
            this.btnthem.TabIndex = 20;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgridnhanvien);
            this.groupBox2.Location = new System.Drawing.Point(42, 366);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(929, 234);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách hiển thị";
            // 
            // dgridnhanvien
            // 
            this.dgridnhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridnhanvien.Location = new System.Drawing.Point(10, 32);
            this.dgridnhanvien.Name = "dgridnhanvien";
            this.dgridnhanvien.RowHeadersWidth = 51;
            this.dgridnhanvien.RowTemplate.Height = 24;
            this.dgridnhanvien.Size = new System.Drawing.Size(909, 196);
            this.dgridnhanvien.TabIndex = 0;
            this.dgridnhanvien.Click += new System.EventHandler(this.dgridnhanvien_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnhuy.Location = new System.Drawing.Point(573, 617);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(75, 44);
            this.btnhuy.TabIndex = 24;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = false;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // NV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 738);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnhuy);
            this.Name = "NV";
            this.Text = "NV";
            this.Load += new System.EventHandler(this.NV_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgridnhanvien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox msksdt;
        private System.Windows.Forms.MaskedTextBox mskngaysinh;
        private System.Windows.Forms.ComboBox cbochinhanh;
        private System.Windows.Forms.ComboBox cbochucvu;
        private System.Windows.Forms.ComboBox cbogioitinh;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.TextBox txtmanv;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgridnhanvien;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip5;
        private System.Windows.Forms.ToolTip toolTip6;
        private System.Windows.Forms.ToolTip toolTip7;
        private System.Windows.Forms.ToolTip toolTip8;
        private System.Windows.Forms.ToolTip toolTip9;
    }
}