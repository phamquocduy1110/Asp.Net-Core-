using Microsoft.EntityFrameworkCore;

namespace NhatNgheDay01Demo.Entities
{
    public class MyDbContext : DbContext
    {
        #region Properties
        public DbSet<Loai>? Loais { get; set; }

        public DbSet<HangHoa>? HangHoas { get; set; }
        #endregion

        public MyDbContext(DbContextOptions options) : base(options)    
        {

        }
    }
}