using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ttcn.Class;

namespace ttcn
{
    public partial class frmphieuthuhoi : Form
    {
        public frmphieuthuhoi()
        {
            InitializeComponent();
        }

        private void frmphieuthuhoi_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();
            SqlConnection conn = Functions.Conn;
            string sqlnv = "select manv, hotennv from Nhanvien where hoatdong = 1 ";
            Functions.Fillcombo(sqlnv, cbonv, "manv", "hotennv");
            string sqlsp = "Select masp, tensp from Sanpham where matinhtrang <> 3";
            Functions.Fillcombo(sqlsp, cbtensp, "masp", "tensp");
            loaddata();
        }
        private void loaddata()
        {
            string sql = "select a.maphieuthuhoi, c.hotennv, a.ngaytao, d.tensp, b.soluong, a.ghichu    from phieuthuhoi a join chitietphieuthuhoi b on a.maphieuthuhoi = b.maphieuthuhoi join nhanvien c on a.manv = c.manv join sanpham d on b.masp = d.masp";
            DataTable data = Functions.GetdataToTable(sql);
            dtgphieuthuhoi.DataSource = data;
            dtgphieuthuhoi.Columns[0].HeaderText = "Mã phiếu";
            dtgphieuthuhoi.Columns[1].HeaderText = "Nhân viên lập";
            dtgphieuthuhoi.Columns[2].HeaderText = "Ngày tạo";
            dtgphieuthuhoi.Columns[3].HeaderText = "Sản phẩm";
            dtgphieuthuhoi.Columns[4].HeaderText = "Số lượng";
            dtgphieuthuhoi.Columns[5].HeaderText = "Chi tiết";
            // Thiết lập chế độ tự động điều chỉnh độ rộng của các cột
            dtgphieuthuhoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Thiết lập tỷ lệ phần trăm cho từng cột
            dtgphieuthuhoi.Columns[0].FillWeight = 10;   // 20%
            dtgphieuthuhoi.Columns[1].FillWeight = 20;   // 30%
            dtgphieuthuhoi.Columns[2].FillWeight = 15;   // 15%
            dtgphieuthuhoi.Columns[3].FillWeight = 20;   // 20%
            dtgphieuthuhoi.Columns[4].FillWeight = 10;   // 10%
            dtgphieuthuhoi.Columns[5].FillWeight = 20;   // 20%

        }
        private void dataload()
        {
            string sql = "select a.maphieuthuhoi, c.hotennv, a.ngaytao, d.tensp, b.soluong, d.ghichu    from phieuthuhoitam a join chitietphieuthuhoitam b on a.maphieuthuhoi = b.maphieuthuhoi join nhanvien c on a.manv = c.manv join sanpham d on b.masp = d.masp";
            DataTable data = Functions.GetdataToTable(sql);
            dtgphieuthuhoi.DataSource = data;
            dtgphieuthuhoi.Columns[0].HeaderText = "Mã phiếu";
            dtgphieuthuhoi.Columns[1].HeaderText = "Nhân viên lập";
            dtgphieuthuhoi.Columns[2].HeaderText = "Ngày tạo";
            dtgphieuthuhoi.Columns[3].HeaderText = "Sản phẩm";
            dtgphieuthuhoi.Columns[4].HeaderText = "Số lượng";
            dtgphieuthuhoi.Columns[5].HeaderText = "Chi tiết";
            // Thiết lập chế độ tự động điều chỉnh độ rộng của các cột
            dtgphieuthuhoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Thiết lập tỷ lệ phần trăm cho từng cột
            dtgphieuthuhoi.Columns[0].FillWeight = 10;   // 20%
            dtgphieuthuhoi.Columns[1].FillWeight = 20;   // 30%
            dtgphieuthuhoi.Columns[2].FillWeight = 15;   // 15%
            dtgphieuthuhoi.Columns[3].FillWeight = 20;   // 20%
            dtgphieuthuhoi.Columns[4].FillWeight = 10;   // 10%
            dtgphieuthuhoi.Columns[5].FillWeight = 20;   // 20%
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btntaophieu.Enabled = true;
            btnIn.Enabled = false;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnthemsanpham.Enabled = true;
            string maPhieuThuHoi = "TH" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // Gán mã phiếu nhập vào TextBox
            txtMaPhieuThuHoi.Text = maPhieuThuHoi;
            cbonv.Focus();
            dataload();
            txtsl.Text = "1";
        }

        private void txtsl_Enter(object sender, EventArgs e)
        {
            if(txtsl.Text == "1")
            {
                txtsl.Text = "";
            }
        }

