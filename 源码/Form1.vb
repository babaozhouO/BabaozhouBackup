Public Class 主窗口
    Private time As DateTime
    Private Sub 主窗口_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        time = DateTime.Now
        Addlog("程序启动")
        Addlog("正在读取配置文件")
    End Sub
    Private Sub Addlog(message As String)
        Dim Addlog As String = "[" + time.ToString("MM-dd HH:mm:ss") + "]: " + message + Environment.NewLine
        LogsTextBox.AppendText(Addlog)
        LogsTextBox.ScrollToCaret()
        LogsTextBox.SelectionStart = LogsTextBox.Text.Length
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        End
    End Sub

    Private Sub ClearlogButton_Click(sender As Object, e As EventArgs) Handles ClearlogButton.Click
        LogsTextBox.Text = ""
        Addlog("已清空日志")
    End Sub

    Private Sub ServiceButton_Click(sender As Object, e As EventArgs) Handles ServiceButton.Click
        Addlog("打开安装/卸载系统服务窗口")
    End Sub

    Private Sub NowTimer_Tick(sender As Object, e As EventArgs) Handles NowTimer.Tick
        time = DateTime.Now
    End Sub

    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        Addlog("打开主程序配置界面")
    End Sub

    Private Sub Button7z_Click(sender As Object, e As EventArgs) Handles Button7z.Click
        Addlog("打开7z压缩程序配置界面")
    End Sub

    Private Sub sftpButton_Click(sender As Object, e As EventArgs) Handles SftpButton.Click
        Addlog("打开内置sftp客户端配置界面")
    End Sub

    Private Sub TestsftpButton_Click(sender As Object, e As EventArgs) Handles TestsftpButton.Click
        Addlog("正在测试sftp服务器连接")
    End Sub
End Class