using MyWebAPINet5.Models;
using System.Collections.Generic;

namespace MyWebAPINet5.Services
{
    public interface ILoaiHangRepository
    {
        List<LoaiHangVM> GetAll();
        LoaiHangVM GetById(int id);
        LoaiHangVM Add(LoaiHangModel loaiHang);
        void Update(LoaiHangVM loaiHang);
        void Delete(int id);
    }
}
