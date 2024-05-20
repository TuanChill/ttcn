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
    public partial class NV : Form
    {
        public NV()
        {
            InitializeComponent();
        }

       

        private void btndong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát form Nhân viên không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                main main = new main();
                main.Show();
            }
        }
        DataTable tblnv;

        private void NV_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();
            txtmanv.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            load_datagrid();
            Functions.Fillcombo("SELECT MaChiNhanh, Tenchinhanh FROM Chinhanh", cbochinhanh, "MaChiNhanh", "Tenchinhanh");
            cbochinhanh.SelectedIndex = -1;
            Functions.Fillcombo("SELECT Machucvu, Tenchucvu FROM Chucvu", cbochucvu, "Machucvu", "Tenchucvu");
            cbochucvu.SelectedIndex = -1;
            Functions.Fillcombo("SELECT DISTINCT GioiTinh FROM NhanVien", cbogioitinh, "GioiTinh", "GioiTinh");
            cbogioitinh.SelectedIndex = -1;
            ResetValues();
        }
        private void ResetValues()
        {
            // Không reset giá trị của txtmanv
             txtmanv.Text = "";
            txthoten.Text = "";
            cbochinhanh.Text = "";
            cbochucvu.Text = "";
            txtdiachi.Text = "";
            txtemail.Text = "";
         //   txtpass.Text = "";
            msksdt.Text = "";
            mskngaysinh.Text = "";
           // txtusername.Text = "";
            cbogioitinh.Text = "";
            //txtmanv.Text = "";
            //txthoten.Text = "";
            //cbochinhanh.Text = "";
            //cbochucvu.Text = "";
            //txtdiachi.Text = "";
            //txtemail.Text = "";
            //txtpass.Text = "";
            //msksdt.Text = "";
            //txtusername.Text = "";
        }

        private void load_datagrid()
        {
            string sql;
            sql = "SELECT Manhanvien,Tennhanvien,Gioitinh,NgaySinh,DiaChi,Email,Sodienthoai,MaChiNhanh,Machucvu FROM NhanVien ";
            tblnv = Functions.GetdataToTable(sql);
            dgridnhanvien.DataSource = tblnv;
            dgridnhanvien.Columns[0].HeaderText = "Mã nhân viên ";
            dgridnhanvien.Columns[1].HeaderText = "Họ tên ";
            dgridnhanvien.Columns[2].HeaderText = "Giới tính";
            dgridnhanvien.Columns[3].HeaderText = "Ngày sinh";
            dgridnhanvien.Columns[4].HeaderText = "Địa chỉ";
            dgridnhanvien.Columns[5].HeaderText = "Email";
            dgridnhanvien.Columns[6].HeaderText = "Số điện thoại";
            dgridnhanvien.Columns[7].HeaderText = "Chi nhánh";
            dgridnhanvien.Columns[8].HeaderText = "Chức vụ";
            //dgridnhanvien.Columns[9].HeaderText = "Username";
            //dgridnhanvien.Columns[10].HeaderText = "Password";
            dgridnhanvien.AllowUserToAddRows = false;
            dgridnhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridnhanvien_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanv.Focus();
                return;
            }
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmanv.Text = dgridnhanvien.CurrentRow.Cells["Manhanvien"].Value.ToString();
            txthoten.Text = dgridnhanvien.CurrentRow.Cells["Tennhanvien"].Value.ToString();
            cbogioitinh.Text = dgridnhanvien.CurrentRow.Cells["GioiTinh"].Value.ToString();
            mskngaysinh.Text = dgridnhanvien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txtdiachi.Text = dgridnhanvien.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtemail.Text = dgridnhanvien.CurrentRow.Cells["Email"].Value.ToString();
            msksdt.Text = dgridnhanvien.CurrentRow.Cells["Sodienthoai"].Value.ToString();

            ma = dgridnhanvien.CurrentRow.Cells["MaChiNhanh"].Value.ToString();
            cbochinhanh.Text = Functions.GetFieldValues("SELECT Tenchinhanh FROM Chinhanh WHERE MaChiNhanh =N'" + ma + "'");
            ma = dgridnhanvien.CurrentRow.Cells["Machucvu"].Value.ToString();
            cbochucvu.Text = Functions.GetFieldValues("SELECT Tenchucvu FROM Chucvu WHERE Machucvu =N'" + ma + "'");
            //txtusername.Text = dgridnhanvien.CurrentRow.Cells["Username"].Value.ToString();
            //txtusername.Text = Functions.GetFieldValues("SELECT TaiKhoan.Username FROM TaiKhoan JOIN NhanVien ON TaiKhoan.Mataikhoan = NhanVien.Mataikhoan WHERE Taikhoan.Mataikhoan ='" + ma + "'");
            //txtpass.Text = dgridnhanvien.CurrentRow.Cells["Password"].Value.ToString();
            //txtpass.Text = Functions.GetFieldValues("SELECT TaiKhoan.Password FROM TaiKhoan JOIN NhanVien ON TaiKhoan.Mataikhoan = NhanVien.Mataikhoan WHERE Taikhoan.Mataikhoan ='" + ma + "'");
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnhuy.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmanv.Enabled = true;
           
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
            btnsua.Enabled = false;

            txthoten.Enabled = true;
            txthoten.Focus();
            txtdiachi.Enabled = true;
            txtemail.Enabled = true;
            mskngaysinh.Enabled = true;
            msksdt.Enabled = true;
            //txtusername.Enabled = true;
            //txtpass.Enabled = true;
            cbochinhanh.Enabled = true;
            cbochucvu.Enabled = true;
            cbogioitinh.Enabled = true;
            //cbogioitinh.Focus();
            ResetValues();
            // Lấy mã sản phẩm lớn nhất trong bảng sản phẩm
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }
            string query = "SELECT MAX(Manhanvien) FROM NhanVien";
            SqlCommand command = new SqlCommand(query, Functions.Conn);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int maxMaNV = Convert.ToInt32(result);
                // Tăng mã sản phẩm lên 1 và hiển thị trong txtmasp
                txtmanv.Text = (maxMaNV + 1).ToString();
            }
            else
            {
                // Nếu không có sản phẩm nào trong bảng, gán mã sản phẩm mặc định là 1
                txtmanv.Text = "1";
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;


            if (txthoten.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txthoten.Focus();
                return;
            }

            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }



            if (txtemail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
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

            if (msksdt.Text == "(   )    -")
            {
                MessageBox.Show("Bạn cần nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msksdt.Focus();
                return;
            }

            if (cbochinhanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chi nhánh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbochinhanh.Focus();
                return;
            }

            if (cbochucvu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbochucvu.Focus();
                return;
            }

            if (cbogioitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbogioitinh.Focus();
                return;
            }
            ////// Chèn dữ liệu vào bảng TaiKhoan
            //sql = "INSERT INTO TaiKhoan (Username, Password) VALUES (N'" + txtusername.Text.Trim() + "',N'" + txtpass.Text.Trim() + "');" +
            //      "SELECT SCOPE_IDENTITY();";
            //string mataikhoan = Functions.GetFieldValues(sql);
            //string manhanvien = Functions.GetFieldValues(sql);
            //// Chèn dữ liệu vào bảng NhanVien với Mataikhoan vừa tạo
            sql = "INSERT INTO NhanVien (Manhanvien,Tennhanvien, Gioitinh, NgaySinh, DiaChi, Email, Sodienthoai, MaChiNhanh, Machucvu)" +
                  "VALUES ('" + txtmanv.Text + "',N'" + txthoten.Text.Trim() + "',N'" + cbogioitinh.Text.Trim() + "','" + Functions.ConvertDateTime(mskngaysinh.Text.Trim()) + "',N'" + txtdiachi.Text.Trim() + "',N'" + txtemail.Text.Trim() + "','" + msksdt.Text + "','" + cbochinhanh.SelectedValue.ToString() + "','" + cbochucvu.SelectedValue.ToString()   + "')";

            Functions.Runsql(sql);
            load_datagrid();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            txthoten.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txthoten.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập họ tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txthoten.Focus();
                return;
            }
            if (cbogioitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn giới tính nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbogioitinh.Focus();
                return;
            }

            if (mskngaysinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Focus();
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

            if (msksdt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msksdt.Focus();
                return;
            }

            if (cbochinhanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn chi nhánh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbochinhanh.Focus();
                return;
            }

            if (cbochucvu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbochucvu.Focus();
                return;
            }

            //if (txtusername.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Bạn phải nhập username", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtusername.Focus();
            //    return;
            //}

            //if (txtpass.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Bạn phải nhập password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtpass.Focus();
            //    return;
            //}

            //sql = "UPDATE NhanVien SET Tennhanvien=N'"+txthoten.Text.Trim().ToString()+"',Gioitinh=N'"+gt + "',Ngaysinh='" + Functions.ConvertDateTime(mskngaysinh.Text) + "' WHERE Manhanvien=N'" + txtmanhanvien.Text + "',Diachi=N'\"+txtdiachi.Text.Trim().ToString()+\"',Dienthoai=N'\" + mskdienthoai.Text.ToString() + \"'";

            //sql = "UPDATE NhanVien SET Tennhanvien=N'"+txthoten.Text.Trim().ToString()+"',GioiTinh=N'"+cbogioitinh.Text.Trim().ToString()+"',NgaySinh='"+ Functions.ConvertDateTime(mskngaysinh.Text.Trim())+"',DiaChi=N'"+txtdiachi.Text.Trim().ToString()+"',Email=N'"+txtemail.Text.Trim().ToString()+"',Sodienthoai=N'"+msksdt.Text.Trim().ToString()+"',MaChiNhanh=N'"+cbochinhanh.Text.Trim().ToString()+"',Machucvu=N'"+cbochucvu.Text.Trim().ToString()+"',Username=N'"+txtusername.Text.Trim().ToString()+"',Password=N'"+txtpass.Text.Trim().ToString()+"' WHERE Manhanvien=N'"+txtmanv.Text.Trim().ToString()+"'";

            //Functions.runsql(sql);
            //load_datagrid();
            //ResetValues();
            //btnhuy.Enabled = false;

            // Cập nhật bảng NhanVien
            sql = "UPDATE NhanVien SET " +
            "Tennhanvien=N'" + txthoten.Text.Trim() + "', " +
            "GioiTinh=N'" + cbogioitinh.Text.Trim() + "', " +
            "NgaySinh='" + Functions.ConvertDateTime(mskngaysinh.Text.Trim()) + "', " +
            "DiaChi=N'" + txtdiachi.Text.Trim() + "', " +
            "Email=N'" + txtemail.Text.Trim() + "', " +
            "Sodienthoai=N'" + msksdt.Text.Trim() + "', " +
            "MaChiNhanh=N'" + cbochinhanh.SelectedValue.ToString() + "', " +
            "Machucvu=N'" + cbochucvu.SelectedValue.ToString() + "' " +
            "WHERE Manhanvien='" + txtmanv.Text.Trim() + "'";

            //try
            //{

            //    Functions.Runsql(sql);
            //    // Cập nhật bảng TaiKhoan
            //    //sql = "UPDATE TaiKhoan SET " +
            //    //      "Username=N'" + txtusername.Text.Trim() + "', " +
            //    //      "Password=N'" + txtpass.Text.Trim() + "' " +
            //    //      "WHERE Mataikhoan='" + txtmanv.Text.Trim() + "'";

            //    //Functions.Runsql(sql);

            //    load_datagrid();
            //    ResetValues();
            //    btnhuy.Enabled = false;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmanv.Enabled = false;
            load_datagrid();
            txtmanv.Text = "";
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txthoten.Text == "") && (msksdt.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM NhanVien WHERE 1=1";

            if (txthoten.Text != "")
                sql = sql + " AND Tennhanvien Like N'%" + txthoten.Text + "%'";

            if (msksdt.Text != "")
                sql = sql + " AND Sodienthoai Like N'%" + msksdt.Text + "%'";

            tblnv = Functions.GetdataToTable(sql);
            if (tblnv.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblnv.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dgridnhanvien.DataSource = tblnv;
            ResetValues();
            txtmanv.Enabled = true;
            txthoten.Enabled = true;
            msksdt.Enabled = true;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmanv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE NhanVien WHERE Manhanvien=N'" + txtmanv.Text + "'";

                Functions.Runsql(sql);
                load_datagrid();
                ResetValues();
            }
        }

        private void txtmanv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txthoten_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void cbogioitinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void cbochucvu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void cbochinhanh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txtemail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txtdiachi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void msksdt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }
    }
}
