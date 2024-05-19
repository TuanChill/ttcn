using Microsoft.Office.Interop.Excel;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using COMExcel = Microsoft.Office.Interop.Excel;



namespace ttcn
{
    public partial class frmphieunhapkho : Form
    {
        public frmphieunhapkho()
        {
            InitializeComponent();
        }
        

        private void frmphieunhapkho_Load(object sender, EventArgs e)
        {
            Class.Functions.Ketnoi();
            SqlConnection conn = Functions.Conn;
            string sql = "SELECT Manhanvien, Tennhanvien FROM NhanVien ";
            Functions.Fillcombo(sql, cbonv, "Manhanvien", "Tennhanvien");
            string sql1 = "SELECT MaNL, TênNL FROM Nguyenlieu where MaTT <> 3";
            Functions.Fillcombo(sql1, cbtensp, "MaNL", "TenNL");
            string sql2 = "SELECT MaNCC, TenNCC FROM NhaCungCap";
            Functions.Fillcombo(sql2, cboncc, "MaNCC", "TenNCC");
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
            /*// Lấy giá trị mã sản phẩm từ TextBox
            if (int.TryParse(txtmasp.Text, out int maSanPham))
            {
                // Truy vấn SQL để lấy giá sản phẩm dựa trên mã sản phẩm
                string sql = "SELECT gia FROM SanPham WHERE masp = " + maSanPham;
               System.Data.DataTable dt = Functions.GetdataToTable(sql);

                // Kiểm tra nếu có kết quả trả về
                if (dt.Rows.Count > 0)
                {
                    // Lấy giá sản phẩm từ DataTable và gán vào TextBox
                    decimal gia = Convert.ToDecimal(dt.Rows[0]["gia"]);
                    txtgia.Text = gia.ToString();
                }
                else
                {
                    // Nếu không tìm thấy giá sản phẩm, đặt giá trị mặc định là 0
                    txtgia.Text = "0";
                }
            }
            else
            {
                // Nếu giá trị mã sản phẩm không hợp lệ, đặt giá trị mặc định là 0
                txtgia.Text = "0";
            }*/
            if (int.TryParse(txtmasp.Text, out int maNl))
            {
                string sql = "SELECT gia FROM Nguyenlieu WHERE masp = " + maNl;
                System.Data.DataTable dt = Functions.GetdataToTable(sql);

                if (dt.Rows.Count > 0)
                {
                    decimal gia = Convert.ToDecimal(dt.Rows[0]["Gia"]);
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
            string maPhieuNhap = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // Gán mã phiếu nhập vào TextBox
            txtMaPhieuNhap.Text = maPhieuNhap;
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
            /*decimal gia;
            int sl;
            decimal ck;

            // Kiểm tra và chuyển đổi giá trị từ các TextBox
            if (!decimal.TryParse(txtgia.Text, out gia))
            {
                // Không chuyển đổi thành công, giá trị không hợp lệ
                txtthanhtien.Text = "0";
                return;
            }

            if (!int.TryParse(txtsl.Text, out sl))
            {
                // Không chuyển đổi thành công, giá trị không hợp lệ
                txtthanhtien.Text = "0";
                return;
            }

            if (!decimal.TryParse(txtck.Text, out ck))
            {
                // Không chuyển đổi thành công, giá trị không hợp lệ
                txtthanhtien.Text = "0";
                return;
            }

            // Tính toán thành tiền
            decimal thanhTien = gia * sl - gia * sl * ck / 100;

            // Gán giá trị cho txtthanhtien
            txtthanhtien.Text = thanhTien.ToString();*/
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
            //string sql = "SELECT a.MaPhieuNK, b. TenNL, c.NgayTao, a.SoLuong, a.DonGia " +
            //     "FROM ChiTietPhieuNhap AS a " +
            //     "JOIN Nguyenlieu AS b ON a.MaNL = b.MaNL " +
            //     "JOIN PhieuNhaptam AS c ON a.MaPhieuNhap = c.MaPhieuNhap " +
            //     "WHERE a.MaPhieuNhap = N'" + txtMaPhieuNhap.Text + "' ORDER BY a.Maphieunhap DESC";
            string sql = "SELECT a.MaPhieuNK, b. TenNL, c.NgayTao, a.SoLuong, a.thanhtien " +
                "FROM Chitietphieunhapkho AS a " +
                "JOIN Nguyenlieu AS b ON a.MaNL = b.MaNL "+
               // +"JOIN PhieuNhaptam AS c ON a.MaPhieuNK = c.MaPhieuNK " +
              //  "WHERE a.MaPhieuNK = N'" + txtMaPhieuNhap.Text +
              "' ORDER BY a.MaPhieuNK DESC";
            // Lấy dữ liệu từ CSDL và gán vào DataTable
            System.Data.DataTable dataTable = Class.Functions.GetdataToTable(sql);

            // Gán DataTable cho DataGridView để hiển thị dữ liệu
            dtgphieunhapkho.DataSource = dataTable;

            // Đặt lại tiêu đề cho các cột
            dtgphieunhapkho.Columns[0].HeaderText = "Mã phiếu nhập";
            dtgphieunhapkho.Columns[1].HeaderText = "Tên sản phẩm";
            dtgphieunhapkho.Columns[2].HeaderText = "Ngày tạo";
            dtgphieunhapkho.Columns[3].HeaderText = "Số lượng";
            
            dtgphieunhapkho.Columns[4].HeaderText = "Thành tiền";

            // Đặt lại độ rộng cho các cột
            dtgphieunhapkho.Columns[0].Width = 120;
            dtgphieunhapkho.Columns[1].Width = 150;
            dtgphieunhapkho.Columns[2].Width = 100;
            dtgphieunhapkho.Columns[3].Width = 80;
            dtgphieunhapkho.Columns[4].Width = 100;
           

            dtgphieunhapkho.AllowUserToAddRows = false;
            dtgphieunhapkho.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthemsanpham_Click(object sender, EventArgs e)
        {
            
                string sqlCheck = "SELECT * FROM Phieunhapkho WHERE MaPhieuNK = N'" + txtMaPhieuNhap.Text.Trim() + "'";
            //string sqlCheck = "SELECT * FROM PhieuNhaptam WHERE MaPhieuNhap = N'" + txtMaPhieuNhap.Text.Trim() + "'";
               System.Data.DataTable dt = Functions.GetdataToTable(sqlCheck);

            if (dt.Rows.Count > 0)
            {

                // Mã phiếu nhập đã tồn tại
                // Kiểm tra mã sản phẩm trong bảng PhieuNhap
                string sqlCheckSP = "SELECT * FROM Chitietphieunhapkho WHERE MaPhieuNK = N'" + txtMaPhieuNhap.Text.Trim() + "' AND MaNL = '" + txtmasp.Text.Trim() + "'";
               System.Data.DataTable dtSP = Functions.GetdataToTable(sqlCheckSP);

                if (dtSP.Rows.Count > 0)
                {
                    // Mã sản phẩm đã tồn tại trong ChiTietPhieuNhap
                    // Thực hiện cập nhật số lượng và thành tiền
                    string sqlUpdate = "UPDATE Chitietphieunhapkho SET SoLuong = SoLuong + " + txtsl.Text.Trim() + ", thanhtien = thanhtien + " + txtthanhtien.Text.Trim() + " WHERE MaPhieuNK = N'" + txtMaPhieuNhap.Text.Trim() + "' AND MaNL = '" + txtmasp.Text.Trim() + "'";
                    //   string sqlUpdate = "UPDATE Chitietphieunhapkho SET SoLuong = SoLuong + " + txtsl.Text.Trim() + ", DonGia = DonGia + " + txtthanhtien.Text.Trim() + " WHERE MaPhieuNhap = N'" + txtMaPhieuNhap.Text.Trim() + "' AND MaSP = '" + txtmasp.Text.Trim() + "'";
                    Functions.RunSQL(sqlUpdate);
                }
                else
                {
                    // Mã sản phẩm chưa tồn tại trong ChiTietPhieuNhap
                    // Thực hiện chèn mới
                    string sql = "INSERT INTO Chitietphieunhapkho (MaPhieuNK, MaNL, SoLuong, thanhtien) VALUES (" +
                        "N'" + txtMaPhieuNhap.Text.Trim() + "'," +
                        "'" + txtmasp.Text.Trim() + "'," +
                        "'" + txtsl.Text.Trim() + "'," +
                        "'" + txtthanhtien.Text.Trim() + "')";
                    Functions.RunSQL(sql);
                }
            }
            else
            {
                int maNV = Convert.ToInt32(cbonv.SelectedValue);
                int MaNCC = Convert.ToInt32(cboncc.SelectedValue);
                int maLoaiPhieu = Convert.ToInt32(cboloaiphieu.SelectedValue);

                //string sqlPhieuNhap = "INSERT INTO PhieuNhaptam (MaPhieuNhap, Manhanvien, MaNCC, MaLoaiPhieu) VALUES (" +
                //    "N'" + txtMaPhieuNhap.Text.Trim() + "'," +
                //    "'" + maNV + "'," +
                //    "'" + MaNCC + "'," +
                //    "'" + maLoaiPhieu + "')";
                //Functions.RunSQL(sqlPhieuNhap);

                string sql = "INSERT INTO Chitietphieunhapkho (MaPhieuNK, MaNL, SoLuong, thanhtien) VALUES (" +
                    "N'" + txtMaPhieuNhap.Text.Trim() + "'," +
                    "'" + txtmasp.Text.Trim() + "'," +
                    "'" + txtsl.Text.Trim() + "'," +
                    "'" + txtthanhtien.Text.Trim() + "')";
                Functions.RunSQL(sql);
            }
                Loaddata();
            loadtongtien();

            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //// Xóa dữ liệu trong bảng ChiTietPhieuNhap
            //string sqlDeleteChiTiet = "DELETE FROM ChiTietPhieuNhap ";
            //Functions.RunSQL(sqlDeleteChiTiet);

            //// Xóa dữ liệu trong bảng PhieuNhapTam
            //string sqlDeletePhieuNhap = "DELETE FROM PhieuNhapTam";
            //Functions.RunSQL(sqlDeletePhieuNhap);

            // Xóa dữ liệu trong các TextBox và ComboBox
            
            // Cập nhật trạng thái hoặc hiển thị thông báo hủy thành công (tuỳ theo yêu cầu)
            Loaddata();
            loadtongtien();
        }

        private void btntaophieu_Click(object sender, EventArgs e)
        {


            // Kiểm tra xem phiếu nhập tạm có tồn tại không
            string sqlCheck = "SELECT * FROM PhieuNhaptam WHERE MaPhieuNhap = N'" + txtMaPhieuNhap.Text.Trim() + "'";
            System.Data.DataTable dt = Functions.GetdataToTable(sqlCheck);

            if (dt.Rows.Count > 0)
            {
                // Sao chép dữ liệu từ bảng PhieuNhaptam sang bảng PhieuNhap
                //string sqlCopyPhieuNhap = "INSERT INTO PhieuNhap (MaPhieuNhap, MaNV, MaNCC, MaLoaiPhieu) " +
                //    "SELECT MaPhieuNhap, MaNV, MaNCC, MaLoaiPhieu FROM PhieuNhaptam";
                string sqlCopyPhieuNhap = "INSERT INTO Phieunhapkho (MaPhieuNK, Manhanvien, MaNCC, MaLoaiPhieu) ";
                Functions.RunSQL(sqlCopyPhieuNhap);

                // Sao chép dữ liệu từ bảng ChiTietPhieuNhap sang bảng ChiTietPhieuNhap
                //string sqlCopyChiTietPhieuNhap = "INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSP, SoLuong, DonGia) " +
                //    "SELECT MaPhieuNhap, MaSP, SoLuong, DonGia FROM ChiTietPhieuNhap";
                string sqlCopyChiTietPhieuNhap = "INSERT INTO Chitietphieunhapkho (MaPhieuNK, MaNL, SoLuong, thanhtien) " +
                    "SELECT MaPhieuNK, MaNL, SoLuong, thanhtien FROM ChitietphieunhapFkho";
                Functions.RunSQL(sqlCopyChiTietPhieuNhap);

                // Cập nhật cột TongTien trong bảng PhieuNhap
                //string sqlUpdateTongTien = "UPDATE PhieuNhap SET TongTien = " +
                //    "(SELECT SUM(Dongia) FROM ChiTietPhieuNhap WHERE MaPhieuNhap = N'" + txtMaPhieuNhap.Text.Trim() + "') where MaPhieuNhap = N'" + txtMaPhieuNhap.Text.Trim() + "' ";
                string sqlUpdateTongTien = "UPDATE Phieunhapkho SET tongsotien = " +
                     "(SELECT SUM(thanhtien) FROM Chitietphieunhapkho WHERE MaPhieuNK = N'" + txtMaPhieuNhap.Text.Trim() + "') where MaPhieuNK = N'" + txtMaPhieuNhap.Text.Trim() + "' ";
                Functions.RunSQL(sqlUpdateTongTien);
                // Xóa dữ liệu trong bảng ChiTietPhieuNhap
                string sqlDeleteChiTietPhieuNhap = "DELETE FROM Chitietphieunhapkho ";
                Functions.RunSQL(sqlDeleteChiTietPhieuNhap);

                // Xóa dữ liệu trong bảng PhieuNhaptam
                //string sqlDeletePhieuNhapTam = "DELETE FROM PhieuNhaptam";
                //Functions.RunSQL(sqlDeletePhieuNhapTam);

                

                MessageBox.Show("Tạo phiếu thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy phiếu nhập tạm có mã " + txtMaPhieuNhap.Text.Trim()+"");
            }


        }
        private void loadtongtien()
        {
            // Tính tổng đơn giá
            string sqlSum = "SELECT SUM(thanhtien) FROM Chitietphieunhapkho";
            // string sqlSum = "SELECT SUM(DonGia) FROM ChiTietPhieuNhap";
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
            // string sql = "SELECT a.MaPhieuNK, b.HoTenNV,  a.NgayTao,  a.Tongtien, c.Tenncc, d. tenloaiphieu FROM  Phieunhapkho a  JOIN NhanVien b ON a.Manhanvien = b.Manhanvien join NhaCungCap c on a.MaNCC = c.MaNCC join loaiphieu d on a.maloaiphieu = d.maloaiphieu ORDER BY a.Maphieunhap DESC";
            string sql = "SELECT a.MaPhieuNK, b.Tennhanvien,  a.NgayTao,  a.tongsotien, c.TenNCC, a.loainhap FROM  Phieunhapkho a  JOIN NhanVien b ON a.Manhanvien = b.Manhanvien join NhaCungCap c on a.MaNCC = c.MaNCC ORDER BY a.MaPhieuNK DESC";
                

            // Lấy dữ liệu từ CSDL và gán vào DataTable
           System.Data.DataTable dataTable = Class.Functions.GetdataToTable(sql);

            // Gán DataTable cho DataGridView để hiển thị dữ liệu
            dtgphieunhapkho.DataSource = dataTable;

            // Đặt lại tiêu đề cho các cột
            dtgphieunhapkho.Columns[0].HeaderText = "Mã phiếu nhập";
            dtgphieunhapkho.Columns[1].HeaderText = "Tên nhân viên";
            
            dtgphieunhapkho.Columns[2].HeaderText = "Ngày tạo";
            
            dtgphieunhapkho.Columns[3].HeaderText = "Thành tiền";
            dtgphieunhapkho.Columns[4].HeaderText = "Đơn vị cung cấp";

            dtgphieunhapkho.Columns[5].HeaderText = "Nhập từ";

            // Đặt lại độ rộng cho các cột
            dtgphieunhapkho.Columns[0].Width = 120;
            dtgphieunhapkho.Columns[1].Width = 150;
            dtgphieunhapkho.Columns[2].Width = 150;
            dtgphieunhapkho.Columns[3].Width = 100;
            dtgphieunhapkho.Columns[4].Width = 150;
            dtgphieunhapkho.Columns[5].Width = 100;


            dtgphieunhapkho.AllowUserToAddRows = false;
            dtgphieunhapkho.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dtgphieunhapkho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private string GetMaSPFromTenSP(string tenSP)
        {
            string sql = "SELECT MaNL FROM Nguyenlieu WHERE TenNL = N'" + tenSP + "'";
           System.Data.DataTable dt = Functions.GetdataToTable(sql);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["MaNL"].ToString();
            }

            return null; // Trả về null nếu không tìm thấy mã sản phẩm
        }
        private void dtgphieunhapkho_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem sự kiện xảy ra trên cột nào
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy mã sản phẩm và mã phiếu nhập từ dòng được nhấp đúp chuột
                if (e.RowIndex >= 0)
                {
                    string tenSP = dtgphieunhapkho.Rows[e.RowIndex].Cells["TenNL"].Value.ToString();
                    string maSP = GetMaSPFromTenSP(tenSP);

                    if (maSP != null)
                    {
                        // Xóa dòng dữ liệu dựa trên mã sản phẩm và mã phiếu nhập
                        string maPhieuNhap = dtgphieunhapkho.Rows[e.RowIndex].Cells["MaPhieuNK"].Value.ToString();

                        string sqlDelete = "DELETE FROM ChiTietPhieunhapkho WHERE MaPhieuNK = N'" + maPhieuNhap + "' AND MaNL = N'" + maSP + "'";
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
        

        private void btnIn_Click(object sender, EventArgs e)
        {
            

        }

        private void dtgphieunhapkho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra chỉ số hàng hợp lệ
            {
                DataGridViewRow row = dtgphieunhapkho.Rows[e.RowIndex];
                string maPhieuNhap = row.Cells["MaPhieuNK"].Value.ToString();

                // Điền mã phiếu nhập vào txtmaphieunhap
                txtMaPhieuNhap.Text = maPhieuNhap;
            }
        }
    }
}
