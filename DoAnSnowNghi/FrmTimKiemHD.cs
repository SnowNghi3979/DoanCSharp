using DoAnSnowNghi.BAL;
using DoAnSnowNghi.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoAnSnowNghi
{
    public partial class FrmTimKiemHD : Form
    {
        DataTable tblHDB;

        public DataTable HoaDonBan { get; private set; }

        public FrmTimKiemHD()
        {
            InitializeComponent();
        }

        private void FrmTimKiemHD_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvDanhsach.DataSource = null;
        }

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
            {
                if (Ctl is TextBox)
                {
                    Ctl.Text = "";
                }
            }
            txtMaHD.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Add your code for the button click event
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvDanhsach.DataSource = null;
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void dgvDanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mahd = dgvDanhsach.CurrentRow.Cells["MaHDBan"].Value.ToString();
                FrmTimKiemHD frm = new FrmTimKiemHD();
                frm.txtMaHD.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void LoadDataGridView()
        {
            dgvDanhsach.DataSource = HoaDonBan;
            dgvDanhsach.Columns[0].HeaderText = "Mã HĐB";
            dgvDanhsach.Columns[1].HeaderText = "Mã nhân viên";
            dgvDanhsach.Columns[2].HeaderText = "Ngày bán";
            dgvDanhsach.Columns[3].HeaderText = "Mã khách";
            dgvDanhsach.Columns[4].HeaderText = "Tổng tiền";
            dgvDanhsach.Columns[0].Width = 150;
            dgvDanhsach.Columns[1].Width = 100;
            dgvDanhsach.Columns[2].Width = 80;
            dgvDanhsach.Columns[3].Width = 80;
            dgvDanhsach.Columns[4].Width = 80;
            dgvDanhsach.AllowUserToAddRows = false;
            dgvDanhsach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public class Functions
        {
            public static DataTable GetDataToTable(string sql)
            {
                using (SqlConnection connection = new SqlConnection("Data Source=@LAPTOP-N4PPCP4O\\SQLEXPRESS;Initial Catalog=QLBanHang;User ID=sa;Password=1234"))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        private void btntimKiem_Click_1(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHD.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") &&
                (txtManhanvien.Text == "") && (txtMaKH.Text == "") &&
                (txtTongtien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM HoaDonBan WHERE 1=1";
            if (txtMaHD.Text != "")
                sql = sql + " AND MaHDBan Like N'%" + txtMaHD.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(Ngayban) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(Ngayban) =" + txtNam.Text;
            if (txtManhanvien.Text != "")
                sql = sql + " AND Manhanvien Like N'%" + txtManhanvien.Text + "%'";
            if (txtMaKH.Text != "")
                sql = sql + " AND Makhach Like N'%" + txtMaKH.Text + "%'";
            if (txtTongtien.Text != "")
                sql = sql + " AND Tongtien <=" + txtTongtien.Text;
            HoaDonBan = Functions.GetDataToTable(sql);
            if (HoaDonBan.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có " + HoaDonBan.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDataGridView();
        }
    }
}
