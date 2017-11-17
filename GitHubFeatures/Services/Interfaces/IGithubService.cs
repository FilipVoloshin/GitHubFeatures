using GitHubFeatures.Models;

namespace GitHubFeatures.Services.Interfaces
{
    public interface IGithubService
    {
        Repository ProcessRepositoryInfoByUrl(string urlString);
    }
}
