using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DotNetCross.Memory.Tests
{
    // TODO: Rename
    public class Unsafe_Calli_Test
    {
        private readonly ITestOutputHelper output;

        public Unsafe_Calli_Test(ITestOutputHelper output)
        {
            this.output = output;
        }

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
            var result = Unsafe.Calli_Func<Comp, Comp, int>(functionPointer, x, y);
            output.WriteLine(nameof(UNSAFE_CALLI_STATIC_RESULT) + " " + result);
            Assert.Equal(-1, result);
        }

        //[Flags]
        //public enum CallingConventions
        //{
        //    //
        //    // Summary:
        //    //     Specifies the default calling convention as determined by the common language
        //    //     runtime. Use this calling convention for static methods. For instance or virtual
        //    //     methods use HasThis.
        //    Standard = 1,
        //    //
        //    // Summary:
        //    //     Specifies the calling convention for methods with variable arguments.
        //    VarArgs = 2,
        //    //
        //    // Summary:
        //    //     Specifies that either the Standard or the VarArgs calling convention may be used.
        //    Any = 3,
        //    //
        //    // Summary:
        //    //     Specifies an instance or virtual method (not a static method). At run-time, the
        //    //     called method is passed a pointer to the target object as its first argument
        //    //     (the this pointer). The signature stored in metadata does not include the type
        //    //     of this first argument, because the method is known and its owner class can be
        //    //     discovered from metadata.
        //    HasThis = 32,
        //    //
        //    // Summary:
        //    //     Specifies that the signature is a function-pointer signature, representing a
        //    //     call to an instance or virtual method (not a static method). If ExplicitThis
        //    //     is set, HasThis must also be set. The first argument passed to the called method
        //    //     is still a this pointer, but the type of the first argument is now unknown. Therefore,
        //    //     a token that describes the type (or class) of the this pointer is explicitly
        //    //     stored into its metadata signature.
        //    ExplicitThis = 64


        [Fact]
        public unsafe void UNSAFE_CALLI_RESULT()
        {
            IntPtr functionPointer = GetFunctionPointerCompAsIComparable();

            var paramType = typeof(Comp);
            var comparableType = typeof(IComparable<Comp>);
            const string methodName = nameof(IComparable<Comp>.CompareTo);
            var methodInfo = comparableType.GetRuntimeMethod(methodName, new Type[] { paramType });

            // Doesn't work
            //var comparison = (ComparisonComp)Marshal.GetDelegateForFunctionPointer(functionPointer, typeof(ComparisonComp));

            var comparison = (Comparison<Comp>)methodInfo.CreateDelegate(typeof(Comparison<Comp>));
            // Doesn't work
            //var delegateFunctionPointer = comparison.Method.MethodHandle.GetFunctionPointer();


            Assert.NotEqual(IntPtr.Zero, functionPointer);
            //Assert.NotEqual(delegateFunctionPointer, functionPointer);
            var x = new Comp(123);
            var y = new Comp(456);
            //// https://books.google.dk/books?id=g8gJKBedykUC&pg=PA94&lpg=PA94&dq=%22calli+instance%22&source=bl&ots=0s-_AUQ3Q7&sig=ACfU3U3vR0s_EcLkpnufJhNclObbEzqepQ&hl=en&sa=X&ved=2ahUKEwjG55Xo1JrpAhWyyKYKHeoRAhEQ6AEwAHoECAoQAQ#v=onepage&q=%22calli%20instance%22&f=false
            //// https://books.google.dk/books?id=Kl1DVZ8wTqcC&pg=PA176&lpg=PA176&dq=GetFunctionPointer+member+for+calli&source=bl&ots=5d6TFzRKSN&sig=ACfU3U3YEfMLCs6og9GlNKqZQmvvMspDBA&hl=en&sa=X&ved=2ahUKEwjFwZ3r1prpAhXvpIsKHRPPCbUQ6AEwAHoECAoQAQ#v=onepage&q=GetFunctionPointer%20member%20for%20calli&f=false
            //// https://github.com/icsharpcode/ILSpy-tests/blob/master/Mono.Cecil-net45/Resources/il/explicitthis.il
            // .locals init (class MakeDecision d, method instance explicit int32 *(class MakeDecision, int32) m,

            //var result = Unsafe.Calli_Instance_Func<Comp, Comp, int>(functionPointer, x, y);
            var result = comparison(x, y);
            //output.WriteLine(nameof(UNSAFE_CALLI_RESULT) + " " + result);
            Assert.Equal(-1, result);
        }

        [Fact]
        public unsafe void Calli_Instance_Func_Store_Test()
        {
            IntPtr functionPointer = GetFunctionPointerCompAsIComparable();
            var ip = Unsafe.Calli_Instance_Func_Store<Comp, Comp, int>(functionPointer);
            Assert.Equal(functionPointer, ip);
        }

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
