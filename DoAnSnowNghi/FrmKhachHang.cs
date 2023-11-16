using DoAnSnowNghi.BAL;
using DoAnSnowNghi.DAL;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DoAnSnowNghi
{
    public partial class FrmKhachHang : Form
    {
        int rowindex = -1;
        KetNoi db = new KetNoi();
        KhachDAL khachDAO= new KhachDAL();
        private string AddOrEdit = null;
   

        public void ResetText1()
        {
            txtMaKH.Clear();
            txtTenkhach.Clear();
            txtDiachi.Clear();
            txtDienThoai.Clear();
            

        }

        private void loadKhach()
        {
            dgvDanhsach.DataSource = db.Khach2.Select(p => new { p.Makhach, p.Tenkhach, p.Diachi,  p.Dienthoai }).ToList();
        }

        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void ShowAndHidden(bool show)
        {
            txtMaKH.Enabled = true;
            txtTenkhach.Enabled = true;
            txtDiachi.Enabled = true;
            txtDienThoai.Enabled = true;
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            // Kiểm tra loại tài khoản và thực hiện các thay đổi tương ứng
            if (FrmDangNhap.LoaiTaiKhoan.ToLower() == "admin")
            {
                // Hiển thị toàn bộ chức năng
            }
            else if (FrmDangNhap.LoaiTaiKhoan.ToLower() == "sa")
            {
                // Ẩn chức năng thêm, sửa, xóa
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            ShowAndHidden(false);
            loadKhach();
        }

        private void dgvDanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            rowindex = e.RowIndex;
            rowindex = e.RowIndex;
            txtMaKH.Text = dgvDanhsach.Rows[rowindex].Cells["Makhach"].Value.ToString();
            txtTenkhach.Text = dgvDanhsach.Rows[rowindex].Cells["Tenkhach"].Value.ToString();
            txtDiachi.Text = dgvDanhsach.Rows[rowindex].Cells["Diachi"].Value.ToString();
            txtDienThoai.Text = dgvDanhsach.Rows[rowindex].Cells["Dienthoai"].Value.ToString();


        }

        private int khCounter = 1;

        private int GenerateNewMaKH()
        {
            int newMaKH;
            do
            {
                khCounter++;
                newMaKH = khCounter;
            }
            while (CheckMaKHExists(newMaKH)); // Kiểm tra mã mới có tồn tại trong DataGridView không

            return newMaKH;
        }

        private bool CheckMaKHExists(int maKH)
        {
            foreach (DataGridViewRow row in dgvDanhsach.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == maKH)
                {
                    return true; // Mã đã tồn tại trong DataGridView
                }
            }
            return false; // Mã chưa tồn tại trong DataGridView
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ShowAndHidden(true);
            AddOrEdit = "Add";
            btnLuu.Enabled = true;

            // Tự động nhập mã khách hàng mới khi thêm mới
            txtMaKH.Text = GenerateNewMaKH().ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            int MaK = int.Parse(txtMaKH.Text.Trim());
            Khach2 kh = khachDAO.getRow(MaK);
            khachDAO.Delete(kh);
            loadKhach();
            ResetText1();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
            btnLuu.Enabled = true;
            AddOrEdit = "Edit";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có muốn thoát không?",
               "Thông báo!",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    MessageBox.Show("Vui lòng điền Mã khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTenkhach.Text))
                {
                    MessageBox.Show("Vui lòng điền Tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDiachi.Text))
                {
                    MessageBox.Show("Vui lòng điền Địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (string.IsNullOrWhiteSpace(txtDienThoai.Text))
                {
                    MessageBox.Show("Vui lòng điền Số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Remove any non-digit characters
                string phoneNumber = new string(txtDienThoai.Text.Where(char.IsDigit).ToArray());

                // Check if the cleaned string has exactly 10 digits
                if (phoneNumber.Length != 10)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the cleaned string is a valid integer
                if (!int.TryParse(phoneNumber, out _))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Continue with your code if the phone number is valid
                // ...




                if (AddOrEdit == "Add")
                {
                    //Luu vào CSDL
                    KhachDAL khachDAO = new KhachDAL();
                    Khach2 kh = new Khach2();
                    kh.Makhach = int.Parse(txtMaKH.Text.Trim());
                    kh.Tenkhach = txtTenkhach.Text.Trim();
                    kh.Diachi = txtDiachi.Text.Trim();
                    kh.Dienthoai = txtDienThoai.Text.Trim();


                    khachDAO.Insert(kh);
                    db.SaveChanges();
                    loadKhach();
                }
                if (AddOrEdit == "Edit")
                {
                    //Update
                    int maSP = int.Parse(txtMaKH.Text.Trim());
                    Khach2 kh = khachDAO.getRow(maSP);
                    kh.Makhach = int.Parse(txtMaKH.Text.Trim());

                    kh.Tenkhach = txtTenkhach.Text.Trim();
                    kh.Diachi = txtDiachi.Text.Trim();
                    kh.Dienthoai = txtDienThoai.Text.Trim();


                    khachDAO.Update(kh);
                    dgvDanhsach.DataSource = khachDAO.getList();
                }
                txtMaKH.Text = "";
                txtTenkhach.Text = "";
                txtDiachi.Text = "";
                txtDienThoai.Text = "";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblMsv_Click(object sender, EventArgs e)
        {

        }
    }
}
