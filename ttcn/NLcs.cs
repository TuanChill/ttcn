using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ttcn.Class;

namespace ttcn
{
    public partial class formNL : Form
    {
        public formNL()
        {

            InitializeComponent();
        }

      
        DataTable dt;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaNL, TenNL, Maloai, Soluong, Gia, MaNCC,MaChiNhanh,MaTT FROM Nguyenlieu";
            dt = Functions.GetdataToTable(sql);
            datagridview_nguyenlieu.DataSource = dt;
            datagridview_nguyenlieu.Columns[0].HeaderText = "Mã nguyên liệu";
            datagridview_nguyenlieu.Columns[1].HeaderText = "Tên nguyên liệu";
            datagridview_nguyenlieu.Columns[2].HeaderText = "Mã loại";
            datagridview_nguyenlieu.Columns[3].HeaderText = "Số lượng";
            datagridview_nguyenlieu.Columns[4].HeaderText = "Giá";
            datagridview_nguyenlieu.Columns[5].HeaderText = "Nhà cung cấp ";
            datagridview_nguyenlieu.Columns[6].HeaderText = "Chi nhánh";
            datagridview_nguyenlieu.Columns[7].HeaderText = "Tình trạng";

            //datagridview_nguyenlieu.Columns[0].Width = 80;
            //datagridview_nguyenlieu.Columns[1].Width = 140;
            //datagridview_nguyenlieu.Columns[2].Width = 80;
            //datagridview_nguyenlieu.Columns[3].Width = 80;
            //datagridview_nguyenlieu.Columns[4].Width = 100;
            //datagridview_nguyenlieu.Columns[5].Width = 100;

            datagridview_nguyenlieu.AllowUserToAddRows = false;
            datagridview_nguyenlieu.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void ResetValues()
        {
            txt_manl.Text = "";
            txt_ten.Text = "";
            combo_maloai.Text = "";
            combo_chinhanh.Text = "";
            combo_mancc.Text = "";
            combo_matt.Text = "";
            txt_sl.Text = "0";
            txt_gia.Text = "0";

            //txt_gia.Enabled = false;
            //txt_sl.Enabled = false;

            txt_anh.Text = "";
            pic.Image = null;
            txt_ghichu.Text = "";
            
        }

        private void formNL_Load(object sender, EventArgs e)
        {
            Class.Functions.Ketnoi();
            txt_manl.Enabled = false;
            btn_luu.Enabled = false;
            btn_boqua.Enabled = false;
            Load_DataGridView();
            // maloai
            Functions.Fillcombo("SELECT Maloai, Tenloai FROM LoaiNL", combo_maloai, "Maloai", "Tenloai");
            combo_maloai.SelectedIndex = -1;
            //mancc
            Functions.Fillcombo("SELECT MaNCC, TenNCC FROM NhaCungCap", combo_mancc, "MaNCC", "TenNCC");
            combo_mancc.SelectedIndex = -1;
            // macnhanh
            Functions.Fillcombo("SELECT MaChiNhanh, Tenchinhanh FROM Chinhanh", combo_chinhanh, "MaChiNhanh", "Tenchinhanh");
            combo_chinhanh.SelectedIndex = -1;
            //matt
            Functions.Fillcombo("SELECT MaTT, mucdo FROM Tinhtrang", combo_matt, "MaTT", "mucdo");
            combo_matt.SelectedIndex = -1;
            ResetValues();
            txt_gia.Text = "0";
            txt_sl.Text = "0";
        }

