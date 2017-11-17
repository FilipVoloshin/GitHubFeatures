using AutoMapper;
using GitHubFeatures.Helpers.Interfaces;
using GitHubFeatures.Models.Enums;
using GitHubFeatures.Models.Forms;
using Microsoft.AspNetCore.Mvc;

namespace GitHubFeatures.Controllers
{
    public class HomeController : Controller
    {
        private IUrlGenerator _urlGenerator;
        public HomeController(IUrlGenerator urlGenerator)
        {
            _urlGenerator = urlGenerator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Check(GitHubInformationForm form, RequestTypes requestType)
        {
            if (form != null)
            {
                switch (requestType)
                {
                    case RequestTypes.CheckIfRepositoryExists:
                        break;
                }
            }
            return null;
        }
    }
}
