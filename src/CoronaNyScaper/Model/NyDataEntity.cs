using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaNyScaper.Model
{
    [Table("corona_ny")]
    public class NyDataEntity
    {
        
        [Key]
        [Column("last_updated")]
        public DateTime LastUpdated { get; set; }
        
        [Column("suffolk")]
        public int Suffolk { get; set; }
        
        [Column("nassau")]
        public int Nassau { get; set; }
        
        [Column("nyc")]
        public int Nyc { get; set; }
        
        [Column("state")]
        public int State { get; set; }
    }
}