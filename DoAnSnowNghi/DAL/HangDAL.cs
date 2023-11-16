using DoAnSnowNghi.BAL;
using System.Collections.Generic;
using System.Linq;

namespace DoAnSnowNghi.DAL
{
    internal class HangDAL
    {
        private KetNoi db = null;

        public HangDAL()
        {
            db = new KetNoi();
        }

        public List<Hang1> getList()
        {
            return db.Hang1.ToList();
        }

        public Hang1 getRow(int MaH)
        {
            return db.Hang1.Find(MaH);
        }

        public int getCount()
        {
            return db.Hang1.Count();
        }

        public void Insert(Hang1 hang)
        {
            db.Hang1.Add(hang);
            db.SaveChanges();
        }

        public void Update(Hang1 hang)
        {
            db.Entry(hang).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Hang1 hang)
        {
            db.Hang1.Remove(hang);
            db.SaveChanges();
        }

        public void Delete(int MaH)
        {
            Hang1 hang = db.Hang1.Find(MaH);
            db.Hang1.Remove(hang);
            db.SaveChanges();
        }

        public List<Hang1> GetHangsByKeyword(string keyword)
        {
            return db.Hang1.Where(h => h.Tenhang.Contains(keyword)).ToList();
        }
    }
}
