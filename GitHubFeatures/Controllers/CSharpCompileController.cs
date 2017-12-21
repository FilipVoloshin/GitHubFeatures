using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitHubFeatures.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GitHubFeatures.Controllers
{
    public class CSharpCompileController : Controller
    {

        private ICSharpCompile sharpCompile;
        public CSharpCompileController(ICSharpCompile sharpCompile)
        {
            this.sharpCompile = sharpCompile;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetCodeResult(string codePart)
        {
            var result = await sharpCompile.GetCodeResultAsync(codePart);
            ViewBag.Result = result;
            ViewBag.Success = !string.IsNullOrEmpty(result);
            return PartialView("_CodeResult");
        }
    }
}
