using Blazor_Project.Classes;
using Blazor_Project.Pages;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text.Json;

namespace Blazor_Project.Services
{
    public class API
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public event Action<Movie[]> OnResultsReceived;
        public event Action<MovieDetails> OnMovieDetailsReceived;
        public string ApiKey { get; } = "9234d11ae25a3141621ee2d10e88edf0"; 
        public string BaseUri { get; } = "https://api.themoviedb.org/3/";
        public string ImagesUri { get; } = "https://image.tmdb.org/t/p/";

        public async Task GetResults()
        {
            var response = await _httpClient.GetAsync($"{BaseUri}some-endpoint-to-get-results");
            response.EnsureSuccessStatusCode();
            var contentStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<Movie[]>(contentStream);
            OnResultsReceived?.Invoke(result);
        }

        public async Task<MovieDetails> GetMovieDetails(string movieId)
        {
            var response = await _httpClient.GetAsync($"{BaseUri}movie/{movieId}?api_key={ApiKey}");
            response.EnsureSuccessStatusCode();
            var contentStream = await response.Content.ReadAsStreamAsync();
            var movieDetails = await JsonSerializer.DeserializeAsync<MovieDetails>(contentStream);
            OnMovieDetailsReceived?.Invoke(movieDetails);
            Console.WriteLine($"Movie details in api: {movieDetails}");
            return movieDetails;
        }
        public async Task<int> GetMovieIdByTitle(string title)
        {
            var url = $"{BaseUri}search/movie?api_key={ApiKey}&query={title}";

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var searchResult = JsonSerializer.Deserialize<SearchResult>(content);

                if (searchResult?.results != null && searchResult.results.Count() > 0)
                {
                    return searchResult.results[0].Id;
                }
                else
                {
                    return -1; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during search: {ex.Message}");
                return -1; 
            }
        }
        public async Task<(List<string> originalTitles, List<int> voteCounts)> Search(string searchTerm)
        {
            var url = $"{BaseUri}search/movie?api_key={ApiKey}&query={searchTerm}";

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var searchResult = JsonSerializer.Deserialize<SearchResult>(content);

                Console.WriteLine("Response Content: " + content);

                var originalTitles = new List<string>();
                var voteCounts = new List<int>();

                if (searchResult?.results != null && searchResult.results.Any())
                {
                    var sortedMovies = searchResult.results.OrderByDescending(movie => movie.VoteCount);
                    Console.WriteLine($"Number of movies found: {sortedMovies.Count()}");

                    foreach (var movie in sortedMovies)
                    {
                        originalTitles.Add(movie.Title);
                        voteCounts.Add(movie.VoteCount);
                    }

                    foreach (var title in originalTitles)
                    {
                        Console.WriteLine($"Original Title: {title}");
                    }
                    foreach (var voteCount in voteCounts)
                    {
                        Console.WriteLine($"Vote Count: {voteCount}");
                    }
                }
                else
                {
                    Console.WriteLine("No movies found");
                }

                return (originalTitles, voteCounts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during search: {ex.Message}");
                return (null, null);
            }
        }
    }
}