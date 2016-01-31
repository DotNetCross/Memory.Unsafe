using System.Runtime.CompilerServices;

namespace DotNetCross.Memory
{
    // NOTE: Code here only to guide the generation of IL, that is edited by hand
    public static class Unsafe
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T Read<T>(void* p) { return default(T); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write<T>(void* p, T value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void* AddressOf<T>(ref T value) { return (void*)0; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int SizeOf<T>() { return 0; }

        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/system.reflection.emit.opcodes.initblk.aspx
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void InitBlock(void* dst, byte initValue, uint size) { }

        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/system.reflection.emit.opcodes.cpblk.aspx
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void CopyBlock(void* dst, void* src, uint size) { }
    }
}
