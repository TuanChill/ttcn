using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using ttcn.Class;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace ttcn
{
    public partial class PNK : Form
    {
        public DataTable DataTable;

        public PNK()
        {
            InitializeComponent();
            DataTable = new DataTable();
            DataTable.Columns.Add("MaNL", typeof(string));
            DataTable.Columns.Add("TenNL", typeof(string));
            DataTable.Columns.Add("SoLuong", typeof(string));
            DataTable.Columns.Add("DonGia", typeof(string));
            DataTable.Columns.Add("ThanhTien", typeof(string));

            // disable mã phiếu
            txt_maphieu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát nhập kho không?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Application.Exit();
                main mainForm = new main();
                mainForm.Show();
                this.Hide();
                return;
            }
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
                if (thanhTien >= 1000) // Display with thousands separator and decimals only if necessary
                {
                    formattedThanhTien = thanhTien.ToString("0,0.###", CultureInfo.GetCultureInfo("vi-VN"));
                }
                else // Display without thousands separator or decimals for values less than 1000
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
            // kiểm tra rỗng các trường dữ liệu nguyên liệu
            if (combo_manl.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nguyên liệu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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

            // kiểm tra nguyên liệu đã ở trong danh sách chưa
            foreach (DataRow r in DataTable.Rows)
            {
                if (r["MaNL"].ToString() == combo_manl.SelectedValue.ToString())
                {
                    MessageBox.Show("Nguyên liệu đã tồn tại trong danh sách", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            // thêm các dữ liệu input vào datatable
            DataRow row = DataTable.NewRow();
            row["MaNL"] = combo_manl.SelectedValue;
            row["TenNL"] = combo_manl.Text;
            row["SoLuong"] = txt_sl.Text;
            row["DonGia"] = txt_gia.Text;
            row["ThanhTien"] = txt_thanhtien.Text;
            DataTable.Rows.Add(row);

            // hiển thị dữ liệu lên datagridview
            datagridview_nguyenlieu.DataSource = DataTable;

            // auto resize datagridview
            datagridview_nguyenlieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            datagridview_nguyenlieu.Columns["MaNL"].Visible = false;
            datagridview_nguyenlieu.Columns["TenNL"].HeaderText = "Tên nguyên liệu";
            datagridview_nguyenlieu.Columns["SoLuong"].HeaderText = "Số lượng";
            datagridview_nguyenlieu.Columns["DonGia"].HeaderText = "Đơn giá";
            datagridview_nguyenlieu.Columns["ThanhTien"].HeaderText = "Thành tiền";

            // tính tổng tiền
            decimal tongTien = 0;
            foreach (DataRow r in DataTable.Rows)
            {
                tongTien += Decimal.Parse(r["ThanhTien"].ToString());
            }

            tinhtongtien();
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
            txt_sl.Text = "0";
            txt_gia.Text = "0";
            txt_thanhtien.Text = "0";
            txt_thanhtien.Enabled = false;
            combo_manv.SelectedIndex = -1;
            txt_tongtien.Text = "0";
            combo_manl.SelectedIndex = -1;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            btn_huy.Enabled = false; // đang 
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
                  txt_maphieu.Text +
                  "' AND a.MaPhieuNK = e.MaPhieuNK AND a.Manhanvien =c.Manhanvien AND d.MaNCC=b.MaNCC ";

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
            int id;
            if (combo_manv.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                combo_manv.Focus();
                return;
            }

            if (datagridview_nguyenlieu.Rows.Count == 0)
            {
                MessageBox.Show("Bạn phải nhập nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // convert dtngaytao to date data in sql
            string date = dtngaytao.Value.ToString("yyyy-MM-dd");
            try
            {
                // Thực hiện INSERT
                sql = "INSERT INTO Phieunhapkho ( NgayTao, Manhanvien, tongsotien) VALUES (N'" + date + "', N'" +
                      combo_manv.SelectedValue + "', N'" + txt_tongtien.Text + "')";
                using (SqlConnection connection = new SqlConnection(Functions.connstring))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();

                        // Lấy ID bản ghi vừa tạo
                        command.CommandText = "SELECT @@IDENTITY";
                        id = Convert.ToInt32(command.ExecuteScalar());
                        Console.WriteLine("Inserted ID: " + id);
                    }
                }

                // Thực hiện INSERT vào bảng chi tiết phiếu nhập
                foreach (DataRow r in DataTable.Rows)
                {
                    sql = "INSERT INTO Chitietphieunhapkho (MaPhieuNK, MaNL, SoLuong, ThanhTien) VALUES (N'" + id +
                          "', N'" + r["MaNL"] + "', N'" + r["SoLuong"] + "', N'" + r["ThanhTien"] + "')";
                    Functions.Runsql(sql);

                    // cộng số lượng nguyên liệu vào bảng nguyên liệu
                    sql = "UPDATE Nguyenlieu SET SoLuong = SoLuong + " + r["SoLuong"] + " WHERE MaNL = N'" + r["MaNL"] + "'";
                    Functions.Runsql(sql);
                }

                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void PNK_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();
            // add data to combobox
            Functions.Fillcombo("SELECT Manhanvien, Tennhanvien FROM NhanVien", combo_manv, "Manhanvien",
                "Tennhanvien");
            Functions.Fillcombo("SELECT MaNL, TenNL FROM Nguyenlieu", combo_manl, "MaNL", "TenNL");
            Console.WriteLine(combo_manl);
            ResetValues();
        }

        private void combo_manl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Functions.Ketnoi();
            // lấy giá trị của nguyên liệu
            if (combo_manl.SelectedValue != null)
            {
                string selectedValue = combo_manl.SelectedValue.ToString();

                if (!string.IsNullOrEmpty(selectedValue))
                {
                    string sql = "SELECT * FROM Nguyenlieu WHERE MaNL = @MaNL";
                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, Functions.Conn))
                        {
                            command.Parameters.AddWithValue("@MaNL", selectedValue);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    txt_gia.Text = reader["Gia"].ToString();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void txt_sl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
            tinhTien();
        }

        private void datagridview_nguyenlieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // lấy dòng được chọn và hiển thị lên các input
            int i = datagridview_nguyenlieu.CurrentRow.Index;

            combo_manl.Text = datagridview_nguyenlieu.Rows[i].Cells[1].Value.ToString();
            txt_sl.Text = datagridview_nguyenlieu.Rows[i].Cells[2].Value.ToString();
            txt_gia.Text = datagridview_nguyenlieu.Rows[i].Cells[3].Value.ToString();
            txt_thanhtien.Text = datagridview_nguyenlieu.Rows[i].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // sửa số lượng nguyên liệu
            if (datagridview_nguyenlieu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (combo_manl.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                combo_manl.Focus();
                return;
            }

            if (txt_sl.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_sl.Focus();
                return;
            }

            // kiểm tra nguyên liệu đã ở trong danh sách chưa
            foreach (DataRow r in DataTable.Rows)
            {
                if (r["MaNL"].ToString() == combo_manl.SelectedValue.ToString())
                {
                    r["SoLuong"] = txt_sl.Text;
                    r["DonGia"] = txt_gia.Text;
                    r["ThanhTien"] = txt_thanhtien.Text;
                    break;
                }
            }

            // hiển thị dữ liệu lên datagridview
            datagridview_nguyenlieu.DataSource = DataTable;
        }

        public void tinhtongtien()
        {
            decimal tongTien = 0;
            foreach (DataRow r in DataTable.Rows)
            {
                tongTien += Decimal.Parse(r["ThanhTien"].ToString());
            }

            txt_tongtien.Text = tongTien.ToString();
        }
    }
}