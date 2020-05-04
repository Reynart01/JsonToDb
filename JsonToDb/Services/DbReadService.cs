using JsonToDb.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonToDb.Services
{
    class DbReadService
    {
        public async Task<List<CountryDto>> GetTopTenCoutriesAsync()
        {
            using (var context = new ApplicationDbContext())
            {
                return await context.Countries
                    .Include(x => x.DailyDataCollection)
                    .Select(country => new CountryDto
                    {
                        Name = country.Name,
                        TotalDeaths = country.DailyDataCollection.Sum(x => x.Deaths),
                        TotalCases = country.DailyDataCollection.Sum(x => x.Cases)
                    })
                    .OrderByDescending(country => country.TotalDeaths)
                    .ThenByDescending(country => country.TotalCases)
                    .Take(10)
                    .ToListAsync();
            }
        }
        public async Task<List<WorstDayDto>> GetWorstDaysAsync()
        {
            using (var context = new ApplicationDbContext())
            {
                return await context.Countries
                    .Include(x => x.DailyDataCollection)
                    .Select(country => new
                    {
                        Country = country.Name,
                        DayObject = country.DailyDataCollection.OrderByDescending(x => x.Deaths).First(),
                    })
                    .Select(country => new WorstDayDto
                    {
                        Country = country.Country,
                        Date = country.DayObject.Date,
                        Deaths = country.DayObject.Deaths,
                    })
                    .Where(x=>x.Deaths > 100)
                    .OrderBy(country => country.Date)
                    .ThenByDescending(country => country.Deaths)
                    .ToListAsync();
            }
        }
    }
}
