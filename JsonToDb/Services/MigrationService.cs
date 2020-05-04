using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JsonToDb.Services
{
    public class MigrationService
    {
        public async Task ApplyMigrations()
        {
            using (var context = new ApplicationDbContext())
            {
                await context.Database.MigrateAsync();
            }
        }
    }
}
