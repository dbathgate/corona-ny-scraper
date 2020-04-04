using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaNyScaper.Model;

namespace CoronaNyScaper.Repository 
{
    public interface IBoroughDataRepository
    {
        Task<List<NyBorough>> CasesByDateRange(DateTime startDate, DateTime endDate);

        Task<List<NyBorough>> HospitalizationsByDateRange(DateTime startDate, DateTime endDate);

        Task<List<NyBorough>> DeathsByDateRange(DateTime startDate, DateTime endDate);

        Task<List<NyBorough>> NewCasesPerDay();

        Task<List<NyBorough>> NewDeathsPerDay();

        Task<List<NyBorough>> NewHospitalizationsPerDay();
    }
}