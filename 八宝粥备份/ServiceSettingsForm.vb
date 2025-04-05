' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Public Class ServiceSettingsForm
    Private Sub 添加日志(信息 As String, 颜色 As Color) ' 添加日志
        MainForm.日志窗口.添加日志(信息, 颜色)
    End Sub
    Private Sub Buttondone_Click(sender As Object, e As EventArgs) Handles Buttondone.Click
        Dim 用户选择 As Integer = MessageBox.Show("确认退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            添加日志("[Action]关闭服务设置窗口", Color.Black)
            Me.Close()
        End If
    End Sub
    Private Sub SetupButton_Click(sender As Object, e As EventArgs) Handles SetupButton.Click
        MessageBox.Show($"尚未实现", "等等吧", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub ButtonUninstall_Click(sender As Object, e As EventArgs) Handles ButtonUninstall.Click
        MessageBox.Show($"尚未实现", "等等吧", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ' 窗口激活时更新日志位置
    Private Sub ServiceSettingsForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            DirectCast(Owner, MainForm).日志窗口.更新停靠位置(Me)
        End If
    End Sub
    ' 窗口移动时更新日志位置
    Private Sub ServiceSettingsForm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            DirectCast(Owner, MainForm).日志窗口.更新停靠位置(Me)
        End If
    End Sub
End Class