using System;
using System.Collections.Generic;
using System.Linq;
using CoronaNyScaper.Context;
using CoronaNyScaper.Model;
using Microsoft.AspNetCore.Mvc;

namespace CoronaNyScaper.Controllers
{
    [ApiController]
    [Route("/api/search/boroughs")]
    public class BoroughsController : Controller
    {
        private readonly MetricDatabaseContext _databaseContext;

        public BoroughsController(MetricDatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<NyBoroughEntity>), 200)]
        public IActionResult Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {

            var nyDataEntity = _databaseContext.NyBoroughs
                .GroupBy(g => new
                {
                    g.Bronx,
                    g.Brooklyn,
                    g.Manhattan,
                    g.Staten,
                    g.Queens
                })
                .Select(s => new
                {
                    s.Key.Bronx,
                    s.Key.Brooklyn,
                    s.Key.Manhattan,
                    s.Key.Staten,
                    s.Key.Queens,
                    LastUpdated = s.Min(s => s.LastUpdated)
                })
                .Where(s => s.LastUpdated >= startDate && s.LastUpdated <= endDate)
                .OrderByDescending(s => s.LastUpdated)
                .ToList();
            
            return Ok(nyDataEntity);
        }
        
        [HttpGet("deaths")]
        [ProducesResponseType(typeof(List<NyBoroughEntity>), 200)]
        public IActionResult GetDeaths([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {

            var nyDataEntity = _databaseContext.NyBoroughDeaths
                .GroupBy(g => new
                {
                    g.Bronx,
                    g.Brooklyn,
                    g.Manhattan,
                    g.Staten,
                    g.Queens
                })
                .Select(s => new
                {
                    s.Key.Bronx,
                    s.Key.Brooklyn,
                    s.Key.Manhattan,
                    s.Key.Staten,
                    s.Key.Queens,
                    LastUpdated = s.Min(s => s.LastUpdated)
                })
                .Where(s => s.LastUpdated >= startDate && s.LastUpdated <= endDate)
                .OrderByDescending(s => s.LastUpdated)
                .ToList();
            
            return Ok(nyDataEntity);
        }
        
        [HttpGet("hospitalizations")]
        [ProducesResponseType(typeof(List<NyBoroughEntity>), 200)]
        public IActionResult GetHospitalizations([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {

            var nyDataEntity = _databaseContext.NyBoroughsHospitalizations
                .GroupBy(g => new
                {
                    g.Bronx,
                    g.Brooklyn,
                    g.Manhattan,
                    g.Staten,
                    g.Queens
                })
                .Select(s => new
                {
                    s.Key.Bronx,
                    s.Key.Brooklyn,
                    s.Key.Manhattan,
                    s.Key.Staten,
                    s.Key.Queens,
                    LastUpdated = s.Min(s => s.LastUpdated)
                })
                .Where(s => s.LastUpdated >= startDate && s.LastUpdated <= endDate)
                .OrderByDescending(s => s.LastUpdated)
                .ToList();
            
            return Ok(nyDataEntity);
        }
    }
}