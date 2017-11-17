using GitHubFeatures.Helpers.Interfaces;
using GitHubFeatures.Models;
using GitHubFeatures.Models.Enums;

namespace GitHubFeatures.Helpers
{
    public class UrlGenerator : IUrlGenerator
    {
        public const string GITHUB_API_URL = @"https://api.github.com/";
        public const string GITHUB_REPO_URL = @"repos/{:owner}{:repo}";
        public string GenerateUrlForGitHubApi(GitHubSettings settings)
        {
            var urlString = string.Empty;

            switch (settings.RequestType)
            {
                case RequestTypes.CheckIfRepositoryExists:
                    if (!string.IsNullOrEmpty(settings.UserName) && !string.IsNullOrEmpty(settings.RepositoryName))
                        urlString = $"{GITHUB_API_URL}{GITHUB_REPO_URL.Replace("{:owner}", settings.UserName).Replace("{:repo}", settings.RepositoryName)}";
                    break;
            }

            return urlString;
        }
    }
}
