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
Imports System.Runtime.InteropServices
Public Module 核心功能模块
    Private Sub 添加日志(信息 As String, 颜色 As Color)
        If 日志窗口.InvokeRequired Then
            日志窗口.Invoke(Sub() 日志窗口.添加日志(信息, 颜色))
        Else
            日志窗口.添加日志(信息, 颜色)
        End If
    End Sub
    Public Class 间隔任务执行器
        Private ReadOnly uiContext As SynchronizationContext = SynchronizationContext.Current
        Private 下次执行时间 As DateTime
        Private 执行时间间隔 As TimeSpan
        Private WithEvents 计时器 As New Timers.Timer With {.AutoReset = False}
        Public Sub New()
            启动()
            添加日志($"[Success]已启动备份计划", Color.Green)
        End Sub
        Private Sub 启动()
            添加日志("[Info]正在计算下一次执行时间", Color.Black)
            Dim 当前时间 As DateTime
            间隔天数 = If(CDbl(间隔天数) < 1, 1, 间隔天数)
            Dim H = 运行时间.Split(":")(0)
            Dim M = 运行时间.Split(":")(1)
            Dim S = 运行时间.Split(":")(2)
            If 运行模式 Then
                当前时间 = DateTime.Now.Date
                下次执行时间 = 当前时间.AddDays(CDbl(间隔天数)).AddHours(CDbl(H)).AddMinutes(CDbl(M)).AddSeconds(CDbl(S))
            Else
                当前时间 = DateTime.Now
                下次执行时间 = 当前时间.AddHours(CDbl(H)).AddMinutes(CDbl(M)).AddSeconds(CDbl(S))
            End If
            执行时间间隔 = 下次执行时间 - DateTime.Now
            添加日志($"[Success]执行时间成功传入,下次执行时间:{下次执行时间}", Color.Green)
            计时器.Interval = 执行时间间隔.TotalMilliseconds
            计时器.Start()
            服务运行状态 = True
        End Sub
        Private Sub 时间到达() Handles 计时器.Elapsed
            计时器.Stop()
            uiContext.Post(Sub()
                               Dim H As New 核心功能类
                               H.核心功能方法()
                               启动()
                           End Sub, Nothing)
        End Sub
        Public Function 获取剩余秒数() As (剩余秒数 As Integer, 总秒数 As Integer）
            Dim TS = (下次执行时间 - DateTime.Now).TotalSeconds
            TS = If(TS >= 0, TS, 0)
            Return (TS, 执行时间间隔.TotalSeconds)
        End Function
        Public Sub 停止任务()
            服务运行状态 = False
            计时器?.Dispose()
        End Sub
    End Class
    Public Class 核心功能类
        Public Sub 核心功能方法()
            If 备份操作进行状态 Then
                添加日志("[Warning]重复运行备份功能,后发起的请求已取消", Color.Red)
                Exit Sub
            End If
            备份操作进行状态 = True
            Dim 原服务运行状态 As Boolean = 服务运行状态
            服务运行状态 = False
			MainForm.服务运行时更改控件状态(True)
            '---------------------------------------------------------------备份MC服务端操作---------------------------------
            Try
				MainForm.执行中的主任务.Text = "备份MC服务端"
				MainForm.主任务进度条.Maximum = 100 '确保进度条最大值为100
				MainForm.主任务进度条.Value = 0
				Dim RCON执行成功 As Boolean = False
				If 是否关服备份 Then
					RCON执行成功 = RCON关闭MC服务器()
				Else
					RCON执行成功 = RCON停止服务端自动保存()
				End If
				If RCON执行成功 = False Then
					MainForm.执行中的分任务.Text = "无"
					Exit Try
				End If
				MainForm.主任务进度条.Value = 10

				If 是否关服备份 Then
					添加日志($"[Info]等待MC服务端彻底关闭({等待服务端关闭时长}s)", Color.Orange)
					MainForm.执行中的分任务.Text = $"等待MC服务端彻底关闭({等待服务端关闭时长}s)"
					If 是否循环更新界面 Then
						Dim C As Integer = 等待服务端关闭时长 * 帧数
						Dim S As Double = 100 / C
						For i As Integer = 1 To C
							MainForm.分任务进度条.Value = If(CInt(S * i) <= 100, CInt(S * i), 100)
							Application.DoEvents()
							Thread.Sleep(延时毫秒数)
						Next
						MainForm.分任务进度条.Value = 100
					Else
						Thread.Sleep(等待服务端关闭时长 * 1000)
						MainForm.分任务进度条.Value = 100
					End If
				End If
				MainForm.主任务进度条.Value = 15

				备份MC服务端()
				MainForm.主任务进度条.Value = 60

				向Sftp服务器上传MC服务端备份文件()
				MainForm.主任务进度条.Value = 90

                If Not 是否关服备份 Then
                    RCON启用服务端自动保存()
                End If
                MainForm.主任务进度条.Value = 100
                MainForm.执行中的分任务.Text = "完成备份MC服务端任务"
                Dim x As Integer = 0
                While x * 延时毫秒数 < 1000
                    Thread.Sleep(延时毫秒数) '展示完成状态
                    x += 1
                End While
            Catch ex As Exception
				添加日志($"[ERROR]执行备份MC服务端任务时发生错误:{ex.Message}", Color.Red)
			Finally
				MainForm.执行中的主任务.Text = "无"
				MainForm.主任务进度条.Value = 0
				MainForm.执行中的分任务.Text = "无"
				MainForm.分任务进度条.Value = 0
			End Try
            '------------------------------------------------------------备份自定义目录操作--------------------------------
            Try
                MainForm.执行中的主任务.Text = "备份自定义目录"
                MainForm.主任务进度条.Value = 0
                If 是否备份自定义目录 Then
                    备份自定义目录()
                    MainForm.主任务进度条.Value = 50
                    If 是否关服备份 Then
                        启动MC服务器()
                    End If
                    Sftp上传自定义备份文件()
                    MainForm.执行中的主任务.Text = "完成备份自定义目录任务"
                    MainForm.主任务进度条.Value = 100
                Else
                    If 是否关服备份 Then
                        启动MC服务器()
                    End If
                End If
                Dim x As Integer = 0
                While x * 延时毫秒数 < 1000
                    Thread.Sleep(延时毫秒数) '展示完成状态
                    x += 1
                End While
            Catch ex As Exception
                添加日志($"[ERROR]执行备份自定义文件夹任务时发生错误:{ex.Message}", Color.Red)
            Finally
                MainForm.执行中的主任务.Text = "无"
                MainForm.主任务进度条.Value = 0
                MainForm.执行中的分任务.Text = "无"
                MainForm.分任务进度条.Value = 0
            End Try
            备份操作进行状态 = False
            服务运行状态 = 原服务运行状态
            MainForm.服务运行时更改控件状态(False)
        End Sub
        Private Function RCON关闭MC服务器() As Boolean
            MainForm.执行中的分任务.Text = "使用RCON通信关闭MC服务端"
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
            MainForm.执行中的分任务.Text = "使用RCON通信止服务端自动保存"
            Dim 任务列表 As New List(Of Integer)
            If 是否控制MC服务端1 Then
                任务列表.Add(1)
                处理单个服务器(RCON1地址, RCON1端口, RCON1密码, "save-off", "1")
                处理单个服务器(RCON1地址, RCON1端口, RCON1密码, "save-all", "1")
            End If
            If 是否控制MC服务端2 Then
                任务列表.Add(2)
                处理单个服务器(RCON2地址, RCON2端口, RCON2密码, "save-off", "2")
                处理单个服务器(RCON2地址, RCON2端口, RCON2密码, "save-all", "2")
            End If
            If 是否控制MC服务端3 Then
                任务列表.Add(3)
                处理单个服务器(RCON3地址, RCON3端口, RCON3密码, "save-off", "3")
                处理单个服务器(RCON3地址, RCON3端口, RCON3密码, "save-all", "3")
            End If
            If 是否控制MC服务端4 Then
                任务列表.Add(4)
                处理单个服务器(RCON4地址, RCON4端口, RCON4密码, "save-off", "4")
                处理单个服务器(RCON4地址, RCON4端口, RCON4密码, "save-all", "4")
            End If
            If 是否控制MC服务端5 Then
                任务列表.Add(5)
                处理单个服务器(RCON5地址, RCON5端口, RCON5密码, "save-off", "5")
                处理单个服务器(RCON5地址, RCON5端口, RCON5密码, "save-all", "5")
            End If
            If 是否控制MC服务端6 Then
                任务列表.Add(6)
                处理单个服务器(RCON6地址, RCON6端口, RCON6密码, "save-off", "6")
                处理单个服务器(RCON6地址, RCON6端口, RCON6密码, "save-all", "6")
            End If
            If 是否控制MC服务端7 Then
                任务列表.Add(7)
                处理单个服务器(RCON7地址, RCON7端口, RCON7密码, "save-off", "7")
                处理单个服务器(RCON7地址, RCON7端口, RCON7密码, "save-all", "7")
            End If
            If 是否控制MC服务端8 Then
                任务列表.Add(8)
                处理单个服务器(RCON8地址, RCON8端口, RCON8密码, "save-off", "8")
                处理单个服务器(RCON8地址, RCON8端口, RCON8密码, "save-all", "8")
            End If
            If 是否控制MC服务端9 Then
                任务列表.Add(9)
                处理单个服务器(RCON9地址, RCON9端口, RCON9密码, "save-off", "9")
                处理单个服务器(RCON9地址, RCON9端口, RCON9密码, "save-all", "9")
            End If
            If 是否控制MC服务端10 Then
                任务列表.Add(10)
                处理单个服务器(RCON10地址, RCON10端口, RCON10密码, "save-off", "10")
                处理单个服务器(RCON10地址, RCON10端口, RCON10密码, "save-all", "10")
            End If
            If 任务列表.Count = 0 Then
                添加日志("[Info]没有控制中的MC服务器,已自动跳过", Color.DarkGreen)
                Return False
            Else
                Return True
            End If
        End Function
        Private Sub RCON启用服务端自动保存()
            MainForm.执行中的分任务.Text = "使用RCON通信重新启用服务端自动保存"
            Dim 任务列表 As New List(Of Integer)
            If 是否控制MC服务端1 Then
                任务列表.Add(1)
                处理单个服务器(RCON1地址, RCON1端口, RCON1密码, "save-on", "1")
            End If
            If 是否控制MC服务端2 Then
                任务列表.Add(2)
                处理单个服务器(RCON2地址, RCON2端口, RCON2密码, "save-on", "2")
            End If
            If 是否控制MC服务端3 Then
                任务列表.Add(3)
                处理单个服务器(RCON3地址, RCON3端口, RCON3密码, "save-on", "3")
            End If
            If 是否控制MC服务端4 Then
                任务列表.Add(4)
                处理单个服务器(RCON4地址, RCON4端口, RCON4密码, "save-on", "4")
            End If
            If 是否控制MC服务端5 Then
                任务列表.Add(5)
                处理单个服务器(RCON5地址, RCON5端口, RCON5密码, "save-on", "5")
            End If
            If 是否控制MC服务端6 Then
                任务列表.Add(6)
                处理单个服务器(RCON6地址, RCON6端口, RCON6密码, "save-on", "6")
            End If
            If 是否控制MC服务端7 Then
                任务列表.Add(7)
                处理单个服务器(RCON7地址, RCON7端口, RCON7密码, "save-on", "7")
            End If
            If 是否控制MC服务端8 Then
                任务列表.Add(8)
                处理单个服务器(RCON8地址, RCON8端口, RCON8密码, "save-on", "8")
            End If
            If 是否控制MC服务端9 Then
                任务列表.Add(9)
                处理单个服务器(RCON9地址, RCON9端口, RCON9密码, "save-on", "9")
            End If
            If 是否控制MC服务端10 Then
                任务列表.Add(10)
                处理单个服务器(RCON10地址, RCON10端口, RCON10密码, "save-on", "10")
            End If
            If 任务列表.Count = 0 Then
                添加日志("[Info]没有控制中的MC服务器,已自动跳过", Color.DarkGreen)
            End If
        End Sub
        Private Sub 备份MC服务端()
            If 是否增量备份 Then
                ' 执行增量备份
                If 备份输出目录 = "" Then 添加日志("[ERROR]备份输出目录不能为空", Color.Red) : Return
                Dim 备份路径 = Path.Combine(备份输出目录, "增量备份")
                If Not Directory.Exists(备份路径) Then Directory.CreateDirectory(备份路径)
                Dim 增量备份实例 As New 增量备份管理器()
                If 是否控制MC服务端1 Then 增量备份实例.执行增量备份(MC服务端1路径, Path.Combine(备份路径, "MC服务端1备份"), "MC服务端1", 备份MC服务端1排除文件参数, 1)
                If 是否控制MC服务端2 Then 增量备份实例.执行增量备份(MC服务端2路径, Path.Combine(备份路径, "MC服务端2备份"), "MC服务端2", 备份MC服务端2排除文件参数, 2)
                If 是否控制MC服务端3 Then 增量备份实例.执行增量备份(MC服务端3路径, Path.Combine(备份路径, "MC服务端3备份"), "MC服务端3", 备份MC服务端3排除文件参数, 3)
                If 是否控制MC服务端4 Then 增量备份实例.执行增量备份(MC服务端4路径, Path.Combine(备份路径, "MC服务端4备份"), "MC服务端4", 备份MC服务端4排除文件参数, 4)
                If 是否控制MC服务端5 Then 增量备份实例.执行增量备份(MC服务端5路径, Path.Combine(备份路径, "MC服务端5备份"), "MC服务端5", 备份MC服务端5排除文件参数, 5)
                If 是否控制MC服务端6 Then 增量备份实例.执行增量备份(MC服务端6路径, Path.Combine(备份路径, "MC服务端6备份"), "MC服务端6", 备份MC服务端6排除文件参数, 6)
                If 是否控制MC服务端7 Then 增量备份实例.执行增量备份(MC服务端7路径, Path.Combine(备份路径, "MC服务端7备份"), "MC服务端7", 备份MC服务端7排除文件参数, 7)
                If 是否控制MC服务端8 Then 增量备份实例.执行增量备份(MC服务端8路径, Path.Combine(备份路径, "MC服务端8备份"), "MC服务端8", 备份MC服务端8排除文件参数, 8)
                If 是否控制MC服务端9 Then 增量备份实例.执行增量备份(MC服务端9路径, Path.Combine(备份路径, "MC服务端9备份"), "MC服务端9", 备份MC服务端9排除文件参数, 9)
                If 是否控制MC服务端10 Then 增量备份实例.执行增量备份(MC服务端10路径, Path.Combine(备份路径, "MC服务端10备份"), "MC服务端10", 备份MC服务端10排除文件参数, 10)
            Else
                If 备份输出目录 = "" Then 添加日志("[ERROR]备份输出目录不能为空", Color.Red) : Return
                ' 执行完整备份
                Dim 备份路径 = Path.Combine(备份输出目录, "完整备份")
                If Not Directory.Exists(备份路径) Then Directory.CreateDirectory(备份路径)
                Dim 完整备份实例 As New 完整备份管理器()
                If 是否控制MC服务端1 Then 完整备份实例.执行完整备份(MC服务端1路径, Path.Combine(备份路径, "MC服务端1备份"), "MC服务端1", 备份MC服务端1排除文件参数, 1)
                If 是否控制MC服务端2 Then 完整备份实例.执行完整备份(MC服务端2路径, Path.Combine(备份路径, "MC服务端2备份"), "MC服务端2", 备份MC服务端2排除文件参数, 2)
                If 是否控制MC服务端3 Then 完整备份实例.执行完整备份(MC服务端3路径, Path.Combine(备份路径, "MC服务端3备份"), "MC服务端3", 备份MC服务端3排除文件参数, 3)
                If 是否控制MC服务端4 Then 完整备份实例.执行完整备份(MC服务端4路径, Path.Combine(备份路径, "MC服务端4备份"), "MC服务端4", 备份MC服务端4排除文件参数, 4)
                If 是否控制MC服务端5 Then 完整备份实例.执行完整备份(MC服务端5路径, Path.Combine(备份路径, "MC服务端5备份"), "MC服务端5", 备份MC服务端5排除文件参数, 5)
                If 是否控制MC服务端6 Then 完整备份实例.执行完整备份(MC服务端6路径, Path.Combine(备份路径, "MC服务端6备份"), "MC服务端6", 备份MC服务端6排除文件参数, 6)
                If 是否控制MC服务端7 Then 完整备份实例.执行完整备份(MC服务端7路径, Path.Combine(备份路径, "MC服务端7备份"), "MC服务端7", 备份MC服务端7排除文件参数, 7)
                If 是否控制MC服务端8 Then 完整备份实例.执行完整备份(MC服务端8路径, Path.Combine(备份路径, "MC服务端8备份"), "MC服务端8", 备份MC服务端8排除文件参数, 8)
                If 是否控制MC服务端9 Then 完整备份实例.执行完整备份(MC服务端9路径, Path.Combine(备份路径, "MC服务端9备份"), "MC服务端9", 备份MC服务端9排除文件参数, 9)
                If 是否控制MC服务端10 Then 完整备份实例.执行完整备份(MC服务端10路径, Path.Combine(备份路径, "MC服务端10备份"), "MC服务端10", 备份MC服务端10排除文件参数, 10)
            End If
        End Sub
        Public Sub 启动MC服务器()
            MainForm.执行中的分任务.Text = "启动所有已启用的MC服务端"
            MainForm.分任务进度条.Value = 10
            If 是否控制MC服务端1 AndAlso Not 检测服务端是否已启动(1) Then 启动单个MC服务器(MC服务端1启动脚本名称, "1")
            If 是否控制MC服务端2 AndAlso Not 检测服务端是否已启动(2) Then 启动单个MC服务器(MC服务端2启动脚本名称, "2")
            If 是否控制MC服务端3 AndAlso Not 检测服务端是否已启动(3) Then 启动单个MC服务器(MC服务端3启动脚本名称, "3")
            If 是否控制MC服务端4 AndAlso Not 检测服务端是否已启动(4) Then 启动单个MC服务器(MC服务端4启动脚本名称, "4")
            If 是否控制MC服务端5 AndAlso Not 检测服务端是否已启动(5) Then 启动单个MC服务器(MC服务端5启动脚本名称, "5")
            If 是否控制MC服务端6 AndAlso Not 检测服务端是否已启动(6) Then 启动单个MC服务器(MC服务端6启动脚本名称, "6")
            If 是否控制MC服务端7 AndAlso Not 检测服务端是否已启动(7) Then 启动单个MC服务器(MC服务端7启动脚本名称, "7")
            If 是否控制MC服务端8 AndAlso Not 检测服务端是否已启动(8) Then 启动单个MC服务器(MC服务端8启动脚本名称, "8")
            If 是否控制MC服务端9 AndAlso Not 检测服务端是否已启动(9) Then 启动单个MC服务器(MC服务端9启动脚本名称, "9")
            If 是否控制MC服务端10 AndAlso Not 检测服务端是否已启动(10) Then 启动单个MC服务器(MC服务端10启动脚本名称, "10")
            MainForm.执行中的分任务.Text = "无"
            MainForm.分任务进度条.Value = 100
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
            MainForm.执行中的主任务.Text = $" 向Sftp服务器上传MC服务端备份文件"
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
        Private Sub 多个Sftp上传单个MC服务端备份文件(MC服务端序号 As String, 备份模式 As String)
            Dim 本地文件目录 = Path.Combine(备份输出目录, $"{备份模式}", $"MC服务端{MC服务端序号}备份")
            Dim 本地文件路径 = Path.Combine(本地文件目录, $"MC服务端{MC服务端序号}的{备份模式}_{读取上次备份时间(本地文件目录):yyyyMMdd-HHmmss}.{压缩格式}")
            Dim 远程文件目录 = $"/备份/{备份模式}/MC服务端{MC服务端序号}备份"
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
                                增量备份实例.执行增量备份(自定义备份目录, Path.Combine(备份路径, "自定义备份目录"), "自定义备份目录", 自定义备份目录排除文件参数)
                                Return True
                            Else
                                ' 执行完整备份
                                Dim 备份路径 = Path.Combine(备份输出目录, "完整备份")
                                If Not Directory.Exists(备份路径) Then
                                    Directory.CreateDirectory(备份路径)
                                End If
                                Dim 完整备份实例 As New 完整备份管理器()
                                完整备份实例.执行完整备份(自定义备份目录, Path.Combine(备份路径, "自定义备份目录"), "自定义备份目录", 自定义备份目录排除文件参数)
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
			MainForm.执行中的主任务.Text = $" 向Sftp服务器上传自定义备份文件夹的备份文件"
			Dim 任务列表 As New List(Of Integer)
			If Sftp1开关 Then 任务列表.Add(1)
			If Sftp2开关 Then 任务列表.Add(2)
			If Sftp3开关 Then 任务列表.Add(3)
			If 任务列表.Count = 0 Then
				添加日志("[Warning]无可用Sftp服务器", Color.DarkOrange)
				Return
			End If
			Dim 备份模式 As String
			If 是否增量备份 Then
				备份模式 = "增量备份"
			Else
				备份模式 = "完整备份"
			End If
			Dim 本地文件目录 = Path.Combine(备份输出目录, $"{备份模式}", "自定义备份目录")
			Dim 本地文件路径 = Path.Combine(本地文件目录, $"自定义备份目录的{备份模式}_{读取上次备份时间(本地文件目录):yyyyMMdd-HHmmss}.{压缩格式}")
			Dim 远程文件目录 = $"/备份/{备份模式}/自定义备份目录"
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
		Private Function 读取上次备份时间(输出目录 As String) As DateTime
			Dim 上次备份时间 As DateTime = DateTime.MinValue
			Dim 时间记录文件 As String = "LastBackup.time"
			Dim 时间文件 = Path.Combine(输出目录, 时间记录文件)
            If File.Exists(时间文件) Then
                If DateTime.TryParse(File.ReadAllText(时间文件), 上次备份时间) Then
                    Return 上次备份时间
                End If
            End If
            Return 上次备份时间
        End Function
		Private Function 检测服务端是否已启动(服务端序号 As Integer) As Boolean
            Select Case 服务端序号
                Case 1
                    Dim P As String = Path.Combine(MC服务端1路径, "logs", "latest.log")
                    Dim 判断结果 As Boolean = 检测文件是否被锁定(P)
                    If 判断结果 Then 添加日志("[Warning]MC服务端1已启动或无权访问latest.log文件", Color.Orange)
                    Return 判断结果
                Case 2
                    Dim P As String = Path.Combine(MC服务端2路径, "logs", "latest.log")
                    Dim 判断结果 As Boolean = 检测文件是否被锁定(P)
                    If 判断结果 Then 添加日志("[Warning]MC服务端2已启动或无权访问latest.log文件", Color.Orange)
                    Return 判断结果
                Case 3
                    Dim P As String = Path.Combine(MC服务端3路径, "logs", "latest.log")
                    Dim 判断结果 As Boolean = 检测文件是否被锁定(P)
                    If 判断结果 Then 添加日志("[Warning]MC服务端3已启动或无权访问latest.log文件", Color.Orange)
                    Return 判断结果
                Case 4
                    Dim P As String = Path.Combine(MC服务端4路径, "logs", "latest.log")
                    Dim 判断结果 As Boolean = 检测文件是否被锁定(P)
                    If 判断结果 Then 添加日志("[Warning]MC服务端4已启动或无权访问latest.log文件", Color.Orange)
                    Return 判断结果
                Case 5
                    Dim P As String = Path.Combine(MC服务端5路径, "logs", "latest.log")
                    Dim 判断结果 As Boolean = 检测文件是否被锁定(P)
                    If 判断结果 Then 添加日志("[Warning]MC服务端5已启动或无权访问latest.log文件", Color.Orange)
                    Return 判断结果
                Case 6
                    Dim P As String = Path.Combine(MC服务端6路径, "logs", "latest.log")
                    Dim 判断结果 As Boolean = 检测文件是否被锁定(P)
                    If 判断结果 Then 添加日志("[Warning]MC服务端6已启动或无权访问latest.log文件", Color.Orange)
                    Return 判断结果
                Case 7
                    Dim P As String = Path.Combine(MC服务端7路径, "logs", "latest.log")
                    Dim 判断结果 As Boolean = 检测文件是否被锁定(P)
                    If 判断结果 Then 添加日志("[Warning]MC服务端7已启动或无权访问latest.log文件", Color.Orange)
                    Return 判断结果
                Case 8
                    Dim P As String = Path.Combine(MC服务端8路径, "logs", "latest.log")
                    Dim 判断结果 As Boolean = 检测文件是否被锁定(P)
                    If 判断结果 Then 添加日志("[Warning]MC服务端8已启动或无权访问latest.log文件", Color.Orange)
                    Return 判断结果
                Case 9
                    Dim P As String = Path.Combine(MC服务端9路径, "logs", "latest.log")
                    Dim 判断结果 As Boolean = 检测文件是否被锁定(P)
                    If 判断结果 Then 添加日志("[Warning]MC服务端9已启动或无权访问latest.log文件", Color.Orange)
                    Return 判断结果
                Case 10
                    Dim P As String = Path.Combine(MC服务端10路径, "logs", "latest.log")
                    Dim 判断结果 As Boolean = 检测文件是否被锁定(P)
                    If 判断结果 Then 添加日志("[Warning]MC服务端10已启动或无权访问latest.log文件", Color.Orange)
                    Return 判断结果
                Case Else
                    Return False
            End Select
        End Function
        Private Function 检测文件是否被锁定(文件路径 As String) As Boolean
            If Not File.Exists(文件路径) Then
                Return False
            End If
            Try
                Using 文件流 As FileStream = File.Open(文件路径, FileMode.Open, FileAccess.Read, FileShare.None)
                    Return False
                End Using
            Catch ex As IOException
                Dim 错误代码 As Integer = Marshal.GetHRForException(ex) And &HFFFF
                If 错误代码 = &H20 OrElse 错误代码 = &H21 Then
                    Return True
                End If
                Return True
            Catch ex As UnauthorizedAccessException
                Return True
            End Try
        End Function
    End Class
End Module
