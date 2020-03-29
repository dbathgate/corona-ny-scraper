using CoronaNyScaper.Model;
using Microsoft.EntityFrameworkCore;

namespace CoronaNyScaper.Context
{
    public class MetricDatabaseContext : DbContext
    {
        public MetricDatabaseContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<NyDataEntity> NyData { get; set; }
        
        public DbSet<NyBoroughEntity> NyBoroughs { get; set; }
        
        public DbSet<NyBoroughDeathsEntity> NyBoroughDeaths { get; set; }
        
        public DbSet<NyBoroughHospitalizations> NyBoroughsHospitalizations { get; set; }
    }
}