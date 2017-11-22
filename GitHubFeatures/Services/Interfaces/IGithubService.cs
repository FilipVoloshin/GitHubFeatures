using System.Collections.Generic;
using GitHubFeatures.Models;

namespace GitHubFeatures.Services.Interfaces
{
    public interface IGithubService
    {
        Repository ProcessRepositoryInfoByUrl(string urlString);
        IList<PullRequest> ProcessPullRequests(string url);
    }
}
