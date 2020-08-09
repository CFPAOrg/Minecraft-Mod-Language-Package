
function Start-Spider {
    param ()
    Get-ModFile -ModCount 10 -GameVersion '1.12.2'
}

function Get-ModId {
    param (
        [string[]]$Path
    )
    $jobs = @()
    $modIds = @()
    foreach ($aPath in $Path) {
        $job = Start-Job -ScriptBlock {
            [System.Diagnostics.Process]$process = [System.Diagnostics.Process]::Start("java", "-jar ./tools/cfr-0.150.jar $aPath")
            $output = $process.StandardOutput
            $reader = [io.streamreader]::new($output)
            $regex = [regex]::new('(?<=modid.*?=").*?(?=")')
            [bool]$isMatch
            while (-not $reader.EndOfStream) {
                $line = $reader.ReadLine()
                if ($regex.IsMatch($line)) {
                    $match = $regex.Match($line)
                    $modIds+=$match.Value
                    $isMatch = $true
                    break
                }
            }
            if (-not $isMacth) {
                $modIds+=""
            }
        }
        $jobs=+$job
        Receive-Job $jobs -Wait
        return $modIds
    }
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
    $jobs = $downloadUrls | ForEach-Object { 
        $oldPath = [io.path]::GetTempFileName()
        $newPath = [io.path]::ChangeExtension($oldPath, [io.path]::GetExtension($_))
        [io.file]::Move($oldPath, $newPath)
        $paths += $newPath
        Invoke-WebRequest -Uri $_ -OutFile $newPath &
    }
    Receive-Job $jobs -Wait
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
