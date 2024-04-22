using Microsoft.EntityFrameworkCore;

namespace MyWebAPINet5.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }

        //region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<LoaiHang> LoaiHangs { get; set; }
    }
}
