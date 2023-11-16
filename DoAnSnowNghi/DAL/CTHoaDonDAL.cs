using DoAnSnowNghi.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnSnowNghi.DAL
{
    internal class CTHoaDonDAL
    {
        private KetNoi db = null;
        public CTHoaDonDAL()
        {
            db = new KetNoi();
        }

        public List<ChiTietHoaDon> getList()
        {
            return db.ChiTietHoaDons.ToList();
        }

        public ChiTietHoaDon getRow(int MaH)
        {
            return db.ChiTietHoaDons.Find(MaH);
        }

        public int getCount()
        {
            return db.ChiTietHoaDons.Count();
        }

        public void Insert(ChiTietHoaDon Chitiet)
        {
            db.ChiTietHoaDons.Add(Chitiet);
            db.SaveChanges();
        }

        public void Update(ChiTietHoaDon Chitiet)
        {
            db.Entry(Chitiet).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(ChiTietHoaDon Chitiet)
        {
            db.ChiTietHoaDons.Remove(Chitiet);
            db.SaveChanges();
        }

        public void Delete(int MaHDBan)
        {
            ChiTietHoaDon Chitiet = db.ChiTietHoaDons.Find(MaHDBan);
            db.ChiTietHoaDons.Remove(Chitiet);
            db.SaveChanges();
        }
    }
}
