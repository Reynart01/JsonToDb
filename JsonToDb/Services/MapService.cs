using JsonToDb.Dtos;
using JsonToDb.Model;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonToDb.Services
{
    public class MapService
    {
        public IEnumerable<Country> GetCountriesFromSourceData(SourceData sourceData)
        {
            return sourceData.records
                .GroupBy(x => x.geoId)
                .Select(x=> x.First())
                .Select(row=> new Country
                {
                    GeoId = row.geoId,
                    Name = row.countriesAndTerritories,
                    TerrorityCode = row.countryterritoryCode,
                })
                .ToList();
        }      
        public IEnumerable<DailyData> GetDailyDataFromSourceData(SourceData sourceData)
        {
            return sourceData.records
                .Select(row=> new DailyData
                {
                    CountryId = row.geoId,
                    Cases = int.Parse(row.cases),
                    Deaths = int.Parse(row.deaths),
                    Date = new DateTime(int.Parse(row.year), int.Parse(row.month), int.Parse(row.day))
                })
                .ToList();
        }
    }
}
