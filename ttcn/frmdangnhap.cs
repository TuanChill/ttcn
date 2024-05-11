using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ttcn.Class;

namespace ttcn
{
    public static class Globals
    {
        public static string Us { get; set; }
        public static string Pass { get; set; }
    }
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }
        

        private void frmlogin_Load(object sender, EventArgs e)
        {
            Class.Functions.Ketnoi();
               
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            Globals.Us = username;
            Globals.Pass = password;
            
            // Tạo instance của `frmthongtincanhan` và truyền instance của `frmlogin`
            
            


            // Tạo instance của `frmthongtincanhan` và truyền instance của `frmlogin`

            SqlConnection Conn = Functions.Conn;
            if (Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Conn.Open();
            }

            try
            {
                // Truy vấn lấy dữ liệu từ bảng tài khoản
                string query = "SELECT Username, Password, quyenhan FROM TaiKhoan WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, Conn);
                command.Parameters.AddWithValue("@Username", username);
                

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string us = reader["Username"].ToString();
                    string qh = reader["quyenhan"].ToString();
                    string dbPassword = reader["Password"].ToString();
                    

                    if (password == dbPassword)
                    {
                        if (qh == "Quản trị")
                        {
                            MessageBox.Show("Đăng nhập thành công!");

                            // Đóng form đăng nhập (frmlogin)
                            this.Hide();
                            // Đăng ký sự kiện FormClosed để xử lý việc đóng form
                            this.FormClosed += Frmlogin_FormClosed;
                            // Hiển thị form chính (frmmain)
                            main mainForm = new main();
                            mainForm.Show();
                        }    
                        else
                        {
                            MessageBox.Show("Đăng nhập thành công!");

                            // Đóng form đăng nhập (frmlogin)
                            this.Hide();
                            // Đăng ký sự kiện FormClosed để xử lý việc đóng form
                            this.FormClosed += Frmlogin_FormClosed;
                            // Hiển thị form chính (frmmain)
                            frmtrangchu main1Form = new frmtrangchu();
                            main1Form.Show();
                        }    
                        
                       

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
        public void dulieu()
        {
            string us = txtusername.Text;
            string ps = txtpassword.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Nếu checkbox được chọn, hiển thị ký tự thường trong txtpassword
                txtpassword.PasswordChar = '\0'; // Ký tự null để hiển thị ký tự thường
            }
            else
            {
                // Nếu checkbox không được chọn, biến txtpassword thành dấu '*'
                txtpassword.PasswordChar = '*';
            }
        }

        private void btnout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Frmlogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Đóng ứng dụng khi form đăng nhập (frmlogin) đã được đóng
            Application.Exit();
        }

        private void frmlogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
