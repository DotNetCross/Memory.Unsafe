.\tools\ilasm.exe /dll /optimize .\il\DotNetCross.Memory.Unsafe.il /OUTPUT=.\build\lib\DotNetCross.Memory.Unsafe.dll
xcopy /Y .\build\lib\DotNetCross.Memory.Unsafe.dll .\build\lib\dotnet\DotNetCross.Memory.Unsafe.dll
xcopy /Y .\build\lib\DotNetCross.Memory.Unsafe.dll .\build\lib\netcore\DotNetCross.Memory.Unsafe.dll
xcopy /Y .\build\lib\DotNetCross.Memory.Unsafe.dll .\build\lib\netcore45\DotNetCross.Memory.Unsafe.dll
xcopy /Y .\build\lib\DotNetCross.Memory.Unsafe.dll .\build\lib\dnxcore\DotNetCross.Memory.Unsafe.dll
xcopy /Y .\build\lib\DotNetCross.Memory.Unsafe.dll .\build\lib\net\DotNetCross.Memory.Unsafe.dll
xcopy /Y .\build\lib\DotNetCross.Memory.Unsafe.dll .\build\lib\net11\DotNetCross.Memory.Unsafe.dll
xcopy /Y .\build\lib\DotNetCross.Memory.Unsafe.dll .\build\lib\portable-net40+win8+sl4+wp7\DotNetCross.Memory.Unsafe.dll