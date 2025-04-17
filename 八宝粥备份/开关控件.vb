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
Public Class 开关控件

    Inherits Control
    Public 当前状态 As Boolean = False
    Private 滑块位置 As Integer = 0
    Private ReadOnly 动画计时器 As New Timer() With {.Interval = 15}
    Public Event 状态变化(新状态 As Boolean)
    Public Sub New()
        Me.Size = New Size(100, 40)
        Me.DoubleBuffered = True
        AddHandler 动画计时器.Tick, AddressOf 执行动画
    End Sub
    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        切换状态()
    End Sub
    Public Sub 切换状态()
        当前状态 = Not 当前状态
        动画计时器.Start()
        RaiseEvent 状态变化(当前状态)
    End Sub
    Private Sub 执行动画(sender As Object, e As EventArgs)
        Dim 目标位置 As Integer = If(当前状态, Me.Width - 30, 0)
        滑块位置 = CInt(滑块位置 + (目标位置 - 滑块位置) * 0.2)

        If Math.Abs(滑块位置 - 目标位置) < 2 Then
            滑块位置 = 目标位置
            动画计时器.Stop()
        End If
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        ' 绘制背景
        Using 背景画刷 As New SolidBrush(If(当前状态, Color.FromArgb(100, 200, 100), Color.FromArgb(200, 100, 100)))
            e.Graphics.FillRectangle(背景画刷, 0, 0, Me.Width, Me.Height)
        End Using

        ' 绘制滑块
        Using 滑块画刷 As New SolidBrush(Color.White)
            e.Graphics.FillRectangle(滑块画刷, 滑块位置, 2, 28, Me.Height - 4)
        End Using

        ' 绘制文字
        Dim 状态文字 As String = If(当前状态, True, "False")
        Using 文字画刷 As New SolidBrush(Me.ForeColor)
            e.Graphics.DrawString(状态文字, Me.Font, 文字画刷,
                New PointF(Me.Width / 2 - 10, Me.Height / 2 - 8))
        End Using
    End Sub
End Class

' 使用示例：
'Private Sub 夜间模式开关_状态变化(新状态 As Boolean) Handles 夜间模式开关.状态变化
'   If 新状态 Then
'       启用夜间模式()
'   Else
'       关闭夜间模式()
'   End If
'End Sub
