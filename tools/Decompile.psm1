# TODO
function DecompileJar {
    param (
        [string]$File
    )
    java -jar cfr.jar $File
}