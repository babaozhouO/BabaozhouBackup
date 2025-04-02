Imports System.IO
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock

Module 日志处理模块
    '-----------------------添加日志功能-----------------------
    Public Sub Addlog(Logs As String, Color As Color)
        Dim Time As DateTime = DateTime.Now
        主窗口.LogsRichTextBox.SelectionStart = 主窗口.LogsRichTextBox.Text.Length
        Dim Addlog As String = "[" + Time.ToString("MM-dd HH:mm:ss") + "]:" + Logs + Environment.NewLine
        主窗口.LogsRichTextBox.SelectionColor = Color
        主窗口.LogsRichTextBox.AppendText(Addlog)
        主窗口.LogsRichTextBox.SelectionColor = 主窗口.LogsRichTextBox.ForeColor
        主窗口.LogsRichTextBox.ScrollToCaret()
        Dim lines As String() = 主窗口.LogsRichTextBox.Lines
        保存日志.SaveLog(Logs)
        If lines.Length > 200 Then
            主窗口.LogsRichTextBox.Lines = lines.Skip(lines.Length - 200).ToArray()
        End If
    End Sub
    '-----------------------保存日志功能-----------------------
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
    Public Sub 日志输出软件信息()
        Addlog("[Info]Github仓库链接:https://github.com/babaozhouO/BabaozhouBackup", Color.Black)
        Addlog("[Info]作者:八宝粥", Color.Black)
        Addlog("[Info]联系方式:QQEmail:1749861851@qq.com", Color.Black)
        Addlog("未经作者同意，不得删除软件中的作者标识，本软件受开源协议保护"， Color.Red)
        Addlog("[Info]程序启动,V0.1.0-alphav1.0-beta.5", Color.Green)
        Addlog("[Info]正在读取配置文件", Color.Black)
    End Sub
    Public Sub 日志输出主程序配置()
        读取主程序配置()
        Addlog("[Info]配置文件读取完成", Color.Green)
        Addlog("[Info]配置文件数据:", Color.Blue)
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]主程序配置:", Color.Blue)
        Addlog("[Info]运行时间:" + 运行时间, Color.Blue)
    End Sub
    Public Sub 日志输出RCON1配置()
        读取RCON1配置()
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]RCON1服务器配置:", Color.Blue)
        Addlog("[Info]RCON1服务器名称:" + RCON1服务器, Color.Blue)
        Addlog("[Info]RCON1服务器地址:" + RCON1地址, Color.Blue)
        Addlog("[Info]RCON1服务器端口:" + RCON1端口, Color.Blue)
    End Sub
    Public Sub 日志输出RCON2配置()
        读取RCON2配置()
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]RCON2服务器配置:", Color.Blue)
        Addlog("[Info]RCON2服务器名称:" + RCON2服务器, Color.Blue)
        Addlog("[Info]RCON2服务器地址:" + RCON2地址, Color.Blue)
        Addlog("[Info]RCON2服务器端口:" + RCON2端口, Color.Blue)
    End Sub
    Public Sub 日志输出RCON3配置()
        读取RCON3配置()
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]RCON3服务器配置:", Color.Blue)
        Addlog("[Info]RCON3服务器名称:" + RCON3服务器, Color.Blue)
        Addlog("[Info]RCON3服务器地址:" + RCON3地址, Color.Blue)
        Addlog("[Info]RCON3服务器端口:" + RCON3端口, Color.Blue)
    End Sub
    Public Sub 日志输出7zip配置()
        读取7zip配置()
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]7zip配置:", Color.Blue)
        Addlog("[Info]压缩格式:" + 压缩格式, Color.Blue)
        Addlog("[Info]压缩等级:" + 压缩等级, Color.Blue)
        Addlog("[Info]压缩密码:" + 压缩密码, Color.Blue)
    End Sub
    Public Sub 日志输出sftp1配置()
        读取Sftp1配置()
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]SFTP1服务器配置:", Color.Blue)
        Addlog("[Info]SFTP1服务器名称:" + Sftp1名称, Color.Blue)
        Addlog("[Info]SFTP1服务器地址:" + Sftp1地址, Color.Blue)
        Addlog("[Info]SFTP1服务器端口:" + Sftp1端口, Color.Blue)
        Addlog("[Info]SFTP1服务器用户名:" + Sftp1用户名, Color.Blue)
        Addlog("[Info]SFTP1服务器密码:" + Sftp1密码, Color.Blue)
    End Sub
    Public Sub 日志输出sftp2配置()
        读取Sftp2配置()
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]SFTP2服务器配置:", Color.Blue)
        Addlog("[Info]SFTP2服务器名称:" + Sftp2名称, Color.Blue)
        Addlog("[Info]SFTP2服务器地址:" + Sftp2地址, Color.Blue)
        Addlog("[Info]SFTP2服务器端口:" + Sftp2端口, Color.Blue)
        Addlog("[Info]SFTP2服务器用户名:" + Sftp2用户名, Color.Blue)
        Addlog("[Info]SFTP2服务器密码:" + Sftp2密码, Color.Blue)
    End Sub
    Public Sub 日志输出sftp3配置()
        读取Sftp3配置()
        Addlog("-------------------------------------------------------------------------------------", Color.Black)
        Addlog("[Info]SFTP3服务器配置:", Color.Blue)
        Addlog("[Info]SFTP3服务器名称:" + Sftp3名称, Color.Blue)
        Addlog("[Info]SFTP3服务器地址:" + Sftp3地址, Color.Blue)
        Addlog("[Info]SFTP3服务器端口:" + Sftp3端口, Color.Blue)
        Addlog("[Info]SFTP3服务器用户名:" + Sftp3用户名, Color.Blue)
        Addlog("[Info]SFTP3服务器密码:" + Sftp3密码, Color.Blue)
    End Sub
End Module
