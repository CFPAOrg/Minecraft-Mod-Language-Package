$configPath = Join-Path $PWD -ChildPath "config.json";
$config = Get-Content $configPath -Raw|ConvertFrom-Json;


dotnet run --configuration Release --project ./src/Spider/Spider.csproj




git config credential.helper store
git config --global user.email "bot@cfpa.com"
git config --global user.name "CfpaBot"
$credentialPath = "~/.git-credentials";
$credential = "https://summpot:$($env:token)@github.com"
if ([System.IO.File]::Exists($credentialPath)) {
    Add-Content $credentialPath $credential -Force -InformationAction Ignore;
}else{
    New-Item -Path $credentialPath -ItemType File -Force -InformationAction Ignore;
    Add-Content $credentialPath $credential -Force -InformationAction Ignore;
}
git add .
git commit -m "Automatically updated."
git push origin $config.game_version