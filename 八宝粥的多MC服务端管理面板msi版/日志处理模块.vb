'Copyright 2025 八宝粥(Email:1749861851@qq.com)

'Licensed under the Apache License, Version 2.0 (the "License");
'you may Not use this file except In compliance With the License.
'You may obtain a copy Of the License at

'    http://www.apache.org/licenses/LICENSE-2.0

'Unless required by applicable law Or agreed To In writing, software
'distributed under the License Is distributed On an "AS IS" BASIS,
'WITHOUT WARRANTIES Or CONDITIONS Of ANY KIND, either express Or implied.
'See the License For the specific language governing permissions And
'limitations under the License.
Imports System.IO
Imports System.Text

Module 日志处理模块
    Public ReadOnly Property 日志文件夹 As String = Path.Combine(程序数据目录, "日志")
    Public Class 日志处理功能
        '-----------------------日志文本框绑定功能-----------------------
        Private 日志文本框 As RichTextBox
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
            If 日志文本框.Lines.Length > 2000 Then 截断日志(2000)
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
        End Sub
        '-----------------------保存日志功能-----------------------
        Public Sub 写入日志文件(日志 As String, 当前时间 As DateTime)
            Dim 日志文件目录 As String = Path.Combine(日志文件夹, $"日志_{DateTime.Now:yyyy-MM-dd}.txt")
            Try
                Directory.CreateDirectory(日志文件夹)
                Dim 格式化后日志 As String = "[" + 当前时间.ToString("HH:mm:ss") + "]:" + 日志 + Environment.NewLine
                File.AppendAllText($"{日志文件目录}", 格式化后日志, Encoding.UTF8)
            Catch ex As Exception
                MessageBox.Show($"写入日志失败:{ex.Message}", "你对日志文件干了什么！", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '-----------------------日志输出配置信息功能-----------------------
        Public Sub 日志输出软件信息()
            添加日志("[Info]作者:八宝粥", Color.Black)
            添加日志("[Info]联系方式:邮箱:1749861851@qq.com", Color.Black)
            添加日志("[Info]程序启动,V0.1.0-alphav2.0", Color.Green)
            添加日志("[Warning]未经作者同意，不得删除软件中的作者标识，本软件受开源协议保护"， Color.Red)
            添加日志("[Info]Github仓库链接:https://github.com/babaozhouO/BBZ-MCServers-Manager", Color.Black)
            添加日志("[Info]正在读取配置文件", Color.Black)
        End Sub
        Public Sub 日志输出主程序配置()
            读取主程序配置()
            添加日志("[Info]配置文件读取完成", Color.Green)
            添加日志("[Info]配置文件数据:", Color.Blue)
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]主程序配置:", Color.Blue)
            添加日志("[Info]运行时间:" + 运行时间, Color.Blue)
            添加日志("[Info]每次运行间隔天数: " + 间隔天数, Color.Blue)
            添加日志("[Info]关服备份: " + 是否关服备份.ToString, Color.Blue)
        End Sub
        Public Sub 日志输出MC服务端配置()
            读取MC服务端配置()
            If 是否控制MC服务端1 Then
                日志输出MC服务端1配置()
            End If
            If 是否控制MC服务端2 Then
                日志输出MC服务端2配置()
            End If
            If 是否控制MC服务端3 Then
                日志输出MC服务端3配置()
            End If
            If 是否控制MC服务端4 Then
                日志输出MC服务端4配置()
            End If
            If 是否控制MC服务端5 Then
                日志输出MC服务端5配置()
            End If
            If 是否控制MC服务端6 Then
                日志输出MC服务端6配置()
            End If
            If 是否控制MC服务端7 Then
                日志输出MC服务端7配置()
            End If
            If 是否控制MC服务端8 Then
                日志输出MC服务端8配置()
            End If
            If 是否控制MC服务端9 Then
                日志输出MC服务端9配置()
            End If
            If 是否控制MC服务端10 Then
                日志输出MC服务端10配置()
            End If
            If Not 是否控制MC服务端1 AndAlso Not 是否控制MC服务端2 AndAlso Not 是否控制MC服务端3 AndAlso Not 是否控制MC服务端4 AndAlso Not 是否控制MC服务端5 AndAlso Not 是否控制MC服务端6 AndAlso Not 是否控制MC服务端7 AndAlso Not 是否控制MC服务端8 AndAlso Not 是否控制MC服务端9 AndAlso Not 是否控制MC服务端10 Then
                添加日志("-------------------------------------------------------------------------------------", Color.Black)
                添加日志("[Warning]MC服务端已全部禁用", Color.Orange)
            End If
        End Sub
        Public Sub 日志输出MC服务端1配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]MC服务端1配置:", Color.Blue)
            添加日志("[Info]MC服务端1名称:" + MC服务端1名称, Color.Blue)
            添加日志("[Info]MC服务端1地址:" + RCON1地址, Color.Blue)
            添加日志("[Info]MC服务端1RCON端口:" + RCON1端口, Color.Blue)
            添加日志("[Info]MC服务端1路径:" + MC服务端1路径, Color.Blue)
            添加日志("[Info]MC服务端1启动脚本名称:" + MC服务端1启动脚本名称, Color.Blue)
        End Sub
        Public Sub 日志输出MC服务端2配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]MC服务端2配置:", Color.Blue)
            添加日志("[Info]MC服务端2名称:" + MC服务端2名称, Color.Blue)
            添加日志("[Info]MC服务端2地址:" + RCON2地址, Color.Blue)
            添加日志("[Info]MC服务端2RCON端口:" + RCON2端口, Color.Blue)
            添加日志("[Info]MC服务端2路径:" + MC服务端2路径, Color.Blue)
            添加日志("[Info]MC服务端2启动脚本名称:" + MC服务端2启动脚本名称, Color.Blue)
        End Sub
        Public Sub 日志输出MC服务端3配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]MC服务端3配置:", Color.Blue)
            添加日志("[Info]MC服务端3名称:" + MC服务端3名称, Color.Blue)
            添加日志("[Info]MC服务端3地址:" + RCON3地址, Color.Blue)
            添加日志("[Info]MC服务端3RCON端口:" + RCON3端口, Color.Blue)
            添加日志("[Info]MC服务端3路径:" + MC服务端3路径, Color.Blue)
            添加日志("[Info]MC服务端3启动脚本名称:" + MC服务端3启动脚本名称, Color.Blue)
        End Sub
        Public Sub 日志输出MC服务端4配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]MC服务端4配置:", Color.Blue)
            添加日志("[Info]MC服务端4名称:" + MC服务端4名称, Color.Blue)
            添加日志("[Info]MC服务端4地址:" + RCON4地址, Color.Blue)
            添加日志("[Info]MC服务端4RCON端口:" + RCON4端口, Color.Blue)
            添加日志("[Info]MC服务端4路径:" + MC服务端4路径, Color.Blue)
            添加日志("[Info]MC服务端4启动脚本名称:" + MC服务端4启动脚本名称, Color.Blue)
        End Sub
        Public Sub 日志输出MC服务端5配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]MC服务端5配置:", Color.Blue)
            添加日志("[Info]MC服务端5名称:" + MC服务端5名称, Color.Blue)
            添加日志("[Info]MC服务端5地址:" + RCON5地址, Color.Blue)
            添加日志("[Info]MC服务端5RCON端口:" + RCON5端口, Color.Blue)
            添加日志("[Info]MC服务端5路径:" + MC服务端5路径, Color.Blue)
            添加日志("[Info]MC服务端5启动脚本名称:" + MC服务端5启动脚本名称, Color.Blue)
        End Sub
        Public Sub 日志输出MC服务端6配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]MC服务端6配置:", Color.Blue)
            添加日志("[Info]MC服务端6名称:" + MC服务端6名称, Color.Blue)
            添加日志("[Info]MC服务端6地址:" + RCON6地址, Color.Blue)
            添加日志("[Info]MC服务端6RCON端口:" + RCON6端口, Color.Blue)
            添加日志("[Info]MC服务端6路径:" + MC服务端6路径, Color.Blue)
            添加日志("[Info]MC服务端6启动脚本名称:" + MC服务端6启动脚本名称, Color.Blue)
        End Sub
        Public Sub 日志输出MC服务端7配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]MC服务端7配置:", Color.Blue)
            添加日志("[Info]MC服务端7名称:" + MC服务端7名称, Color.Blue)
            添加日志("[Info]MC服务端7地址:" + RCON7地址, Color.Blue)
            添加日志("[Info]MC服务端7RCON端口:" + RCON7端口, Color.Blue)
            添加日志("[Info]MC服务端7路径:" + MC服务端7路径, Color.Blue)
            添加日志("[Info]MC服务端7启动脚本名称:" + MC服务端7启动脚本名称, Color.Blue)
        End Sub
        Public Sub 日志输出MC服务端8配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]MC服务端8配置:", Color.Blue)
            添加日志("[Info]MC服务端8名称:" + MC服务端8名称, Color.Blue)
            添加日志("[Info]MC服务端8地址:" + RCON8地址, Color.Blue)
            添加日志("[Info]MC服务端8RCON端口:" + RCON8端口, Color.Blue)
            添加日志("[Info]MC服务端8路径:" + MC服务端8路径, Color.Blue)
            添加日志("[Info]MC服务端8启动脚本名称:" + MC服务端8启动脚本名称, Color.Blue)
        End Sub
        Public Sub 日志输出MC服务端9配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]MC服务端9配置:", Color.Blue)
            添加日志("[Info]MC服务端9名称:" + MC服务端9名称, Color.Blue)
            添加日志("[Info]MC服务端9地址:" + RCON9地址, Color.Blue)
            添加日志("[Info]MC服务端9RCON端口:" + RCON9端口, Color.Blue)
            添加日志("[Info]MC服务端9路径:" + MC服务端9路径, Color.Blue)
            添加日志("[Info]MC服务端9启动脚本名称:" + MC服务端9启动脚本名称, Color.Blue)
        End Sub
        Public Sub 日志输出MC服务端10配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]MC服务端10配置:", Color.Blue)
            添加日志("[Info]RCON10服务器名称:" + MC服务端10名称, Color.Blue)
            添加日志("[Info]RCON10服务器地址:" + RCON10地址, Color.Blue)
            添加日志("[Info]RCON10服务器RCON端口:" + RCON10端口, Color.Blue)
            添加日志("[Info]MC服务端10路径:" + MC服务端10路径, Color.Blue)
            添加日志("[Info]MC服务端10启动脚本名称:" + MC服务端10启动脚本名称, Color.Blue)
        End Sub
        Public Sub 日志输出7zip配置()
            读取7zip配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]7zip配置:", Color.Blue)
            添加日志("[Info]压缩格式:" + 压缩格式, Color.Blue)
            添加日志("[Info]压缩等级:" + 压缩级别.ToString, Color.Blue)
            添加日志("[Info]压缩方法:" + 压缩方法, Color.Blue)
            添加日志("[Info]使用的CPU线程数:" + 线程数.ToString, Color.Blue)
            添加日志("[Info]自定义备份目录:" + 自定义备份目录, Color.Blue)
            添加日志("[Info]备份输出目录:" + 备份输出目录, Color.Blue)
            添加日志("[Info}是否备份自定义备份目录:" + 是否备份自定义目录.ToString, Color.Blue)
            添加日志("[Info]增量备份:" + 是否增量备份.ToString, Color.Blue)
        End Sub
        Public Sub 日志输出SFTP配置()
            读取Sftp配置()
            If Sftp1开关 Then
                日志输出sftp1配置()
            End If
            If Sftp2开关 Then
                日志输出sftp2配置()
            End If
            If Sftp3开关 Then
                日志输出sftp3配置()
            End If
            If Not Sftp1开关 AndAlso Not Sftp2开关 AndAlso Not Sftp3开关 Then
                添加日志("-------------------------------------------------------------------------------------", Color.Black)
                添加日志("[Warning]Sftp服务端已全部禁用", Color.Orange)
            End If
        End Sub
        Public Sub 日志输出sftp1配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]SFTP1服务器配置:", Color.Blue)
            添加日志("[Info]SFTP1服务器名称:" + Sftp1名称, Color.Blue)
            添加日志("[Info]SFTP1服务器地址:" + Sftp1地址, Color.Blue)
            添加日志("[Info]SFTP1服务器端口:" + Sftp1端口, Color.Blue)
            添加日志("[Info]SFTP1服务器用户名:" + Sftp1用户名, Color.Blue)
            添加日志("[Info]SFTP1服务器密码:" + Sftp1密码, Color.Blue)
        End Sub
        Public Sub 日志输出sftp2配置()
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[Info]SFTP2服务器配置:", Color.Blue)
            添加日志("[Info]SFTP2服务器名称:" + Sftp2名称, Color.Blue)
            添加日志("[Info]SFTP2服务器地址:" + Sftp2地址, Color.Blue)
            添加日志("[Info]SFTP2服务器端口:" + Sftp2端口, Color.Blue)
            添加日志("[Info]SFTP2服务器用户名:" + Sftp2用户名, Color.Blue)
            添加日志("[Info]SFTP2服务器密码:" + Sftp2密码, Color.Blue)
        End Sub
        Public Sub 日志输出sftp3配置()
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
