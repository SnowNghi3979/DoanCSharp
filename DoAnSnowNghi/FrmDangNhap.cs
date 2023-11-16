using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using DoAnSnowNghi.BAL;
using DoAnSnowNghi.DAL;

namespace DoAnSnowNghi
{

    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pbAnh.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public static string LoaiTaiKhoan { get; private set; }

        private void FrmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("Bạn muốn tho không?", "Thông báo",
            // MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}

            if (FrmMain.thanhvien == null)
            {
                // If the user hasn't logged in, ask for confirmation
                DialogResult result = MessageBox.Show("Bạn muốn thoát không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    // If the user clicks "No", cancel the form closing event
                    e.Cancel = true;
                }
                else
                {
                    // If the user clicks "Yes", exit the application
                    Application.Exit();
                }
            }
            else
            {
                // If the user has logged in, do nothing or provide appropriate logic
            }
        }



        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string tendn = txtDangNhap.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();
            NguoiDungDAL tvDAO = new NguoiDungDAL();
            NguoiDung1 thanhvien = tvDAO.getRow(tendn, matkhau);

            if (thanhvien == null)
            {
                lblThongbao.Text = "Tài khoản không tồn tại";
            }
            else
            {
                FrmMain.thanhvien = thanhvien;
                LoaiTaiKhoan = tendn; // Lưu loại tài khoản vào biến tĩnh
                // Close the login form
                this.Close();
            }
        }


        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

            //DialogResult result = MessageBox.Show(
            //               "Bạn có muốn thoát không?",
            //               "Thông báo!",
            //               MessageBoxButtons.YesNo,
            //               MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
        }
    }
}
