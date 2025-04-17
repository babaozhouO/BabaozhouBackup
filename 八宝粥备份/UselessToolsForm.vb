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
Imports System.Threading
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
		Dim 七Zip安装包路径 As String = Path.Combine(Application.StartupPath, "资源", "7z2409-x64.exe")

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
			ComboBoxRCON.Items.Add("没有可用的RCON,全给你关掉了(恼)")
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
			ComboBoxSftp.Items.Add("没有可用的SFTP,全给你关掉了(恼)")
		End If
		ComboBoxSftp.SelectedIndex = 0
	End Sub
	Private Sub SendCommand_Click(sender As Object, e As EventArgs) Handles SendCommand.Click
		Dim 选中的RCON名称 As String = ComboBoxRCON.Text
		Dim 指令 As String = Command.Text
		Dim RCON实例 As New RCON客户端
		Select Case 选中的RCON名称
			Case MC服务端1名称
				RCON实例.连接RCON(RCON1地址, RCON1端口, RCON1密码, "1")
				RCON实例.发送指令并返回响应(指令, "1")
			Case MC服务端2名称
				RCON实例.连接RCON(RCON2地址, RCON2端口, RCON2密码, "2")
				RCON实例.发送指令并返回响应(指令, "2")
			Case MC服务端3名称
				RCON实例.连接RCON(RCON3地址, RCON3端口, RCON3密码, "3")
				RCON实例.发送指令并返回响应(指令, "3")
			Case MC服务端4名称
				RCON实例.连接RCON(RCON4地址, RCON4端口, RCON4密码, "4")
				RCON实例.发送指令并返回响应(指令, "4")
			Case MC服务端5名称
				RCON实例.连接RCON(RCON5地址, RCON5端口, RCON5密码, "5")
				RCON实例.发送指令并返回响应(指令, "5")
			Case MC服务端6名称
				RCON实例.连接RCON(RCON6地址, RCON6端口, RCON6密码, "6")
				RCON实例.发送指令并返回响应(指令, "6")
			Case MC服务端7名称
				RCON实例.连接RCON(RCON7地址, RCON7端口, RCON7密码, "7")
				RCON实例.发送指令并返回响应(指令, "7")
			Case MC服务端8名称
				RCON实例.连接RCON(RCON8地址, RCON8端口, RCON8密码, "8")
				RCON实例.发送指令并返回响应(指令, "8")
			Case MC服务端9名称
				RCON实例.连接RCON(RCON9地址, RCON9端口, RCON9密码, "9")
				RCON实例.发送指令并返回响应(指令, "9")
			Case MC服务端10名称
				RCON实例.连接RCON(RCON10地址, RCON10端口, RCON10密码, "10")
				RCON实例.发送指令并返回响应(指令, "10")
			Case "所有已启用服务端"
				If 是否控制MC服务端1 Then
					RCON实例.连接RCON(RCON1地址, RCON1端口, RCON1密码, "1")
					RCON实例.发送指令并返回响应(指令, "1")
				End If
				If 是否控制MC服务端2 Then
					RCON实例.连接RCON(RCON2地址, RCON2端口, RCON2密码, "2")
					RCON实例.发送指令并返回响应(指令, "2")
				End If
				If 是否控制MC服务端3 Then
					RCON实例.连接RCON(RCON2地址, RCON2端口, RCON2密码, "2")
					RCON实例.发送指令并返回响应(指令, "2")
				End If
				If 是否控制MC服务端4 Then
					RCON实例.连接RCON(RCON4地址, RCON4端口, RCON4密码, "4")
					RCON实例.发送指令并返回响应(指令, "4")
				End If
				If 是否控制MC服务端5 Then
					RCON实例.连接RCON(RCON5地址, RCON5端口, RCON5密码, "5")
					RCON实例.发送指令并返回响应(指令, "5")
				End If
				If 是否控制MC服务端6 Then
					RCON实例.连接RCON(RCON6地址, RCON6端口, RCON6密码, "6")
					RCON实例.发送指令并返回响应(指令, "6")
				End If
				If 是否控制MC服务端7 Then
					RCON实例.连接RCON(RCON7地址, RCON7端口, RCON7密码, "7")
					RCON实例.发送指令并返回响应(指令, "7")
				End If
				If 是否控制MC服务端8 Then
					RCON实例.连接RCON(RCON8地址, RCON8端口, RCON8密码, "8")
					RCON实例.发送指令并返回响应(指令, "8")
				End If
				If 是否控制MC服务端9 Then
					RCON实例.连接RCON(RCON9地址, RCON9端口, RCON9密码, "9")
					RCON实例.发送指令并返回响应(指令, "9")
				End If
				If 是否控制MC服务端10 Then
					RCON实例.连接RCON(RCON10地址, RCON10端口, RCON10密码, "10")
					RCON实例.发送指令并返回响应(指令, "10")
				End If
			Case Else
				添加日志("[ERROR]你选了个啥玩意？？？", Color.Red)
				MsgBox("你选了个啥玩意？？？", MsgBoxStyle.Critical, "错误")
				ComboBoxRCON.SelectedIndex = 0
				Return
		End Select
		Thread.Sleep(3000) ' 等待数据包到达
		Select Case 选中的RCON名称
			Case MC服务端1名称
				RCON实例.断开连接("1")
				If RCON实例.连接状态 = False Then Return
				添加日志("[INFO]RCON1服务器连接已断开", Color.Orange)
			Case MC服务端2名称
				RCON实例.断开连接("2")
				If RCON实例.连接状态 = False Then Return
				添加日志("[INFO]RCON2服务器连接已断开", Color.Orange)
			Case MC服务端3名称
				RCON实例.断开连接("3")
				If RCON实例.连接状态 = False Then Return
				添加日志("[INFO]RCON3服务器连接已断开", Color.Orange)
			Case MC服务端4名称
				RCON实例.断开连接("4")
				If RCON实例.连接状态 = False Then Return
				添加日志("[INFO]RCON4服务器连接已断开", Color.Orange)
			Case MC服务端5名称
				RCON实例.断开连接("5")
				If RCON实例.连接状态 = False Then Return
				添加日志("[INFO]RCON5服务器连接已断开", Color.Orange)
			Case MC服务端6名称
				RCON实例.断开连接("6")
				If RCON实例.连接状态 = False Then Return
				添加日志("[INFO]RCON6服务器连接已断开", Color.Orange)
			Case MC服务端7名称
				RCON实例.断开连接("7")
				If RCON实例.连接状态 = False Then Return
				添加日志("[INFO]RCON7服务器连接已断开", Color.Orange)
			Case MC服务端8名称
				RCON实例.断开连接("8")
				If RCON实例.连接状态 = False Then Return
				添加日志("[INFO]RCON8服务器连接已断开", Color.Orange)
			Case MC服务端9名称
				RCON实例.断开连接("9")
				If RCON实例.连接状态 = False Then Return
				添加日志("[INFO]RCON9服务器连接已断开", Color.Orange)
			Case MC服务端10名称
				RCON实例.断开连接("10")
				If RCON实例.连接状态 = False Then Return
				添加日志("[INFO]RCON10服务器连接已断开", Color.Orange)
			Case "所有已启用服务端"
				If 是否控制MC服务端1 Then
					RCON实例.断开连接("1")
					If RCON实例.连接状态 = False Then Return
					添加日志("[INFO]RCON1服务器连接已断开", Color.Orange)
				End If
				If 是否控制MC服务端2 Then
					RCON实例.断开连接("2")
					If RCON实例.连接状态 = False Then Return
					添加日志("[INFO]RCON2服务器连接已断开", Color.Orange)
				End If
				If 是否控制MC服务端3 Then
					RCON实例.断开连接("3")
					If RCON实例.连接状态 = False Then Return
					添加日志("[INFO]RCON3服务器连接已断开", Color.Orange)
				End If
				If 是否控制MC服务端4 Then
					RCON实例.断开连接("4")
					If RCON实例.连接状态 = False Then Return
					添加日志("[INFO]RCON4服务器连接已断开", Color.Orange)
				End If
				If 是否控制MC服务端5 Then
					RCON实例.断开连接("5")
					If RCON实例.连接状态 = False Then Return
					添加日志("[INFO]RCON5服务器连接已断开", Color.Orange)
				End If
				If 是否控制MC服务端6 Then
					RCON实例.断开连接("6")
					If RCON实例.连接状态 = False Then Return
					添加日志("[INFO]RCON6服务器连接已断开", Color.Orange)
				End If
				If 是否控制MC服务端7 Then
					RCON实例.断开连接("7")
					If RCON实例.连接状态 = False Then Return
					添加日志("[INFO]RCON7服务器连接已断开", Color.Orange)
				End If
				If 是否控制MC服务端8 Then
					RCON实例.断开连接("8")
					If RCON实例.连接状态 = False Then Return
					添加日志("[INFO]RCON8服务器连接已断开", Color.Orange)
				End If
				If 是否控制MC服务端9 Then
					RCON实例.断开连接("9")
					If RCON实例.连接状态 = False Then Return
					添加日志("[INFO]RCON9服务器连接已断开", Color.Orange)
				End If
				If 是否控制MC服务端10 Then
					RCON实例.断开连接("10")
					If RCON实例.连接状态 = False Then Return
					添加日志("[INFO]RCON10服务器连接已断开", Color.Orange)
				End If
		End Select
	End Sub

	Private Sub ChooseFile_Click(sender As Object, e As EventArgs) Handles ChooseFile.Click
		选择文件.ShowDialog()
	End Sub

	Private Sub FileSend_Click(sender As Object, e As EventArgs) Handles FileSend.Click
		Dim 选中的Sftp名称 As String = ComboBoxSftp.Text
		Dim 本地文件路径 As String = 选择文件.FileName
		Dim 远程目录路径 As String = 远程目录.Text
		If 远程目录路径 = "" Then
			远程目录路径 = "/"
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
		If Not ComboBoxRCON.Text = "没有可用的RCON,全给你关掉了(恼)" Then
			添加日志("[Action]启动所有已启用的MC服务端", Color.Orange)
			启动MC服务器()
		Else
			添加日志("没有可用的RCON,全给你关掉了(恼)", Color.Red)
		End If
	End Sub
End Class