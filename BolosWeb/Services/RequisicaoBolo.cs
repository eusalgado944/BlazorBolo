using BolosModel.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;

namespace BolosWeb.Services
{
    public class RequisicaoBolo
    {
        private readonly HttpClient _httpClient;

        public RequisicaoBolo(IHttpClientFactory httpClientFactory)
        {

            _httpClient = httpClientFactory.CreateClient("BolosAPI");
        }

        public async Task<IEnumerable<Bolo>> BuscarBolo()
        {
            var uriBuilder = new UriBuilder($"{_httpClient.BaseAddress}api/Bolos");
            var parametros = HttpUtility.ParseQueryString(uriBuilder.Query);
            uriBuilder.Query = parametros.ToString();
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                IncludeFields = false,
                UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip
            };
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Bolo>>(uriBuilder.ToString(), jsonSerializerOptions);
            return result ?? new List<Bolo>();
        }
    }
}
