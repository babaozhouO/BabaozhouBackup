Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class 主窗口
    Private Time As DateTime
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
    Private Sub 主窗口_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Time = DateTime.Now
        Addlog("[Info]Github仓库链接:https://github.com/babaozhouO/BabaozhouBackup", Color.Black)
        Addlog("[Info]程序启动,V0.1.0-alphav1.0-beta.3", Color.Green)
        Addlog("[Info]正在读取配置文件", Color.Black)
        运行时间 = 配置文件操作.读取配置("MainSettings", "Runtime", "03:00:00", "配置文件/MainConfig.ini")
        RCON服务器 = 配置文件操作.读取配置("RCONConfig", "Server1Name", "Server1", "配置文件/RCONConfig.ini")
        RCON地址 = 配置文件操作.读取配置("RCONConfig", "Server1IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON端口 = 配置文件操作.读取配置("RCONConfig", "Server1Port", "25575", "配置文件/RCONConfig.ini")
        RCON密码 = 配置文件操作.读取配置("RCONConfig", "Server1Password", "空", "配置文件/RCONConfig.ini")
        Addlog("[Info]配置文件读取完成", Color.Green)
        Addlog("[Info]配置文件数据:", Color.Blue)
        Addlog("[Info]运行时间:" + 运行时间, Color.Blue)
        Addlog("[Info]RCON服务器名称:" + RCON服务器, Color.Blue)
        Addlog("[Info]RCON服务器地址:" + RCON地址, Color.Blue)
        Addlog("[Info]RCON服务器端口:" + RCON端口, Color.Blue)
        If RCON密码 = "空" Then
            Addlog("[Warning]RCON服务器密码:未设置", Color.Blue)
        Else
            Addlog("[Info]RCON服务器密码:已设置", Color.Blue)
        End If
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
        Addlog(运行时间, Color.Black)
        Addlog("[Info]服务已启动", Color.Green)
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