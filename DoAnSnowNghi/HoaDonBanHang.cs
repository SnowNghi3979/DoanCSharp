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

namespace DoAnSnowNghi
{
    public partial class HoaDonBanHang : Form
    {
        SqlConnection connection;
        SqlCommand commmand;
        string str = @"Data Source=LAPTOP-N4PPCP4O\SQLEXPRESS;Initial Catalog=QLBanHang;User ID=sa;Password=1234";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            commmand = connection.CreateCommand();
            commmand.CommandText = "SELECT * FROM HoaDonBan1";
            adapter.SelectCommand = commmand;
            table.Clear();
            adapter.Fill(table);
            dgvDanhsach.DataSource = table;
        }
        public HoaDonBanHang()
        {
            InitializeComponent();
        }

        private void HoaDonBanHang_Load(object sender, EventArgs e)
        {
            // Kiểm tra loại tài khoản và thực hiện các thay đổi tương ứng
            if (FrmDangNhap.LoaiTaiKhoan.ToLower() == "admin")
            {
                // Hiển thị toàn bộ chức năng
            }
            else if (FrmDangNhap.LoaiTaiKhoan.ToLower() == "sac")
            {
                // Ẩn chức năng thêm, sửa, xóa
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
            

                // Load MaHDBan values into cbMaHD
                List<string> maHDBanList = GetMaHDBanList();
                cbMaHD.DataSource = maHDBanList;
            


            txtTennhanvien.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienThoai.ReadOnly = true;
            txtTenhang.ReadOnly = true;
            txtDongia.ReadOnly = true;

        }

        private void dgvDanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvDanhsach.CurrentRow.Index;
            txtMaHD.Text = dgvDanhsach.Rows[i].Cells[0].Value.ToString();
            dtNgayBan.Text = dgvDanhsach.Rows[i].Cells[1].Value.ToString();
            txtMaNV.Text = dgvDanhsach.Rows[i].Cells[2].Value.ToString();
            txtTennhanvien.Text = dgvDanhsach.Rows[i].Cells[3].Value.ToString();
            txtMaKH.Text = dgvDanhsach.Rows[i].Cells[4].Value.ToString();
            txtTenKH.Text = dgvDanhsach.Rows[i].Cells[5].Value.ToString();
            txtDiachi.Text = dgvDanhsach.Rows[i].Cells[6].Value.ToString();
            txtDienThoai.Text = dgvDanhsach.Rows[i].Cells[7].Value.ToString();
            txtMahang.Text = dgvDanhsach.Rows[i].Cells[8].Value.ToString();
            txtTenhang.Text = dgvDanhsach.Rows[i].Cells[9].Value.ToString();
            txtDongia.Text = dgvDanhsach.Rows[i].Cells[10].Value.ToString();
            txtSoluong.Text = dgvDanhsach.Rows[i].Cells[11].Value.ToString();
            cbGiamgia.Text = dgvDanhsach.Rows[i].Cells[12].Value.ToString();
            txtTongtien.Text = dgvDanhsach.Rows[i].Cells[13].Value.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text) ||
                string.IsNullOrWhiteSpace(dtNgayBan.Text) ||
                string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtTennhanvien.Text) ||
                string.IsNullOrWhiteSpace(txtMaKH.Text) ||
                string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(txtDiachi.Text) ||
                string.IsNullOrWhiteSpace(txtDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtMahang.Text) ||
                string.IsNullOrWhiteSpace(txtTenhang.Text) ||
                string.IsNullOrWhiteSpace(txtDongia.Text) ||
                string.IsNullOrWhiteSpace(txtSoluong.Text) ||
                string.IsNullOrWhiteSpace(cbGiamgia.Text) ||
                string.IsNullOrWhiteSpace(txtTongtien.Text))

            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Thoát khỏi hàm nếu thông tin không đầy đủ
            }

            // Kiểm tra xem MaCapPhat đã tồn tại hay chưa
            string checkExistQuery = "SELECT COUNT(*) FROM HoaDonBan1 WHERE MaHDBan = '" + txtMaHD.Text + "'";
            commmand.CommandText = checkExistQuery;
            int count = Convert.ToInt32(commmand.ExecuteScalar());
            if (count > 0)
            {
                MessageBox.Show("MaHoaDon đã tồn tại.Vui lòng chọn MaHD khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Thêm mới nếu MaCapPhat chưa tồn tại
            string insertQuery = "INSERT INTO HoaDonBan1(MaHDBan,Ngayban,MaNV,TenNV,MaKH,TenKH,Diachi,SDT,Mahanghoa,Tenhanghoa,Dongia,Soluong,Giamgia,Tongtien) " +
                                 "VALUES ('" + txtMaHD.Text + "'," +
                                         "'" + dtNgayBan.Text + "'," +
                                         "'" + txtMaNV.Text + "'," +
                                         "N'" + txtTennhanvien.Text + "'," +
                                         "'" + txtMaKH.Text + "'," +
                                         "N'" + txtTenKH.Text + "'," +
                                         "N'" + txtDiachi.Text + "'," +
                                         "'" + txtDienThoai.Text + "'," +
                                         "'" + txtMahang.Text + "'," +
                                         "N'" + txtTenhang.Text + "'," +
                                         "'" + txtDongia.Text + "'," +
                                         "'" + txtSoluong.Text + "'," +
                                         "'" + cbGiamgia.Text + "'," +
                                         "'" + txtTongtien.Text + "')";

            commmand.CommandText = insertQuery;
            commmand.ExecuteNonQuery();
            loaddata();
            MessageBox.Show("Thao tác thêm thành công");
            // Reset các control sau khi thêm thành công
            txtMaHD.Text = "";
            dtNgayBan.Text = "1/1/1990";
            txtMaNV.Text = "";
            txtTennhanvien.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            txtDienThoai.Text = "";
            txtMahang.Text = "";
            txtTenhang.Text = "";
            txtDongia.Text = "";
            txtSoluong.Text = "";
            cbGiamgia.Text = "";
            txtTongtien.Text = "";

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                commmand = connection.CreateCommand();
                commmand.CommandText = "update HoaDonBan1 set Ngayban= '" + dtNgayBan.Text +
                                       "',MaNV='" + txtMaNV.Text +
                                       "',TenNV= N'" + txtTennhanvien.Text +
                                       "',MaKH= '" + txtMaKH.Text +
                                       "',TenKH= N'" + txtTenKH.Text +
                                       "',Diachi= N'" + txtDiachi.Text +
                                       "',SDT= '" + txtDienThoai.Text +
                                       "',Mahanghoa= '" + txtMahang.Text +
                                       "',Tenhanghoa= N'" + txtTenhang.Text +
                                       "',Dongia= '" + txtDongia.Text +
                                       "',Soluong= '" + txtSoluong.Text +
                                       "',Giamgia= '" + cbGiamgia.Text +
                                       "',Tongtien= '" + txtTongtien.Text +
                                       "' where MaHDBan= '" + txtMaHD.Text + "'";
                commmand.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Thao tác sửa thành công");
                // Reset các control sau khi thêm thành công
                txtMaHD.Text = "";
                dtNgayBan.Text = "1/1/1990";
                txtMaNV.Text = "";
                txtTennhanvien.Text = "";
                txtMaKH.Text = "";
                txtTenKH.Text = "";
                txtDiachi.Text = "";
                txtDienThoai.Text = "";
                txtMahang.Text = "";
                txtTenhang.Text = "";
                txtDongia.Text = "";
                txtSoluong.Text = "";
                cbGiamgia.Text = "";
                txtTongtien.Text = "";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    commmand = connection.CreateCommand();
                    commmand.CommandText = "delete from HoaDonBan1 where MaHDBan='" + txtMaHD.Text + "'";
                    commmand.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Thao tác xóa thành công");
                    // Reset các control sau khi thêm thành công
                    txtMaHD.Text = "";
                    dtNgayBan.Text = "1/1/1990";
                    txtMaNV.Text = "";
                    txtTennhanvien.Text = "";
                    txtMaKH.Text = "";
                    txtTenKH.Text = "";
                    txtDiachi.Text = "";
                    txtDienThoai.Text = "";
                    txtMahang.Text = "";
                    txtTenhang.Text = "";
                    txtDongia.Text = "";
                    txtSoluong.Text = "";
                    cbGiamgia.Text = "";
                    txtTongtien.Text = "";
                }
            }
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            if (!string.IsNullOrEmpty(maNV))
            {
                string tenNhanVien = GetTenNhanVien(maNV);
                txtTennhanvien.Text = tenNhanVien;
            }
            else
            {
                txtTennhanvien.Text = "";
            }
        }

        private string GetTenNhanVien(string maNV)
        {
            string tenNhanVien = "";

            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                string query = "SELECT Tennhanvien FROM NhanVien WHERE Manhanvien = @MaNV";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        tenNhanVien = result.ToString();
                    }
                }
            }

            return tenNhanVien;
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            // Khi người dùng nhập MaKH
            if (!string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                // Thực hiện truy vấn để lấy thông tin từ bảng Khach2
                string query = "SELECT * FROM Khach2 WHERE Makhach='" + txtMaKH.Text + "'";
                commmand.CommandText = query;

                DataTable khachTable = new DataTable();
                SqlDataAdapter khachAdapter = new SqlDataAdapter(commmand);
                khachAdapter.Fill(khachTable);

                if (khachTable.Rows.Count > 0)
                {
                    // Hiển thị thông tin lấy được từ bảng Khach2
                    txtTenKH.Text = khachTable.Rows[0]["Tenkhach"].ToString();
                    txtDiachi.Text = khachTable.Rows[0]["Diachi"].ToString();
                    txtDienThoai.Text = khachTable.Rows[0]["Dienthoai"].ToString();
                }
                else
                {
                    // Nếu không tìm thấy thông tin
                    MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMahang_TextChanged(object sender, EventArgs e)
        {
            // Khi người dùng nhập MaHang
            if (!string.IsNullOrWhiteSpace(txtMahang.Text))
            {
                // Thực hiện truy vấn để lấy thông tin từ bảng Hang1
                string query = "SELECT * FROM Hang1 WHERE Mahang='" + txtMahang.Text + "'";
                commmand.CommandText = query;

                DataTable hangTable = new DataTable();
                SqlDataAdapter hangAdapter = new SqlDataAdapter(commmand);
                hangAdapter.Fill(hangTable);

                if (hangTable.Rows.Count > 0)
                {
                    // Hiển thị thông tin lấy được từ bảng Hang1
                    txtTenhang.Text = hangTable.Rows[0]["Tenhang"].ToString();
                    txtDongia.Text = hangTable.Rows[0]["Dongiaban"].ToString();
                }
                else
                {
                    // Nếu không tìm thấy thông tin
                    MessageBox.Show("Không tìm thấy thông tin hàng hóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDongia.Text) && !string.IsNullOrEmpty(txtSoluong.Text))
            {
                try
                {
                    int donGia = Convert.ToInt32(txtDongia.Text);
                    int soLuong = Convert.ToInt32(txtSoluong.Text);

                    // Tính tổng tiền theo đơn giá và số lượng
                    int tongTien = donGia * soLuong;

                    // Kiểm tra và trừ giảm giá nếu có
                    if (!string.IsNullOrEmpty(cbGiamgia.Text))
                    {
                        int giamGia = Convert.ToInt32(cbGiamgia.Text);
                        tongTien -= giamGia;
                    }

                    // Hiển thị tổng tiền trong ô txtTongTien
                    txtTongtien.Text = tongTien.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng nhập số lượng, đơn giá và giảm giá hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SearchMaHoaDon(string maHoaDon)
        {
            // Clear existing parameters
            commmand.Parameters.Clear();

            // Build the search query
            string query = "SELECT * FROM HoaDonBan1 WHERE MaHDBan = @MaHDBan";
            commmand.CommandText = query;

            // Add new parameter
            commmand.Parameters.AddWithValue("@MaHDBan", maHoaDon);

            // Execute the query
            DataTable searchResultTable = new DataTable();
            SqlDataAdapter searchAdapter = new SqlDataAdapter(commmand);
            searchAdapter.Fill(searchResultTable);

            // Display the search result in the DataGridView
            dgvDanhsach.DataSource = searchResultTable;
        }

        private List<string> GetMaHDBanList()
        {
            List<string> maHDBanList = new List<string>();

            // Query to get distinct MaHDBan values
            string query = "SELECT DISTINCT MaHDBan FROM HoaDonBan1";
            commmand.CommandText = query;

            using (SqlDataReader reader = commmand.ExecuteReader())
            {
                while (reader.Read())
                {
                    maHDBanList.Add(reader["MaHDBan"].ToString());
                }
            }

            return maHDBanList;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string maHoaDonToSearch = cbMaHD.Text.Trim();

            if (!string.IsNullOrEmpty(maHoaDonToSearch))
            {
                // Perform the search
                SearchMaHoaDon(maHoaDonToSearch);
            }
            else
            {
                // Display all data if the search string is empty
                loaddata();
            }
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
    }

}
