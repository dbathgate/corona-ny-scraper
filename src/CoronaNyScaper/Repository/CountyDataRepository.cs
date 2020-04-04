using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaNyScaper.Data;
using CoronaNyScaper.Model;
using Microsoft.EntityFrameworkCore;

namespace CoronaNyScaper.Repository
{
    public class CountyDataRepository : ICountyDataRepository
    {
        readonly MetricDatabaseContext _databaseContext;
        
        public CountyDataRepository(MetricDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<NyCounty>> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _databaseContext.NyCounties
                .GroupBy(g => new
                {
                    g.Nassau,
                    g.Suffolk,
                    g.Nyc,
                    g.State
                })
                .Select(s => new NyCounty
                {
                    Nassau = s.Key.Nassau,
                    Suffolk = s.Key.Suffolk,
                    Nyc = s.Key.Nyc,
                    State = s.Key.State,
                    LastUpdated = s.Min(s => s.LastUpdated)
                })
                .Where(s => s.LastUpdated >= startDate && s.LastUpdated <= endDate)
                .OrderByDescending(s => s.LastUpdated)
                .ToListAsync();
        }
    }
}