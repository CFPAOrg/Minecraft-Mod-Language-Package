$projectPath = Join-Path $PWD -ChildPath "project";
$outputPath = Join-Path $PWD -ChildPath "output";
$zipArchivePath = Join-Path $PWD -ChildPath "Minecraft-Mod-Language-Package.zip";

Remove-Item $outputPath -Recurse -Force -ErrorAction Ignore;
Remove-Item $zipArchivePath -Force -ErrorAction Ignore;
Get-ChildItem $projectPath -Exclude "en_us.lang" -Recurse|
ForEach-Object {
    Copy-Item -Path $_  -Destination (Join-Path $outputPath -ChildPath ([IO.Path]::GetRelativePath($projectPath,$_)));
}
Compress-Archive $outputPath $zipArchivePath -CompressionLevel Optimal;
Write-Host ("::set-output name=timestamp::{0}" -F (Get-Date -Format "yyyyMMddhhmmss" ));