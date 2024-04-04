using System.Text.Json.Serialization;

namespace Blazor_Project.Classes
{
    public class MovieDetails
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("adult")]
        public bool Adult { get; set; }
        [JsonPropertyName("original_language")]
        public string Language { get; set; }
        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }
        [JsonPropertyName("overview")]
        public string Overview { get; set; }
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("vote_average")]
        public float VotesAverage { get; set; }
        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }
    }
}