        private void btnthemsanpham_Click(object sender, EventArgs e)
        {
            string tensp = cbtensp.Text;
            string ghichu = txtghichu.Text;
            string sql1 = "SELECT * FROM sanpham WHERE tensp = @tensp AND ghichu = @ghichu";
            SqlCommand cmdtimmasp = new SqlCommand(sql1, Functions.Conn);
            cmdtimmasp.Parameters.AddWithValue("@tensp", tensp);
            cmdtimmasp.Parameters.AddWithValue("@ghichu", ghichu);
            SqlDataReader reader = cmdtimmasp.ExecuteReader();

            if (reader.Read())
            {
                string masp = reader["masp"].ToString();
                reader.Close();

                string sqlTimPhieu = "SELECT maphieuthuhoi FROM phieuthuhoitam WHERE maphieuthuhoi = '" + txtMaPhieuThuHoi.Text.Trim() + "'";
                SqlCommand cmdTimPhieu = new SqlCommand(sqlTimPhieu, Functions.Conn);
                object result = cmdTimPhieu.ExecuteScalar();

                if (result != null)
                {
                    string sqlTimCTPhieu = "SELECT * FROM chitietphieuthuhoitam WHERE maphieuthuhoi = '" + txtMaPhieuThuHoi.Text.Trim() + "' AND masp = @masp";
                    SqlCommand cmdTimCTPhieu = new SqlCommand(sqlTimCTPhieu, Functions.Conn);
                    cmdTimCTPhieu.Parameters.AddWithValue("@masp", masp);
                    SqlDataReader readerCTPhieu = cmdTimCTPhieu.ExecuteReader();

                    if (readerCTPhieu.Read())
                    {
                        readerCTPhieu.Close();
                        string sqlUpdate = "UPDATE chitietphieuthuhoitam SET soluong = soluong + " + txtsl.Text.Trim() + " WHERE maphieuthuhoi = '" + txtMaPhieuThuHoi.Text.Trim() + "' AND masp = @masp";
                        SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, Functions.Conn);
                        cmdUpdate.Parameters.AddWithValue("@masp", masp);
                        cmdUpdate.ExecuteNonQuery();
                    }
                    else
                    {
                        readerCTPhieu.Close ();
                        string sqlInsertCTPhieu = "INSERT INTO chitietphieuthuhoitam VALUES ('" + txtMaPhieuThuHoi.Text.Trim() + "', @masp, '" + txtsl.Text.Trim() + "')";
                        SqlCommand cmdInsertCTPhieu = new SqlCommand(sqlInsertCTPhieu, Functions.Conn);
                        cmdInsertCTPhieu.Parameters.AddWithValue("@masp", masp);
                        cmdInsertCTPhieu.ExecuteNonQuery();
                    }

                    readerCTPhieu.Close();
                }
                else
                {
                    string sqlInsertPhieu = "INSERT INTO phieuthuhoitam (maphieuthuhoi, manv) VALUES ('" + txtMaPhieuThuHoi.Text.Trim() + "', '" + cbonv.SelectedValue.ToString() + "')";
                    SqlCommand cmdInsertPhieu = new SqlCommand(sqlInsertPhieu, Functions.Conn);
                    cmdInsertPhieu.ExecuteNonQuery();

                    string sqlInsertCTPhieu = "INSERT INTO chitietphieuthuhoitam VALUES ('" + txtMaPhieuThuHoi.Text.Trim() + "', @masp, '" + txtsl.Text.Trim() + "')";
                    SqlCommand cmdInsertCTPhieu = new SqlCommand(sqlInsertCTPhieu, Functions.Conn);
                    cmdInsertCTPhieu.Parameters.AddWithValue("@masp", masp);
                    cmdInsertCTPhieu.ExecuteNonQuery();
                }

                reader.Close();
            }
            else
            {
                reader.Close();
                string sqlSelectSP = "SELECT * FROM sanpham WHERE masp = '" + cbtensp.SelectedValue.ToString() + "'";
                SqlCommand cmdSelectSP = new SqlCommand(sqlSelectSP, Functions.Conn);
                SqlDataReader readerSP = cmdSelectSP.ExecuteReader();

                if (readerSP.Read())
                {
                    string chitiet = readerSP["chitietsp"].ToString();
                    float gia = float.Parse(readerSP["gia"].ToString());
                    int maloaisp = int.Parse(readerSP["maloaisp"].ToString());
                    int mahang = int.Parse(readerSP["mahang"].ToString());
                    readerSP.Close();
                    string sqlInsertSP = "INSERT INTO sanpham (tensp, chitietsp, gia, ghichu, maloaisp, mahang, matinhtrang) VALUES (N'" + cbtensp.Text.Trim() + "', @chitiet, @gia, N'" + txtghichu.Text.Trim() + "', @maloaisp, @mahang, '3')";
                    SqlCommand cmdInsertSP = new SqlCommand(sqlInsertSP, Functions.Conn);
                    cmdInsertSP.Parameters.AddWithValue("@chitiet", chitiet);
                    cmdInsertSP.Parameters.AddWithValue("@gia", gia);
                    cmdInsertSP.Parameters.AddWithValue("@maloaisp", maloaisp);
                    cmdInsertSP.Parameters.AddWithValue("@mahang", mahang);
                    cmdInsertSP.ExecuteNonQuery();

                    string sqlGetMaSP = "SELECT MaSP FROM sanpham WHERE tensp = N'" + cbtensp.Text.Trim() + "' AND ghichu = N'" + txtghichu.Text.Trim() + "'";
                    SqlCommand cmdGetMaSP = new SqlCommand(sqlGetMaSP, Functions.Conn);
                    object maSPResult = cmdGetMaSP.ExecuteScalar();

                    if (maSPResult != null && int.TryParse(maSPResult.ToString(), out int maSP))
                    {
                        string sqlTimPhieu = "SELECT maphieuthuhoi FROM phieuthuhoitam WHERE maphieuthuhoi = '" + txtMaPhieuThuHoi.Text.Trim() + "'";
                        SqlCommand cmdTimPhieu = new SqlCommand(sqlTimPhieu, Functions.Conn);
                        object result = cmdTimPhieu.ExecuteScalar();

                        if (result != null)
                        {
                            string sqlTimCTPhieu = "SELECT * FROM chitietphieuthuhoitam WHERE maphieuthuhoi = '" + txtMaPhieuThuHoi.Text.Trim() + "' AND masp = @masp";
                            SqlCommand cmdTimCTPhieu = new SqlCommand(sqlTimCTPhieu, Functions.Conn);
                            cmdTimCTPhieu.Parameters.AddWithValue("@masp", maSP);
                            SqlDataReader readerCTPhieu = cmdTimCTPhieu.ExecuteReader();

                            if (readerCTPhieu.Read())
                            {
                                readerCTPhieu.Close();
                                string sqlUpdate = "UPDATE chitietphieuthuhoitam SET soluong = soluong + " + txtsl.Text.Trim() + " WHERE maphieuthuhoi = '" + txtMaPhieuThuHoi.Text.Trim() + "' AND masp = @masp";
                                SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, Functions.Conn);
                                cmdUpdate.Parameters.AddWithValue("@masp", maSP);
                                cmdUpdate.ExecuteNonQuery();
                            }
                            else
                            {
                                readerCTPhieu.Close();
                                string sqlInsertCTPhieu = "INSERT INTO chitietphieuthuhoitam VALUES ('" + txtMaPhieuThuHoi.Text.Trim() + "', @masp, '" + txtsl.Text.Trim() + "')";
                                SqlCommand cmdInsertCTPhieu = new SqlCommand(sqlInsertCTPhieu, Functions.Conn);
                                cmdInsertCTPhieu.Parameters.AddWithValue("@masp", maSP);
                                cmdInsertCTPhieu.ExecuteNonQuery();
                            }

                            readerCTPhieu.Close();
                        }
                        else
                        {
                            string sqlInsertPhieu = "INSERT INTO phieuthuhoitam (maphieuthuhoi, manv) VALUES ('" + txtMaPhieuThuHoi.Text.Trim() + "', '" + cbonv.SelectedValue.ToString() + "')";
                            SqlCommand cmdInsertPhieu = new SqlCommand(sqlInsertPhieu, Functions.Conn);
                            cmdInsertPhieu.ExecuteNonQuery();

                            string sqlInsertCTPhieu = "INSERT INTO chitietphieuthuhoitam VALUES ('" + txtMaPhieuThuHoi.Text.Trim() + "', @masp, '" + txtsl.Text.Trim() + "')";
                            SqlCommand cmdInsertCTPhieu = new SqlCommand(sqlInsertCTPhieu, Functions.Conn);
                            cmdInsertCTPhieu.Parameters.AddWithValue("@masp", maSP);
                            cmdInsertCTPhieu.ExecuteNonQuery();
                        }
                    }
                }

