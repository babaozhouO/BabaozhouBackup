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
Public Class MainSettingsForm
    Private Sub 添加日志(信息 As String, 颜色 As Color)
        日志窗口.添加日志(信息, 颜色)
    End Sub
    Private Sub ButtonCancle_Click(sender As Object, e As EventArgs) Handles ButtonCancle.Click
        Dim 用户选择 As Integer = MessageBox.Show("是否放弃保存设置并退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            添加日志("[Action]关闭主程序设置窗口", Color.Black)
            Me.Close()
        End If
    End Sub
    Private Sub ButtonSaveAndExit_Click(sender As Object, e As EventArgs) Handles ButtonSaveAndExit.Click
        Dim 要写入的运行时间配置 As String
        Dim 用户选择 As Integer = MessageBox.Show("是否保存设置并退出?", "提示", MessageBoxButtons.YesNo)
        If 用户选择 = DialogResult.Yes Then
            要写入的运行时间配置 = TextBoxhour.Text + ":" + TextBoxminute.Text + ":" + TextBoxsecond.Text
            写入主程序配置(Days.Text, 要写入的运行时间配置, CheckBox是否关服备份.Checked, CInt(WaitingSeconds.Text), CInt(FPS.Text), CheckBox1.Checked)
            日志窗口.日志输出主程序配置()
            添加日志("[Action]关闭主程序设置窗口", Color.Black)
            Me.Close()
        End If
    End Sub
    Private Sub MainSettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        读取主程序配置()
        Days.Text = 间隔天数
        TextBoxhour.Text = 运行时间.Split(":")(0)
        TextBoxminute.Text = 运行时间.Split(":")(1)
        TextBoxsecond.Text = 运行时间.Split(":")(2)
        CheckBox是否关服备份.Checked = 是否关服备份
		WaitingSeconds.Text = 等待服务端关闭时长.ToString
        CheckBox1.Checked = 运行模式
        FPS.Text = 帧数.ToString
    End Sub
    ' 窗口激活时更新日志位置
    Private Sub MainSettingsForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            日志窗口.更新停靠位置(Me)
        End If
    End Sub
    ' 窗口移动时更新日志位置
    Private Sub MainSettingsForm_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainForm Then
            日志窗口.更新停靠位置(Me)
        End If
    End Sub
End Class