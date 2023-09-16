$timberbornDir = ".\Packages\Timberborn"
$timberbornDlls = Get-ChildItem $timberbornDir -Filter "Timberborn.*.dll" -Recurse

# Create a backup of the original dlls

$timberbornDlls | ForEach-Object {
    $backupPath = $_.FullName + ".bak"
    Copy-Item $_.FullName $backupPath
}

# Publicize the dlls

assembly-publicizer --overwrite --publicize-compiler-generated $($timberbornDlls | ForEach-Object { $_.FullName } )

# Restore the original dlls

#$timberbornDlls | ForEach-Object {
#    $backupPath = $_.FullName + ".bak"
#    Copy-Item $backupPath $_.FullName
#    Remove-Item $backupPath
#}
