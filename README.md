# Unsafe
Unsafe methods for working with pointers and unmanaged memory.

```csharp
public static class Unsafe
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe T Read<T>(void* p)
    {
        .maxstack  1
        ldarg.0
        ldobj !!T
        ret
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void Write<T>(void* p, T value)
    {
        .maxstack  2
        ldarg.0
        ldarg.1
        stobj !!T
        ret  
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void* AddressOf<T>(ref T value)
    {
        .maxstack  1
        ldarg.0
        ret
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int SizeOf<T>()
    {
        sizeof !!T
        ret
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void InitBlock(void* dst, byte initValue, uint size)
    {
        .maxstack  3
        ldarg.0
        ldarg.1
        ldarg.2
        initblk
        ret
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void CopyBlock(void* dst, void* src, uint size)
    {
        .maxstack  3
        ldarg.0
        ldarg.1
        ldarg.2
        cpblk
        ret
    }
}
```

## NuGet
https://www.nuget.org/packages/DotNetCross.Memory.Unsafe.dll/
