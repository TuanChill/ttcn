using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ttcn
{
    public partial class frmdanhsach : Form
    {
        private Form activeForm;
        public frmdanhsach()
        {
            InitializeComponent();
        }

        private void frmdanhsach_Load(object sender, EventArgs e)
        {
            OpenChildForm(new frmphieunhapkho(), sender);
            button1.Focus();
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in paneldanhsach.Controls)
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
            this.panelshow.Controls.Add(childForm);
            this.panelshow.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmphieunhapkho(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmphieuxuatkho(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmphieuthuhoi(), sender);
        }
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
            

            //btnCloseChildForm.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormLoaiPhieu(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmdondathang(), sender);
        }
    }
}
