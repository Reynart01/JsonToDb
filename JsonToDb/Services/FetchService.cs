using JsonToDb.Dtos;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonToDb.Services
{
    public class FetchService
    {
        public async Task<SourceData> FetchDataFromUrl(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var stream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<SourceData>(stream);
        }
    }
}
