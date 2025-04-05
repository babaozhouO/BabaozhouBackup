' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class MainForm
    Public 日志窗口 As 显示日志的窗口
    Private imageFolder As String = "背景图片"
    Private imageExtensions As String() = {".jpg", ".png", ".bmp"}
    Private imageFiles As New List(Of String)()
    Private currentImageIndex As Integer = 0
    Private nextSwitchTime As DateTime ' 下一次切换的时间点
    Public Sub 添加日志(信息 As String, 颜色 As Color) ' 添加日志
        日志窗口.添加日志(信息, 颜色)
    End Sub
    '--------------------------------初始化计时器--------------------------------
    Private Sub UpdateCountdownDisplay() ' 更新倒计时显示
        Dim remainingTime As TimeSpan = nextSwitchTime - DateTime.Now
        Dim seconds As Integer = CInt(remainingTime.TotalSeconds)

        ' 显示剩余秒数
        倒计时数字显示.Text = $"{seconds} 秒后切换下一张"

        ' 更新进度条（最大值60秒）
        倒计时进度条.Maximum = 60
        倒计时进度条.Value = Math.Max(0, 60 - seconds)
    End Sub
    '-----------------------------------图片轮播-------------------------------------------
    Private Sub LoadImageFiles() ' 加载图片文件列表
        If Directory.Exists(imageFolder) Then
            imageFiles = Directory.GetFiles(imageFolder).
                Where(Function(file) imageExtensions.Contains(Path.GetExtension(file).ToLower())).ToList()
        End If
    End Sub
    Private Sub LoadImage(imagePath As String) ' 加载图片
        Try
            If PictureBox.Image IsNot Nothing Then
                PictureBox.Image.Dispose()
            End If
            PictureBox.Image = Image.FromFile(imagePath)
        Catch ex As Exception
            MessageBox.Show($"加载图片失败：{ex.Message}")
        End Try
    End Sub

    Private Sub 主窗口_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SevenZipSettingsForm.Owner = Me
        MainSettingsForm.Owner = Me
        RCONSettingsForm.Owner = Me
        ServiceSettingsForm.Owner = Me
        SftpSettingsForm.Owner = Me
        UselessToolsForm.Owner = Me
        日志窗口 = New 显示日志的窗口(Me)
        '-------------------------------------初始化控件关系-------------------------------------
        Me.IntroductionLabel.Parent = PictureBox
        Me.IntroductionLabel.BackColor = Color.Transparent
        Me.LogsLabel.Parent = PictureBox
        Me.LogsLabel.BackColor = Color.Transparent
        Me.倒计时数字显示.Parent = PictureBox
        Me.倒计时数字显示.BackColor = Color.Transparent
        '--------------------------------初始化背景图片--------------------------------
        LoadImageFiles()
        If imageFiles.Count > 0 Then
            LoadImage(imageFiles(currentImageIndex))
            StartCountdown()
        Else
            MessageBox.Show("未找到图片文件！")
        End If
        Application.DoEvents()
    End Sub
    Private Sub 主窗口_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        日志窗口.Show()
        日志窗口.更新停靠位置(Me)
        日志窗口.日志输出软件信息()
        日志窗口.日志输出主程序配置()
        日志窗口.日志输出RCON配置()
        日志窗口.日志输出7zip配置()
        日志窗口.日志输出SFTP配置()
        添加日志("-------------------------------------------------------------------------------------", Color.Black)
    End Sub
    Private Sub MainForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        日志窗口.更新停靠位置(Me) ' 更新日志窗口位置
    End Sub
    Private Sub 主窗口_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        NowTimer.Stop() ' 窗体关闭时释放资源
        ChanegeImageTimer.Stop()
        PictureBox.Image?.Dispose()
    End Sub
    Private Sub StartCountdown() ' 初始化倒计时
        nextSwitchTime = DateTime.Now.AddMinutes(1) ' 初始为60秒后切换
        UpdateCountdownDisplay()
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        End
    End Sub
    Private Sub ClearlogButton_Click(sender As Object, e As EventArgs) Handles ClearlogButton.Click
        日志窗口.LogsRichTextBox.Clear()
        添加日志("[Action]已清空日志", Color.Green)
    End Sub
    Private Sub ServiceButton_Click(sender As Object, e As EventArgs) Handles ServiceButton.Click
        添加日志("[Action]打开安装/卸载系统服务窗口", Color.Black)
        ServiceSettingsForm.Show()
        日志窗口.更新停靠位置(ServiceSettingsForm)
    End Sub
    Private Sub NowTimer_Tick(sender As Object, e As EventArgs) Handles NowTimer.Tick
        UpdateCountdownDisplay()
    End Sub
    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        添加日志("[Action]打开主程序配置界面", Color.Black)
        MainSettingsForm.Show()
        日志窗口.更新停靠位置(MainSettingsForm)
    End Sub
    Private Sub Button7z_Click(sender As Object, e As EventArgs) Handles Button7z.Click
        添加日志("[Action]打开7z压缩程序配置界面", Color.Black)
        SevenZipSettingsForm.Show()
        日志窗口.更新停靠位置(SevenZipSettingsForm)
    End Sub
    Private Sub SftpButton_Click(sender As Object, e As EventArgs) Handles SftpButton.Click
        添加日志("[Action]打开内置sftp客户端配置界面", Color.Black)
        SftpSettingsForm.Show()
        日志窗口.更新停靠位置(SftpSettingsForm)
    End Sub
    Private Sub ButtonRCON_Click(sender As Object, e As EventArgs) Handles ButtonRCON.Click
        添加日志("[Action]打开RCON服务器配置界面", Color.Black)
        RCONSettingsForm.Show()
        日志窗口.更新停靠位置(RCONSettingsForm)
    End Sub
    Private Sub TestsftpButton_Click(sender As Object, e As EventArgs) Handles TestsftpButton.Click
        添加日志("[Action]正在测试sftp服务器连接", Color.Black)
        Sftp服务器测试器()
    End Sub
    Private Sub TestRCONButton_Click(sender As Object, e As EventArgs) Handles TestRCONButton.Click
        添加日志("[Action]正在测试RCON服务器连接", Color.Black)
        RCON服务器测试器()
    End Sub
    Private Sub RunButton_Click(sender As Object, e As EventArgs) Handles RunButton.Click
        添加日志("[Action]正在启动服务", Color.Black)
        添加日志("[Info]正在读取配置文件", Color.Black)
        日志窗口.日志输出主程序配置()
        日志窗口.日志输出RCON配置()
        日志窗口.日志输出7zip配置()
        日志窗口.日志输出SFTP配置()
        添加日志("-------------------------------------------------------------------------------------", Color.Black)
        添加日志("[ERROR]服务未启动，尚未实现", Color.Red)
    End Sub
    Private Sub ButtonSightseeing_Click(sender As Object, e As EventArgs) Handles ButtonSightseeing.Click
        Me.IntroductionLabel.Visible = False
        日志窗口.Visible = False
        Me.ExitButton.Visible = False
        Me.ClearlogButton.Visible = False
        Me.ServiceButton.Visible = False
        Me.SettingsButton.Visible = False
        Me.Button7z.Visible = False
        Me.SftpButton.Visible = False
        Me.TestsftpButton.Visible = False
        Me.TestRCONButton.Visible = False
        Me.RunButton.Visible = False
        Me.ButtonSightseeing.Visible = False
        Me.RunButton.Visible = False
        Me.ServiceButton.Visible = False
        Me.ToolsButton.Visible = False
        Me.StopButton.Visible = False
        Me.LogsLabel.Visible = False
        Me.ButtonRCON.Visible = False
        Me.ReturnButton.Visible = True
    End Sub
    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        Me.IntroductionLabel.Visible = True
        日志窗口.Visible = True
        Me.ExitButton.Visible = True
        Me.ClearlogButton.Visible = True
        Me.ServiceButton.Visible = True
        Me.SettingsButton.Visible = True
        Me.Button7z.Visible = True
        Me.SftpButton.Visible = True
        Me.TestsftpButton.Visible = True
        Me.TestRCONButton.Visible = True
        Me.RunButton.Visible = True
        Me.ButtonSightseeing.Visible = True
        Me.RunButton.Visible = True
        Me.ServiceButton.Visible = True
        Me.ToolsButton.Visible = True
        Me.StopButton.Visible = True
        Me.LogsLabel.Visible = True
        Me.ButtonRCON.Visible = True
        Me.ReturnButton.Visible = False
    End Sub
    Private Sub ToolsButton_Click(sender As Object, e As EventArgs) Handles ToolsButton.Click
        UselessToolsForm.Show()
        日志窗口.更新停靠位置(UselessToolsForm)
    End Sub
    Private Sub ChanegeImageTimer_Tick(sender As Object, e As EventArgs) Handles ChanegeImageTimer.Tick ' 切换图片并重置倒计时
        currentImageIndex = (currentImageIndex + 1) Mod imageFiles.Count
        LoadImage(imageFiles(currentImageIndex))
        nextSwitchTime = DateTime.Now.AddMinutes(1) ' 重置倒计时
        UpdateCountdownDisplay()
    End Sub
    Private Async Sub 核心功能()

    End Sub
    Private Async Sub RCON服务器测试器()
        If RCON1开关 = "ON" Then
            Dim RCON测试器 As New RCON客户端()
            添加日志("[INFO]正在测试RCON1服务器", Color.Orange)
            RCON测试器.连接RCON(RCON1地址, RCON1端口, RCON1密码)
            If RCON测试器.连接状态 = False Then
                Return
            End If
            RCON测试器.发送指令并返回响应("list")
            Await Task.Delay(4000) ' 等待数据包到达
            RCON测试器.断开连接()
            添加日志("[INFO]RCON1服务器连接已断开", Color.Orange)
        End If
        If RCON2开关 = "ON" Then
            Dim RCON测试器 As New RCON客户端()
            添加日志("[INFO]正在测试RCON2服务器", Color.Orange)
            RCON测试器.连接RCON(RCON2地址, RCON2端口, RCON2密码)
            If RCON测试器.连接状态 = False Then
                Return
            End If
            RCON测试器.发送指令并返回响应("list")
            Await Task.Delay(4000) ' 等待数据包到达
            RCON测试器.断开连接()
            添加日志("[INFO]RCON2服务器连接已断开", Color.Orange)
        End If
        If RCON3开关 = "ON" Then
            Dim RCON测试器 As New RCON客户端()
            添加日志("[INFO]正在测试RCON3服务器", Color.Orange)
            RCON测试器.连接RCON(RCON3地址, RCON3端口, RCON3密码)
            If RCON测试器.连接状态 = False Then
                Return
            End If
            RCON测试器.发送指令并返回响应("list")
            Await Task.Delay(4000) ' 等待数据包到达
            RCON测试器.断开连接()
            添加日志("[INFO]RCON3服务器连接已断开", Color.Orange)
        End If
        If RCON4开关 = "ON" Then
            Dim RCON测试器 As New RCON客户端()
            添加日志("[INFO]正在测试RCON4服务器", Color.Orange)
            RCON测试器.连接RCON(RCON4地址, RCON4端口, RCON4密码)
            If RCON测试器.连接状态 = False Then
                Return
            End If
            RCON测试器.发送指令并返回响应("list")
            Await Task.Delay(4000) ' 等待数据包到达
            RCON测试器.断开连接()
            添加日志("[INFO]RCON4服务器连接已断开", Color.Orange)
        End If
        If RCON5开关 = "ON" Then
            Dim RCON测试器 As New RCON客户端()
            添加日志("[INFO]正在测试RCON5服务器", Color.Orange)
            RCON测试器.连接RCON(RCON5地址, RCON5端口, RCON5密码)
            If RCON测试器.连接状态 = False Then
                Return
            End If
            RCON测试器.发送指令并返回响应("list")
            Await Task.Delay(4000) ' 等待数据包到达
            RCON测试器.断开连接()
            添加日志("[INFO]RCON5服务器连接已断开", Color.Orange)
        End If
        If RCON6开关 = "ON" Then
            Dim RCON测试器 As New RCON客户端()
            添加日志("[INFO]正在测试RCON6服务器", Color.Orange)
            RCON测试器.连接RCON(RCON6地址, RCON6端口, RCON6密码)
            If RCON测试器.连接状态 = False Then
                Return
            End If
            RCON测试器.发送指令并返回响应("list")
            Await Task.Delay(4000) ' 等待数据包到达
            RCON测试器.断开连接()
            添加日志("[INFO]RCON6服务器连接已断开", Color.Orange)
        End If
        If RCON7开关 = "ON" Then
            Dim RCON测试器 As New RCON客户端()
            添加日志("[INFO]正在测试RCON7服务器", Color.Orange)
            RCON测试器.连接RCON(RCON7地址, RCON7端口, RCON7密码)
            If RCON测试器.连接状态 = False Then
                Return
            End If
            RCON测试器.发送指令并返回响应("list")
            Await Task.Delay(4000) ' 等待数据包到达
            RCON测试器.断开连接()
            添加日志("[INFO]RCON7服务器连接已断开", Color.Orange)
        End If
        If RCON8开关 = "ON" Then
            Dim RCON测试器 As New RCON客户端()
            添加日志("[INFO]正在测试RCON8服务器", Color.Orange)
            RCON测试器.连接RCON(RCON8地址, RCON8端口, RCON8密码)
            If RCON测试器.连接状态 = False Then
                Return
            End If
            RCON测试器.发送指令并返回响应("list")
            Await Task.Delay(4000) ' 等待数据包到达
            RCON测试器.断开连接()
            添加日志("[INFO]RCON8服务器连接已断开", Color.Orange)
        End If
        If RCON9开关 = "ON" Then
            Dim RCON测试器 As New RCON客户端()
            添加日志("[INFO]正在测试RCON9服务器", Color.Orange)
            RCON测试器.连接RCON(RCON9地址, RCON9端口, RCON9密码)
            If RCON测试器.连接状态 = False Then
                Return
            End If
            RCON测试器.发送指令并返回响应("list")
            Await Task.Delay(4000) ' 等待数据包到达
            RCON测试器.断开连接()
            添加日志("[INFO]RCON9服务器连接已断开", Color.Orange)
        End If
        If RCON10开关 = "ON" Then
            Dim RCON测试器 As New RCON客户端()
            添加日志("[INFO]正在测试RCON10服务器", Color.Orange)
            RCON测试器.连接RCON(RCON10地址, RCON10端口, RCON10密码)
            If RCON测试器.连接状态 = False Then
                Return
            End If
            RCON测试器.发送指令并返回响应("list")
            Await Task.Delay(4000) ' 等待数据包到达
            RCON测试器.断开连接()
            添加日志("[INFO]RCON10服务器连接已断开", Color.Orange)
        End If
    End Sub
    Private Sub Sftp服务器测试器()
        If Sftp1开关 = "ON" Then
            Dim Sftp测试器 As New SFTP客户端(Sftp1地址, Sftp1端口, Sftp1用户名, Sftp1密码)
            添加日志("[INFO]正在测试SFTP1服务器", Color.Orange)
            Sftp测试器.建立Sftp连接()
            If Sftp测试器.连接状态 = False Then Return
            Sftp测试器.断开连接()
            添加日志("[INFO]SFTP1服务器连接已断开", Color.Orange)
        End If
        If Sftp2开关 = "ON" Then
            Dim Sftp测试器 As New SFTP客户端(Sftp2地址, Sftp2端口, Sftp2用户名, Sftp2密码)
            添加日志("[INFO]正在测试SFTP2服务器", Color.Orange)
            Sftp测试器.建立Sftp连接()
            If Sftp测试器.连接状态 = False Then Return
            Sftp测试器.断开连接()
            添加日志("[INFO]SFTP2服务器连接已断开", Color.Orange)
        End If
        If Sftp3开关 = "ON" Then
            Dim Sftp测试器 As New SFTP客户端(Sftp3地址, Sftp3端口, Sftp3用户名, Sftp3密码)
            添加日志("[INFO]正在测试SFTP3服务器", Color.Orange)
            Sftp测试器.建立Sftp连接()
            If Sftp测试器.连接状态 = False Then Return
            Sftp测试器.断开连接()
            添加日志("[INFO]SFTP3服务器连接已断开", Color.Orange)
        End If
    End Sub
End Class