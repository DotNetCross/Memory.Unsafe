dotnet test src/DotNetCross.Memory.Unsafe.Tests/DotNetCross.Memory.Unsafe.Tests.csproj -c Debug -v q /nologo /property:Platform=X64 /nowarn:NETSDK1138
dotnet test src/DotNetCross.Memory.Unsafe.Tests/DotNetCross.Memory.Unsafe.Tests.csproj -c Release -v q /nologo /property:Platform=X64 /nowarn:NETSDK1138
# Using 32-bit dotnet to test x86 see https://github.com/xunit/xunit/issues/1123
& "C:\Program Files (x86)\dotnet\dotnet.exe" test src/DotNetCross.Memory.Unsafe.Tests/DotNetCross.Memory.Unsafe.Tests.csproj -c Debug -v q /nologo /property:Platform=X86 /nowarn:NETSDK1138
& "C:\Program Files (x86)\dotnet\dotnet.exe" test src/DotNetCross.Memory.Unsafe.Tests/DotNetCross.Memory.Unsafe.Tests.csproj -c Release -v q /nologo /property:Platform=X86 /nowarn:NETSDK1138