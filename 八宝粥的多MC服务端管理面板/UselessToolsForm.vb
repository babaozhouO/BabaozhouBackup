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
Imports System.ComponentModel
Imports System.IO
Public Class UselessToolsForm
	Private Sub 添加日志(信息 As String, 颜色 As Color)
		日志窗口.添加日志(信息, 颜色)
	End Sub
	Private Sub UselessToolsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
		初始化RCON选择项()
		初始化Sftp选择项()
	End Sub
	' 窗口激活时更新日志位置
	Private Sub UselessToolsForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
		If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
			日志窗口.更新停靠位置(Me)
		End If
	End Sub
	' 窗口移动时更新日志位置
	Private Sub UselessToolsForm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
		If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
			日志窗口.更新停靠位置(Me)
		End If
	End Sub
	Private Sub 安装7Zip_Click(sender As Object, e As EventArgs) Handles 安装7Zip.Click
		Dim 七Zip安装包路径 As String = Path.Combine(程序数据目录, "资源", "7z2409-x64.exe")
		If Not File.Exists(七Zip安装包路径) Then
			添加日志("[ERROR]资源文件被你删了", Color.Red)
			MsgBox("你个坏蛋,把我的资源文件删了！", MsgBoxStyle.Critical, "坏蛋！")
			Return
		End If
		If Not 是否以管理员身份运行() Then
			添加日志("[ERROR]都叫你用管理员身份运行此程序了,你就是不听", Color.Red)
			MsgBox("都叫你用管理员身份运行此程序了,你就是不听", MsgBoxStyle.Critical, "错误")
			Return
		End If
		Process.Start(七Zip安装包路径)
	End Sub
	Private Sub 退出_Click(sender As Object, e As EventArgs) Handles 退出.Click
		Dim 用户选择 As Integer = MessageBox.Show("确认退出?", "提示", MessageBoxButtons.YesNo)
		If 用户选择 = DialogResult.Yes Then
			Me.Close()
		End If
	End Sub
	Private Sub 初始化RCON选择项()
		ComboBoxRCON.Items.Clear()
		If 是否控制MC服务端1 Then
			ComboBoxRCON.Items.Add(MC服务端1名称)
		End If
		If 是否控制MC服务端2 Then
			ComboBoxRCON.Items.Add(MC服务端2名称)
		End If
		If 是否控制MC服务端3 Then
			ComboBoxRCON.Items.Add(MC服务端3名称)
		End If
		If 是否控制MC服务端4 Then
			ComboBoxRCON.Items.Add(MC服务端4名称)
		End If
		If 是否控制MC服务端5 Then
			ComboBoxRCON.Items.Add(MC服务端5名称)
		End If
		If 是否控制MC服务端6 Then
			ComboBoxRCON.Items.Add(MC服务端6名称)
		End If
		If 是否控制MC服务端7 Then
			ComboBoxRCON.Items.Add(MC服务端7名称)
		End If
		If 是否控制MC服务端8 Then
			ComboBoxRCON.Items.Add(MC服务端8名称)
		End If
		If 是否控制MC服务端9 Then
			ComboBoxRCON.Items.Add(MC服务端9名称)
		End If
		If 是否控制MC服务端10 Then
			ComboBoxRCON.Items.Add(MC服务端10名称)
		End If
		If ComboBoxRCON.Items.Count = 0 Then
			ComboBoxRCON.Items.Add("没有可用的RCON服务端,全给你关掉了(恼)")
		Else
			ComboBoxRCON.Items.Add("所有已启用服务端"）
		End If
		ComboBoxRCON.SelectedIndex = 0
	End Sub
	Private Sub 初始化Sftp选择项()
		ComboBoxSftp.Items.Clear()
		If Sftp1开关 Then
			ComboBoxSftp.Items.Add(Sftp1名称)
		End If
		If Sftp2开关 Then
			ComboBoxSftp.Items.Add(Sftp2名称)
		End If
		If Sftp3开关 Then
			ComboBoxSftp.Items.Add(Sftp3名称)
		End If
		If ComboBoxSftp.Items.Count = 0 Then
			ComboBoxSftp.Items.Add("没有可用的SFTP服务器,全给你关掉了(恼)")
		End If
		ComboBoxSftp.SelectedIndex = 0
	End Sub
	Private RCON实例1 As New RCON客户端
	Private RCON实例2 As New RCON客户端
	Private RCON实例3 As New RCON客户端
	Private RCON实例4 As New RCON客户端
	Private RCON实例5 As New RCON客户端
	Private RCON实例6 As New RCON客户端
	Private RCON实例7 As New RCON客户端
	Private RCON实例8 As New RCON客户端
	Private RCON实例9 As New RCON客户端
	Private RCON实例10 As New RCON客户端
	Private Sub Connect_Click(sender As Object, e As EventArgs) Handles Connect.Click
		Dim 选中的RCON名称 As String = ComboBoxRCON.Text
		Dim 指令 As String = Command.Text
		Dim 等待时长 As Integer = CInt(WaitingSeconds.Text)
		Select Case 选中的RCON名称
			Case MC服务端1名称
				RCON实例1.连接RCON(RCON1地址, RCON1端口, RCON1密码, "1")
			Case MC服务端2名称
				RCON实例2.连接RCON(RCON2地址, RCON2端口, RCON2密码, "2")
			Case MC服务端3名称
				RCON实例3.连接RCON(RCON3地址, RCON3端口, RCON3密码, "3")
			Case MC服务端4名称
				RCON实例4.连接RCON(RCON4地址, RCON4端口, RCON4密码, "4")
			Case MC服务端5名称
				RCON实例5.连接RCON(RCON5地址, RCON5端口, RCON5密码, "5")
			Case MC服务端6名称
				RCON实例6.连接RCON(RCON6地址, RCON6端口, RCON6密码, "6")
			Case MC服务端7名称
				RCON实例7.连接RCON(RCON7地址, RCON7端口, RCON7密码, "7")
			Case MC服务端8名称
				RCON实例8.连接RCON(RCON8地址, RCON8端口, RCON8密码, "8")
			Case MC服务端9名称
				RCON实例9.连接RCON(RCON9地址, RCON9端口, RCON9密码, "9")
			Case MC服务端10名称
				RCON实例10.连接RCON(RCON10地址, RCON10端口, RCON10密码, "10")
			Case "所有已启用服务端"
				If 是否控制MC服务端1 Then
					RCON实例1.连接RCON(RCON1地址, RCON1端口, RCON1密码, "1")
				End If
				If 是否控制MC服务端2 Then
					RCON实例2.连接RCON(RCON2地址, RCON2端口, RCON2密码, "2")
				End If
				If 是否控制MC服务端3 Then
					RCON实例3.连接RCON(RCON2地址, RCON2端口, RCON2密码, "2")
				End If
				If 是否控制MC服务端4 Then
					RCON实例4.连接RCON(RCON4地址, RCON4端口, RCON4密码, "4")
				End If
				If 是否控制MC服务端5 Then
					RCON实例5.连接RCON(RCON5地址, RCON5端口, RCON5密码, "5")
				End If
				If 是否控制MC服务端6 Then
					RCON实例6.连接RCON(RCON6地址, RCON6端口, RCON6密码, "6")
				End If
				If 是否控制MC服务端7 Then
					RCON实例7.连接RCON(RCON7地址, RCON7端口, RCON7密码, "7")
				End If
				If 是否控制MC服务端8 Then
					RCON实例8.连接RCON(RCON8地址, RCON8端口, RCON8密码, "8")
				End If
				If 是否控制MC服务端9 Then
					RCON实例9.连接RCON(RCON9地址, RCON9端口, RCON9密码, "9")
				End If
				If 是否控制MC服务端10 Then
					RCON实例10.连接RCON(RCON10地址, RCON10端口, RCON10密码, "10")
				End If
			Case Else
				添加日志("[ERROR]你选了个啥玩意？？？", Color.Red)
				MsgBox("你选了个啥玩意？？？", MsgBoxStyle.Critical, "错误")
				ComboBoxRCON.SelectedIndex = 0
				Return
		End Select
		If RCON实例1.连接状态 Or RCON实例2.连接状态 Or RCON实例3.连接状态 Or RCON实例4.连接状态 Or RCON实例5.连接状态 Or RCON实例6.连接状态 Or RCON实例7.连接状态 Or RCON实例8.连接状态 Or RCON实例9.连接状态 Or RCON实例10.连接状态 Then
			Connect.Enabled = False
			Send.Enabled = True
			DisConnect.Enabled = True
			GetMissedMessage.Enabled = False
		End If
	End Sub
	Private Sub Send_Click(sender As Object, e As EventArgs) Handles Send.Click
		Dim 等待时长 As Integer = CInt(WaitingSeconds.Text)
		Dim 指令 As String = Command.Text
		Select Case ComboBoxRCON.Text
			Case MC服务端1名称
				RCON实例1.发送指令并返回响应(指令, "1", 等待时长)
			Case MC服务端2名称
				RCON实例2.发送指令并返回响应(指令, "2", 等待时长)
			Case MC服务端3名称
				RCON实例3.发送指令并返回响应(指令, "3", 等待时长)
			Case MC服务端4名称
				RCON实例4.发送指令并返回响应(指令, "4", 等待时长)
			Case MC服务端5名称
				RCON实例5.发送指令并返回响应(指令, "5", 等待时长)
			Case MC服务端6名称
				RCON实例6.发送指令并返回响应(指令, "6", 等待时长)
			Case MC服务端7名称
				RCON实例7.发送指令并返回响应(指令, "7", 等待时长)
			Case MC服务端8名称
				RCON实例8.发送指令并返回响应(指令, "8", 等待时长)
			Case MC服务端9名称
				RCON实例9.发送指令并返回响应(指令, "9", 等待时长)
			Case MC服务端10名称
				RCON实例10.发送指令并返回响应(指令, "10", 等待时长)
			Case "所有已启用服务端"
				If 是否控制MC服务端1 Then
					RCON实例1.发送指令并返回响应(指令, "1", 等待时长)
				End If
				If 是否控制MC服务端2 Then
					RCON实例2.发送指令并返回响应(指令, "2", 等待时长)
				End If
				If 是否控制MC服务端3 Then
					RCON实例3.发送指令并返回响应(指令, "3", 等待时长)
				End If
				If 是否控制MC服务端4 Then
					RCON实例4.发送指令并返回响应(指令, "4", 等待时长)
				End If
				If 是否控制MC服务端5 Then
					RCON实例5.发送指令并返回响应(指令, "5", 等待时长)
				End If
				If 是否控制MC服务端6 Then
					RCON实例6.发送指令并返回响应(指令, "6", 等待时长)
				End If
				If 是否控制MC服务端7 Then
					RCON实例7.发送指令并返回响应(指令, "7", 等待时长)
				End If
				If 是否控制MC服务端8 Then
					RCON实例8.发送指令并返回响应(指令, "8", 等待时长)
				End If
				If 是否控制MC服务端9 Then
					RCON实例9.发送指令并返回响应(指令, "9", 等待时长)
				End If
				If 是否控制MC服务端10 Then
					RCON实例10.发送指令并返回响应(指令, "10", 等待时长)
				End If
		End Select
		GetMissedMessage.Enabled = True
	End Sub
	Private Sub DisConnect_Click(sender As Object, e As EventArgs) Handles DisConnect.Click
		Dim 选中的RCON名称 As String = ComboBoxRCON.Text
		Select Case 选中的RCON名称
			Case MC服务端1名称
				RCON实例1.断开连接("1")
			Case MC服务端2名称
				RCON实例2.断开连接("2")
			Case MC服务端3名称
				RCON实例3.断开连接("3")
			Case MC服务端4名称
				RCON实例4.断开连接("4")
			Case MC服务端5名称
				RCON实例5.断开连接("5")
			Case MC服务端6名称
				RCON实例6.断开连接("6")
			Case MC服务端7名称
				RCON实例7.断开连接("7")
			Case MC服务端8名称
				RCON实例8.断开连接("8")
			Case MC服务端9名称
				RCON实例9.断开连接("9")
			Case MC服务端10名称
				RCON实例10.断开连接("10")
			Case "所有已启用服务端"
				If 是否控制MC服务端1 Then
					RCON实例1.断开连接("1")
				End If
				If 是否控制MC服务端2 Then
					RCON实例2.断开连接("2")
				End If
				If 是否控制MC服务端3 Then
					RCON实例3.断开连接("3")
				End If
				If 是否控制MC服务端4 Then
					RCON实例4.断开连接("4")
				End If
				If 是否控制MC服务端5 Then
					RCON实例5.断开连接("5")
				End If
				If 是否控制MC服务端6 Then
					RCON实例6.断开连接("6")
				End If
				If 是否控制MC服务端7 Then
					RCON实例7.断开连接("7")
				End If
				If 是否控制MC服务端8 Then
					RCON实例8.断开连接("8")
				End If
				If 是否控制MC服务端9 Then
					RCON实例9.断开连接("9")
				End If
				If 是否控制MC服务端10 Then
					RCON实例10.断开连接("10")
				End If
		End Select
		Connect.Enabled = True
		Send.Enabled = False
		DisConnect.Enabled = False
		GetMissedMessage.Enabled = False
	End Sub
	Private Sub GetMissedMessage_Click(sender As Object, e As EventArgs) Handles GetMissedMessage.Click
		Dim 返回值 As String = ""
		Dim 服务器序号 As Integer
		Select Case ComboBoxRCON.Text
			Case MC服务端1名称
				返回值 = RCON实例1.读取返回数据包("1").返回的有效数据
				服务器序号 = 1
			Case MC服务端2名称
				返回值 = RCON实例1.读取返回数据包("2").返回的有效数据
				服务器序号 = 2
			Case MC服务端3名称
				返回值 = RCON实例1.读取返回数据包("3").返回的有效数据
				服务器序号 = 3
			Case MC服务端4名称
				返回值 = RCON实例1.读取返回数据包("4").返回的有效数据
				服务器序号 = 4
			Case MC服务端5名称
				返回值 = RCON实例1.读取返回数据包("5").返回的有效数据
				服务器序号 = 5
			Case MC服务端6名称
				返回值 = RCON实例1.读取返回数据包("6").返回的有效数据
				服务器序号 = 6
			Case MC服务端7名称
				返回值 = RCON实例1.读取返回数据包("7").返回的有效数据
				服务器序号 = 7
			Case MC服务端8名称
				返回值 = RCON实例1.读取返回数据包("8").返回的有效数据
				服务器序号 = 8
			Case MC服务端9名称
				返回值 = RCON实例1.读取返回数据包("9").返回的有效数据
				服务器序号 = 9
			Case MC服务端10名称
				返回值 = RCON实例1.读取返回数据包("10").返回的有效数据
				服务器序号 = 10
		End Select
		添加日志($"[Info]MC服务器{服务器序号}指令返回信息:", Color.Orange)
		添加日志(返回值, Color.Orange)
	End Sub
	Private Sub ChooseFile_Click(sender As Object, e As EventArgs) Handles ChooseFile.Click
		选择文件.ShowDialog()
	End Sub
	Private Sub FileSend_Click(sender As Object, e As EventArgs) Handles FileSend.Click
		Dim 选中的Sftp名称 As String = ComboBoxSftp.Text
		Dim 本地文件路径 As String = 选择文件.FileName
		Dim 远程目录路径 As String = 远程目录.Text
		If 远程目录路径 = "" Then
			远程目录路径 = "\\"
		End If
		Select Case 选中的Sftp名称
			Case Sftp1名称
				处理单个Sftp服务端_上传文件(Sftp1地址, Sftp1端口, Sftp1用户名, Sftp1密码, "1", 本地文件路径, 远程目录路径)
			Case Sftp2名称
				处理单个Sftp服务端_上传文件(Sftp2地址, Sftp2端口, Sftp2用户名, Sftp2密码, "2", 本地文件路径, 远程目录路径)
			Case Sftp3名称
				处理单个Sftp服务端_上传文件(Sftp3地址, Sftp3端口, Sftp3用户名, Sftp3密码, "3", 本地文件路径, 远程目录路径)
			Case Else
				添加日志("[ERROR]你选了个啥玩意？？？", Color.Red)
				MessageBox.Show("你选了个啥玩意？？？", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
				ComboBoxSftp.SelectedIndex = 0
		End Select
	End Sub
	Private Sub 启动MC服务端_Click(sender As Object, e As EventArgs) Handles 启动MC服务端.Click
		倒计时冷却.Interval = 30000
		倒计时冷却.Enabled = True
		启动MC服务端.Enabled = False
		启动MC服务端.Text = "启动已启用的MC服务端(冷却中)"
		If Not ComboBoxRCON.Text = "没有可用的RCON服务端,全给你关掉了(恼)" Then
			添加日志("[Action]启动所有已启用的MC服务端", Color.Orange)
			Dim H As New 核心功能类
			H.启动MC服务器()
		Else
			添加日志("没有可用的MC服务端,全给你关掉了(恼)", Color.Red)
		End If
	End Sub
	Private Sub 冷却结束() Handles 倒计时冷却.Tick
		倒计时冷却.Enabled = False
		启动MC服务端.Enabled = True
		启动MC服务端.Text = "启动已启用的MC服务端"
	End Sub

	Private Sub UselessToolsForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
		RCON实例1 = Nothing
		RCON实例2 = Nothing
		RCON实例3 = Nothing
		RCON实例4 = Nothing
		RCON实例5 = Nothing
		RCON实例6 = Nothing
		RCON实例7 = Nothing
		RCON实例8 = Nothing
		RCON实例9 = Nothing
		RCON实例10 = Nothing
	End Sub
End Class