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
        public DateTime last_updated { get; set; }
        
        [Column("suffolk")]
        public int suffolk { get; set; }
        
        [Column("nassau")]
        public int nassau { get; set; }
        
        [Column("nyc")]
        public int nyc { get; set; }
        
        [Column("state")]
        public int state { get; set; }
        
        [Column("newsday_last_updated")]
        public DateTime newsday_last_updated { get; set; }
    }
}