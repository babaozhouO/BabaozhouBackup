' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Public Class RCONSettingsForm
    Public Sub 添加日志(信息 As String, 颜色 As Color)
        MainForm.日志窗口.添加日志(信息, 颜色)
    End Sub
    Private Sub ButtonCancle_Click(sender As Object, e As EventArgs) Handles ButtonCancle.Click
        Dim 用户选择 As Integer = MessageBox.Show("是否放弃保存设置并退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            添加日志("[Action]关闭RCON服务器设置窗口", Color.Black)
            Me.Close()
        End If
    End Sub
    Private Sub ButtonSaveAndExit_Click(sender As Object, e As EventArgs) Handles ButtonSaveAndExit.Click
        Dim 用户选择 As Integer = MessageBox.Show("是否保存设置并退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            保存RCON配置()
            添加日志("[Success]成功保存RCON服务器设置", Color.Green)
            添加日志("[Action]关闭RCON服务器设置窗口", Color.Black)
            MainForm.日志窗口.日志输出RCON配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            Me.Close()
        End If
    End Sub
    Private Sub 开关控件1_状态变化(新状态 As Boolean) Handles 开关控件1.状态变化
        If 新状态 Then
            RCON1开关 = "ON"
        Else
            RCON1开关 = "OFF"
        End If
    End Sub
    Private Sub 开关控件2_状态变化(新状态 As Boolean) Handles 开关控件2.状态变化
        If 新状态 Then
            RCON2开关 = "ON"
        Else
            RCON2开关 = "OFF"
        End If
    End Sub
    Private Sub 开关控件3_状态变化(新状态 As Boolean) Handles 开关控件3.状态变化
        If 新状态 Then
            RCON3开关 = "ON"
        Else
            RCON3开关 = "OFF"
        End If
    End Sub
    Private Sub 开关控件4_状态变化(新状态 As Boolean) Handles 开关控件4.状态变化
        If 新状态 Then
            RCON4开关 = "ON"
        Else
            RCON4开关 = "OFF"
        End If
    End Sub
    Private Sub 开关控件5_状态变化(新状态 As Boolean) Handles 开关控件5.状态变化
        If 新状态 Then
            RCON5开关 = "ON"
        Else
            RCON5开关 = "OFF"
        End If
    End Sub
    Private Sub 开关控件6_状态变化(新状态 As Boolean) Handles 开关控件6.状态变化
        If 新状态 Then
            RCON6开关 = "ON"
        Else
            RCON6开关 = "OFF"
        End If
    End Sub
    Private Sub 开关控件7_状态变化(新状态 As Boolean) Handles 开关控件7.状态变化
        If 新状态 Then
            RCON7开关 = "ON"
        Else
            RCON7开关 = "OFF"
        End If
    End Sub
    Private Sub 开关控件8_状态变化(新状态 As Boolean) Handles 开关控件8.状态变化
        If 新状态 Then
            RCON8开关 = "ON"
        Else
            RCON8开关 = "OFF"
        End If
    End Sub
    Private Sub 开关控件9_状态变化(新状态 As Boolean) Handles 开关控件9.状态变化
        If 新状态 Then
            RCON9开关 = "ON"
        Else
            RCON9开关 = "OFF"
        End If
    End Sub
    Private Sub 开关控件10_状态变化(新状态 As Boolean) Handles 开关控件10.状态变化
        If 新状态 Then
            RCON10开关 = "ON"
        Else
            RCON10开关 = "OFF"
        End If
    End Sub
    Private Sub RCONSettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        加载RCON配置()
    End Sub
    ' 窗口激活时更新日志位置
    Private Sub RCONSettingsForm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            DirectCast(Owner, MainForm).日志窗口.更新停靠位置(Me)
        End If
    End Sub
    ' 窗口激活时更新日志位置
    Private Sub RCONSettingsForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            DirectCast(Owner, MainForm).日志窗口.更新停靠位置(Me)
        End If
    End Sub
    Private Sub 加载RCON配置()
        读取RCON配置()
        '加载RCON1配置
        If RCON1开关 = "ON" Then
            开关控件1.切换状态()
        End If
        RCON1.Text = RCON1名称
        名称1.Text = RCON1名称
        地址1.Text = RCON1地址
        端口1.Text = RCON1端口
        密码1.Text = RCON1密码
        '加载RCON2配置
        If RCON2开关 = "ON" Then
            开关控件2.切换状态()
        End If
        RCON2.Text = RCON2名称
        名称2.Text = RCON2名称
        地址2.Text = RCON2地址
        端口2.Text = RCON2端口
        密码2.Text = RCON2密码
        '加载RCON3配置
        If RCON3开关 = "ON" Then
            开关控件3.切换状态()
        End If
        RCON3.Text = RCON3名称
        名称3.Text = RCON3名称
        地址3.Text = RCON3地址
        端口3.Text = RCON3端口
        密码3.Text = RCON3密码
        '加载RCON4配置
        If RCON4开关 = "ON" Then
            开关控件4.切换状态()
        End If
        RCON4.Text = RCON4名称
        名称4.Text = RCON4名称
        地址4.Text = RCON4地址
        端口4.Text = RCON4端口
        密码4.Text = RCON4密码
        '加载RCON5配置
        If RCON5开关 = "ON" Then
            开关控件5.切换状态()
        End If
        RCON5.Text = RCON5名称
        名称5.Text = RCON5名称
        地址5.Text = RCON5地址
        端口5.Text = RCON5端口
        密码5.Text = RCON5密码
        '加载RCON6配置
        If RCON6开关 = "True" Then
            开关控件6.切换状态()
        End If
        RCON6.Text = RCON6名称
        名称6.Text = RCON6名称
        地址6.Text = RCON6地址
        端口6.Text = RCON6端口
        密码6.Text = RCON6密码
        '加载RCON7配置
        If RCON7开关 = "ON" Then
            开关控件7.切换状态()
        End If
        RCON7.Text = RCON7名称
        名称7.Text = RCON7名称
        地址7.Text = RCON7地址
        端口7.Text = RCON7端口
        密码7.Text = RCON7密码
        '加载RCON8配置
        If RCON8开关 = "ON" Then
            开关控件8.切换状态()
        End If
        RCON8.Text = RCON8名称
        名称8.Text = RCON8名称
        地址8.Text = RCON8地址
        端口8.Text = RCON8端口
        密码8.Text = RCON8密码
        '加载RCON9配置
        If RCON9开关 = "ON" Then
            开关控件9.切换状态()
        End If
        RCON9.Text = RCON9名称
        名称9.Text = RCON9名称
        地址9.Text = RCON9地址
        端口9.Text = RCON9端口
        密码9.Text = RCON9密码
        '加载RCON10配置
        If RCON10开关 = "ON" Then
            开关控件10.切换状态()
        End If
        RCON10.Text = RCON10名称
        名称10.Text = RCON10名称
        地址10.Text = RCON10地址
        端口10.Text = RCON10端口
        密码10.Text = RCON10密码
    End Sub
    Private Sub 保存RCON配置()
        写入RCON配置(1, RCON1开关, 名称1.Text, 地址1.Text, 端口1.Text, 密码1.Text)
        写入RCON配置(2, RCON2开关, 名称2.Text, 地址2.Text, 端口2.Text, 密码2.Text)
        写入RCON配置(3, RCON3开关, 名称3.Text, 地址3.Text, 端口3.Text, 密码3.Text)
        写入RCON配置(4, RCON4开关, 名称4.Text, 地址4.Text, 端口4.Text, 密码4.Text)
        写入RCON配置(5, RCON5开关, 名称5.Text, 地址5.Text, 端口5.Text, 密码5.Text)
        写入RCON配置(6, RCON6开关, 名称6.Text, 地址6.Text, 端口6.Text, 密码6.Text)
        写入RCON配置(7, RCON7开关, 名称7.Text, 地址7.Text, 端口7.Text, 密码7.Text)
        写入RCON配置(8, RCON8开关, 名称8.Text, 地址8.Text, 端口8.Text, 密码8.Text)
        写入RCON配置(9, RCON9开关, 名称9.Text, 地址9.Text, 端口9.Text, 密码9.Text)
        写入RCON配置(10, RCON10开关, 名称10.Text, 地址10.Text, 端口10.Text, 密码10.Text)
    End Sub
End Class