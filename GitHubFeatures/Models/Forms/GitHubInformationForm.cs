using System.ComponentModel.DataAnnotations;

namespace GitHubFeatures.Models.Forms
{
    public class GitHubInformationForm
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string RepositoryName { get; set; }
    }
}
