using System;

namespace CoronaNyScaper.Model
{
    public class NyBorough
    {
        public DateTime LastUpdated { get; set; }
        
        public int Queens { get; set; }
        
        public int Manhattan { get; set; }
        
        public int Brooklyn { get; set; }

        public int Staten { get; set; }
        
        public int Bronx { get; set; }
    }
}