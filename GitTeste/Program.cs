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
            //var nomeBranch = args[1];

            var hashCommits = string.Empty;

            using (var repositorio = new Repository(caminhoRepositorio))
            {
                var branchInformado = repositorio.Branches.FirstOrDefault(branch => branch.Name == "Teste");

                foreach (var commit in branchInformado.Commits)
                {
                    if (commit != branchInformado.TrackingDetails.CommonAncestor)
                    {
                        hashCommits += commit.Sha + "\r\n";
                    }
                }
            }

            Console.WriteLine(hashCommits);
        }
    }
}
