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
Imports Renci.SshNet
Imports System.IO
Imports System.Text
Imports System.Threading
Public Class SFTP客户端 ' SFTP 客户端类，实现连接和文件上传功能
    Implements IDisposable
    Private 客户端实例 As SftpClient ' SFTP 客户端实例
    Public 连接状态 As Boolean = False ' 连接状态
    Private 服务端序号 As String
    Private Shared ReadOnly 正斜杠 As Char() = {"/"c}
    Private Shared ReadOnly 反斜杠 As Char() = {"\"c}
    Private Sub 添加日志(信息 As String, 颜色 As Color)
        If 日志窗口.InvokeRequired Then
            日志窗口.Invoke(Sub() 日志窗口.添加日志(信息, 颜色))
        Else
            日志窗口.添加日志(信息, 颜色)
        End If
    End Sub
    Public Sub 建立Sftp连接(主机地址 As String, 端口号 As Integer, 用户名 As String, 密码 As String, _服务端序号 As String) ' 连接到 SFTP 服务器
        服务端序号 = _服务端序号
        MainForm.执行中的分任务.Text = $"处理Sftp{服务端序号}服务器"
        MainForm.分任务进度条.Value = 0
        添加日志($"[Action]正在尝试连接到Sftp{服务端序号}服务器", Color.Orange)
        Try
            If 客户端实例 Is Nothing OrElse Not 客户端实例.IsConnected Then '检测是否已连接
                Dim 连接信息 = New PasswordConnectionInfo(主机地址, 端口号, 用户名, 密码) With {.Encoding = Encoding.UTF8}
                客户端实例 = New SftpClient(连接信息)
                If 是否循环更新界面 Then
                    Dim T = 客户端实例.ConnectAsync(CancellationToken.None)
                    While Not T.IsCompleted
                        Application.DoEvents()
                        Thread.Sleep(延时毫秒数)
                    End While
                Else
                    客户端实例.Connect()
                End If
            Else
                添加日志($"[ERROR]Sftp{服务端序号}服务器已连接，请勿重复连接", Color.Red)
            End If
        Catch
            添加日志($"[ERROR]SFTP{服务端序号}服务器连接失败，请检查网络和凭据或配置文件", Color.Red)
            MainForm.执行中的分任务.Text = $"无"
            MainForm.分任务进度条.Value = 0
        End Try
        If 客户端实例 IsNot Nothing AndAlso 客户端实例.IsConnected Then
            连接状态 = True
            添加日志($"[Success]成功连接Sftp{服务端序号}服务器", Color.Green)
            MainForm.分任务进度条.Value = 10
        Else
            添加日志($"[ERROR]]SFTP{服务端序号}服务器连接失败，请检查网络和凭据或配置文件", Color.Red)
            MainForm.执行中的分任务.Text = $"无"
            MainForm.分任务进度条.Value = 0
        End If
    End Sub
    Private WithEvents 模拟文件上传耗时 As New Timers.Timer With {.AutoReset = True, .Interval = 1000}
    Private ReadOnly uiContext As SynchronizationContext = SynchronizationContext.Current
    Private Sub Tick() Handles 模拟文件上传耗时.Elapsed
        uiContext.Post(Sub()
                           MainForm.分任务进度条.Value += If(MainForm.分任务进度条.Value < 93, 1, 0)
                       End Sub, Nothing)
    End Sub
    Public Sub 上传文件(本地文件路径 As String, 远程目录路径 As String) ' 上传本地文件到远程路径
        If 本地文件路径 = "" Then
            添加日志($"[ERROR]Sftp{服务端序号}客户端发现未选择文件", Color.Red)
            Return
        End If
        If Not File.Exists(本地文件路径) Then
            添加日志($"[ERROR]Sftp{服务端序号}客户端发现本地文件不存在", Color.Red)
            Return '检测本地文件是否存在
        End If
        If 客户端实例 Is Nothing OrElse Not 客户端实例.IsConnected Then
            添加日志($"[ERROR]Sftp{服务端序号}客户端未连接", Color.Red)
            Return
        End If
        If Not 远程目录路径.StartsWith("/"c) Then 远程目录路径 = $"/{远程目录路径}"
        远程目录路径 = 远程目录路径.Replace(反斜杠, 正斜杠).TrimEnd(正斜杠) ' 处理远程目录路径
        If 远程目录路径 = "" Then 远程目录路径 = "/"
        If 客户端实例.Exists(远程目录路径) Then
            添加日志($"[Success]Sftp{服务端序号}客户端确认远程目录存在", Color.Green)
        Else
            Dim 路径层级 As String() = 远程目录路径.Trim(正斜杠).Split(正斜杠, StringSplitOptions.RemoveEmptyEntries)
            ' 初始化当前路径为根目录
            Dim 当前路径 As String = "/"
            ' 逐级创建目录
            For Each 目录 As String In 路径层级
                Dim 下一级路径 As String = $"{当前路径.TrimEnd("/"c)}/{目录}"
                Try
                    ' 检查目录是否存在
                    If Not 客户端实例.Exists(下一级路径) Then
                        ' 切换到父目录
                        客户端实例.ChangeDirectory(当前路径)
                        ' 创建单级目录
                        客户端实例.CreateDirectory(目录)
                        ' 验证是否创建成功
                        If Not 客户端实例.Exists(下一级路径) Then
                            添加日志($"[ERROR]目录创建失败：{下一级路径}", Color.Red)
                            Exit Sub
                        End If
                    End If
                    ' 更新当前路径
                    当前路径 = 下一级路径
                Catch ex As Exception
                    添加日志($"[ERROR]创建目录失败：{下一级路径}，错误：{ex.Message}", Color.Red)
                    Exit Sub
                End Try
            Next
        End If
        MainForm.分任务进度条.Value = 30
        添加日志($"[Info]Sftp{服务端序号}客户端正在上传文件", Color.Orange)
        ' 获取文件名并拼接远程路径
        Dim 文件名 = Path.GetFileName(本地文件路径)
        Dim 远程文件路径 = If(远程目录路径.EndsWith("/"c), $"{远程目录路径}{文件名}", $"{远程目录路径}/{文件名}")
        Try
            ' 上传文件
            Using 文件流 As New FileStream(本地文件路径, FileMode.Open)
                If 是否循环更新界面 Then
                    模拟文件上传耗时.Enabled = True
                    Dim UpLoadResult As IAsyncResult = 客户端实例.BeginUploadFile(文件流, 远程文件路径)
                    While Not UpLoadResult.IsCompleted
                        Application.DoEvents()
                        Thread.Sleep(延时毫秒数)
                    End While
                    客户端实例.EndUploadFile(UpLoadResult)
                    模拟文件上传耗时.Enabled = False
                Else
                    客户端实例.UploadFile(文件流, 远程文件路径)
                End If
                MainForm.分任务进度条.Value = 95
            End Using
            添加日志($"[Success]Sftp{服务端序号}客户端文件上传成功", Color.Green)
            MainForm.分任务进度条.Value = 100
        Catch ex As Exception
            添加日志($"[ERROR]Sftp{服务端序号}客户端文件上传失败:{ex.Message}", Color.Red)
            添加日志("[Tips]请检查sftp用户是否有写权限,是否已启用UTF-8编码", Color.Red)
            Exit Sub
        End Try
    End Sub
    Public Function 检测远程文件是否存在(远程文件路径 As String) ' 检测远程文件是否存在
        If 客户端实例 Is Nothing OrElse Not 客户端实例.IsConnected Then
            添加日志($"[ERROR]Sftp{服务端序号}客户端未连接", Color.Red)
            Return False
        End If
        MainForm.分任务进度条.Value = 30
        Try
            If 客户端实例.Exists(远程文件路径) Then
                添加日志($"[Success]Sftp{服务端序号}客户端发现远程文件存在", Color.Green)
                Return True
            Else
                添加日志($"[ERROR]Sftp{服务端序号}客户端发现远程文件不存在", Color.Red)
                Return False
            End If
        Catch
			添加日志($"[ERROR]Sftp{服务端序号}客户端检测远程文件失败", Color.Red)
			Return False
		End Try
    End Function
    Public Sub 删除文件(远程文件路径 As String)  ' 删除远程文件
        If 客户端实例 Is Nothing OrElse Not 客户端实例.IsConnected Then
            添加日志($"[ERROR]Sftp{服务端序号}客户端未连接", Color.Red)
            Exit Sub
        End If
        MainForm.分任务进度条.Value = 50
        Try
            客户端实例.DeleteFile(远程文件路径)
            添加日志($"[Success]Sftp{服务端序号}客户端成功删除远程文件", Color.Green)
        Catch
            添加日志($"[ERROR]Sftp{服务端序号}客户端删除远程文件失败", Color.Red)
        Finally
            MainForm.分任务进度条.Value = 100
        End Try
    End Sub
    Public Sub 断开连接() ' 断开连接并释放资源
        If 客户端实例 IsNot Nothing AndAlso 客户端实例.IsConnected Then
            客户端实例.Disconnect()
            MainForm.分任务进度条.Value = 0
            MainForm.执行中的分任务.Text = $"无"
        End If
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose ' 实现 IDisposable 接口
        If Not 连接状态 Then Return
        断开连接()
        客户端实例?.Dispose()
        GC.SuppressFinalize(Me)
        添加日志($"[Info]Sftp{服务端序号}服务器连接已断开并释放", Color.Orange)
    End Sub
End Class
Public Module 处理单个Sftp服务端功能
    Public Sub 处理单个Sftp服务端_上传文件(地址 As String, 端口 As String, 用户名 As String, 密码 As String, 服务器序号 As String, 本地文件路径 As String, 远程目录 As String)
        Using Sftp实例 As New SFTP客户端()
            Sftp实例.建立Sftp连接(地址, 端口, 用户名, 密码, 服务器序号)
            If Not Sftp实例.连接状态 Then Return
            Sftp实例.上传文件(本地文件路径, 远程目录)
        End Using
    End Sub
    Public Sub 处理单个Sftp服务端_删除文件(地址 As String, 端口 As String, 用户名 As String, 密码 As String, 服务器序号 As String, 远程文件路径 As String)
        Using Sftp实例 As New SFTP客户端()
            Sftp实例.建立Sftp连接(地址, 端口, 用户名, 密码, 服务器序号)
            If Sftp实例.连接状态 AndAlso Sftp实例.检测远程文件是否存在(远程文件路径) Then
                Sftp实例.删除文件(远程文件路径)
            End If
        End Using
    End Sub
    Public Sub 测试单个Sftp服务端_上传和删除(地址 As String, 端口 As String, 用户名 As String, 密码 As String, 服务器序号 As String, 本地文件路径 As String, 远程目录 As String, 远程文件路径 As String)
        Using Sftp实例 As New SFTP客户端()
            Sftp实例.建立Sftp连接(地址, 端口, 用户名, 密码, 服务器序号)
            MainForm.主任务进度条.PerformStep()
            If Not Sftp实例.连接状态 Then Return
            Sftp实例.上传文件(本地文件路径, 远程目录)
            MainForm.主任务进度条.PerformStep()
            If Sftp实例.连接状态 AndAlso Sftp实例.检测远程文件是否存在(远程文件路径) Then
                Sftp实例.删除文件(远程文件路径)
            End If
            MainForm.主任务进度条.PerformStep()
        End Using
    End Sub
End Module