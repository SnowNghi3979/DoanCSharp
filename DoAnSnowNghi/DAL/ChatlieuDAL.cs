using DoAnSnowNghi.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnSnowNghi.DAL
{
    internal class ChatlieuDAL
    {
        KetNoi db = null;
        public ChatlieuDAL()
        {
            db = new KetNoi();
        }
        public List<Chatlieu1> getList()
        {
            return db.Chatlieu1.ToList();
        }
        public Chatlieu1 getRow(string MaCL)
        {
            return db.Chatlieu1.Find(MaCL);
        }
        public int getCount()
        {
            return db.Chatlieu1.Count();
        }
        public void Insert(Chatlieu1 chatlieu)
        {
            db.Chatlieu1.Add(chatlieu);
            db.SaveChanges();
        }
        public void Update(Chatlieu1 chatlieu)
        {
            db.Entry(chatlieu).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(Chatlieu1 chatlieu)
        {
            db.Chatlieu1.Remove(chatlieu);
            db.SaveChanges();
        }
        public void Delete(int MaCL)
        {
            Chatlieu1 chatlieu = db.Chatlieu1.Find(MaCL);
            db.Chatlieu1.Remove(chatlieu);
            db.SaveChanges();
        }
        
    }
}
