using GitHubFeatures.Services.Interfaces;
using System;
using System.Threading.Tasks;
using GitHubFeatures.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace GitHubFeatures.Services
{
    public class CSharpCompileService : ICSharpCompile
    {
        private const string API_URL = "https://www.microsoft.com/net/api/code";
        public async Task<string> GetCodeResultAsync(string code)
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(API_URL));
                request.Headers.Add("Referer", "https://www.microsoft.com/net");
                var codeSnippet = code;

                var codeInput = new CodeRequest { Language = "csharp", CaptureStats = false, Sources = new string[1] };
                codeInput.Sources[0] = codeSnippet;

                var request_content = JsonConvert.SerializeObject(codeInput);
                request.Content = new StringContent(request_content, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.SendAsync(request);

                var responseString = await response.Content.ReadAsStringAsync();
                var codeOutput = JsonConvert.DeserializeObject<CodeResponse>(responseString);
                return codeOutput.Output[0] ?? string.Empty;
            }
        }
    }
}
