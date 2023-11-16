using DoAnSnowNghi.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnSnowNghi.DAL
{
    internal class KhachDAL
    {
        KetNoi db = null;
        public KhachDAL()
        {
            db = new KetNoi();
        }
        public List<Khach2> getList()
        {
            return db.Khach2.ToList();
        }
        public Khach2 getRow(int MaK)
        {
            return db.Khach2.Find(MaK);
        }
        public int getCount()
        {
            return db.Khach2.Count();
        }
        public void Insert(Khach2 khach)
        {
            db.Khach2.Add(khach);
            db.SaveChanges();
        }
        public void Update(Khach2 khach)
        {
            db.Entry(khach).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(Khach2 khach)
        {
            db.Khach2.Remove(khach);
            db.SaveChanges();
        }
        public void Delete(int MaK)
        {
            Khach2 khach = db.Khach2.Find(MaK);
            db.Khach2.Remove(khach);
            db.SaveChanges();
        }
    }
}

