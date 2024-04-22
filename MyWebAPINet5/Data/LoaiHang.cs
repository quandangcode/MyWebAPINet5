using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPINet5.Data
{
    [Table("LoaiHang")]
    public class LoaiHang
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        public string TenLoai { get; set; }
    }
}
