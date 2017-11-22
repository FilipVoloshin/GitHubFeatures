using Newtonsoft.Json;
using System.Collections.Generic;

namespace GitHubFeatures.Models
{
    public partial class Commit
    {
        [JsonProperty("author")]
        public object Author { get; set; }

        [JsonProperty("comments_url")]
        public string CommentsUrl { get; set; }

        [JsonProperty("committer")]
        public object Committer { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

    }

    public partial class PurpleCommit
    {
        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("comment_count")]
        public long CommentCount { get; set; }

        [JsonProperty("committer")]
        public Author Committer { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

    }

    public partial class Author
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Commit
    {
        public static List<Commit> FromJson(string json) => JsonConvert.DeserializeObject<List<Commit>>(json, ConverterCommit.Settings);
    }

    public static class SerializeCommit
    {
        public static string ToJson(this List<Commit> self) => JsonConvert.SerializeObject(self, ConverterCommit.Settings);
    }

    public class ConverterCommit
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
