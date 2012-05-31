﻿'********************************** 模块头 **********************************'
' 模块名:  PictureBasedWindow.xaml.vb 
' 项目名称:      CSWPFIrregularShapeWindow
' Copyright (c) Microsoft Corporation.
'
' PictureBasedWindow.xaml.vb文件定义了一个PictureBasedWindow类，该方法负责命令绑定和命令与菜
' 单选项或是按钮的关系.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
' EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
' MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***********************************************************************************'


Imports System.Text

''' <summary>
''' PictureBasedWindow.xaml的逻辑交互
''' </summary>
Partial Public Class PictureBasedWindow
    Inherits Window
    Public Sub New()
        InitializeComponent()

        ' 像下面这样添加创建一个对象所需要的代码
        Dim cb As New CommandBinding()
        cb.Command = UICommandBase.CloseCmd
        AddHandler cb.Executed, AddressOf CloseCmdExecuted
        AddHandler cb.CanExecute, AddressOf CloseCmdCanExecute

        Dim minb As New CommandBinding()
        minb.Command = UICommandBase.MinimizeCmd
        AddHandler minb.Executed, AddressOf MinimizeCmdExecuted
        AddHandler minb.CanExecute, AddressOf MinimizeCmdCanExecute

        Dim maxb As New CommandBinding()
        maxb.Command = UICommandBase.MaximizeCmd
        AddHandler maxb.Executed, AddressOf MaximizeCmdExecuted
        AddHandler maxb.CanExecute, AddressOf MaximizeCmdCanExecute

        Dim restoreb As New CommandBinding()
        restoreb.Command = UICommandBase.RestoreCmd
        AddHandler restoreb.Executed, AddressOf RestoreCmdExecuted
        AddHandler restoreb.CanExecute, AddressOf RestoreCmdCanExecute

        ' 为命令对象添加设置以使其可以运行
        Me.CommandBindings.Add(cb)
        Me.CommandBindings.Add(minb)
        Me.CommandBindings.Add(maxb)
        Me.CommandBindings.Add(restoreb)

        Me.mnuInvokeClose.Command = UICommandBase.CloseCmd
        Me.mnuInvokeClose.CommandTarget = btnInvokeClose
        Me.btnInvokeClose.Command = UICommandBase.CloseCmd

        Me.mnuInvokeMaximize.Command = UICommandBase.MaximizeCmd
        Me.mnuInvokeMaximize.CommandTarget = btnInvokeMaximize
        Me.btnInvokeMaximize.Command = UICommandBase.MaximizeCmd

        Me.mnuInvokeMinimize.Command = UICommandBase.MinimizeCmd
        Me.mnuInvokeMinimize.CommandTarget = btnInvokeMinimize
        Me.btnInvokeMinimize.Command = UICommandBase.MinimizeCmd

        Me.mnuInvokeRestore.Command = UICommandBase.RestoreCmd
        Me.mnuInvokeRestore.CommandTarget = btnInvokeRestore
        Me.btnInvokeRestore.Command = UICommandBase.RestoreCmd
    End Sub

    ''' <summary>
    ''' 关闭窗口
    ''' </summary>
    Private Sub CloseCmdExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        Me.Close()
    End Sub

    ''' <summary>
    ''' CanExecuteRoutedEventHandler触发关闭窗体命令
    ''' </summary>
    Private Sub CloseCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = True
    End Sub

    ''' <summary>
    ''' 最小化窗体
    ''' </summary>
    Private Sub MinimizeCmdExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        Me.WindowState = WindowState.Minimized
    End Sub

    ''' <summary>
    ''' CanExecuteRoutedEventHandler触发最小化窗体命令
    ''' </summary>
    Private Sub MinimizeCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = True
    End Sub

    ''' <summary>
    ''' CanExecuteRoutedEventHandler触发最大化窗体命令
    ''' </summary>
    Private Sub MaximizeCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = True
    End Sub

    ''' <summary>
    '''最大化窗口
    ''' </summary>
    Private Sub MaximizeCmdExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        ' 如果canExcute有效，那么那些触发窗体最大化的菜单选项和按钮应该是被选中的
        Dim canExecute As Boolean = AvalonCommandsHelper.CanExecuteCommandSource(btnInvokeRestore)
        If canExecute = True Then
            Me.btnInvokeRestore.Visibility = Visibility.Visible
            Me.btnInvokeMaximize.Visibility = Visibility.Hidden
            Me.mnuInvokeMaximize.IsEnabled = False
            Me.mnuInvokeRestore.IsEnabled = True
        End If
        Me.WindowState = WindowState.Maximized
    End Sub

    ''' <summary>
    ''' CanExecuteRoutedEventHandler触发窗体还原命令
    ''' </summary>
    Private Sub RestoreCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = True
    End Sub

    ''' <summary>
    ''' 还原窗体
    ''' </summary>
    Private Sub RestoreCmdExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)

        ' 如果canExcute有效，那么那些触发窗体还原的菜单选项和按钮应该是被选中的
        Dim canExecute As Boolean = AvalonCommandsHelper.CanExecuteCommandSource(btnInvokeRestore)
        If canExecute = True Then
            Me.btnInvokeRestore.Visibility = Visibility.Hidden
            Me.btnInvokeMaximize.Visibility = Visibility.Visible
            Me.mnuInvokeMaximize.IsEnabled = True
            Me.mnuInvokeRestore.IsEnabled = False
        End If
        Me.WindowState = WindowState.Normal

    End Sub

    ''' <summary>
    ''' 代表拖动形状窗体的事件
    ''' </summary>
    Private Sub Window_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Me.DragMove()
    End Sub
End Class

