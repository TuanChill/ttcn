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
    public partial class FormTinhTrang : Form
    {
        public FormTinhTrang()
        {
            InitializeComponent();
        }

        private void FormTinhTrang_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();

            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select matinhtrang, tentinhtrang from dbo.tinhtrang";
            DataTable a = Functions.GetdataToTable(sql);
            dgtt.DataSource = a;

            dgtt.Columns[0].HeaderText = "Mã tình trạng";
            dgtt.Columns[1].HeaderText = "Tên tình trạng";


            dgtt.AllowUserToAddRows = false;
            dgtt.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgtt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmatt.Text = dgtt.CurrentRow.Cells["matinhtrang"].Value.ToString();
            txttentt.Text = dgtt.CurrentRow.Cells["tentinhtrang"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnHuy.Enabled = true;
        }
        private void loaddata()
        {
            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select matinhtrang, tentinhtrang from dbo.tinhtrang";
            DataTable a = Functions.GetdataToTable(sql);
            dgtt.DataSource = a;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            int maTT = Convert.ToInt32(txtmatt.Text.Trim());
            string sql = "UPDATE dbo.tinhtrang SET tentinhtrang = N'" + txttentt.Text.Trim() + "' WHERE matinhtrang = " + maTT;
            string connectionString = Functions.Conn.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        txttentt.Text = "";
                        txttentt.Focus();
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

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maTT = Convert.ToInt32(txtmatt.Text.Trim());
                string sql = "DELETE FROM dbo.tinhtrang WHERE matinhtrang = " + maTT;

                string connectionString = Functions.Conn.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txttentt.Text = "";
                            txttentt.Focus();
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmatt.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnHuy.Enabled = true;
            btnsua.Enabled = false;
            txttentt.Clear();

            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(MATINHTRANG) FROM TINHTRANG";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxMTT = Convert.ToInt32(result);
                txtmatt.Text = (maxMTT + 1).ToString();
            }
            else
            {
                
                txtmatt.Text = "1";
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO dbo.tinhtrang (tentinhtrang) VALUES (N'" + txttentt.Text.Trim() + "')";

            if (!Functions.Checkkey(sql))
            {
                // Thực hiện câu lệnh INSERT khi không có trùng khóa
                // ...

                txttentt.Text = "";
                txttentt.Focus();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Trùng khóa! Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            loaddata();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtmatt.Enabled = false;
            btnluu.Enabled = false;
            resetvalue();
        }
        private void resetvalue()
        {
            txttentt.Text = "";
            txtmatt.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
