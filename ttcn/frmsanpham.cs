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
    public partial class frmsanpham : Form
    {
        public frmsanpham()
        {
            InitializeComponent();
        }

        private void frmsanpham_Load(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            // Kết nối tới cơ sở dữ liệu
            Class.Functions.Ketnoi();
            SqlConnection conn = Functions.Conn;
            

            // Load dữ liệu
            LoadData();
            dtgsanpham.Columns[0].HeaderText = "Mã sản phẩm";
            dtgsanpham.Columns[1].HeaderText = "Tên sản phẩm";
            dtgsanpham.Columns[2].HeaderText = "Tình trạng";
            dtgsanpham.Columns[3].HeaderText = "Loại";
            dtgsanpham.Columns[4].HeaderText = "Hãng";
            dtgsanpham.Columns[6].HeaderText = "Ghi chú";
            dtgsanpham.Columns[5].HeaderText = "Thông số kỹ thuật";
            dtgsanpham.Columns[7].HeaderText = "Giá";

            // Đặt trường txtmasp thành chỉ đọc
            txtmasp.ReadOnly = true;

            // Đổ dữ liệu vào ComboBox cbhang
            string queryHang = "SELECT MaHang, TenHang FROM Hang";
            Functions.Fillcombo(queryHang, cbhang, "MaHang", "TenHang");

            // Đổ dữ liệu vào ComboBox cbtinhtrang
            string queryTinhTrang = "SELECT MaTinhTrang, TenTinhTrang FROM TinhTrang";
            Functions.Fillcombo(queryTinhTrang, cbtinhtrang, "MaTinhTrang", "TenTinhTrang");

            // Đổ dữ liệu vào ComboBox cbloai
            string queryLoai = "SELECT MaLoaiSP, TenLoaiSP FROM LoaiSanPham";
            Functions.Fillcombo(queryLoai, cbloai, "MaLoaiSP", "TenLoaiSP");

            // Đặt trường txtmasp thành chỉ đọc
            txtmasp.ReadOnly = true;

        }


        private void dtgsanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            txttensanpham.Text = "";
            txttensanpham.Focus();
            
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            // Lấy giá trị mã hãng từ ComboBox cbhang
            //string maHang = cbhang.SelectedValue.ToString();

            // Lấy giá trị mã tình trạng từ ComboBox cbtinhtrang
            //string maTinhTrang = cbtinhtrang.SelectedValue.ToString();

            // Lấy giá trị mã loại từ ComboBox cbloai
            //string maLoai = cbloai.SelectedValue.ToString();

            // Thực hiện các thao tác cần thiết để thêm dữ liệu vào cơ sở dữ liệu, sử dụng maHang, maTinhTrang, maLoai
            // ...
            txtmasp.Clear();
            txttensanpham.Clear();
            cbhang.SelectedIndex = -1;
            cbloai.SelectedIndex = -1;
            cbtinhtrang.SelectedIndex = -1;
            txtgia.Clear();
            txtghichu.Clear();
            txtchitietsanpham.Clear();
            btnsua.Enabled = false;
            btnxoa.Enabled = false;

            // Lấy mã sản phẩm lớn nhất trong bảng sản phẩm
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(MaSP) FROM SanPham";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxMaSP = Convert.ToInt32(result);
                // Tăng mã sản phẩm lên 1 và hiển thị trong txtmasp
                txtmasp.Text = (maxMaSP + 1).ToString();
            }
            else
            {
                // Nếu không có sản phẩm nào trong bảng, gán mã sản phẩm mặc định là 1
                txtmasp.Text = "1";
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            
            btnluu.Enabled = false;
            
            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(txtmasp.Text) || string.IsNullOrEmpty(txttensanpham.Text) || string.IsNullOrEmpty(cbhang.Text) || string.IsNullOrEmpty(cbtinhtrang.Text) || string.IsNullOrEmpty(cbloai.Text) || string.IsNullOrEmpty(txtgia.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm và nhập đầy đủ thông tin cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ các điều khiển
            int maSP = Convert.ToInt32(txtmasp.Text);
            string tensp = txttensanpham.Text;
            int maHang = Convert.ToInt32(cbhang.SelectedValue);
            int maTinhTrang = Convert.ToInt32(cbtinhtrang.SelectedValue);
            int maLoaiSP = Convert.ToInt32(cbloai.SelectedValue);
            string chitiet = txtchitietsanpham.Text;
            string ghichu = txtghichu.Text;
            decimal gia = Convert.ToDecimal(txtgia.Text);

            // Tạo truy vấn SQL
            string query = $"UPDATE sanpham SET TenSP = N'{tensp}', MaHang = {maHang}, MaTinhTrang = {maTinhTrang}, MaLoaiSP = {maLoaiSP}, ChitietSP = N'{chitiet}', Ghichu = N'{ghichu}', Gia = {gia} WHERE MaSP = {maSP}";

            // Thực hiện truy vấn
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            command.ExecuteNonQuery();

            // Hiển thị thông báo thành công và làm mới dữ liệu
            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(txtmasp.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã sản phẩm cần xóa
            int maSP = Convert.ToInt32(txtmasp.Text);

            // Tạo truy vấn SQL
            string query = $"DELETE FROM sanpham WHERE MaSP = {maSP}";

            // Thực hiện truy vấn
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            command.ExecuteNonQuery();

            // Hiển thị thông báo thành công và làm mới dữ liệu
            MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox và ComboBox
            string tenSP = txttensanpham.Text;
            int maHang = Functions.GetSelectedValue(cbhang);
            int maLoai = Functions.GetSelectedValue(cbloai);
            int tinhTrang = Functions.GetSelectedValue(cbtinhtrang);
            int gia = Functions.ConvertToInt32(txtgia.Text);
            string ghiChu = txtghichu.Text;
            string chiTietSP = txtchitietsanpham.Text;

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(tenSP) || maHang == -1 || maLoai == -1 ||
                tinhTrang == -1 || string.IsNullOrEmpty(txtgia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo câu truy vấn INSERT để chèn dữ liệu vào bảng
            string query = "INSERT INTO dbo.Sanpham (TenSP, MaHang, MaLoaiSP, maTinhTrang, Gia, GhiChu, ChiTietSP) " +
                           "VALUES (@TenSP, @MaHang, @MaLoaiSP, @TinhTrang, @Gia, @GhiChu, @ChiTietSP)";

            // Tạo đối tượng SqlCommand và thiết lập các tham số
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            command.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = tenSP;
            command.Parameters.Add("@MaHang", SqlDbType.Int).Value = maHang;
            command.Parameters.Add("@MaLoaiSP", SqlDbType.Int).Value = maLoai;
            command.Parameters.Add("@TinhTrang", SqlDbType.Int).Value = tinhTrang;
            command.Parameters.Add("@Gia", SqlDbType.Int).Value = gia;
            command.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = ghiChu;
            command.Parameters.Add("@ChiTietSP", SqlDbType.NVarChar).Value = chiTietSP;

            try
            {
                if (Functions.Conn.State == ConnectionState.Closed)
                {
                    Functions.Conn.Open();
                }
                // Thực thi câu truy vấn
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgsanpham.Refresh();

                    // Clear dữ liệu trong các TextBox và ComboBox
                    txtmasp.Clear();
                    txttensanpham.Clear();
                    cbhang.SelectedIndex = -1;
                    cbloai.SelectedIndex = -1;
                    cbtinhtrang.SelectedIndex = -1;
                    txtgia.Clear();
                    txtghichu.Clear();
                    txtchitietsanpham.Clear();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối sau khi thực hiện câu truy vấn
                Functions.Conn.Close();
            }
            
            LoadData();
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;

        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            // Xóa dữ liệu trong các điều khiển
            txtmasp.Clear();
            txttensanpham.Clear();
            cbhang.SelectedIndex = -1;
            cbtinhtrang.SelectedIndex = -1;
            cbloai.SelectedIndex = -1;
            txtchitietsanpham.Clear();
            txtghichu.Clear();
            txtgia.Clear();
            LoadData();
            if (txttensanpham.Text == "")
            {
                txttensanpham.Text = "Tên sản phẩm";
                txttensanpham.ForeColor = Color.Gray; // Đặt màu chữ khi nhập
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txttensanpham_TextChanged(object sender, EventArgs e)
        {
            
            txttensanpham.ForeColor = Color.Black;
            
        }
        private void LoadData()
        {
            // Tạo truy vấn SQL để lấy dữ liệu từ CSDL
            string sql = "select a.MaSP, a.TenSP, b.TenTinhTrang, c.TenLoaiSP, d.TenHang, a.ChitietSP, a.Ghichu, a.Gia from dbo.sanpham a join dbo.tinhtrang b on a.matinhtrang = b.matinhtrang join dbo.LoaiSanPham c on a.MaLoaiSP = c.MaLoaiSP join dbo.Hang d on a.MaHang = d.MaHang";

            // Lấy dữ liệu từ CSDL và gán vào DataTable
            DataTable dataTable = Class.Functions.GetdataToTable(sql);

            // Gán DataTable cho DataGridView để hiển thị dữ liệu
            dtgsanpham.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtmasp_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmasp.Text))
            {
                txtmasp.Text = "Mã sản phẩm";
                txtmasp.ForeColor = Color.Gray; // Đặt màu chữ mờ
            }
        }
        
        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            if (txttimkiem.Text != "Nhập từ khóa để tìm kiếm")
            {
                txttimkiem.Text = txttimkiem.Text.Trim();
            }
        }
        
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            btnhuy.Enabled = true;
            string query = "SELECT a.MaSP, a.TenSP, b.TenTinhTrang, c.TenLoaiSP, d.TenHang, a.ChitietSP, a.Ghichu, a.Gia " +
                   "FROM dbo.sanpham a " +
                   "JOIN dbo.tinhtrang b ON a.matinhtrang = b.matinhtrang " +
                   "JOIN dbo.LoaiSanPham c ON a.MaLoaiSP = c.MaLoaiSP " +
                   "JOIN dbo.Hang d ON a.MaHang = d.MaHang " +
                   "WHERE LOWER(a.TenSP) LIKE '%' + LOWER(N'"+ txttimkiem.Text.Trim()+"') + '%' " +
                   "OR LOWER(d.TenHang) LIKE '%' + LOWER(N'"+ txttimkiem.Text.Trim()+"') + '%' " +
                   "OR LOWER(b.TenTinhTrang) LIKE '%' + LOWER(N'"+ txttimkiem.Text.Trim()+"') + '%' " +
                   "OR LOWER(c.TenLoaiSP) LIKE '%' + LOWER(N'"+ txttimkiem.Text.Trim()+"') + '%'";

            // Lấy dữ liệu từ CSDL và gán vào DataTable
            DataTable dataTable = Class.Functions.GetdataToTable(query);

            // Gán DataTable cho DataGridView để hiển thị dữ liệu
            dtgsanpham.DataSource = dataTable;
        }

        private void txttimkiem_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txttimkiem_Enter(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "Nhập từ khóa để tìm kiếm")
            {
                txttimkiem.Text = "";
                txttimkiem.ForeColor = Color.Gray; // Đặt màu chữ khi nhập
            }
        }

        private void txttimkiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiem.Text))
            {
                txttimkiem.Text = "Nhập từ khóa để tìm kiếm";
                txttimkiem.ForeColor = Color.Gray; // Đặt màu chữ mờ
            }
        }

        private void txttensanpham_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttensanpham.Text))
            {
                txttensanpham.Text = "Tên sản phẩm";
                txttensanpham.ForeColor = Color.Gray; // Đặt màu chữ mờ
            }
        }

        private void txtmasp_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmasp.Text))
            {
                txtmasp.Text = "Mã sản phẩm";
                txtmasp.ForeColor = Color.Gray; // Đặt màu chữ mờ
            }
        }

        private void txttensanpham_Enter(object sender, EventArgs e)
        {
            if (txttensanpham.Text == "Tên sản phẩm")
            {
                txttensanpham.Text = "";
                txttensanpham.ForeColor = Color.Gray; // Đặt màu chữ khi nhập
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgsanpham.Rows[e.RowIndex];

                // Lấy giá trị từ các cột tương ứng trong dòng được chọn
                string maSP = row.Cells["MaSP"].Value.ToString();
                string tenSP = row.Cells["TenSP"].Value.ToString();
                string maHang = row.Cells["TenHang"].Value.ToString();
                string maLoai = row.Cells["TenLoaiSP"].Value.ToString();
                string tinhTrang = row.Cells["TenTinhTrang"].Value.ToString();
                string gia = row.Cells["Gia"].Value.ToString();
                string ghiChu = row.Cells["GhiChu"].Value.ToString();
                string chiTietSP = row.Cells["ChiTietSP"].Value.ToString();

                // Đổ dữ liệu vào các TextBox
                txtmasp.Text = maSP;
                txttensanpham.Text = tenSP;
                txtgia.Text = gia;
                txtghichu.Text = ghiChu;
                txtchitietsanpham.Text = chiTietSP;

                // Cập nhật giá trị cho ComboBox cbhang
                DataRow[] hangRows = ((DataTable)cbhang.DataSource).Select("TenHang = '" + maHang + "'");
                if (hangRows.Length > 0)
                {
                    int maHangValue = Convert.ToInt32(hangRows[0]["MaHang"]);
                    cbhang.SelectedValue = maHangValue;
                }
                else
                {
                    // Xử lý khi giá trị không hợp lệ
                }

                // Cập nhật giá trị cho ComboBox cbloai
                DataRow[] loaiRows = ((DataTable)cbloai.DataSource).Select("TenLoaiSP = '" + maLoai + "'");
                if (loaiRows.Length > 0)
                {
                    int maLoaiValue = Convert.ToInt32(loaiRows[0]["MaLoaiSP"]);
                    cbloai.SelectedValue = maLoaiValue;
                }
                else
                {
                    // Xử lý khi giá trị không hợp lệ
                }

                // Cập nhật giá trị cho ComboBox cbtinhtrang
                DataRow[] tinhTrangRows = ((DataTable)cbtinhtrang.DataSource).Select("TenTinhTrang = '" + tinhTrang + "'");
                if (tinhTrangRows.Length > 0)
                {
                    int maTinhTrangValue = Convert.ToInt32(tinhTrangRows[0]["MaTinhTrang"]);
                    cbtinhtrang.SelectedValue = maTinhTrangValue;
                }
                else
                {
                    // Xử lý khi giá trị không hợp lệ
                }
            }
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
            btnhuy.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLoaisanpham a = new frmLoaisanpham();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hang a = new Hang();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormTinhTrang a = new FormTinhTrang();
            a.Show();
        }
    }
}
