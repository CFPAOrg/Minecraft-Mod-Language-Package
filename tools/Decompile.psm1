# TODO
function DecompileJar {
    param (
        [string]$file
    )
    java -jar cfr.jar $file
}