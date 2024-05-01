using MyWebAPINet5.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebAPINet5.Services
{
    public class LoaiHangRepoInMemory : ILoaiHangRepository
    {
        static List<LoaiHangVM> loais = new List<LoaiHangVM>
        {
            new LoaiHangVM{MaLoai = 1, TenLoai = "Tivi"},
            new LoaiHangVM{MaLoai = 2, TenLoai = "Tủ lạnh"},
            new LoaiHangVM{MaLoai = 3, TenLoai = "Điều hòa"},
            new LoaiHangVM{MaLoai = 4, TenLoai = "Máy giặt"},
        };
        public LoaiHangVM Add(LoaiHangModel loaiHang)
        {
            var loai = new LoaiHangVM
            {
                MaLoai = loais.Max(lo => lo.MaLoai + 1),
                TenLoai = loaiHang.TenLoai
            };
            loais.Add(loai);
            return loai;
        }

        public void Delete(int id)
        {
            var loai = loais.SingleOrDefault(lo => lo.MaLoai == loaiHang.MaLoai);
            if (loai != null)
            {
                loais.Remove(loai);
            }
        }

        public List<LoaiHangVM> GetAll()
        {
            return loais;
        }

        public LoaiHangVM GetById(int id)
        {
            return loais.SingleOrDefault(lo => lo.MaLoai == id);


        }

        public void Update(LoaiHangVM loaiHang)
        {
            var loai = loais.SingleOrDefault(lo => lo.MaLoai == loaiHang.MaLoai);
            if (loai != null)
            {
                loai.TenLoai = loaiHang.TenLoai;
            }
        }
    }
}
