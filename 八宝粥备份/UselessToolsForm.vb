Imports System.IO
Imports System.Linq.Expressions

' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Public Class UselessToolsForm
    Public Sub 添加日志(信息 As String, 颜色 As Color)
        MainForm.日志窗口.添加日志(信息, 颜色)
    End Sub
    Private Sub UselessToolsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        初始化RCON选择项()
        初始化Sftp选择项()
    End Sub
    ' 窗口激活时更新日志位置
    Private Sub UselessToolsForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            DirectCast(Owner, MainForm).日志窗口.更新停靠位置(Me)
        End If
    End Sub
    ' 窗口移动时更新日志位置
    Private Sub UselessToolsForm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            DirectCast(Owner, MainForm).日志窗口.更新停靠位置(Me)
        End If
    End Sub
    Private Sub 安装7Zip_Click(sender As Object, e As EventArgs) Handles 安装7Zip.Click
        Dim 七Zip安装包路径 As String = Path.Combine(Application.StartupPath, "资源", "7z2409-x64.exe")

        If Not File.Exists(七Zip安装包路径) Then
            添加日志("[ERROR]资源文件被你删了", Color.Red)
            MsgBox("你个坏蛋,把我的资源文件删了！", MsgBoxStyle.Critical, "坏蛋！")
            Return
        End If
        If Not 是否以管理员身份运行() Then
            添加日志("[ERROR]都叫你用管理员身份运行此程序了,你就是不听", Color.Red)
            MsgBox("都叫你用管理员身份运行此程序了,你就是不听", MsgBoxStyle.Critical, "错误")
            Return
        End If
        Process.Start(七Zip安装包路径)
    End Sub
    Private Sub 退出_Click(sender As Object, e As EventArgs) Handles 退出.Click
        Dim 用户选择 As Integer = MessageBox.Show("确认退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
    Private Sub 初始化RCON选择项()
        ComboBoxRCON.Items.Clear()
        If RCON1开关 = "ON" Then
            ComboBoxRCON.Items.Add(RCON1名称)
        End If
        If RCON2开关 = "ON" Then
            ComboBoxRCON.Items.Add(RCON2名称)
        End If
        If RCON3开关 = "ON" Then
            ComboBoxRCON.Items.Add(RCON3名称)
        End If
        If RCON4开关 = "ON" Then
            ComboBoxRCON.Items.Add(RCON4名称)
        End If
        If RCON5开关 = "ON" Then
            ComboBoxRCON.Items.Add(RCON5名称)
        End If
        If RCON6开关 = "ON" Then
            ComboBoxRCON.Items.Add(RCON6名称)
        End If
        If RCON7开关 = "ON" Then
            ComboBoxRCON.Items.Add(RCON7名称)
        End If
        If RCON8开关 = "ON" Then
            ComboBoxRCON.Items.Add(RCON8名称)
        End If
        If RCON9开关 = "ON" Then
            ComboBoxRCON.Items.Add(RCON9名称)
        End If
        If RCON10开关 = "ON" Then
            ComboBoxRCON.Items.Add(RCON10名称)
        End If
        If ComboBoxRCON.Items.Count = 0 Then
            ComboBoxRCON.Items.Add("没有可用的RCON,全给你关掉了(恼)")
        End If
        ComboBoxRCON.SelectedIndex = 0
    End Sub
    Private Sub 初始化Sftp选择项()
        ComboBoxSftp.Items.Clear()
        If Sftp1开关 = "ON" Then
            ComboBoxSftp.Items.Add(Sftp1名称)
        End If
        If Sftp2开关 = "ON" Then
            ComboBoxSftp.Items.Add(Sftp2名称)
        End If
        If Sftp3开关 = "ON" Then
            ComboBoxSftp.Items.Add(Sftp3名称)
        End If
        If ComboBoxSftp.Items.Count = 0 Then
            ComboBoxSftp.Items.Add("没有可用的SFTP,全给你关掉了(恼)")
        End If
        ComboBoxSftp.SelectedIndex = 0
    End Sub
    Private Async Sub SendCommand_Click(sender As Object, e As EventArgs) Handles SendCommand.Click
        Dim 选中的RCON名称 As String = ComboBoxRCON.Text
        Dim 指令 As String = Command.Text
        Dim RCON实例 As New RCON客户端
        Select Case 选中的RCON名称
            Case RCON1名称
                RCON实例.连接RCON(RCON1地址, RCON1端口, RCON1密码)
                RCON实例.发送指令并返回响应(指令)
            Case RCON2名称
                RCON实例.连接RCON(RCON2地址, RCON2端口, RCON2密码)
                RCON实例.发送指令并返回响应(指令)
            Case RCON3名称
                RCON实例.连接RCON(RCON3地址, RCON3端口, RCON3密码)
                RCON实例.发送指令并返回响应(指令)
            Case RCON4名称
                RCON实例.连接RCON(RCON4地址, RCON4端口, RCON4密码)
                RCON实例.发送指令并返回响应(指令)
            Case RCON5名称
                RCON实例.连接RCON(RCON5地址, RCON5端口, RCON5密码)
                RCON实例.发送指令并返回响应(指令)
            Case RCON6名称
                RCON实例.连接RCON(RCON6地址, RCON6端口, RCON6密码)
                RCON实例.发送指令并返回响应(指令)
            Case RCON7名称
                RCON实例.连接RCON(RCON7地址, RCON7端口, RCON7密码)
                RCON实例.发送指令并返回响应(指令)
            Case RCON8名称
                RCON实例.连接RCON(RCON8地址, RCON8端口, RCON8密码)
                RCON实例.发送指令并返回响应(指令)
            Case RCON9名称
                RCON实例.连接RCON(RCON9地址, RCON9端口, RCON9密码)
                RCON实例.发送指令并返回响应(指令)
            Case RCON10名称
                RCON实例.连接RCON(RCON10地址, RCON10端口, RCON10密码)
                RCON实例.发送指令并返回响应(指令)
            Case Else
                添加日志("[ERROR]你选了个啥玩意？？？", Color.Red)
                MsgBox("你选了个啥玩意？？？", MsgBoxStyle.Critical, "错误")
                ComboBoxRCON.SelectedIndex = 0
                Return
        End Select
        Await Task.Delay(4000) ' 等待数据包到达
        Select Case 选中的RCON名称
            Case RCON1名称
                RCON实例.断开连接()
                If RCON实例.连接状态 = False Then Return
                添加日志("[INFO]RCON1服务器连接已断开", Color.Orange)
            Case RCON2名称
                RCON实例.断开连接()
                If RCON实例.连接状态 = False Then Return
                添加日志("[INFO]RCON2服务器连接已断开", Color.Orange)
            Case RCON3名称
                RCON实例.断开连接()
                If RCON实例.连接状态 = False Then Return
                添加日志("[INFO]RCON3服务器连接已断开", Color.Orange)
            Case RCON4名称
                RCON实例.断开连接()
                If RCON实例.连接状态 = False Then Return
                添加日志("[INFO]RCON4服务器连接已断开", Color.Orange)
            Case RCON5名称
                RCON实例.断开连接()
                If RCON实例.连接状态 = False Then Return
                添加日志("[INFO]RCON5服务器连接已断开", Color.Orange)
            Case RCON6名称
                RCON实例.断开连接()
                If RCON实例.连接状态 = False Then Return
                添加日志("[INFO]RCON6服务器连接已断开", Color.Orange)
            Case RCON7名称
                RCON实例.断开连接()
                If RCON实例.连接状态 = False Then Return
                添加日志("[INFO]RCON7服务器连接已断开", Color.Orange)
            Case RCON8名称
                RCON实例.断开连接()
                If RCON实例.连接状态 = False Then Return
                添加日志("[INFO]RCON8服务器连接已断开", Color.Orange)
            Case RCON9名称
                RCON实例.断开连接()
                If RCON实例.连接状态 = False Then Return
                添加日志("[INFO]RCON9服务器连接已断开", Color.Orange)
            Case RCON10名称
                RCON实例.断开连接()
                If RCON实例.连接状态 = False Then Return
                添加日志("[INFO]RCON10服务器连接已断开", Color.Orange)
        End Select
    End Sub

    Private Sub ChooseFile_Click(sender As Object, e As EventArgs) Handles ChooseFile.Click
        选择文件.ShowDialog()
    End Sub

    Private Sub FileSend_Click(sender As Object, e As EventArgs) Handles FileSend.Click
        Dim 选中的Sftp名称 As String = ComboBoxSftp.Text
        Dim 文件路径 As String = 选择文件.FileName
        Select Case 选中的Sftp名称
            Case Sftp1名称
                Using Sftp实例 As New SFTP客户端(Sftp1地址, Sftp1端口, Sftp1用户名, Sftp1密码)
                    Sftp实例.建立Sftp连接()
                    If Sftp实例.连接状态 = False Then Return
                    If 文件路径 = "" Then
                        添加日志("[ERROR]未选择文件", Color.Red)
                        Return
                    Else
                        Sftp实例.上传文件(文件路径, "/")
                        MessageBox.Show("文件上传成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Case Sftp2名称
                Using Sftp实例 As New SFTP客户端(Sftp2地址, Sftp2端口, Sftp2用户名, Sftp2密码)
                    Sftp实例.建立Sftp连接()
                    If Sftp实例.连接状态 = False Then Return
                    Sftp实例.上传文件(文件路径, "/")
                    MessageBox.Show("文件上传成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            Case Sftp3名称
                Using Sftp实例 As New SFTP客户端(Sftp3地址, Sftp3端口, Sftp3用户名, Sftp3密码)
                    Sftp实例.建立Sftp连接()
                    If Sftp实例.连接状态 = False Then
                        Return
                    Else
                        Sftp实例.上传文件(文件路径, "/")
                        MessageBox.Show("文件上传成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Case Else
                添加日志("[ERROR]你选了个啥玩意？？？", Color.Red)
                MessageBox.Show("你选了个啥玩意？？？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ComboBoxSftp.SelectedIndex = 0
        End Select
    End Sub
End Class