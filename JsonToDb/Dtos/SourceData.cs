﻿namespace JsonToDb.Dtos
{
    public class SourceData
    {
        public Record[] records { get; set; }
    }

    public class Record
    {
        public string dateRep { get; set; }
        public string day { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string cases { get; set; }
        public string deaths { get; set; }
        public string countriesAndTerritories { get; set; }
        public string geoId { get; set; }
        public string countryterritoryCode { get; set; }
        public string popData2018 { get; set; }
    }
}
