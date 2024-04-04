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
        public string ApiKey { get; } = "9234d11ae25a3141621ee2d10e88edf0";
        public string BaseUri { get; } = "https://api.themoviedb.org/3/";
        public string ImagesUri { get; } = "https://image.tmdb.org/t/p/";

        public IObservable<Movie[]> GetResults()
        {
            return Observable.FromAsync(GetResultsAsync);
        }

        private async Task<Movie[]> GetResultsAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUri}some-endpoint-to-get-results");
            response.EnsureSuccessStatusCode();
            var contentStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Movie[]>(contentStream);
        }

        public IObservable<MovieDetails> GetMovieDetails(string movieId)
        {
            return Observable.FromAsync(() => GetMovieDetailsAsync(movieId));
        }

        private async Task<MovieDetails> GetMovieDetailsAsync(string movieId)
        {
            var response = await _httpClient.GetAsync($"{BaseUri}movie/{movieId}?api_key={ApiKey}");
            response.EnsureSuccessStatusCode();
            var contentStream = await response.Content.ReadAsStreamAsync();
            var movieDetails = await JsonSerializer.DeserializeAsync<MovieDetails>(contentStream);
            Console.WriteLine($"Movie details in api: {movieDetails}");
            return movieDetails;
        }

        public IObservable<int> GetMovieIdByTitle(string title)
        {
            return Observable.FromAsync(() => GetMovieIdByTitleAsync(title));
        }

        private async Task<int> GetMovieIdByTitleAsync(string title)
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
                return -1;
            }
        }

        public IObservable<(List<string>, List<int>)> Search(string searchTerm)
        {
            return Observable.FromAsync(() => SearchAsync(searchTerm));
        }

        private async Task<(List<string>, List<int>)> SearchAsync(string searchTerm)
        {
            var url = $"{BaseUri}search/movie?api_key={ApiKey}&query={searchTerm}";

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var searchResult = JsonSerializer.Deserialize<SearchResult>(content);


                var originalTitles = new List<string>();
                var voteCounts = new List<int>();

                if (searchResult?.results != null && searchResult.results.Count() > 0)
                {
                    var sortedMovies = searchResult.results.OrderByDescending(movie => movie.VoteCount);

                    foreach (var movie in sortedMovies)
                    {
                        originalTitles.Add(movie.Title);
                        voteCounts.Add(movie.VoteCount);
                    }
                }

                return (originalTitles, voteCounts);
            }
            catch (Exception ex)
            {
                return (null, null);
            }
        }
    }
}