using CoronaNyScaper.Model;
using Microsoft.EntityFrameworkCore;

namespace CoronaNyScaper.Data
{
    public class MetricDatabaseContext : DbContext
    {
        public MetricDatabaseContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<NyCountyEntity> NyCounties { get; set; }
        
        public DbSet<NyBoroughEntity> NyBoroughs { get; set; }
        
        public DbSet<NyBoroughDeathsEntity> NyBoroughDeaths { get; set; }
        
        public DbSet<NyBoroughHospitalizationsEntity> NyBoroughsHospitalizations { get; set; }
    }
}