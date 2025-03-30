' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class 主窗口
    Private Time As DateTime
    Private imageFolder As String = "背景图片"
    Private imageExtensions As String() = {".jpg", ".png", ".bmp"}
    Private imageFiles As New List(Of String)()
    Private currentImageIndex As Integer = 0
    Private nextSwitchTime As DateTime ' 下一次切换的时间点
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
        '--------------------------------配置文件读取及日志记录--------------------------------
        Time = DateTime.Now
        Addlog("[Info]Github仓库链接:https://github.com/babaozhouO/BabaozhouBackup", Color.Black)
        Addlog("[Info]作者:八宝粥", Color.Black)
        Addlog("[Info]联系方式:QQEmail:1749861851@qq.com", Color.Black)
        Addlog("未经作者同意，不得删除软件中的作者标识，本软件受开源协议保护"， Color.Red)
        Addlog("[Info]程序启动,V0.1.0-alphav1.0-beta.4", Color.Green)
        Addlog("[Info]正在读取配置文件", Color.Black)
        运行时间 = 配置文件操作.读取配置("MainSettings", "Runtime", "03:00:00", "配置文件/MainConfig.ini")
        RCON1服务器 = 配置文件操作.读取配置("RCONConfig", "Server1Name", "Server1", "配置文件/RCONConfig.ini")
        RCON1地址 = 配置文件操作.读取配置("RCONConfig", "Server1IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON1端口 = 配置文件操作.读取配置("RCONConfig", "Server1Port", "25575", "配置文件/RCONConfig.ini")
        RCON1密码 = 配置文件操作.读取配置("RCONConfig", "Server1Password", "空", "配置文件/RCONConfig.ini")
        Addlog("[Info]配置文件读取完成", Color.Green)
        Addlog("[Info]配置文件数据:", Color.Blue)
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]主程序配置:", Color.Blue)
        Addlog("[Info]运行时间:" + 运行时间, Color.Blue)
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]RCON服务器配置:", Color.Blue)
        Addlog("[Info]RCON服务器名称:" + RCON1服务器, Color.Blue)
        Addlog("[Info]RCON服务器地址:" + RCON1地址, Color.Blue)
        Addlog("[Info]RCON服务器端口:" + RCON1端口, Color.Blue)
        If RCON1密码 = "空" Then
            Addlog("[Info]" + RCON1服务器 + "RCON密码:未设置", Color.Blue)
        Else
            Addlog("[Info]" + RCON1服务器 + "RCON密码:已设置", Color.Blue)
        End If
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        'RCON服务器 = 配置文件操作.读取配置("RCONConfig", "Server2Name", "Server3", "配置文件/RCONConfig.ini")
        'RCON地址 = 配置文件操作.读取配置("RCONConfig", "Server2IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        'RCON端口 = 配置文件操作.读取配置("RCONConfig", "Server2Port", "25576", "配置文件/RCONConfig.ini")
        'RCON密码 = 配置文件操作.读取配置("RCONConfig", "Server2Password", "空", "配置文件/RCONConfig.ini")
        'Addlog("[Info]RCON服务器名称:" + RCON服务器, Color.Blue)
        'Addlog("[Info]RCON服务器地址:" + RCON地址, Color.Blue)
        'Addlog("[Info]RCON服务器端口:" + RCON端口, Color.Blue)
        'If RCON密码 = "空" Then
        '   Addlog("[Info]" + RCON服务器 + "RCON密码:未设置", Color.Blue)
        'Else
        '   Addlog("[Info]" + RCON服务器 + "RCON密码:已设置", Color.Blue)
        'End If
        'Addlog("-------------------------------------------------------------------------------------", Color.Black)
        'RCON服务器 = 配置文件操作.读取配置("RCONConfig", "Server3Name", "Server3", "配置文件/RCONConfig.ini")
        'RCON地址 = 配置文件操作.读取配置("RCONConfig", "Server3IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        'RCON端口 = 配置文件操作.读取配置("RCONConfig", "Server3Port", "25577", "配置文件/RCONConfig.ini")
        'RCON密码 = 配置文件操作.读取配置("RCONConfig", "Server3Password", "空", "配置文件/RCONConfig.ini")
        'Addlog("[Info]RCON服务器名称:" + RCON服务器, Color.Blue)
        'Addlog("[Info]RCON服务器地址:" + RCON地址, Color.Blue)
        'Addlog("[Info]RCON服务器端口:" + RCON端口, Color.Blue)
        'If RCON密码 = "空" Then
        '   Addlog("[Info]" + RCON服务器 + "RCON密码:未设置", Color.Blue)
        'Else
        '   Addlog("[Info]" + RCON服务器 + "RCON密码:已设置", Color.Blue)
        'End If
        'Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Sftp1名称 = 配置文件操作.读取配置("SFTPConfig", "Sftp1Name", "SFTP1", "配置文件/SFTPConfig.ini")
        Sftp1地址 = 配置文件操作.读取配置("SFTPConfig", "Sftp1IP", "127.0.0.1", "配置文件/SFTPConfig.ini")
        Sftp1端口 = 配置文件操作.读取配置("SFTPConfig", "Sftp1Port", "22", "配置文件/SFTPConfig.ini")
        Sftp1用户名 = 配置文件操作.读取配置("SFTPConfig", "Sftp1User", "default", "配置文件/SFTPConfig.ini")
        Sftp1密码 = 配置文件操作.读取配置("SFTPConfig", "Sftp1Password", "default", "配置文件/SFTPConfig.ini")
        Addlog("[Info]SFTP服务器配置:", Color.Blue)
        Addlog("[Info]SFTP服务器名称:" + Sftp1名称, Color.Blue)
        Addlog("[Info]SFTP服务器地址:" + Sftp1地址, Color.Blue)
        Addlog("[Info]SFTP服务器端口:" + Sftp1端口, Color.Blue)
        Addlog("[Info]SFTP服务器用户名:" + Sftp1用户名, Color.Blue)
        Addlog("[Info]SFTP服务器密码:" + Sftp1密码, Color.Blue)
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        'Sftp2名称 = 配置文件操作.读取配置("SFTPConfig", "Sftp2Name", "SFTP2", "配置文件/SFTPConfig.ini")
        'Sftp2地址 = 配置文件操作.读取配置("SFTPConfig", "Sftp2IP", "127.0.0.1", "配置文件/SFTPConfig.ini")
        'Sftp2端口 = 配置文件操作.读取配置("SFTPConfig", "Sftp2Port", "22", "配置文件/SFTPConfig.ini")
        'Sftp2用户名 = 配置文件操作.读取配置("SFTPConfig", "Sftp2User", "default", "配置文件/SFTPConfig.ini")
        'Sftp2密码 = 配置文件操作.读取配置("SFTPConfig", "Sftp2Password", "default", "配置文件/SFTPConfig.ini")
        'Addlog("[Info]SFTP服务器名称:" + Sftp2名称, Color.Blue)
        'Addlog("[Info]SFTP服务器地址:" + Sftp2地址, Color.Blue)
        'Addlog("[Info]SFTP服务器端口:" + Sftp2端口, Color.Blue)
        'Addlog("[Info]SFTP服务器用户名:" + Sftp2用户名, Color.Blue)
        'Addlog("[Info]SFTP服务器密码:" + Sftp2密码, Color.Blue)
        'Addlog("-------------------------------------------------------------------------------------", Color.Black)
        'Sftp3名称 = 配置文件操作.读取配置("SFTPConfig", "Sftp3Name", "SFTP3", "配置文件/SFTPConfig.ini")
        'Sftp3地址 = 配置文件操作.读取配置("SFTPConfig", "Sftp3IP", "127.0.0.1", "配置文件/SFTPConfig.ini")
        'Sftp3端口 = 配置文件操作.读取配置("SFTPConfig", "Sftp3Port", "22", "配置文件/SFTPConfig.ini")
        'Sftp3用户名 = 配置文件操作.读取配置("SFTPConfig", "Sftp3User", "default", "配置文件/SFTPConfig.ini")
        'Sftp3密码 = 配置文件操作.读取配置("SFTPConfig", "Sftp3Password", "default", "配置文件/SFTPConfig.ini")
        'Addlog("[Info]SFTP服务器名称:" + Sftp3名称, Color.Blue)
        'Addlog("[Info]SFTP服务器地址:" + Sftp3地址, Color.Blue)
        'Addlog("[Info]SFTP服务器端口:" + Sftp3端口, Color.Blue)
        'Addlog("[Info]SFTP服务器用户名:" + Sftp3用户名, Color.Blue)
        'Addlog("[Info]SFTP服务器密码:" + Sftp3密码, Color.Blue)
        'Addlog("-------------------------------------------------------------------------------------", Color.Black)
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
        LogsRichTextBox.Clear()
        Addlog("[Action]已清空日志", Color.Green)
    End Sub
    Private Sub ServiceButton_Click(sender As Object, e As EventArgs) Handles ServiceButton.Click
        Addlog("[Action]打开安装/卸载系统服务窗口", Color.Green)
        FormService.Show()
    End Sub
    Private Sub NowTimer_Tick(sender As Object, e As EventArgs) Handles NowTimer.Tick
        Time = DateTime.Now
        UpdateCountdownDisplay()
    End Sub
    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        Addlog("[Action]打开主程序配置界面", Color.Green)
        FormMainSettings.Show()
    End Sub
    Private Sub Button7z_Click(sender As Object, e As EventArgs) Handles Button7z.Click
        Addlog("[Action]打开7z压缩程序配置界面", Color.Green)
    End Sub
    Private Sub SftpButton_Click(sender As Object, e As EventArgs) Handles SftpButton.Click
        Addlog("[Action]打开内置sftp客户端配置界面", Color.Green)
    End Sub
    Private Sub TestsftpButton_Click(sender As Object, e As EventArgs) Handles TestsftpButton.Click
        Addlog("[Action]正在测试sftp服务器连接", Color.Black)
    End Sub
    Private Sub TestRCONButton_Click(sender As Object, e As EventArgs) Handles TestRCONButton.Click
        Addlog("[Action]正在测试RCON服务器连接", Color.Black)
    End Sub
    Private Sub RunButton_Click(sender As Object, e As EventArgs) Handles RunButton.Click
        Addlog("[Action]正在启动服务", Color.Green)
        Addlog("[Info]正在读取配置文件", Color.Black)
        运行时间 = 配置文件操作.读取配置("MainSettings", "Runtime", "03:00:00", "配置文件/MainConfig.ini")
        RCON1服务器 = 配置文件操作.读取配置("RCONConfig", "Server1Name", "Server1", "配置文件/RCONConfig.ini")
        RCON1地址 = 配置文件操作.读取配置("RCONConfig", "Server1IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON1端口 = 配置文件操作.读取配置("RCONConfig", "Server1Port", "25575", "配置文件/RCONConfig.ini")
        RCON1密码 = 配置文件操作.读取配置("RCONConfig", "Server1Password", "空", "配置文件/RCONConfig.ini")
        Addlog("[Info]配置文件读取完成", Color.Green)
        Addlog("[Info]配置文件数据:", Color.Blue)
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]主程序配置:", Color.Blue)
        Addlog("[Info]运行时间:" + 运行时间, Color.Blue)
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]RCON服务器配置:", Color.Blue)
        Addlog("[Info]RCON服务器名称:" + RCON1服务器, Color.Blue)
        Addlog("[Info]RCON服务器地址:" + RCON1地址, Color.Blue)
        Addlog("[Info]RCON服务器端口:" + RCON1端口, Color.Blue)
        If RCON1密码 = "空" Then
            Addlog("[Info]" + RCON1服务器 + "RCON密码:未设置", Color.Blue)
        Else
            Addlog("[Info]" + RCON1服务器 + "RCON密码:已设置", Color.Blue)
        End If
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        'RCON服务器 = 配置文件操作.读取配置("RCONConfig", "Server2Name", "Server3", "配置文件/RCONConfig.ini")
        'RCON地址 = 配置文件操作.读取配置("RCONConfig", "Server2IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        'RCON端口 = 配置文件操作.读取配置("RCONConfig", "Server2Port", "25576", "配置文件/RCONConfig.ini")
        'RCON密码 = 配置文件操作.读取配置("RCONConfig", "Server2Password", "空", "配置文件/RCONConfig.ini")
        'Addlog("[Info]RCON服务器名称:" + RCON服务器, Color.Blue)
        'Addlog("[Info]RCON服务器地址:" + RCON地址, Color.Blue)
        'Addlog("[Info]RCON服务器端口:" + RCON端口, Color.Blue)
        'If RCON密码 = "空" Then
        '   Addlog("[Info]" + RCON服务器 + "RCON密码:未设置", Color.Blue)
        'Else
        '   Addlog("[Info]" + RCON服务器 + "RCON密码:已设置", Color.Blue)
        'End If
        'Addlog("-------------------------------------------------------------------------------------", Color.Black)
        'RCON服务器 = 配置文件操作.读取配置("RCONConfig", "Server3Name", "Server3", "配置文件/RCONConfig.ini")
        'RCON地址 = 配置文件操作.读取配置("RCONConfig", "Server3IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        'RCON端口 = 配置文件操作.读取配置("RCONConfig", "Server3Port", "25577", "配置文件/RCONConfig.ini")
        'RCON密码 = 配置文件操作.读取配置("RCONConfig", "Server3Password", "空", "配置文件/RCONConfig.ini")
        'Addlog("[Info]RCON服务器名称:" + RCON服务器, Color.Blue)
        'Addlog("[Info]RCON服务器地址:" + RCON地址, Color.Blue)
        'Addlog("[Info]RCON服务器端口:" + RCON端口, Color.Blue)
        'If RCON密码 = "空" Then
        '   Addlog("[Info]" + RCON服务器 + "RCON密码:未设置", Color.Blue)
        'Else
        '   Addlog("[Info]" + RCON服务器 + "RCON密码:已设置", Color.Blue)
        'End If
        'Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Sftp1名称 = 配置文件操作.读取配置("SFTPConfig", "Sftp1Name", "SFTP1", "配置文件/SFTPConfig.ini")
        Sftp1地址 = 配置文件操作.读取配置("SFTPConfig", "Sftp1IP", "127.0.0.1", "配置文件/SFTPConfig.ini")
        Sftp1端口 = 配置文件操作.读取配置("SFTPConfig", "Sftp1Port", "22", "配置文件/SFTPConfig.ini")
        Sftp1用户名 = 配置文件操作.读取配置("SFTPConfig", "Sftp1User", "default", "配置文件/SFTPConfig.ini")
        Sftp1密码 = 配置文件操作.读取配置("SFTPConfig", "Sftp1Password", "default", "配置文件/SFTPConfig.ini")
        Addlog("[Info]SFTP服务器配置:", Color.Blue)
        Addlog("[Info]SFTP服务器名称:" + Sftp1名称, Color.Blue)
        Addlog("[Info]SFTP服务器地址:" + Sftp1地址, Color.Blue)
        Addlog("[Info]SFTP服务器端口:" + Sftp1端口, Color.Blue)
        Addlog("[Info]SFTP服务器用户名:" + Sftp1用户名, Color.Blue)
        Addlog("[Info]SFTP服务器密码:" + Sftp1密码, Color.Blue)
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        'Sftp2名称 = 配置文件操作.读取配置("SFTPConfig", "Sftp2Name", "SFTP2", "配置文件/SFTPConfig.ini")
        'Sftp2地址 = 配置文件操作.读取配置("SFTPConfig", "Sftp2IP", "127.0.0.1", "配置文件/SFTPConfig.ini")
        'Sftp2端口 = 配置文件操作.读取配置("SFTPConfig", "Sftp2Port", "22", "配置文件/SFTPConfig.ini")
        'Sftp2用户名 = 配置文件操作.读取配置("SFTPConfig", "Sftp2User", "default", "配置文件/SFTPConfig.ini")
        'Sftp2密码 = 配置文件操作.读取配置("SFTPConfig", "Sftp2Password", "default", "配置文件/SFTPConfig.ini")
        'Addlog("[Info]SFTP服务器名称:" + Sftp2名称, Color.Blue)
        'Addlog("[Info]SFTP服务器地址:" + Sftp2地址, Color.Blue)
        'Addlog("[Info]SFTP服务器端口:" + Sftp2端口, Color.Blue)
        'Addlog("[Info]SFTP服务器用户名:" + Sftp2用户名, Color.Blue)
        'Addlog("[Info]SFTP服务器密码:" + Sftp2密码, Color.Blue)
        'Addlog("-------------------------------------------------------------------------------------", Color.Black)
        'Sftp3名称 = 配置文件操作.读取配置("SFTPConfig", "Sftp3Name", "SFTP3", "配置文件/SFTPConfig.ini")
        'Sftp3地址 = 配置文件操作.读取配置("SFTPConfig", "Sftp3IP", "127.0.0.1", "配置文件/SFTPConfig.ini")
        'Sftp3端口 = 配置文件操作.读取配置("SFTPConfig", "Sftp3Port", "22", "配置文件/SFTPConfig.ini")
        'Sftp3用户名 = 配置文件操作.读取配置("SFTPConfig", "Sftp3User", "default", "配置文件/SFTPConfig.ini")
        'Sftp3密码 = 配置文件操作.读取配置("SFTPConfig", "Sftp3Password", "default", "配置文件/SFTPConfig.ini")
        'Addlog("[Info]SFTP服务器名称:" + Sftp3名称, Color.Blue)
        'Addlog("[Info]SFTP服务器地址:" + Sftp3地址, Color.Blue)
        'Addlog("[Info]SFTP服务器端口:" + Sftp3端口, Color.Blue)
        'Addlog("[Info]SFTP服务器用户名:" + Sftp3用户名, Color.Blue)
        'Addlog("[Info]SFTP服务器密码:" + Sftp3密码, Color.Blue)
        'Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]服务未启动，尚未实现", Color.Green)
    End Sub
    Private Sub ButtonSightseeing_Click(sender As Object, e As EventArgs) Handles ButtonSightseeing.Click
        Me.IntroductionLabel.Visible = False
        Me.LogsRichTextBox.Visible = False
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
        Me.LogsRichTextBox.Visible = True
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
    Private Sub Addlog(Logs As String, Color As Color)
        LogsRichTextBox.SelectionStart = LogsRichTextBox.Text.Length
        Dim Addlog As String = "[" + Time.ToString("MM-dd HH:mm:ss") + "]:" + Logs + Environment.NewLine
        LogsRichTextBox.SelectionColor = Color
        LogsRichTextBox.AppendText(Addlog)
        LogsRichTextBox.SelectionColor = LogsRichTextBox.ForeColor
        LogsRichTextBox.ScrollToCaret()
        Dim lines As String() = LogsRichTextBox.Lines
        保存日志.SaveLog(Logs)
        If lines.Length > 200 Then
            LogsRichTextBox.Lines = lines.Skip(lines.Length - 200).ToArray()
        End If
    End Sub

    Private Sub ChanegeImageTimer_Tick(sender As Object, e As EventArgs) Handles ChanegeImageTimer.Tick ' 切换图片并重置倒计时
        currentImageIndex = (currentImageIndex + 1) Mod imageFiles.Count
        LoadImage(imageFiles(currentImageIndex))
        nextSwitchTime = DateTime.Now.AddMinutes(1) ' 重置倒计时
        UpdateCountdownDisplay()
    End Sub

    Private Sub PictureBox_Click(sender As Object, e As EventArgs) Handles PictureBox.Click

    End Sub
End Class
Public Class 保存日志
    Private Shared ReadOnly LogDirectory As String = Path.Combine(Application.StartupPath, "日志")
    Private Shared ReadOnly LogFilePath As String = Path.Combine(LogDirectory, $"日志_{DateTime.Now:yyyy-MM-dd}.txt")
    Public Shared Sub SaveLog(Logs As String)
        Try
            Directory.CreateDirectory(LogDirectory)
            Dim LogText As String = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]{Logs}{Environment.NewLine}"
            File.AppendAllText(LogFilePath, LogText, Encoding.UTF8)
        Catch ex As Exception
            MessageBox.Show($"写入日志失败:{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
