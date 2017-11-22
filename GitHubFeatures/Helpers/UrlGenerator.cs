using GitHubFeatures.Helpers.Interfaces;
using GitHubFeatures.Models;
using GitHubFeatures.Models.Enums;

namespace GitHubFeatures.Helpers
{
    public class UrlGenerator : IUrlGenerator
    {
        public string User_Key => "31db8cea24ba6deef076";
        public string User_Secret => "b0ba3e1e8ab06aa9d0acb7f4db540f4a3e8dc6f9";

        public const string GITHUB_API_URL = @"https://api.github.com/";
        public const string GITHUB_REPO_URL = @"repos/{:owner}/{:repo}";
        public const string GITHUB_PULL_REQUESTS_URL = @"repos/{:owner}/{:repo}/pulls";
        public const string GITHUB_BRANCHES_URL = @"repos/{:owner}/{:repo}/branches";
        public const string GITHUB_COMMITS_URL = @"repos/{:owner}/{:repo}/commits";


        private string SetUpApiString(string apiString, string userName, string repoName)
        {
            var urlString = $"{GITHUB_API_URL}{apiString.Replace("{:owner}", userName).Replace("{:repo}", repoName)}";
            return $"{urlString}?{User_Key}&{User_Secret}";
        }

        public string GenerateUrlForGitHubApi(GitHubSettings settings)
        {
            var urlString = string.Empty;

            switch (settings.RequestType)
            {
                case RequestTypes.CheckIfRepositoryExists:
                    if (!string.IsNullOrEmpty(settings.UserName) && !string.IsNullOrEmpty(settings.RepositoryName))
                        urlString = SetUpApiString(GITHUB_REPO_URL, settings.UserName, settings.RepositoryName);
                    break;
                case RequestTypes.GetAllPullRequests:
                    if (!string.IsNullOrEmpty(settings.UserName) && !string.IsNullOrEmpty(settings.RepositoryName))
                        urlString = SetUpApiString(GITHUB_PULL_REQUESTS_URL, settings.UserName, settings.RepositoryName);
                    break;
                case RequestTypes.GetAllBranches:
                    if (!string.IsNullOrEmpty(settings.UserName) && !string.IsNullOrEmpty(settings.RepositoryName))
                        urlString = SetUpApiString(GITHUB_BRANCHES_URL, settings.UserName, settings.RepositoryName);
                    break;
                case RequestTypes.LastCommits:
                    if (!string.IsNullOrEmpty(settings.UserName) && !string.IsNullOrEmpty(settings.RepositoryName))
                        urlString = SetUpApiString(GITHUB_COMMITS_URL, settings.UserName, settings.RepositoryName);
                    break;
            }

            return urlString;
        }
    }
}
