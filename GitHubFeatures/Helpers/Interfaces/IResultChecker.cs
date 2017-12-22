namespace GitHubFeatures.Helpers.Interfaces
{
    public interface IResultChecker
    {
        bool IsCodeCorrect(string code, object expectedResult);
    }
}
