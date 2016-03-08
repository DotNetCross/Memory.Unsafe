# Unsafe
Unsafe methods for working with pointers and unmanaged memory in a completely generic not-type-safe way.

## NuGet
https://www.nuget.org/packages/DotNetCross.Memory.Unsafe.dll/

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
