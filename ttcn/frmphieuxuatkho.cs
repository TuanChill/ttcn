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
    public partial class frmphieuxuatkho : Form
    {
        public frmphieuxuatkho()
        {
            InitializeComponent();
        }

        private void frmphieuxuatkho_Load(object sender, EventArgs e)
        {
            Class.Functions.Ketnoi();
            SqlConnection conn = Functions.Conn;
            string sql = "SELECT Manhanvien, Tennhanvien FROM NhanVien ";
            Functions.Fillcombo(sql, cbonv, "MaNV", "HoTenNV");
            string sql1 = "SELECT MaNL, TenNL, Mota,SoLuong,Gia,Ghichu FROM Nguyenlieu where MaTT <> 3";
            Functions.Fillcombo(sql1, cbtensp, "MaNL", "TenNL");
            
            //string sql3 = "SELECT MaLoaiPhieu, TenLoaiPhieu FROM LoaiPhieu";
            //Functions.Fillcombo(sql3, cboloaiphieu, "MaLoaiPhieu", "TenLoaiPhieu");
            txtsl.Text = "0";
            LoadGiaSanPham();
            txtck.Text = "0";
            dataload();
            loadtongtien();
            CalculateThanhTien();
            
        }

        private void cbtensp_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy giá trị mã sản phẩm từ ComboBox
            string maSanPham = cbtensp.SelectedValue.ToString();

            // Gán giá trị mã sản phẩm vào TextBox
            txtmasp.Text = maSanPham;
            LoadGiaSanPham();
        }
        private void LoadGiaSanPham()
        {
           
            if (int.TryParse(txtmasp.Text, out int maSanPham))
            {
                string sql = "SELECT Gia FROM Nguyenlieu WHERE MaNL = " + maSanPham;
                System.Data.DataTable dt = Functions.GetdataToTable(sql);

                if (dt.Rows.Count > 0)
                {
                    decimal gia = Convert.ToDecimal(dt.Rows[0]["gia"]);
                    txtgia.Text = gia.ToString();
                }
                else
                {
                    txtgia.Text = "0";
                }
            }
            else
            {
                txtgia.Text = "0";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btntaophieu.Enabled = true;
            btnIn.Enabled = false;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            string maPhieuXuat = "PX" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // Gán mã phiếu nhập vào TextBox
            txtMaPhieuXuat.Text = maPhieuXuat;
            cbonv.Focus();
            Loaddata();
            

        }

        private void txtsl_Enter(object sender, EventArgs e)
        {
            if (txtsl.Text == "0")
            {
                txtsl.Text = "";
            }
        }

        private void txtgia_Enter(object sender, EventArgs e)
        {
            if (txtgia.Text == "0")
            {
                txtgia.Text = "";
            }
        }

        private void txtck_Enter(object sender, EventArgs e)
        {
            if (txtck.Text == "0")
            {
                txtck.Text = "";
            }
        }
        private void CalculateThanhTien()
        {
            
            decimal gia;
            int sl;

            if (Decimal.TryParse(txtgia.Text, out gia) && Int32.TryParse(txtsl.Text, out sl))
            {
                decimal thanhTien = gia * sl;
                txtthanhtien.Text = thanhTien.ToString();
            }
            else
            {
                txtthanhtien.Text = "0";
            }
        }

        private void txtsl_TextChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }

        private void txtgia_TextChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }

        private void txtck_TextChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }
        private void Loaddata()
        {
            //string sql = "SELECT a.MaPhieuXuat, b. TenSP, c.NgayTao, a.SoLuong, a.DonGia " +
            //     "FROM PhieuXuat AS a " +
            //     "JOIN SanPham AS b ON a.MaSP = b.MaSP " +
            //     "JOIN PhieuXuattam AS c ON a.MaPhieuXuat = c.MaPhieuXuat " +
            //     "WHERE a.MaPhieuXuat = N'" + txtMaPhieuXuat.Text + "'";
            string sql = "SELECT a.MaPhieuXK, b. TenNL, c.NgayTao, a.SoLuong, a.thanhtien " +
                 "FROM PhieuXuatKho AS a " +
                 "JOIN Nguyenlieu AS b ON a.MaNL = b.MaNL " +
                // "JOIN PhieuXuattam AS c ON a.MaPhieuXK = c.MaPhieuXK " +
                 "WHERE a.MaPhieuXK = N'" + txtMaPhieuXuat.Text + "'";

            // Lấy dữ liệu từ CSDL và gán vào DataTable
            System.Data.DataTable dataTable = Class.Functions.GetdataToTable(sql);

            // Gán DataTable cho DataGridView để hiển thị dữ liệu
            dtgphieuxuatkho.DataSource = dataTable;

            // Đặt lại tiêu đề cho các cột
            dtgphieuxuatkho.Columns[0].HeaderText = "Mã phiếu xuất";
            dtgphieuxuatkho.Columns[1].HeaderText = "Tên sản phẩm";
            dtgphieuxuatkho.Columns[2].HeaderText = "Ngày tạo";
            dtgphieuxuatkho.Columns[3].HeaderText = "Số lượng";

            dtgphieuxuatkho.Columns[4].HeaderText = "Thành tiền";

            // Đặt lại độ rộng cho các cột
            dtgphieuxuatkho.Columns[0].Width = 120;
            dtgphieuxuatkho.Columns[1].Width = 150;
            dtgphieuxuatkho.Columns[2].Width = 100;
            dtgphieuxuatkho.Columns[3].Width = 80;
            dtgphieuxuatkho.Columns[4].Width = 100;


            dtgphieuxuatkho.AllowUserToAddRows = false;
            dtgphieuxuatkho.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        //private void btnthemsanpham_Click(object sender, EventArgs e)
        //{
        //    string sqlCheck = "SELECT * FROM PhieuXuattam WHERE MaPhieuXuat = N'" + txtMaPhieuXuat.Text.Trim() + "'";
        //    System.Data.DataTable dt = Functions.GetdataToTable(sqlCheck);

        //    if (dt.Rows.Count > 0)
        //    {

        //        // Mã phiếu nhập đã tồn tại
        //        // Kiểm tra mã sản phẩm trong bảng PhieuXuat
        //        string sqlCheckSP = "SELECT * FROM PhieuXuatKho WHERE MaPhieuXK = N'" + txtMaPhieuXuat.Text.Trim() + "' AND MaNL = '" + txtmasp.Text.Trim() + "'";
        //        System.Data.DataTable dtSP = Functions.GetdataToTable(sqlCheckSP);

        //        if (dtSP.Rows.Count > 0)
        //        {
        //            // Mã sản phẩm đã tồn tại trong PhieuXuat
        //            // Thực hiện cập nhật số lượng và thành tiền
        //            //string sqlUpdate = "UPDATE PhieuXuatKho SET SoLuong = SoLuong + " + txtsl.Text.Trim() + ", DonGia = DonGia + " + txtthanhtien.Text.Trim() + " WHERE MaPhieuXuat = N'" + txtMaPhieuXuat.Text.Trim() + "' AND MaSP = '" + txtmasp.Text.Trim() + "'";
        //            string sqlUpdate = "UPDATE PhieuXuatKho SET SoLuong = SoLuong + " + txtsl.Text.Trim() + ", thanhtien = thanhtien + " + txtthanhtien.Text.Trim() + " WHERE MaPhieuXK = N'" + txtMaPhieuXuat.Text.Trim() + "' AND MaNL = '" + txtmasp.Text.Trim() + "'";
        //            Functions.RunSQL(sqlUpdate);
        //        }
        //        else
        //        {
        //            // Mã sản phẩm chưa tồn tại trong PhieuXuat
        //            // Thực hiện chèn mới
        //            string sql = "INSERT INTO PhieuXuatKho (MaPhieuXK, MaNL, SoLuong, thanhtien) VALUES (" +
        //                "N'" + txtMaPhieuXuat.Text.Trim() + "'," +
        //                "'" + txtmasp.Text.Trim() + "'," +
        //                "'" + txtsl.Text.Trim() + "'," +
        //                "'" + txtthanhtien.Text.Trim() + "')";
        //            Functions.RunSQL(sql);
        //        }
        //    }
        //    else
        //    {
        //        int maNV = Convert.ToInt32(cbonv.SelectedValue);
                
        //        int maLoaiPhieu = Convert.ToInt32(cboloaiphieu.SelectedValue);

        //        //string sqlPhieuXuat = "INSERT INTO PhieuXuattam (MaPhieuXuat, MaNV, MaLoaiPhieu) VALUES (" +
        //        //    "N'" + txtMaPhieuXuat.Text.Trim() + "'," +
        //        //    "'" + maNV + "'," +

        //        //    "'" + maLoaiPhieu + "')";
        //        string sqlPhieuXuat = "INSERT INTO PhieuXuattam (MaPhieuXK, Manhanvien) VALUES (" +
        //           "N'" + txtMaPhieuXuat.Text.Trim() + "'," +
        //           "'" + maNV + ")";
        //        Functions.RunSQL(sqlPhieuXuat);

        //      //  string sql = "INSERT INTO PhieuXuatKho (MaPhieuXK, MaNL, SoLuong, DonGia) VALUES (" +
        //             string sql = "INSERT INTO PhieuXuatKho (MaPhieuXK, MaNL, SoLuong, thanhtien) VALUES (" +
        //            "N'" + txtMaPhieuXuat.Text.Trim() + "'," +
        //            "'" + txtmasp.Text.Trim() + "'," +
        //            "'" + txtsl.Text.Trim() + "'," +
        //            "'" + txtthanhtien.Text.Trim() + "')";
        //        Functions.RunSQL(sql);
        //    }
        //    Loaddata();
        //    loadtongtien();
        //}

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu trong bảng PhieuXuat
            string sqlDeleteChiTiet = "DELETE FROM PhieuXuatKho ";
            Functions.RunSQL(sqlDeleteChiTiet);

            // Xóa dữ liệu trong bảng PhieuXuatTam
            string sqlDeletePhieuXuat = "DELETE FROM PhieuXuatTam";
            Functions.RunSQL(sqlDeletePhieuXuat);

            // Xóa dữ liệu trong các TextBox và ComboBox

            // Cập nhật trạng thái hoặc hiển thị thông báo hủy thành công (tuỳ theo yêu cầu)
            Loaddata();
            loadtongtien();
        }

        private void btntaophieu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem phiếu nhập tạm có tồn tại không
            string sqlCheck = "SELECT * FROM PhieuXuattam WHERE MaPhieuXK = N'" + txtMaPhieuXuat.Text.Trim() + "'";
            System.Data.DataTable dt = Functions.GetdataToTable(sqlCheck);

            if (dt.Rows.Count > 0)
            {
                // Sao chép dữ liệu từ bảng PhieuXuattam sang bảng PhieuXuat
                //string sqlCopyPhieuXuat = "INSERT INTO PhieuXuat  (MaPhieuXuat, maNV, MaLoaiPhieu) " +
                //    "SELECT MaPhieuXuat, MaNV, MaLoaiPhieu FROM PhieuXuattam";
                string sqlCopyPhieuXuat = "INSERT INTO PhieuXuat  (MaPhieuXuat, maNV, MaLoaiPhieu) " +
                    "SELECT MaPhieuXuat, MaNV, MaLoaiPhieu FROM PhieuXuattam";
                Functions.RunSQL(sqlCopyPhieuXuat);

                // Sao chép dữ liệu từ bảng PhieuXuat sang bảng ChiTietPhieuXuat
                string sqlCopyChiTietPhieuXuat = "INSERT INTO ChiTietPhieuXuat (MaPhieuXuat, MaSP, SoLuong, DonGia) " +
                    "SELECT MaPhieuXuat, MaSP, SoLuong, DonGia FROM PhieuXuat";
                Functions.RunSQL(sqlCopyChiTietPhieuXuat);

                // Cập nhật cột TongTien trong bảng PhieuXuat
                string sqlUpdateTongTien = "UPDATE PhieuXuat  SET  TongTien = " +
                    "(SELECT SUM(Dongia) FROM ChiTietPhieuXuat  WHERE MaPhieuXuat = N'" + txtMaPhieuXuat.Text.Trim() + "' ) where MaPhieuXuat = N'" + txtMaPhieuXuat.Text.Trim() + "' ";
                Functions.RunSQL(sqlUpdateTongTien);
                // Xóa dữ liệu trong bảng PhieuXuat
                string sqlDeletePhieuXuat = "DELETE FROM PhieuXuat ";
                Functions.RunSQL(sqlDeletePhieuXuat);

                // Xóa dữ liệu trong bảng PhieuXuattam
                string sqlDeletePhieuXuatTam = "DELETE FROM PhieuXuattam";
                Functions.RunSQL(sqlDeletePhieuXuatTam);



                MessageBox.Show("Tạo phiếu thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy phiếu nhập tạm có mã " + txtMaPhieuXuat.Text.Trim() + "");
            }

        }
        private void loadtongtien()
        {
            // Tính tổng đơn giá
            string sqlSum = "SELECT SUM(DonGia) FROM PhieuXuat";
            System.Data.DataTable dtSum = Functions.GetdataToTable(sqlSum);
            float tongTien = 0;
            if (dtSum.Rows.Count > 0 && dtSum.Rows[0][0] != DBNull.Value)
            {
                tongTien = Convert.ToSingle(dtSum.Rows[0][0]);
            }

            // Gán giá trị cho txttongtien
            txttongtien.Text = tongTien.ToString("F4");
        }
        private void dataload()
        {
            string sql = "SELECT a.MaPhieuXuat, b.HoTenNV,  a.NgayTao,  a.Tongtien, d. tenloaiphieu FROM  PhieuXuat a  JOIN NhanVien b ON a.MaNV = b.MaNV  join loaiphieu d on a.maloaiphieu = d.maloaiphieu ";


            // Lấy dữ liệu từ CSDL và gán vào DataTable
            System.Data.DataTable dataTable = Class.Functions.GetdataToTable(sql);

            // Gán DataTable cho DataGridView để hiển thị dữ liệu
            dtgphieuxuatkho.DataSource = dataTable;

            // Đặt lại tiêu đề cho các cột
            dtgphieuxuatkho.Columns[0].HeaderText = "Mã phiếu xuất";
            dtgphieuxuatkho.Columns[1].HeaderText = "Tên nhân viên";

            dtgphieuxuatkho.Columns[2].HeaderText = "Ngày tạo";

            dtgphieuxuatkho.Columns[3].HeaderText = "Thành tiền";
            

            dtgphieuxuatkho.Columns[4].HeaderText = "Xuất đến";

            // Đặt lại độ rộng cho các cột
            dtgphieuxuatkho.Columns[0].Width = 120;
            dtgphieuxuatkho.Columns[1].Width = 150;
            dtgphieuxuatkho.Columns[2].Width = 150;
            dtgphieuxuatkho.Columns[3].Width = 100;
            dtgphieuxuatkho.Columns[4].Width = 150;
            


            dtgphieuxuatkho.AllowUserToAddRows = false;
            dtgphieuxuatkho.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private string GetMaSPFromTenSP(string tenSP)
        {
            string sql = "SELECT MaSP FROM SanPham WHERE TenSP = N'" + tenSP + "'";
            System.Data.DataTable dt = Functions.GetdataToTable(sql);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["MaSP"].ToString();
            }

            return null; // Trả về null nếu không tìm thấy mã sản phẩm
        }

        private void dtgphieuxuatkho_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem sự kiện xảy ra trên cột nào
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy mã sản phẩm và mã phiếu nhập từ dòng được nhấp đúp chuột
                if (e.RowIndex >= 0)
                {
                    string tenSP = dtgphieuxuatkho.Rows[e.RowIndex].Cells["TenSP"].Value.ToString();
                    string maSP = GetMaSPFromTenSP(tenSP);

                    if (maSP != null)
                    {
                        // Xóa dòng dữ liệu dựa trên mã sản phẩm và mã phiếu nhập
                        string maPhieuxuat = dtgphieuxuatkho.Rows[e.RowIndex].Cells["maphieunhap"].Value.ToString();

                        string sqlDelete = "DELETE FROM PhieuXuat WHERE MaPhieuxuat = N'" + maPhieuxuat + "' AND MaSP = N'" + maSP + "'";
                        Functions.RunSQL(sqlDelete);

                        // Refresh lại DataGridView sau khi xóa dòng dữ liệu
                        Loaddata();
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgphieuxuatkho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra chỉ số hàng hợp lệ
            {
                DataGridViewRow row = dtgphieuxuatkho.Rows[e.RowIndex];
                string maPhieuXuat = row.Cells["MaPhieuXuat"].Value.ToString();

                // Điền mã phiếu nhập vào txtmaphieunhap
                txtMaPhieuXuat.Text = maPhieuXuat;
            }
        }

        
    }
}
