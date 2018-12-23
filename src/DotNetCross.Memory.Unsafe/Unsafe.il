
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern System.Runtime
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 4:0:0:0
}
.assembly DotNetCross.Memory.Unsafe
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                   63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [System.Runtime]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .custom instance void [System.Runtime]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 19 44 6F 74 4E 65 74 43 72 6F 73 73 2E 4D   // ...DotNetCross.M
                                                                                                    65 6D 6F 72 79 2E 55 6E 73 61 66 65 00 00 )       // emory.Unsafe..
  .custom instance void [System.Runtime]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 3E 55 6E 73 61 66 65 20 6D 65 74 68 6F 64   // ..>Unsafe method
                                                                                                          73 20 66 6F 72 20 77 6F 72 6B 69 6E 67 20 77 69   // s for working wi
                                                                                                          74 68 20 70 6F 69 6E 74 65 72 73 20 61 6E 64 20   // th pointers and 
                                                                                                          75 6E 6D 61 6E 61 67 65 64 20 6D 65 6D 6F 72 79   // unmanaged memory
                                                                                                          2E 00 00 )                                        // ...
  .custom instance void [System.Runtime]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 0B 44 6F 74 4E 65 74 43 72 6F 73 73 00 00 ) // ...DotNetCross..
  .custom instance void [System.Runtime]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 19 44 6F 74 4E 65 74 43 72 6F 73 73 2E 4D   // ...DotNetCross.M
                                                                                                      65 6D 6F 72 79 2E 55 6E 73 61 66 65 00 00 )       // emory.Unsafe..
  .custom instance void [System.Runtime]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 1D 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                        44 6F 74 4E 65 74 43 72 6F 73 73 20 32 30 31 36   // DotNetCross 2016
                                                                                                        00 00 ) 
  .custom instance void [System.Runtime]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 30 2E 32 2E 32 2E 30 00 00 )             // ...0.2.3.0..
  .hash algorithm 0x00008004
  .ver 0:3:0:0
}
.module DotNetCross.Memory.Unsafe.dll
// MVID: {B87A9616-91DD-4DC6-A4FC-3217D05362CD}
.imagebase 0x10000000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x011E0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed beforefieldinit DotNetCross.Memory.Unsafe
       extends [System.Runtime]System.Object
{
  .method public hidebysig static !!T& AsRefAtByteOffset<T>(
      object obj, native int offset) cil managed aggressiveinlining
  {
      .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
      .maxstack 2
      .locals ([0] uint8& addr)
      ldarg.0     // load the object
      stloc.0     // convert the object pointer to a byref
      ldloc.0     // load the object pointer as a byref
      ldarg.1     // load the offset
      add         // add the offset
      //ldobj !!T   // load a T value from the computed address
      // Roundtrip via a local to avoid type mismatch on return that the JIT inliner chokes on.
      //stloc.0
      //ldloc.0
      ret
  }

  .method public hidebysig static native int ByteOffset<T>(object origin, !!T& target) cil managed aggressiveinlining
  {
      .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
      .maxstack 2
      .locals ([0] uint8& addr)
      ldarg.1
      ldarg.0
      stloc.0     // convert the object pointer to a byref
      ldloc.0     // load the object pointer as a byref
      sub
      ret
  } // end of method Unsafe::ByteOffset

  .method public hidebysig static void  Write<T>(void* destination,
                                                 !!T& 'value') cil managed aggressiveinlining
  {
      .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
      .maxstack  2
      ldarg.0
      ldarg.1
      ldobj !!T
      stobj !!T
      ret  
  } // end of method Unsafe::Write


  .method public hidebysig static !!T Read<T>(void* source) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        ldarg.0
        ldobj !!T
        ret
  } // end of method Unsafe::Read

  .method public hidebysig static !!T ReadUnaligned<T>(void* source) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        ldarg.0        
        unaligned. 0x1
        ldobj !!T
        ret
  } // end of method Unsafe::ReadUnaligned
  
  .method public hidebysig static !!T ReadUnaligned<T>(uint8& source) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        ldarg.0        
        unaligned. 0x1
        ldobj !!T
        ret
  } // end of method Unsafe::ReadUnaligned

  .method public hidebysig static void Write<T>(void* destination,
                                                 !!T 'value') cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        stobj !!T
        ret
  } // end of method Unsafe::Write

  .method public hidebysig static void WriteUnaligned<T>(void* destination,
                                                 !!T 'value') cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        unaligned. 0x01
        stobj !!T
        ret
  } // end of method Unsafe::WriteUnaligned

  .method public hidebysig static void WriteUnaligned<T>(uint8& destination,
                                                 !!T 'value') cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1        
        unaligned. 0x01
        stobj !!T
        ret
  } // end of method Unsafe::WriteUnaligned

  .method public hidebysig static void Copy<T>(void* destination,
                                                !!T& source) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        ldobj !!T
        stobj !!T
        ret
  } // end of method Unsafe::Copy

  .method public hidebysig static void Copy<T>(!!T& destination,
                                                void* source) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        ldobj !!T
        stobj !!T
        ret
  } // end of method Unsafe::Copy

  .method public hidebysig static void* AsPointer<T>(!!T& 'value') cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        ldarg.0
        conv.u
        ret
  } // end of method Unsafe::AsPointer

  .method public hidebysig static int32 SizeOf<T>() cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        sizeof !!T
        ret
  } // end of method Unsafe::SizeOf

  .method public hidebysig static void CopyBlock(void* destination, void* source, uint32 byteCount) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        ldarg.2
        cpblk
        ret
  } // end of method Unsafe::CopyBlock

  .method public hidebysig static void CopyBlock(uint8& destination, uint8& source, uint32 byteCount) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        ldarg.2
        cpblk
        ret
  } // end of method Unsafe::CopyBlock

  .method public hidebysig static void CopyBlockUnaligned(void* destination, void* source, uint32 byteCount) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        ldarg.2
        unaligned. 0x1
        cpblk
        ret
  } // end of method Unsafe::CopyBlockUnaligned

  .method public hidebysig static void CopyBlockUnaligned(uint8& destination, uint8& source, uint32 byteCount) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        ldarg.2
        unaligned. 0x1
        cpblk
        ret
  } // end of method Unsafe::CopyBlockUnaligned

  .method public hidebysig static void InitBlock(void* startAddress, uint8 'value', uint32 byteCount) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        ldarg.2
        initblk
        ret
  } // end of method Unsafe::InitBlock

  .method public hidebysig static void InitBlock(uint8& startAddress, uint8 'value', uint32 byteCount) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        ldarg.2
        initblk
        ret
  } // end of method Unsafe::InitBlock

  .method public hidebysig static void InitBlockUnaligned(void* startAddress, uint8 'value', uint32 byteCount) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        ldarg.2
        unaligned. 0x1
        initblk
        ret
  } // end of method Unsafe::InitBlockUnaligned

  .method public hidebysig static void InitBlockUnaligned(uint8& startAddress, uint8 'value', uint32 byteCount) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        ldarg.2
        unaligned. 0x1
        initblk
        ret
  } // end of method Unsafe::InitBlockUnaligned

  .method public hidebysig static !!T As<class T>(object o) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        ldarg.0
        ret
  } // end of method Unsafe::As

  .method public hidebysig static !!T& AsRef<T>(void* source) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
