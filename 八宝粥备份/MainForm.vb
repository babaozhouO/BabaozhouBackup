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
        日志输出软件信息()
        日志输出主程序配置()
        If 配置文件操作模块.读取配置("RCONCongig", "Server1", "ON", "配置文件/RCONConfig.ini") = "ON" Then
            日志输出RCON1配置()
        End If
        If 配置文件操作模块.读取配置("RCONCongig", "Server2", "OFF", "配置文件/RCONConfig.ini") = "ON" Then
            日志输出RCON2配置()
        End If
        If 配置文件操作模块.读取配置("RCONCongig", "Server3", "OFF", "配置文件/RCONConfig.ini") = "ON" Then
            日志输出RCON3配置()
        End If
        日志输出7zip配置()
        If 配置文件操作模块.读取配置("SFTPConfig", "Sftp1", "ON", "配置文件/SFTPConfig.ini") = "ON" Then
            日志输出sftp1配置()
        End If
        If 配置文件操作模块.读取配置("SFTPConfig", "Sftp2", "OFF", "配置文件/SFTPConfig.ini") = "ON" Then
            日志输出sftp2配置()
        End If
        If 配置文件操作模块.读取配置("SFTPConfig", "Sftp3", "OFF", "配置文件/SFTPConfig.ini") = "ON" Then
            日志输出sftp3配置()
        End If
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
        日志输出主程序配置()
        If 配置文件操作模块.读取配置("RCONCongig", "Server1", "ON", "配置文件/RCONConfig.ini") = "ON" Then
            日志输出RCON1配置()
        End If
        If 配置文件操作模块.读取配置("RCONCongig", "Server2", "OFF", "配置文件/RCONConfig.ini") = "ON" Then
            日志输出RCON2配置()
        End If
        If 配置文件操作模块.读取配置("RCONCongig", "Server3", "OFF", "配置文件/RCONConfig.ini") = "ON" Then
            日志输出RCON3配置()
        End If
        日志输出7zip配置()
        If 配置文件操作模块.读取配置("SFTPConfig", "Sftp1", "ON", "配置文件/SFTPConfig.ini") = "ON" Then
            日志输出sftp1配置()
        End If
        If 配置文件操作模块.读取配置("SFTPConfig", "Sftp2", "OFF", "配置文件/SFTPConfig.ini") = "ON" Then
            日志输出sftp2配置()
        End If
        If 配置文件操作模块.读取配置("SFTPConfig", "Sftp3", "OFF", "配置文件/SFTPConfig.ini") = "ON" Then
            日志输出sftp3配置()
        End If
        Addlog("[ERROR]服务未启动，尚未实现", Color.Green)
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

    Private Sub ChanegeImageTimer_Tick(sender As Object, e As EventArgs) Handles ChanegeImageTimer.Tick ' 切换图片并重置倒计时
        currentImageIndex = (currentImageIndex + 1) Mod imageFiles.Count
        LoadImage(imageFiles(currentImageIndex))
        nextSwitchTime = DateTime.Now.AddMinutes(1) ' 重置倒计时
        UpdateCountdownDisplay()
    End Sub
End Class