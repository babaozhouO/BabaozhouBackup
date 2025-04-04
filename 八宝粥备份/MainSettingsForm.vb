﻿' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Public Class MainSettingsForm
    Public Sub 添加日志(信息 As String, 颜色 As Color)
        MainForm.日志窗口.添加日志(信息, 颜色)
    End Sub
    Private Sub ButtonCancle_Click(sender As Object, e As EventArgs) Handles ButtonCancle.Click
        Dim 用户选择 As Integer = MessageBox.Show("是否放弃保存设置并退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            添加日志("[Action]关闭主程序设置窗口", Color.Black)
            Me.Close()
        End If
    End Sub
    Private Sub ButtonSaveAndExit_Click(sender As Object, e As EventArgs) Handles ButtonSaveAndExit.Click
        Dim 要写入的运行时间配置 As String
        Dim 用户选择 As Integer = MessageBox.Show("是否保存设置并退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            要写入的运行时间配置 = TextBoxhour.Text + ":" + TextBoxminute.Text + ":" + TextBoxsecond.Text
            写入主程序配置(要写入的运行时间配置)
            添加日志("[Action]关闭主程序设置窗口", Color.Black)
            Me.Close()
        End If
    End Sub
    Private Sub MainSettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        读取主程序配置()
        TextBoxhour.Text = 运行时间.Split(":")(0)
        TextBoxminute.Text = 运行时间.Split(":")(1)
        TextBoxsecond.Text = 运行时间.Split(":")(2)
    End Sub
    ' 窗口激活时更新日志位置
    Private Sub MainSettingsForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            DirectCast(Owner, MainForm).日志窗口.更新停靠位置(Me)
        End If
    End Sub
    ' 窗口移动时更新日志位置
    Private Sub MainSettingsForm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            DirectCast(Owner, MainForm).日志窗口.更新停靠位置(Me)
        End If
    End Sub
End Class