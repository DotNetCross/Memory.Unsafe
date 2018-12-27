using System;
using System.Runtime.CompilerServices;

namespace DotNetCross.Memory
{
    // corefx links:
    // https://github.com/dotnet/corefx/blob/master/src/System.Runtime.CompilerServices.Unsafe/ref/System.Runtime.CompilerServices.Unsafe.cs
    // https://github.com/dotnet/corefx/blob/master/src/System.Runtime.CompilerServices.Unsafe/src/System.Runtime.CompilerServices.Unsafe.il
    // Joe Duffy Slice.NET:
    // https://github.com/joeduffy/slice.net/blob/master/src/PtrUtils.il

    // NOTE: Code here only to guide the generation of IL, that is edited by hand
    public static class Unsafe
    {
        // DotNetCross.Memory.Unsafe specific methods 
        // not found in corefx Unsafe currently
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static ref T RefAtByteOffset<T>(object source, System.IntPtr byteoffset) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static System.IntPtr ByteOffset<T>(object origin, ref T target) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void Write<T>(void* destination, ref T value) { }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T AddByteOffset<T>(ref T source, System.IntPtr byteOffset) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T Add<T>(ref T source, int elementOffset) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void* Add<T>(void* source, int elementOffset) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T Add<T>(ref T source, System.IntPtr elementOffset) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreSame<T>(ref T left, ref T right) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void* AsPointer<T>(ref T value) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static ref T AsRef<T>(void* source) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T AsRef<T>(in T source) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T As<T>(object o) where T : class { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TTo As<TFrom, TTo>(ref TFrom source) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static System.IntPtr ByteOffset<T>(ref T origin, ref T target) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyBlock(ref byte destination, ref byte source, uint byteCount) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void CopyBlock(void* destination, void* source, uint byteCount) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyBlockUnaligned(ref byte destination, ref byte source, uint byteCount) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void CopyBlockUnaligned(void* destination, void* source, uint byteCount) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void Copy<T>(void* destination, ref T source) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void Copy<T>(ref T destination, void* source) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InitBlock(ref byte startAddress, byte value, uint byteCount) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void InitBlock(void* startAddress, byte value, uint byteCount) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InitBlockUnaligned(ref byte startAddress, byte value, uint byteCount) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void InitBlockUnaligned(void* startAddress, byte value, uint byteCount) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAddressGreaterThan<T>(ref T left, ref T right) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAddressLessThan<T>(ref T left, ref T right) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static T Read<T>(void* source) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static T ReadUnaligned<T>(void* source) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ReadUnaligned<T>(ref byte source) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeOf<T>() { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T SubtractByteOffset<T>(ref T source, System.IntPtr byteOffset) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T Subtract<T>(ref T source, int elementOffset) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void* Subtract<T>(void* source, int elementOffset) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T Subtract<T>(ref T source, System.IntPtr elementOffset) { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T Unbox<T>(object box) where T : struct { throw null; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void Write<T>(void* destination, T value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteUnaligned<T>(void* destination, T value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUnaligned<T>(ref byte destination, T value) { }
    }

    public sealed class Pinnable
    {
        public byte Pin;
    }
}
