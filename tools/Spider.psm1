
function Start-Spider {
    param ()
    $paths = Get-ModFile -ModCount 100 -GameVersion '1.12.2'
    Get-ModId -Path $paths | Out-Host
}

function Get-LangFile {
    param (
        [string[]]$Path,
        [string]$language
    )
    $regex = [regex]::new("assets\\[^\\]+\\lang")
    $tempPath = [io.path]::GetTempPath()
    $langFiles = @()
    foreach($aPath in $Path) {
        $destPath = [io.path]::Combine($tempPath, [System.Random]::new().Next()) # Generate a temp random PATH (not file), may be further optimized
        $index = $destPath.Length
        Expand-Archive -Path $aPath -DestinationPath $destPath
        $resultFiles = Get-ChildItem "$destPath*" -Include "$aPath.lang" -Recurse
        if($resultFiles.Length -eq 0) {
            Write-Host "Detected one mod without any language file." # May find a way to add modid in the string......
            $langFiles += ""
            continue
        }
        $match = $false
        foreach($resultFile in $resultFiles) {
            if($regex.Ismatch($resultFile.DirectoryName.SubString($index))) {
                $match = $true
                $langFiles += $resultFile.FullName
                break
            }
        }
        if(-not $match) {
            Write-Host "Detected one mod with irregular language file position."
            $langFiles += ""
        }
    }
    return $langFiles
}

function Get-ModId {
    param (
        [string[]]$Path
    )
    $map = New-Object hashtable
    $Path | ForEach-Object -Parallel {
        $process = [System.Diagnostics.Process]::new()
        $process.StartInfo.UseShellExecute = $false;  
        $process.StartInfo.RedirectStandardOutput = $true;
        $process.StartInfo.FileName = "java"
        $process.StartInfo.Arguments = "-jar ./tools/cfr-0.150.jar $_"
        $process.Start() | Out-Null
        [bool]$isMatch = $false
        
        $regex = [regex]::new('(?<=modid.*?=").*?(?=")')
        while (-not $process.StandardOutput.EndOfStream) {
            $line = $process.StandardOutput.ReadLine()
            if ($regex.IsMatch($line)) {
                $match = $regex.Match($line)
                $map.Add($_,$match.Value)
                $isMatch = $true
                break
            }
        }
        if (-not $isMacth) {
            $map.Add($_,$null)
        }
    } -ThrottleLimit 20
    return $map
}
function Get-ModFile {
    param (
        [int]$ModCount,
        [string]$GameVersion
    )
    $apiResponse = Invoke-CurseForgeApiQuery -CategoryId 0 -GameId 432 -Index 0 -PageSize $ModCount -GameVersion $GameVersion -SectionId 6 -Sort 1
    $downloadUrls = @()
    foreach ($mod in $apiResponse) {
        $file = $mod.gameVersionLatestFiles | Where-Object -Property gameVersion -EQ $GameVersion | Select-Object -First 1
        $downloadUrl = Join-DownloadUrl -FileId $file.projectFileId -FileName $file.projectFileName
        $downloadUrls += $downloadUrl
    }
    $paths = @()
    $downloadUrls | ForEach-Object -Parallel { 
        $oldPath = [io.path]::GetTempFileName()
        $newPath = [io.path]::ChangeExtension($oldPath, [io.path]::GetExtension($_))
        [io.file]::Move($oldPath, $newPath)
        $paths += $newPath
        Invoke-WebRequest -Uri $_ -OutFile $newPath
    } -ThrottleLimit 20
    return $paths
}

function Join-DownloadUrl {
    param (
        [string]$FileId,
        [string]$FileName
    )
    $firstPart = $FileId[0..3] | Join-String
    $secondPart = $FileId[4..6] | Join-String
    return "https://edge.forgecdn.net/files/$firstPart/$secondPart/$FileName"
}

function Invoke-CurseForgeApiQuery {
    param (
        [string]$CategoryId,
        [string]$GameId,
        [string]$Index,
        [string]$PageSize,
        [string]$GameVersion,
        [string]$SearchFilter,
        [string]$SectionId,
        [string]$Sort
    )
    [string]$url = "https://addons-ecs.forgesvc.net/api/v2/addon/search?"
    if ($CategoryId) {
        $url += "categoryId=$CategoryId"
        $url += "&"
    }
    if ($GameId) {
        $url += "gameId=$GameId"
        $url += "&"
    }
    if ($Index) {
        $url += "index=$Index"
        $url += "&"
    }
    if ($PageSize) {
        $url += "pageSize=$PageSize"
        $url += "&"
    }
    if ($GameVersion) {
        $url += "gameVersion=$GameVersion"
        $url += "&"
    }
    if ($SearchFilter) {
        $url += "searchFilter=$SearchFilter"
        $url += "&"
    }
    if ($SectionId) {
        $url += "sectionId=$SectionId"
        $url += "&"
    }
    if ($Sort) {
        $url += "sort=$Sort"
        $url += "&"
    }
    $result = Invoke-RestMethod -Uri $url
    return $result
}
