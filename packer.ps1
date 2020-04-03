Add-Type -AssemblyName .\Properties.dll
$projectPath = Join-Path $PWD -ChildPath "project";
$outputPath = Join-Path $PWD -ChildPath "output";
$zipArchivePath = Join-Path $PWD -ChildPath "Minecraft-Mod-Language-Modpack.zip";

Remove-Item $outputPath -Recurse -Force -ErrorAction Ignore;
Remove-Item $zipArchivePath -Force -ErrorAction Ignore;
$files = Get-ChildItem $projectPath -Recurse -File | Where-Object { $_.BaseName -ne "en_us" };
foreach ($fi in $files) {
    $dest = (Join-Path $outputPath -ChildPath ([IO.Path]::GetRelativePath($projectPath, $fi.FullName)));
    New-Item -Path ([io.Path]::GetDirectoryName($dest)) -ItemType Directory -InformationAction Ignore -ErrorAction Ignore;
    if ($fi.Extension -eq ".lang") {
        $isEnhanced = $false;
        $fi | Get-Content | ForEach-Object {
            if ([string]::IsNullOrWhiteSpace($_)) {
                continue;
            }
            if ($_.StartsWith("#PARSE_ESCAPES")) {
                $isEnhanced=$true;
                return;
            }
        }
        
        if ($isEnhanced -eq $true) {
            $reader = [io.file]::OpenRead($fi.FullName);
            $p = [Properties]::new($reader);
            New-Item -ItemType File -Value ($p.ToString()) -Path $dest -InformationAction Ignore -Force;
            $reader.Dispose();
        }
        else {
            $l = [Properties]::new();
            $fi | Get-Content | ForEach-Object {
                if ((-not [string]::IsNullOrEmpty($_))-and( $_[0] -ne "#")) {
                    $a = $_ -split "=", 2;
                    $l[$a[0]] = $a[1];
                }
            }
            New-Item -ItemType File -Value ($l.ToString()) -Path $dest -InformationAction Ignore -Force;
        }
    }
    else {
        Copy-Item -Path $fi.FullName  -Destination (Join-Path $outputPath -ChildPath ([IO.Path]::GetRelativePath($projectPath, $fi.FullName)));
    }
}
Compress-Archive "$outputPath/*" $zipArchivePath -CompressionLevel Optimal;