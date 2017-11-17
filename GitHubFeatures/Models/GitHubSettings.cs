using GitHubFeatures.Models.Enums;

namespace GitHubFeatures.Models
{
    public class GitHubSettings
    {
        public string UserName { get; set; }
        public string RepositoryName { get; set; }
        public RequestTypes RequestType { get; set; }
    }
}
