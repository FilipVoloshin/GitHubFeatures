using GitHubFeatures.Helpers.Interfaces;
using GitHubFeatures.Models;
using GitHubFeatures.Models.Enums;
using GitHubFeatures.Models.Forms;
using GitHubFeatures.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubFeatures.Controllers
{
    public class HomeController : Controller
    {
        private IUrlGenerator _urlGenerator;
        private IGithubService _githubService;
        public HomeController(IUrlGenerator urlGenerator, IGithubService githubService)
        {
            _urlGenerator = urlGenerator;
            _githubService = githubService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckRepository(GitHubInformationForm form, RequestTypes request)
        {
            Repository repositoryInformation = null;
            var url = string.Empty;

            if (!string.IsNullOrEmpty(form.UserName) && !string.IsNullOrEmpty(form.RepositoryName))
            {
                var gihubSettings = new GitHubSettings { UserName = form.UserName, RepositoryName = form.RepositoryName, RequestType = request };
                url = _urlGenerator.GenerateUrlForGitHubApi(gihubSettings);
                try
                {
                    repositoryInformation = _githubService.ProcessRepositoryInfoByUrl(url);
                }
                catch (Exception ex)
                {
                    ViewBag.InnerException = ex.Message;
                }
            }

            return PartialView("_Repository", repositoryInformation);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckPullRequests(GitHubInformationForm form, RequestTypes request)
        {
            var url = string.Empty;
            IList<PullRequest> pullRequests = new List<PullRequest>();

            if (!string.IsNullOrEmpty(form.UserName) && !string.IsNullOrEmpty(form.RepositoryName))
            {
                var gihubSettings = new GitHubSettings { UserName = form.UserName, RepositoryName = form.RepositoryName, RequestType = request };
                url = _urlGenerator.GenerateUrlForGitHubApi(gihubSettings);
                try
                {
                    pullRequests = _githubService.ProcessPullRequests(url);
                }
                catch (Exception ex)
                {
                    ViewBag.InnerException = ex.Message;
                }
            }
            return PartialView("_PullRequests", pullRequests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckBranches(GitHubInformationForm form, RequestTypes request)
        {
            IList<Branch> branches = new List<Branch>();
            var url = string.Empty;

            if (!string.IsNullOrEmpty(form.UserName) && !string.IsNullOrEmpty(form.RepositoryName))
            {
                var gihubSettings = new GitHubSettings { UserName = form.UserName, RepositoryName = form.RepositoryName, RequestType = request };
                url = _urlGenerator.GenerateUrlForGitHubApi(gihubSettings);
                try
                {
                    branches = _githubService.ProcessBranches(url);
                }
                catch (Exception ex)
                {
                    ViewBag.InnerException = ex.Message;
                }
            }
            return PartialView("_Branches", branches);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckCommits(GitHubInformationForm form, RequestTypes request)
        {
            IList<Commit> commits = new List<Commit>();
            var url = string.Empty;

            if (!string.IsNullOrEmpty(form.UserName) && !string.IsNullOrEmpty(form.RepositoryName))
            {
                var gihubSettings = new GitHubSettings { UserName = form.UserName, RepositoryName = form.RepositoryName, RequestType = request };
                url = _urlGenerator.GenerateUrlForGitHubApi(gihubSettings);
                try
                {
                    commits = _githubService.ProcessCommits(url);
                }
                catch (Exception ex)
                {
                    ViewBag.InnerException = ex.Message;
                }
            }

            return PartialView("_Branches", commits);
        }
    }
}
