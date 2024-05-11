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
    public partial class FormLoaiNCC : Form
    {
        public FormLoaiNCC()
        {
            InitializeComponent();
        }

        private void FormLoaiNCC_Load(object sender, EventArgs e)
        {
             Functions.Ketnoi();

            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select maloaincc, tenloaincc from dbo.loainhacungcap";
            DataTable a =  Functions.GetdataToTable(sql);
            dglncc.DataSource = a;

            dglncc.Columns[0].HeaderText = "Mã loại nhà cung cấp";
            dglncc.Columns[1].HeaderText = "Tên loại nhà cung cấp";

            dglncc.Columns[0].Width = 160;
            dglncc.Columns[1].Width = 160;

            dglncc.AllowUserToAddRows = false;
            dglncc.EditMode = DataGridViewEditMode.EditProgrammatically;
            
        }

        //Nút THÊM

        private void resetvalue()
        {
          txttenloaincc.Text = "";
          txtmaloaincc.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtmaloaincc.Enabled = false;
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            txttenloaincc.Clear();
            
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(MaLoaiNCC) FROM LoaiNhaCungCap";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxMLNCC = Convert.ToInt32(result);
                
                txtmaloaincc.Text = (maxMLNCC + 1).ToString();
            }
            else
            {
                
                txtmaloaincc.Text = "1";
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            int maLNCC = Convert.ToInt32(txtmaloaincc.Text.Trim());
            string sql = "UPDATE dbo.loainhacungcap SET tenloaincc = N'" + txttenloaincc.Text.Trim() + "' WHERE maloaincc = " + maLNCC;
            string connectionString = Functions.Conn.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        txttenloaincc.Text = "";
                        txttenloaincc.Focus();
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
        private void loaddata()
        {
            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select maloaincc, tenloaincc from dbo.loainhacungcap";
            DataTable a =  Functions.GetdataToTable(sql);
            dglncc.DataSource = a;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "INSERT INTO dbo.loainhacungcap (tenloaincc) VALUES (N'" + txttenloaincc.Text.Trim() + "')";

            if (! Functions.Checkkey(sql))
            {
                // Thực hiện câu lệnh INSERT khi không có trùng khóa
                // ...

                txtmaloaincc.Text = "";
                txtmaloaincc.Focus();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Trùng khóa! Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            
        }*/

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maLNCC = Convert.ToInt32(txtmaloaincc.Text.Trim());
                string sql = "DELETE FROM dbo.loainhacungcap WHERE maloaincc = " + maLNCC;

                string connectionString = Functions.Conn.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txttenloaincc.Text = "";
                            txttenloaincc.Focus();
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

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtmaloaincc.Enabled = false;
            btnluu.Enabled = false;
            resetvalue();
        }
      //  private void resetvalue()
      //  {
       //     txttenloaincc.Text = "";
       //     txtmaloaincc.Text = "";
      //  }

        private void dglncc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaloaincc.Text = dglncc.CurrentRow.Cells["maloaincc"].Value.ToString();
            txttenloaincc.Text = dglncc.CurrentRow.Cells["tenloaincc"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnhuy.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO dbo.loainhacungcap (tenloaincc) VALUES (N'" + txttenloaincc.Text.Trim() + "')";

            if (! Functions.Checkkey(sql))
            {
                // Thực hiện câu lệnh INSERT khi không có trùng khóa
                // ...

                txttenloaincc.Text = "";
                txttenloaincc.Focus();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Trùng khóa! Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            loaddata();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
