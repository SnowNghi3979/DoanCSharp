using DoAnSnowNghi.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnSnowNghi.DAL
{
    internal class NhanVienDAL
    {
        KetNoi db = null;
        public NhanVienDAL()
        {
            db = new KetNoi();
        }
        public List<NhanVien> getList()
        {
            return db.NhanViens.ToList();
        }
        public NhanVien getRow(int MaNV)
        {
            return db.NhanViens.Find(MaNV);
        }
        public int getCount()
        {
            return db.NhanViens.Count();
        }
        public void Insert(NhanVien nhanvien)
        {
            db.NhanViens.Add(nhanvien);
            db.SaveChanges();
        }
        public void Update(NhanVien nhanvien)
        {
            db.Entry(nhanvien).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(NhanVien nhanvien)
        {
            db.NhanViens.Remove(nhanvien);
            db.SaveChanges();
        }
        public void Delete(int MaNV)
        {
            NhanVien nhanvien = db.NhanViens.Find(MaNV);
            db.NhanViens.Remove(nhanvien);
            db.SaveChanges();
        }
    }
}
