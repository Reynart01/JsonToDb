using JsonToDb.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonToDb.Services
{
    public class DbWriteService
    {
        public async Task SaveCountries(IEnumerable<Country> countries)
        {
            using(var context = new ApplicationDbContext())
            {
                if(await context.Countries.AnyAsync())
                {
                    return;
                }
                await context.AddRangeAsync(countries);

                await context.SaveChangesAsync();
            }
        }
        public async Task SaveData(IEnumerable<DailyData> data)
        {
            using(var context = new ApplicationDbContext())
            {
                if (await context.DailyData.AnyAsync())
                {
                    return;
                }
                await context.AddRangeAsync(data);

                await context.SaveChangesAsync();
            }
        }     
    }
}
