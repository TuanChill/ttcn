using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ttcn.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace ttcn
{
    public partial class PNK : Form
    {
        public PNK()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát nhập kho không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Application.Exit();
                main mainForm = new main();
                mainForm.Show();
                return;
            }
        }

        private void PNK_Load(object sender, EventArgs e)
        {
            Class.Functions.Ketnoi();
            btn_them.Enabled = true;
            btn_luu.Enabled = false;
          //  btn_xoa.Enabled = false;
            btn_in.Enabled = false;
            txt_maphieu.ReadOnly = true;
          //  txt_tennv.ReadOnly = true;
          //  txt_tenncc.ReadOnly = true;
            txt_dc.Enabled = false;
            mtxt_dt.Enabled = false;
          //  txt_tennl.ReadOnly = true;
           txt_gia.Enabled = false;
            txt_thanhtien.ReadOnly = true;
            txt_tongtien.ReadOnly = true;     
            txt_tongtien.Text = "0";
            

            SqlConnection conn = Functions.Conn;
            string sql = "SELECT Manhanvien,Tennhanvien FROM NhanVien ";
            Functions.Fillcombo(sql, combo_manv, "Manhanvien","Tennhanvien"); 
            
            Functions.Fillcombo("SELECT MaNL,TenNL FROM Nguyenlieu", combo_manl, "MaNL","TenNL");

            string sql2 = "SELECT MaNCC,TenNCC FROM NhaCungCap";
            Functions.Fillcombo(sql2, combo_ncc, "MaNCC","TenNCC");
            combo_manv.SelectedIndex = -1;
            combo_ncc.SelectedIndex = -1;
            combo_manl.SelectedIndex = -1;

            if (txt_maphieu.Text != "")
            {
               // loadThongTin();
             //   btn_xoa.Enabled = true;
                btn_in.Enabled = true;
            }
            Load_DataGridViewChitiet();
            txt_sl.Text = "0";
            txt_thanhtien.Text = "0";
            txt_gia.Text = "0";

        }
        //private void loadThongTin()
        //{
        //    string str;
        //    str = "SELECT NgayTao FROM Phieunhapkho WHERE MaPhieuNK = N'" + txt_maphieu.Text + "'";
        //    dtngaytao.Text = Functions.ConvertTimeTo24(Functions.GetFieldValues(str));
        //    //str = "SELECT MaNV FROM Nhanvien WHERE MaPhieuNK = N'" + txt_maphieu.Text + "'";
        //    //combo_manv.Text = Functions.GetFieldValues(str);

        //    //str = "SELECT MaNCC FROM NhaCungCap WHERE MaPhieuNK = N'" + txt_maphieu.Text + "'";
        //    //combo_ncc.Text = Functions.GetFieldValues(str);

        //    str = "SELECT tongsotien FROM Phieunhapkho WHERE MaPhieuNK = N'" + txt_maphieu.Text + "'";
        //    txt_tongtien.Text = Functions.GetFieldValues(str);

        //    lb_bangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txt_thanhtien.Text);

        //}
        DataTable dt;
        private void Load_DataGridViewChitiet()
        {
            string sql;
            //   sql = "SELECT a.MaNL, a.TenNL, b.Soluong, a.Gia, b.Thanhtien FROM Nguyenlieu AS a, Chitietphieunhapkho AS b WHERE b.MaPhieuNK = N'" + txt_maphieu.Text + "' AND a.MaNL=b.MaNL";
             sql = "SELECT a.MaPhieuNK,b.MaNL, b.TenNL, a.SoLuong,b.Gia, a.thanhtien " +
                 "FROM Chitietphieunhapkho AS a " +
                 "JOIN Nguyenlieu AS b ON a.MaNL = b.MaNL " +
                "JOIN NhaCungCap AS c ON b.MaNCC = c.MaNCC " +
                "JOIN Phieunhapkho AS d ON a.MaPhieuNK = d.MaPhieuNK " +
                 " ORDER BY a.MaPhieuNK ASC";
            dt = Functions.GetdataToTable(sql);
            datagridview_nguyenlieu.DataSource = dt;

            datagridview_nguyenlieu.Columns[0].HeaderText = "Mã phiếu";
            datagridview_nguyenlieu.Columns[1].HeaderText = "Mã nguyên liệu";
            datagridview_nguyenlieu.Columns[2].HeaderText = "Tên nguyên liệu";
            datagridview_nguyenlieu.Columns[3].HeaderText = "Số lượng";
            datagridview_nguyenlieu.Columns[4].HeaderText = "Giá";
            datagridview_nguyenlieu.Columns[5].HeaderText = "Thành tiền";
           
            //datagridview_nguyenlieu.Columns[0].Width = 50;
            //datagridview_nguyenlieu.Columns[1].Width = 150;
            //datagridview_nguyenlieu.Columns[2].Width = 150;
            //datagridview_nguyenlieu.Columns[3].Width = 150;
            //datagridview_nguyenlieu.Columns[4].Width = 150;
          
            datagridview_nguyenlieu.AllowUserToAddRows = false;
            datagridview_nguyenlieu.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void datagridview_nguyenlieu_Click(object sender, EventArgs e)
        {
            if (btn_them.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txt_maphieu.Focus();
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào được hiển thị", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            txt_maphieu.Text = datagridview_nguyenlieu.CurrentRow.Cells["MaPhieuNK"].Value.ToString();
            string manl, mancc, manv, maphieunk;
            manl = datagridview_nguyenlieu.CurrentRow.Cells["MaNL"].Value.ToString();
            maphieunk = datagridview_nguyenlieu.CurrentRow.Cells["MaPhieuNK"].Value.ToString();


            // sửa 
            combo_manl.Text = Functions.GetFieldValues("SELECT TenNL FROM Nguyenlieu WHERE MaNL = N'" + manl + "'");
            combo_manv.Text = Functions.GetFieldValues("select Tennhanvien from Nhanvien as a JOIN Phieunhapkho AS b ON a.Manhanvien = b.Manhanvien  WHERE MaPhieuNK = N'" + maphieunk + "'");
            combo_ncc.Text = Functions.GetFieldValues("select TenNCC from Nguyenlieu as a JOIN NhaCungCap AS b ON a.MaNCC = b.MaNCC WHERE MaNL = N'" + manl + "'");

            //txt_tennl.Text = Functions.GetFieldValues("SELECT TenNL FROM Nguyenlieu WHERE MaNL = N'" + manl + "'");
            //txt_tennv.Text = Functions.GetFieldValues("select Tennhanvien from Nhanvien as a JOIN Phieunhapkho AS b ON a.Manhanvien = b.Manhanvien  WHERE MaPhieuNK = N'" + maphieunk + "'");
            //txt_tenncc.Text = Functions.GetFieldValues("select TenNCC from Nguyenlieu as a JOIN NhaCungCap AS b ON a.MaNCC = b.MaNCC WHERE MaNL = N'" + manl + "'");
            txt_sl.Text = datagridview_nguyenlieu.CurrentRow.Cells["SoLuong"].Value.ToString();
            txt_thanhtien.Text = datagridview_nguyenlieu.CurrentRow.Cells["thanhtien"].Value.ToString();

            btn_in.Enabled = true;

            btn_huy.Enabled = true;
        }

        private void txt_gia_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
            tinhTien();
        }
        private void tinhTien()
        {
            decimal gia;
            int sl;

            if (Decimal.TryParse(txt_gia.Text, out gia) && Int32.TryParse(txt_sl.Text, out sl))
            {
                decimal thanhTien = gia * sl;

                // Improved formatting with user-defined precision
                string formattedThanhTien;
                if (thanhTien >= 1000)  // Display with thousands separator and decimals only if necessary
                {
                    formattedThanhTien = thanhTien.ToString("0,0.###", CultureInfo.GetCultureInfo("vi-VN"));
                }
                else  // Display without thousands separator or decimals for values less than 1000
                {
                    formattedThanhTien = thanhTien.ToString("0", CultureInfo.GetCultureInfo("vi-VN"));
                }

                txt_thanhtien.Text = formattedThanhTien;
            }
            else
            {
                txt_thanhtien.Text = "0";
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            btn_taophieu.Enabled = true;
            btn_in.Enabled = false;
            btn_huy.Enabled = true;
            btn_them.Enabled = false;
            btn_luu.Enabled = true;
            txt_gia.Enabled = true;
            txt_dc.Enabled = true;
            mtxt_dt.Enabled = true;
            string maPhieuNhap = DateTime.Now.ToString("HHss");
            // 240515183724 24051518 245151825
            //// Gán mã phiếu nhập vào TextBox
            //txt_ma.Text = maPhieuNhap;
            string key = Functions.CreateKey("MaPhieuNK");
            txt_maphieu.Text = key;
            ResetValues();
            txt_maphieu.Enabled = true;
            txt_maphieu.Focus();
            txt_gia.Enabled=true;
            // Gán mã phiếu nhập vào TextBox
            txt_maphieu.Text = maPhieuNhap;
           // combo_manv.Focus();
        }
        private void ResetValues()
        {
            txt_maphieu.Text = "";
            dtngaytao.Text = "";
            //combo_nv.Text = "";
            //combo_ten.Text = "";
            // combo_ncc.Text = "";
            //txt_tennv.Text = "";
            //txt_tennl.Text = "";
            //txt_tenncc.Text = "";
            txt_dc.Text = "";
            mtxt_dt.Text = "";
            txt_sl.Text = "0";
            txt_gia.Text = "0";
            txt_thanhtien.Text = "0";
            txt_thanhtien.Enabled = false;
            combo_manv.SelectedIndex = -1;
            combo_ncc.SelectedIndex = -1;
            txt_tongtien.Text = "0";
            combo_manl.SelectedIndex = -1;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            btn_huy.Enabled = false;// đang 
            btn_them.Enabled = true;
            btn_in.Enabled = true;

            btn_luu.Enabled = false;
            txt_maphieu.Enabled = false;
            ResetValues();
        }

        private void btn_in_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinphieu, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 10;
            exRange.Range["B1:B1"].ColumnWidth = 45;
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B2:B2"].Value = "Công ty TNHH Sản xuất - Kinh doanh thương mại và dịch vụ Tín Phát";

            exRange.Range["B3"].MergeCells = true;
            exRange.Range["B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B3"].Value = "Địa chỉ: Bắc Từ Liêm - Hà Nội";

            exRange.Range["B4"].MergeCells = true;
            exRange.Range["B4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B4"].Value = "Điện thoại: 0906 249 090";


            exRange.Range["A1:I1"].Font.Size = 16;
            exRange.Range["A1:I1"].Font.Name = "Times new roman";
            exRange.Range["A1:I1"].Font.Bold = true;
            exRange.Range["A1:I1"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["A1:I1"].MergeCells = true;
            exRange.Range["A1:I1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:I1"].Value = "PHIẾU ĐĂNG NHẬP";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaPhieuNK, a.NgayTao, a.tongsotien, b.TenNCC, b.DiaChi, b.Sodienthoai, c.Tennhanvien " +
                "FROM Phieunhapkho AS a, NhaCungCap AS b, NhanVien AS c, Nguyenlieu as d, Chitietphieunhapkho as e WHERE a.MaPhieuNK = N'" +
                txt_maphieu.Text + "' AND a.MaPhieuNK = e.MaPhieuNK AND a.Manhanvien =c.Manhanvien AND d.MaNCC=b.MaNCC ";

            tblThongtinphieu = Functions.GetdataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã phiếu:";
            exRange.Range["C6:C6"].MergeCells = true;
            exRange.Range["C6:C6"].Value = tblThongtinphieu.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Tên nhà cung cấp:";
            
            exRange.Range["C7:C7"].ColumnWidth = 25;
            exRange.Range["C7:C7"].MergeCells = true;
            exRange.Range["C7:C7"].Value = tblThongtinphieu.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:C8"].MergeCells = true;
            exRange.Range["C8:C8"].Value = tblThongtinphieu.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Số điện thoại:";
            exRange.Range["C9:C9"].MergeCells = true;
            exRange.Range["C9:C9"].Value = txt_thanhtien;
            exRange.Range["C9:C9"].Value = tblThongtinphieu.Rows[0][5].ToString();
            exRange.Range["B10:B10"].Value = "Tên nhân viên:";
            exRange.Range["C10:C10"].MergeCells = true;
            exRange.Range["C10:C10"].Value = txt_thanhtien;
            exRange.Range["C10:C10"].Value = tblThongtinphieu.Rows[0][6].ToString();
            //Lấy thông tin các mặt hàng
            //sql = "SELECT a.MaPhieuNK, b.TenNL, a.SoLuong, a.thanhtien " +
            //   "FROM Chitietphieunhapkho AS a " +
            //   "JOIN Nguyenlieu AS b ON a.MaNL = b.MaNL " +
            //   " ORDER BY a.MaPhieuNK ASC";
            sql = "SELECT b.TenNL, a.SoLuong, a.thanhtien " +
              "FROM Chitietphieunhapkho AS a " +
              "JOIN Nguyenlieu AS b ON a.MaNL = b.MaNL " +
              " ORDER BY a.MaPhieuNK ASC";
            tblThongtinHang = Functions.GetdataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            //   exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinphieu.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu
 (tblThongtinphieu.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            //DateTime d = Convert.ToDateTime(tblThongtinphieu.Rows[0][1]);
            //exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            //exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            //exRange.Range["A6:C6"].Value = tblThongtinphieu.Rows[0][6];
            exSheet.Name = "Phiếu nhập";
            exApp.Visible = true;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaPhieuNK FROM Chitietphieunhapkho WHERE MaPhieuNK=N'" + txt_maphieu.Text + "'";
            if (!Functions.Checkkey(sql))
            {
                // Mã phiếu chưa có, tiến hành lưu các thông tin chung
                // Mã phiếu nk được sinh tự động do đó không có trường hợp trùng khóa
                if (dtngaytao.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn ngày ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtngaytao.Focus();
                    return;
                }
                if (combo_manv.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    combo_manv.Focus();
                    return;
                }
                if (combo_ncc.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    combo_ncc.Focus();
                    return;
                }
                if (txt_dc.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_dc.Focus();
                    return;
                }
                if (mtxt_dt.Text == "(   )    -")
                {
                    MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mtxt_dt.Focus();
                    return;
                }
                if (combo_manl.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    combo_manl.Focus();
                    return;
                }
                if (txt_sl.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_sl.Focus();
                    return;
                }
                if (txt_gia.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_gia.Focus();
                    return;
                }
                string sqlnl;
                //  lưu thông tin chung vào bảng chitiephieunhapkho
                //sql = "INSERT INTO Chitietphieunhapkho(MaPhieuNK, MaNL, SoLuong, thanhtien) VALUES(N'" + txt_maphieu.Text.Trim() + "', '"
                //      + "',N'" + combo_manl.SelectedValue + "',N'" + txt_sl.Text.Trim() + "'," + txt_thanhtien.Text + ")";
                //sql = "SELECT MaNL FROM Nguyenlieu WHERE MaNL=N'" +combo_manl.SelectedValue + "' AND MaPhieuNK = N'" + txt_maphieu.Text.Trim() + "'";
                //sql ="Select Manhanvien from NhanVien where Manhanvien=N'"+combo_manv.SelectedValue + "'AND MaPhieuNK =N'"+txt_maphieu.Text.Trim()+"'";

                Functions.Runsql(sql);
            }
        }
            //private void btn_taophieu_Click(object sender, EventArgs e)
            //{
            //    // Kiểm tra xem phiếu nhập tạm có tồn tại không
            //    string sqlCheck = "SELECT * FROM Phieunhapkho WHERE MaPhieuNK = N'" + txt_maphieu.Text.Trim() + "'";
            //    System.Data.DataTable dt = Functions.GetdataToTable(sqlCheck);

            //    if (dt.Rows.Count > 0)
            //    {
            //        // Sao chép dữ liệu từ bảng PhieuNhaptam sang bảng PhieuNhap
            //        //string sqlCopyPhieuNhap = "INSERT INTO PhieuNhap (MaPhieuNhap, MaNV, MaNCC, MaLoaiPhieu) " +
            //        //    "SELECT MaPhieuNhap, MaNV, MaNCC, MaLoaiPhieu FROM PhieuNhaptam";
            //        string sqlCopyPhieuNhap = "INSERT INTO Phieunhapkho(MaPhieuNK, Manhanvien, MaNCC, MaLoaiPhieu) ";
            //        Functions.RunSQL(sqlCopyPhieuNhap);

            //        // Sao chép dữ liệu từ bảng ChiTietPhieuNhap sang bảng ChiTietPhieuNhap
            //        //string sqlCopyChiTietPhieuNhap = "INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSP, SoLuong, DonGia) " +
            //        //    "SELECT MaPhieuNhap, MaSP, SoLuong, DonGia FROM ChiTietPhieuNhap";
            //        string sqlCopyChiTietPhieuNhap = "INSERT INTO Chitietphieunhapkho (MaPhieuNK, MaNL, SoLuong, thanhtien) " +
            //            "SELECT MaPhieuNK, MaNL, SoLuong, thanhtien FROM Chitietphieunhapkho";
            //        Functions.RunSQL(sqlCopyChiTietPhieuNhap);

            //        // Cập nhật cột TongTien trong bảng PhieuNhap
            //        //string sqlUpdateTongTien = "UPDATE PhieuNhap SET TongTien = " +
            //        //    "(SELECT SUM(Dongia) FROM ChiTietPhieuNhap WHERE MaPhieuNhap = N'" + txtMaPhieuNhap.Text.Trim() + "') where MaPhieuNhap = N'" + txtMaPhieuNhap.Text.Trim() + "' ";
            //        string sqlUpdateTongTien = "UPDATE Phieunhapkho SET tongsotien = " +
            //             "(SELECT SUM(thanhtien) FROM Chitietphieunhapkho WHERE MaPhieuNK = N'" + txt_maphieu.Text.Trim() + "') where MaPhieuNK = N'" + txt_maphieu.Text.Trim() + "' ";
            //        Functions.RunSQL(sqlUpdateTongTien);
            //        // Xóa dữ liệu trong bảng ChiTietPhieuNhap
            //        string sqlDeleteChiTietPhieuNhap = "DELETE FROM Chitietphieunhapkho ";
            //        Functions.RunSQL(sqlDeleteChiTietPhieuNhap);

            //        // Xóa dữ liệu trong bảng PhieuNhaptam
            //        //string sqlDeletePhieuNhapTam = "DELETE FROM PhieuNhaptam";
            //        //Functions.RunSQL(sqlDeletePhieuNhapTam);



            //        MessageBox.Show("Tạo phiếu thành công!");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không tìm thấy phiếu nhập có mã " + txt_maphieu.Text.Trim() + "");
            //    }

            //  }
       

    }
}
