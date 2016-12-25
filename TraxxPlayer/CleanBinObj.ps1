$directories = dir -Directory
foreach($dir in  $directories)
{
    Remove-Item -Path "$($dir)\Bin" -Force -Confirm:$false
    Remove-Item -Path "$($dir)\Obj" -Force -Confirm:$false
}