        private void datagridview_nguyenlieu_Click(object sender, EventArgs e)
        {
            string ma,mancc,matt,macn;
            if (btn_them.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_manl.Focus();
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            txt_manl.Text = datagridview_nguyenlieu.CurrentRow.Cells["MaNL"].Value.ToString();
            txt_ten.Text = datagridview_nguyenlieu.CurrentRow.Cells["TenNL"].Value.ToString();
            ma =   datagridview_nguyenlieu.CurrentRow.Cells["Maloai"].Value.ToString();
            combo_maloai.Text = Functions.GetFieldValues("SELECT Tenloai FROM LoaiNL WHERE Maloai = N'" + ma + "'");

            //mancc = datagridview_nguyenlieu.CurrentRow.Cells["MaNCC"].Value.ToString();
            //combo_maloai.Text = Functions.GetFieldValues("SELECT TenNCC FROM NhaCungCap as a join Nguyenlieu as b on  WHERE MaNCC = N'" + mancc + "'");

            //macn = datagridview_nguyenlieu.CurrentRow.Cells["MaChiNhanh"].Value.ToString();
            //combo_maloai.Text = Functions.GetFieldValues("SELECT Tenchinhanh FROM Chinhanh WHERE MaChiNhanh = N'" + macn + "'");

            //matt = datagridview_nguyenlieu.CurrentRow.Cells["MaTT"].Value.ToString();
            //combo_maloai.Text = Functions.GetFieldValues("SELECT mucdo FROM Tinhtrang WHERE MaTT = N'" + matt + "'");
            combo_mancc.Text = Functions.GetFieldValues("select TenNCC from Nguyenlieu as a JOIN NhaCungCap AS b ON a.MaNCC = b.MaNCC WHERE MaNL = N'" + ma + "'");
            combo_matt.Text = Functions.GetFieldValues("select mucdo from Tinhtrang as a JOIN Nguyenlieu AS b ON a.MaTT = b.MaTT WHERE MaNL = N'" + ma + "'");
            combo_chinhanh.Text = Functions.GetFieldValues("select Tenchinhanh from Nguyenlieu as a JOIN Chinhanh AS b ON a.MaChiNhanh = b.MaChiNhanh WHERE MaNL = N'" + ma + "'");

            txt_sl.Text = datagridview_nguyenlieu.CurrentRow.Cells["SoLuong"].Value.ToString();
            txt_gia.Text = datagridview_nguyenlieu.CurrentRow.Cells["Gia"].Value.ToString();
            txt_anh.Text = Functions.GetFieldValues("SELECT Anh FROM Nguyenlieu WHERE MaNL = N'" + txt_manl.Text + "'");
            try
            {
                pic.Image = Image.FromFile(txt_anh.Text);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy ảnh", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                pic.Image = null;
            }
            txt_ghichu.Text = Functions.GetFieldValues("SELECT Ghichu FROM Nguyenlieu WHERE MaNL = N'" + txt_manl.Text + "'");
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            btn_boqua.Enabled = true;

        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgopen = new OpenFileDialog();
            dlgopen.Filter = "bitmap(*.bmp)|*.bmp|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgopen.InitialDirectory = "D:\\";
            dlgopen.FilterIndex = 3;
            dlgopen.Title = "Hãy chọn hình ảnh để hiển thị";
            if (dlgopen.ShowDialog() == DialogResult.OK)
            {
                pic.Image = Image.FromFile(dlgopen.FileName);
                txt_anh.Text = dlgopen.FileName;
            }
        }

        private void btn_boqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btn_boqua.Enabled = false;
            btn_them.Enabled = true;
            btn_xoa.Enabled = true;
            btn_sua.Enabled = true;
            btn_luu.Enabled = false;
            txt_manl.Enabled = false;
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát form Nguyên liệu?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                main main = new main();
                main.Show();
                return;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            btn_boqua.Enabled = true;
            btn_luu.Enabled = true;
            btn_them.Enabled = false;
            ResetValues();
            txt_manl.Enabled = true;
            txt_manl.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_manl.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Nguyenlieu WHERE MaNL=N'" + txt_manl.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();

            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txt_manl.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nguyên liệu", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txt_manl.Focus();
                return;
            }
            if (txt_ten.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nguyên liệu", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txt_ten.Focus();
                return;
            }

