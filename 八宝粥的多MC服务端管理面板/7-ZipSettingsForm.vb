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
Public Class SevenZipSettingsForm
	Private Sub 添加日志(信息 As String, 颜色 As Color)
		日志窗口.添加日志(信息, 颜色)
	End Sub
	Private Sub ButtonCancle_Click(sender As Object, e As EventArgs) Handles ButtonCancle.Click
		Dim 用户选择 As DialogResult = MessageBox.Show("是否放弃保存设置并退出?", "提示", MessageBoxButtons.YesNo)
		If 用户选择 = DialogResult.Yes Then
			添加日志("[Action]关闭7-Zip设置窗口", Color.Black)
			Me.Close()
		End If
	End Sub
	Private Sub ButtonSaveAndExit_Click(sender As Object, e As EventArgs) Handles ButtonSaveAndExit.Click
		Dim 用户选择 As DialogResult = MessageBox.Show("是否保存设置并退出?", "提示", MessageBoxButtons.YesNo)
		If CheckBox1.Checked Then
			是否增量备份 = True
		Else
			是否增量备份 = False
		End If
		If CheckBox2.Checked Then
			是否备份自定义目录 = True
		Else
			是否备份自定义目录 = False
		End If
		Select Case 选择压缩格式.SelectedIndex
			Case 0 '7z
				压缩格式 = "7z"
				Select Case 选择压缩方法.SelectedIndex
					Case 0 'LMZA2
						压缩方法 = "LMZA2"
					Case 1 'LMZA
						压缩方法 = "LMZA"
					Case 2 'PPMd
						压缩方法 = "PPMd"
					Case 3 'BZip2
						压缩方法 = "BZip2"
				End Select
			Case 1 'tar
				压缩格式 = "tar"
				Select Case 选择压缩方法.SelectedIndex
					Case 0
						压缩方法 = "GNU"
					Case 1
						压缩方法 = "POSIX"
				End Select
			Case 2 'wim
				压缩格式 = "wim"
				压缩方法 = ""
			Case 3 'zip
				压缩格式 = "zip"
				Select Case 选择压缩方法.SelectedIndex
					Case 0
						压缩方法 = "Deflate"
					Case 1
						压缩方法 = "Deflate64"
					Case 2
						压缩方法 = "BZip2"
					Case 3
						压缩方法 = "LMZA"
					Case 4
						压缩方法 = "PPMd"
				End Select
		End Select
		压缩级别 = 选择压缩级别.SelectedIndex
		If 用户选择 = DialogResult.Yes Then
			写入7zip配置(压缩格式, 压缩级别, 压缩方法, CInt(TextBox3.Text), TextBox1.Text, TextBox2.Text, 是否增量备份, 是否备份自定义目录, CPU线程数.Text)
			添加日志("[Success]成功保存7-Zip设置", Color.Green)
			日志窗口.日志输出7zip配置()
			添加日志("--------------------------------------------------------------", Color.Black)
			添加日志("[Action]关闭7-Zip设置窗口", Color.Black)
			Me.Close()
		End If
	End Sub
	Private Sub SevenZipSettingsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
		日志窗口.更新停靠位置(Me)
		初始化配置项()
	End Sub
	' 窗口激活时更新日志位置
	Private Sub SevenZipSettingsForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
		If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
			日志窗口.更新停靠位置(Me)
		End If
	End Sub
	' 窗口移动时更新日志位置
	Private Sub SevenZipSettingsForm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
		If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
			日志窗口.更新停靠位置(Me)
		End If
	End Sub
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Using FolderBrowserDialog As New FolderBrowserDialog
			If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
				TextBox2.Text = FolderBrowserDialog.SelectedPath
			End If
		End Using
	End Sub
	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Using FolderBrowserDialog As New FolderBrowserDialog
			If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
				TextBox1.Text = FolderBrowserDialog.SelectedPath
			End If
		End Using
	End Sub
	Private Sub 初始化配置项()
		读取7zip配置()
		Select Case 压缩格式
			Case "7z"
				选择压缩格式.SelectedIndex = 0
				Select Case 压缩方法
					Case "LMZA2"
						选择压缩方法.SelectedIndex = 0
					Case "LMZA"
						选择压缩方法.SelectedIndex = 1
					Case "PPMd"
						选择压缩方法.SelectedIndex = 2
					Case "BZip2"
						选择压缩方法.SelectedIndex = 3
				End Select
			Case "tar"
				选择压缩格式.SelectedIndex = 1
				选择压缩级别.Enabled = False
				Select Case 压缩方法
					Case "GNU"
						选择压缩方法.SelectedIndex = 0
					Case "POSIX"
						选择压缩方法.SelectedIndex = 1
				End Select
				CPU线程数.Enabled = False
			Case "wim"
				选择压缩格式.SelectedIndex = 2
				选择压缩级别.Enabled = False
				选择压缩方法.Enabled = False
				选择压缩方法.SelectedIndex = -1
				CPU线程数.Enabled = False
			Case "zip"
				选择压缩格式.SelectedIndex = 3
				Select Case 压缩方法
					Case "Deflate"
						选择压缩方法.SelectedIndex = 0
					Case "Deflate64"
						选择压缩方法.SelectedIndex = 1
					Case "BZip2"
						选择压缩方法.SelectedIndex = 2
					Case "LMZA"
						选择压缩方法.SelectedIndex = 3
					Case "PPMd"
						选择压缩方法.SelectedIndex = 4
				End Select
		End Select
		选择压缩级别.SelectedIndex = 压缩级别
		CPU线程数.Text = 线程数
		TextBox1.Text = 自定义备份目录
		TextBox2.Text = 备份输出目录
		TextBox3.Text = 超时时长.ToString
		If 是否增量备份 Then
			CheckBox1.Checked = True
		Else
			CheckBox1.Checked = False
		End If
		If 是否备份自定义目录 Then
			CheckBox2.Checked = True
		Else
			CheckBox2.Checked = False
		End If
	End Sub
	Private Sub 选择压缩格式_索引变化(sender As Object, e As EventArgs) Handles 选择压缩格式.SelectedIndexChanged
		Dim Sevenzip As Object() = New Object() {"LMZA2-压缩率最高,兼容性较差", "LMZA-压缩率稍低,兼容性较差", "PPMd-高效压缩纯文本", "BZip2-兼容性较好(Linux)"}
		Dim tar As Object = New Object() {"GNU", "POSIX"}
		Dim zip As Object = New Object() {"Deflate-压缩率中等", "Deflate64-压缩率较高", "BZip2-兼容性较好(Linux)", "LMZA-压缩率最高,兼容性较差", "PPMd-高效压缩纯文本"}
		选择压缩方法.Items.Clear()
		Select Case 选择压缩格式.SelectedIndex
			Case 0 '7z
				选择压缩级别.Enabled = True
				CPU线程数.Enabled = True
				选择压缩方法.Items.AddRange(Sevenzip)
				If Not 选择压缩方法.Text = "LMZA2-压缩率最高,兼容性较差" Then
					If Not 选择压缩方法.Text = "LMZA-压缩率稍低,兼容性较差" Then
						If Not 选择压缩方法.Text = "PPMd-高效压缩纯文本" Then
							If Not 选择压缩方法.Text = "BZip2-兼容性较好(Linux)" Then
								选择压缩方法.SelectedIndex = 0
							End If
						End If
					End If
				End If
				If 选择压缩级别.SelectedIndex = 0 Then
					选择压缩方法.Enabled = False
					选择压缩方法.SelectedIndex = -1
					选择压缩方法.Text = ""
				Else
					选择压缩方法.Enabled = True
				End If
			Case 1 'tar
				选择压缩方法.Items.AddRange(tar)
				If Not 选择压缩方法.Text = "GNU" Then
					If Not 选择压缩方法.Text = "POSIX" Then
						选择压缩方法.SelectedIndex = 0
					End If
				End If
				选择压缩方法.Enabled = True
				选择压缩级别.Enabled = False
				选择压缩级别.SelectedIndex = 0
				CPU线程数.Enabled = False
				CPU线程数.Text = 1
			Case 2 'wim
				选择压缩方法.Enabled = False
				选择压缩方法.SelectedIndex = -1
				选择压缩方法.Text = ""
				选择压缩级别.Enabled = False
				选择压缩级别.SelectedIndex = 0
				CPU线程数.Enabled = False
				CPU线程数.Text = "1"
			Case 3 'zip
				选择压缩方法.Items.AddRange(zip)
				选择压缩级别.Enabled = True
				选择压缩方法.Enabled = True
				CPU线程数.Enabled = True
				If Not 选择压缩方法.Text = "Deflate-压缩率中等" Then
					If Not 选择压缩方法.Text = "Deflate64-压缩率较高" Then
						If Not 选择压缩方法.Text = "BZip2-兼容性较好(Linux)" Then
							If Not 选择压缩方法.Text = "LMZA-压缩率最高,兼容性较差" Then
								If Not 选择压缩方法.Text = "PPMd-高效压缩纯文本" Then
									选择压缩方法.SelectedIndex = 0
								End If
							End If
						End If
					End If
				End If
				If 选择压缩级别.SelectedIndex = 0 Then
					选择压缩方法.Enabled = False
					选择压缩方法.SelectedIndex = -1
					选择压缩方法.Text = ""
				Else
					选择压缩方法.Enabled = True
				End If
		End Select
		'选择压缩级别_索引变化()
	End Sub
	Private Sub 选择压缩级别_SelectedIndexChanged(sender As Object, e As EventArgs) Handles 选择压缩级别.SelectedIndexChanged
		Select Case 选择压缩级别.SelectedIndex
			Case 0
				选择压缩方法.Enabled = False
				选择压缩方法.SelectedIndex = -1
				CPU线程数.Enabled = False
				CPU线程数.Text = "1"
			Case Else
				选择压缩方法.Enabled = True
				CPU线程数.Enabled = True
				If 选择压缩方法.SelectedIndex = -1 Then
					If Not 选择压缩格式.SelectedIndex = 2 Then
						选择压缩方法.SelectedIndex = 0
					End If
				End If
		End Select
	End Sub
	Private Sub 选择压缩级别_索引变化()
		Select Case 选择压缩级别.SelectedIndex
			Case 0
				选择压缩方法.Enabled = False
				选择压缩方法.SelectedIndex = -1
				CPU线程数.Enabled = False
				CPU线程数.Text = "1"
			Case Else
				选择压缩方法.Enabled = True
				CPU线程数.Enabled = True
				If 选择压缩方法.SelectedIndex = -1 Then
					If Not 选择压缩格式.SelectedIndex = 2 Then
						选择压缩方法.SelectedIndex = 0
					End If
				End If
		End Select
	End Sub
End Class