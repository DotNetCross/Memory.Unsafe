if not exist ".\build\Libs_AnyCPU_Debug\" mkdir .\build\Libs_AnyCPU_Debug\
if not exist ".\build\Libs_AnyCPU_Release\" mkdir .\build\Libs_AnyCPU_Release\
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\Ilasm.exe" /nologo /dll /debug .\src\DotNetCross.Memory.Unsafe\Unsafe.il /OUTPUT=.\build\Libs_AnyCPU_Debug\Unsafe.dll
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\Ilasm.exe" /nologo /dll /optimize .\src\DotNetCross.Memory.Unsafe\Unsafe.il /OUTPUT=.\build\Libs_AnyCPU_Release\Unsafe.dll
REM .\tools\ilasm.exe /dll /optimize .\src\DotNetCross.Memory.Unsafe\Unsafe.il /OUTPUT=.\build\Libs_AnyCPU_Debug\Unsafe.dll
REM "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Ilasm.exe" /nologo /dll /debug  .\src\DotNetCross.Memory.Unsafe\Unsafe.il /OUTPUT=.\build\Libs_AnyCPU_Debug\Unsafe.dll
REM "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Ilasm.exe" /NOLOGO /DLL /DEBUG /OUTPUT:"./build/Libs_AnyCPU_Debug/DotNetCross.Memory.Unsafe.dll"   ".\src\DotNetCross.Memory.Unsafe\Unsafe.il"
REM "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Ilasm.exe" /NOLOGO /DLL /DEBUG  /OUTPUT:"obj\Debug\DotNetCross.Memory.Unsafe.dll"   "E:\oss\Unsafe\src\DotNetCross.Memory.Unsafe\Unsafe.il"
