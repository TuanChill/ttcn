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
    public partial class frmchinhanh : Form
    {
        public frmchinhanh()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maCN = Convert.ToInt32(txtmcn.Text.Trim());
                string sql = "DELETE FROM dbo.chinhanh WHERE machinhanh = " + maCN;

                string connectionString = Functions.Conn.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txttcn.Text = "";
                            txttcn.Focus();
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

        private void loaddata()
        {
            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select machinhanh, tenchinhanh, diachi, sdt from dbo.chinhanh ";
            DataTable a = Functions.GetdataToTable(sql);
            dgcn.DataSource = a;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO dbo.ChiNhanh (TenChiNhanh, DiaChi, SDT) VALUES (N'" + txttcn.Text.Trim() + "', N'" + txtdc.Text.Trim() + "', N'" + txtsdt.Text.Trim() + "')";

            if (Functions.Checkkey(sql))
            {
                // Thực hiện câu lệnh INSERT khi không có trùng khóa
                // ...

                txttcn.Text = "";
                txttcn.Focus();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Trùng khóa! Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            loaddata();
        }
      
        private void ChiNhanh_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();

            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select machinhanh, tenchinhanh, diachi, sdt from dbo.chinhanh";
            DataTable a = Functions.GetdataToTable(sql);
            dgcn.DataSource = a;

            dgcn.Columns[0].HeaderText = "Mã chi nhánh";
            dgcn.Columns[1].HeaderText = "Tên chi nhánh";
            dgcn.Columns[2].HeaderText = "Địa chỉ";
            dgcn.Columns[3].HeaderText = "Số điện thoại";

            dgcn.Columns[0].Width = 125;
            dgcn.Columns[1].Width = 135;
            dgcn.Columns[2].Width = 120;
            dgcn.Columns[3].Width = 120;

            dgcn.AllowUserToAddRows = false;
            dgcn.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmcn.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
            btnsua.Enabled = false;
            txttcn.Clear();
            // Lấy mã sản phẩm lớn nhất trong bảng sản phẩm
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(MaChiNhanh) FROM ChiNhanh";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxMacn = Convert.ToInt32(result);
                // Tăng mã sản phẩm lên 1 và hiển thị trong txtmasp
                txtmcn.Text = (maxMacn + 1).ToString();
            }
            else
            {
                // Nếu không có sản phẩm nào trong bảng, gán mã sản phẩm mặc định là 1
                txtmcn.Text = "1";
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtmcn.Enabled = false;
            btnluu.Enabled = false;
            resetvalue();
        }
        private void resetvalue()
        {
            txttcn.Text = "";
            txtsdt.Text = "";
            txtdc.Text = "";
            txtmcn.Text = "";
        }

        private void dgcn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmcn.Text = dgcn.CurrentRow.Cells["MaChiNhanh"].Value.ToString();
            txttcn.Text = dgcn.CurrentRow.Cells["TenChiNhanh"].Value.ToString();
            txtdc.Text = dgcn.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtsdt.Text = dgcn.CurrentRow.Cells["SDT"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnhuy.Enabled = true;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            int maCN = Convert.ToInt32(txtmcn.Text.Trim());
            string sql = "UPDATE dbo.chinhanh SET Tenchinhanh = N'" + txttcn.Text.Trim() + "', diachi = N'" + txtdc.Text.Trim() + "', sdt = N'" + txtsdt.Text.Trim() + "' WHERE machinhanh = " + maCN;
            string connectionString = Functions.Conn.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        txttcn.Text = "";
                        txttcn.Focus();
                        MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loaddata();
                    }
                    else
                    {
                        MessageBox.Show("Sửa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                resetvalue();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
   
}
