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
    public partial class Hang : Form
    {
        public Hang()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Hang_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();

            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select mahang, tenhang from dbo.hang";
            DataTable a = Functions.GetdataToTable(sql);
            dgh.DataSource = a;

            dgh.Columns[0].HeaderText = "Mã hãng";
            dgh.Columns[1].HeaderText = "Tên hãng";
            // Thiết lập chế độ tự động điều chỉnh độ rộng của các cột
            dgh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Thiết lập tỷ lệ phần trăm cho từng cột
            dgh.Columns[0].FillWeight = 40;   // 20%
            dgh.Columns[1].FillWeight = 60;   // 30%

            dgh.AllowUserToAddRows = false;
            dgh.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmh.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
            btnsua.Enabled = false;
            txtth.Clear();
            
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(MAHANG) FROM HANG";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxMH = Convert.ToInt32(result);
                
                txtmh.Text = (maxMH + 1).ToString();
            }
            else
            {
                
                txtmh.Text = "1";
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtmh.Enabled = false;
            btnluu.Enabled = false;
            resetvalue();
        }
        private void resetvalue()
        {
            txtth.Text = "";
            txtmh.Text = "";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO dbo.hang (tenhang) VALUES (N'" + txtth.Text.Trim() + "')";

            if (!Functions.Checkkey(sql))
            {
                // Thực hiện câu lệnh INSERT khi không có trùng khóa
                // ...

                txtth.Text = "";
                txtth.Focus();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Trùng khóa! Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            loaddata();
        }

        private void dgh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmh.Text = dgh.CurrentRow.Cells["mahang"].Value.ToString();
            txtth.Text = dgh.CurrentRow.Cells["tenhang"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnhuy.Enabled = true;
        }
        private void loaddata()
        {
            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select mahang, tenhang from dbo.hang";
            DataTable a = Functions.GetdataToTable(sql);
            dgh.DataSource = a;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maH = Convert.ToInt32(txtmh.Text.Trim());
                string sql = "DELETE FROM dbo.hang WHERE mahang = " + maH;

                string connectionString = Functions.Conn.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txtth.Text = "";
                            txtth.Focus();
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
            int maH = Convert.ToInt32(txtmh.Text.Trim());
            string sql = "UPDATE dbo.hang SET tenhang = N'" + txtth.Text.Trim() + "' WHERE mahang = " + maH;
            string connectionString = Functions.Conn.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        txtth.Text = "";
                        txtth.Focus();
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
    }
}
