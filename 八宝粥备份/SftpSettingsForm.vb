' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Public Class SftpSettingsForm
    Private Sub 添加日志(信息 As String, 颜色 As Color)
        日志窗口.添加日志(信息, 颜色)
    End Sub
    Private Sub ButtonCancle_Click(sender As Object, e As EventArgs) Handles ButtonCancle.Click
        Dim 用户选择 As Integer = MessageBox.Show("是否放弃保存设置并退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            添加日志("[Action]关闭Sftp服务器设置窗口", Color.Black)
            Me.Close()
        End If
    End Sub
    Private Sub ButtonSaveAndExit_Click(sender As Object, e As EventArgs) Handles ButtonSaveAndExit.Click
        Dim 用户选择 As Integer = MessageBox.Show("是否保存设置并退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            保存Sftp配置()
            添加日志("[Success]成功保存Sftp服务器设置", Color.Green)
            日志窗口.日志输出SFTP配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Action]关闭Sftp服务器设置窗口", Color.Black)
            Me.Close()
        End If
    End Sub

    Private Sub SftpSettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        加载Sftp配置()
    End Sub
    ' 窗口激活时更新日志位置
    Private Sub ServiceSettingsForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            日志窗口.更新停靠位置(Me)
        End If
    End Sub
    ' 窗口移动时更新日志位置
    Private Sub SftpSettingsForm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            日志窗口.更新停靠位置(Me)
        End If
    End Sub
    Private Sub 开关控件1_状态变化(新状态 As Boolean) Handles 开关控件1.状态变化
        If 新状态 Then
            Sftp1开关 = True
        Else
            Sftp1开关 = False
        End If
    End Sub
    Private Sub 开关控件2_状态变化(新状态 As Boolean) Handles 开关控件2.状态变化
        If 新状态 Then
            Sftp2开关 = True
        Else
            Sftp2开关 = False
        End If
    End Sub
    Private Sub 开关控件3_状态变化(新状态 As Boolean) Handles 开关控件3.状态变化
        If 新状态 Then
            Sftp3开关 = True
        Else
            Sftp3开关 = False
        End If
    End Sub
    Private Sub 加载Sftp配置()
        读取Sftp配置()
        '加载Sftp1配置
        If Sftp1开关  Then
            开关控件1.切换状态()
        End If
        Sftp1.Text = Sftp1名称
        名称1.Text = Sftp1名称
        地址1.Text = Sftp1地址
        端口1.Text = Sftp1端口
        用户名1.Text = Sftp1用户名
        密码1.Text = Sftp1密码
        '加载Sftp2配置
        If Sftp2开关  Then
            开关控件2.切换状态()
        End If
        Sftp2.Text = Sftp2名称
        名称2.Text = Sftp2名称
        地址2.Text = Sftp2地址
        端口2.Text = Sftp2端口
        用户名2.Text = Sftp2用户名
        密码2.Text = Sftp2密码
        '加载Sftp3配置
        If Sftp3开关  Then
            开关控件3.切换状态()
        End If
        Sftp3.Text = Sftp3名称
        名称3.Text = Sftp3名称
        地址3.Text = Sftp3地址
        端口3.Text = Sftp3端口
        用户名3.Text = Sftp3用户名
        密码3.Text = Sftp3密码
    End Sub
    Private Sub 保存Sftp配置()
        写入Sftp配置(1, Sftp1开关, 名称1.Text, 地址1.Text, 端口1.Text, 用户名1.Text, 密码1.Text)
        写入Sftp配置(2, Sftp2开关, 名称2.Text, 地址2.Text, 端口2.Text, 用户名2.Text, 密码2.Text)
        写入Sftp配置(3, Sftp3开关, 名称3.Text, 地址3.Text, 端口3.Text, 用户名3.Text, 密码3.Text)
    End Sub
End Class