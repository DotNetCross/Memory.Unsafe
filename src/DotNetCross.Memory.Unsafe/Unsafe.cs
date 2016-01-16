using System;
using System.Runtime.CompilerServices;

namespace DotNetCross.Memory.Unsafe
{
    // NOTE: Code here only guide the generation of IL, that is edited by hand
    public static class Unsafe
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T Read<T>(void* p)
            where T : struct
        {
            return default(T);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write<T>(void* p, T value)
            where T : struct
        { }
    }
}
