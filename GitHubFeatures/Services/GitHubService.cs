using GitHubFeatures.Models;
using GitHubFeatures.Services.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GitHubFeatures.Services
{
    public class GitHubService : IGithubService
    {
        public Repository ProcessRepositoryInfoByUrl(string urlString)
        {
            Repository repository = null;
            try
            {
                if (!string.IsNullOrEmpty(urlString))
                {
                    var client = new HttpClient();

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                    var stringTask = client.GetStringAsync(urlString).Result;

                    repository = Repository.FromJson(stringTask);
                }
                return repository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
