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
Public Class MCServerSettingsForm
	Private Sub 添加日志(信息 As String, 颜色 As Color)
		日志窗口.添加日志(信息, 颜色)
	End Sub
	Private Sub ButtonCancle_Click(sender As Object, e As EventArgs) Handles ButtonCancle.Click
		Dim 用户选择 As Integer = MessageBox.Show("是否放弃保存设置并退出?", "提示", MessageBoxButtons.YesNo)
		If 用户选择 = DialogResult.Yes Then
			添加日志("[Action]关闭RCON服务器设置窗口", Color.Black)
			Me.Close()
		End If
	End Sub
	Private Sub ButtonSaveAndExit_Click(sender As Object, e As EventArgs) Handles ButtonSaveAndExit.Click
		Dim 用户选择 As Integer = MessageBox.Show("是否保存设置并退出?", "提示", MessageBoxButtons.YesNo)
		If 用户选择 = DialogResult.Yes Then
			保存RCON配置()
			添加日志("[Success]成功保存RCON服务器设置", Color.Green)
			添加日志("[Action]关闭RCON服务器设置窗口", Color.Black)
			日志窗口.日志输出RCON配置()
			添加日志("-------------------------------------------------------------------------------------", Color.Black)
			Me.Close()
		End If
	End Sub
	Private Sub 开关控件1_状态变化(新状态 As Boolean) Handles 开关控件1.状态变化
		If 新状态 Then
			是否控制MC服务端1 = True
		Else
			是否控制MC服务端1 = False
		End If
	End Sub
	Private Sub 开关控件2_状态变化(新状态 As Boolean) Handles 开关控件2.状态变化
		If 新状态 Then
			是否控制MC服务端2 = True
		Else
			是否控制MC服务端2 = False
		End If
	End Sub
	Private Sub 开关控件3_状态变化(新状态 As Boolean) Handles 开关控件3.状态变化
		If 新状态 Then
			是否控制MC服务端3 = True
		Else
			是否控制MC服务端3 = False
		End If
	End Sub
	Private Sub 开关控件4_状态变化(新状态 As Boolean) Handles 开关控件4.状态变化
		If 新状态 Then
			是否控制MC服务端4 = True
		Else
			是否控制MC服务端4 = False
		End If
	End Sub
	Private Sub 开关控件5_状态变化(新状态 As Boolean) Handles 开关控件5.状态变化
		If 新状态 Then
			是否控制MC服务端5 = True
		Else
			是否控制MC服务端5 = False
		End If
	End Sub
	Private Sub 开关控件6_状态变化(新状态 As Boolean) Handles 开关控件6.状态变化
		If 新状态 Then
			是否控制MC服务端6 = True
		Else
			是否控制MC服务端6 = False
		End If
	End Sub
	Private Sub 开关控件7_状态变化(新状态 As Boolean) Handles 开关控件7.状态变化
		If 新状态 Then
			是否控制MC服务端7 = True
		Else
			是否控制MC服务端7 = False
		End If
	End Sub
	Private Sub 开关控件8_状态变化(新状态 As Boolean) Handles 开关控件8.状态变化
		If 新状态 Then
			是否控制MC服务端8 = True
		Else
			是否控制MC服务端8 = False
		End If
	End Sub
	Private Sub 开关控件9_状态变化(新状态 As Boolean) Handles 开关控件9.状态变化
		If 新状态 Then
			是否控制MC服务端9 = True
		Else
			是否控制MC服务端9 = False
		End If
	End Sub
	Private Sub 开关控件10_状态变化(新状态 As Boolean) Handles 开关控件10.状态变化
		If 新状态 Then
			是否控制MC服务端10 = True
		Else
			是否控制MC服务端10 = False
		End If
	End Sub
	Private Sub RCONSettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		加载RCON配置()
	End Sub
	' 窗口激活时更新日志位置
	Private Sub RCONSettingsForm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
		If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
			日志窗口.更新停靠位置(Me)
		End If
	End Sub
	' 窗口激活时更新日志位置
	Private Sub RCONSettingsForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
		If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
			日志窗口.更新停靠位置(Me)
		End If
	End Sub
	Private Sub 加载RCON配置()
		读取MC服务端配置()
		'加载RCON1配置
		If 是否控制MC服务端1 Then 开关控件1.切换状态()
		MCServer1.Text = MC服务端1名称
		名称1.Text = MC服务端1名称
		地址1.Text = RCON1地址
		端口1.Text = RCON1端口
		密码1.Text = RCON1密码
		TextBox11.Text = MC服务端1启动脚本名称
		TextBox1.Text = MC服务端1路径
		'加载RCON2配置
		If 是否控制MC服务端2 Then 开关控件2.切换状态()
		MCServer2.Text = MC服务端2名称
		名称2.Text = MC服务端2名称
		地址2.Text = RCON2地址
		端口2.Text = RCON2端口
		密码2.Text = RCON2密码
		TextBox12.Text = MC服务端2启动脚本名称
		TextBox2.Text = MC服务端2路径
		'加载RCON3配置
		If 是否控制MC服务端3 Then 开关控件3.切换状态()
		MCServer3.Text = MC服务端3名称
		名称3.Text = MC服务端3名称
		地址3.Text = RCON3地址
		端口3.Text = RCON3端口
		密码3.Text = RCON3密码
		TextBox13.Text = MC服务端3启动脚本名称
		TextBox3.Text = MC服务端3路径
		'加载RCON4配置
		If 是否控制MC服务端4 Then 开关控件4.切换状态()
		MCServer4.Text = MC服务端4名称
		名称4.Text = MC服务端4名称
		地址4.Text = RCON4地址
		端口4.Text = RCON4端口
		密码4.Text = RCON4密码
		TextBox14.Text = MC服务端4启动脚本名称
		TextBox4.Text = MC服务端4路径
		'加载RCON5配置
		If 是否控制MC服务端5 Then 开关控件5.切换状态()
		MCServer5.Text = MC服务端5名称
		名称5.Text = MC服务端5名称
		地址5.Text = RCON5地址
		端口5.Text = RCON5端口
		密码5.Text = RCON5密码
		TextBox15.Text = MC服务端5启动脚本名称
		TextBox5.Text = MC服务端5路径
		'加载RCON6配置
		If 是否控制MC服务端6 Then 开关控件6.切换状态()
		MCServer6.Text = MC服务端6名称
		名称6.Text = MC服务端6名称
		地址6.Text = RCON6地址
		端口6.Text = RCON6端口
		密码6.Text = RCON6密码
		TextBox21.Text = MC服务端6启动脚本名称
		TextBox6.Text = MC服务端6路径
		'加载RCON7配置
		If 是否控制MC服务端7 Then 开关控件7.切换状态()
		MCServer7.Text = MC服务端7名称
		名称7.Text = MC服务端7名称
		地址7.Text = RCON7地址
		端口7.Text = RCON7端口
		密码7.Text = RCON7密码
		TextBox22.Text = MC服务端7启动脚本名称
		TextBox7.Text = MC服务端7路径
		'加载RCON8配置
		If 是否控制MC服务端8 Then 开关控件8.切换状态()
		MCServer8.Text = MC服务端8名称
		名称8.Text = MC服务端8名称
		地址8.Text = RCON8地址
		端口8.Text = RCON8端口
		密码8.Text = RCON8密码
		TextBox23.Text = MC服务端8启动脚本名称
		TextBox8.Text = MC服务端8路径
		'加载RCON9配置
		If 是否控制MC服务端9 Then 开关控件9.切换状态()
		MCServer9.Text = MC服务端9名称
		名称9.Text = MC服务端9名称
		地址9.Text = RCON9地址
		端口9.Text = RCON9端口
		密码9.Text = RCON9密码
		TextBox24.Text = MC服务端9启动脚本名称
		TextBox9.Text = MC服务端9路径
		'加载RCON10配置
		If 是否控制MC服务端10 Then 开关控件10.切换状态()
		MCServer10.Text = MC服务端10名称
		名称10.Text = MC服务端10名称
		地址10.Text = RCON10地址
		端口10.Text = RCON10端口
		密码10.Text = RCON10密码
		TextBox25.Text = MC服务端10启动脚本名称
		TextBox10.Text = MC服务端10路径
	End Sub
	Private Sub 保存RCON配置()
		写入MC服务端配置(1, 是否控制MC服务端1, 名称1.Text, 地址1.Text, 端口1.Text, 密码1.Text, TextBox1.Text, TextBox11.Text, TextBox16.Text)
		写入MC服务端配置(2, 是否控制MC服务端2, 名称2.Text, 地址2.Text, 端口2.Text, 密码2.Text, TextBox2.Text, TextBox12.Text, TextBox17.Text)
		写入MC服务端配置(3, 是否控制MC服务端3, 名称3.Text, 地址3.Text, 端口3.Text, 密码3.Text, TextBox3.Text, TextBox13.Text, TextBox18.Text)
		写入MC服务端配置(4, 是否控制MC服务端4, 名称4.Text, 地址4.Text, 端口4.Text, 密码4.Text, TextBox4.Text, TextBox14.Text, TextBox19.Text)
		写入MC服务端配置(5, 是否控制MC服务端5, 名称5.Text, 地址5.Text, 端口5.Text, 密码5.Text, TextBox5.Text, TextBox15.Text, TextBox20.Text)
		写入MC服务端配置(6, 是否控制MC服务端6, 名称6.Text, 地址6.Text, 端口6.Text, 密码6.Text, TextBox6.Text, TextBox21.Text, TextBox26.Text)
		写入MC服务端配置(7, 是否控制MC服务端7, 名称7.Text, 地址7.Text, 端口7.Text, 密码7.Text, TextBox7.Text, TextBox22.Text, TextBox27.Text)
		写入MC服务端配置(8, 是否控制MC服务端8, 名称8.Text, 地址8.Text, 端口8.Text, 密码8.Text, TextBox8.Text, TextBox23.Text, TextBox28.Text)
		写入MC服务端配置(9, 是否控制MC服务端9, 名称9.Text, 地址9.Text, 端口9.Text, 密码9.Text, TextBox9.Text, TextBox24.Text, TextBox29.Text)
		写入MC服务端配置(10, 是否控制MC服务端10, 名称10.Text, 地址10.Text, 端口10.Text, 密码10.Text, TextBox10.Text, TextBox25.Text, TextBox30.Text)
	End Sub
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Using FolderBrowserDialog As New FolderBrowserDialog
			If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
				TextBox1.Text = FolderBrowserDialog.SelectedPath
			End If
		End Using
	End Sub
	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Using FolderBrowserDialog As New FolderBrowserDialog
			If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
				TextBox2.Text = FolderBrowserDialog.SelectedPath
			End If
		End Using
	End Sub
	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button4.Click
		Using FolderBrowserDialog As New FolderBrowserDialog
			If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
				TextBox4.Text = FolderBrowserDialog.SelectedPath
			End If
		End Using
	End Sub
	Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button3.Click
		Using FolderBrowserDialog As New FolderBrowserDialog
			If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
				TextBox3.Text = FolderBrowserDialog.SelectedPath
			End If
		End Using
	End Sub
	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
		Using FolderBrowserDialog As New FolderBrowserDialog
			If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
				TextBox5.Text = FolderBrowserDialog.SelectedPath
			End If
		End Using
	End Sub
	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
		Using FolderBrowserDialog As New FolderBrowserDialog()
			If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then
				TextBox6.Text = FolderBrowserDialog.SelectedPath
			End If
		End Using
	End Sub
	Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
		Using FolderBrowserDialog As New FolderBrowserDialog()
			If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then
				TextBox7.Text = FolderBrowserDialog.SelectedPath
			End If
		End Using
	End Sub
	Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
		Using FolderBrowserDialog As New FolderBrowserDialog()
			If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then
				TextBox8.Text = FolderBrowserDialog.SelectedPath
			End If
		End Using
	End Sub
	Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
		Using FolderBrowserDialog As New FolderBrowserDialog()
			If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then
				TextBox9.Text = FolderBrowserDialog.SelectedPath
			End If
		End Using
	End Sub
	Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
		Using FolderBrowserDialog As New FolderBrowserDialog()
			If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then
				TextBox10.Text = FolderBrowserDialog.SelectedPath
			End If
		End Using
	End Sub
End Class