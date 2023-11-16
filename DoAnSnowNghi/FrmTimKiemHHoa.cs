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
    public partial class FrmTimKiemHHoa : Form
    {
        public FrmTimKiemHHoa()
        {
            InitializeComponent();
        }
        int rowindex = -1;
        KetNoi db = new KetNoi();
        HangDAL hangDAO = new HangDAL();
        private string AddOrEdit = null;

        private void loadHang()
        {
            dgvDanhsach.DataSource = db.Hang1.Select(p => new { p.Mahang, p.Tenhang, p.Machatlieu, p.Soluong, p.Dongianhap, p.Dongiaban, p.Anh, p.Ghichu }).ToList();
        }



        private void FrmTimKiemHHoa_Load(object sender, EventArgs e)
        {

            loadHang();
        }
        public void LoadGridByKeyWord(string keyword)
        {
            dgvDanhsach.DataSource = hangDAO.GetHangsByKeyword(keyword);
        }





        private void btnTim_Click_1(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text; // Assuming txtTimKiem is the name of your search textbox
            LoadGridByKeyWord(keyword);
        }

        private void dgvDanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

