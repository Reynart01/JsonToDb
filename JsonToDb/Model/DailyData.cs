using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonToDb.Model
{
    public class DailyData
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public string PopData2018 { get; set; }
        public Country Country { get; set; }

        [ForeignKey(nameof(Country))]
        public string CountryId { get; set; }
    }
}
