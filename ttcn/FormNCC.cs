using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ttcn.Class;

namespace ttcn
{
    public partial class FormNCC : Form
    {
        DataTable tblncc;
        public FormNCC()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            int maNCC = Convert.ToInt32(txtmancc.Text.Trim());
            int selectedValue = Convert.ToInt32(cblncc.SelectedValue);
            string sql = "update dbo.nhacungcap set Tenncc = N'"+txttenncc.Text.Trim()+"' and Sdt = N'"+txtsdt.Text.Trim()+"' and diachi = N' "+txtdiachi.Text.Trim()+"' and maloaincc = "+selectedValue+" where mancc = "+maNCC+"";

        }

        private void FormNCC_Load(object sender, EventArgs e)
        {
             Functions.Ketnoi();

            loaddata();

            dgncc.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgncc.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgncc.Columns[2].HeaderText = "Loại NCC";
            dgncc.Columns[3].HeaderText = "Địa chỉ";
            dgncc.Columns[4].HeaderText = "Số điện thoại";
            dgncc.Columns[0].Width = 135;
            dgncc.Columns[1].Width = 135;
            dgncc.Columns[2].Width = 145;
            dgncc.Columns[3].Width = 150;
            dgncc.Columns[4].Width = 115;

            dgncc.AllowUserToAddRows = false;
            dgncc.EditMode = DataGridViewEditMode.EditProgrammatically;
            //đổ dữ liệu vào cblncc
            string sqlncc = "select maloaincc, tenloaincc from loainhacungcap";
             Functions.Fillcombo(sqlncc, cblncc, "maloaincc", "tenloaincc");
        }
        private void loaddata()
        {
            SqlConnection conn = Functions.Conn;
            string sql;
            sql = "select a.mancc, tenncc, tenloaincc, diachi, sdt from dbo.nhacungcap a join dbo.loainhacungcap b on a.maloaincc = b.maloaincc";
            DataTable a =  Functions.GetdataToTable(sql);
            dgncc.DataSource = a;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void load_data_datagrit()
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmancc.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled= false;
            btnxoa.Enabled= false;
            btnhuybo.Enabled = true;
            btnsua.Enabled = false;
            txttenncc.Clear();
            cblncc.SelectedIndex = -1 ;
            // Lấy mã sản phẩm lớn nhất trong bảng sản phẩm
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(MaNCC) FROM NhaCungCap";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxMancc = Convert.ToInt32(result);
                // Tăng mã sản phẩm lên 1 và hiển thị trong txtmasp
                txtmancc.Text = (maxMancc + 1).ToString();
            }
            else
            {
                // Nếu không có sản phẩm nào trong bảng, gán mã sản phẩm mặc định là 1
                txtmancc.Text = "1";
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnhuybo_Click(object sender, EventArgs e)
        {
            btnhuybo.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtmancc.Enabled = false;
            btnluu.Enabled = false;
            resetvalue();
        }
        private void resetvalue()
        {
            txttenncc.Text = "";
            cblncc.Text = "";
            txtsdt.Text = "";
            txtdiachi.Text = "";
            txtmancc.Text = "";
        }

        private void dgncc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmancc.Text = dgncc.CurrentRow.Cells["mancc"].Value.ToString();
            txttenncc.Text = dgncc.CurrentRow.Cells["tenncc"].Value.ToString();
            txtdiachi.Text = dgncc.CurrentRow.Cells["diachi"].Value.ToString();
            txtsdt.Text = dgncc.CurrentRow.Cells["sdt"].Value.ToString();
            cblncc.Text = dgncc.CurrentRow.Cells["tenloaincc"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnhuybo.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            int selectedValue = Convert.ToInt32(cblncc.SelectedValue);
            sql = "INSERT INTO dbo.nhacungcap (tenncc, maloaincc, diachi, sdt) VALUES (N'" + txttenncc.Text.Trim() + "', " + selectedValue + ", N'" + txtdiachi.Text.Trim() + "', N'" + txtsdt.Text.Trim() + "')";

            if (! Functions.Checkkey(sql))
            {
                // Thực hiện câu lệnh INSERT khi không có trùng khóa
                // ...

                txttenncc.Text = "";
                txttenncc.Focus();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Trùng khóa! Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            loaddata();

            
        }
        

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maNCC = Convert.ToInt32(txtmancc.Text.Trim());
                string sql = "DELETE FROM dbo.nhacungcap WHERE mancc = " + maNCC;

                string connectionString = Functions.Conn.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txttenncc.Text = "";
                            txttenncc.Focus();
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

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            int maNCC = Convert.ToInt32(txtmancc.Text.Trim());
            int selectedValue = Convert.ToInt32(cblncc.SelectedValue);
            string sql = "UPDATE dbo.nhacungcap SET Tenncc = N'" + txttenncc.Text.Trim() + "', Sdt = N'" + txtsdt.Text.Trim() + "', diachi = N'" + txtdiachi.Text.Trim() + "', maloaincc = " + selectedValue + " WHERE mancc = " + maNCC;
            string connectionString = Functions.Conn.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        txttenncc.Text = "";
                        txttenncc.Focus();
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

        private void button2_Click(object sender, EventArgs e)
        {
            FormLoaiNCC a = new FormLoaiNCC();
            a.Show();
        }
    }
}
