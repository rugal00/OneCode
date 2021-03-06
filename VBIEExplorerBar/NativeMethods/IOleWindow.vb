﻿'*************************** Module Header ******************************'
' 模块名称:  IOleWindow.vb
' 项目:	    VBIEExplorerBar
' Copyright (c) Microsoft Corporation.
' 
' IOleWindow接口提供了一个方法。该方法允许一个应用程序获得各种参与就地激活、
' 进入和推出上下文敏感的帮助模式的windows的句柄。
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
    <Guid("00000114-0000-0000-C000-000000000046")>
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface IOleWindow
        Sub GetWindow(<System.Runtime.InteropServices.Out()> ByRef phwnd As IntPtr)

        Sub ContextSensitiveHelp(<[In]()> ByVal fEnterMode As Boolean)

    End Interface
End Namespace
