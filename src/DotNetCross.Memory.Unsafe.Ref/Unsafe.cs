using System;
using System.Runtime.CompilerServices;

namespace DotNetCross.Memory
{
    // NOTE: Code here only to guide the generation of IL, that is edited by hand
    public static class Unsafe
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T Read<T>(void* p) { return default(T); } // Overridden in IL

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write<T>(void* p, T value) { } // Overridden in IL

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write<T>(void* p, ref T value) { } // Overridden in IL

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int SizeOf<T>() { return 0; } // Overridden in IL

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T As<T>(object obj) where T : class
        { return default(T); } // Overridden in IL

        // Instead of AddressOf
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void* AsPointer<T>(ref T value) { return (void*)0; } // Overridden in IL

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ref TTo AsRef<TFrom, TTo>(ref TFrom value) { throw new NotImplementedException(); } // Overridden in IL

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void InitBlock(void* dst, byte initValue, uint size) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void CopyBlock(void* dst, void* src, uint size) { }
    }

    public sealed class Pinnable
    {
        public byte Pin;
    }
}
