# Memory.Unsafe
Unsafe methods for working with pointers and unmanaged memory in a completely generic, not-type-safe way.

## Gitter
[![Join the chat at https://gitter.im/DotNetCross/Memory.Unsafe](https://badges.gitter.im/DotNetCross/Memory.Unsafe.svg)](https://gitter.im/DotNetCross/Memory.Unsafe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## NuGet
The current NuGet package name is `DotNetCross.Memory.Unsafe`. It can be found here:

https://www.nuget.org/packages/DotNetCross.Memory.Unsafe

### OBSOLETE NuGet Package Name and URL
Unfortunately, I made the mistake of including `.dll` in the package name when I first created the `nuspec`-file. This was later fixed (version >= 0.2.2.0), but also means people who have been referring to the package via `DotNetCross.Memory.Unsafe.dll` may not know this was changed to `DotNetCross.Memory.Unsafe`. Unfortunately, there was no way to redirect or rename the old package so users could be informed of this change.


## API
API surface currently, no doubt this will change until a stable API has been determined.
```csharp
public static class Unsafe
{
    public static unsafe T Read<T>(void* p)
    public static unsafe void Write<T>(void* p, T value)
    public static unsafe void Write<T>(void* p, ref T value)
    public static unsafe int SizeOf<T>()
    public static T As<T>(object obj)
    public static unsafe void* AsPointer<T>(ref T value)
    public static unsafe void InitBlock(void* dst, byte initValue, uint size)
    public static unsafe void CopyBlock(void* dst, void* src, uint size)
}
public class Pinnable
{
    public byte Pin;
}
```

## Examples
### Read
```csharp
var ptr = stackalloc int[1];
*ptr = 42;
var v = Unsafe.Read<int>(ptr);
Assert.Equal(42, v);
```

### Write
```csharp
var ptr = stackalloc int[1];
*ptr = 17;
Unsafe.Write<int>(ptr, 42);
Assert.Equal(42, ptr[0]);
```

### SizeOf
```csharp
var size = Unsafe.SizeOf<T>();
```

### As + AsPointer
```csharp
var array = new int[2];
array[0] = 42;
array[1] = 17;
fixed (void* pinPtr = &Unsafe.As<Pinnable>(array).Pin)
{
    void* firstPtr = Unsafe.AsPointer(ref array[0]);

    Assert.Equal(42, Unsafe.Read<int>(firstPtr));
    Assert.Equal(17, Unsafe.Read<int>((byte*)firstPtr + sizeof(int)));
}
```

### CopyBlock
```csharp
var src = stackalloc byte[2];
src[0] = src[1] = 0x12;
var dest = stackalloc short[1];
Unsafe.CopyBlock(dest, src, 2);
Assert.Equal(0x1212, dest[0]);
```

### InitBlock
```csharp
var ptr = stackalloc byte[10];
Unsafe.InitBlock(ptr, 123, 10);
for (int i = 0; i < 10; i++)
    Assert.Equal(123, ptr[i]);
```