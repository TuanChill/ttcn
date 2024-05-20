namespace ttcn
{
    partial class DangNhap
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
            this.label2 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.togglePassword = new System.Windows.Forms.CheckBox();
            this.pic_avt = new System.Windows.Forms.PictureBox();
            this.exitApp = new ttcn.RJButton();
            this.rjButton1 = new ttcn.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pic_avt)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(301, 399);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên tài khoản";
            // 
            // userName
            // 
            this.userName.Cursor = System.Windows.Forms.Cursors.No;
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(452, 399);
            this.userName.Margin = new System.Windows.Forms.Padding(4);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(179, 27);
            this.userName.TabIndex = 3;
            this.userName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.userName_KeyUp);
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(452, 463);
            this.Password.Margin = new System.Windows.Forms.Padding(4);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(179, 27);
            this.Password.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 467);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(256, 274);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(504, 46);
            this.label3.TabIndex = 6;
            this.label3.Text = "WELCOME TO TIN PHAT";
            // 
            // togglePassword
            // 
            this.togglePassword.AutoSize = true;
            this.togglePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.togglePassword.Location = new System.Drawing.Point(452, 522);
            this.togglePassword.Margin = new System.Windows.Forms.Padding(4);
            this.togglePassword.Name = "togglePassword";
            this.togglePassword.Size = new System.Drawing.Size(162, 24);
            this.togglePassword.TabIndex = 7;
            this.togglePassword.Text = "Hiển thị mật khẩu";
            this.togglePassword.UseVisualStyleBackColor = true;
            this.togglePassword.Click += new System.EventHandler(this.togglePassword_Click);
            // 
            // pic_avt
            // 
            this.pic_avt.Image = global::ttcn.Properties.Resources.avttinphat;
            this.pic_avt.Location = new System.Drawing.Point(399, 54);
            this.pic_avt.Name = "pic_avt";
            this.pic_avt.Size = new System.Drawing.Size(215, 188);
            this.pic_avt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_avt.TabIndex = 9;
            this.pic_avt.TabStop = false;
            // 
            // exitApp
            // 
            this.exitApp.BackColor = System.Drawing.Color.MediumTurquoise;
            this.exitApp.FlatAppearance.BorderSize = 0;
            this.exitApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitApp.ForeColor = System.Drawing.Color.Black;
            this.exitApp.Location = new System.Drawing.Point(485, 595);
            this.exitApp.Margin = new System.Windows.Forms.Padding(4);
            this.exitApp.Name = "exitApp";
            this.exitApp.Size = new System.Drawing.Size(146, 44);
            this.exitApp.TabIndex = 8;
            this.exitApp.Text = "Thoát";
            this.exitApp.UseVisualStyleBackColor = false;
            this.exitApp.Click += new System.EventHandler(this.exitApp_Click_1);
            // 
            // rjButton1
            // 
            this.rjButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rjButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(305, 595);
            this.rjButton1.Margin = new System.Windows.Forms.Padding(4);
            this.rjButton1.MaximumSize = new System.Drawing.Size(147, 44);
            this.rjButton1.MinimumSize = new System.Drawing.Size(147, 44);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(147, 44);
            this.rjButton1.TabIndex = 0;
            this.rjButton1.Text = "Đăng nhập";
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(967, 707);
            this.Controls.Add(this.pic_avt);
            this.Controls.Add(this.exitApp);
            this.Controls.Add(this.togglePassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rjButton1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DangNhap";
            this.Text = "DangNhap";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_avt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RJButton rjButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox togglePassword;
        private RJButton exitApp;
        private System.Windows.Forms.PictureBox pic_avt;
    }
}