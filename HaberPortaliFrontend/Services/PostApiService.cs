using HaberPortaliFrontend.Models;
using System.Net.Http.Json;

namespace HaberPortaliFrontend.Services
{
    

    public class PostApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseApiUrl = "https://localhost:7033/api/News";

        public PostApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Post>>("https://localhost:7033/api/News" + "/GetList");
            }
            catch (HttpRequestException ex)
            {
                // Log the error (e.g., using a logging framework)
                Console.WriteLine($"Error fetching posts: {ex.Message}");
                return new List<Post>(); // Return an empty list or a default response
            }
        }
    }

}
