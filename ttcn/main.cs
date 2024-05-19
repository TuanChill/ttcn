using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ttcn
{
    public partial class main : Form
    {
        
        
        
        private Form activeForm;
        public main()
        {
            InitializeComponent();
            
        }
        // Phương thức để chọn màu chủ đề
        // Import các namespace cần thiết
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Phương thức để chọn màu chủ đề
       

        // Phương thức để kích hoạt nút được chọn
        

        // Phương thức để vô hiệu hóa các nút
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        // Phương thức để mở form con
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
           // lblTitle.Text = childForm.Text;
        }

        // Các sự kiện khi nhấn các nút menu

        
        // Sự kiện khi nhấn nút đóng form con
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        // Phương thức để reset giao diện
        // private void Reset()
        //{
        //  DisableButton();
        // lblTitle.Text = "HOME";
        //panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
        //panelLogo.BackColor = Color.FromArgb(39, 39, 58);
        //currentButton = null;
        //btnCloseChildForm.Visible = false;
        //}
        // Phương thức để reset giao diện
        // Phương thức để reset giao diện
        private void Reset()
        {
            DisableButton();
            //panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            
            //btnCloseChildForm.Visible = false;
        }

        // Sự kiện khi kéo thanh tiêu đề để di chuyển form
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Sự kiện khi nhấn nút đóng chương trình
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Sự kiện khi nhấn nút phóng to/mở rộng form
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        // Sự kiện khi nhấn nút thu nhỏ form
        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnProducts_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmdanhsach(), sender);
        }

        private void btnOrders_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new formNL(), sender);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmchinhanh(), sender);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmtimkiem(), sender);
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            OpenChildForm(new khachHang(), sender);
        }
       
        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void panelDesktopPane_Paint(object sender, PaintEventArgs e)
        {

        }
        private frmlogin loginForm; // Biến để lưu trữ instance của frmlogin

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenChildForm (new frmthongtincanhan(), sender);
            
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra nếu form đang tắt là form cuối cùng
            if (Application.OpenForms.Count == 1)
            {
                frmlogin login = new frmlogin();
                login.Show();
                // Tắt ứng dụng hoàn toàn
                
              
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNCC(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhanVien(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmloainl(), sender);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new ChucVu(), sender);

        }

        private void panelTitleBar_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void main_MaximumSizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void main_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap a = new DangNhap();
            a.Show();
        }
    }
}
