using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ttcn.Class;

namespace ttcn
{
    public partial class frmthongtincanhan : Form
    {
        
        public frmthongtincanhan()
        {
            InitializeComponent();
            
        }
        

        private void frmthongtincanhan_Load(object sender, EventArgs e)
        {
            Class.Functions.Ketnoi();
            string username = Globals.Us;
            string password = Globals.Pass;
            string sqlcn = "select machinhanh, tenchinhanh from chinhanh";
            Functions.Fillcombo(sqlcn, cbmcn, "machinhanh", "tenchinhanh");
            string sqlcv = "select machucvu, tenchucvu from chucvu";
            Functions.Fillcombo(sqlcv, cbmcv, "machucvu", "tenchucvu");

            string sql = "select a.manv, hotennv, gioitinh, ngaysinh, email, a.sdt, a.diachi,b.tenchinhanh, c.username, d.tenchucvu, c.password, c.quyenhan from dbo.nhanvien a join chinhanh b on a.machinhanh = b.machinhanh join taikhoan c on a.mataikhoan = c.mataikhoan join chucvu d on d.machucvu = a.machucvu where c.username = '"+username+"'";
            SqlCommand cmdTimTK = new SqlCommand(sql, Functions.Conn);
            SqlDataReader reader = cmdTimTK.ExecuteReader();
            reader.Read();
            string mnv = reader["manv"].ToString();
            string ht = reader["hotennv"].ToString();
            string dc = reader["diachi"].ToString();
            txtemail.Text = reader["email"].ToString();
            txtgt.Text = reader["gioitinh"].ToString();
            txtpassword.Text = reader["password"].ToString();
            txtsdt.Text = reader["sdt"].ToString();
            txtusername.Text = reader["username"].ToString();
            cbmcn.Text = reader["tenchinhanh"].ToString();
            cbmcv.Text = reader["tenchucvu"].ToString();
            maskngaysinh.Text = reader["ngaysinh"].ToString() ;
            reader.Close();
            txtmnv.Text = mnv;
            txtht.Text = ht;
            txtdc.Text = dc;
            
            txtmnv.Enabled = false;
            txtht.Enabled = false;
            txtdc.Enabled = false;
            txtemail.Enabled = false;
            txtgt.Enabled = false;
            txtpassword.Enabled = false;
            txtsdt.Enabled = false;
            txtusername.Enabled = false;
            cbmcn.Enabled = false;
            cbmcv.Enabled = false;
            maskngaysinh.Enabled = false;
            btnluu.Enabled = false;

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txtht.Enabled = true;
            txtdc.Enabled = true;
            txtemail.Enabled = true;
            txtgt.Enabled = true;
            txtpassword.Enabled = true;
            txtsdt.Enabled = true;
            
            
            maskngaysinh.Enabled = true;
            btnsua.Enabled = false;
            btnluu.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sqlthemtaikhoan = " update taikhoan set  password = N'" + txtpassword.Text.Trim() + "' where username = '" + txtusername.Text.Trim() + "'";
            Functions.Runsql(sqlthemtaikhoan);

            string sql;
            sql = "update nhanvien set hotenNV = N'" + txtht.Text.Trim() + "', gioitinh = N'" + txtgt.Text.Trim() + "', ngaysinh = '" + maskngaysinh.Text.Trim() + "' , email =N'" + txtemail.Text.Trim() + "', sdt = N'" + txtsdt.Text.Trim() + "', diachi = N'" + txtdc.Text.Trim() + "' where maNV = '" + txtmnv.Text.Trim() + "'";
            Functions.Runsql(sql);
            
            SqlCommand command = new SqlCommand(sql, Functions.Conn);
            // command.Parameters.AddWithValue("tk1", matk1);

            if (!Functions.Checkkey(sql))
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
        }
    }
}
