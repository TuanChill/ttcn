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
    public partial class PhieuNK : Form
    {
        public PhieuNK()
        {
            InitializeComponent();
        }

        private void PhieuNK_Load(object sender, EventArgs e)
        {
            Class.Functions.Ketnoi();
            SqlConnection conn = Functions.Conn;
            string sql = "SELECT Manhanvien, Tennhanvien FROM NhanVien ";
            Functions.Fillcombo(sql, combo_nv, "Manhanvien", "Tennhanvien");
            //string sql1 = "SELECT MaNL, TenNL FROM Nguyenlieu where MaTT <> 4"; // trong txt_ma nl hiển thị danh sách tên để dễ chọn
            //Functions.Fillcombo(sql1, combo_ten, "MaNL", "TenNL");
            Functions.Fillcombo("SELECT MaNL, TenNL FROM Nguyenlieu", combo_ten, "MaNL", "TenNL");
            string sql2 = "SELECT MaNCC, TenNCC FROM NhaCungCap";
            Functions.Fillcombo(sql2, combo_ncc, "MaNCC", "TenNCC");

            //string sql3 = "SELECT MaNL, TenNL FROM Nguyenlieu where MaTT <> 4";
            //Functions.Fillcombo(sql3, combo_masp, "MaNL", "TenNL");



            combo_nv.SelectedIndex = -1;
            combo_ncc.SelectedIndex = -1;
            
            combo_ten.SelectedIndex = -1;
            // combo_masp.SelectedIndex = -1;
            txt_sl.Text = "0";
            txt_gia.Text = "0";
            txt_ttien.Text = "0";

            //  txt_ttien.Text = "0";
            //loadThanhTien();

            Loaddata();
            // loadtongtien();
         
             btn_luu.Enabled = false;
             txt_ma.Enabled = false;
             btnHuy.Enabled = false;
            //tinhTien();
            Load_ThongtinHD();

        }
        private void Load_ThongtinHD()
        {
            string str;
       
            str = "SELECT thanhtien FROM Chitietphieunhapkho WHERE MaPhieuNK = N'" + txt_ma.Text + "'";
            txt_ttien.Text = Functions.GetFieldValues(str);

            lb_bangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txt_ttien.Text);
        }


        private void Loaddata()
        {
            string sql = "SELECT a.MaPhieuNK,b.MaNL, b.TenNL, a.SoLuong, a.thanhtien " +
               "FROM Chitietphieunhapkho AS a " +
               "JOIN Nguyenlieu AS b ON a.MaNL = b.MaNL " +
              "JOIN NhaCungCap AS c ON b.MaNCC = c.MaNCC "+
               " ORDER BY a.MaPhieuNK ASC";
            dt = Functions.GetdataToTable(sql);
            // Lấy dữ liệu từ CSDL và gán vào DataTable
            System.Data.DataTable dataTable = Class.Functions.GetdataToTable(sql);

            // Gán DataTable cho DataGridView để hiển thị dữ liệu
            datagridview_nguyenlieu.DataSource = dataTable;

            // Đặt lại tiêu đề cho các cột
            //maphieunk,manguyenlieu, tennguyenlieu, ngaytao, nhanvien, gia,soluong, nhacungcap, thanhtien
            datagridview_nguyenlieu.Columns[0].HeaderText = "Mã Phiếu nhập kho";
            datagridview_nguyenlieu.Columns[1].HeaderText = "Mã nguyên liệu";
            datagridview_nguyenlieu.Columns[2].HeaderText = "Tên nguyên liệu";
            // dtgphieunhapkho.Columns[2].HeaderText = "Ngày tạo";
          // datagridview_nguyenlieu.Columns[3].HeaderText = "Ngày tạo";
          //  datagridview_nguyenlieu.Columns[4].HeaderText = "Nhân viên";
          //  datagridview_nguyenlieu.Columns[5].HeaderText = "Giá";
            datagridview_nguyenlieu.Columns[3].HeaderText = "Số lượng";
            // datagridview_nguyenlieu.Columns[3].HeaderText = "Số lượng";
           // datagridview_nguyenlieu.Columns[7].HeaderText = "Nhà cung cấp";
            datagridview_nguyenlieu.Columns[4].HeaderText = "Thành tiền";

            //// Đặt lại độ rộng cho các cột
            datagridview_nguyenlieu.Columns[0].Width = 100;
            datagridview_nguyenlieu.Columns[1].Width = 150;
            datagridview_nguyenlieu.Columns[2].Width = 150;
            datagridview_nguyenlieu.Columns[3].Width = 150;
           datagridview_nguyenlieu.Columns[4].Width = 100;
          

            datagridview_nguyenlieu.AllowUserToAddRows = false;
            datagridview_nguyenlieu.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        DataTable dt;
        private void datagridview_nguyenlieu_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txt_ma.Focus();
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào được hiển thị", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            txt_ma.Text = datagridview_nguyenlieu.CurrentRow.Cells["MaPhieuNK"].Value.ToString();
            string manl,mancc,manv,maphieunk;
            manl = datagridview_nguyenlieu.CurrentRow.Cells["MaNL"].Value.ToString();
            maphieunk = datagridview_nguyenlieu.CurrentRow.Cells["MaPhieuNK"].Value.ToString();
            combo_ten.Text = Functions.GetFieldValues("SELECT TenNL FROM Nguyenlieu WHERE MaNL = N'" + manl + "'");
            combo_nv.Text = Functions.GetFieldValues("select Tennhanvien from Nhanvien as a JOIN Phieunhapkho AS b ON a.Manhanvien = b.Manhanvien  WHERE MaPhieuNK = N'" + maphieunk + "'");
            combo_ncc.Text = Functions.GetFieldValues("select TenNCC from Nguyenlieu as a JOIN NhaCungCap AS b ON a.MaNCC = b.MaNCC WHERE MaNL = N'" + manl + "'");
            txt_sl.Text = datagridview_nguyenlieu.CurrentRow.Cells["SoLuong"].Value.ToString();
            txt_ttien.Text = datagridview_nguyenlieu.CurrentRow.Cells["thanhtien"].Value.ToString();
            
            btnIn.Enabled = true;

            btnHuy.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btntaophieu.Enabled = true;
            btnIn.Enabled = false;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btn_luu.Enabled = true;
            // 
            //string maPhieuNhap = DateTime.Now.ToString("ydMM");
            //txt_ma.Text =Functions.CreateKey(maPhieuNhap);
            // int maPN = Convert.ToInt32(maPhieuNhap);
            //// btnThem.Enabled = false;
            string maPhieuNhap =  DateTime.Now.ToString("HHss");
            // 240515183724 24051518 245151825
            //// Gán mã phiếu nhập vào TextBox
            //txt_ma.Text = maPhieuNhap;
           string key = Functions.CreateKey("MaPhieuNK");
            txt_ma.Text = key;
            ResetValues();
            txt_ma.Enabled = true;
            txt_ma.Focus();
           
            // Gán mã phiếu nhập vào TextBox
           txt_ma.Text = maPhieuNhap;
            combo_nv.Focus();


            
            Loaddata();
        }
        private void ResetValues()
        {
            txt_ma.Text = "";
            dtngaytao.Text = "";
            //combo_nv.Text = "";
            //combo_ten.Text = "";
           // combo_ncc.Text = "";
            txt_sl.Text = "0";
            txt_gia.Text = "0";
            txt_ttien.Text = "0";
            txt_ttien.Enabled=false;
            combo_nv.SelectedIndex = -1;
            combo_ncc.SelectedIndex = -1;

            combo_ten.SelectedIndex = -1;

        }
        


        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát nhập kho không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                // Application.Exit();
                main mainForm = new main();
                mainForm.Show();
                
                
                return;
            }
        }

        //private void datagridview_nguyenlieu_DoubleClick(object sender, EventArgs e)
        //{
        //    string mapn;
        //    if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        mapn = datagridview_nguyenlieu.CurrentRow.Cells["MaPhieuNK"].Value.ToString();
        //        PhieuNK frm = new PhieuNK();
        //        frm.txt_ma.Text = mapn;
        //        frm.StartPosition = FormStartPosition.CenterScreen;
        //        frm.ShowDialog();
        //    }

        //}

    

        private void btnIn_Click(object sender, EventArgs e)
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
            exRange.Range["A2:B2"].Value = "Công ty TNHH Sản xuất - Kinh doanh thương mại và dịch vụ Tín Phát";

            exRange.Range["B3"].MergeCells = true;
            exRange.Range["B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B3"].Value = "Địa chỉ: Bắc Từ Liêm - Hà Nội";

            exRange.Range["B4"].MergeCells = true;
            exRange.Range["B4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B4"].Value = "Điện thoại: 0906 249 090";


            exRange.Range["A1:Z1"].Font.Size = 16;
            exRange.Range["A1:Z1"].Font.Name = "Times new roman";
            exRange.Range["A1:Z1"].Font.Bold = true;
            exRange.Range["A1:Z1"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["A1:Z1"].MergeCells = true;
            exRange.Range["A1:Z1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:Z1"].Value = "PHIẾU ĐĂNG NHẬP";
            // Biểu diễn thông tin chung của hóa đơn bán
           sql= "SELECT a.MaPhieuNK, b.TenNL, a.SoLuong, a.thanhtien " +
               "FROM Chitietphieunhapkho AS a " +
               "JOIN Nguyenlieu AS b ON a.MaNL = b.MaNL " +
               " ORDER BY a.MaPhieuNK ASC";
            tblThongtinphieu = Functions.GetdataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã phiếu:";
            exRange.Range["C6:D6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinphieu.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Tên nguyên liệu:";
            exRange.Range["C7:D7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinphieu.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Số lượng:";
            exRange.Range["C8:D8"].MergeCells = true;
            //exRange.Range["C8:E8"].Value = tblThongtinphieu.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Thành tiền:";
            exRange.Range["C9:D9"].MergeCells = true;
            exRange.Range["C9:D9"].Value = txt_ttien;
            //exRange.Range["C9:E9"].Value = tblThongtinphieu.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT a.MaPhieuNK, b.TenNL, a.SoLuong, a.thanhtien " +
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
            sql = "SELECT MaPhieuNK FROM Chitietphieunhapkho WHERE MaPhieuNK=N'" + txt_ma.Text + "'";
            if (!Functions.Checkkey(sql))
            {
                // Mã phiếu chưa có, tiến hành lưu các thông tin chung
                // Mã phiếu nk được sinh tự động do đó không có trường hợp trùng khóa
                if (dtngaytao.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn ngày ", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtngaytao.Focus();
                    return;
                }
                if (combo_nv.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    combo_nv.Focus();
                    return;
                }
                if (combo_ten.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nguyên liệu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    combo_ten.Focus();
                    return;
                }
                if (txt_sl.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_sl.Focus();
                    return;
                }
                if (combo_ncc.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    combo_ten.Focus();
                    return;
                }
                if (txt_gia.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    combo_ten.Focus();
                    return;
                }
                //lưu thông tin chung vào bảng 
                sql = "INSERT INTO Chitietphieunhapkho(MaPhieuNK, MaNL, SoLuong, thanhtien) VALUES(N'" + txt_ma.Text.Trim() + "', '" 
                      + "',N'" + combo_ten.SelectedValue + "',N'" +txt_sl.Text.Trim() + "'," + txt_ttien.Text + ")";
                
                Functions.Runsql(sql);
            }

           
            if (Functions.Checkkey(sql))
            {
                MessageBox.Show("Mã nguyên liệu này đã có, vui lòng nhập mã khác", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
                combo_ten.Focus();
                return;
            }
//            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
//            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT soluong FROM Hangtonkho WHERE MaNL = N'" + combo_ten.SelectedValue + "'"));
//            if (Convert.ToDouble(txt_sl.Text) > sl)
//            {
//                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                txt_sl.Text = "";
//                txt_sl.Focus();
//                return;
//            }
//            sql = "INSERT INTO Chitietphieunhapkho(MaPhieuNK,MaNL,SoLuong,Thanhtien)" +
//                " VALUES(N'" + txt_ma.Text.Trim() + "', N'" + combo_ten.SelectedValue + 
//"'," + txt_sl.Text + ",," +  txt_ttien.Text + "'";
//            Functions.Runsql(sql);
//            Loaddata();
//            // Cập nhật lại số lượng của mặt hàng vào bảng hangtonkho
//            SLcon = sl - Convert.ToDouble(txt_sl.Text);
//            sql = "UPDATE Hangtonkho SET soluong =" + SLcon + " WHERE MaNL= N'" +combo_ten.SelectedValue + "'";
//            Functions.Runsql(sql);
//            // Cập nhật lại tổng tiền 

//            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT tongsotien FROM Phieunhapkho WHERE MaPhieuNK = N'" + txt_ma.Text + "'"));
//            Tongmoi = tong + Convert.ToDouble(txttongtien.Text);
//            sql = "UPDATE Phieunhapkho SET Tongtien =" + Tongmoi + " WHERE MaPhieuNK = N'" + txttongtien.Text + "'";
//            Functions.Runsql(sql);
//            txttongtien.Text = Tongmoi.ToString();
//            lb_bangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
            ResetValues();
           
            btnThem.Enabled = true;
            btnIn.Enabled = true;

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;// đang 
            btnThem.Enabled = true;
            btnIn.Enabled = true;
           
            btn_luu.Enabled = false;
            txt_ma.Enabled = false;
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

                txt_ttien.Text = formattedThanhTien;
            }
            else
            {
                txt_ttien.Text = "0";
            }

        }
    }
}
