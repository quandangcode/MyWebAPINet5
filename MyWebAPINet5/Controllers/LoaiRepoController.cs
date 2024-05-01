using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPINet5.Models;
using MyWebAPINet5.Services;

namespace MyWebAPINet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiRepoController : ControllerBase
    {
        private ILoaiHangRepository _loaiHangRepository;

        public LoaiRepoController(ILoaiHangRepository loaiHangRepository)
        {
            _loaiHangRepository = loaiHangRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_loaiHangRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _loaiHangRepository.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, LoaiHangVM loai)
        {
            if (id != loai.MaLoai)
            {
                return BadRequest();
            }
            try
            {
                _loaiHangRepository.Update(loai);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        [HttpPost]
        public IActionResult Add(LoaiHangModel loai)
        {
            try
            {
                _loaiHangRepository.Add(loai);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                _loaiHangRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}
