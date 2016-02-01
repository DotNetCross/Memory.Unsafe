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
        public static unsafe int SizeOf<T>() { return 0; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void* AddressOf<T>(ref T value) { return (void*)0; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueCaster<T> Cast<T>(T value) where T : struct
        {   return new ValueCaster<T>(value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReferenceCaster Cast(object obj)
        {   return new ReferenceCaster(obj); }

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

    public class Pinnable
    {
        public byte Pin;
    }

    public struct ValueCaster<T>
        where T : struct
    {
        public readonly T Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueCaster(T value)
        {
            Value = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TTo To<TTo>() where TTo : struct
        { return default(TTo); } // Overridden in IL
    }

    public struct ReferenceCaster
    {
        public readonly object Object;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReferenceCaster(object obj)
        {
            Object = obj;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TTo To<TTo>() where TTo : class
        { return default(TTo); } // Overridden in IL

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Pinnable ToPinnable()
        { return To<Pinnable>(); }
    }
}
