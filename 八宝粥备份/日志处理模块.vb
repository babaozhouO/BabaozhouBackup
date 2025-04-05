' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Imports System.Drawing.Text
Imports System.IO
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock

Module 日志处理模块
    Public Class 日志处理功能
        '-----------------------日志文本框绑定功能-----------------------
        Private WithEvents 日志文本框 As RichTextBox
        Public Sub 绑定文本框(要绑定的文本框 As RichTextBox)
            日志文本框 = 要绑定的文本框
        End Sub
        '-----------------------添加日志功能-----------------------
        Public Sub 添加日志(日志文本 As String, 日志文本颜色 As Color)
            Dim 当前时间 As DateTime = DateTime.Now
            写入日志文件(日志文本, 当前时间)
            日志文本框.SelectionStart = 日志文本框.Text.Length
            Dim 处理后的日志 As String = "[" + 当前时间.ToString("MM-dd HH:mm:ss") + "]:" + 日志文本 + Environment.NewLine
            日志文本框.SelectionColor = 日志文本颜色
            日志文本框.AppendText(处理后的日志)
            日志文本框.SelectionColor = 日志文本框.ForeColor
            If 日志文本框.Lines.Length > 500 Then
                截断日志(500)
            End If
            日志文本框.ScrollToCaret()
        End Sub
        '-----------------------截断日志功能-----------------------
        Public Sub 截断日志(最大保留行数 As Integer）
            If 日志文本框.Lines.Length <= 最大保留行数 Then Return
            Dim 需要移除的行数 As Integer = 日志文本框.Lines.Length - 最大保留行数
            Dim 首行结束位置 As Integer = 日志文本框.GetFirstCharIndexFromLine(需要移除的行数)
            日志文本框.Select(0, 首行结束位置)
            日志文本框.SelectedText = ""
            日志文本框.SelectionStart = 日志文本框.Text.Length
            日志文本框.ScrollToCaret()
        End Sub
        '-----------------------保存日志功能-----------------------
        Public Sub 写入日志文件(日志 As String, 当前时间 As DateTime)
            Dim 日志文件夹 As String = "C:\ProgramData\八宝粥的单人团队\八宝粥备份\日志"
            Dim 日志文件目录 As String = Path.Combine(日志文件夹, $"日志_{DateTime.Now:yyyy-MM-dd}.txt")
            Try
                Directory.CreateDirectory(日志文件夹)
                Dim 格式化后日志 As String = "[" + 当前时间.ToString("HH:mm:ss") + "]:" + 日志 + Environment.NewLine
                File.AppendAllText($"{日志文件目录}", 格式化后日志, Encoding.UTF8)
            Catch ex As Exception
                MessageBox.Show($"写入日志失败:{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '-----------------------日志输出配置信息功能-----------------------
        Public Sub 日志输出软件信息()
            添加日志("[Info]Github仓库链接:https://github.com/babaozhouO/BabaozhouBackup", Color.Black)
            添加日志("[Info]作者:八宝粥", Color.Black)
            添加日志("[Info]联系方式:QQEmail:1749861851@qq.com", Color.Black)
            添加日志("未经作者同意，不得删除软件中的作者标识，本软件受开源协议保护"， Color.Red)
            添加日志("[Info]程序启动,V0.1.0-alphav1.0-beta.9", Color.Green)
            添加日志("[Info]正在读取配置文件", Color.Black)
        End Sub
        Public Sub 日志输出主程序配置()
            读取主程序配置()
            添加日志("[Info]配置文件读取完成", Color.Green)
            添加日志("[Info]配置文件数据:", Color.Blue)
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]主程序配置:", Color.Blue)
            添加日志("[Info]运行时间:" + 运行时间, Color.Blue)
        End Sub
        Public Sub 日志输出RCON配置()
            读取RCON配置()
            If RCON1开关 = "ON" Then
                日志输出RCON1配置()
            End If
            If RCON2开关 = "ON" Then
                日志输出RCON2配置()
            End If
            If RCON3开关 = "ON" Then
                日志输出RCON3配置()
            End If
            If RCON4开关 = "ON" Then
                日志输出RCON4配置()
            End If
            If RCON5开关 = "ON" Then
                日志输出RCON5配置()
            End If
            If RCON6开关 = "ON" Then
                日志输出RCON6配置()
            End If
            If RCON7开关 = "ON" Then
                日志输出RCON7配置()
            End If
            If RCON8开关 = "ON" Then
                日志输出RCON8配置()
            End If
            If RCON9开关 = "ON" Then
                日志输出RCON9配置()
            End If
            If RCON10开关 = "ON" Then
                日志输出RCON10配置()
            End If
        End Sub
        Public Sub 日志输出RCON1配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]RCON1服务器配置:", Color.Blue)
            添加日志("[Info]RCON1服务器名称:" + RCON1名称, Color.Blue)
            添加日志("[Info]RCON1服务器地址:" + RCON1地址, Color.Blue)
            添加日志("[Info]RCON1服务器端口:" + RCON1端口, Color.Blue)
        End Sub
        Public Sub 日志输出RCON2配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]RCON2服务器配置:", Color.Blue)
            添加日志("[Info]RCON2服务器名称:" + RCON2名称, Color.Blue)
            添加日志("[Info]RCON2服务器地址:" + RCON2地址, Color.Blue)
            添加日志("[Info]RCON2服务器端口:" + RCON2端口, Color.Blue)
        End Sub
        Public Sub 日志输出RCON3配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]RCON3服务器配置:", Color.Blue)
            添加日志("[Info]RCON3服务器名称:" + RCON3名称, Color.Blue)
            添加日志("[Info]RCON3服务器地址:" + RCON3地址, Color.Blue)
            添加日志("[Info]RCON3服务器端口:" + RCON3端口, Color.Blue)
        End Sub
        Public Sub 日志输出RCON4配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]RCON4服务器配置:", Color.Blue)
            添加日志("[Info]RCON4服务器名称:" + RCON4名称, Color.Blue)
            添加日志("[Info]RCON4服务器地址:" + RCON4地址, Color.Blue)
            添加日志("[Info]RCON4服务器端口:" + RCON4端口, Color.Blue)
        End Sub
        Public Sub 日志输出RCON5配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]RCON5服务器配置:", Color.Blue)
            添加日志("[Info]RCON5服务器名称:" + RCON5名称, Color.Blue)
            添加日志("[Info]RCON5服务器地址:" + RCON5地址, Color.Blue)
            添加日志("[Info]RCON5服务器端口:" + RCON5端口, Color.Blue)
        End Sub
        Public Sub 日志输出RCON6配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]RCON6服务器配置:", Color.Blue)
            添加日志("[Info]RCON6服务器名称:" + RCON6名称, Color.Blue)
            添加日志("[Info]RCON6服务器地址:" + RCON6地址, Color.Blue)
            添加日志("[Info]RCON6服务器端口:" + RCON6端口, Color.Blue)
        End Sub
        Public Sub 日志输出RCON7配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]RCON7服务器配置:", Color.Blue)
            添加日志("[Info]RCON7服务器名称:" + RCON7名称, Color.Blue)
            添加日志("[Info]RCON7服务器地址:" + RCON7地址, Color.Blue)
            添加日志("[Info]RCON7服务器端口:" + RCON7端口, Color.Blue)
        End Sub
        Public Sub 日志输出RCON8配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]RCON8服务器配置:", Color.Blue)
            添加日志("[Info]RCON8服务器名称:" + RCON8名称, Color.Blue)
            添加日志("[Info]RCON8服务器地址:" + RCON8地址, Color.Blue)
            添加日志("[Info]RCON8服务器端口:" + RCON8端口, Color.Blue)
        End Sub
        Public Sub 日志输出RCON9配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]RCON9服务器配置:", Color.Blue)
            添加日志("[Info]RCON9服务器名称:" + RCON9名称, Color.Blue)
            添加日志("[Info]RCON9服务器地址:" + RCON9地址, Color.Blue)
            添加日志("[Info]RCON9服务器端口:" + RCON9端口, Color.Blue)
        End Sub
        Public Sub 日志输出RCON10配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]RCON10服务器配置:", Color.Blue)
            添加日志("[Info]RCON10服务器名称:" + RCON10名称, Color.Blue)
            添加日志("[Info]RCON10服务器地址:" + RCON10地址, Color.Blue)
            添加日志("[Info]RCON10服务器端口:" + RCON10端口, Color.Blue)
        End Sub
        Public Sub 日志输出7zip配置()
            读取7zip配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]7zip配置:", Color.Blue)
            添加日志("[Info]压缩格式:" + 压缩格式, Color.Blue)
            添加日志("[Info]压缩等级:" + 压缩级别, Color.Blue)
        End Sub
        Public Sub 日志输出SFTP配置()
            读取Sftp配置()
            If Sftp1开关 = "ON" Then
                日志输出sftp1配置()
            End If
            If Sftp2开关 = "ON" Then
                日志输出sftp2配置()
            End If
            If Sftp3开关 = "ON" Then
                日志输出sftp3配置()
            End If
        End Sub
        Public Sub 日志输出sftp1配置()
            读取Sftp1配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]SFTP1服务器配置:", Color.Blue)
            添加日志("[Info]SFTP1服务器名称:" + Sftp1名称, Color.Blue)
            添加日志("[Info]SFTP1服务器地址:" + Sftp1地址, Color.Blue)
            添加日志("[Info]SFTP1服务器端口:" + Sftp1端口, Color.Blue)
            添加日志("[Info]SFTP1服务器用户名:" + Sftp1用户名, Color.Blue)
            添加日志("[Info]SFTP1服务器密码:" + Sftp1密码, Color.Blue)
        End Sub
        Public Sub 日志输出sftp2配置()
            读取Sftp2配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]SFTP2服务器配置:", Color.Blue)
            添加日志("[Info]SFTP2服务器名称:" + Sftp2名称, Color.Blue)
            添加日志("[Info]SFTP2服务器地址:" + Sftp2地址, Color.Blue)
            添加日志("[Info]SFTP2服务器端口:" + Sftp2端口, Color.Blue)
            添加日志("[Info]SFTP2服务器用户名:" + Sftp2用户名, Color.Blue)
            添加日志("[Info]SFTP2服务器密码:" + Sftp2密码, Color.Blue)
        End Sub
        Public Sub 日志输出sftp3配置()
            读取Sftp3配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]SFTP3服务器配置:", Color.Blue)
            添加日志("[Info]SFTP3服务器名称:" + Sftp3名称, Color.Blue)
            添加日志("[Info]SFTP3服务器地址:" + Sftp3地址, Color.Blue)
            添加日志("[Info]SFTP3服务器端口:" + Sftp3端口, Color.Blue)
            添加日志("[Info]SFTP3服务器用户名:" + Sftp3用户名, Color.Blue)
            添加日志("[Info]SFTP3服务器密码:" + Sftp3密码, Color.Blue)
        End Sub
    End Class
End Module
