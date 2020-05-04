using JsonToDb.Dtos;
using JsonToDb.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JsonToDb
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var migrationService = new MigrationService();
            var fetchService = new FetchService();
            var mapService = new MapService();
            var dbWriteService = new DbWriteService();
            var dbReadService = new DbReadService();

            await migrationService.ApplyMigrations();

            SourceData data = await fetchService
                .FetchDataFromUrl("https://opendata.ecdc.europa.eu/covid19/casedistribution/json/");

            var countries = mapService.GetCountriesFromSourceData(data);

            await dbWriteService.SaveCountries(countries);

            var dailyData = mapService.GetDailyDataFromSourceData(data);

            await dbWriteService.SaveData(dailyData);

            var countriesFromDb = await dbReadService.GetCoutriesAsync();

            int i = 0;
            Console.WriteLine(string.Format("{0,5}. {1,-50}{2,-20}{3}","Lp", "Państwo","Zachorowania", "Zgony"));
            foreach(var country in countriesFromDb)
            {
                Console.WriteLine(string.Format("{0,5}. {1,-50}{2,-20}{3}", ++i, country.Name, country.DailyDataCollection?.Sum(x => x.Cases), country.DailyDataCollection?.Sum(x => x.Deaths)));//.Replace(' ', '_'));
            }


            Console.ReadKey();
        }
    }
}
