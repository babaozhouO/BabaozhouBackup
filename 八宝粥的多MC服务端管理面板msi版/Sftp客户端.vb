﻿'Copyright 2025 八宝粥(Email:1749861851@qq.com)

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
Imports System.Linq.Expressions
Imports System.Text
Imports System.Threading
Public Class SFTP客户端 ' SFTP 客户端类，实现连接和文件上传功能
    Implements IDisposable
    Private 客户端实例 As SftpClient ' SFTP 客户端实例
    Public 连接状态 As Boolean = False ' 连接状态
    Public 远程文件存在状态 As Boolean = False ' 远程文件存在状态
    Private 服务端序号 As String
    Private Sub 添加日志(信息 As String, 颜色 As Color)
        If 日志窗口.InvokeRequired Then
            日志窗口.Invoke(Sub() 日志窗口.添加日志(信息, 颜色))
        Else
            日志窗口.添加日志(信息, 颜色)
        End If
    End Sub
    Public Sub 建立Sftp连接(主机地址 As String, 端口号 As Integer, 用户名 As String, 密码 As String, _服务端序号 As String) ' 连接到 SFTP 服务器
        服务端序号 = _服务端序号
        添加日志($"[Action]正在尝试连接到Sftp{服务端序号}服务器", Color.Orange)
        Try
            If 客户端实例 Is Nothing OrElse Not 客户端实例.IsConnected Then '检测是否已连接
                Dim 连接信息 = New PasswordConnectionInfo(主机地址, 端口号, 用户名, 密码) With {
                    .Encoding = Encoding.UTF8 ' 设置编码为 UTF-8
                    } ' 创建连接信息
                客户端实例 = New SftpClient(连接信息)
                客户端实例.Connect()
            Else
                添加日志($"[ERROR]Sftp{服务端序号}服务器已连接，请勿重复连接", Color.Red)
            End If
        Catch
            添加日志($"[ERROR]SFTP{服务端序号}服务器连接失败，请检查网络和凭据或配置文件", Color.Red)
        End Try
        If 客户端实例 IsNot Nothing AndAlso 客户端实例.IsConnected Then
            连接状态 = True
            添加日志($"[Success]成功连接Sftp{服务端序号}服务器", Color.Green)
        End If
    End Sub
    Public Sub 上传文件(本地文件路径 As String, 远程目录路径 As String) ' 上传本地文件到远程路径
        If 本地文件路径 = "" Then 添加日志($"[ERROR]Sftp{服务端序号}客户端发现未选择文件", Color.Red) : Return
        If Not File.Exists(本地文件路径) Then 添加日志($"[ERROR]Sftp{服务端序号}客户端发现本地文件不存在", Color.Red) : Return '检测本地文件是否存在
        If 客户端实例 Is Nothing OrElse Not 客户端实例.IsConnected Then 添加日志($"[ERROR]Sftp{服务端序号}客户端未连接", Color.Red) : Return
        Try
            ' 确保远程目录存在
            If Not 客户端实例.Exists(远程目录路径) Then
                添加日志($"[Warning]Sftp{服务端序号}客户端发现远程目录不存在，正在创建", Color.DarkOrange)
                客户端实例.CreateDirectory(远程目录路径)
                添加日志($"[Success]Sftp{服务端序号}客户端成功创建远程目录", Color.Green)
            End If
            添加日志($"[Success]Sftp{服务端序号}客户端确认远程目录存在", Color.Green)
            添加日志($"[Info]Sftp{服务端序号}客户端正在上传文件", Color.Orange)
            ' 获取文件名并拼接远程路径
            Dim 文件名 = Path.GetFileName(本地文件路径)
            Dim 远程文件路径 = If(远程目录路径.EndsWith("/"), $"{远程目录路径}{文件名}", $"{远程目录路径}/{文件名}")
            ' 上传文件
            Using 文件流 As New FileStream(本地文件路径, FileMode.Open)
                客户端实例.UploadFile(文件流, 远程文件路径)
            End Using
            添加日志($"[Success]Sftp{服务端序号}客户端文件上传成功", Color.Green)
        Catch ex As Exception
            添加日志($"[ERROR]Sftp{服务端序号}客户端文件上传失败:{ex}", Color.Red)
            添加日志("[Tips]请检查sftp用户是否有写权限,是否已启用UTF-8编码", Color.Red)
        End Try
    End Sub
    Public Sub 检测远程文件是否存在(远程文件路径 As String) ' 检测远程文件是否存在
        If 客户端实例 Is Nothing OrElse Not 客户端实例.IsConnected Then 添加日志($"[ERROR]Sftp{服务端序号}客户端未连接", Color.Red) : Return
        Try
            If 客户端实例.Exists(远程文件路径) Then
                远程文件存在状态 = True
                添加日志($"[Success]Sftp{服务端序号}客户端发现远程文件存在", Color.Green)
            Else
                添加日志($"[ERROR]Sftp{服务端序号}客户端发现远程文件不存在", Color.Red)
            End If
        Catch
            添加日志($"[ERROR]Sftp{服务端序号}客户端检测远程文件失败", Color.Red)
        End Try
    End Sub
    Public Sub 删除文件(远程文件路径 As String)  ' 删除远程文件
        If 客户端实例 Is Nothing OrElse Not 客户端实例.IsConnected Then 添加日志($"[ERROR]Sftp{服务端序号}客户端未连接", Color.Red)
        Try
            If 远程文件存在状态 Then
                客户端实例.DeleteFile(远程文件路径)
                添加日志($"[Success]Sftp{服务端序号}客户端成功删除远程文件", Color.Green)
            Else
                添加日志($"[ERROR]Sftp{服务端序号}客户端发现远程文件不存在", Color.Red)
            End If
        Catch
            添加日志($"[ERROR]Sftp{服务端序号}客户端删除远程文件失败", Color.Red)
        End Try
    End Sub
    Public Sub 断开连接() ' 断开连接并释放资源
        If 客户端实例 IsNot Nothing AndAlso 客户端实例.IsConnected Then
            客户端实例.Disconnect()
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
        Return
    End Sub
    Public Sub 处理单个Sftp服务端_删除文件(地址 As String, 端口 As String, 用户名 As String, 密码 As String, 服务器序号 As String, 远程文件路径 As String)
        Using Sftp实例 As New SFTP客户端()
            Sftp实例.建立Sftp连接(地址, 端口, 用户名, 密码, 服务器序号)
            If Not Sftp实例.连接状态 Then Return
            Sftp实例.检测远程文件是否存在(远程文件路径)
            If Not Sftp实例.远程文件存在状态 Then Return
            Sftp实例.删除文件(远程文件路径)
        End Using
        Return
    End Sub
End Module