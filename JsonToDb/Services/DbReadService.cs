using JsonToDb.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToDb.Services
{
    class DbReadService
    {
        public async Task<List<Country>> GetCoutriesAsync()
        {
            using(var context = new ApplicationDbContext())
            {
                return await context.Countries
                    .Include(x=>x.DailyDataCollection)
                    .ToListAsync();
            }
        }
    }
}
