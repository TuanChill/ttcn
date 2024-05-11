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
    public partial class frmdondathang : Form
    {
        public frmdondathang()
        {
            InitializeComponent();
        }

        private void lblMaHang_Click(object sender, EventArgs e)
        {

        }

        private void txtmasp_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMaHDban_Click(object sender, EventArgs e)
        {

        }

        private void frmdondathang_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();
            SqlConnection conn = Functions.Conn;
            btnload();
            string sql = "SELECT MaNV, HoTenNV FROM NhanVien where hoatdong = 1";
            Functions.Fillcombo(sql, cbonv, "MaNV", "HoTenNV");
            string sql1 = "SELECT MaSP, TenSP FROM SanPham where matinhtrang <> 3";
            Functions.Fillcombo(sql1, cbtensp, "MaSP", "TenSP");
            string sql2 = "SELECT MaNCC, TenNCC FROM NhaCungCap";
            Functions.Fillcombo(sql2, cboncc, "MaNCC", "TenNCC");
            txtsl.Text = "0";
            dataload();
        }
        private void btnload()
        {
            btnIn.Enabled = false;
            btnHuy.Enabled = false;
            btnthemsanpham.Enabled = false;
            btntaophieu.Enabled = false;
        }
        private void btnload1()
        {
            btnIn.Enabled = true;
            btnHuy.Enabled = true;
            btnthemsanpham.Enabled = true;
            btntaophieu.Enabled = true;
        }
        private void dataload()
        {
            string sql = "SELECT a.MaDon, b.HoTenNV,  a.NgayTao, c.Tenncc FROM  Dondathang a  JOIN NhanVien b ON a.MaNV = b.MaNV join nhacungcap c on a.mancc = c.mancc order by a.madon desc ";


            // Lấy dữ liệu từ CSDL và gán vào DataTable
            DataTable dataTable = Functions.GetdataToTable(sql);

            // Gán DataTable cho DataGridView để hiển thị dữ liệu
            dtgdondat.DataSource = dataTable;

            // Đặt lại tiêu đề cho các cột
            dtgdondat.Columns[0].HeaderText = "Mã đơn";
            dtgdondat.Columns[1].HeaderText = "Tên nhân viên";
            dtgdondat.Columns[2].HeaderText = "Ngày tạo";
            dtgdondat.Columns[3].HeaderText = "Đơn vị cung cấp";

            

            // Đặt lại độ rộng cho các cột
            dtgdondat.Columns[0].Width = 120;
            dtgdondat.Columns[1].Width = 150;
            dtgdondat.Columns[2].Width = 150;
            dtgdondat.Columns[3].Width = 100;
            


            
            string sql1 = "select a.madon, d.tensp, b.soluong    from dondathang a join chitietdondathang b on a.madon = b.madon  join sanpham d on b.masp = d.masp order by a.madon desc";
            DataTable data = Functions.GetdataToTable(sql1);
            dtgchitiet.DataSource = data;
            dtgchitiet.Columns[0].HeaderText = "Mã đơn";
            
            
            dtgchitiet.Columns[1].HeaderText = "Sản phẩm";
            dtgchitiet.Columns[2].HeaderText = "Số lượng";
            
            // Thiết lập chế độ tự động điều chỉnh độ rộng của các cột
            dtgchitiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Thiết lập tỷ lệ phần trăm cho từng cột
            dtgchitiet.Columns[0].FillWeight = 30;   // 20%
            dtgchitiet.Columns[1].FillWeight = 50;   // 30%
            dtgchitiet.Columns[2].FillWeight = 20;   // 15%
               
        }

        private void cbtensp_SelectedValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị mã sản phẩm từ ComboBox
            string maSanPham = cbtensp.SelectedValue.ToString();

            // Gán giá trị mã sản phẩm vào TextBox
            txtmasp.Text = maSanPham;
        }

        private void cboncc_SelectedValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị mã sản phẩm từ ComboBox
            string mancc = cboncc.SelectedValue.ToString();

            // Gán giá trị mã sản phẩm vào TextBox
            txtmancc.Text = mancc;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnthemsanpham.Enabled = true;
            btntaophieu.Enabled = true;
            btnIn.Enabled = false;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            string madon = "DH" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // Gán mã phiếu nhập vào TextBox
            txtMadon.Text = madon;
            cbonv.Focus();
            Loaddata();
        }
        private void Loaddata()
        {
            string sql = "SELECT a.MaDon, b.HoTenNV,  a.NgayTao, c.Tenncc FROM  Dondathang a  JOIN NhanVien b ON a.MaNV = b.MaNV join nhacungcap c on a.mancc = c.mancc order by a.madon desc ";


            // Lấy dữ liệu từ CSDL và gán vào DataTable
            DataTable dataTable = Functions.GetdataToTable(sql);

            // Gán DataTable cho DataGridView để hiển thị dữ liệu
            dtgdondat.DataSource = dataTable;

            // Đặt lại tiêu đề cho các cột
            dtgdondat.Columns[0].HeaderText = "Mã đơn";
            dtgdondat.Columns[1].HeaderText = "Tên nhân viên";
            dtgdondat.Columns[2].HeaderText = "Ngày tạo";
            dtgdondat.Columns[3].HeaderText = "Đơn vị cung cấp";



            // Đặt lại độ rộng cho các cột
            dtgdondat.Columns[0].Width = 120;
            dtgdondat.Columns[1].Width = 150;
            dtgdondat.Columns[2].Width = 150;
            dtgdondat.Columns[3].Width = 100;




            string sql1 = "select a.madon, d.tensp, b.soluong    from dondathangtam a join chitietdondathangtam b on a.madon = b.madon  join sanpham d on b.masp = d.masp order by a.madon desc";
            DataTable data = Functions.GetdataToTable(sql1);
            dtgchitiet.DataSource = data;
            dtgchitiet.Columns[0].HeaderText = "Mã đơn";


            dtgchitiet.Columns[1].HeaderText = "Sản phẩm";
            dtgchitiet.Columns[2].HeaderText = "Số lượng";

            // Thiết lập chế độ tự động điều chỉnh độ rộng của các cột
            dtgchitiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Thiết lập tỷ lệ phần trăm cho từng cột
            dtgchitiet.Columns[0].FillWeight = 30;   // 20%
            dtgchitiet.Columns[1].FillWeight = 50;   // 30%
            dtgchitiet.Columns[2].FillWeight = 20;   // 15%
        }

        private void btnthemsanpham_Click(object sender, EventArgs e)
        {

            string sqlCheck = "SELECT * FROM dondathangtam WHERE Madon = N'" + txtMadon.Text.Trim() + "'";
            System.Data.DataTable dt = Functions.GetdataToTable(sqlCheck);

            if (dt.Rows.Count > 0)
            {

                // Mã phiếu nhập đã tồn tại
                // Kiểm tra mã sản phẩm trong bảng chitietdondathangtam
                string sqlCheckSP = "SELECT * FROM chitietdondathangtam WHERE Madon = N'" + txtMadon.Text.Trim() + "' AND MaSP = '" + txtmasp.Text.Trim() + "'";
                System.Data.DataTable dtSP = Functions.GetdataToTable(sqlCheckSP);

                if (dtSP.Rows.Count > 0)
                {
                    // Mã sản phẩm đã tồn tại trong chitietdondathangtam
                    // Thực hiện cập nhật số lượng và thành tiền
                    string sqlUpdate = "UPDATE chitietdondathangtam SET SoLuong = SoLuong + " + txtsl.Text.Trim() + " WHERE Madon = N'" + txtMadon.Text.Trim() + "' AND MaSP = '" + txtmasp.Text.Trim() + "'";
                    Functions.RunSQL(sqlUpdate);
                }
                else
                {
                    // Mã sản phẩm chưa tồn tại trong chitietdondathangtam
                    // Thực hiện chèn mới
                    string sql = "INSERT INTO chitietdondathangtam (Madon, MaSP, SoLuong) VALUES (" +
                        "N'" + txtMadon.Text.Trim() + "'," +
                        "'" + txtmasp.Text.Trim() + "'," +
                        "'" + txtsl.Text.Trim() + "')";
                    Functions.RunSQL(sql);
                }
            }
            else
            {
                int maNV = Convert.ToInt32(cbonv.SelectedValue);
                int maNCC = Convert.ToInt32(cboncc.SelectedValue);
                

                string sqldondat = "INSERT INTO dondathangtam (Madon, MaNV, MaNCC) VALUES (" +
                    "N'" + txtMadon.Text.Trim() + "'," +
                    "'" + maNV + "'," +
                    "'" + maNCC + "')";
                Functions.RunSQL(sqldondat);

                string sql = "INSERT INTO chitietdondathangtam (Madon, MaSP, SoLuong) VALUES (" +
                    "N'" + txtMadon.Text.Trim() + "'," +
                    "'" + txtmasp.Text.Trim() + "'," +
                    "'" + txtsl.Text.Trim() + "')";
                Functions.RunSQL(sql);
            }
            Loaddata();
        }
        

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu trong bảng chitietdondathangtam
            string sqlDeleteChiTiet = "DELETE FROM chitietdondathangtam ";
            Functions.RunSQL(sqlDeleteChiTiet);

            // Xóa dữ liệu trong bảng dondathangtam
            string sqlDeletedondathang = "DELETE FROM dondathangtam";
            Functions.RunSQL(sqlDeletedondathang);

            // Xóa dữ liệu trong các TextBox và ComboBox
            loadbuton();

            // Cập nhật trạng thái hoặc hiển thị thông báo hủy thành công (tuỳ theo yêu cầu)
            Loaddata();
        }

        private void btntaophieu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem phiếu nhập tạm có tồn tại không
            string sqlCheck = "SELECT * FROM dondathangtam WHERE MaDon = N'" + txtMadon.Text.Trim() + "'";
            System.Data.DataTable dt = Functions.GetdataToTable(sqlCheck);

            if (dt.Rows.Count > 0)
            {
                // Sao chép dữ liệu từ bảng dondathangtam sang bảng dondathang
                string sqlCopydondathang = "INSERT INTO dondathang (MaDon, MaNV, MaNCC) " +
                    "SELECT MaDon, MaNV, MaNCC FROM dondathangtam";
                Functions.RunSQL(sqlCopydondathang);

                // Sao chép dữ liệu từ bảng ChiTietdondathangtam sang bảng ChiTietdondathang
                string sqlCopyChiTietdondathang = "INSERT INTO ChiTietdondathang (MaDon, MaSP, SoLuong) " +
                    "SELECT MaDon, MaSP, SoLuong FROM ChiTietdondathangtam";
                Functions.RunSQL(sqlCopyChiTietdondathang);

                
                // Xóa dữ liệu trong bảng ChiTietdondathangtam
                string sqlDeleteChiTietdondathangtam = "DELETE FROM ChiTietdondathangtam ";
                Functions.RunSQL(sqlDeleteChiTietdondathangtam);

                // Xóa dữ liệu trong bảng dondathangtam
                string sqlDeletedondathangtam = "DELETE FROM dondathangtam";
                Functions.RunSQL(sqlDeletedondathangtam);



                MessageBox.Show("Tạo phiếu thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy phiếu nhập tạm có mã " + txtMadon.Text.Trim() + "");
            }
            dataload();
            loadbuton();
        }
        private void loadbuton()
        {
            btnThem.Enabled = true;
            btnIn.Enabled = false;
            btnHuy.Enabled = false;

        }

        private void dtgdondat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgchitiet_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(btnThem.Enabled == false)
            {
                // Kiểm tra chỉ số hàng hợp lệ và không phải hàng tiêu đề
                if (e.RowIndex >= 0 && e.RowIndex < dtgdondat.Rows.Count - 1)
                {
                    DataGridViewRow selectedRow = dtgdondat.Rows[e.RowIndex];

                    // Lấy giá trị của cột Mã đơn
                    string maDon = selectedRow.Cells["MaDon"].Value.ToString();
                    

                    // Thực hiện xóa dòng trong CSDL và trong DataGridView
                    string sql = "delete from chitietdondattam WHERE MaDon = '" + maDon + "'";
                    Functions.RunSQL(sql);
                    
                    Loaddata();
                }
            }
            else
            {
                // Kiểm tra chỉ số hàng hợp lệ và không phải hàng tiêu đề
                if (e.RowIndex >= 0 && e.RowIndex < dtgdondat.Rows.Count - 1)
                {
                    DataGridViewRow selectedRow = dtgdondat.Rows[e.RowIndex];

                    // Lấy giá trị của cột Mã đơn
                    string maDon = selectedRow.Cells["MaDon"].Value.ToString();

                    // Thực hiện xóa dòng trong CSDL và trong DataGridView
                    string sql = "delete from chitietdondathang WHERE MaDon = '" + maDon + "' and masp = '"+txtmasp.Text.Trim()+"'";
                    Functions.RunSQL(sql);
                    dataload();
                    
                }
            }
            
        }

        private void dtgdondat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMadon.Text = dtgdondat.CurrentRow.Cells[0].Value.ToString();
            cbonv.Text = dtgdondat.CurrentRow.Cells[1].Value.ToString();
            dtngaytao.Text = dtgdondat.CurrentRow.Cells[2].Value.ToString();
            cboncc.Text = dtgdondat.CurrentRow.Cells[3].Value.ToString();
            string sql1 = "select a.madon, d.tensp, b.soluong    from dondathang a join chitietdondathang b on a.madon = b.madon  join sanpham d on b.masp = d.masp where a.madon = '"+txtMadon.Text.Trim()+"' order by a.madon desc";
            DataTable data = Functions.GetdataToTable(sql1);
            dtgchitiet.DataSource = data;
            dtgchitiet.Columns[0].HeaderText = "Mã đơn";


            dtgchitiet.Columns[1].HeaderText = "Sản phẩm";
            dtgchitiet.Columns[2].HeaderText = "Số lượng";
            btnHuy.Enabled = true;

            

        }

        private void dtgdondat_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ số hàng hợp lệ và không phải hàng tiêu đề
            if (e.RowIndex >= 0 && e.RowIndex < dtgdondat.Rows.Count - 1)
            {
                DataGridViewRow selectedRow = dtgdondat.Rows[e.RowIndex];

                // Lấy giá trị của cột Mã đơn
                string maDon = selectedRow.Cells["MaDon"].Value.ToString();

                // Thực hiện xóa dòng trong CSDL và trong DataGridView
                string sql = "delete from chitietdondathang WHERE MaDon = '" + maDon + "' ";
                Functions.RunSQL(sql);
                string sqlDelete = "DELETE FROM Dondathang WHERE MaDon = '" + maDon + "'";

                Functions.RunSQL(sqlDelete);
                if (btnThem.Enabled == true)
                {
                    dataload();
                }
                else
                {
                    Loaddata();
                }
            }
        }

        private void dtgchitiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMadon.Text = dtgchitiet.CurrentRow.Cells[0].Value.ToString();
            cbtensp.Text = dtgchitiet.CurrentRow.Cells[1].Value.ToString();
            txtsl.Text = dtgchitiet.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
