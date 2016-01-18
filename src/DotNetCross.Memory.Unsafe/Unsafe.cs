using System;
using System.Runtime.CompilerServices;

namespace DotNetCross.Memory
{
    // NOTE: Code here only guide the generation of IL, that is edited by hand
    public static class Unsafe
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T Read<T>(void* p)
        {
            return default(T);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Write<T>(void* p, T value)
        { }
    }
}
