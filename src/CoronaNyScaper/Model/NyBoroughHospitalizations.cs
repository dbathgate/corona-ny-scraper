using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaNyScaper.Model
{
    [Table("corona_borough_hospitalizations")]
    public class NyBoroughHospitalizations
    {
        [Key]
        [Column("last_updated")]
        public DateTime LastUpdated { get; set; }
        
        [Column("queens")]
        public int Queens { get; set; }
        
        [Column("manhattan")]
        public int Manhattan { get; set; }
        
        [Column("brooklyn")]
        public int Brooklyn { get; set; }
        
        [Column("staten")]
        public int Staten { get; set; }
        
        [Column("bronx")]
        public int Bronx { get; set; }
    }
}