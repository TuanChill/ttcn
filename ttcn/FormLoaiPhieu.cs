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
    public partial class FormLoaiPhieu : Form
    {
        public FormLoaiPhieu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        // nút lưu
        private void button2_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO dbo.loaiphieu (tenloaiphieu) VALUES (N'" + txttenloaiphieu.Text.Trim() + "')";

            if (! Functions.Checkkey(sql))
            {
                // Thực hiện câu lệnh INSERT khi không có trùng khóa
                // ...

                txttenloaiphieu.Text = "";
                txttenloaiphieu.Focus();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Trùng khóa! Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            loaddata();
        }
        private void loaddata()
        {
            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select maloaiphieu, tenloaiphieu from dbo.loaiphieu";
            DataTable a =  Functions.GetdataToTable(sql);
            dgloaiphieu.DataSource = a;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaloaiphieu.Text = dgloaiphieu.CurrentRow.Cells["maloaiphieu"].Value.ToString();
            txttenloaiphieu.Text = dgloaiphieu.CurrentRow.Cells["tenloaiphieu"].Value.ToString();
            
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnhuy.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //NÚT SỬA
        private void button4_Click(object sender, EventArgs e)
        {
            int maLP = Convert.ToInt32(txtmaloaiphieu.Text.Trim());
            string sql = "UPDATE dbo.loaiphieu SET tenloaiphieu = N'" + txttenloaiphieu.Text.Trim() + "' WHERE maloaiphieu = " + maLP;
            string connectionString = Functions.Conn.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        txttenloaiphieu.Text = "";
                        txttenloaiphieu.Focus();
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

        // NÚT XÓA
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maLP = Convert.ToInt32(txtmaloaiphieu.Text.Trim());
                string sql = "DELETE FROM dbo.loaiphieu WHERE maloaiphieu = " + maLP;

                string connectionString = Functions.Conn.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txttenloaiphieu.Text = "";
                            txttenloaiphieu.Focus();
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

        private void FormLoaiPhieu_Load(object sender, EventArgs e)
        {
             Functions.Ketnoi();

            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select maloaiphieu, tenloaiphieu from dbo.loaiphieu";
            DataTable a =  Functions.GetdataToTable(sql);
            dgloaiphieu.DataSource = a;

            dgloaiphieu.Columns[0].HeaderText = "Mã loại phiếu";
            dgloaiphieu.Columns[1].HeaderText = "Tên loại phiếu";

            dgloaiphieu.Columns[0].Width = 135;
            dgloaiphieu.Columns[1].Width = 145;

            dgloaiphieu.AllowUserToAddRows = false;
            dgloaiphieu.EditMode = DataGridViewEditMode.EditProgrammatically;
           
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmaloaiphieu.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
            btnsua.Enabled = false;
            txttenloaiphieu.Clear();
            

            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(MALOAIPHIEU) FROM LOAIPHIEU";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxMLP = Convert.ToInt32(result);

                txtmaloaiphieu.Text = (maxMLP + 1).ToString();
            }
            else
            {

                txtmaloaiphieu.Text = "1";
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtmaloaiphieu.Enabled = false;
            btnluu.Enabled = false;
            resetvalue();
        }
        private void resetvalue()
        {
            txttenloaiphieu.Text = "";
            txtmaloaiphieu.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
