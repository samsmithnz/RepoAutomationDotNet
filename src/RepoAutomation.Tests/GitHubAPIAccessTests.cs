using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoAutomation.APIAccess;
using RepoAutomation.Models;
using RepoAutomation.Tests.Helpers;
using System.Threading.Tasks;

namespace RepoAutomation.Tests;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
[TestClass]
[TestCategory("IntegrationTests")]
public class GitHubAPIAccessTests : BaseAPIAccessTests
{
    [TestMethod]
    public async Task GetRepoGetTest()
    {
        //Arrange
        string owner = "samsmithnz";
        string repoName = "RepoAutomation"; //inception!!

        //Act
        Repo? repo = await GitHubAPIAccess.GetRepo(base.GitHubId, base.GitHubSecret, owner, repoName);

        //Assert
        Assert.IsNotNull(repo);
        if (repo != null)
        {
            Assert.AreEqual(owner, repo.owner?.login);
            Assert.AreEqual(repoName, repo.name);
            Assert.AreEqual(owner + "/" + repoName, repo.full_name);
            Assert.AreEqual("true", repo.allow_auto_merge);
            Assert.AreEqual("true", repo.delete_branch_on_merge);
            Assert.AreEqual("true", repo.allow_merge_commit);
            Assert.AreEqual("false", repo.allow_rebase_merge);
            Assert.AreEqual("true", repo.allow_squash_merge);
            Assert.AreEqual("public", repo.visibility);
            Assert.AreEqual("main", repo.default_branch);
            Assert.IsNotNull(repo.RawJSON);
            Assert.IsNotNull(repo.id);
        }
    }

    [TestMethod]
    public async Task GetRepoThatDoesNotExistGetTest()
    {
        //Arrange
        string owner = "samsmithnz";
        string repoName = "RepoAutomation2"; //Doesn't exist

        //Act
        Repo? repo = await GitHubAPIAccess.GetRepo(base.GitHubId, base.GitHubSecret, owner, repoName);

        //Assert
        Assert.IsNull(repo);
    }



    [TestMethod]
    public async Task DeleteRepoThatDoesNotExistGetTest()
    {
        //Arrange
        string owner = "samsmithnz";
        string repoName = "RepoAutomationToDelete"; //Doesn't exist

        //Act
        bool result = await GitHubAPIAccess.DeleteRepo(base.GitHubId, base.GitHubSecret, owner, repoName);

        //Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public async Task CreateAndDeleteRepoTest()
    {
        //Arrange
        string owner = "samsmithnz";
        string repoName = "NewRepoTest";

        //Act I: Creation
        await GitHubAPIAccess.CreateRepo(base.GitHubId, base.GitHubSecret, repoName);
        Repo? repo = await GitHubAPIAccess.GetRepo(base.GitHubId, base.GitHubSecret, owner, repoName);

        //Assert
        Assert.IsNotNull(repo);
        if (repo != null)
        {
            Assert.AreEqual(repoName, repo.name);
        }

        //Act II: End of days
        await GitHubAPIAccess.DeleteRepo(base.GitHubId, base.GitHubSecret, owner, repoName);
        repo = await GitHubAPIAccess.GetRepo(base.GitHubId, base.GitHubSecret, owner, repoName);

        Assert.IsNull(repo);
    }
}