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
    }
}