using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotNetCross.Memory.Tests
{
    // TODO: Rename
    public class Unsafe_Calli_Test
    {
        // public delegate TResult Func<[NullableAttribute(2)] in T1, [NullableAttribute(2)] in T2, [NullableAttribute(2)] in T3, [NullableAttribute(2)] out TResult>(T1 arg1, T2 arg2, T3 arg3);

        public class Comp
            : IComparable<Comp>
        {
            public readonly int Value;

            public Comp(int value) =>
                Value = value;

            public int CompareTo(Comp other) =>
                Value.CompareTo(other.Value);

            public static int Compare(Comp x, Comp y) => x.CompareTo(y);
        }

        // Marshal.GetDelegateForFunctionPointer does not work for generic delegates
        delegate int ComparisonComp(Comp x, Comp y);



        [Fact]
        public unsafe void ClassMethodToPointer()
        {
            IntPtr functionPointer = GetFunctionPointerComp();

            Assert.NotEqual(IntPtr.Zero, functionPointer);
        }

        private static unsafe IntPtr GetFunctionPointerComp()
        {
            var paramType = typeof(Comp);
            var comparableType = typeof(Comp);
            const string methodName = nameof(IComparable<Comp>.CompareTo);
            var methodInfo = comparableType.GetRuntimeMethod(methodName, new Type[] { paramType });

            var runtimeHandle = methodInfo.MethodHandle;
            var functionPointer = runtimeHandle.GetFunctionPointer();
            return functionPointer;
        }

        [Fact]
        public unsafe void UNSAFE_CALLI_STATIC_RESULT()
        {
            var paramType = typeof(Comp);
            var type = typeof(Comp);
            const string methodName = nameof(Comp.Compare);
            var methodInfo = type.GetRuntimeMethod(methodName, new Type[] { paramType, paramType });
            var runtimeHandle = methodInfo.MethodHandle;
            var functionPointer = runtimeHandle.GetFunctionPointer();

            Assert.NotEqual(IntPtr.Zero, functionPointer);
            var x = new Comp(123);
            var y = new Comp(456);
            var result = Unsafe.Calli_Managed_Func<Comp, Comp, int>(functionPointer, x, y);
            Assert.Equal(-1, result);
        }

        //[Fact]
        //public unsafe void UNSAFE_CALLI_RESULT()
        //{
        //    IntPtr functionPointer = GetFunctionPointerCompAsIComparable();

        //    Assert.NotEqual(IntPtr.Zero, functionPointer);
        //    var x = new Comp(123);
        //    var y = new Comp(456);
        //    var result = Unsafe.Calli_Managed_Func<Comp, Comp, int>(functionPointer, x, y);
        //    Assert.Equal(-1, result);
        //}

        private static unsafe IntPtr GetFunctionPointerCompAsIComparable()
        {
            var paramType = typeof(Comp);
            var comparableType = typeof(IComparable<Comp>);
            const string methodName = nameof(IComparable<Comp>.CompareTo);
            var methodInfo = comparableType.GetRuntimeMethod(methodName, new Type[] { paramType });

            var runtimeHandle = methodInfo.MethodHandle;
            var functionPointer = runtimeHandle.GetFunctionPointer();
            return functionPointer;
        }

        //[Fact]
        //public unsafe void DelegateToPointer()
        //{
        //    var compare = DelegateDoctor.GetComparableCompareToAsOpenObjectDelegate<Comp>();

        //    Assert.Equal(-1, compare(new Comp(-1), new Comp(1)));
        //    Assert.Equal(0, compare(new Comp(1), new Comp(1)));
        //    Assert.Equal(1, compare(new Comp(1), new Comp(-1)));

        //    var methodInfo = compare.Method;
        //    var runtimeHandle = methodInfo.MethodHandle;
        //    var functionPointer = runtimeHandle.GetFunctionPointer();

        //    Assert.NotEqual(IntPtr.Zero, functionPointer);

        //    var compareFromPtr = Marshal.GetDelegateForFunctionPointer<ComparisonComp>(functionPointer);
        //    // Below fails yielding incorrect results for some reason
        //    //Assert.Equal(-1, compareFromPtr(new Comp(-1), new Comp(1)));
        //    //Assert.Equal(0, compareFromPtr(new Comp(1), new Comp(1)));
        //    //Assert.Equal(1, compareFromPtr(new Comp(1), new Comp(-1)));
        //}
    }
}
