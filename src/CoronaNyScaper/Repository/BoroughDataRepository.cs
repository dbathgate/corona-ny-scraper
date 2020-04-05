using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaNyScaper.Data;
using CoronaNyScaper.Model;
using Microsoft.EntityFrameworkCore;

namespace CoronaNyScaper.Repository
{
    public class BoroughDataRepository : IBoroughDataRepository
    {
        readonly MetricDatabaseContext _databaseContext;

        public BoroughDataRepository(MetricDatabaseContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<NyBorough>> CasesByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _databaseContext.NyBoroughs
                .GroupBy(g => new
                {
                    g.Bronx,
                    g.Brooklyn,
                    g.Manhattan,
                    g.Staten,
                    g.Queens
                })
                .Select(s => new NyBorough
                {
                    Bronx = s.Key.Bronx,
                    Brooklyn = s.Key.Brooklyn,
                    Manhattan = s.Key.Manhattan,
                    Staten = s.Key.Staten,
                    Queens = s.Key.Queens,
                    LastUpdated = s.Min(s => s.LastUpdated)
                })
                .Where(s => s.LastUpdated >= startDate && s.LastUpdated <= endDate)
                .OrderByDescending(s => s.LastUpdated)
                .ToListAsync();
        }

        public async Task<List<NyBorough>> DeathsByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _databaseContext.NyBoroughDeaths
                .GroupBy(g => new
                {
                    g.Bronx,
                    g.Brooklyn,
                    g.Manhattan,
                    g.Staten,
                    g.Queens
                })
                .Select(s => new NyBorough
                {
                    Bronx = s.Key.Bronx,
                    Brooklyn = s.Key.Brooklyn,
                    Manhattan = s.Key.Manhattan,
                    Staten = s.Key.Staten,
                    Queens = s.Key.Queens,
                    LastUpdated = s.Min(s => s.LastUpdated)
                })
                .Where(s => s.LastUpdated >= startDate && s.LastUpdated <= endDate)
                .OrderByDescending(s => s.LastUpdated)
                .ToListAsync();
        }

        public async Task<List<NyBorough>> HospitalizationsByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _databaseContext.NyBoroughsHospitalizations
                .GroupBy(g => new
                {
                    g.Bronx,
                    g.Brooklyn,
                    g.Manhattan,
                    g.Staten,
                    g.Queens
                })
                .Select(s => new NyBorough
                {
                    Bronx = s.Key.Bronx,
                    Brooklyn = s.Key.Brooklyn,
                    Manhattan = s.Key.Manhattan,
                    Staten = s.Key.Staten,
                    Queens = s.Key.Queens,
                    LastUpdated = s.Min(s => s.LastUpdated)
                })
                .Where(s => s.LastUpdated >= startDate && s.LastUpdated <= endDate)
                .OrderByDescending(s => s.LastUpdated)
                .ToListAsync();
        }

        public async Task<List<NyBorough>> NewCasesPerDay()
        {
            var result = await _databaseContext.NyBoroughs
                .GroupBy(g => new
                {
                    LastUpdated = g.LastUpdated.Date
                })
                .Select(s => new NyBorough
                {
                    Bronx = s.Max(s => s.Bronx),
                    Brooklyn = s.Max(s => s.Brooklyn),
                    Manhattan = s.Max(s => s.Manhattan),
                    Staten = s.Max(s => s.Staten),
                    Queens = s.Max(s => s.Queens),
                    LastUpdated = s.Key.LastUpdated
                })
                .OrderByDescending(s => s.LastUpdated)
                .ToListAsync();
            
            return CalculateNewCases(result);
        }

        public async Task<List<NyBorough>> NewHospitalizationsPerDay()
        {
            var result = await _databaseContext.NyBoroughsHospitalizations
                .GroupBy(g => new
                {
                    LastUpdated = g.LastUpdated.Date
                })
                .Select(s => new NyBorough
                {
                    Bronx = s.Max(s => s.Bronx),
                    Brooklyn = s.Max(s => s.Brooklyn),
                    Manhattan = s.Max(s => s.Manhattan),
                    Staten = s.Max(s => s.Staten),
                    Queens = s.Max(s => s.Queens),
                    LastUpdated = s.Key.LastUpdated
                })
                .OrderByDescending(s => s.LastUpdated)
                .ToListAsync();
            
            return CalculateNewCases(result);
        }

        public async Task<List<NyBorough>> NewDeathsPerDay()
        {
            var result = await _databaseContext.NyBoroughDeaths
                .GroupBy(g => new
                {
                    LastUpdated = g.LastUpdated.Date
                })
                .Select(s => new NyBorough
                {
                    Bronx = s.Max(s => s.Bronx),
                    Brooklyn = s.Max(s => s.Brooklyn),
                    Manhattan = s.Max(s => s.Manhattan),
                    Staten = s.Max(s => s.Staten),
                    Queens = s.Max(s => s.Queens),
                    LastUpdated = s.Key.LastUpdated
                })
                .OrderByDescending(s => s.LastUpdated)
                .ToListAsync();
            
            return CalculateNewCases(result);
        }
        
        private List<NyBorough> CalculateNewCases(List<NyBorough> result)
        {
            List<NyBorough> data = new List<NyBorough>();

            int index = 0;
            foreach (var current in result)
            {
                var nextIndex = index + 1;

                if (result.Count > nextIndex)
                {
                    var next = result[nextIndex];

                    data.Add(new NyBorough
                    {
                        Queens = current.Queens - next.Queens,
                        Brooklyn = current.Brooklyn - next.Brooklyn,
                        Manhattan = current.Manhattan - next.Manhattan,
                        Bronx = current.Bronx - next.Bronx,
                        Staten = current.Staten - next.Staten,
                        LastUpdated = current.LastUpdated
                    });
                }

                index = nextIndex;
            }

            return data;
        }
    }
}