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
        Dim 用户选择 As Integer = MessageBox.Show("是否放弃保存设置并退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            添加日志("[Action]关闭7-Zip设置窗口", Color.Black)
            Me.Close()
        End If
    End Sub
    Private Sub ButtonSaveAndExit_Click(sender As Object, e As EventArgs) Handles ButtonSaveAndExit.Click
        Dim 用户选择 As Integer = MessageBox.Show("是否保存设置并退出?", "提示", MessageBoxButtons.YesNo)
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
        If 用户选择 = DialogResult.Yes Then
            写入7zip配置(选择压缩格式.Text, 选择压缩级别.Text, TextBox1.Text, TextBox2.Text, 是否增量备份, 是否备份自定义目录, CPU线程数.Text)
            添加日志("[Success]成功保存7-Zip设置", Color.Green)
            日志窗口.日志输出7zip配置()
            添加日志("--------------------------------------------------------------", Color.Black)
            添加日志("[Action]关闭7-Zip设置窗口", Color.Black)
            Me.Close()
        End If
    End Sub
    Private Sub SevenZipSettingsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        日志窗口.更新停靠位置(Me)
        读取7zip配置()
        选择压缩格式.Text = 压缩格式
        选择压缩级别.Text = 压缩级别
        CPU线程数.Text = 线程数
        TextBox1.Text = 自定义备份目录
        TextBox2.Text = 备份输出目录
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
End Class