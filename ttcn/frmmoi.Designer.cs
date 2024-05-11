namespace ttcn
{
    partial class frmmoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmoi));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("sản phẩm 1", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Sản phẩm 2", 0);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Sản phẩm 3", 0);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("sản phẩm 1", 0);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Sản phẩm 2", 0);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Sản phẩm 3", 0);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("sanpham1");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("sanpham2");
            this.imglistanhsp = new System.Windows.Forms.ImageList(this.components);
            this.listsanpham = new System.Windows.Forms.ListView();
            this.imglistloaisanpham = new System.Windows.Forms.ImageList(this.components);
            this.listloaisanpham = new System.Windows.Forms.ListView();
            this.tldDataSet1 = new ttcn.tldDataSet();
            this.listViewHienthi = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tldDataSet1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // imglistanhsp
            // 
            this.imglistanhsp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglistanhsp.ImageStream")));
            this.imglistanhsp.TransparentColor = System.Drawing.Color.Transparent;
            this.imglistanhsp.Images.SetKeyName(0, "borcelle (2).png");
            // 
            // listsanpham
            // 
            this.listsanpham.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listsanpham.BackgroundImageTiled = true;
            this.listsanpham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listsanpham.GridLines = true;
            this.listsanpham.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            this.listsanpham.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listsanpham.LargeImageList = this.imglistanhsp;
            this.listsanpham.Location = new System.Drawing.Point(0, 0);
            this.listsanpham.Name = "listsanpham";
            this.listsanpham.Size = new System.Drawing.Size(727, 422);
            this.listsanpham.SmallImageList = this.imglistanhsp;
            this.listsanpham.TabIndex = 3;
            this.listsanpham.UseCompatibleStateImageBehavior = false;
            this.listsanpham.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listsanpham.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listsanpham_MouseClick);
            this.listsanpham.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listsanpham_MouseDoubleClick);
            // 
            // imglistloaisanpham
            // 
            this.imglistloaisanpham.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglistloaisanpham.ImageStream")));
            this.imglistloaisanpham.TransparentColor = System.Drawing.Color.Transparent;
            this.imglistloaisanpham.Images.SetKeyName(0, "1981.Twist_Pink_Light-390w-844h@3x~iphone.jpeg");
            this.imglistloaisanpham.Images.SetKeyName(1, "1982.Twist_Pink_Dark-390w-844h@3x~iphone.jpeg");
            this.imglistloaisanpham.Images.SetKeyName(2, "1991.Twist_Blue_Light-390w-844h@3x~iphone.jpeg");
            this.imglistloaisanpham.Images.SetKeyName(3, "1992.Twist_Blue_Dark-390w-844h@3x~iphone.jpeg");
            this.imglistloaisanpham.Images.SetKeyName(4, "2001.Twist_Black_Light-390w-844h@3x~iphone.jpeg");
            this.imglistloaisanpham.Images.SetKeyName(5, "2002.Twist_Black_Dark-390w-844h@3x~iphone.jpeg");
            this.imglistloaisanpham.Images.SetKeyName(6, "2011.Twist_White_Light-390w-844h@3x~iphone.jpeg");
            this.imglistloaisanpham.Images.SetKeyName(7, "2012.Twist_White_Dark-390w-844h@3x~iphone.jpeg");
            this.imglistloaisanpham.Images.SetKeyName(8, "2021.Twist_Red_Light-390w-844h@3x~iphone.jpeg");
            this.imglistloaisanpham.Images.SetKeyName(9, "2022.Twist_Red_Dark-390w-844h@3x~iphone.jpeg");
            // 
            // listloaisanpham
            // 
            this.listloaisanpham.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listloaisanpham.BackgroundImageTiled = true;
            this.listloaisanpham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listloaisanpham.GridLines = true;
            this.listloaisanpham.HideSelection = false;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            this.listloaisanpham.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.listloaisanpham.LargeImageList = this.imglistloaisanpham;
            this.listloaisanpham.Location = new System.Drawing.Point(1, 417);
            this.listloaisanpham.Name = "listloaisanpham";
            this.listloaisanpham.Size = new System.Drawing.Size(727, 87);
            this.listloaisanpham.SmallImageList = this.imglistanhsp;
            this.listloaisanpham.TabIndex = 4;
            this.listloaisanpham.UseCompatibleStateImageBehavior = false;
            this.listloaisanpham.SelectedIndexChanged += new System.EventHandler(this.listloaisanpham_SelectedIndexChanged);
            // 
            // tldDataSet1
            // 
            this.tldDataSet1.DataSetName = "tldDataSet";
            this.tldDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listViewHienthi
            // 
            this.listViewHienthi.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listViewHienthi.BackgroundImageTiled = true;
            this.listViewHienthi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewHienthi.GridLines = true;
            this.listViewHienthi.HideSelection = false;
            this.listViewHienthi.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem7,
            listViewItem8});
            this.listViewHienthi.LargeImageList = this.imglistanhsp;
            this.listViewHienthi.Location = new System.Drawing.Point(0, 85);
            this.listViewHienthi.Name = "listViewHienthi";
            this.listViewHienthi.Size = new System.Drawing.Size(275, 337);
            this.listViewHienthi.SmallImageList = this.imglistanhsp;
            this.listViewHienthi.TabIndex = 5;
            this.listViewHienthi.UseCompatibleStateImageBehavior = false;
            this.listViewHienthi.View = System.Windows.Forms.View.Details;
            this.listViewHienthi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewHienthi_MouseClick);
            this.listViewHienthi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewHienthi_MouseDoubleClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(723, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 504);
            this.panel4.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.listViewHienthi);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(275, 504);
            this.panel5.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 10);
            this.panel1.TabIndex = 7;
            // 
            // frmphieunhapkho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 504);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.listloaisanpham);
            this.Controls.Add(this.listsanpham);
            this.Name = "frmphieunhapkho";
            this.Text = "frmphieunhapkho";
            this.Load += new System.EventHandler(this.frmphieunhapkho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tldDataSet1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imglistanhsp;
        private System.Windows.Forms.ListView listsanpham;
        private System.Windows.Forms.ImageList imglistloaisanpham;
        private System.Windows.Forms.ListView listloaisanpham;
        private tldDataSet tldDataSet1;
        private System.Windows.Forms.ListView listViewHienthi;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
    }
}