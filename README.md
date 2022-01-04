# Repo Automation

[![CI/ CD](https://github.com/samsmithnz/RepoAutomation/actions/workflows/dotnet.yml/badge.svg)](https://github.com/samsmithnz/RepoAutomation/actions/workflows/dotnet.yml)

.NET code to create and configure a repo with C#. 
- Enables repo "auto-merge" open
- Enables repo "Delete head branch on merge" option 
- Enables repo visibility to be set
- Creates the initial project.
    - Clone the project to a folder (`Target folder`) https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository
    - Create src folder
    - Creates .NET test project (`test project name` and `test project type`) https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new
    - Creates .NET console\library\webapi\web app project (`project name` and `project type`) https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new
    - Creates .NET solution (`solution name`) https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-sln
- Creates the GitHub action to build/test/publish the .NET projects added above
    - Adds an action status badge to the readme file
- Creates the dependabot configuration
- Push all of the changes back to the repository/GitHub
- [ ] (TODO) Sets up branch policies on default branch (require a pull request and successful build action)

## Usage

```Shell
RepoAutomation [-o|--owner <GITHUB-OWNER/ACCOUNT>] 
               [-r|--repo <REPOSITORY-NAME>] 
               [-d|--directory <WORKING-DIRECTORY>] 
               [-v|--visibility <REPO-VISIBILITY>]
               [-p|--projectTypes <.NET-COMMA-DELIMITED-PROJECTS]
```
<!-- TODO: RepoAutomation [-l|--license <repo license>] [-p|--patToken <GitHub Pat Token>]  [-bp|--branchpolicy <default branch policy>] -->

Requires a [PAT token](https://github.com/settings/tokens) to be setup, with `repo`, `workflow`, and `delete_repo` (DANGER! DANGER, WILL ROBINSON!!) permissions

## Example

Using default settings to create a new repository "RepoAutomationTest", with a .NET 6 class library and unit tests project:
```
RepoAutomation --owner samsmithnz --repo RepoAutomationTest --directory c:\users\sam\source\repos --visibility public --projectTypes classlib,mstest
```

![image](https://user-images.githubusercontent.com/8389039/147719122-13fad701-8305-4a85-bb93-de07f90e8c1c.png)

Here is the result:
![image](https://user-images.githubusercontent.com/8389039/147702917-076d9502-4979-40f3-9b90-44664e495afe.png)

[![CI/CD](https://github.com/samsmithnz/RepoAutomation/actions/workflows/workflow.yml/badge.svg)](https://github.com/samsmithnz/RepoAutomation/actions/workflows/workflow.yml)
