﻿namespace ttcn
{
    partial class frmdanhsach
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
            this.paneldanhsach = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panelhienthi = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelshow = new System.Windows.Forms.Panel();
            this.paneldanhsach.SuspendLayout();
            this.SuspendLayout();
            // 
            // paneldanhsach
            // 
            this.paneldanhsach.Controls.Add(this.button5);
            this.paneldanhsach.Controls.Add(this.button4);
            this.paneldanhsach.Controls.Add(this.panelhienthi);
            this.paneldanhsach.Controls.Add(this.button2);
            this.paneldanhsach.Controls.Add(this.button1);
            this.paneldanhsach.Location = new System.Drawing.Point(1, 0);
            this.paneldanhsach.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.paneldanhsach.Name = "paneldanhsach";
            this.paneldanhsach.Size = new System.Drawing.Size(1212, 52);
            this.paneldanhsach.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(486, 0);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(221, 52);
            this.button5.TabIndex = 5;
            this.button5.Text = "Đơn hàng";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(705, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(228, 52);
            this.button4.TabIndex = 4;
            this.button4.Text = "Mục tiêu nhập, xuất";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panelhienthi
            // 
            this.panelhienthi.Location = new System.Drawing.Point(0, 59);
            this.panelhienthi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelhienthi.Name = "panelhienthi";
            this.panelhienthi.Size = new System.Drawing.Size(1164, 554);
            this.panelhienthi.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(232, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(256, 52);
            this.button2.TabIndex = 2;
            this.button2.Text = "Phiếu xuất kho";
            this.button2.UseVisualStyleBackColor = true;
      //      this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Phiếu nhập kho";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelshow
            // 
            this.panelshow.Location = new System.Drawing.Point(1, 59);
            this.panelshow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelshow.Name = "panelshow";
            this.panelshow.Size = new System.Drawing.Size(933, 585);
            this.panelshow.TabIndex = 1;
            // 
            // frmdanhsach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 657);
            this.Controls.Add(this.panelshow);
            this.Controls.Add(this.paneldanhsach);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmdanhsach";
            this.Text = "Tạo phiếu";
            this.Load += new System.EventHandler(this.frmdanhsach_Load);
            this.paneldanhsach.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paneldanhsach;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelhienthi;
        private System.Windows.Forms.Panel panelshow;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}