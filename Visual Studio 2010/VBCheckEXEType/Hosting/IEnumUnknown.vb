﻿'*************************** 模块头 ******************************'
' 模块名:  IEnumUnknown.vb
' 项目名:	    VBCheckEXEType
' 版权 (c) Microsoft Corporation.
' 
' 枚举有未知接口的对象. 它可以用来枚举
' 包含多个对象的组件里的对象. 
' 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security

Namespace Hosting
    <ComImport()>
    <SecurityCritical()>
    <Guid("00000100-0000-0000-C000-000000000046")>
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface IEnumUnknown
        <PreserveSig()>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Function [Next](<[In](), MarshalAs(UnmanagedType.U4)> ByVal elementArrayLength As Integer,
                        <Out(), MarshalAs(UnmanagedType.LPArray, ArraySubType:=UnmanagedType.IUnknown, SizeParamIndex:=0)> ByVal elementArray() As Object,
                        <Out(), MarshalAs(UnmanagedType.U4)> ByRef fetchedElementCount As Integer) As Integer

        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Function Skip(<[In](), MarshalAs(UnmanagedType.U4)> ByVal count As Integer) As Integer

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub Reset()

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub Clone(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef enumerator As IEnumUnknown)

    End Interface
End Namespace