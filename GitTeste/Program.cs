using LibGit2Sharp;
using System;
using System.Linq;

namespace GitTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            var caminhoRepositorio = args[0];
            var repositorio = new Repository(caminhoRepositorio);

            var hashCommit = args[1];
            var commitInicial = repositorio.Commits.FirstOrDefault(commit => commit.Sha == hashCommit);

            var branchMergeRequest = repositorio.Branches.FirstOrDefault(branch => branch.Commits.Contains(commitInicial));

            var hashCommits = string.Empty;

            foreach (var commit in branchMergeRequest.Commits)
            {
                hashCommits += commit.Sha + "\n";
            }

            Console.WriteLine(hashCommits);
        }
    }
}
