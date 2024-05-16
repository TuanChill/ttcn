using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ttcn.Class;

namespace ttcn
{
    public partial class frmLoaisanpham : Form
    {
        public frmLoaisanpham()
        {
            InitializeComponent();
        }

        //NÚT XÓA LOẠI SP
        /*private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maLSP = Convert.ToInt32(txtmalsp.Text.Trim());
                string sql = "DELETE FROM dbo.loaisanpham WHERE maloaisp = " + maLSP;

                string connectionString = Functions.Conn.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txttenlsp.Text = "";
                            txttenlsp.Focus();
                            MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loaddata();
                        }
                        else
                        {
                            MessageBox.Show("Xóa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        /*private void btnthem_Click(object sender, EventArgs e)
        {
            txtmalsp.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
            btnsua.Enabled = false;
            txttenlsp.Clear();

            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(MaLoaiSP) FROM LoaianPham";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxMLSP = Convert.ToInt32(result);

                txtmalsp.Text = (maxMLSP + 1).ToString();
            }
            else
            {
                txtmalsp.Text = "1";
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtmalsp.Enabled = false;
            btnluu.Enabled = false;
            resetvalue();
        }
        private void resetvalue()
        {
            txttenlsp.Text = "";
            txtmalsp.Text = "";
        }

        /*private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO dbo.loaisanpham (tenloaisp) VALUES (N'" + txttenlsp.Text.Trim() + "')";

            if (!Functions.Checkkey(sql))
            {
                // Thực hiện câu lệnh INSERT khi không có trùng khóa
                // ...

                txttenlsp.Text = "";
                txttenlsp.Focus();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Trùng khóa! Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            loaddata();
        }

        private void dgloaisp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmalsp.Text = dgloaisp.CurrentRow.Cells["maloaisp"].Value.ToString();
            txttenlsp.Text = dgloaisp.CurrentRow.Cells["tenloaisp"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnhuy.Enabled = true;
        }
        private void loaddata()
        {
            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select maloaisp, tenloaisp from dbo.loaisanpham";
            DataTable a = Functions.GetdataToTable(sql);
            dgloaisp.DataSource = a;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            int maLSP = Convert.ToInt32(txtmalsp.Text.Trim());
            string sql = "UPDATE dbo.loaisanpham SET tenloaisp = N'" + txttenlsp.Text.Trim() + "' WHERE maloaisp = " + maLSP;
            string connectionString = Functions.Conn.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        txttenlsp.Text = "";
                        txttenlsp.Focus();
                        MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loaddata();
                    }
                    else
                    {
                        MessageBox.Show("Sửa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }*/

        private void frmLoaisanpham_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();

            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select maloaisp, tenloaisp from dbo.loaisanpham";
            DataTable a = Functions.GetdataToTable(sql);
            dgloaisp.DataSource = a;

            dgloaisp.Columns[0].HeaderText = "Mã loại sản phẩm";
            dgloaisp.Columns[1].HeaderText = "Tên loại sản phẩm";
            dgloaisp.Columns[0].Width = 135;
            dgloaisp.Columns[1].Width = 150;
            dgloaisp.AllowUserToAddRows = false;
            dgloaisp.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void loaddata()
        {
            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select maloaisp, tenloaisp from dbo.loaisanpham";
            DataTable a = Functions.GetdataToTable(sql);
            dgloaisp.DataSource = a;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmalsp.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
            btnsua.Enabled = false;
            txttenlsp.Clear();
            // Lấy mã sản phẩm lớn nhất trong bảng sản phẩm
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(MaLoaiSP) FROM LoaiSanPham";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxMLSP = Convert.ToInt32(result);
                // Tăng mã sản phẩm lên 1 và hiển thị trong txtmasp
                txtmalsp.Text = (maxMLSP + 1).ToString();
            }
            else
            {
                // Nếu không có sản phẩm nào trong bảng, gán mã sản phẩm mặc định là 1
                txtmalsp.Text = "1";
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtmalsp.Enabled = false;
            btnluu.Enabled = false;
            resetvalue();
        }
        private void resetvalue()
        {
            txtmalsp.Text = "";
            txttenlsp.Text = "";
        }

        private void dgloaisp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmalsp.Text = dgloaisp.CurrentRow.Cells["maloaisp"].Value.ToString();
            txttenlsp.Text = dgloaisp.CurrentRow.Cells["tenloaisp"].Value.ToString();
            
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnhuy.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO dbo.loaisanpham (tenloaisp) VALUES (N'" + txttenlsp.Text.Trim() + "')";

            if (!Functions.Checkkey(sql))
            {
                // Thực hiện câu lệnh INSERT khi không có trùng khóa
                // ...

                txttenlsp.Text = "";
                txttenlsp.Focus();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Trùng khóa! Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            loaddata();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maLSP = Convert.ToInt32(txtmalsp.Text.Trim());
                string sql = "DELETE FROM dbo.loaisanpham WHERE maloaisp = " + maLSP;

                string connectionString = Functions.Conn.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txttenlsp.Text = "";
                            txttenlsp.Focus();
                            MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loaddata();
                        }
                        else
                        {
                            MessageBox.Show("Xóa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            int maLSP = Convert.ToInt32(txtmalsp.Text.Trim());
            string sql = "UPDATE dbo.loaisanpham SET tenloaisp = N'" + txttenlsp.Text.Trim() + "' WHERE maloaisp = " + maLSP;
            string connectionString = Functions.Conn.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        txttenlsp.Text = "";
                        txttenlsp.Focus();
                        MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loaddata();
                    }
                    else
                    {
                        MessageBox.Show("Sửa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        /*private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maLSP = Convert.ToInt32(txtmalsp.Text.Trim());
                string sql = "DELETE FROM dbo.LoaiSanPham WHERE maloaisp = " + maLSP;

                string connectionString = Functions.Conn.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txttenlsp.Text = "";
                            txttenlsp.Focus();
                            MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loaddata();
                        }
                        else
                        {
                            MessageBox.Show("Xóa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }*/
    }
}