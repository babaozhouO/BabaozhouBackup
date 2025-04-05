' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Public Class RCON客户端
    Private RCON客户端 As TcpClient
    Private 数据流 As NetworkStream
    Private 请求ID As Integer = 0
    Public 连接状态 As Boolean = False
    Private Sub 添加日志(信息 As String, 颜色 As Color) ' 添加日志
        MainForm.日志窗口.添加日志(信息, 颜色)
    End Sub
    Public Sub 连接RCON(地址 As String, 端口 As Integer, 密码 As String) ' 连接到 RCON 服务端
        RCON客户端 = New TcpClient()
        Try
            添加日志("[Action]正在连接到RCON服务端", Color.Orange)
            RCON客户端.Connect(地址, 端口)
        Catch
            添加日志("[ERROR]无法连接到指定的地址和端口，请检查网络连接和配置文件或服务端设置。", Color.Red)
            Return
        End Try
        添加日志("[Success]连接成功", Color.Green)
        数据流 = RCON客户端.GetStream()
        添加日志("[INFO]正在尝试登录至RCON服务器", Color.Black)
        登录到RCON(密码)
    End Sub
    Private Sub 登录到RCON(密码 As String) ' 认证（发送密码）
        添加日志("[INFO]正在构建登录信息数据包", Color.Black)
        Dim 登录数据包 = 构建数据包(3, 密码)
        添加日志("[INFO]正在发送登录信息数据包", Color.Black)
        数据流.Write(登录数据包, 0, 登录数据包.Length)
        添加日志("[INFO]正在读取返回数据包", Color.Black)
        Dim 登录数据包返回值 = 读取返回数据包()
        If 登录数据包返回值.返回的数据包请求ID = -1 Then
            添加日志("[ERROR]RCON认证失败，密码错误", Color.Red)
        Else
            连接状态 = True
            添加日志("[Success]RCON认证成功", Color.Green)
        End If
    End Sub
    Public Async Sub 发送指令并返回响应(指令 As String) ' 发送命令并返回响应
        If 连接状态 = False Then Return
        If 指令 = "" Then
            MsgBox("指令不能为空", MsgBoxStyle.Critical, "错误")
            添加日志("[ERROR]指令不能为空", Color.Red)
            Return
        End If
        添加日志("[Info]要发送的指令:" + 指令, Color.Orange)
        请求ID += 1
        添加日志("[INFO]正在构建指令数据包", Color.Black)
        Dim 指令数据包 = 构建数据包(2, 指令)
        添加日志("[INFO]正在发送指令数据包", Color.Black)
        数据流.Write(指令数据包, 0, 指令数据包.Length) ' 发送数据包
        添加日志("[INFO]正在等待返回结果", Color.Black)
        Await Task.Delay(3000) ' 等待数据包到达
        添加日志("[INFO]正在读取返回数据包", Color.Black)
        Dim 指令返回值 = 读取返回数据包()
        添加日志(指令返回值.返回的有效数据, Color.Orange)
    End Sub
    Private Function 构建数据包(数据包类型 As Integer, 要发送的数据 As String) As Byte() ' 构建 RCON 协议数据包
        Using 数据包 As New MemoryStream()
            Using 数据包写入器 As New BinaryWriter(数据包)
                ' 计算长度（长度 = 请求ID(4) + 类型(4) + 要发送的数据字节数 + 2个空字节）
                Dim 转化后的数据 = Encoding.UTF8.GetBytes(要发送的数据)
                Dim 数据包总长度 As Integer = 4 + 4 + 转化后的数据.Length + 2
                ' 写入数据包
                数据包写入器.Write(数据包总长度)           ' 长度（小端序）
                数据包写入器.Write(请求ID)        ' 请求ID
                数据包写入器.Write(数据包类型)       ' 包类型
                数据包写入器.Write(转化后的数据)     ' 载荷
                数据包写入器.Write({0, 0})           ' 空字节结尾
            End Using
            Return 数据包.ToArray()
        End Using
    End Function
    Private Function 读取返回数据包() As (返回的数据包请求ID As Integer, 返回的有效数据 As String) ' 读取并解析响应数据包
        Dim 返回的数据包(4096) As Byte
        'Thread.Sleep(3000) ' 等待数据包到达
        Dim 返回数据包长度记录 = 数据流.Read(返回的数据包, 0, 4) ' 读取数据包长度（前4个字节）
        If 返回数据包长度记录 < 4 Then
            添加日志("[ERROR]无法读取完整数据包长度", Color.Red)
            Throw New IOException("无法读取完整数据包长度")
        End If
        Dim 真实总长度 = BitConverter.ToInt32(返回的数据包, 0) ' 解析长度
        返回数据包长度记录 = 数据流.Read(返回的数据包, 0, 真实总长度)
        If 返回数据包长度记录 < 真实总长度 Then
            添加日志("[ERROR]数据包不完整", Color.Red)
            Throw New IOException("数据包不完整")
        End If
        Using 读取缓冲区 As New MemoryStream(返回的数据包, 0, 真实总长度) ' 读取剩余数据
            Using 读取器 As New BinaryReader(读取缓冲区)
                Dim 返回的数据包请求ID = 读取器.ReadInt32()
                Dim ptype = 读取器.ReadInt32()
                Dim 有效数据 = 读取器.ReadBytes(真实总长度 - 4 - 4 - 2) ' 排除请求ID、类型和空字节
                Return (返回的数据包请求ID, Encoding.UTF8.GetString(有效数据))
            End Using
        End Using
    End Function
    Public Sub 断开连接() ' 关闭连接
        If 连接状态 = False Then Return
        数据流?.Close()
        RCON客户端?.Close()
        添加日志("[Info]已断开RCON服务器连接", Color.Orange)
    End Sub
End Class
