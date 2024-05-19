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
        DataTable dt;
        private void FormTinhTrang_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();

            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select MaTT, mucdo from Tinhtrang";
            
           
            dt = Functions.GetdataToTable(sql);
            datagridview_tinhtrang.DataSource = dt;

            datagridview_tinhtrang.Columns[0].HeaderText = "Mã tình trạng";
            datagridview_tinhtrang.Columns[1].HeaderText = "Mức độ";

            datagridview_tinhtrang.Columns[0].Width = 100;
            datagridview_tinhtrang.Columns[1].Width = 300;

            txtmatt.Enabled= false;
            datagridview_tinhtrang.AllowUserToAddRows = false;
            datagridview_tinhtrang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgtt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmatt.Text = datagridview_tinhtrang.CurrentRow.Cells["MaTT"].Value.ToString();
            txttentt.Text = datagridview_tinhtrang.CurrentRow.Cells["mucdo"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnHuy.Enabled = true;
        }
        private void loaddata()
        {
            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select MaTT, mucdo from Tinhtrang";
            DataTable a = Functions.GetdataToTable(sql);
            datagridview_tinhtrang.DataSource = a;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            int maTT = Convert.ToInt32(txtmatt.Text.Trim());
            string sql = "UPDATE Tinhtrang SET mucdo = N'" + txttentt.Text.Trim() + "' WHERE MaTT = " + maTT;
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
            //if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    int maTT = Convert.ToInt32(txtmatt.Text.Trim());
            //    string sql = "DELETE FROM Tinhtrang WHERE MaTT = " + maTT;

            //    string connectionString = Functions.Conn.ConnectionString;

            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();

            //        using (SqlCommand command = new SqlCommand(sql, connection))
            //        {
            //            int rowsAffected = command.ExecuteNonQuery();

            //            if (rowsAffected > 0)
            //            {
            //                txttentt.Text = "";
            //                txttentt.Focus();
            //                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                loaddata();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Xóa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }
            //        }
            //    }
            //}
            string sql;
            
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (txtmatt.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Tinhtrang WHERE MaTT=N'" + txtmatt.Text + "'";
                Class.Functions.RunSqlDel(sql);
                loaddata();
                resetvalue();
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
            string query = "SELECT MAX(MaTT) FROM Tinhtrang";
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
            if (txtmatt.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã tình trạng", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtmatt.Focus();
                return;
            }
            if (txttentt.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mức độ tình trạng", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txttentt.Focus();
                return;
            }



            sql = "SELECT MaTT FROM Tinhtrang WHERE MaTT=N'" + txtmatt.Text.Trim() + "'";
            if (Functions.Checkkey(sql))
            {
                MessageBox.Show("Mã tình trạng này đã tồn, vui lòng nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmatt.Focus();
                txtmatt.Text = "";
                return;
            }
            sql = "INSERT INTO Tinhtrang (MaTT, mucdo) " + "VALUES (N'" + txtmatt.Text.Trim() + "', N'" + txttentt.Text.Trim() + "')";


            Functions.Runsql(sql);
            loaddata();
            resetvalue();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmatt.Enabled = false;
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
            if (MessageBox.Show("Bạn có muốn thoát form Nguyên liệu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                main main = new main();
                main.Show();
                return;
            }
        }
    }
}
