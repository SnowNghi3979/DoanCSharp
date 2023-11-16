using DoAnSnowNghi.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnSnowNghi.DAL
{
    internal class NguoiDungDAL
    {
        KetNoi db = null;
        public NguoiDungDAL()
        {
            db = new KetNoi();
        }
        public NguoiDung1 getRow(string tendn, string matkhau)
        {
            return db.NguoiDung1.Where(m => m.TenDN == tendn && m.MatKhau == matkhau).FirstOrDefault();

        }
    }
}
