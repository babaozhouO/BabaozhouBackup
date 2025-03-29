Imports System.IO
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
        LogsSave.SaveLog(Logs)
        If lines.Length > 1000 Then
            LogsRichTextBox.Lines = lines.Skip(lines.Length - 1000).ToArray()
        End If
    End Sub
    Private Sub 主窗口_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Time = DateTime.Now
        Addlog("[Info]Github仓库链接:https://github.com/babaozhouO/BabaozhouBackup", Color.Black)
        Addlog("[Info]程序启动", Color.Green)
        Addlog("[Info]正在读取配置文件", Color.Black)
        Addlog("[Error]读取配置文件失败", Color.Red)
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
        ServiceForm.Show()
    End Sub

    Private Sub NowTimer_Tick(sender As Object, e As EventArgs) Handles NowTimer.Tick
        Time = DateTime.Now
    End Sub

    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        Addlog("[Action]打开主程序配置界面", Color.Green)
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
End Class
Public Class LogsSave
    Private Shared ReadOnly LogDirectory As String = Path.Combine(Application.StartupPath, "Logs")
    Private Shared ReadOnly LogFilePath As String = Path.Combine(LogDirectory, $"Logs_{DateTime.Now:yyyy-MM-dd}.txt")
    Public Shared Sub SaveLog(Logs As String)
        Try
            Directory.CreateDirectory(LogDirectory)
            Dim LogFile As String = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]{Logs}{Environment.NewLine}"
            File.AppendAllText(LogFilePath, LogFile, Encoding.UTF8)
        Catch ex As Exception
            Debug.WriteLine($"写入日志失败:{ex.Message}")
        End Try
    End Sub

End Class