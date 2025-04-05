' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Imports Renci.SshNet
Imports System.IO
Public Class SFTP客户端 ' SFTP 客户端类，实现连接和文件上传功能
    Implements IDisposable
    Private _客户端实例 As SftpClient ' SFTP 客户端实例
    Private ReadOnly _主机地址 As String ' 连接参数
    Private ReadOnly _端口号 As Integer
    Private ReadOnly _用户名 As String
    Private ReadOnly _密码 As String
    Public 连接状态 As Boolean = False ' 连接状态
    Private Sub 添加日志(信息 As String, 颜色 As Color) ' 添加日志
        MainForm.日志窗口.添加日志(信息, 颜色)
    End Sub
    Public Sub New(主机地址 As String, 端口号 As Integer, 用户名 As String, 密码 As String) ' 初始化 SFTP 客户端
        _主机地址 = 主机地址
        _端口号 = 端口号
        _用户名 = 用户名
        _密码 = 密码
    End Sub
    Public Sub 建立Sftp连接() ' 连接到 SFTP 服务器
        添加日志("[Info]正在尝试建立Sftp连接", Color.Orange)
        Try
            If _客户端实例 Is Nothing OrElse Not _客户端实例.IsConnected Then '检测是否已连接
                Dim 连接信息 = New PasswordConnectionInfo(_主机地址, _端口号, _用户名, _密码) ' 创建连接信息
                _客户端实例 = New SftpClient(连接信息)
                _客户端实例.Connect()
            Else
                添加日志("[ERROR]Sftp服务器已连接，请勿重复连接", Color.Red)
            End If
        Catch
            添加日志("[ERROR]SFTP服务器连接失败，请检查网络和凭据或配置文件", Color.Red)
        End Try
        If _客户端实例.IsConnected Then
            连接状态 = True
            添加日志("[Success]成功建立Sftp连接", Color.Green)
        End If
    End Sub
    Public Sub 上传文件(本地文件路径 As String, 远程目录路径 As String) ' 上传本地文件到远程路径
        If 连接状态 = False Then Return
        If 本地文件路径 = "" Then
            添加日志("[ERROR]未选择文件", Color.Red)
            Return
        End If
        If Not File.Exists(本地文件路径) Then
            添加日志("[ERROR]本地文件不存在", Color.Red) '检测本地文件是否存在
            Throw New FileNotFoundException("", 本地文件路径)
        End If
        If _客户端实例 Is Nothing OrElse Not _客户端实例.IsConnected Then '检测是否已连接
            Throw New InvalidOperationException("未连接Sftp服务器")
        End If
        Try
            ' 确保远程目录存在
            If Not _客户端实例.Exists(远程目录路径) Then
                添加日志("[Warning]远程目录不存在，正在创建", Color.DarkOrange)
                _客户端实例.CreateDirectory(远程目录路径)
                添加日志("[Success]远程目录创建成功", Color.Green)
            End If
            添加日志("[Success]远程目录存在", Color.Green)
            添加日志("[Info]正在上传文件", Color.Orange)
            ' 获取文件名并拼接远程路径
            Dim 文件名 = Path.GetFileName(本地文件路径)
            Dim 远程文件路径 = If(远程目录路径.EndsWith("/"), $"{远程目录路径}{文件名}", $"{远程目录路径}/{文件名}")
            ' 上传文件
            Using 文件流 As New FileStream(本地文件路径, FileMode.Open)
                _客户端实例.UploadFile(文件流, 远程文件路径)
            End Using
            添加日志("[Success]文件上传成功", Color.Green)
        Catch
            添加日志("[ERROR]文件上传失败", Color.Red)
        End Try
    End Sub
    Public Sub 断开连接() ' 断开连接并释放资源
        If _客户端实例 IsNot Nothing AndAlso _客户端实例.IsConnected Then
            _客户端实例.Disconnect()
        End If
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose ' 实现 IDisposable 接口
        If 连接状态 = False Then Return
        断开连接()
        _客户端实例?.Dispose()
        添加日志("[Info]Sftp连接已断开并释放", Color.Orange)
    End Sub
End Class