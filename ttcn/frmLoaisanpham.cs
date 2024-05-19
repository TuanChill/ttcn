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
    public partial class frmloainl : Form
    {
        public frmloainl()
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

            Class.Functions.Ketnoi();
            txt_maloai.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            loaddata();
            resetvalue();

        }
        private void loaddata()
        {
            string sql;
            sql = "SELECT Maloai,Tenloai FROM LoaiNL";
            dt = Functions.GetdataToTable(sql);
            datagridview_nguyenlieu.DataSource = dt;
            datagridview_nguyenlieu.Columns[0].HeaderText = "Mã nguyên liệu";
            datagridview_nguyenlieu.Columns[1].HeaderText = "Tên nguyên liệu";

            datagridview_nguyenlieu.Columns[0].Width = 135;
            datagridview_nguyenlieu.Columns[1].Width = 150;
            datagridview_nguyenlieu.AllowUserToAddRows = false;
            datagridview_nguyenlieu.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txt_maloai.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
            btnsua.Enabled = false;
            txt_ten.Clear();
            // Lấy mã sản phẩm lớn nhất trong bảng sản phẩm
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(Maloai) FROM LoaiNL";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxMLSP = Convert.ToInt32(result);
                // Tăng mã sản phẩm lên 1 và hiển thị trong txtmasp
                txt_maloai.Text = (maxMLSP + 1).ToString();
            }
            else
            {
                // Nếu không có sản phẩm nào trong bảng, gán mã sản phẩm mặc định là 1
                txt_maloai.Text = "1";
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txt_maloai.Enabled = false;
            btnluu.Enabled = false;
            resetvalue();
        }
        private void resetvalue()
        {
            txt_maloai.Text = "";
            txt_ten.Text = "";
        }

        //private void dgloaisp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    txt_maloai.Text = datagridview_nguyenlieu.CurrentRow.Cells["Maloai"].Value.ToString();
        //    txt_ten.Text = datagridview_nguyenlieu.CurrentRow.Cells["Tenloai"].Value.ToString();
            
        //    btnsua.Enabled = true;
        //    btnxoa.Enabled = true;
        //    btnhuy.Enabled = true;
        //}

        private void btnluu_Click(object sender, EventArgs e)
        {
            //string sql;
            //sql = "INSERT INTO LoaiNL (Tenloai) VALUES (N'" + txttenlsp.Text.Trim() + "')";

            //if (!Functions.Checkkey(sql))
            //{
            //    // Thực hiện câu lệnh INSERT khi không có trùng khóa
            //    // ...

            //    txttenlsp.Text = "";
            //    txttenlsp.Focus();
            //    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Trùng khóa! Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}


            //loaddata();

            string sql;
            if (txt_maloai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã loại nguyên liệu", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txt_maloai.Focus();
                return;
            }
            if (txt_ten.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên loại nguyên liệu", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txt_ten.Focus();
                return;
            }

           

            sql = "SELECT Maloai FROM LoaiNL WHERE Maloai=N'" + txt_maloai.Text.Trim() + "'";
            if (Functions.Checkkey(sql))
            {
                MessageBox.Show("Mã nguyên liệu này đã tồn, vui lòng nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_maloai.Focus();
                txt_maloai.Text = "";
                return;
            }
            sql = "INSERT INTO LoaiNL (Maloai, Tenloai) " +"VALUES (N'" + txt_maloai.Text.Trim() + "', N'" + txt_ten.Text.Trim() + "')";


            Functions.Runsql(sql);
            loaddata();
            resetvalue();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
             txt_maloai.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maLSP = Convert.ToInt32(txt_maloai.Text.Trim());
                string sql = "DELETE FROM LoaiNL WHERE Maloai = " + maLSP;

                string connectionString = Functions.Conn.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txt_ten.Text = "";
                            txt_ten.Focus();
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
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (txt_maloai.Text == "")
            {
                MessageBox.Show("bạn chưa chọn bản ghi nào", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                return;
            }
            string sql;
                    

            sql = "UPDATE LoaiNL SET Tenloai=N'" + txt_ten.Text.Trim().ToString() + "'WHERE Maloai=N'" + txt_maloai.Text + "'";
            Functions.Runsql(sql);
            loaddata();
            resetvalue();

            btnhuy.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát form Nguyên liệu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                main main = new main();
                main.Show();
                return;
            }
        }
        DataTable dt;
        private void datagridview_nguyenlieu_Click(object sender, EventArgs e)
        {
            
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_maloai.Focus();
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txt_maloai.Text = datagridview_nguyenlieu.CurrentRow.Cells["Maloai"].Value.ToString();
            txt_ten.Text = datagridview_nguyenlieu.CurrentRow.Cells["Tenloai"].Value.ToString();
   
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnhuy.Enabled = true;
        }
    }
}