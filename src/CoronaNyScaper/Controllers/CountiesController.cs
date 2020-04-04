using System;
using System.Collections.Generic;
using CoronaNyScaper.Model;
using Microsoft.AspNetCore.Mvc;
using CoronaNyScaper.Repository;
using System.Threading.Tasks;
using System.Net.Mime;

namespace CoronaNyScaper.Controllers
{
    [ApiController]
    [Route("/api/search/counties")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CountiesController: ControllerBase
    {
        private readonly ICountyDataRepository _repository;

        public CountiesController(ICountyDataRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(List<NyCounty>), 200)]
        public async Task<ActionResult<List<NyCounty>>> Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            return await _repository.GetByDateRange(startDate, endDate);   
        }

        [HttpGet("new-per-day")]
        [ProducesResponseType(typeof(List<NyCounty>), 200)]
        public async Task<ActionResult<List<NyCounty>>> GetNewPerDay()
        {
            return await _repository.NewPerDay(); 
        }
    }
}