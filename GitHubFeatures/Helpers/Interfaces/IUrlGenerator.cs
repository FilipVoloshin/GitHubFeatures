using GitHubFeatures.Models;

namespace GitHubFeatures.Helpers.Interfaces
{
    public interface IUrlGenerator
    {
        string GenerateUrlForGitHubApi(GitHubSettings settings);
    }
}
