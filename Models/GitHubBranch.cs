using System.Text.Json.Serialization;


namespace chessAI.Models // Replace 'YourApp.Models' with the appropriate namespace for your project
{
    public class GitHubBranch
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("commit")]
        public GitHubCommit Commit { get; set; }

        // Other properties specific to the GitHub branch, if any
    }

    public class GitHubCommit
    {
        [JsonPropertyName("sha")]
        public string Sha { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        // Other properties specific to the GitHub commit, if any
    }
}


