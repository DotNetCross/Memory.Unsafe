
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern System.Runtime
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 4:0:21:0
}
.assembly DotNetCross.Memory.Unsafe
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                   63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [System.Runtime]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module DotNetCross.Memory.Unsafe.dll
// MVID: {043AA01B-59A4-48BD-959B-70458482A171}
.imagebase 0x10000000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00FA0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed beforefieldinit DotNetCross.Memory.Unsafe.Unsafe
       extends [System.Runtime]System.Object
{
  .method public hidebysig static !!T  Read<valuetype .ctor ([System.Runtime]System.ValueType) T>(void* p) cil managed aggressiveinlining
  {
    // Can't be expressed in C#, thus in IL:
    .maxstack 1
    ldarg.0
    ldobj !!T
    ret
  } // end of method Unsafe::Read

  .method public hidebysig static void  Write<valuetype .ctor ([System.Runtime]System.ValueType) T>(void* p,
                                                                                                    !!T 'value') cil managed aggressiveinlining
  {
    // Can't be expressed in C#, thus in IL:
    .maxstack 2
    ldarg.0
    ldarg.1
    stobj !!T
    ret  
    } // end of method Unsafe::Write

} // end of class DotNetCross.Memory.Unsafe.Unsafe


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file .\il\DotNetCross.Memory.Unsafe.res
