using JsonToDb.Model;
using Microsoft.EntityFrameworkCore;

namespace JsonToDb
{
    class ApplicationDbContext: DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<DailyData> DailyData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JsonToDb;Trusted_Connection=True;MultipleActiveResultSets=true;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
