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
					Case 0 'LZMA2
						压缩方法 = "LZMA2"
					Case 1 'LZMA
						压缩方法 = "LZMA"
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
						压缩方法 = "LZMA"
					Case 4
						压缩方法 = "PPMd"
				End Select
		End Select
		压缩级别 = 选择压缩级别.SelectedIndex
		If 用户选择 = DialogResult.Yes Then
			写入7zip配置(压缩格式, 压缩级别, 压缩方法, 选择字典大小.Text, 选择单词大小.Text, CInt(TextBox3.Text), TextBox1.Text, TextBox2.Text, 是否增量备份, 是否备份自定义目录, CPU线程数.Text)
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
					Case "LZMA2"
						选择压缩方法.SelectedIndex = 0
						Select Case 字典大小
							Case "64KB"
								选择字典大小.SelectedIndex = 0
							Case "256KB"
								选择字典大小.SelectedIndex = 1
							Case "1MB"
								选择字典大小.SelectedIndex = 2
							Case "2MB"
								选择字典大小.SelectedIndex = 3
							Case "3MB"
								选择字典大小.SelectedIndex = 4
							Case "4MB"
								选择字典大小.SelectedIndex = 5
							Case "6MB"
								选择字典大小.SelectedIndex = 6
							Case "8MB"
								选择字典大小.SelectedIndex = 7
							Case "12MB"
								选择字典大小.SelectedIndex = 8
							Case "16MB"
								选择字典大小.SelectedIndex = 9
							Case "24MB"
								选择字典大小.SelectedIndex = 10
							Case "32MB"
								选择字典大小.SelectedIndex = 11
							Case "48MB"
								选择字典大小.SelectedIndex = 12
							Case "64MB"
								选择字典大小.SelectedIndex = 13
							Case "96MB"
								选择字典大小.SelectedIndex = 14
							Case "128MB"
								选择字典大小.SelectedIndex = 15
							Case "192MB"
								选择字典大小.SelectedIndex = 16
							Case "256MB"
								选择字典大小.SelectedIndex = 17
							Case "384MB"
								选择字典大小.SelectedIndex = 18
							Case "512MB"
								选择字典大小.SelectedIndex = 19
							Case "768MB"
								选择字典大小.SelectedIndex = 20
							Case "1024MB"
								选择字典大小.SelectedIndex = 21
							Case "1536MB"
								选择字典大小.SelectedIndex = 22
							Case "2048MB"
								选择字典大小.SelectedIndex = 23
							Case "3072MB"
								选择字典大小.SelectedIndex = 24
							Case "3840MB"
								选择字典大小.SelectedIndex = 25
						End Select
						Select Case 单词大小
							Case "8"
								选择单词大小.SelectedIndex = 0
							Case "12"
								选择单词大小.SelectedIndex = 1
							Case "16"
								选择单词大小.SelectedIndex = 2
							Case "24"
								选择单词大小.SelectedIndex = 3
							Case "32"
								选择单词大小.SelectedIndex = 4
							Case "48"
								选择单词大小.SelectedIndex = 5
							Case "64"
								选择单词大小.SelectedIndex = 6
							Case "96"
								选择单词大小.SelectedIndex = 7
							Case "128"
								选择单词大小.SelectedIndex = 8
							Case "192"
								选择单词大小.SelectedIndex = 9
							Case "256"
								选择单词大小.SelectedIndex = 10
							Case "273"
								选择单词大小.SelectedIndex = 11
						End Select
					Case "LZMA"
						选择压缩方法.SelectedIndex = 1
						Select Case 字典大小
							Case "64KB"
								选择字典大小.SelectedIndex = 0
							Case "256KB"
								选择字典大小.SelectedIndex = 1
							Case "1MB"
								选择字典大小.SelectedIndex = 2
							Case "2MB"
								选择字典大小.SelectedIndex = 3
							Case "3MB"
								选择字典大小.SelectedIndex = 4
							Case "4MB"
								选择字典大小.SelectedIndex = 5
							Case "6MB"
								选择字典大小.SelectedIndex = 6
							Case "8MB"
								选择字典大小.SelectedIndex = 7
							Case "12MB"
								选择字典大小.SelectedIndex = 8
							Case "16MB"
								选择字典大小.SelectedIndex = 9
							Case "24MB"
								选择字典大小.SelectedIndex = 10
							Case "32MB"
								选择字典大小.SelectedIndex = 11
							Case "48MB"
								选择字典大小.SelectedIndex = 12
							Case "64MB"
								选择字典大小.SelectedIndex = 13
							Case "96MB"
								选择字典大小.SelectedIndex = 14
							Case "128MB"
								选择字典大小.SelectedIndex = 15
							Case "192MB"
								选择字典大小.SelectedIndex = 16
							Case "256MB"
								选择字典大小.SelectedIndex = 17
							Case "384MB"
								选择字典大小.SelectedIndex = 18
							Case "512MB"
								选择字典大小.SelectedIndex = 19
							Case "768MB"
								选择字典大小.SelectedIndex = 20
							Case "1024MB"
								选择字典大小.SelectedIndex = 21
							Case "1536MB"
								选择字典大小.SelectedIndex = 22
							Case "2048MB"
								选择字典大小.SelectedIndex = 23
							Case "3072MB"
								选择字典大小.SelectedIndex = 24
							Case "3840MB"
								选择字典大小.SelectedIndex = 25
						End Select
						Select Case 单词大小
							Case "8"
								选择单词大小.SelectedIndex = 0
							Case "12"
								选择单词大小.SelectedIndex = 1
							Case "16"
								选择单词大小.SelectedIndex = 2
							Case "24"
								选择单词大小.SelectedIndex = 3
							Case "32"
								选择单词大小.SelectedIndex = 4
							Case "48"
								选择单词大小.SelectedIndex = 5
							Case "64"
								选择单词大小.SelectedIndex = 6
							Case "96"
								选择单词大小.SelectedIndex = 7
							Case "128"
								选择单词大小.SelectedIndex = 8
							Case "192"
								选择单词大小.SelectedIndex = 9
							Case "256"
								选择单词大小.SelectedIndex = 10
							Case "273"
								选择单词大小.SelectedIndex = 11
						End Select
					Case "PPMd"
						选择压缩方法.SelectedIndex = 2
						Select Case 字典大小
							Case "1MB"
								选择字典大小.SelectedIndex = 0
							Case "2MB"
								选择字典大小.SelectedIndex = 1
							Case "3MB"
								选择字典大小.SelectedIndex = 2
							Case "4MB"
								选择字典大小.SelectedIndex = 3
							Case "6MB"
								选择字典大小.SelectedIndex = 4
							Case "8MB"
								选择字典大小.SelectedIndex = 5
							Case "12MB"
								选择字典大小.SelectedIndex = 6
							Case "16MB"
								选择字典大小.SelectedIndex = 7
							Case "24MB"
								选择字典大小.SelectedIndex = 8
							Case "32MB"
								选择字典大小.SelectedIndex = 9
							Case "48MB"
								选择字典大小.SelectedIndex = 10
							Case "64MB"
								选择字典大小.SelectedIndex = 11
							Case "96MB"
								选择字典大小.SelectedIndex = 12
							Case "128MB"
								选择字典大小.SelectedIndex = 13
							Case "192MB"
								选择字典大小.SelectedIndex = 14
							Case "256MB"
								选择字典大小.SelectedIndex = 15
							Case "384MB"
								选择字典大小.SelectedIndex = 16
							Case "512MB"
								选择字典大小.SelectedIndex = 17
							Case "768MB"
								选择字典大小.SelectedIndex = 18
							Case "1024MB"
								选择字典大小.SelectedIndex = 19
						End Select
						Select Case 单词大小
							Case "2"
								选择单词大小.SelectedIndex = 0
							Case "3"
								选择单词大小.SelectedIndex = 1
							Case "4"
								选择单词大小.SelectedIndex = 2
							Case "5"
								选择单词大小.SelectedIndex = 3
							Case "6"
								选择单词大小.SelectedIndex = 4
							Case "7"
								选择单词大小.SelectedIndex = 5
							Case "8"
								选择单词大小.SelectedIndex = 6
							Case "10"
								选择单词大小.SelectedIndex = 7
							Case "12"
								选择单词大小.SelectedIndex = 8
							Case "14"
								选择单词大小.SelectedIndex = 9
							Case "16"
								选择单词大小.SelectedIndex = 10
							Case "20"
								选择单词大小.SelectedIndex = 11
							Case "24"
								选择单词大小.SelectedIndex = 12
							Case "28"
								选择单词大小.SelectedIndex = 13
							Case "32"
								选择单词大小.SelectedIndex = 14
						End Select
					Case "BZip2"
						选择压缩方法.SelectedIndex = 3
						Select Case 字典大小
							Case "100KB"
								选择字典大小.SelectedIndex = 0
							Case "200KB"
								选择字典大小.SelectedIndex = 1
							Case "300KB"
								选择字典大小.SelectedIndex = 2
							Case "400KB"
								选择字典大小.SelectedIndex = 3
							Case "500KB"
								选择字典大小.SelectedIndex = 4
							Case "600KB"
								选择字典大小.SelectedIndex = 5
							Case "700KB"
								选择字典大小.SelectedIndex = 6
							Case "800KB"
								选择字典大小.SelectedIndex = 7
							Case "900KB"
								选择字典大小.SelectedIndex = 8
						End Select
						选择单词大小.Enabled = False
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
				选择字典大小.Enabled = False
				选择单词大小.Enabled = False
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
						选择字典大小.Enabled = False
						选择字典大小.Text = "32KB"
						Select Case 单词大小
							Case "8"
								选择单词大小.SelectedIndex = 0
							Case "12"
								选择单词大小.SelectedIndex = 1
							Case "16"
								选择单词大小.SelectedIndex = 2
							Case "24"
								选择单词大小.SelectedIndex = 3
							Case "32"
								选择单词大小.SelectedIndex = 4
							Case "48"
								选择单词大小.SelectedIndex = 5
							Case "64"
								选择单词大小.SelectedIndex = 6
							Case "96"
								选择单词大小.SelectedIndex = 7
							Case "128"
								选择单词大小.SelectedIndex = 8
							Case "192"
								选择单词大小.SelectedIndex = 9
							Case "256"
								选择单词大小.SelectedIndex = 10
							Case "258"
								选择单词大小.SelectedIndex = 11
						End Select
					Case "Deflate64"
						选择压缩方法.SelectedIndex = 1
						选择压缩方法.SelectedIndex = 0
						选择字典大小.Enabled = False
						选择字典大小.Text = "64KB"
						Select Case 单词大小
							Case "8"
								选择单词大小.SelectedIndex = 0
							Case "12"
								选择单词大小.SelectedIndex = 1
							Case "16"
								选择单词大小.SelectedIndex = 2
							Case "24"
								选择单词大小.SelectedIndex = 3
							Case "32"
								选择单词大小.SelectedIndex = 4
							Case "48"
								选择单词大小.SelectedIndex = 5
							Case "64"
								选择单词大小.SelectedIndex = 6
							Case "96"
								选择单词大小.SelectedIndex = 7
							Case "128"
								选择单词大小.SelectedIndex = 8
							Case "192"
								选择单词大小.SelectedIndex = 9
							Case "256"
								选择单词大小.SelectedIndex = 10
							Case "257"
								选择单词大小.SelectedIndex = 11
						End Select
					Case "BZip2"
						选择压缩方法.SelectedIndex = 2
						选择压缩方法.SelectedIndex = 3
						选择单词大小.Enabled = False
						Select Case 字典大小
							Case "100KB"
								选择字典大小.SelectedIndex = 0
							Case "200KB"
								选择字典大小.SelectedIndex = 1
							Case "300KB"
								选择字典大小.SelectedIndex = 2
							Case "400KB"
								选择字典大小.SelectedIndex = 3
							Case "500KB"
								选择字典大小.SelectedIndex = 4
							Case "600KB"
								选择字典大小.SelectedIndex = 5
							Case "700KB"
								选择字典大小.SelectedIndex = 6
							Case "800KB"
								选择字典大小.SelectedIndex = 7
							Case "900KB"
								选择字典大小.SelectedIndex = 8
						End Select
					Case "LZMA"
						选择压缩方法.SelectedIndex = 3
						Select Case 字典大小
							Case "64KB"
								选择字典大小.SelectedIndex = 0
							Case "256KB"
								选择字典大小.SelectedIndex = 1
							Case "1MB"
								选择字典大小.SelectedIndex = 2
							Case "2MB"
								选择字典大小.SelectedIndex = 3
							Case "3MB"
								选择字典大小.SelectedIndex = 4
							Case "4MB"
								选择字典大小.SelectedIndex = 5
							Case "6MB"
								选择字典大小.SelectedIndex = 6
							Case "8MB"
								选择字典大小.SelectedIndex = 7
							Case "12MB"
								选择字典大小.SelectedIndex = 8
							Case "16MB"
								选择字典大小.SelectedIndex = 9
							Case "24MB"
								选择字典大小.SelectedIndex = 10
							Case "32MB"
								选择字典大小.SelectedIndex = 11
							Case "48MB"
								选择字典大小.SelectedIndex = 12
							Case "64MB"
								选择字典大小.SelectedIndex = 13
							Case "96MB"
								选择字典大小.SelectedIndex = 14
							Case "128MB"
								选择字典大小.SelectedIndex = 15
							Case "192MB"
								选择字典大小.SelectedIndex = 16
							Case "256MB"
								选择字典大小.SelectedIndex = 17
							Case "384MB"
								选择字典大小.SelectedIndex = 18
							Case "512MB"
								选择字典大小.SelectedIndex = 19
							Case "768MB"
								选择字典大小.SelectedIndex = 20
							Case "1024MB"
								选择字典大小.SelectedIndex = 21
							Case "1536MB"
								选择字典大小.SelectedIndex = 22
							Case "2048MB"
								选择字典大小.SelectedIndex = 23
							Case "3072MB"
								选择字典大小.SelectedIndex = 24
							Case "3840MB"
								选择字典大小.SelectedIndex = 25
						End Select
						Select Case 单词大小
							Case "8"
								选择单词大小.SelectedIndex = 0
							Case "12"
								选择单词大小.SelectedIndex = 1
							Case "16"
								选择单词大小.SelectedIndex = 2
							Case "24"
								选择单词大小.SelectedIndex = 3
							Case "32"
								选择单词大小.SelectedIndex = 4
							Case "48"
								选择单词大小.SelectedIndex = 5
							Case "64"
								选择单词大小.SelectedIndex = 6
							Case "96"
								选择单词大小.SelectedIndex = 7
							Case "128"
								选择单词大小.SelectedIndex = 8
							Case "192"
								选择单词大小.SelectedIndex = 9
							Case "256"
								选择单词大小.SelectedIndex = 10
							Case "273"
								选择单词大小.SelectedIndex = 11
						End Select
					Case "PPMd"
						选择压缩方法.SelectedIndex = 4
						Select Case 字典大小
							Case "1MB"
								选择字典大小.SelectedIndex = 0
							Case "2MB"
								选择字典大小.SelectedIndex = 1
							Case "3MB"
								选择字典大小.SelectedIndex = 2
							Case "4MB"
								选择字典大小.SelectedIndex = 3
							Case "6MB"
								选择字典大小.SelectedIndex = 4
							Case "8MB"
								选择字典大小.SelectedIndex = 5
							Case "12MB"
								选择字典大小.SelectedIndex = 6
							Case "16MB"
								选择字典大小.SelectedIndex = 7
							Case "24MB"
								选择字典大小.SelectedIndex = 8
							Case "32MB"
								选择字典大小.SelectedIndex = 9
							Case "48MB"
								选择字典大小.SelectedIndex = 10
							Case "64MB"
								选择字典大小.SelectedIndex = 11
							Case "96MB"
								选择字典大小.SelectedIndex = 12
							Case "128MB"
								选择字典大小.SelectedIndex = 13
							Case "192MB"
								选择字典大小.SelectedIndex = 14
							Case "256MB"
								选择字典大小.SelectedIndex = 15
							Case "384MB"
								选择字典大小.SelectedIndex = 16
							Case "512MB"
								选择字典大小.SelectedIndex = 17
							Case "768MB"
								选择字典大小.SelectedIndex = 18
							Case "1024MB"
								选择字典大小.SelectedIndex = 19
						End Select
						Select Case 单词大小
							Case "2"
								选择单词大小.SelectedIndex = 0
							Case "3"
								选择单词大小.SelectedIndex = 1
							Case "4"
								选择单词大小.SelectedIndex = 2
							Case "5"
								选择单词大小.SelectedIndex = 3
							Case "6"
								选择单词大小.SelectedIndex = 4
							Case "7"
								选择单词大小.SelectedIndex = 5
							Case "8"
								选择单词大小.SelectedIndex = 6
							Case "10"
								选择单词大小.SelectedIndex = 7
							Case "12"
								选择单词大小.SelectedIndex = 8
							Case "14"
								选择单词大小.SelectedIndex = 9
							Case "16"
								选择单词大小.SelectedIndex = 10
							Case "20"
								选择单词大小.SelectedIndex = 11
							Case "24"
								选择单词大小.SelectedIndex = 12
							Case "28"
								选择单词大小.SelectedIndex = 13
							Case "32"
								选择单词大小.SelectedIndex = 14
						End Select
				End Select
		End Select
		选择压缩级别.SelectedIndex = 压缩级别
		CPU线程数.Text = 线程数
		TextBox1.Text = 自定义备份目录
		TextBox2.Text = 备份输出目录
		TextBox3.Text = 超时时长.ToString
		CheckBox1.Checked = 是否增量备份
		CheckBox2.Checked = 是否备份自定义目录
	End Sub
	Private Sub 选择压缩格式_索引变化(sender As Object, e As EventArgs) Handles 选择压缩格式.SelectedIndexChanged
		Dim Sevenzip As Object() = New Object() {"LZMA2-压缩率最高,兼容性较差", "LZMA-压缩率稍低,兼容性较差", "PPMd-高效压缩纯文本", "BZip2-兼容性较好(Linux)"}
		Dim tar As Object = New Object() {"GNU", "POSIX"}
		Dim zip As Object = New Object() {"Deflate-压缩率中等", "Deflate64-压缩率较高", "BZip2-兼容性较好(Linux)", "LZMA-压缩率最高,兼容性较差", "PPMd-高效压缩纯文本"}
		选择压缩方法.Items.Clear()
		Select Case 选择压缩格式.SelectedIndex
			Case 0 '7z
				选择压缩级别.Enabled = True
				CPU线程数.Enabled = True
				选择压缩方法.Items.AddRange(Sevenzip)
				If Not 选择压缩方法.Text = "LZMA2-压缩率最高,兼容性较差" Or
					Not 选择压缩方法.Text = "LZMA-压缩率稍低,兼容性较差" Or
					Not 选择压缩方法.Text = "PPMd-高效压缩纯文本" Or
					Not 选择压缩方法.Text = "BZip2-兼容性较好(Linux)" Then
					选择压缩方法.SelectedIndex = 0
				End If
				If 选择压缩级别.SelectedIndex = 0 Then  '压缩级别为0时禁用
					选择压缩方法.Enabled = False
					选择压缩方法.SelectedIndex = -1
					选择压缩方法.Text = ""
					选择字典大小.Enabled = False
					选择字典大小.SelectedIndex = -1
					选择字典大小.Text = ""
					选择单词大小.Enabled = False
					选择单词大小.SelectedIndex = -1
					选择单词大小.Text = ""
				Else
					选择压缩方法.Enabled = True
					选择字典大小.Enabled = True
					选择单词大小.Enabled = True
				End If
			Case 1 'tar
				选择压缩方法.Items.AddRange(tar)
				If Not 选择压缩方法.Text = "GNU" Or
					Not 选择压缩方法.Text = "POSIX" Then
					选择压缩方法.SelectedIndex = 0
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
				If Not 选择压缩方法.Text = "Deflate-压缩率中等" Or
					Not 选择压缩方法.Text = "Deflate64-压缩率较高" Or
					Not 选择压缩方法.Text = "BZip2-兼容性较好(Linux)" Or
					Not 选择压缩方法.Text = "LZMA-压缩率最高,兼容性较差" Or
					Not 选择压缩方法.Text = "PPMd-高效压缩纯文本" Then
					选择压缩方法.SelectedIndex = 0
				End If
				If 选择压缩级别.SelectedIndex = 0 Then  '压缩级别为0时禁用
					选择压缩方法.Enabled = False
					选择压缩方法.SelectedIndex = -1
					选择压缩方法.Text = ""
					选择字典大小.Enabled = False
					选择字典大小.SelectedIndex = -1
					选择字典大小.Text = ""
					选择单词大小.Enabled = False
					选择单词大小.SelectedIndex = -1
					选择单词大小.Text = ""
				Else
					选择压缩方法.Enabled = True
					选择字典大小.Enabled = True
					选择单词大小.Enabled = True
				End If
		End Select
		'选择压缩级别_索引变化()
	End Sub
	Private Sub 选择压缩级别_SelectedIndexChanged(sender As Object, e As EventArgs) Handles 选择压缩级别.SelectedIndexChanged
		Select Case 选择压缩级别.SelectedIndex
			Case 0 '压缩级别为0时禁用所有
				选择压缩方法.Enabled = False
				选择压缩方法.SelectedIndex = -1
				选择字典大小.Enabled = False
				选择字典大小.SelectedIndex = -1
				选择字典大小.Text = ""
				选择单词大小.Enabled = False
				选择单词大小.SelectedIndex = -1
				选择单词大小.Text = ""
				CPU线程数.Enabled = False
				CPU线程数.Text = "1"
			Case Else
				选择压缩方法.Enabled = True
				CPU线程数.Enabled = True
				If 选择压缩方法.SelectedIndex = -1 Then '当没有选择压缩方法时
					If Not 选择压缩格式.SelectedIndex = 2 Then '当不是wim格式时
						选择压缩方法.SelectedIndex = 0 '默认选择第一项
					End If
				End If
		End Select
	End Sub
	Private Sub 选择压缩方法_SelectedIndexChanged(sender As Object, e As EventArgs) Handles 选择压缩方法.SelectedIndexChanged
		选择字典大小.Items.Clear()
		选择单词大小.Items.Clear()
		'定义LZMA2字典大小和单词大小的范围
		Dim LZMA2字典大小范围 As Object() = New Object() {"64KB", "256KB", "1MB", "2MB", "3MB", "4MB", "6MB", "8MB", "12MB", "16MB", "24MB", "32MB", "48MB", "64MB", "96MB", "128MB", "192MB", "256MB", "384MB", "512MB", "768MB", "1024MB", "1536MB", "2048MB", "3072MB", "3840MB"}
		Dim LZMA2单词大小范围 As Object() = New Object() {"8", "12", "16", "24", "32", "48", "64", "96", "128", "192", "256", "273"}
		'定义LZMA字典大小和单词大小的范围
		Dim LZMA字典大小范围 As Object() = New Object() {"64KB", "256KB", "1MB", "2MB", "3MB", "4MB", "6MB", "8MB", "12MB", "16MB", "24MB", "32MB", "48MB", "64MB", "96MB", "128MB", "192MB", "256MB", "384MB", "512MB", "768MB", "1024MB", "1536MB", "2048MB", "3072MB", "3840MB"}
		Dim LZMA单词大小范围 As Object() = New Object() {"8", "12", "16", "24", "32", "48", "64", "96", "128", "192", "256", "273"}
		'定义PPMd字典大小和单词大小的范围
		Dim PPMd字典大小范围 As Object() = New Object() {"1MB", "2MB", "3MB", "4MB", "6MB", "8MB", "12MB", "16MB", "24MB", "32MB", "48MB", "64MB", "96MB", "128MB", "192MB", "256MB", "384MB", "512MB", "768MB", "1024MB"}
		Dim PPMd单词大小范围 As Object() = New Object() {"2", "3", "4", "5", "6", "7", "8", "10", "12", "16", "20", "24"， "28", "32"}
		'定义BZip2字典大小范围
		Dim BZip2字典大小范围 As Object() = New Object() {"100KB", "200KB", "300KB", "400KB", "500KB", "600KB", "700KB", "800KB", "900KB"}
		'定义Deflate单词大小范围
		Dim Deflate单词大小范围 As Object() = New Object() {"8", "12", "16", "24", "32", "48", "64", "96", "128", "192", "256", "258"}
		'定义Deflate64单词大小范围
		Dim Deflate64单词大小范围 As Object() = New Object() {"8", "12", "16", "24", "32", "48", "64", "96", "128", "192", "256", "257"}
		Select Case 选择压缩方法.Text
			Case "LZMA2-压缩率最高,兼容性较差"
				选择字典大小.Items.AddRange(LZMA2字典大小范围)
				选择单词大小.Items.AddRange(LZMA2单词大小范围)
				选择字典大小.Enabled = True
				选择单词大小.Enabled = True
				'当选择字典大小不在范围内时，默认选择64KB
				If Not 选择字典大小.Text = "64KB" Or
				Not 选择字典大小.Text = "256KB" Or
				Not 选择字典大小.Text = "1MB" Or
				Not 选择字典大小.Text = "2MB" Or
				Not 选择字典大小.Text = "3MB" Or
				Not 选择字典大小.Text = "4MB" Or
				Not 选择字典大小.Text = "6MB" Or
				Not 选择字典大小.Text = "8MB" Or
				Not 选择字典大小.Text = "12MB" Or
				Not 选择字典大小.Text = "16MB" Or
				Not 选择字典大小.Text = "24MB" Or
				Not 选择字典大小.Text = "32MB" Or
				Not 选择字典大小.Text = "48MB" Or
				Not 选择字典大小.Text = "64MB" Or
				Not 选择字典大小.Text = "96MB" Or
				Not 选择字典大小.Text = "128MB" Or
				Not 选择字典大小.Text = "192MB" Or
				Not 选择字典大小.Text = "256MB" Or
				Not 选择字典大小.Text = "384MB" Or
				Not 选择字典大小.Text = "512MB" Or
				Not 选择字典大小.Text = "768MB" Or
				Not 选择字典大小.Text = "1024MB" Or
				Not 选择字典大小.Text = "1536MB" Or
				Not 选择字典大小.Text = "2048MB" Or
				Not 选择字典大小.Text = "3072MB" Or
				Not 选择字典大小.Text = "3840MB" Then
					选择字典大小.SelectedIndex = 0
				End If
				'当选择单词大小不在范围内时，默认选择8
				If Not 选择单词大小.Text = "8" Or
						Not 选择单词大小.Text = "12" Or
						Not 选择单词大小.Text = "16" Or
						Not 选择单词大小.Text = "24" Or
						Not 选择单词大小.Text = "32" Or
						Not 选择单词大小.Text = "48" Or
						Not 选择单词大小.Text = "64" Or
						Not 选择单词大小.Text = "96" Or
						Not 选择单词大小.Text = "128" Or
						Not 选择单词大小.Text = "192" Or
						Not 选择单词大小.Text = "256" Or
						Not 选择单词大小.Text = "273" Then
					选择单词大小.SelectedIndex = 0
				End If
			Case "LZMA-压缩率稍低,兼容性较差"
				选择字典大小.Items.AddRange(LZMA字典大小范围)
				选择单词大小.Items.AddRange(LZMA单词大小范围)
				选择字典大小.Enabled = True
				选择单词大小.Enabled = True
				'当选择字典大小不在范围内时，默认选择64KB
				If Not 选择字典大小.Text = "64KB" Or
				Not 选择字典大小.Text = "256KB" Or
				Not 选择字典大小.Text = "1MB" Or
				Not 选择字典大小.Text = "2MB" Or
				Not 选择字典大小.Text = "3MB" Or
				Not 选择字典大小.Text = "4MB" Or
				Not 选择字典大小.Text = "6MB" Or
				Not 选择字典大小.Text = "8MB" Or
				Not 选择字典大小.Text = "12MB" Or
				Not 选择字典大小.Text = "16MB" Or
				Not 选择字典大小.Text = "24MB" Or
				Not 选择字典大小.Text = "32MB" Or
				Not 选择字典大小.Text = "48MB" Or
				Not 选择字典大小.Text = "64MB" Or
				Not 选择字典大小.Text = "96MB" Or
				Not 选择字典大小.Text = "128MB" Or
				Not 选择字典大小.Text = "192MB" Or
				Not 选择字典大小.Text = "256MB" Or
				Not 选择字典大小.Text = "384MB" Or
				Not 选择字典大小.Text = "512MB" Or
				Not 选择字典大小.Text = "768MB" Or
				Not 选择字典大小.Text = "1024MB" Or
				Not 选择字典大小.Text = "1536MB" Or
				Not 选择字典大小.Text = "2048MB" Or
				Not 选择字典大小.Text = "3072MB" Or
				Not 选择字典大小.Text = "3840MB" Then
					选择字典大小.SelectedIndex = 0
				End If
				'当选择单词大小不在范围内时，默认选择8
				If Not 选择单词大小.Text = "8" Or
						Not 选择单词大小.Text = "12" Or
						Not 选择单词大小.Text = "16" Or
						Not 选择单词大小.Text = "24" Or
						Not 选择单词大小.Text = "32" Or
						Not 选择单词大小.Text = "48" Or
						Not 选择单词大小.Text = "64" Or
						Not 选择单词大小.Text = "96" Or
						Not 选择单词大小.Text = "128" Or
						Not 选择单词大小.Text = "192" Or
						Not 选择单词大小.Text = "256" Or
						Not 选择单词大小.Text = "273" Then
					选择单词大小.SelectedIndex = 0
				End If
			Case "LZMA-压缩率最高,兼容性较差"
				选择字典大小.Items.AddRange(LZMA字典大小范围)
				选择单词大小.Items.AddRange(LZMA单词大小范围)
				选择字典大小.Enabled = True
				选择单词大小.Enabled = True
				'当选择字典大小不在范围内时，默认选择64KB
				If Not 选择字典大小.Text = "64KB" Or
				Not 选择字典大小.Text = "256KB" Or
				Not 选择字典大小.Text = "1MB" Or
				Not 选择字典大小.Text = "2MB" Or
				Not 选择字典大小.Text = "3MB" Or
				Not 选择字典大小.Text = "4MB" Or
				Not 选择字典大小.Text = "6MB" Or
				Not 选择字典大小.Text = "8MB" Or
				Not 选择字典大小.Text = "12MB" Or
				Not 选择字典大小.Text = "16MB" Or
				Not 选择字典大小.Text = "24MB" Or
				Not 选择字典大小.Text = "32MB" Or
				Not 选择字典大小.Text = "48MB" Or
				Not 选择字典大小.Text = "64MB" Or
				Not 选择字典大小.Text = "96MB" Or
				Not 选择字典大小.Text = "128MB" Or
				Not 选择字典大小.Text = "192MB" Or
				Not 选择字典大小.Text = "256MB" Or
				Not 选择字典大小.Text = "384MB" Or
				Not 选择字典大小.Text = "512MB" Or
				Not 选择字典大小.Text = "768MB" Or
				Not 选择字典大小.Text = "1024MB" Or
				Not 选择字典大小.Text = "1536MB" Or
				Not 选择字典大小.Text = "2048MB" Or
				Not 选择字典大小.Text = "3072MB" Or
				Not 选择字典大小.Text = "3840MB" Then
					选择字典大小.SelectedIndex = 0
				End If
				'当选择单词大小不在范围内时，默认选择8
				If Not 选择单词大小.Text = "8" Or
						Not 选择单词大小.Text = "12" Or
						Not 选择单词大小.Text = "16" Or
						Not 选择单词大小.Text = "24" Or
						Not 选择单词大小.Text = "32" Or
						Not 选择单词大小.Text = "48" Or
						Not 选择单词大小.Text = "64" Or
						Not 选择单词大小.Text = "96" Or
						Not 选择单词大小.Text = "128" Or
						Not 选择单词大小.Text = "192" Or
						Not 选择单词大小.Text = "256" Or
						Not 选择单词大小.Text = "273" Then
					选择单词大小.SelectedIndex = 0
				End If
			Case "PPMd-高效压缩纯文本"
				选择字典大小.Items.AddRange(PPMd字典大小范围)
				选择单词大小.Items.AddRange(PPMd单词大小范围)
				选择字典大小.Enabled = True
				选择单词大小.Enabled = True
				'当选择字典大小不在范围内时，默认选择1MB
				If Not 选择字典大小.Text = "1MB" Or
						Not 选择字典大小.Text = "2MB" Or
						Not 选择字典大小.Text = "3MB" Or
						Not 选择字典大小.Text = "4MB" Or
						Not 选择字典大小.Text = "6MB" Or
						Not 选择字典大小.Text = "8MB" Or
						Not 选择字典大小.Text = "12MB" Or
						Not 选择字典大小.Text = "16MB" Or
						Not 选择字典大小.Text = "24MB" Or
						Not 选择字典大小.Text = "32MB" Or
						Not 选择字典大小.Text = "48MB" Or
						Not 选择字典大小.Text = "64MB" Or
						Not 选择字典大小.Text = "96MB" Or
						Not 选择字典大小.Text = "128MB" Or
						Not 选择字典大小.Text = "192MB" Or
						Not 选择字典大小.Text = "256MB" Or
						Not 选择字典大小.Text = "384MB" Or
						Not 选择字典大小.Text = "512MB" Or
						Not 选择字典大小.Text = "768MB" Or
						Not 选择字典大小.Text = "1024MB" Then
					选择字典大小.SelectedIndex = 0
				End If
				'当选择单词大小不在范围内时，默认选择2
				If Not 选择单词大小.Text = "2" Or
						Not 选择单词大小.Text = "3" Or
						Not 选择单词大小.Text = "4" Or
						Not 选择单词大小.Text = "5" Or
						Not 选择单词大小.Text = "6" Or
						Not 选择单词大小.Text = "7" Or
						Not 选择单词大小.Text = "8" Or
						Not 选择单词大小.Text = "10" Or
						Not 选择单词大小.Text = "12" Or
						Not 选择单词大小.Text = "14" Or
						Not 选择单词大小.Text = "16" Or
						Not 选择单词大小.Text = "20" Or
						Not 选择单词大小.Text = "24" Or
						Not 选择单词大小.Text = "28" Or
						Not 选择单词大小.Text = "32" Then
					选择单词大小.SelectedIndex = 0
				End If
			Case "BZip2-兼容性较好(Linux)"
				选择字典大小.Items.AddRange(BZip2字典大小范围)
				选择字典大小.Enabled = True
				选择单词大小.Enabled = False
				'当选择字典大小不在范围内时，默认选择100KB
				If Not 选择字典大小.Text = "100KB" Or
						Not 选择字典大小.Text = "200KB" Or
						Not 选择字典大小.Text = "300KB" Or
						Not 选择字典大小.Text = "400KB" Or
						Not 选择字典大小.Text = "500KB" Or
						Not 选择字典大小.Text = "600KB" Or
						Not 选择字典大小.Text = "700KB" Or
						Not 选择字典大小.Text = "800KB" Or
						Not 选择字典大小.Text = "900KB" Then
					选择字典大小.SelectedIndex = 0
				End If
				选择单词大小.SelectedIndex = -1
				选择单词大小.Text = ""
			Case "Deflate-压缩率中等"
				选择单词大小.Items.AddRange(Deflate单词大小范围)
				选择单词大小.Enabled = True
				选择字典大小.Enabled = False
				选择字典大小.Items.Add("32KB")
				选择字典大小.SelectedIndex = 0
				'当选择单词大小不在范围内时，默认选择8
				If Not 选择单词大小.Text = "8" Or
						Not 选择单词大小.Text = "12" Or
						Not 选择单词大小.Text = "16" Or
						Not 选择单词大小.Text = "24" Or
						Not 选择单词大小.Text = "32" Or
						Not 选择单词大小.Text = "48" Or
						Not 选择单词大小.Text = "64" Or
						Not 选择单词大小.Text = "96" Or
						Not 选择单词大小.Text = "128" Or
						Not 选择单词大小.Text = "192" Or
						Not 选择单词大小.Text = "256" Or
						Not 选择单词大小.Text = "258" Then
					选择单词大小.SelectedIndex = 0
				End If
			Case "Deflate64-压缩率较高"
				选择单词大小.Items.AddRange(Deflate64单词大小范围)
				选择单词大小.Enabled = True
				选择字典大小.Enabled = False
				选择字典大小.Items.Add("64KB")
				选择字典大小.SelectedIndex = 0
				'当选择单词大小不在范围内时，默认选择8
				If Not 选择单词大小.Text = "8" Or
						Not 选择单词大小.Text = "12" Or
						Not 选择单词大小.Text = "16" Or
						Not 选择单词大小.Text = "24" Or
						Not 选择单词大小.Text = "32" Or
						Not 选择单词大小.Text = "48" Or
						Not 选择单词大小.Text = "64" Or
						Not 选择单词大小.Text = "96" Or
						Not 选择单词大小.Text = "128" Or
						Not 选择单词大小.Text = "192" Or
						Not 选择单词大小.Text = "256" Or
						Not 选择单词大小.Text = "257" Then
					选择单词大小.SelectedIndex = 0
				End If
		End Select
	End Sub
End Class