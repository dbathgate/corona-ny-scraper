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
    }
}