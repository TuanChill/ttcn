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
    public partial class frmtimkiem : Form
    {
        public frmtimkiem()
        {
            InitializeComponent();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {

            string query = "SELECT a.MaSP, a.TenSP, e.TenChiNhanh, f.SoLuong, b.TenTinhTrang, c.TenLoaiSP, d.TenHang, a.ChitietSP, a.Ghichu, a.Gia " +
                "FROM dbo.sanpham a " +
                "JOIN dbo.tinhtrang b ON a.matinhtrang = b.matinhtrang " +
                "JOIN dbo.LoaiSanPham c ON a.MaLoaiSP = c.MaLoaiSP " +
                "JOIN dbo.Hang d ON a.MaHang = d.MaHang " +
                "JOIN dbo.HangTonKho f ON a.MaSP = f.MaSP " +
                "JOIN dbo.ChiNhanh e ON f.MaChiNhanh = e.MaChiNhanh " +
                "WHERE LOWER(a.TenSP) LIKE '%' + LOWER(N'" + txttimkiem.Text.Trim() + "') + '%' " +
                "OR LOWER(d.TenHang) LIKE '%' + LOWER(N'" + txttimkiem.Text.Trim() + "') + '%' " +
                "OR LOWER(b.TenTinhTrang) LIKE '%' + LOWER(N'" + txttimkiem.Text.Trim() + "') + '%' " +
                "OR LOWER(c.TenLoaiSP) LIKE '%' + LOWER(N'" + txttimkiem.Text.Trim() + "') + '%' " +
                "OR LOWER(e.TenChiNhanh) LIKE '%' + LOWER(N'" + txttimkiem.Text.Trim() + "') + '%'";


            // Lấy dữ liệu từ CSDL và gán vào DataTable
            DataTable dataTable = Class.Functions.GetdataToTable(query);

            // Gán DataTable cho DataGridView để hiển thị dữ liệu
            dtgsanpham.DataSource = dataTable;
        }

        private void frmtimkiem_Load(object sender, EventArgs e)
        {
            Class.Functions.Ketnoi();
            SqlConnection conn = Functions.Conn;

        }

        private void txttimkiem_Enter(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "Nhập từ khóa để tìm kiếm")
            {
                txttimkiem.Text = "";
                txttimkiem.ForeColor = Color.Gray; // Đặt màu chữ khi nhập
            }
        }
    }
}
