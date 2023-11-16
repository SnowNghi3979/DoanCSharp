using DoAnSnowNghi.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnSnowNghi.DAL
{
    internal class HDBanDAL
    {
        private KetNoi db = null;

        public HDBanDAL()
        {
            db = new KetNoi();
        }

        public List<HoaDonBan> getList()
        {
            return db.HoaDonBans.ToList();
        }

        public HoaDonBan getRow(int MaHDBan)
        {
            return db.HoaDonBans.Find(MaHDBan);
        }

        public int getCount()
        {
            return db.HoaDonBans.Count();
        }

        public void Insert(HoaDonBan hoadon)
        {
            db.HoaDonBans.Add(hoadon);
            db.SaveChanges();
        }

        public void Update(HoaDonBan hoadon)
        {
            db.Entry(hoadon).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(HoaDonBan hoadon)
        {
            db.HoaDonBans.Remove(hoadon);
            db.SaveChanges();
        }

        public void Delete(int MaHDBan)
        {
            HoaDonBan hoadon = db.HoaDonBans.Find(MaHDBan);
            db.HoaDonBans.Remove(hoadon);
            db.SaveChanges();
        }

        //public List<Hang1> GetHangsByKeyword(string keyword)
        //{
        //    return db.Hang1.Where(h => h.Tenhang.Contains(keyword)).ToList();
        //}
    }
}

