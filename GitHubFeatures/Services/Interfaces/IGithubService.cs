﻿using System.Collections.Generic;
using GitHubFeatures.Models;

namespace GitHubFeatures.Services.Interfaces
{
    public interface IGithubService
    {
        Repository ProcessRepositoryInfoByUrl(string urlString);
        IList<PullRequest> ProcessPullRequests(string url);
        IList<Branch> ProcessBranches(string url);
        IList<Commit> ProcessCommits(string url);
    }
}
