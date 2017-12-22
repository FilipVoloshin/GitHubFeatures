using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitHubFeatures.Services.Interfaces;
using GitHubFeatures.Helpers.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GitHubFeatures.Controllers
{
    public class CSharpCompileController : Controller
    {

        private ICSharpCompile sharpCompile;
        private IResultChecker resultChecker;
        public CSharpCompileController(ICSharpCompile sharpCompile, IResultChecker resultChecker)
        {
            this.sharpCompile = sharpCompile;
            this.resultChecker = resultChecker;
        }
        public IActionResult Index()
        {
            ViewBag.Main = $"using System;{Environment.NewLine}{Environment.NewLine}public class Test{Environment.NewLine}{{{Environment.NewLine}\t" +
                        $"public static void Main(){Environment.NewLine}\t{{{Environment.NewLine}\t}}{Environment.NewLine}}}";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetCodeResult(string codePart)
        {
            var codeResult = await sharpCompile.GetCodeResultAsync(codePart);
            var isSuccess = resultChecker.IsCodeCorrect(codeResult, "Hello world");
            ViewBag.Result = codeResult;
            ViewBag.Success = isSuccess;
            return PartialView("_CodeResult");
        }
    }
}
