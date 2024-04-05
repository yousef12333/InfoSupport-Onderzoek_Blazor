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
        public string ApiKey= "9234d11ae25a3141621ee2d10e88edf0";
        public string BaseUri = "https://api.themoviedb.org/3/";
        public string ImagesUri = "https://image.tmdb.org/t/p/";

        public IObservable<MovieDetails> GetMovieDetails(string movieId) => Observable.FromAsync(() => GetMovieDetailsAsync(movieId));
        public IObservable<int> GetMovieIdByTitle(string title) => Observable.FromAsync(() => GetMovieIdByTitleAsync(title));
        public IObservable<(List<string>, List<int>)> Search(string searchTerm) => Observable.FromAsync(() => SearchAsync(searchTerm));
       
        private async Task<MovieDetails> GetMovieDetailsAsync(string movieId)
        {
            var response = await _httpClient.GetAsync($"{BaseUri}movie/{movieId}?api_key={ApiKey}");
            response.EnsureSuccessStatusCode();
            var contentStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<MovieDetails>(contentStream);
        }

        private async Task<int> GetMovieIdByTitleAsync(string title)
        {
            var url = $"{BaseUri}search/movie?api_key={ApiKey}&query={title}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var searchResult = JsonSerializer.Deserialize<SearchResult>(content);

            return searchResult?.results?.Count() > 0 ? searchResult.results[0].Id : -1;
        }

        private async Task<(List<string>, List<int>)> SearchAsync(string searchTerm)
        {
            var url = $"{BaseUri}search/movie?api_key={ApiKey}&query={searchTerm}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var searchResult = JsonSerializer.Deserialize<SearchResult>(content);

            return ProcessSearchResult(searchResult);
        }

        private (List<string>, List<int>) ProcessSearchResult(SearchResult searchResult)
        {
            var originalTitles = new List<string>();
            var voteCounts = new List<int>();

            if (searchResult?.results == null)
                return (originalTitles, voteCounts);

            var sortedMovies = searchResult.results.OrderByDescending(movie => movie.VoteCount);

            foreach (var movie in sortedMovies)
            {
                originalTitles.Add(movie.Title);
                voteCounts.Add(movie.VoteCount);
            }

            return (originalTitles, voteCounts);
        }
    }
}