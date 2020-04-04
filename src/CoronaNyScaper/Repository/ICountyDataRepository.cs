using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaNyScaper.Model;

namespace CoronaNyScaper.Repository
{
    public interface ICountyDataRepository
    {
        Task<List<NyCounty>> GetByDateRange(DateTime startDate, DateTime endDate);

        Task<List<NyCounty>> NewPerDay();
    }
}