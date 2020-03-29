using System;
using System.Linq;
using System.Collections.Generic;
using CoronaNyScaper.Context;
using CoronaNyScaper.Model;
using Microsoft.AspNetCore.Mvc;

namespace CoronaNyScaper.Controllers
{
    [ApiController]
    [Route("/api/search/counties")]
    public class CountiesController: ControllerBase
    {
        private readonly MetricDatabaseContext _databaseContext;

        public CountiesController(MetricDatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(List<NyDataEntity>), 200)]
        public IActionResult Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = _databaseContext.NyData
                .GroupBy(g => new
                {
                    g.Nassau,
                    g.Suffolk,
                    g.Nyc,
                    g.State
                })
                .Select(s => new
                {
                    s.Key.Nassau,
                    s.Key.Suffolk,
                    s.Key.Nyc,
                    s.Key.State,
                    LastUpdated = s.Min(s => s.LastUpdated)
                })
                .Where(s => s.LastUpdated >= startDate && s.LastUpdated <= endDate)
                .OrderByDescending(s => s.LastUpdated)
                .ToList();
            
            return Ok(result);
        }
    }
}