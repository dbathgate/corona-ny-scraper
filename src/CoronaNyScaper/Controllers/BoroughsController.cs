using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using CoronaNyScaper.Model;
using CoronaNyScaper.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoronaNyScaper.Controllers
{
    [ApiController]
    [Route("/api/search/boroughs")]
    [Produces(MediaTypeNames.Application.Json)]
    public class BoroughsController : Controller
    {
        private readonly IBoroughDataRepository _repository;

        public BoroughsController(IBoroughDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<NyBorough>), 200)]
        public async Task<ActionResult<List<NyBorough>>> Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            return await _repository.CasesByDateRange(startDate, endDate);
        }
        
        [HttpGet("hospitalizations")]
        [ProducesResponseType(typeof(List<NyBorough>), 200)]
        public  async Task<ActionResult<List<NyBorough>>> GetHospitalizations([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            return await _repository.HospitalizationsByDateRange(startDate, endDate);   
        }

        [HttpGet("deaths")]
        [ProducesResponseType(typeof(List<NyBorough>), 200)]
        public  async Task<ActionResult<List<NyBorough>>> getDeaths([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            return await _repository.DeathsByDateRange(startDate, endDate);   
        }
    }
}