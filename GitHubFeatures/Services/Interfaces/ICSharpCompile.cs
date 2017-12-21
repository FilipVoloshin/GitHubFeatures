using GitHubFeatures.Models;
using System.Threading.Tasks;

namespace GitHubFeatures.Services.Interfaces
{
    public interface ICSharpCompile
    {
        Task<string> GetCodeResultAsync(string code);
    }
}
