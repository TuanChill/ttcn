using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ttcn.Class;

namespace ttcn
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            Functions.Ketnoi();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            string username = userName.Text;
            string password = Password.Text;
            Globals.Us = username;
            Globals.Pass = password;

            // Tạo instance của `frmthongtincanhan` và truyền instance của `frmlogin`

            SqlConnection Conn = Functions.Conn;
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }

            try
            {
                // Truy vấn lấy dữ liệu từ bảng tài khoản
                string query = "SELECT Username, Password FROM TaiKhoan WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, Conn);
                command.Parameters.AddWithValue("@Username", username);


                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string us = reader["Username"].ToString();
                    string dbPassword = reader["Password"].ToString();


                    if (password == dbPassword)
                    {
                            MessageBox.Show("Đăng nhập thành công!");

                            // Đóng form đăng nhập (frmlogin)
                            this.Hide();
                            // Đăng ký sự kiện FormClosed để xử lý việc đóng form
                            //this.FormClosed += exitApp_Click;
                            // Hiển thị form chính (frmmain)
                            main mainForm = new main();
                            mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không chính xác!");
                        // Xử lý khi mật khẩu không chính xác

                        reader.Close();
                        Conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập không tồn tại!");
                    // Xử lý khi tên đăng nhập không tồn tại

                    reader.Close();
                    Conn.Close();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        //private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    //if(MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    //{
        //    //    Application.Exit();
        //    //    return;
        //    //}
        //}

        public void dulieu()
        {
            string us = userName.Text;
            string ps = Password.Text;
        }

        private void togglePassword_Click(object sender, EventArgs e)
        {
            if (togglePassword.Checked)
            {
                // Nếu checkbox được chọn, hiển thị ký tự thường trong txtpassword
                Password.PasswordChar = (char)0; // Ký tự null để hiển thị ký tự thường
            }
            else
            {
                // Nếu checkbox không được chọn, biến txtpassword thành dấu '*'
                Password.PasswordChar = '*';
            }
        }

        private void exitApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
                return;
            }
        }
    }
}
