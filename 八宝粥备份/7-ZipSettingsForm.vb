' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Public Class SevenZipSettingsForm
    Public Sub 添加日志(信息 As String, 颜色 As Color)
        MainForm.日志窗口.添加日志(信息, 颜色)
    End Sub
    Private Sub ButtonCancle_Click(sender As Object, e As EventArgs) Handles ButtonCancle.Click
        Dim 用户选择 As Integer = MessageBox.Show("是否放弃保存设置并退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            添加日志("[Action]关闭7-Zip设置窗口", Color.Black)
            Me.Close()
        End If
    End Sub
    Private Sub ButtonSaveAndExit_Click(sender As Object, e As EventArgs) Handles ButtonSaveAndExit.Click
        Dim 用户选择 As Integer = MessageBox.Show("是否保存设置并退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            写入7zip配置(选择压缩格式.Text, 选择压缩级别.Text)
            添加日志("[Success]成功保存7-Zip设置", Color.Green)
            MainForm.日志窗口.日志输出7zip配置()
            添加日志("--------------------------------------------------------------", Color.Black)
            添加日志("[Action]关闭7-Zip设置窗口", Color.Black)
            Me.Close()
        End If
    End Sub
    Private Sub SevenZipSettingsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        MainForm.日志窗口.更新停靠位置(Me)
        读取7zip配置()
        选择压缩格式.Text = 压缩格式
        选择压缩级别.Text = 压缩级别
    End Sub
    ' 窗口激活时更新日志位置
    Private Sub SevenZipSettingsForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            DirectCast(Owner, MainForm).日志窗口.更新停靠位置(Me)
        End If
    End Sub
    ' 窗口移动时更新日志位置
    Private Sub SevenZipSettingsForm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            DirectCast(Owner, MainForm).日志窗口.更新停靠位置(Me)
        End If
    End Sub
End Class