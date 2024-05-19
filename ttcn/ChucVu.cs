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
    public partial class ChucVu : Form
    {
        public ChucVu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ChucVu_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();

            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select Machucvu, Tenchucvu from Chucvu";
            DataTable a = Functions.GetdataToTable(sql);
            dgcv.DataSource = a;

            dgcv.Columns[0].HeaderText = "Mã chức vụ";
            dgcv.Columns[1].HeaderText = "Tên chức vụ";

            dgcv.Columns[0].Width = 125;
            dgcv.Columns[1].Width = 135;
           

            dgcv.AllowUserToAddRows = false;
            dgcv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmcv.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
            btnsua.Enabled = false;
            txttcv.Clear();
            // Lấy mã sản phẩm lớn nhất trong bảng sản phẩm
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(Machucvu) FROM Chucvu";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxCV = Convert.ToInt32(result);
                // Tăng mã sản phẩm lên 1 và hiển thị trong txtmasp
                txtmcv.Text = (maxCV + 1).ToString();
            }
            else
            {
                // Nếu không có sản phẩm nào trong bảng, gán mã sản phẩm mặc định là 1
                txtmcv.Text = "1";
            }
        }

        
        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmcv.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chức vụ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtmcv.Focus();
                return;
            }
            if (txttcv.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên chức vụ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txttcv.Focus();
                return;
            }



            sql = "SELECT Machucvu FROM Chucvu WHERE Machucvu=N'" + txtmcv.Text.Trim() + "'";
            if (Functions.Checkkey(sql))
            {
                MessageBox.Show("Mã tình trạng này đã tồn, vui lòng nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmcv.Focus();
                txtmcv.Text = "";
                return;
            }
            sql = "INSERT INTO Chucvu (Machucvu, Tenchucvu) " + "VALUES (N'" + txtmcv.Text.Trim() + "', N'" + txttcv.Text.Trim() + "')";


            Functions.Runsql(sql);
            loaddata();
            resetvalue();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmcv.Enabled = false;
            loaddata();
        }

        private void dgcv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void loaddata()
        {
            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select Machucvu, Tenchucvu from Chucvu";
            DataTable a = Functions.GetdataToTable(sql);
            dgcv.DataSource = a;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtmcv.Enabled = false;
            btnluu.Enabled = false;
            resetvalue();
        }
        private void resetvalue()
        {
            txttcv.Text = "";
            txtmcv.Text = "";
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maCV = Convert.ToInt32(txtmcv.Text.Trim());
                string sql = "DELETE FROM Chucvu WHERE Machucvu = " + maCV;

                string connectionString = Functions.Conn.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txttcv.Text = "";
                            txttcv.Focus();
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
            int maCV = Convert.ToInt32(txtmcv.Text.Trim());
            string sql = "UPDATE Chucvu SET Tenchucvu = N'" + txttcv.Text.Trim() + "' WHERE Machucvu = " + maCV;
            string connectionString = Functions.Conn.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        txttcv.Text = "";
                        txttcv.Focus();
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

        private void dgcv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmcv.Text = dgcv.CurrentRow.Cells["Machucvu"].Value.ToString();
            txttcv.Text = dgcv.CurrentRow.Cells["Tenchucvu"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnhuy.Enabled = true;
        }
    }

}
