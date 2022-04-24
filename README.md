# Play.Common

Common libraries uses by Play Economy services.

## Create and publish package

```powershell
$version="1.0.6"
$owner="icodedotnetmicroservices"
dotnet pack src\Play.Common\ --configuration Release -p:PackageVersion=$version -p:RepositoryUrl=https://github.com/$owner/Play.Common -o ..\packages
```
