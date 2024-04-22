using System.ComponentModel.DataAnnotations;

namespace MyWebAPINet5.Models
{
    public class LoaiHangModel
    {
        [Required]
        public string TenLoai { get; set; }
    }
}
