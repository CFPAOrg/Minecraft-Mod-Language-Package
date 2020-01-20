using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using Octokit;
using Commit = LibGit2Sharp.Commit;
using Credentials = LibGit2Sharp.Credentials;
using Repository = LibGit2Sharp.Repository;
using Signature = LibGit2Sharp.Signature;

namespace Spider.Types
{
    static class RepositoryManager
    {
        public static void PushToGitHub()
        {
            var token = Environment.GetEnvironmentVariable("token");
            if (!string.IsNullOrEmpty(token))
            {
                Console.WriteLine("开始push到github");
                var repo = new Repository(Settings.WorkPath);
                Commands.Stage(repo, "*");
                Signature author = new Signature("CfpaBot", "bot@cfpa.team", DateTime.Now);
                Signature committer = author;
                Commit commit = repo.Commit("Automatically updated all en_us.lang", author, committer);
                Console.WriteLine($"创建了一个commit:{commit.Sha}");
                Remote remote = repo.Network.Remotes["origin"];
                var options = new PushOptions
                {
                    CredentialsProvider = (_url, _user, _cred) =>
                        new UsernamePasswordCredentials { Username = token, Password = string.Empty }
                };
                repo.Network.Push(remote, "HEAD",@"refs/heads/1.12.2", options);
                Console.WriteLine("已成功向GitHub推送所有en_us.lang");
            }
        }
    }
}
