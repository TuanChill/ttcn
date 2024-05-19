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

namespace ttcn
{
    public partial class frmtrangchu : Form
    {
        private Form activeForm;
        public frmtrangchu()
        {
            InitializeComponent();
        }

        private void main1_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
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
            lblTitle.Text = childForm.Text;
        }
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);

            //btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void main1_MaximumSizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void main1_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btntaophieu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmdanhsach(), sender);
        }

        private void btnsanpham_Click(object sender, EventArgs e)
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
            OpenChildForm(new Hang(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNCC(), sender);
        }

        private void main1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmtrangchu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmlogin a = new frmlogin();
            a.Show();
        }

        private void frmtrangchu_Load(object sender, EventArgs e)
        {

        }

        private void btntaophieu_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmdanhsach(), sender);
        }

        private void btnsanpham_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new formNL(), sender);
        }

        private void frmtrangchu_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmthongtincanhan(), sender);
        }
    }
}