                readerSP.Close();
                
            }
            dataload();
        }

        private void btntaophieu_Click(object sender, EventArgs e)
        {
            // Chuyển dữ liệu từ bảng Phiếu thu hồi tạm sang bảng Phiếu thu hồi
            string insertPhieuThuHoiSql = "INSERT INTO PhieuThuHoi SELECT * FROM PhieuThuHoiTam";
            Functions.RunSQL(insertPhieuThuHoiSql);

            // Chuyển dữ liệu từ bảng Chi tiết phiếu thu hồi tạm sang bảng Chi tiết phiếu thu hồi
            string insertChiTietPhieuThuHoiSql = "INSERT INTO ChiTietPhieuThuHoi  SELECT * FROM ChiTietPhieuThuHoiTam";
            Functions.RunSQL(insertChiTietPhieuThuHoiSql);
            // Xóa dữ liệu trong bảng Chi tiết phiếu thu hồi tạm
            string deleteChiTietPhieuThuHoiTamSql = "DELETE FROM ChiTietPhieuThuHoiTam";
            Functions.RunSQL(deleteChiTietPhieuThuHoiTamSql);
            // Xóa dữ liệu trong bảng Phiếu thu hồi tạm
            string deletePhieuThuHoiTamSql = "DELETE FROM PhieuThuHoiTam";
            Functions.RunSQL(deletePhieuThuHoiTamSql);
            MessageBox.Show("Tạo phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmphieuthuhoi_Load(sender, e);
            bandau();


        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu trong bảng Chi tiết phiếu thu hồi tạm
            string deleteChiTietPhieuThuHoiTamSql = "DELETE FROM ChiTietPhieuThuHoiTam";
            Functions.RunSQL(deleteChiTietPhieuThuHoiTamSql);
            // Xóa dữ liệu trong bảng Phiếu thu hồi tạm
            string deletePhieuThuHoiTamSql = "DELETE FROM PhieuThuHoiTam";
            Functions.RunSQL(deletePhieuThuHoiTamSql);
            frmphieuthuhoi_Load(sender, e);
            bandau();
            
        }
        private void bandau()
        {
            btnThem.Enabled = true;
            btnthemsanpham.Enabled = false;
            btntaophieu.Enabled = false;
            btnHuy.Enabled = false;
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgphieuthuhoi_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if(btnThem.Enabled)
            {
                string mapth = dtgphieuthuhoi.CurrentRow.Cells["maphieuthuhoi"].Value.ToString();
                string sql = "delete from chitietphieuthuhoi where maphieuthuhoi = '" + mapth + "'";
                Functions.RunSQL(sql);
                string sql1 = "delete from phieuthuhoi where maphieuthuhoi = '" + mapth + "'";
                Functions.RunSQL(sql1);
                loaddata();
            }
            else
            {
                string tensp = dtgphieuthuhoi.CurrentRow.Cells["tensp"].Value.ToString();
                string ghichu = dtgphieuthuhoi.CurrentRow.Cells[5].Value.ToString();
                string sql1 = "select masp from sanpham where tensp = '" + tensp + "' and ghichu = '" + ghichu + "'";
                SqlCommand cmdtimmasp = new SqlCommand(sql1, Functions.Conn);
                SqlDataReader readerMSP = cmdtimmasp.ExecuteReader();
                readerMSP.Read();
                string masp = readerMSP["masp"].ToString();
                readerMSP.Close();
                string mapth = dtgphieuthuhoi.CurrentRow.Cells["maphieuthuhoi"].Value.ToString();
                
                string sql = "delete from chitietphieuthuhoitam where maphieuthuhoi = '" + mapth + "' and masp = '"+masp+"'";
                Functions.RunSQL(sql);
                dataload(); 
            }*/
            


        }

        private void dtgphieuthuhoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled)
            {
                string mapth = dtgphieuthuhoi.CurrentRow.Cells["maphieuthuhoi"].Value.ToString();
                string sql = "delete from chitietphieuthuhoi where maphieuthuhoi = '" + mapth + "'";
                Functions.RunSQL(sql);
                string sql1 = "delete from phieuthuhoi where maphieuthuhoi = '" + mapth + "'";
                Functions.RunSQL(sql1);
                loaddata();
            }
            else
            {
                string tensp1 = dtgphieuthuhoi.CurrentRow.Cells["tensp"].Value.ToString();
                string ghichu1 = dtgphieuthuhoi.CurrentRow.Cells["ghichu"].Value.ToString();

                string sql1 = "SELECT * FROM sanpham WHERE tensp = @tensp AND ghichu = @ghichu";
                SqlCommand cmdtimmasp = new SqlCommand(sql1, Functions.Conn);
                cmdtimmasp.Parameters.AddWithValue("@tensp", tensp1);
                cmdtimmasp.Parameters.AddWithValue("@ghichu", ghichu1);

                SqlDataReader readerMSP = cmdtimmasp.ExecuteReader();

                if (readerMSP.Read())
                {
                    string masp = readerMSP["masp"].ToString();
                    readerMSP.Close();

                    string mapth = dtgphieuthuhoi.CurrentRow.Cells["maphieuthuhoi"].Value.ToString();
                    string sql = "DELETE FROM chitietphieuthuhoitam WHERE maphieuthuhoi = @mapth AND masp = @masp";
                    SqlCommand cmdDelete = new SqlCommand(sql, Functions.Conn);
                    cmdDelete.Parameters.AddWithValue("@mapth", mapth);
                    cmdDelete.Parameters.AddWithValue("@masp", masp);
                    cmdDelete.ExecuteNonQuery();

                    dataload();
                }
                else
                {
                    readerMSP.Close();

                    // Xử lý tình huống khi không có dữ liệu
                }

            }
        }
    }
}
