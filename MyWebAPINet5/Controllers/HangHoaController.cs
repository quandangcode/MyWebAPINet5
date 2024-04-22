using Microsoft.AspNetCore.Mvc;
using MyWebAPINet5.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebAPINet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //LINQ truy van
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == id);
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(HangHoa hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = hangHoaVM.MaHangHoa,
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, HangHoa hangHoaedit)
        {
            try
            {
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == id);
                if (hanghoa == null) { return NotFound(); }
                if (hangHoaedit.MaHangHoa != hanghoa.MaHangHoa) { return BadRequest(); }
                //Update
                hanghoa.TenHangHoa = hangHoaedit.TenHangHoa;
                hanghoa.DonGia = hangHoaedit.DonGia;
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {

            try
            {
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == id);
                if (hanghoa == null) { return NotFound(); }
                hangHoas.Remove(hanghoa);
                return Ok(hangHoas);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
