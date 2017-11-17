using GitHubFeatures.Helpers.Interfaces;
using GitHubFeatures.Models;
using GitHubFeatures.Models.Enums;
using GitHubFeatures.Models.Forms;
using GitHubFeatures.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Check(GitHubInformationForm form, RequestTypes requestType)
        {
            var url = string.Empty;
            if (form != null)
            {
                switch (requestType)
                {
                    case RequestTypes.CheckIfRepositoryExists:
                        if (!string.IsNullOrEmpty(form.UserName) && !string.IsNullOrEmpty(form.RepositoryName))
                        {
                            var gihubSettings = new GitHubSettings { UserName = form.UserName, RepositoryName = form.RepositoryName, RequestType = requestType };
                            url = _urlGenerator.GenerateUrlForGitHubApi(gihubSettings);
                            var repositoryInformation = _githubService.ProcessRepositoryInfoByUrl(url);
                            if (repositoryInformation != null)
                                return PartialView("_Repository", repositoryInformation);
                        }
                        break;
                    default:
                        return new JsonResult(new { Error = true });
                }
            }
            return new JsonResult(new { Error = true }); ;
        }
    }
}
