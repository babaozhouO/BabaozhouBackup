﻿'Copyright 2025 八宝粥(Email:1749861851@qq.com)

'Licensed under the Apache License, Version 2.0 (the "License");
'you may Not use this file except In compliance With the License.
'You may obtain a copy Of the License at

'    http://www.apache.org/licenses/LICENSE-2.0

'Unless required by applicable law Or agreed To In writing, software
'distributed under the License Is distributed On an "AS IS" BASIS,
'WITHOUT WARRANTIES Or CONDITIONS Of ANY KIND, either express Or implied.
'See the License For the specific language governing permissions And
'limitations under the License.
Public Class 日志窗口
    Private 日志处理器实例 As 日志处理功能
    Private Sub 日志窗口_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeComponent()
        日志处理器实例 = New 日志处理功能
        日志处理器实例.绑定文本框(Me.LogsRichTextBox)
    End Sub
    Public Sub 添加日志(信息 As String, 颜色 As Color)
        日志处理器实例.添加日志(信息, 颜色)
    End Sub
    Public Sub 日志输出软件信息()
        日志处理器实例.日志输出软件信息()
    End Sub
    Public Sub 日志输出主程序配置()
        日志处理器实例.日志输出主程序配置()
    End Sub
    Public Sub 日志输出MC服务端配置()
        日志处理器实例.日志输出MC服务端配置()
    End Sub
    Public Sub 日志输出SFTP配置()
        日志处理器实例.日志输出SFTP配置()
    End Sub
    Public Sub 日志输出7zip配置()
        日志处理器实例.日志输出7zip配置()
    End Sub
    Private 当前目标窗口 As Form
    Private ReadOnly 主窗口 As MainForm
    ' 智能停靠方法
    Public Sub 更新停靠位置(目标窗口 As Form)
        If 日志窗口是否更新位置 Then
            当前目标窗口 = 目标窗口
        Else
            当前目标窗口 = MainForm
            目标窗口 = MainForm
        End If
        If 日志窗口隐藏状态 Then Return
        Me.Visible = 目标窗口.Visible
        If TypeOf 目标窗口 Is MainForm Then
            ' 主窗口模式：固定位置
            Me.Location = 目标窗口.PointToScreen(New Point(30, 30))
            Me.Size = New Size(650, 410)
        Else
            ' 子窗口模式：左侧停靠
            Dim 目标位置 As New Point(目标窗口.Left - Me.Width, 目标窗口.Top + (目标窗口.Height - Me.Height) \ 2)
            Me.Location = 目标位置
        End If
    End Sub
    '实时跟随目标窗口
    Private Sub 位置同步Timer_Tick(sender As Object, e As EventArgs) Handles 位置同步Timer.Tick
        If 日志窗口隐藏状态 Then Return
        If 当前目标窗口 IsNot Nothing AndAlso Not 当前目标窗口.IsDisposed Then
            Me.Visible = 当前目标窗口.Visible
            If TypeOf 当前目标窗口 Is MainForm Then
                Me.Location = 当前目标窗口.PointToScreen(New Point(30, 30))
            Else
                Dim 新位置 As New Point(当前目标窗口.Left - Me.Width, 当前目标窗口.Top + (当前目标窗口.Height - Me.Height) \ 2)
                Me.Location = 新位置
            End If
        End If
    End Sub
End Class