// For .NET Core the roundtrip via a local is no longer needed see:
// https://github.com/dotnet/coreclr/issues/13341
// and
// https://github.com/dotnet/coreclr/pull/11218
#ifdef netcoreapp
        .maxstack 1
        ldarg.0
        ret
#else
        .locals (int32&)
        .maxstack 1
        ldarg.0
        // Roundtrip via a local to avoid type mismatch on return that the JIT inliner chokes on.
        stloc.0
        ldloc.0
        ret
#endif
  } // end of method Unsafe::AsRef

  .method public hidebysig static !!T& AsRef<T>(!!T& source) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .param [1]
#ifdef netcoreapp
        .custom instance void [CORE_ASSEMBLY]System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor() = ( 01 00 00 00 )
#else
        .custom instance void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor() = ( 01 00 00 00 )
#endif
        .maxstack 1
        ldarg.0
        ret
  } // end of method Unsafe::AsRef

  .method public hidebysig static !!TTo& As<TFrom, TTo>(!!TFrom& source) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        ldarg.0
        ret
  } // end of method Unsafe::As

  .method public hidebysig static !!T& Unbox<valuetype .ctor ([System.Runtime]System.ValueType) T> (object 'box') cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 1
        ldarg.0
        unbox !!T
        ret
  } // end of method Unsafe::Unbox

  .method public hidebysig static !!T& Add<T>(!!T& source, int32 elementOffset) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        sizeof !!T
        conv.i
        mul
        add
        ret
  } // end of method Unsafe::Add

  .method public hidebysig static void* Add<T>(void* source, int32 elementOffset) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        sizeof !!T
        conv.i
        mul
        add
        ret
  } // end of method Unsafe::Add

  .method public hidebysig static !!T& Add<T>(!!T& source, native int elementOffset) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        sizeof !!T
        mul
        add
        ret
  } // end of method Unsafe::Add

  .method public hidebysig static !!T& AddByteOffset<T>(!!T& source, native int byteOffset) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        add
        ret
  } // end of method Unsafe::AddByteOffset

  .method public hidebysig static !!T& Subtract<T>(!!T& source, int32 elementOffset) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        sizeof !!T
        conv.i
        mul
        sub
        ret
  } // end of method Unsafe::Subtract

  .method public hidebysig static void* Subtract<T>(void* source, int32 elementOffset) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        sizeof !!T
        conv.i
        mul
        sub
        ret
  } // end of method Unsafe::Subtract

  .method public hidebysig static !!T& Subtract<T>(!!T& source, native int elementOffset) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 3
        ldarg.0
        ldarg.1
        sizeof !!T
        mul
        sub
        ret
  } // end of method Unsafe::Subtract

  .method public hidebysig static !!T& SubtractByteOffset<T>(!!T& source, native int byteOffset) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        sub
        ret
  } // end of method Unsafe::SubtractByteOffset

  .method public hidebysig static native int ByteOffset<T>(!!T& origin, !!T& target) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.1
        ldarg.0
        sub
        ret
  } // end of method Unsafe::ByteOffset

  .method public hidebysig static bool AreSame<T>(!!T& left, !!T& right) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        ceq
        ret 
  } // end of method Unsafe::AreSame

  .method public hidebysig static bool IsAddressGreaterThan<T>(!!T& left, !!T& right) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        cgt.un
        ret 
  } // end of method Unsafe::IsAddressGreaterThan

  .method public hidebysig static bool IsAddressLessThan<T>(!!T& left, !!T& right) cil managed aggressiveinlining
  {
        .custom instance void System.Runtime.Versioning.NonVersionableAttribute::.ctor() = ( 01 00 00 00 )
        .maxstack 2
        ldarg.0
        ldarg.1
        clt.un
        ret 
  } // end of method Unsafe::IsAddressLessThan

} // end of class DotNetCross.Memory.Unsafe

