using System;
using System.Threading.Tasks;
using CoronaNyScaper.Context;
using CoronaNyScaper.Model;
using CoronaNyScaper.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeZoneConverter;

namespace CoronaNyScaper.Controllers
{
    // [ApiController]
    // [Route("/api/scrape")]
    // public class ScrapeController : ControllerBase
    // {
    //     private readonly INyDataRepository _repository;
    //     private readonly MetricDatabaseContext _databaseContext;
    //     private readonly ILogger<ScrapeController> _logger;
    //
    //     public ScrapeController(INyDataRepository repository, MetricDatabaseContext databaseContext, ILogger<ScrapeController> logger)
    //     {
    //         this._repository = repository;
    //         this._databaseContext = databaseContext;
    //         this._logger = logger;
    //     }
    //     
    //     [HttpPost]
    //     public async Task<IActionResult> Scrape()
    //     {
    //         var nyData = await this._repository.Get();
    //
    //         var timeZoneInfo = TZConvert.GetTimeZoneInfo("America/New_York");
    //         var nyDataEntity = new NyDataEntity
    //         {
    //             last_updated = DateTime.UtcNow,
    //             suffolk = nyData.suffolk,
    //             nassau = nyData.nassau,
    //             nyc = nyData.nyc,
    //             state = nyData.state,
    //             newsday_last_updated = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(nyData.last_updated), timeZoneInfo)
    //         };
    //         
    //         _databaseContext.Add(nyDataEntity);
    //         await _databaseContext.SaveChangesAsync();
    //         
    //         _logger.LogInformation("Successfully fetched and stored data");
    //
    //         return Ok();
    //     }
    // }
}