using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ttcn.Class;

namespace ttcn
{
    public partial class frmmoi : Form
    {
        public frmmoi()
        {
            InitializeComponent();
            listViewHienthi.MouseClick += listViewHienthi_MouseClick;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmphieunhapkho_Load(object sender, EventArgs e)
        {
            // Kết nối tới cơ sở dữ liệu
            Class.Functions.Ketnoi();
            SqlConnection conn = Functions.Conn;
            Loadlistsp();
            Loadlistloaisp();
            // Đặt độ rộng các cột sau khi ListView đã được hiển thị
            listloaisanpham.Columns[0].Width = 200;
            // Đặt độ rộng các cột khác nếu cần
            // Tạo cột "Số lượng"
            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Số lượng";
            columnHeader1.Width = 100;

            // Tạo cột "Sản phẩm"
            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Sản phẩm";
            columnHeader2.Width = 200;

            // Thêm các cột vào listViewHienthi
            listViewHienthi.Columns.Add(columnHeader2);
            listViewHienthi.Columns.Add(columnHeader1);
            listViewHienthi.Items.Clear();
        }
        private void Loadlistsp()
        {
            // Lấy tên loại sản phẩm đầu tiên
            string sqlTenLoaiSP = "SELECT TOP 1 c.tenloaisp FROM dbo.sanpham a JOIN dbo.tinhtrang b ON a.matinhtrang = b.matinhtrang JOIN dbo.LoaiSanPham c ON a.MaLoaiSP = c.MaLoaiSP JOIN dbo.Hang d ON a.MaHang = d.MaHang";
            string tenLoaiSP = Class.Functions.getfilevalue(sqlTenLoaiSP);

            // Lấy danh sách sản phẩm tương ứng với loại sản phẩm
            string sqlSanPham = "SELECT a.TenSP FROM dbo.sanpham a JOIN dbo.tinhtrang b ON a.matinhtrang = b.matinhtrang JOIN dbo.LoaiSanPham c ON a.MaLoaiSP = c.MaLoaiSP JOIN dbo.Hang d ON a.MaHang = d.MaHang WHERE c.tenloaisp = N'" + tenLoaiSP + "'";
            DataTable dataTableSanPham = Class.Functions.GetdataToTable(sqlSanPham);

            // Xóa dữ liệu cũ trong ListView
            listsanpham.Items.Clear();

            // Gán ImageList cho ListView
            listsanpham.SmallImageList = imglistanhsp;

            // Duyệt qua từng dòng dữ liệu trong DataTable
            foreach (DataRow row in dataTableSanPham.Rows)
            {
                string tenSP = row["TenSP"].ToString();

                // Tạo ListViewItem và thêm vào ListView
                ListViewItem item = new ListViewItem(tenSP);
                item.ImageIndex = 0; // Chỉ số của ảnh trong ImageList
                listsanpham.Items.Add(item);
            }
        }
        private void Loadlistloaisp()
        {
            // Tạo truy vấn SQL để lấy dữ liệu từ CSDL
            string sql = "SELECT distinct c.tenloaisp FROM dbo.sanpham a JOIN dbo.tinhtrang b ON a.matinhtrang = b.matinhtrang JOIN dbo.LoaiSanPham c ON a.MaLoaiSP = c.MaLoaiSP JOIN dbo.Hang d ON a.MaHang = d.MaHang";

            // Lấy dữ liệu từ CSDL và gán vào DataTable
            DataTable dataTable = Class.Functions.GetdataToTable(sql);

            // Xóa dữ liệu cũ trong ListView
            listloaisanpham.Items.Clear();

            // Gán ImageList cho ListView
            listloaisanpham.SmallImageList = imglistloaisanpham;

            // Tạo và cấu hình cột trong ListView
            listloaisanpham.Columns.Clear();
            listloaisanpham.Columns.Add("Loại sản phẩm", 200); // Tạo cột với độ rộng là 200 pixels

            // Duyệt qua từng dòng dữ liệu trong DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                string tenloaiSP = row["tenloaisp"].ToString();

                // Tạo ListViewItem và thêm vào ListView
                ListViewItem item = new ListViewItem(tenloaiSP);
                item.ImageIndex = 0; // Chỉ số của ảnh trong ImageList
                
                listloaisanpham.Items.Add(item);
            }

            // Tự động điều chỉnh độ rộng cột dựa trên nội dung
            listloaisanpham.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listsanpham.SelectedItems.Count > 0)
            {
                // Lấy tên sản phẩm được chọn
                string selectedSanPham = listsanpham.SelectedItems[0].Text;

                // Thêm dòng dữ liệu vào listBoxhienthi
                
            }

            
            
        }