            if (combo_maloai.Text.Trim() == "0")
            {
                MessageBox.Show("Bạn phải chọn loại nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                combo_maloai.Focus();
                return;
            }
            if (txt_sl.Text.Trim() == "0")
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_sl.Focus();
                return;
            }
            if (txt_gia.Text.Trim() == "0")
            {
                MessageBox.Show("Bạn phải nhập giá nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_gia.Focus();
                return;
            }
            if (combo_mancc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                combo_mancc.Focus();
                return;
            }
            if (combo_matt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn tình trạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                combo_matt.Focus();
                return;
            }

            if (txt_anh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_anh.Focus();
                return;
            }
           
            if (combo_chinhanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn chi nhánh ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                combo_chinhanh.Focus();
                return;
            }
            
           
            sql = "SELECT MaNL FROM Nguyenlieu WHERE MaNL=N'" + txt_manl.Text.Trim() + "'";
            if (Functions.Checkkey(sql))
            {
                MessageBox.Show("Mã nguyên liệu này đã tồn, vui lòng nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_manl.Focus();
                txt_manl.Text = "";
                return;
            }
            sql = "INSERT INTO Nguyenlieu (MaNL, TenNL,Maloai, SoLuong, Gia, MaNCC,MaChiNhanh,MaTT, Anh) " +
 "VALUES (N'" + txt_manl.Text.Trim() + "', N'" + txt_ten.Text.Trim() + "', N'" +combo_maloai.SelectedValue.ToString() + "', N'"+ txt_sl.Text.Trim() + "', N'" + txt_gia.Text.Trim() + "', N'" + combo_mancc.SelectedValue.ToString()+ "', N'" + combo_chinhanh.SelectedValue.ToString()+ "', N'" + combo_matt.SelectedValue.ToString()+"', N'" + txt_anh.Text.Trim() + "')";


            Functions.Runsql(sql);
            Load_DataGridView ();
            ResetValues();
            btn_xoa.Enabled = true;
            btn_them.Enabled = true;
            btn_sua.Enabled = true;
            btn_boqua.Enabled = false;
            btn_luu.Enabled = false;
            txt_manl.Enabled = false;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (txt_manl.Text == "")
            {
                MessageBox.Show("bạn chưa chọn bản ghi nào", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                return;
            }
            string sql;
            //sql = "UPDATE Nguyenlieu SET TenNL=N'" + txt_ten.Text.Trim().ToString() +
            //            "',Maloai=N'" + combo_maloai.SelectedValue.ToString() +
            //            "',SoLuong='" + txt_sl.Text +
            //             "',Gia='" + txt_gia.Text +
            //             "',MaNCC='" + combo_mancc.SelectedValue.ToString() +
            //             "',MaChiNhanh='" + combo_chinhanh.SelectedValue.ToString() +
            //             "',MaTT='" + combo_matt.SelectedValue.ToString() +
            //             "',Anh='" + txt_anh.Text +
            //            "' WHERE MaNL=N'" + txt_manl.Text + "'";

            sql = "UPDATE Nguyenlieu SET TenNL=N'" + txt_ten.Text.Trim().ToString() + "',Maloai=N'" 
                + combo_maloai.SelectedValue.ToString() 
                + "',SoLuong=" + txt_sl.Text.Trim() + ", Gia='" + txt_gia.Text.Trim()
                + "',MaNCC='" + combo_mancc.SelectedValue.ToString() 
                + "',MaChiNhanh='" + combo_chinhanh.SelectedValue.ToString() 
                + "',MaTT='" + combo_matt.SelectedValue.ToString() 
                + "',Anh='" + txt_anh.Text + "'WHERE MaNL=N'" + txt_manl.Text + "'";
            Functions.Runsql(sql);
            Load_DataGridView();
            ResetValues();
           
            btn_boqua.Enabled = true;
        }

        private void btn_tk_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txt_manl.Text == "") && (txt_ten.Text == "") && (combo_maloai.Text =="")&& (combo_chinhanh.Text == "")&& (combo_mancc.Text == "")&& (combo_matt.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM Nguyenlieu WHERE 1=1";
            if (txt_manl.Text != "")
                sql = sql + " AND MaNL Like N'%" + txt_manl.Text + "%'";
            if (txt_ten.Text != "")
                sql = sql + " AND TenNL Like N'%" + txt_ten.Text + "%'";
            if (combo_maloai.Text != "")
                sql = sql + " AND Maloai Like N'%" + combo_maloai.SelectedValue + "%'";
            if (combo_chinhanh.Text != "")
                sql = sql + " AND MaChiNhanh Like N'%" + combo_chinhanh.SelectedValue + "%'";
            if (combo_mancc.Text != "")
                sql = sql + " AND MaNCC Like N'%" + combo_mancc.SelectedValue + "%'";
            if (combo_matt.Text != "")
                sql = sql + " AND MaTT Like N'%" + combo_matt.SelectedValue + "%'";
            dt = Functions.GetdataToTable(sql);
            if (dt.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + dt.Rows.Count + " bản ghi thỏa mãn điều kiện!!!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            datagridview_nguyenlieu.DataSource = dt;
            ResetValues();

        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaNL, TenNL, Maloai, Soluong, Gia,MaNCC,MaChiNhanh,MaTT, Anh,Ghichu FROM Nguyenlieu";
            dt = Functions.GetdataToTable(sql);
            datagridview_nguyenlieu.DataSource = dt;

        }

        private void btn_An_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                if (MessageBox.Show("Bạn muốn ẩn tất cả các mặt hàng trong danh sách không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Hide all items from the list
                    dt.Rows.Clear();
                }
            }
            else
            {
                // Inform the user that there are no items to hide
                MessageBox.Show("Danh sách hiện đang trống.");
            }
        }

        private void txt_manl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txt_ten_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void combo_maloai_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txt_sl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txt_gia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void combo_mancc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void combo_matt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }
    }
}