.class public auto ansi sealed beforefieldinit DotNetCross.Memory.Pinnable
       extends [System.Runtime]System.Object
{
  .field public uint8 Pin
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    .maxstack  1
    ldarg.0
    call       instance void [System.Runtime]System.Object::.ctor()
    ret
  } // end of method Pinnable::.ctor

} // end of class DotNetCross.Memory.Pinnable

.class private auto ansi sealed beforefieldinit System.Runtime.Versioning.NonVersionableAttribute
       extends [System.Runtime]System.Attribute
{
  .custom instance void [System.Runtime]System.AttributeUsageAttribute::.ctor(valuetype [System.Runtime]System.AttributeTargets) = ( 01 00 6C 00 00 00 02 00 54 02 0D 41 6C 6C 6F 77   // ..l.....T..Allow
                                                                                                                                     4D 75 6C 74 69 70 6C 65 00 54 02 09 49 6E 68 65   // Multiple.T..Inhe
                                                                                                                                     72 69 74 65 64 00 )                               // rited.
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
        .maxstack 1
        ldarg.0
        call instance void [System.Runtime]System.Attribute::.ctor()
        ret
  } // end of method NonVersionableAttribute::.ctor

} // end of class System.Runtime.Versioning.NonVersionableAttribute

.class private auto ansi sealed beforefieldinit Microsoft.CodeAnalysis.EmbeddedAttribute
       extends [System.Runtime]System.Attribute
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void Microsoft.CodeAnalysis.EmbeddedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    .maxstack  1
    ldarg.0
    call       instance void [System.Runtime]System.Attribute::.ctor()
    nop
    ret
  } // end of method EmbeddedAttribute::.ctor

} // end of class Microsoft.CodeAnalysis.EmbeddedAttribute

.class private auto ansi sealed beforefieldinit System.Runtime.CompilerServices.IsReadOnlyAttribute
       extends [System.Runtime]System.Attribute
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void Microsoft.CodeAnalysis.EmbeddedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    .maxstack  1
    ldarg.0
    call       instance void [System.Runtime]System.Attribute::.ctor()
    nop
    ret
  } // end of method IsReadOnlyAttribute::.ctor

} // end of class System.Runtime.CompilerServices.IsReadOnlyAttribute

// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file .\il\DotNetCross.Memory.Unsafe.res
