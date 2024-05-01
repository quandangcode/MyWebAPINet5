using MyWebAPINet5.Data;
using MyWebAPINet5.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebAPINet5.Services
{
    public class LoaiHangRepository : ILoaiHangRepository
    {
        public MyDBContext _context;
        public LoaiHangRepository(MyDBContext context)
        {
            _context = context;
        }
        public LoaiHangVM Add(LoaiHangModel loaiHang)
        {
            var loai = new LoaiHang
            {
                TenLoai = loaiHang.TenLoai

            };
            _context.Add(loai);
            _context.SaveChanges();
            return new LoaiHangVM
            {
                TenLoai = loai.TenLoai
            };
        }

        public void Delete(int id)
        {
            var loai = _context.LoaiHangs.SingleOrDefault(lo => lo.MaLoai == id);

            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }

        public List<LoaiHangVM> GetAll()
        {
            var loais = _context.LoaiHangs.Select(loai => new LoaiHangVM
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai,
            }).ToList();
            return loais;
        }

        public LoaiHangVM GetById(int id)
        {
            var loai = _context.LoaiHangs.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai == null)
            {
                return null;
            }
            else
            {
                return new LoaiHangVM
                {
                    MaLoai = loai.MaLoai,
                    TenLoai = loai.TenLoai
                };
            }
        }

        public void Update(LoaiHangVM loaiHang)
        {
            var loai = _context.LoaiHangs.SingleOrDefault(lo => lo.MaLoai == loaiHang.MaLoai);
            if (loai != null)
            {
                loai.TenLoai = loaiHang.TenLoai;
                _context.SaveChanges();
            }

        }
    }
}
