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
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Public Class RCON客户端
	Private RCON客户端实例 As New TcpClient
	Private 数据流 As NetworkStream
	Private 请求ID As Integer = 0
	Public 连接状态 As Boolean = False
	Private Shared Sub 添加日志(信息 As String, 颜色 As Color)
		If 日志窗口.InvokeRequired Then
			日志窗口.Invoke(Sub() 日志窗口.添加日志(信息, 颜色))
		Else
			日志窗口.添加日志(信息, 颜色)
		End If
	End Sub
	Public Sub 连接RCON(地址 As String, 端口 As Integer, 密码 As String, 服务器序号 As String)
		' ------------------------------------------------连接到 RCON 服务端----------------------------------
		添加日志($"[Action]正在连接到RCON{服务器序号}服务端", Color.Orange)
		MainForm.执行中的分任务.Text = $"处理RCON{服务器序号}服务端"
		MainForm.分任务进度条.Value = 0
		If 是否循环更新界面 Then
			Dim T = RCON客户端实例.ConnectAsync(地址, 端口)
			While Not T.IsCompleted
				Thread.Sleep(延时毫秒数)
				Application.DoEvents()
			End While
		Else
			RCON客户端实例.Connect(地址, 端口)
		End If
		If Not RCON客户端实例.Connected Then
			添加日志($"[ERROR]RCON{服务器序号}客户端无法连接到指定的服务器，请检查网络连接和配置文件。", Color.Red)
			MainForm.执行中的分任务.Text = $"无"
			MainForm.分任务进度条.Value = 0
			Exit Sub
		End If
		MainForm.分任务进度条.Value = 10
		添加日志($"[Success]RCON{服务器序号}连接成功", Color.Green)
		数据流 = RCON客户端实例.GetStream()
		'--------------------------------------------尝试登录至RCON{服务器序号}服务器--------------------------------
		添加日志($"[INFO]正在尝试登录至RCON{服务器序号}服务器", Color.Black)
		添加日志($"[INFO]RCON{服务器序号}客户端正在构建登录信息数据包", Color.Black)
		Dim 登录数据包 = 构建数据包(3, 密码)
		MainForm.分任务进度条.Value = 15
		添加日志($"[INFO]RCON{服务器序号}客户端正在发送登录信息数据包", Color.Black)
		If 是否循环更新界面 Then
			Dim T As Task = 数据流.WriteAsync(登录数据包, 0, 登录数据包.Length) ' 发送数据包
			While Not T.IsCompleted
				Thread.Sleep(延时毫秒数)
				Application.DoEvents()
			End While
		Else
			数据流.Write(登录数据包, 0, 登录数据包.Length) ' 发送数据包
		End If
		添加日志($"[Info]RCON{服务器序号}客户端:登录数据包发送完成", Color.Black)
		添加日志($"[INFO]RCON{服务器序号}客户端正在读取返回数据包", Color.Black)
		Dim Rid = 读取返回数据包(服务器序号).返回的数据包请求ID
		If Rid = 0 Then
			连接状态 = True
			添加日志($"[Success]RCON{服务器序号}登录成功", Color.Green)
			MainForm.分任务进度条.Value = 20
			Exit Sub
		ElseIf Rid = -1 Then
			添加日志($"[ERROR]RCON{服务器序号}登录失败，密码错误", Color.Red)
		ElseIf Rid = -2 Then
			添加日志($"[ERROR]RCON{服务器序号}登录失败，网络错误", Color.Red)
		Else
			添加日志($"[ERROR]RCON{服务器序号}登录失败，未知错误，返回代码{Rid}", Color.Red)
		End If
		MainForm.分任务进度条.Value = 0
		MainForm.执行中的分任务.Text = ""
	End Sub
	Public Sub 发送指令并返回响应(指令 As String, 服务器序号 As String, Optional 等待时长 As Integer = 3) ' 发送命令并返回响应
		If Not 连接状态 Then Exit Sub
		If String.IsNullOrEmpty(指令) Then
			添加日志($"[ERROR]RCON{服务器序号}客户端指令不能为空", Color.Red)
			Exit Sub
		End If
		添加日志($"[Info]RCON{服务器序号}客户端要发送的指令:{指令}", Color.Orange)
		请求ID += 1
		添加日志($"[Info]RCON{服务器序号}客户端正在构建指令数据包", Color.Black)
		Dim 指令数据包 = 构建数据包(2, 指令)
		MainForm.分任务进度条.Value = 30
		添加日志($"[Info]RCON{服务器序号}客户端正在发送指令数据包", Color.Black)
		If 是否循环更新界面 Then
			Dim T As Task = 数据流.WriteAsync(指令数据包, 0, 指令数据包.Length) ' 发送数据包
			While Not T.IsCompleted
				Thread.Sleep(延时毫秒数)
				Application.DoEvents()
			End While
		Else
			数据流.Write(指令数据包, 0, 指令数据包.Length) ' 发送数据包
		End If
		添加日志($"[Info]RCON{服务器序号}客户端:指令数据包发送完成", Color.Black)
		MainForm.分任务进度条.Value = 35
		'读取返回响应
		If 指令 = "list" Or 指令 = "stop" Or 指令 = "save-off" Or 指令 = "save-on" Then
			添加日志($"[Info]RCON{服务器序号}客户端正在接收并读取返回数据包,接收超时时长:0.5s", Color.Black)
			If 是否循环更新界面 Then
				Dim C As Integer = 0.5 * 帧数 '循环次数
				Dim S As Double = 55 / C '每次循环增加量
				For i = 1 To C
					MainForm.分任务进度条.Value = 35 + Math.Min(CInt(S * i), 55）
					Thread.Sleep(延时毫秒数)
					Application.DoEvents()
				Next
				MainForm.分任务进度条.Value = 90
			Else
				Thread.Sleep(500)
				MainForm.分任务进度条.Value = 90
			End If
		Else
			添加日志($"[Info]RCON{服务器序号}客户端正在接收并读取返回数据包,接收超时时长:{等待时长}s", Color.Black)
			If 是否循环更新界面 Then
				Dim i As Integer
				Dim Count As Integer = 等待时长 * 帧数
				Dim S = 55 / Count
				While i <= Count
					i += 1
					Thread.Sleep(延时毫秒数)
					MainForm.分任务进度条.Value = 35 + Math.Min(CInt(S * i), 55）
					Application.DoEvents()
				End While
			Else
				Thread.Sleep(等待时长 * 1000)
				MainForm.分任务进度条.Value = 90
			End If
		End If
		Dim 完整响应 As String = ""
		Try
			While 数据流.DataAvailable
				Dim 返回值 = 读取返回数据包(服务器序号)
				If 返回值.返回的数据包请求ID = 请求ID Then
					完整响应 += 返回值.返回的有效数据
				End If
			End While
		Catch ex As IOException
			添加日志($"[ERROR]读取返回响应失败: {ex.Message}", Color.Red)
		End Try
		MainForm.分任务进度条.Value = 100
		添加日志($"[Info]MC服务器{服务器序号}指令返回信息:", Color.Orange)
		添加日志(完整响应, Color.Orange)
	End Sub
	Private Function 构建数据包(数据包类型 As Integer, 要发送的数据 As String) As Byte() ' 构建 RCON 协议数据包
		Using 数据包 As New MemoryStream()
			Using 数据包写入器 As New BinaryWriter(数据包)
				' 计算长度（长度 = 请求ID(4) + 类型(4) + 要发送的数据字节数 + 2个空字节）
				Dim 转化后的数据 = Encoding.UTF8.GetBytes(要发送的数据)
				Dim 数据包总长度 As Integer = 4 + 4 + 转化后的数据.Length + 2
				' 写入数据包
				数据包写入器.Write(数据包总长度)      ' 长度（小端序）
				数据包写入器.Write(请求ID)           ' 请求ID
				数据包写入器.Write(数据包类型)       ' 包类型
				数据包写入器.Write(转化后的数据)     ' 载荷
				数据包写入器.Write({0, 0})           ' 空字节结尾
			End Using
			Return 数据包.ToArray()
		End Using
	End Function
	Public Function 读取返回数据包(服务器序号 As String) As (返回的数据包请求ID As Integer, 返回的有效数据 As String)
		If 数据流.DataAvailable Then
			'[长度(4字节)][请求ID(4字节)][类型(4字节)][有效载荷][结尾空字节(2字节)]
			Dim 完整数据包的长度记录部分(3) As Byte
			Dim 完整数据包的长度记录部分已读取长度 As Integer = 0
			Dim 数据包除长度记录部分外的长度 As Integer
			Dim 重试计数 As Integer = 0
			' 读取长度字段（4字节）
			While 完整数据包的长度记录部分已读取长度 < 4 AndAlso 重试计数 <= 5
				Dim 当前循环的读取长度 = 数据流.Read(完整数据包的长度记录部分, 完整数据包的长度记录部分已读取长度, 4 - 完整数据包的长度记录部分已读取长度)
				'[请求ID(4字节)][类型(4字节)][有效载荷][结尾空字节(2字节)]
				If 当前循环的读取长度 = 0 Then
					重试计数 += 1
				Else
					完整数据包的长度记录部分已读取长度 += 当前循环的读取长度
				End If
			End While
			If 完整数据包的长度记录部分已读取长度 < 4 AndAlso 重试计数 >= 5 Then
				添加日志($"[ERROR]数据包长度记录读取完成前,MC服务端{服务器序号}已关闭连接", Color.Red)
				Return (-2, "空")
			End If
			' 读取剩余数据
			数据包除长度记录部分外的长度 = BitConverter.ToInt32(完整数据包的长度记录部分, 0)
			'Dim 数据包除长度记录部分外部分(数据包除长度记录部分外的长度 - 1) As Byte
			'Dim 已读数据包除长度记录部分外部分长度 As Integer = 0
			'While 已读数据包除长度记录部分外部分长度 < 数据包除长度记录部分外部分.Length
			'	Dim 单次循环中读取长度 = 数据流.Read(数据包除长度记录部分外部分,
			'							 已读数据包除长度记录部分外部分长度,
			'							 数据包除长度记录部分外部分.Length - 已读数据包除长度记录部分外部分长度)
			'	If 单次循环中读取长度 = 0 And Not 数据流.DataAvailable Then
			'		添加日志("[ERROR]RCON1客户端接收的数据包不完整", Color.Red)
			'		Return (-2, "")
			'	End If
			'	已读数据包除长度记录部分外部分长度 += 单次循环中读取长度
			'End While
			' 解析数据包

			'解析请求ID
			Dim 返回的请求ID部分(3) As Byte
			数据流.Read(返回的请求ID部分, 0, 4)
			Dim 返回的数据包请求ID As Integer = BitConverter.ToInt32(返回的请求ID部分, 0)
			'[类型(4字节)][有效载荷][结尾空字节(2字节)]

			'解析类型
			Dim 返回的数据包类型部分(3) As Byte
			数据流.Read(返回的数据包类型部分, 0, 4)
			Dim 返回的数据包类型 As Integer = BitConverter.ToInt32(返回的数据包类型部分, 0)
			'[有效载荷][结尾空字节(2字节)]

			'解析有效数据
			Dim 有效数据部分(数据包除长度记录部分外的长度 - 4 - 4 - 2 - 1) As Byte
			数据流.Read(有效数据部分, 0, 有效数据部分.Length)
			Dim 有效数据 As String = Encoding.UTF8.GetString(有效数据部分)
			'[结尾空字节(2字节)]

			'抛弃结尾
			Dim 数据包尾(1) As Byte
			数据流.Read(数据包尾, 0, 2)
			Return (返回的数据包请求ID, 有效数据)
		Else
			添加日志("[Warning]没有滞留的数据包", Color.DarkOrange)
			Return (-2, "空")
		End If
		Return (-2, "空")
	End Function
	Public Sub 断开连接(服务器序号 As String)  ' 关闭连接
		If Not 连接状态 Then Exit Sub
		MainForm.执行中的分任务.Text = "无"
		MainForm.分任务进度条.Value = 0
		数据流.Dispose()
		RCON客户端实例.Dispose()
		添加日志($"[Info]已断开RCON{服务器序号}服务器连接", Color.Orange)
	End Sub
End Class
Public Module 处理单个服务端
	Public Sub 处理单个服务器(地址 As String, 端口 As Integer, 密码 As String, 指令 As String, 服务器序号 As String)
		Dim RCON实例 As New RCON客户端()
		RCON实例.连接RCON(地址, 端口, 密码, 服务器序号)
		RCON实例.发送指令并返回响应(指令, 服务器序号)
		RCON实例.断开连接(服务器序号)
	End Sub
End Module