        private void listloaisanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listloaisanpham.SelectedItems.Count > 0)
            {
                // Lấy tên loại sản phẩm được chọn
                string selectedLoaiSP = listloaisanpham.SelectedItems[0].Text;

                // Tạo truy vấn SQL để lấy danh sách sản phẩm với điều kiện tên loại sản phẩm
                string sqlSanPham = "SELECT a.TenSP FROM dbo.sanpham a JOIN dbo.tinhtrang b ON a.matinhtrang = b.matinhtrang JOIN dbo.LoaiSanPham c ON a.MaLoaiSP = c.MaLoaiSP JOIN dbo.Hang d ON a.MaHang = d.MaHang WHERE c.tenloaisp = N'" + selectedLoaiSP + "'";

                // Lấy dữ liệu từ CSDL và gán vào DataTable
                DataTable dataTableSanPham = Class.Functions.GetdataToTable(sqlSanPham);

                // Xóa dữ liệu cũ trong ListView
                listsanpham.Items.Clear();

                // Gán ImageList cho ListView
                listsanpham.SmallImageList = imglistanhsp;

                // Duyệt qua từng dòng dữ liệu trong DataTable
                foreach (DataRow row in dataTableSanPham.Rows)
                {
                    string tenSP = row["TenSP"].ToString();

                    // Tạo ListViewItem và thêm vào ListView
                    ListViewItem item = new ListViewItem(tenSP);
                    item.ImageIndex = 0; // Chỉ số của ảnh trong ImageList
                    listsanpham.Items.Add(item);
                }
            }
        }

        private void listsanpham_MouseClick(object sender, MouseEventArgs e)
        {
            if (listsanpham.SelectedItems.Count > 0)
            {
                string selectedSanPham = listsanpham.SelectedItems[0].Text;

                // Kiểm tra xem sản phẩm đã tồn tại trong listViewHienthi hay chưa
                bool exists = false;
                foreach (ListViewItem item in listViewHienthi.Items)
                {
                    if (item.SubItems[0].Text == selectedSanPham)
                    {
                        exists = true;

                        // Tìm ô số lượng tương ứng và tăng giá trị số lượng
                        int currentQuantity;
                        if (int.TryParse(item.SubItems[1].Text, out currentQuantity))
                        {
                            currentQuantity++;
                            item.SubItems[1].Text = currentQuantity.ToString();
                            break;
                        }
                    }
                }

                // Nếu sản phẩm chưa tồn tại, thêm một dòng mới vào listViewHienthi
                if (!exists)
                {
                    ListViewItem newItem = new ListViewItem();
                    newItem.Text = selectedSanPham;
                    newItem.SubItems.Add("1");
                    listViewHienthi.Items.Add(newItem);
                }
            }
        }

        private void TextBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxQuantity = (TextBox)sender;
            ListViewItem.ListViewSubItem subItem = (ListViewItem.ListViewSubItem)textBoxQuantity.Tag;
            int quantity;
            if (int.TryParse(textBoxQuantity.Text, out quantity))
            {
                // Cập nhật số lượng trong ListView
                subItem.Text = quantity.ToString();
            }
            else
            {
                // Nếu người dùng nhập không hợp lệ, đặt lại giá trị số lượng từ ListView
                textBoxQuantity.Text = subItem.Text;
            }
        }
        private void TextBoxQuantity_LostFocus(object sender, EventArgs e)
        {
            TextBox textBoxQuantity = (TextBox)sender;
            if (textBoxQuantity.Tag is ListViewItem.ListViewSubItem subItem)
            {
                int quantity;
                if (int.TryParse(textBoxQuantity.Text, out quantity))
                {
                    // Cập nhật số lượng trong ListView
                    subItem.Text = quantity.ToString();
                }
                else
                {
                    // Nếu người dùng nhập không hợp lệ, đặt lại giá trị số lượng từ ListView
                    textBoxQuantity.Text = subItem.Text;
                }
                listViewHienthi.Controls.Remove(textBoxQuantity);
                textBoxQuantity.Dispose();
            }
        }

        private void listsanpham_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
        }

        private void listViewHienthi_MouseClick(object sender, MouseEventArgs e)
        {
            /*ListViewHitTestInfo hit = listViewHienthi.HitTest(e.Location);
            ListViewItem item = hit.Item;
            int columnIndex = hit.Item.SubItems.IndexOf(hit.SubItem);

            if (item != null && columnIndex == 1)
            {
                Rectangle subItemBounds = item.SubItems[columnIndex].Bounds;
                TextBox textBoxQuantity = new TextBox();
                textBoxQuantity.Text = item.SubItems[columnIndex].Text;
                textBoxQuantity.Bounds = subItemBounds;
                textBoxQuantity.TextChanged += TextBoxQuantity_TextChanged;
                listViewHienthi.Controls.Add(textBoxQuantity);
                textBoxQuantity.Focus();
                textBoxQuantity.Tag = item;
            }*/
            ListViewItem item = listViewHienthi.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                int columnIndex = 1; // Chỉnh lại chỉ số cột tương ứng với số lượng
                Rectangle subItemBounds = item.SubItems[columnIndex].Bounds;
                TextBox textBoxQuantity = new TextBox();
                textBoxQuantity.Text = item.SubItems[columnIndex].Text;
                textBoxQuantity.Bounds = subItemBounds;
                textBoxQuantity.TextChanged += TextBoxQuantity_TextChanged;
                textBoxQuantity.LostFocus += TextBoxQuantity_LostFocus;
                listViewHienthi.Controls.Add(textBoxQuantity);
                textBoxQuantity.Focus();
                textBoxQuantity.Tag = item.SubItems[columnIndex];
            }
        }

        private void listViewHienthi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           /* ListViewHitTestInfo hit = listViewHienthi.HitTest(e.Location);
            ListViewItem item = hit.Item;
            int columnIndex = hit.Item.SubItems.IndexOf(hit.SubItem);

            if (item != null && columnIndex == 1)
            {
                Rectangle subItemBounds = item.SubItems[columnIndex].Bounds;
                TextBox textBoxQuantity = new TextBox();
                textBoxQuantity.Text = item.SubItems[columnIndex].Text;
                textBoxQuantity.Bounds = subItemBounds;
                textBoxQuantity.TextChanged += TextBoxQuantity_TextChanged;
                listViewHienthi.Controls.Add(textBoxQuantity);
                textBoxQuantity.Focus();
                textBoxQuantity.Tag = item.SubItems[columnIndex];
            }*/
        }
    }
}
