﻿'********************************** 模块头 ******************************'
' 模块名:  ICustomDoc.vb
' 项目名:  VBCustomIEContextMenu
' 版权 (c) Microsoft Corporation.
' 
' 接口 ICustomDoc 使得主机能设置 MSHTML IDocHostUIHandler　接口．
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

Imports System.Runtime.InteropServices

Namespace NativeMethods
    <ComImport()>
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    <GuidAttribute("3050f3f0-98b5-11cf-bb82-00aa00bdce0b")>
    Public Interface ICustomDoc
        <PreserveSig()>
        Sub SetUIHandler(ByVal pUIHandler As IDocHostUIHandler)
    End Interface
End Namespace


