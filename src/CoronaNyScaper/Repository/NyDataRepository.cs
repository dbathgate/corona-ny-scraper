using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CoronaNyScaper.Model;
using Microsoft.Extensions.Logging;

namespace CoronaNyScaper.Repository
{
    public class NyDataRepository : INyDataRepository
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly ILogger<NyDataRepository> _logger;

        public NyDataRepository(ILogger<NyDataRepository> logger)
        {
            this._logger = logger;
        }
        
        public async Task<NyData> Get()
        {
            _logger.LogInformation("Here");
            var response = _httpClient.GetStreamAsync("https://projects.newsday.com/assets/corona-widget/");

            return await JsonSerializer.DeserializeAsync<NyData>(await response);
        }
    }
}