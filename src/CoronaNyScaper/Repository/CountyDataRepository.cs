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

        public async Task<List<NyCounty>> NewPerDay()
        {
            var result = await _databaseContext.NyCounties
                .GroupBy(g => new
                {
                    LastUpdated = g.LastUpdated.Date
                })
                .Select(s => new NyCounty
                {
                    Nassau = s.Max(s => s.Nassau),
                    Suffolk = s.Max(s => s.Suffolk),
                    Nyc = s.Max(s => s.Nyc),
                    State = s.Max(s => s.State),
                    LastUpdated = s.Key.LastUpdated
                })
                .OrderByDescending(s => s.LastUpdated)
                .ToListAsync();
            
            List<NyCounty> data = new List<NyCounty>();

            int index = 0;
            foreach (var current in result)
            {
                var nextIndex = index + 1;

                if (result.Count > nextIndex)
                {
                    var next = result[nextIndex];

                    data.Add(new NyCounty
                    {
                        Nyc = current.Nyc - next.Nyc,
                        Suffolk = current.Suffolk - next.Suffolk,
                        Nassau = current.Nassau - next.Nassau,
                        State = current.State - next.State,
                        LastUpdated = current.LastUpdated
                    });
                }

                index = nextIndex;
            }

            return data;
        }
    }
}