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
    public partial class NCCap : Form
    {
        public NCCap()
        {
            InitializeComponent();
        }
        DataTable tblncc;
        private void NCC_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();
            txtmancc.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            //txttenncc.Enabled = false;
            //txtemail.Enabled = false;
            //txtdiachi.Enabled = false;
            //msksdt.Enabled = false;
            //txtghichu.Enabled = false;
            load_datagrid();
            ResetValues();
        }
        private void ResetValues()
        {
            // Không reset giá trị của txtmanv
             txtmancc.Text = "";
            txttenncc.Text = "";
            txtdiachi.Text = "";
            txtemail.Text = "";
            msksdt.Text = "";
            txtghichu.Text = "";
        }
        private void load_datagrid()
        {
            string sql;
            sql = "SELECT * FROM NhaCungCap";
            tblncc = Functions.GetdataToTable(sql);
            dgridncc.DataSource = tblncc;
            dgridncc.Columns[0].HeaderText = "Mã NCC ";
            dgridncc.Columns[1].HeaderText = "Tên NCC ";
            dgridncc.Columns[2].HeaderText = "Địa chỉ";
            dgridncc.Columns[3].HeaderText = "Số điện thoại";
            dgridncc.Columns[4].HeaderText = "Email";
            dgridncc.Columns[5].HeaderText = "Ghi chú";
            dgridncc.AllowUserToAddRows = false;
            dgridncc.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridncc_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmancc.Focus();
                return;
            }
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmancc.Text = dgridncc.CurrentRow.Cells["MaNCC"].Value.ToString();
            txttenncc.Text = dgridncc.CurrentRow.Cells["TenNCC"].Value.ToString();
            txtdiachi.Text = dgridncc.CurrentRow.Cells["DiaChi"].Value.ToString();
            msksdt.Text = dgridncc.CurrentRow.Cells["Sodienthoai"].Value.ToString();
            txtemail.Text = dgridncc.CurrentRow.Cells["Email"].Value.ToString();
            txtghichu.Text = dgridncc.CurrentRow.Cells["Ghichu"].Value.ToString();

            txtmancc.Enabled = false;
            txtdiachi.Enabled = true;
            txttenncc.Enabled = false;
            txtemail.Enabled = true;
            msksdt.Enabled = true;
            txtghichu.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnhuy.Enabled = true;
            txttenncc.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
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
                int maxMaNCC = Convert.ToInt32(result);
                // Tăng mã sản phẩm lên 1 và hiển thị trong txtmasp
                txtmancc.Text = (maxMaNCC + 1).ToString();
            }
            else
            {
                // Nếu không có sản phẩm nào trong bảng, gán mã sản phẩm mặc định là 1
                txtmancc.Text = "1";
            }

            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
            btnsua.Enabled = false;
            //txtmakh.Enabled = true;
            //txtmakh.Focus();
            txttenncc.Enabled = true;
            txttenncc.Focus();
            txtdiachi.Enabled = true;
            txtemail.Enabled = true;
            txtghichu.Enabled = true;
            msksdt.Enabled = true;

            //cbogioitinh.Focus();
            ResetValues();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;


            if (txttenncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenncc.Focus();
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

            if (txtghichu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtghichu.Focus();
                return;
            }

            sql = "SELECT MaNCC FROM NhaCungCap WHERE MaNCC =N'" + txtmancc + "'";

            int mancc = int.Parse(txtmancc.Text.Trim());

            sql = "INSERT INTO NhaCungCap (MaNCC,TenNCC,DiaChi,Sodienthoai,Email,Ghichu) " +
                "VALUES('" + mancc + "',N'" + txttenncc.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "','" + msksdt.Text.Trim() + "','" + txtemail.Text.Trim() + "',N'" + txtghichu.Text.Trim() + "')";

            Functions.Runsql(sql);
            load_datagrid();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            txtmancc.Enabled = false;
            txttenncc.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmancc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            if (txttenncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenncc.Focus();
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

            //if (txtghichu.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Bạn phải nhập ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtghichu.Focus();
            //    return;
            //}

            sql = "UPDATE NhaCungCap SET TenNCC=N'" + txttenncc.Text.Trim().ToString() + "',DiaChi=N'" + txtdiachi.Text.Trim().ToString() + "',Sodienthoai=N'" + msksdt.Text.ToString() + "',Email='" + txtemail.Text.ToString() + "',Ghichu=N'" + txtghichu.Text.Trim() + "' WHERE MaNCC=N'" + txtmancc.Text + "'";
            Functions.RunSQL(sql);
            load_datagrid();
            ResetValues();
            btnhuy.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmancc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE NhaCungCap WHERE MaNCC=N'" + txtmancc.Text + "'";
                Functions.RunSQL(sql);
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
            txtmancc.Enabled = false;
            load_datagrid();
            txtmancc.Text = "";
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txttenncc.Text == "") && (msksdt.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM NhaCungCap WHERE 1=1";
            //if (txtmakh.Text != "")
            //    sql = sql + " AND MaKH Like N'%" + txtmakh.Text + "%'";

            if (txttenncc.Text != "")
                sql = sql + " AND TenNCC Like N'%" + txttenncc.Text + "%'";

            if (msksdt.Text != "")
                sql = sql + " AND Sodienthoai Like N'%" + msksdt.Text + "%'";

            tblncc = Functions.GetdataToTable(sql);
            if (tblncc.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblncc.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dgridncc.DataSource = tblncc;
            ResetValues();
            txtmancc.Enabled = true;
            txttenncc.Enabled = true;
            msksdt.Enabled = true;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát form Nhà cung cấp không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                main main = new main();
                main.Show();
            }
        }

        private void txtmancc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txttenncc_KeyUp(object sender, KeyEventArgs e)
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

        private void txtemail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
