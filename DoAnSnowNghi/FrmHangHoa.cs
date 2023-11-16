using DoAnSnowNghi.BAL;
using DoAnSnowNghi.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnSnowNghi
{
    public partial class FrmHangHoa : Form
    {


        public FrmHangHoa()
        {
            InitializeComponent();
        }
        int rowindex = -1;
        KetNoi db = new KetNoi();
        HangDAL hangDAO = new HangDAL();
        private string AddOrEdit = null;


        public void ResetText1()
        {
            txtMaHang.Clear();
            txtTenHang.Clear();
            cbMaChatLieu.Items.Clear();
            txtSoLuong.Clear();
            txtDonGiaNhap.Clear();
            txtDonGiaBan.Clear();
            //txtAnh.Clear();
            textGhiChu.Clear();


        }

        private void ShowAndHidden(bool show)
        {
            txtMaHang.Enabled = true;
            txtTenHang.Enabled = true;
            cbMaChatLieu.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
            //txtAnh.Enabled = true;
            textGhiChu.Enabled = true;
        }

        private void loadHang()
        {
            dgvDanhsach.DataSource = db.Hang1.Select(p => new { p.Mahang, p.Tenhang, p.Machatlieu, p.Soluong, p.Dongianhap, p.Dongiaban, p.Anh, p.Ghichu }).ToList();
        }

        private void FrmHangHoa_Load(object sender, EventArgs e)
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
            loadHang();
            cbMaChatLieu.DataSource = db.Chatlieu1.Select(cl => cl.Machatlieu).ToList();
        }

        private void dgvDanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHang.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            rowindex = e.RowIndex;
            rowindex = e.RowIndex;
            txtMaHang.Text = dgvDanhsach.Rows[rowindex].Cells["Mahang"].Value.ToString();
            txtTenHang.Text = dgvDanhsach.Rows[rowindex].Cells["Tenhang"].Value.ToString();

            cbMaChatLieu.Text = dgvDanhsach.Rows[rowindex].Cells["Machatlieu"].Value.ToString();
            txtSoLuong.Text = dgvDanhsach.Rows[rowindex].Cells["Soluong"].Value.ToString();

            txtDonGiaNhap.Text = dgvDanhsach.Rows[rowindex].Cells["Dongianhap"].Value.ToString();
            txtDonGiaBan.Text = dgvDanhsach.Rows[rowindex].Cells["Dongiaban"].Value.ToString();
            if (dgvDanhsach.Rows[rowindex].Cells["Anh"].Value != null)
            {
                byte[] imageData = (byte[])dgvDanhsach.Rows[rowindex].Cells["Anh"].Value;
                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pbAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbAnh.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbAnh.Image = null; // Nếu không có hình ảnh, PictureBox sẽ hiển thị rỗng.
                }
            }
            else
            {
                pbAnh.Image = null; // Nếu không có hình ảnh, PictureBox sẽ hiển thị rỗng.
            }
            textGhiChu.Text = dgvDanhsach.Rows[rowindex].Cells["Ghichu"].Value.ToString();
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            int MaH = int.Parse(txtMaHang.Text.Trim());
            Hang1 hh = hangDAO.getRow(MaH);
            hangDAO.Delete(hh);
            loadHang();
            ResetText1();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaHang.Enabled = false;
            btnLuu.Enabled = true;
            AddOrEdit = "Edit";
        }

        private int mahangCounter = 1;

        private string GenerateNewMaHang()
        {
            int newMaHang;
            do
            {
                mahangCounter++;
                newMaHang = mahangCounter;
            }
            while (CheckMaHangExists(newMaHang)); // Kiểm tra mã mới có tồn tại trong DataGridView không

            return newMaHang.ToString();
        }

        private bool CheckMaHangExists(int maHang)
        {
            foreach (DataGridViewRow row in dgvDanhsach.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == maHang)
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

            // Tự động nhập mã hàng hóa mới khi thêm mới
            txtMaHang.Text = GenerateNewMaHang();
        }

        // Các phương thức và sự kiện khác ở đây...

        private byte[] selectedImageBytes;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(open.FileName);
                    txtAnh.Text = open.FileName; // Save the image path to the TextBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }*/
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaHang.Text))
                {
                    MessageBox.Show("Vui lòng điền Mã hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTenHang.Text))
                {
                    MessageBox.Show("Vui lòng điền Tên hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cbMaChatLieu.Text))
                {
                    MessageBox.Show("Vui lòng điền mã chất liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (string.IsNullOrWhiteSpace(txtDonGiaNhap.Text))
                {
                    MessageBox.Show("Vui lòng điền đơn giá nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtDonGiaBan.Text))
                {
                    MessageBox.Show("Vui lòng điền đơn giá bán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //if (string.IsNullOrWhiteSpace(txtAnh.Text))
                //{
                //    MessageBox.Show("Vui lòng điền Số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                if (string.IsNullOrWhiteSpace(textGhiChu.Text))
                {
                    MessageBox.Show("Vui lòng điền ghi chú.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (AddOrEdit == "Add")
                {
                    //Luu vào CSDL
                    HangDAL hangDAO = new HangDAL();
                    Hang1 hh = new Hang1();
                    hh.Mahang = int.Parse(txtMaHang.Text.Trim());
                    hh.Tenhang = txtTenHang.Text.Trim();
                    hh.Machatlieu = cbMaChatLieu.Text.Trim();
                    hh.Dongianhap = Convert.ToInt32(txtDonGiaNhap.Text.Trim());
                    hh.Dongiaban = Convert.ToInt32(txtDonGiaBan.Text.Trim());
                    hh.Soluong = Convert.ToInt32(txtSoLuong.Text.Trim());
                    hh.Anh = selectedImageBytes;
                    hh.Ghichu = textGhiChu.Text.Trim();

                    hangDAO.Insert(hh);
                    db.SaveChanges();
                    loadHang();
                }
                if (AddOrEdit == "Edit")
                {
                    // Update
                    int maSP = int.Parse(txtMaHang.Text.Trim());
                    Hang1 hh = hangDAO.getRow(maSP);
                    hh.Mahang = int.Parse(txtMaHang.Text.Trim());

                    hh.Tenhang = txtTenHang.Text.Trim();
                    hh.Machatlieu = cbMaChatLieu.Text.Trim();
                    hh.Dongianhap = Convert.ToInt32(txtDonGiaNhap.Text.Trim());
                    hh.Dongiaban = Convert.ToInt32(txtDonGiaBan.Text.Trim());
                    hh.Soluong = Convert.ToInt32(txtSoLuong.Text.Trim());
                    byte[] currentImage = hh.Anh;
                    if (selectedImageBytes != null)
                    {
                        hh.Anh = selectedImageBytes; // Cập nhật thông tin ảnh mới
                    }
                    else
                    {
                        hh.Anh = currentImage; // Giữ nguyên thông tin ảnh cũ
                    }
                    hh.Ghichu = textGhiChu.Text.Trim();


                    hangDAO.Update(hh);
                    dgvDanhsach.DataSource = hangDAO.getList();
                }
                txtMaHang.Clear();
                txtTenHang.Clear();
                cbMaChatLieu.Items.Clear();
                txtSoLuong.Clear();
                txtDonGiaNhap.Clear();
                txtDonGiaBan.Clear();
                //txtAnh.Clear();
                textGhiChu.Clear();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                    string imagePath = openFileDialog.FileName;
                    pbAnh.Image = Image.FromFile(imagePath);
                    selectedImageBytes = File.ReadAllBytes(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbMaChatLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMaChatLieu.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {

            // Tìm kiếm hàng hóa theo mã chất liệu được chọn
            string maChatLieu = cbMaChatLieu.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(maChatLieu))
            {
                dgvDanhsach.DataSource = db.Hang1
                    .Where(h => h.Machatlieu == maChatLieu)
                    .Select(p => new { p.Mahang, p.Tenhang, p.Machatlieu, p.Soluong, p.Dongianhap, p.Dongiaban, p.Anh, p.Ghichu })
                    .ToList();
            }
            else
            {
                // Nếu không chọn mã chất liệu, hiển thị toàn bộ danh sách
                loadHang();
            }

        }
    }
}

