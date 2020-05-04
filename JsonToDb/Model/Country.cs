﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JsonToDb.Model
{
    public class Country
    {
        [Key]
        public string GeoId { get; set; }
        public string Name { get; set; }
        public string TerrorityCode { get; set; }
        public virtual ICollection<DailyData> DailyDataCollection { get; set; }
    }
}
