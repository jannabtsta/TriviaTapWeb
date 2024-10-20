using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TriviaTapWeb.Models;

namespace TriviaTapWeb.Services
{
    public class JokeService
    {
        private readonly HttpClient _httpClient;

        public JokeService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<JokeResponse> GetRandomJoke()
        {
            var response = await _httpClient.GetStringAsync("https://v2.jokeapi.dev/joke/Any");
            var jokeResponse = JsonConvert.DeserializeObject<JokeResponse>(response);
            return jokeResponse;
        }
    }
}
