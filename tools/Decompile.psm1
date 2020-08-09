# TODO
function DecompileJar {
    param (
        [string]$File
    )
    foreach ($FilePath in $File) {
        java -jar "./tools/cfr-0.150.jar" $FilePath
    }
}