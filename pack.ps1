$sourceNugetExe = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
# We download into packages so it is not checked-in since this is ignored in git
$packagesPath = ".\packages\"
$targetNugetExe = $packagesPath + "nuget.exe"
# Download if it does not exist
If (!(Test-Path $targetNugetExe))
{
   If (!(Test-Path $packagesPath))
   {
     mkdir $packagesPath
   }
   "Downloading nuget to: " + $targetNugetExe
   Invoke-WebRequest $sourceNugetExe -OutFile $targetNugetExe
}
xcopy /Y .\src\DotNetCross.Memory.Unsafe\bin\Release\net45\*.dll .\src-pack\lib\net45\
xcopy /Y .\src\DotNetCross.Memory.Unsafe\bin\Release\netstandard1.0\*.dll .\src-pack\lib\netstandard1.0\
xcopy /Y .\src\DotNetCross.Memory.Unsafe\bin\Release\netstandard2.0\*.dll .\src-pack\lib\netstandard2.0\
xcopy /Y .\src\DotNetCross.Memory.Unsafe\bin\Release\netcoreapp2.0\*.dll .\src-pack\lib\netcoreapp2.0\
iex ($targetNugetExe + " pack .\src-pack\DotNetCross.Memory.Unsafe.nuspec")