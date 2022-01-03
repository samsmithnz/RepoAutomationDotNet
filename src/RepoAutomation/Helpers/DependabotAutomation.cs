﻿using GitHubActionsDotNet.Helpers;
using RepoAutomation.APIAccess;
using RepoAutomation.Models;
using System.Text;

namespace RepoAutomation.Helpers
{
    public static class DependabotAutomation
    {
        public static string SetupDependabotFile(string workingDirectory, string owner)
        {
            StringBuilder log = new();

            log.Append("Scanning repo for dependabot dependencies");
            List<string> files = FileSearch.GetFilesForDirectory(workingDirectory);

            log.Append("Generating dependabot configuration");
            string yaml = GitHubActionsDotNet.Serialization.DependabotSerialization.Serialize(workingDirectory, files,
                "daily",
                "06:00",
                "America/New_York",
                new() { owner },
                10,
                true);

            log.Append("Writing dependabot configuration to file: " + workingDirectory + "\\.github\\dependabot.yml");
            File.WriteAllText(workingDirectory + "\\.github\\dependabot.yml", yaml);

            return log.ToString();
        }

        //public async static Task<GitHubFile[]?> CheckForDependabotFile(string? id, string? secret,
        //    string owner, string repository, string path)
        //{
        //    GitHubFile[]? searchResult = await GitHubAPIAccess.GetFiles(id, secret,
        //        owner, repository, path);
        //    return searchResult;
        //}

    }
}
