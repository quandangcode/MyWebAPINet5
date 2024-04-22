using Microsoft.AspNetCore.Mvc;
using MyWebAPINet5.Data;
using MyWebAPINet5.Models;
using System.Linq;

namespace MyWebAPINet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiHangController : ControllerBase
    {
        private readonly MyDBContext _context;

        public LoaiHangController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listLoaiHangs = _context.LoaiHangs.ToList();
            return Ok(listLoaiHangs);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loaiHang = _context.LoaiHangs.SingleOrDefault(lh => lh.MaLoai == id);
            if (loaiHang == null)
            {
                return NotFound();
            }
            return Ok(loaiHang);
        }
        [HttpPost]
        public IActionResult CreateNew(LoaiHangModel model)
        {
            try
            {
                var loai = new LoaiHang
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, LoaiHangModel loaiHangedit)
        {
            var loaiHang = _context.LoaiHangs.SingleOrDefault(lh => lh.MaLoai == id);
            if (loaiHang == null)
            {
                return NotFound();
            }
            loaiHang.TenLoai = loaiHangedit.TenLoai;
            _context.SaveChanges();
            return Ok(loaiHang);
        }
    }
}
