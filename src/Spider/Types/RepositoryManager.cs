using System;
using System.Diagnostics;
using LibGit2Sharp;
using Serilog;

namespace Spider.Types
{
    internal class RepositoryManager
    {
        public static void PushToGithub()
        {
            var sw = Stopwatch.StartNew();
            var token = Environment.GetEnvironmentVariable("token");
            if (string.IsNullOrEmpty(token)) return;
            using var repo = new Repository(Configuration.RepositoryPath);
            var author = new Signature("CFPABot", "bot@cfpa.team", DateTime.Now);
            Commands.Stage(repo, "*");
            var commit = repo.Commit("Automatically updated.", author, author);
            Log.Information($"创建了一个commit:{commit.Sha}");
            var remote = repo.Network.Remotes["origin"];
            var options = new PushOptions
            {
                CredentialsProvider = (url, usernameFromUrl, types) =>
                    new UsernamePasswordCredentials {Username = token, Password = string.Empty}
            };
            repo.Network.Push(remote, "HEAD", @"refs/heads/1.12.2", options);
            sw.Stop();
            Log.Information($"成功Push到远程仓库：{remote.PushUrl},耗时{sw.ElapsedMilliseconds}ms");
        }
    }
}