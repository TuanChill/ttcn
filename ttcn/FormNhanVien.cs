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
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
             Functions.Ketnoi();

            SqlConnection conn = Functions.Conn;
          
           // dgnv.Columns[10].Width = 100;
           // dgnv.Columns[11].Width = 100;

            dgnv.AllowUserToAddRows = false;
            dgnv.EditMode = DataGridViewEditMode.EditProgrammatically;
            string sqlcn = "select machinhanh, tenchinhanh from chinhanh";
             Functions.Fillcombo(sqlcn, cbmcn, "machinhanh", "tenchinhanh");
            string sqlcv = "select machucvu, tenchucvu from chucvu";
             Functions.Fillcombo(sqlcv, cbmcv, "machucvu", "tenchucvu");
            loaddata();
            

            btnLuu.Enabled  = false;
            btnHuy.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void loaddata()
        {
            string sql;
            sql = "select a.manv, hotennv, gioitinh, ngaysinh, email, a.sdt, a.diachi,b.tenchinhanh, c.username, d.tenchucvu, c.password, c.quyenhan from dbo.nhanvien a join chinhanh b on a.machinhanh = b.machinhanh join taikhoan c on a.mataikhoan = c.mataikhoan join chucvu d on d.machucvu = a.machucvu where a.hoatdong = 1";
            DataTable a =  Functions.GetdataToTable(sql);
            dgnv.DataSource = a;

            dgnv.Columns[0].HeaderText = "Mã nhân viên ";
            dgnv.Columns[1].HeaderText = "Họ tên ";
            dgnv.Columns[2].HeaderText = "Giới tính";
            dgnv.Columns[3].HeaderText = "Ngày sinh";
            dgnv.Columns[4].HeaderText = "Email";
            dgnv.Columns[5].HeaderText = "Số điện thoại";
            dgnv.Columns[6].HeaderText = "Địa chỉ";
            dgnv.Columns[7].HeaderText = "Chi nhánh";
            dgnv.Columns[8].HeaderText = "Mã tài khoản";
            dgnv.Columns[9].HeaderText = "Chức vụ";
            dgnv.Columns[10].HeaderText = "password";
            dgnv.Columns[11].HeaderText = "quyền hạn";




            dgnv.Columns[0].Width = 100;
            dgnv.Columns[1].Width = 125;
            dgnv.Columns[2].Width = 90;
            dgnv.Columns[3].Width = 100;
            dgnv.Columns[4].Width = 150;
            dgnv.Columns[5].Width = 115;
            dgnv.Columns[6].Width = 115;
            dgnv.Columns[7].Width = 115;
            dgnv.Columns[8].Width = 100;
            dgnv.Columns[9].Width = 100;
            dgnv.Columns[10].Width = 100;
            dgnv.Columns[11].Width = 100;


        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            
            txtmnv.Enabled = false;
            btnLuu.Enabled = true;
            btnthem.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnSua.Enabled = false;
            txtht.Clear();
            cbmcn.SelectedIndex = -1;
            // Lấy mã sản phẩm lớn nhất trong bảng sản phẩm
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(MaNV) FROM NhanVien";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxManv = Convert.ToInt32(result);
                // Tăng mã sản phẩm lên 1 và hiển thị trong txtmasp
                txtmnv.Text = (maxManv + 1).ToString();
            }
            else
            {
                // Nếu không có sản phẩm nào trong bảng, gán mã sản phẩm mặc định là 1
                txtmnv.Text = "1";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnthem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtmnv.Enabled = false;
            btnLuu.Enabled = false;
            resetvalue();
        }
        private void resetvalue()
        {
            txtmnv.Text = "";
            txtht.Text = "";
            txtgt.Text = "";
            maskngaysinh.Text = "";
            txtemail.Text = "";
            cbmcn.Text = "";
            txtsdt.Text = "";
            txtdc.Text = "";
            cbmcv.Text = "";
            txtpassword.Text = "";
            txtusername.Text = "";
            cboquyenhan.Text = "";

        }

        private void dgnv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sqlthemtaikhoan = " insert into taikhoan values('" + txtusername.Text.Trim() + "','" + txtpassword.Text.Trim() + "',N'" + cboquyenhan.Text.Trim() + "')";
            Functions.Runsql(sqlthemtaikhoan);
            string sqltruyvantaikhoan = "Select * from taikhoan where username = '" + txtusername.Text.Trim() + "'";
            SqlCommand cmdTimTK = new SqlCommand(sqltruyvantaikhoan, Functions.Conn);
            SqlDataReader reader = cmdTimTK.ExecuteReader();
            reader.Read();
            string matk1 = reader["mataikhoan"].ToString();
            reader.Close();
            string sql;
            sql = "INSERT INTO dbo.nhanvien (hotennv, gioitinh, ngaysinh, email, sdt, diachi, machinhanh, mataikhoan, machucvu, hoatdong) VALUES (N'" + txtht.Text.Trim() + "', N'" + txtgt.Text.Trim() + "','"+maskngaysinh.Text.Trim()+ "', N'" + txtemail.Text.Trim() +"', N'" + txtsdt.Text.Trim() + "', N'" + txtdc.Text.Trim() +"','" + cbmcn.SelectedValue  + "', '" + matk1 +"','" + cbmcv.SelectedValue +"', 1)";
            SqlCommand command = new SqlCommand(sql, Functions.Conn);
           // command.Parameters.AddWithValue("tk1", matk1);

            if (! Functions.Checkkey(sql))
            {
                // Thực hiện câu lệnh INSERT khi không có trùng khóa
                // ...

                txtht.Text = "";
                txtht.Focus();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Trùng khóa! Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            loaddata();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maNV = Convert.ToInt32(txtmnv.Text.Trim());
                string sql = " update nhanvien set hoatdong = 0 where manv = '"+ maNV +"' ";

                string connectionString = Functions.Conn.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            txtht.Text = "";
                            txtht.Focus();
                            MessageBox.Show("Đã xóa nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loaddata();
                        }
                        else
                        {
                            MessageBox.Show("Xóa nhân viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void cbmcn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sqltruyvantaikhoan = "Select * from taikhoan where username = '" + txtusername.Text.Trim() + "'";
            SqlCommand cmdTimTK = new SqlCommand(sqltruyvantaikhoan, Functions.Conn);
            SqlDataReader reader = cmdTimTK.ExecuteReader();
            reader.Read();
            string matk1 = reader["mataikhoan"].ToString();
            reader.Close();

            string sqlthemtaikhoan = " update taikhoan set username = N'"+txtusername.Text.Trim()+"', password = N'"+txtpassword.Text.Trim()+ "', quyenhan = N'"+cboquyenhan.Text.Trim()+"' where mataikhoan = '" + matk1+"'"   ;
            Functions.Runsql(sqlthemtaikhoan);

            string sql;
            sql = "update nhanvien set hotenNV = N'"+txtht.Text.Trim()+"', gioitinh = N'"+txtgt.Text.Trim()+ "', ngaysinh = '"+maskngaysinh.Text.Trim()+"' , email =N'" + txtemail.Text.Trim()+"', sdt = N'"+txtsdt.Text.Trim()+"', diachi = N'"+txtdc.Text.Trim()+"', machinhanh = '"+cbmcn.SelectedValue+"',machucvu = '"+cbmcv.SelectedValue+ "' where maNV = '" + txtmnv.Text.Trim() +"'" ;
            Functions.Runsql(sql);
            SqlCommand command = new SqlCommand(sql, Functions.Conn);
            // command.Parameters.AddWithValue("tk1", matk1);

            if (! Functions.Checkkey(sql))
            {
                // Thực hiện câu lệnh INSERT khi không có trùng khóa
                // ...

               // txtht.Text = "";
               // txtht.Focus();
                MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa Không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            loaddata();
        }

        private void dgnv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmnv.Text = dgnv.CurrentRow.Cells["MaNV"].Value.ToString();
            txtht.Text = dgnv.CurrentRow.Cells["HoTenNV"].Value.ToString();
            txtgt.Text = dgnv.CurrentRow.Cells["GioiTinh"].Value.ToString();
            maskngaysinh.Text = dgnv.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txtemail.Text = dgnv.CurrentRow.Cells["Email"].Value.ToString();
            txtsdt.Text = dgnv.CurrentRow.Cells["SDT"].Value.ToString();
            txtdc.Text = dgnv.CurrentRow.Cells["DiaChi"].Value.ToString();
            cbmcn.Text = dgnv.CurrentRow.Cells["tenchinhanh"].Value.ToString();
            txtusername.Text = dgnv.CurrentRow.Cells["username"].Value.ToString();
            txtpassword.Text = dgnv.CurrentRow.Cells["password"].Value.ToString();
            cbmcv.Text = dgnv.CurrentRow.Cells["tenchucvu"].Value.ToString();
            cboquyenhan.Text = dgnv.CurrentRow.Cells["quyenhan"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
