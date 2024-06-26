
using System.Text.Json;

namespace ExamenDDI_Ale.Service
{
    public class TMDbService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "b5d8429f0393bbd5749fd0bf48844587";
        private const string BaseUrl = "https://api.themoviedb.org/3/";

        public TMDbService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>> GetNowPlayingMoviesAsync()
        {
            var url = $"{BaseUrl}movie/now_playing?api_key={ApiKey}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var nowPlayingResponse = JsonSerializer.Deserialize<NowPlayingResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return nowPlayingResponse.Results;
        }

    }

    public class NowPlayingResponse
    {
        public List<Movie> Results { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Poster_Path { get; set; }
    }
}
