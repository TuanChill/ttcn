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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.exitApp = new ttcn.RJButton();
            this.rjButton1 = new ttcn.RJButton();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 199);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Tài khoản";
            // 
            // userName
            // 
            this.userName.Cursor = System.Windows.Forms.Cursors.No;
            this.userName.Location = new System.Drawing.Point(174, 199);
            this.userName.Margin = new System.Windows.Forms.Padding(4);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(179, 22);
            this.userName.TabIndex = 3;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(174, 263);
            this.Password.Margin = new System.Windows.Forms.Padding(4);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(179, 22);
            this.Password.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 267);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 46);
            this.label3.TabIndex = 6;
            this.label3.Text = "Wellcome";
            // 
            // togglePassword
            // 
            this.togglePassword.AutoSize = true;
            this.togglePassword.Location = new System.Drawing.Point(174, 325);
            this.togglePassword.Margin = new System.Windows.Forms.Padding(4);
            this.togglePassword.Name = "togglePassword";
            this.togglePassword.Size = new System.Drawing.Size(130, 20);
            this.togglePassword.TabIndex = 7;
            this.togglePassword.Text = "Hiển thị mật khẩu";
            this.togglePassword.UseVisualStyleBackColor = true;
            this.togglePassword.Click += new System.EventHandler(this.togglePassword_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackgroundImage = global::ttcn.Properties.Resources.nguyelieugo_ENCX;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(396, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(425, 497);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // exitApp
            // 
            this.exitApp.BackColor = System.Drawing.Color.MediumTurquoise;
            this.exitApp.FlatAppearance.BorderSize = 0;
            this.exitApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitApp.ForeColor = System.Drawing.Color.Black;
            this.exitApp.Location = new System.Drawing.Point(207, 374);
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
            this.rjButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(27, 374);
            this.rjButton1.Margin = new System.Windows.Forms.Padding(4);
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
            this.ClientSize = new System.Drawing.Size(822, 497);
            this.Controls.Add(this.flowLayoutPanel1);
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}