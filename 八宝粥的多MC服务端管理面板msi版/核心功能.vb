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
Imports System.Threading
Imports System.IO
Public Module 核心功能实例
    Private Sub 添加日志(信息 As String, 颜色 As Color)
        If 日志窗口.InvokeRequired Then
            日志窗口.Invoke(Sub() 日志窗口.添加日志(信息, 颜色))
        Else
            日志窗口.添加日志(信息, 颜色)
        End If
    End Sub
    Public Class 间隔任务调度器
        ' 示例：每隔7天在午夜执行（每周任务）
        'Dim 周任务 As New 间隔任务调度器(7, "23:59:59")
        Private 定时器 As Timer
        Private 间隔天数 As Integer
        Private 每日执行时间 As TimeSpan
        Public 服务运行状态 As Boolean = False
        ' 初始化间隔任务
        ' 使用时间字符串初始化（格式："HH:mm:ss"）
        Public Sub New(间隔天 As Integer, 时间文本 As String)
            If 间隔天 < 1 Then 添加日志("[Error]间隔天数不能小于1", Color.Red) : Return
            If Not TimeSpan.TryParse(时间文本, 每日执行时间) Then
                添加日志("[Error]时间格式不正确，请使用HH:mm:ss格式", Color.Red)
                Return
            End If
            间隔天数 = 间隔天
            添加日志($"[Success]执行时间成功传入，间隔天数：{间隔天数}，每日执行时间：{每日执行时间}", Color.Green)
            启动调度器()
        End Sub
        Private Sub 启动调度器()
            添加日志("[Info]正在计算下一次执行时间", Color.Black)
            Dim 下次时间 = 计算下次执行时间()
            If 下次时间 = DateTime.MinValue Then Return
            定时器 = New Timer(AddressOf 定时回调, Nothing, 下次时间 - DateTime.Now, Timeout.InfiniteTimeSpan)
        End Sub
        Private Function 计算下次执行时间() As DateTime
            Dim 当前时间 = DateTime.Now
            Dim 基准时间 = 当前时间.Date.Add(每日执行时间)
            Dim 安全计数器 As Integer = 0
            Const 最大天数 = 30 ' 防止死循环
            ' 计算符合间隔的最近执行时间
            While 安全计数器 < 最大天数
                If 基准时间 > 当前时间 Then
                    If 是否符合间隔天数(基准时间) Then
                        Return 基准时间
                    End If
                End If
                基准时间 = 基准时间.AddDays(1)
                安全计数器 += 1
            End While
            添加日志("[Error]计算下次执行时间失败，可能是间隔天数设置不正确", Color.Red)
            Return DateTime.MinValue
        End Function
        Private Function 是否符合间隔天数(时间 As DateTime) As Boolean
            Dim 起始时间 = New DateTime(2020, 1, 1) ' 固定基准日期
            Dim 天数差 = (时间.Date - 起始时间.Date).Days
            Return 天数差 Mod 间隔天数 = 0
        End Function
        Private Sub 定时回调(状态 As Object)
            Try
                核心功能()
            Catch
                添加日志("[Error]执行任务时发生异常", Color.Red)
            Finally
                Dim 下次时间 = 计算下次执行时间()

                定时器.Change(下次时间 - DateTime.Now, Timeout.InfiniteTimeSpan)
            End Try
        End Sub
        Public Sub 停止任务()
            定时器?.Dispose()
        End Sub

    End Class
    Public Sub 核心功能()
        If MainForm.InvokeRequired Then
            MainForm.Invoke(Sub() MainForm.服务运行时更改控件状态(True))
        Else
            MainForm.Invoke(Sub() MainForm.服务运行时更改控件状态(True))
        End If
        Try
            If 是否关服备份 Then
                If RCON关闭MC服务器() Then
                    添加日志("[Info]阻塞线程1分钟，等待MC服务端彻底关闭", Color.Orange)
                    Thread.Sleep(60000)
                    备份MC服务端()
                    启动MC服务器()
                    向Sftp服务器上传MC服务端备份文件()
                End If
            Else
                If RCON停止服务端自动保存() Then
                    备份MC服务端()
                    向Sftp服务器上传MC服务端备份文件()
                End If
                If 备份自定义目录() Then
                    Sftp上传自定义备份文件()
                End If
            End If
        Catch ex As Exception
            添加日志($"[ERROR]执行任务时发生错误:{ex.Message}", Color.Red)
        End Try
        If MainForm.InvokeRequired Then
            MainForm.Invoke(Sub() MainForm.服务运行时更改控件状态(False))
            MainForm.Invoke(Sub() MainForm.StopButton.Enabled = False)
        Else
            MainForm.Invoke(Sub() MainForm.服务运行时更改控件状态(False))
            MainForm.Invoke(Sub() MainForm.StopButton.Enabled = False)
        End If
    End Sub
    Private Function RCON关闭MC服务器() As Boolean
        Dim 任务列表 As New List(Of Integer)
        If 是否控制MC服务端1 Then
            任务列表.Add(1)
            处理单个服务器(RCON1地址, RCON1端口, RCON1密码, "stop", "1")
        End If
        If 是否控制MC服务端2 Then
            任务列表.Add(2)
            处理单个服务器(RCON2地址, RCON2端口, RCON2密码, "stop", "2")
        End If
        If 是否控制MC服务端3 Then
            任务列表.Add(3)
            处理单个服务器(RCON3地址, RCON3端口, RCON3密码, "stop", "3")
        End If
        If 是否控制MC服务端4 Then
            任务列表.Add(4)
            处理单个服务器(RCON4地址, RCON4端口, RCON4密码, "stop", "4")
        End If
        If 是否控制MC服务端5 Then
            任务列表.Add(5)
            处理单个服务器(RCON5地址, RCON5端口, RCON5密码, "stop", "5")
        End If
        If 是否控制MC服务端6 Then
            任务列表.Add(6)
            处理单个服务器(RCON6地址, RCON6端口, RCON6密码, "stop", "6")
        End If
        If 是否控制MC服务端7 Then
            任务列表.Add(7)
            处理单个服务器(RCON7地址, RCON7端口, RCON7密码, "stop", "7")
        End If
        If 是否控制MC服务端8 Then
            任务列表.Add(8)
            处理单个服务器(RCON8地址, RCON8端口, RCON8密码, "stop", "8")
        End If
        If 是否控制MC服务端9 Then
            任务列表.Add(9)
            处理单个服务器(RCON9地址, RCON9端口, RCON9密码, "stop", "9")
        End If
        If 是否控制MC服务端10 Then
            任务列表.Add(10)
            处理单个服务器(RCON10地址, RCON10端口, RCON10密码, "stop", "10")
        End If
        If 任务列表.Count = 0 Then
            添加日志("[Info]没有控制中的MC服务器,已自动跳过", Color.DarkGreen)
            Return False
        Else
            Return True
        End If
    End Function
    Private Function RCON停止服务端自动保存() As Boolean
        Dim 任务列表 As New List(Of Integer)
        If 是否控制MC服务端1 Then
            任务列表.Add(1)
            处理单个服务器(RCON1地址, RCON1端口, RCON1密码, "save off", "1")
            处理单个服务器(RCON1地址, RCON1端口, RCON1密码, "save all", "1")
        End If
        If 是否控制MC服务端2 Then
            任务列表.Add(2)
            处理单个服务器(RCON2地址, RCON2端口, RCON2密码, "save off", "2")
            处理单个服务器(RCON2地址, RCON2端口, RCON2密码, "save all", "2")
        End If
        If 是否控制MC服务端3 Then
            任务列表.Add(3)
            处理单个服务器(RCON3地址, RCON3端口, RCON3密码, "save off", "3")
            处理单个服务器(RCON3地址, RCON3端口, RCON3密码, "save all", "3")
        End If
        If 是否控制MC服务端4 Then
            任务列表.Add(4)
            处理单个服务器(RCON4地址, RCON4端口, RCON4密码, "save off", "4")
            处理单个服务器(RCON4地址, RCON4端口, RCON4密码, "save all", "4")
        End If
        If 是否控制MC服务端5 Then
            任务列表.Add(5)
            处理单个服务器(RCON5地址, RCON5端口, RCON5密码, "save off", "5")
            处理单个服务器(RCON5地址, RCON5端口, RCON5密码, "save all", "5")
        End If
        If 是否控制MC服务端6 Then
            任务列表.Add(6)
            处理单个服务器(RCON6地址, RCON6端口, RCON6密码, "save off", "6")
            处理单个服务器(RCON6地址, RCON6端口, RCON6密码, "save all", "6")
        End If
        If 是否控制MC服务端7 Then
            任务列表.Add(7)
            处理单个服务器(RCON7地址, RCON7端口, RCON7密码, "save off", "7")
            处理单个服务器(RCON7地址, RCON7端口, RCON7密码, "save all", "7")
        End If
        If 是否控制MC服务端8 Then
            任务列表.Add(8)
            处理单个服务器(RCON8地址, RCON8端口, RCON8密码, "save off", "8")
            处理单个服务器(RCON8地址, RCON8端口, RCON8密码, "save all", "8")
        End If
        If 是否控制MC服务端9 Then
            任务列表.Add(9)
            处理单个服务器(RCON9地址, RCON9端口, RCON9密码, "save off", "9")
            处理单个服务器(RCON9地址, RCON9端口, RCON9密码, "save all", "9")
        End If
        If 是否控制MC服务端10 Then
            任务列表.Add(10)
            处理单个服务器(RCON10地址, RCON10端口, RCON10密码, "save off", "10")
            处理单个服务器(RCON10地址, RCON10端口, RCON10密码, "save all", "10")
        End If
        If 任务列表.Count = 0 Then
            添加日志("[Info]没有控制中的MC服务器,已自动跳过", Color.DarkGreen)
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub 备份MC服务端()
        If 是否增量备份 Then
            ' 执行增量备份
            If 备份输出目录 = "" Then 添加日志("[ERROR]备份输出目录不能为空", Color.Red) : Return
            Dim 备份路径 = Path.Combine(备份输出目录, "增量备份")
            If Not Directory.Exists(备份路径) Then Directory.CreateDirectory(备份路径)
            Dim 增量备份实例 As New 增量备份管理器()
            If 是否控制MC服务端1 Then 增量备份实例.执行增量备份(MC服务端1路径, Path.Combine(备份路径, "RCON1备份"), "RCON1增量备份", 备份MC服务端1排除文件参数)
            If 是否控制MC服务端2 Then 增量备份实例.执行增量备份(MC服务端2路径, Path.Combine(备份路径, "RCON2备份"), "RCON2增量备份", 备份MC服务端2排除文件参数)
            If 是否控制MC服务端3 Then 增量备份实例.执行增量备份(MC服务端3路径, Path.Combine(备份路径, "RCON3备份"), "RCON3增量备份", 备份MC服务端3排除文件参数)
            If 是否控制MC服务端4 Then 增量备份实例.执行增量备份(MC服务端4路径, Path.Combine(备份路径, "RCON4备份"), "RCON4增量备份", 备份MC服务端4排除文件参数)
            If 是否控制MC服务端5 Then 增量备份实例.执行增量备份(MC服务端5路径, Path.Combine(备份路径, "RCON5备份"), "RCON5增量备份", 备份MC服务端5排除文件参数)
            If 是否控制MC服务端6 Then 增量备份实例.执行增量备份(MC服务端6路径, Path.Combine(备份路径, "RCON6备份"), "RCON6增量备份", 备份MC服务端6排除文件参数)
            If 是否控制MC服务端7 Then 增量备份实例.执行增量备份(MC服务端7路径, Path.Combine(备份路径, "RCON7备份"), "RCON7增量备份", 备份MC服务端7排除文件参数)
            If 是否控制MC服务端8 Then 增量备份实例.执行增量备份(MC服务端8路径, Path.Combine(备份路径, "RCON8备份"), "RCON8增量备份", 备份MC服务端8排除文件参数)
            If 是否控制MC服务端9 Then 增量备份实例.执行增量备份(MC服务端9路径, Path.Combine(备份路径, "RCON9备份"), "RCON9增量备份", 备份MC服务端9排除文件参数)
            If 是否控制MC服务端10 Then 增量备份实例.执行增量备份(MC服务端10路径, Path.Combine(备份路径, "RCON10备份"), "RCON10增量备份", 备份MC服务端10排除文件参数)
        Else
            If 备份输出目录 = "" Then 添加日志("[ERROR]备份输出目录不能为空", Color.Red) : Return
            ' 执行完整备份
            Dim 备份路径 = Path.Combine(备份输出目录, "完整备份")
            If Not Directory.Exists(备份路径) Then Directory.CreateDirectory(备份路径)
            Dim 完整备份实例 As New 完整备份管理器()
            If 是否控制MC服务端1 Then 完整备份实例.执行完整备份(MC服务端1路径, Path.Combine(备份路径, "RCON1备份"), "RCON1完整备份", 备份MC服务端1排除文件参数)
            If 是否控制MC服务端2 Then 完整备份实例.执行完整备份(MC服务端2路径, Path.Combine(备份路径, "RCON2备份"), "RCON2完整备份", 备份MC服务端2排除文件参数)
            If 是否控制MC服务端3 Then 完整备份实例.执行完整备份(MC服务端3路径, Path.Combine(备份路径, "RCON3备份"), "RCON3完整备份", 备份MC服务端3排除文件参数)
            If 是否控制MC服务端4 Then 完整备份实例.执行完整备份(MC服务端4路径, Path.Combine(备份路径, "RCON4备份"), "RCON4完整备份", 备份MC服务端4排除文件参数)
            If 是否控制MC服务端5 Then 完整备份实例.执行完整备份(MC服务端5路径, Path.Combine(备份路径, "RCON5备份"), "RCON5完整备份", 备份MC服务端5排除文件参数)
            If 是否控制MC服务端6 Then 完整备份实例.执行完整备份(MC服务端6路径, Path.Combine(备份路径, "RCON6备份"), "RCON6完整备份", 备份MC服务端6排除文件参数)
            If 是否控制MC服务端7 Then 完整备份实例.执行完整备份(MC服务端7路径, Path.Combine(备份路径, "RCON7备份"), "RCON7完整备份", 备份MC服务端7排除文件参数)
            If 是否控制MC服务端8 Then 完整备份实例.执行完整备份(MC服务端8路径, Path.Combine(备份路径, "RCON8备份"), "RCON8完整备份", 备份MC服务端8排除文件参数)
            If 是否控制MC服务端9 Then 完整备份实例.执行完整备份(MC服务端9路径, Path.Combine(备份路径, "RCON9备份"), "RCON9完整备份", 备份MC服务端9排除文件参数)
            If 是否控制MC服务端10 Then 完整备份实例.执行完整备份(MC服务端10路径, Path.Combine(备份路径, "RCON10备份"), "RCON10完整备份", 备份MC服务端10排除文件参数)
        End If
    End Sub
    Public Sub 启动MC服务器()
        If 是否控制MC服务端1 Then 启动单个MC服务器(MC服务端1启动脚本名称, "1")
        If 是否控制MC服务端2 Then 启动单个MC服务器(MC服务端2启动脚本名称, "2")
        If 是否控制MC服务端3 Then 启动单个MC服务器(MC服务端3启动脚本名称, "3")
        If 是否控制MC服务端4 Then 启动单个MC服务器(MC服务端4启动脚本名称, "4")
        If 是否控制MC服务端5 Then 启动单个MC服务器(MC服务端5启动脚本名称, "5")
        If 是否控制MC服务端6 Then 启动单个MC服务器(MC服务端6启动脚本名称, "6")
        If 是否控制MC服务端7 Then 启动单个MC服务器(MC服务端7启动脚本名称, "7")
        If 是否控制MC服务端8 Then 启动单个MC服务器(MC服务端8启动脚本名称, "8")
        If 是否控制MC服务端9 Then 启动单个MC服务器(MC服务端9启动脚本名称, "9")
        If 是否控制MC服务端10 Then 启动单个MC服务器(MC服务端10启动脚本名称, "10")
    End Sub
    Private Sub 启动单个MC服务器(MC启动脚本名称 As String, 服务器序号 As String)
        Dim P As String = ""
        Select Case 服务器序号
            Case "1"
                P = MC服务端1路径
            Case "2"
                P = MC服务端2路径
            Case "3"
                P = MC服务端3路径
            Case "4"
                P = MC服务端4路径
            Case "5"
                P = MC服务端5路径
            Case "6"
                P = MC服务端6路径
            Case "7"
                P = MC服务端7路径
            Case "8"
                P = MC服务端8路径
            Case "9"
                P = MC服务端9路径
            Case "10"
                P = MC服务端10路径
        End Select
        Try
            If String.IsNullOrEmpty(MC启动脚本名称) Then
                添加日志($"[ERROR]MC服务器{服务器序号}启动脚本名称不能为空", Color.Red) : Return
            Else
                Dim MC启动脚本路径 As String = Path.Combine(P, MC启动脚本名称)
                If File.Exists(MC启动脚本名称) Then
                    添加日志($"[ERROR]MC服务器{服务器序号}启动脚本不存在", Color.Red) : Return
                End If
            End If
            Using 服务端 As New Process()
                服务端.StartInfo.FileName = Path.Combine(P, MC启动脚本名称)
                服务端.StartInfo.WorkingDirectory = P
                服务端.StartInfo.UseShellExecute = True
                服务端.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                添加日志($"[Info]正在启动MC服务器{服务器序号}", Color.Orange)
                服务端.Start()
                添加日志($"[Success]MC服务器{服务器序号}已成功启动", Color.DarkGreen)
            End Using
        Catch ex As Exception
            添加日志($"[ERROR]启动MC服务器{服务器序号}时发生异常：{ex.Message}", Color.Red)
        End Try
    End Sub
    Private Sub 向Sftp服务器上传MC服务端备份文件()
        If 是否增量备份 Then
            Dim m As String = "增量备份" 'mode
            If 是否控制MC服务端1 Then 多个Sftp上传单个MC服务端备份文件(1, m)
            If 是否控制MC服务端2 Then 多个Sftp上传单个MC服务端备份文件(2, m)
            If 是否控制MC服务端3 Then 多个Sftp上传单个MC服务端备份文件(3, m)
            If 是否控制MC服务端4 Then 多个Sftp上传单个MC服务端备份文件(4, m)
            If 是否控制MC服务端5 Then 多个Sftp上传单个MC服务端备份文件(5, m)
            If 是否控制MC服务端6 Then 多个Sftp上传单个MC服务端备份文件(6, m)
            If 是否控制MC服务端7 Then 多个Sftp上传单个MC服务端备份文件(7, m)
            If 是否控制MC服务端8 Then 多个Sftp上传单个MC服务端备份文件(8, m)
            If 是否控制MC服务端9 Then 多个Sftp上传单个MC服务端备份文件(9, m)
            If 是否控制MC服务端10 Then 多个Sftp上传单个MC服务端备份文件(10, m)
        Else
            Dim m As String = "完整备份" 'mode
            If 是否控制MC服务端1 Then 多个Sftp上传单个MC服务端备份文件(1, m)
            If 是否控制MC服务端2 Then 多个Sftp上传单个MC服务端备份文件(2, m)
            If 是否控制MC服务端3 Then 多个Sftp上传单个MC服务端备份文件(3, m)
            If 是否控制MC服务端4 Then 多个Sftp上传单个MC服务端备份文件(4, m)
            If 是否控制MC服务端5 Then 多个Sftp上传单个MC服务端备份文件(5, m)
            If 是否控制MC服务端6 Then 多个Sftp上传单个MC服务端备份文件(6, m)
            If 是否控制MC服务端7 Then 多个Sftp上传单个MC服务端备份文件(7, m)
            If 是否控制MC服务端8 Then 多个Sftp上传单个MC服务端备份文件(8, m)
            If 是否控制MC服务端9 Then 多个Sftp上传单个MC服务端备份文件(9, m)
            If 是否控制MC服务端10 Then 多个Sftp上传单个MC服务端备份文件(10, m)
        End If
    End Sub
    Private Sub 多个Sftp上传单个MC服务端备份文件(RCON序号 As String, 备份模式 As String)
        Dim 本地文件目录 = Path.Combine(备份输出目录, $"{备份模式}", $"RCON{RCON序号}备份")
        Dim 本地文件路径 = Path.Combine(本地文件目录, $"RCON{RCON序号}{备份模式}_{读取上次备份时间(本地文件目录):yyyyMMdd-HHmmss}.7z")
        Dim 远程文件目录 = Path.Combine("/备份", $"{备份模式}", $"RCON{RCON序号}备份")
        If Sftp1开关 Then
            处理单个Sftp服务端_上传文件(Sftp1地址, Sftp1端口, Sftp1用户名, Sftp1密码, "1", 本地文件路径, 远程文件目录)
        End If
        If Sftp2开关 Then
            处理单个Sftp服务端_上传文件(Sftp2地址, Sftp2端口, Sftp2用户名, Sftp2密码, "2", 本地文件路径, 远程文件目录)
        End If
        If Sftp3开关 Then
            处理单个Sftp服务端_上传文件(Sftp3地址, Sftp3端口, Sftp3用户名, Sftp3密码, "3", 本地文件路径, 远程文件目录)
            Return
        End If
        添加日志("[Warning]无可用Sftp服务器", Color.DarkOrange)
    End Sub
    Private Function 备份自定义目录() As Boolean
        If 是否备份自定义目录 Then
            If Not String.IsNullOrEmpty(自定义备份目录) Then
                If Directory.Exists(自定义备份目录) Then
                    If Not String.IsNullOrEmpty(备份输出目录) Then
                        If 是否增量备份 Then
                            ' 执行增量备份
                            Dim 备份路径 = Path.Combine(备份输出目录, "增量备份")
                            If Not Directory.Exists(备份路径) Then
                                Directory.CreateDirectory(备份路径)
                            End If
                            Dim 增量备份实例 As New 增量备份管理器()
                            增量备份实例.执行增量备份(自定义备份目录, Path.Combine(备份路径, "自定义备份目录"), "增量备份")
                            Return True
                        Else
                            ' 执行完整备份
                            Dim 备份路径 = Path.Combine(备份输出目录, "完整备份")
                            If Not Directory.Exists(备份路径) Then
                                Directory.CreateDirectory(备份路径)
                            End If
                            Dim 完整备份实例 As New 完整备份管理器()
                            完整备份实例.执行完整备份(自定义备份目录, Path.Combine(备份路径, "自定义备份目录"), "完整备份")
                            Return True
                        End If
                    Else
                        添加日志("[ERROR]备份输出目录不能为空", Color.Red)
                        Return False
                    End If
                Else
                    添加日志("[ERROR]自定义备份目录不存在", Color.Red)
                    Return False
                End If
            Else
                添加日志("[ERROR]启用自定义备份时,备份目录不能为空", Color.Red)
                Return False
            End If
        Else
            添加日志("[Info]未启用备份自定义目录，已跳过", Color.Orange)
            Return False
        End If
    End Function
    Private Sub Sftp上传自定义备份文件()
        Dim 任务列表 As New List(Of Integer)
        If Sftp1开关 Then 任务列表.Add(1)
        If Sftp2开关 Then 任务列表.Add(2)
        If Sftp3开关 Then 任务列表.Add(3)
        If 任务列表.Count = 0 Then
            添加日志("[Warning]无可用Sftp服务器", Color.DarkOrange)
            Return
        End If
        Dim 备份模式 As String
        If 是否备份自定义目录 Then
            备份模式 = "增量备份"
        Else
            备份模式 = "完整备份"
        End If
        Dim 本地文件目录 = Path.Combine(备份输出目录, $"{备份模式}", "自定义备份目录")
        Dim 本地文件路径 = Path.Combine(本地文件目录, $"{备份模式}_{读取上次备份时间(本地文件目录):yyyyMMdd-HHmmss}.7z")
        Dim 远程文件目录 = Path.Combine("\备份", $"{备份模式}", $"自定义备份目录")
        If Sftp1开关 Then
            处理单个Sftp服务端_上传文件(Sftp1地址, Sftp1端口, Sftp1用户名, Sftp1密码, "1", 本地文件路径, 远程文件目录)
        End If
        If Sftp2开关 Then
            处理单个Sftp服务端_上传文件(Sftp2地址, Sftp2端口, Sftp2用户名, Sftp2密码, "2", 本地文件路径, 远程文件目录)
        End If
        If Sftp3开关 Then
            处理单个Sftp服务端_上传文件(Sftp3地址, Sftp3端口, Sftp3用户名, Sftp3密码, "3", 本地文件路径, 远程文件目录)
        End If
    End Sub
    Private Function 读取上次备份时间(输出目录 As String)
        Dim 上次备份时间 As DateTime = DateTime.MinValue
        Dim 时间记录文件 As String = "LastBackup.time"
        Dim 时间文件 = Path.Combine(输出目录, 时间记录文件)
        If File.Exists(时间文件) Then
            DateTime.TryParse(File.ReadAllText(时间文件), 上次备份时间)
        End If
        Return 上次备份时间
    End Function
End Module
