
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern System.Runtime
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 4:0:21:0
}
.assembly extern System.Runtime.InteropServices
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

  .custom instance void [System.Runtime]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 19 44 6F 74 4E 65 74 43 72 6F 73 73 2E 4D   // ...DotNetCross.M
                                                                                                    65 6D 6F 72 79 2E 55 6E 73 61 66 65 00 00 )       // emory.Unsafe..
  .custom instance void [System.Runtime]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 3E 55 6E 73 61 66 65 20 6D 65 74 68 6F 64   // ..>Unsafe method
                                                                                                          73 20 66 6F 72 20 77 6F 72 6B 69 6E 67 20 77 69   // s for working wi
                                                                                                          74 68 20 75 6E 6D 61 6E 61 67 65 64 20 6D 65 6D   // th unmanaged mem
                                                                                                          6F 72 79 20 61 6E 64 20 70 6F 69 6E 74 65 72 73   // ory and pointers
                                                                                                          2E 00 00 )                                        // ...
  .custom instance void [System.Runtime]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [System.Runtime]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 0B 44 6F 74 4E 65 74 43 72 6F 73 73 00 00 ) // ...DotNetCross..
  .custom instance void [System.Runtime]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 19 44 6F 74 4E 65 74 43 72 6F 73 73 2E 4D   // ...DotNetCross.M
                                                                                                      65 6D 6F 72 79 2E 55 6E 73 61 66 65 00 00 )       // emory.Unsafe..
  .custom instance void [System.Runtime]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 1D 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                        44 6F 74 4E 65 74 43 72 6F 73 73 20 32 30 31 36   // DotNetCross 2016
                                                                                                        00 00 ) 
  .custom instance void [System.Runtime]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [System.Runtime]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [System.Runtime.InteropServices]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 33 33 35 66 66 65 63 35 2D 31 39 38 32   // ..$335ffec5-1982
                                                                                                                        2D 34 62 32 33 2D 61 33 64 62 2D 37 31 65 61 63   // -4b23-a3db-71eac
                                                                                                                        63 66 65 31 38 65 36 00 00 )                      // cfe18e6..
  .custom instance void [System.Runtime]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 30 2E 31 2E 31 2E 30 00 00 )             // ...0.1.1.0..
  .hash algorithm 0x00008004
  .ver 0:1:1:0
}
.module DotNetCross.Memory.Unsafe.dll
// MVID: {9400C8FF-C5EB-43CB-9EFC-FA0A6CF40856}
.imagebase 0x10000000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00930000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed beforefieldinit DotNetCross.Memory.Unsafe
       extends [System.Runtime]System.Object
{
  .method public hidebysig static !!T  Read<T>(void* p) cil managed aggressiveinlining
  {
    // Can't be expressed in C#, thus in IL:
    .maxstack  1
    ldarg.0
    ldobj !!T
    ret
  } // end of method Unsafe::Read

  .method public hidebysig static void  Write<T>(void* p,
                                                 !!T 'value') cil managed aggressiveinlining
  {
    // Can't be expressed in C#, thus in IL:
    .maxstack  2
    ldarg.0
    ldarg.1
    stobj !!T
    ret  
    } // end of method Unsafe::Write

} // end of class DotNetCross.Memory.Unsafe


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file .\il\DotNetCross.Memory.Unsafe.res
