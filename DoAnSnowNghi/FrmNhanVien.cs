using DoAnSnowNghi.BAL;
using DoAnSnowNghi.DAL;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnSnowNghi
{
    public partial class FrmNhanVien : Form
    {
        int rowindex = -1;
        KetNoi db = new KetNoi();
        NhanVienDAL nhanVienDAO = new NhanVienDAL();
        private string AddOrEdit = null;

        public void ResetText1()
        {
            txtMaNV.Clear();
            txtTennhanvien.Clear();
            txtDiachi.Clear();
            makNgaySinh.Clear();
            mtbDienThoai.ResetText();
            chbNam.Checked = false;
            chbNu.Checked = false;

        }

        private void loadNhanVien()
        {
            dgvDanhsach.DataSource = db.NhanViens.Select(p => new { p.Manhanvien, p.Tennhanvien, p.Diachi, p.Gioitinh, p.Dienthoai, p.Ngaysinh }).ToList();
        }
        public FrmNhanVien()
        {
            InitializeComponent();
        }


        private void FrmNhanVien_Load(object sender, EventArgs e)
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
            loadNhanVien();

        }
        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvDanhsach.Columns["Column3"].Index && e.Value != null)
            {
                if (e.Value is bool gioiTinhValue)
                {
                    e.Value = gioiTinhValue ? "Nam" : "Nữ";
                    e.FormattingApplied = true;
                }
            }
        }
        private int hdCounter = 1;
        private string GenerateNewMaHDBan()
        {
            string newMaHDBan;
            do
            {
                hdCounter++;
                newMaHDBan = "P" + hdCounter.ToString("00");
            }
            while (CheckMaHDBanExists(newMaHDBan)); // Kiểm tra mã mới có tồn tại trong DataGridView không

            return newMaHDBan;
        }

        private bool CheckMaHDBanExists(string maHDBan)
        {
            foreach (DataGridViewRow row in dgvDanhsach.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == maHDBan)
                {
                    return true; // Mã đã tồn tại trong DataGridView
                }
            }
            return false; // Mã chưa tồn tại trong DataGridView
        }



        private void ShowAndHidden(bool show)
        {
            txtMaNV.Enabled = true;
            txtTennhanvien.Enabled = true;
        }


        private int nvCounter = 1;

        private int GenerateNewMaNV()
        {
            int newMaNV;
            do
            {
                nvCounter++;
                newMaNV = nvCounter;
            }
            while (CheckMaNVExists(newMaNV)); // Kiểm tra mã mới có tồn tại trong DataGridView không

            return newMaNV;
        }

        private bool CheckMaNVExists(int maNV)
        {
            foreach (DataGridViewRow row in dgvDanhsach.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == maNV)
                {
                    return true; // Mã đã tồn tại trong DataGridView
                }
            }
            return false; // Mã chưa tồn tại trong DataGridView
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            ShowAndHidden(true);
            AddOrEdit = "Add";
            btnLuu.Enabled = true;

            // Tự động nhập mã nhân viên mới khi thêm mới
            txtMaNV.Text = GenerateNewMaNV().ToString();
        }

        public bool checkMaNV(string manv)
        {
            if (dgvDanhsach.Rows.Count == 0)
            {
                return true;
            }
            for (int row = 0; row < dgvDanhsach.Rows.Count - 1; row++)
            {
                if (dgvDanhsach.Rows[row].Cells["Manhanvien"].Value.ToString() == manv)
                {
                    return false;
                }
            }
            return true;
        }
    

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            int maNV = int.Parse(txtMaNV.Text.Trim());
            NhanVien nv = nhanVienDAO.getRow(maNV);
            nhanVienDAO.Delete(nv);
            loadNhanVien();
            ResetText1();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
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
        //Lưu
        private void btnMoi_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    MessageBox.Show("Vui lòng điền Mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTennhanvien.Text))
                {
                    MessageBox.Show("Vui lòng điền Tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDiachi.Text))
                {
                    MessageBox.Show("Vui lòng điền Địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!chbNam.Checked && !chbNu.Checked)
                {
                    MessageBox.Show("Vui lòng chọn Giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(mtbDienThoai.Text))
                {
                    MessageBox.Show("Vui lòng điền Số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Remove any non-digit characters
                string phoneNumber = new string(mtbDienThoai.Text.Where(char.IsDigit).ToArray());

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



                if (string.IsNullOrWhiteSpace(makNgaySinh.Text))
                {
                    MessageBox.Show("Vui lòng điền Ngày sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (AddOrEdit == "Add")
                {
                    //Luu vào CSDL
                    NhanVienDAL nhanVienDAO = new NhanVienDAL();
                    NhanVien nv = new NhanVien();
                    nv.Manhanvien = int.Parse(txtMaNV.Text.Trim());
                    nv.Tennhanvien = txtTennhanvien.Text.Trim();
                    nv.Diachi = txtDiachi.Text.Trim();
                    nv.Gioitinh = chbNam.Checked ? "Nam" : "Nữ";
                    nv.Dienthoai = mtbDienThoai.Text.Trim();

                    nv.Ngaysinh = DateTime.Parse(makNgaySinh.Text);

                    nhanVienDAO.Insert(nv);
                    db.SaveChanges();
                    loadNhanVien();
                }
                if (AddOrEdit == "Edit")
                {
                    //Update
                    int maSP = int.Parse(txtMaNV.Text.Trim());
                    NhanVien nv = nhanVienDAO.getRow(maSP);
                    nv.Manhanvien = int.Parse(txtMaNV.Text.Trim());

                    nv.Tennhanvien = txtTennhanvien.Text.Trim();
                    nv.Diachi = txtDiachi.Text.Trim();
                    nv.Gioitinh = chbNam.Checked ? "Nam" : "Nữ";
                    nv.Dienthoai = mtbDienThoai.Text.Trim();
                    nv.Ngaysinh = DateTime.Parse(makNgaySinh.Text);

                    nhanVienDAO.Update(nv);
                    dgvDanhsach.DataSource = nhanVienDAO.getList();
                }
                txtMaNV.Text = "";
                txtTennhanvien.Text = "";
                txtDiachi.Text = "";
                makNgaySinh.Text = "";
                mtbDienThoai.Text = "";
                chbNam.Checked = false;
                chbNu.Checked = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            btnLuu.Enabled = true;
            AddOrEdit = "Edit";
        }

        private void dgvDanhsach_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            rowindex = e.RowIndex;
            rowindex = e.RowIndex;
            txtMaNV.Text = dgvDanhsach.Rows[rowindex].Cells["Manhanvien"].Value.ToString();
            txtTennhanvien.Text = dgvDanhsach.Rows[rowindex].Cells["Tennhanvien"].Value.ToString();
            txtDiachi.Text = dgvDanhsach.Rows[rowindex].Cells["Diachi"].Value.ToString();
            string gioiTinh = dgvDanhsach.Rows[rowindex].Cells["Gioitinh"].Value.ToString();
            if (gioiTinh == "Nam")
            {
                chbNam.Checked = true;
                chbNu.Checked = false;
            }
            else if (gioiTinh == "Nữ")
            {
                chbNam.Checked = false;
                chbNu.Checked = true;
            }
            mtbDienThoai.Text = dgvDanhsach.Rows[rowindex].Cells["Dienthoai"].Value.ToString();
            makNgaySinh.Text = dgvDanhsach.Rows[rowindex].Cells["Ngaysinh"].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }




