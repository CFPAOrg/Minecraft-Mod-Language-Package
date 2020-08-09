Import-Module ./tools/Spider.psm1

Describe "Spider" {
    InModuleScope Spider {
        # It "Test Join-DownloadUrl" {
        #     $expected = 'https://edge.forgecdn.net/files/2724/357/SkyFactory4-4.0.8.zip'
        #     $actual = Join-DownloadUrl -FileId '2724357' -FileName 'SkyFactory4-4.0.8.zip'
        #     $actual | Should -Be $expected
        # }
        It "Test Get-ModFile" {
            $filePaths = Get-ModFile -ModCount 10 -GameVersion '1.12.2'
        }

        It "Test Get-ModId" {
            Get-ModId -Path $filePaths
        }
    }
}

Remove-Module Spider

