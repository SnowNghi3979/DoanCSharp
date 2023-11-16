using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnSnowNghi.BAL;
using DoAnSnowNghi.DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace DoAnSnowNghi
{
    public partial class FrmChatlieu : Form
    {
        int rowindex = -1;
        KetNoi db = new KetNoi();
        ChatlieuDAL chatlieuDAO = new ChatlieuDAL();
        private string AddOrEdit = null;

        public void ResetText1()
        {
            txtMaChatLieu.Clear();
            txtTenchatlieu.Clear();
            

        }
        private void loadChatlieu()
        {
            dgvDanhsach.DataSource = db.Chatlieu1.Select(p => new { p.Machatlieu, p.Tenchatlieu }).ToList();
        }
        

        public FrmChatlieu()
        {
            InitializeComponent();
           

        }
        private void ShowAndHidden(bool show)
        {
            txtMaChatLieu.Enabled = true;
            txtTenchatlieu.Enabled = true;
        }
        private void FrmChatlieu_Load(object sender, EventArgs e)
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
            loadChatlieu();
        }

        private void dgvDanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaChatLieu.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            rowindex = e.RowIndex;
            rowindex = e.RowIndex;
            txtMaChatLieu.Text = dgvDanhsach.Rows[rowindex].Cells["Machatlieu"].Value.ToString();
            txtTenchatlieu.Text = dgvDanhsach.Rows[rowindex].Cells["Tenchatlieu"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ShowAndHidden(true);
            AddOrEdit = "Add";
            btnLuu.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaChatLieu.Enabled = true;//lm mờ ô text không cho chỉnh sửa
            btnLuu.Enabled = true;
            AddOrEdit = "Edit";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
            string MaCL = string.Format(txtMaChatLieu.Text.Trim());

            Chatlieu1 cl = chatlieuDAO.getRow(MaCL);
            chatlieuDAO.Delete(cl);
            loadChatlieu();
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

        private void txtTenchatlieu_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenchatlieu.Text;
            string filteredInput = Regex.Replace(input, @"[^a-zA-Z0-9\sÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓÔỌỎỐỒỔỖỘỚỜỞỠỢÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọôỏốồổỗộớờởỡợùúụủũưừứựửữỳýỵỷỹđ]+", "");

            if (input != filteredInput)
            {
                MessageBox.Show("Tên chất liệu không được chứa kí tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenchatlieu.Text = filteredInput;
                txtTenchatlieu.SelectionStart = filteredInput.Length;
            }
        }

        private void txtMaChatLieu_TextChanged(object sender, EventArgs e)
        {
            if (txtMaChatLieu.Text.Length > 4)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Mã chất liệu không được nhập quá 5 kí tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
                try
                {
                    if (string.IsNullOrWhiteSpace(txtMaChatLieu.Text))
                    {
                        MessageBox.Show("Vui lòng điền Mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtTenchatlieu.Text))
                    {
                        MessageBox.Show("Vui lòng điền Tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    
                    if (AddOrEdit == "Add")
                    {
                        //Luu vào CSDL
                        ChatlieuDAL chatlieuDAO = new ChatlieuDAL();
                        Chatlieu1 cl = new Chatlieu1();
                        cl.Machatlieu = txtMaChatLieu.Text.Trim();
                        cl.Tenchatlieu = txtTenchatlieu.Text.Trim();
                       

                        chatlieuDAO.Insert(cl);
                        db.SaveChanges();
                        loadChatlieu();
                    }
                    if (AddOrEdit == "Edit")
                    {
                        //Update
                        string maSP = string.Format(txtMaChatLieu.Text.Trim());
                        Chatlieu1 cl = chatlieuDAO.getRow(maSP);
                        cl.Machatlieu = txtMaChatLieu.Text.Trim();

                        cl.Tenchatlieu = txtTenchatlieu.Text.Trim();

                        chatlieuDAO.Update(cl);
                        dgvDanhsach.DataSource = chatlieuDAO.getList();
                    }
                    txtMaChatLieu.Text = "";
                    txtTenchatlieu.Text = "";
                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }
    }

