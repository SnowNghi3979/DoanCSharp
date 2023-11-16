using DoAnSnowNghi.BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnSnowNghi
{
    public partial class FrmMain : Form

    {
        public static string tentaikhoan = null;
        
        private Form currentFromChild;
        private void openChildForm(Form childForm)
        {
            if (currentFromChild != null)
            {
                currentFromChild.Close();
            }
            currentFromChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnMain.Controls.Add(childForm);
            pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public FrmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;


        }
        public static NguoiDung1 thanhvien = null;
        

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmNhanVien());
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmHangHoa());
        }

        private void btnChatLieu_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmChatlieu());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmKhachHang());
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
          //  openChildForm(new FrmTimKiemHD());
        }

        private void btnChatLieu_Click_1(object sender, EventArgs e)
        {
            openChildForm(new FrmChatlieu());
        }

        private void btnCL_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmChatlieu());
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (thanhvien == null)
            {
                Form frmdn = new FrmDangNhap();
                frmdn.ShowDialog();
            }
            if (thanhvien != null)
            {
                toolStripStatusLabelThanhVien1.Text = thanhvien.TenDN;
                //tabControlMain.ImageList = loadImageList();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmTimKiemHHoa());
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát không?", "Thông báo",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            openChildForm(new HoaDonBanHang());
        }
    }
}
