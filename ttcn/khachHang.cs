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
    public partial class khachHang : Form
    {
        public khachHang()
        {
            InitializeComponent();
        }
        DataTable tblkh;
        private void khachHang_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();
            txtmakh.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            //txttenkh.Enabled = false;
            //txtemail.Enabled = false;
            //txtdiachi.Enabled = false;
            //mskngaysinh.Enabled = false;
            //msksdt.Enabled = false;
            load_datagrid();
            Functions.Fillcombo("SELECT DISTINCT GioiTinh FROM Khachhang", cbogioitinh, "GioiTinh", "GioiTinh");
            cbogioitinh.SelectedIndex = -1;
            ResetValues();
        }

        private void ResetValues()
        {
            // Không reset giá trị của txtmanv
            // txtmakh.Text = "";
            txttenkh.Text = "";
            txtdiachi.Text = "";
            txtemail.Text = "";
            msksdt.Text = "";
            mskngaysinh.Text = "";
            cbogioitinh.Text = "";
            txtmakh.Text = "";
        }

        private void load_datagrid()
        {
            string sql;
            sql = "SELECT * FROM Khachhang";
            tblkh = Functions.GetdataToTable(sql);
            dgridkhachhang.DataSource = tblkh;
            dgridkhachhang.Columns[0].HeaderText = "Mã khách ";
            dgridkhachhang.Columns[1].HeaderText = "Họ tên khách ";
            dgridkhachhang.Columns[2].HeaderText = "Ngày sinh";
            dgridkhachhang.Columns[3].HeaderText = "Giới tính";
            dgridkhachhang.Columns[4].HeaderText = "Email";
            dgridkhachhang.Columns[5].HeaderText = "Số điện thoại";
            dgridkhachhang.Columns[6].HeaderText = "Địa chỉ";
            dgridkhachhang.AllowUserToAddRows = false;
            dgridkhachhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridkhachhang_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakh.Focus();
                return;
            }
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmakh.Text = dgridkhachhang.CurrentRow.Cells["MaKH"].Value.ToString();
            txttenkh.Text = dgridkhachhang.CurrentRow.Cells["Tenkhachhang"].Value.ToString();
            cbogioitinh.Text = dgridkhachhang.CurrentRow.Cells["GioiTinh"].Value.ToString();
            mskngaysinh.Text = dgridkhachhang.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txtdiachi.Text = dgridkhachhang.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtemail.Text = dgridkhachhang.CurrentRow.Cells["Email"].Value.ToString();
            msksdt.Text = dgridkhachhang.CurrentRow.Cells["Sodienthoai"].Value.ToString();

            txtmakh.Enabled = true;
            txtdiachi.Enabled = true;
            txttenkh.Enabled = true;
            txtemail.Enabled = true;
            msksdt.Enabled = true;
            mskngaysinh.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnhuy.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            // Lấy mã sản phẩm lớn nhất trong bảng sản phẩm
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(MaKH) FROM Khachhang";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxMaKH = Convert.ToInt32(result);
                // Tăng mã sản phẩm lên 1 và hiển thị trong txtmasp
                txtmakh.Text = (maxMaKH + 1).ToString();
            }
            else
            {
                // Nếu không có sản phẩm nào trong bảng, gán mã sản phẩm mặc định là 1
                txtmakh.Text = "1";
            }

            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
            btnsua.Enabled = false;
            //txtmakh.Enabled = true;
            //txtmakh.Focus();
            txttenkh.Enabled = true;
            txttenkh.Focus();
            txtdiachi.Enabled = true;
            txtemail.Enabled = true;
            mskngaysinh.Enabled = true;
            msksdt.Enabled = true;
            cbogioitinh.Enabled = true;
            //cbogioitinh.Focus();
            ResetValues();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;


            if (txttenkh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenkh.Focus();
                return;
            }

            if (mskngaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn cần nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Focus();
                return;
            }

            if (!Functions.IsDate(mskngaysinh.Text))
            {
                MessageBox.Show("Bạn cần nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Text = "";
                mskngaysinh.Focus();
                return;
            }

            if (cbogioitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbogioitinh.Focus();
                return;
            }

            if (txtemail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
                return;
            }

            if (msksdt.Text == "(   )    -")
            {
                MessageBox.Show("Bạn cần nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msksdt.Focus();
                return;
            }

            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }

            sql = "SELECT MaKH FROM Khachhang WHERE MaKH =N'" + txtmakh + "'";


            //string makh = Functions.GetFieldValues(sql);
            //sql = "INSERT INTO Khachhang (MaKH,Tenkhachhang,NgaySinh,GioiTinh,Email,Sodienthoai,DiaChi) VALUES('"+txtmakh+"',N'"+txttenkh.Text.Trim()+"','"+Functions.ConvertDateTime(mskngaysinh.Text.Trim())+"',N'"+cbogioitinh.SelectedValue.ToString()+"','"+txtemail.Text.Trim()+"','"+msksdt.Text.Trim()+"',N'"+txtdiachi.Text.Trim()+"')";

            //sql = "INSERT INTO Khachhang (MaKH,Tenkhachhang,NgaySinh,GioiTinh,Email,Sodienthoai,DiaChi) " +
            //"VALUES('"+txtmakh+"',N'"+txttenkh.Text.Trim()+"','"+Functions.ConvertDateTime(mskngaysinh.Text.Trim())+"',N'"+cbogioitinh.SelectedValue.ToString()+"','"+txtemail.Text.Trim()+"','"+msksdt.Text.Trim()+"',N'"+txtdiachi.Text.Trim()+"')";

            int makh = int.Parse(txtmakh.Text.Trim());

            sql = "INSERT INTO Khachhang (MaKH,Tenkhachhang,NgaySinh,GioiTinh,Email,Sodienthoai,DiaChi) " +
                "VALUES('" + makh + "',N'" + txttenkh.Text.Trim() + "','" + Functions.ConvertDateTime(mskngaysinh.Text.Trim()) + "',N'" + cbogioitinh.SelectedValue.ToString() + "','" + txtemail.Text.Trim() + "','" + msksdt.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "')";

            Functions.Runsql(sql);
            load_datagrid();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            txtmakh.Enabled = false;
            txttenkh.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmakh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            if (txttenkh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenkh.Focus();
                return;
            }

            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }

            if (txtemail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
                return;
            }

            if (msksdt.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msksdt.Focus();
                return;
            }

            if (mskngaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Focus();
                return;
            }

            if (!Functions.IsDate(mskngaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Text = "";
                mskngaysinh.Focus();
                return;
            }

            if (cbogioitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbogioitinh.Focus();
                return;
            }

            sql = "UPDATE Khachhang SET Tenkhachhang=N'" + txttenkh.Text.Trim().ToString() + "',DiaChi=N'" + txtdiachi.Text.Trim().ToString() + "',Sodienthoai=N'" + msksdt.Text.ToString() + "',Email='" + txtemail.Text.ToString() + "',GioiTinh=N'" + cbogioitinh.SelectedValue.ToString() + "',NgaySinh='" + Functions.ConvertDateTime(mskngaysinh.Text) + "' WHERE MaKH=N'" + txtmakh.Text + "'";
            Functions.Runsql(sql);
            load_datagrid();
            ResetValues();
            btnhuy.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmakh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Khachhang WHERE MaKH=N'" + txtmakh.Text + "'";
                Functions.Runsql(sql);
                load_datagrid();
                ResetValues();
            }

        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmakh.Enabled = false;
            load_datagrid() ;
            txtmakh.Text = "";
           
        }

       

        private void txtmakh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txttenkh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void mskngaysinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void cbogioitinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtemail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void msksdt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát form Khách hàng không? ","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                main main = new main();
                main.Show();
            }
        }

        

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txttenkh.Text == "") && (msksdt.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM Khachhang WHERE 1=1";
            //if (txtmakh.Text != "")
            //    sql = sql + " AND MaKH Like N'%" + txtmakh.Text + "%'";

            if (txttenkh.Text != "")
                sql = sql + " AND Tenkhachhang Like N'%" + txttenkh.Text + "%'";

            if (msksdt.Text != "")
                sql = sql + " AND Sodienthoai Like N'%" + msksdt.Text + "%'";

            tblkh = Functions.GetDataToTable(sql);
            if (tblkh.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblkh.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dgridkhachhang.DataSource = tblkh;
            ResetValues();
            btnhuy.Enabled = true;
            txtmakh.Enabled = true;
            txttenkh.Enabled = true;
            msksdt.Enabled = true;
        }
    }
}
