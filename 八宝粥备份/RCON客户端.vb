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
Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Public Class RCON客户端
    Private RCON客户端 As TcpClient
    Private 数据流 As NetworkStream
    Private 请求ID As Integer = 0
    Public 连接状态 As Boolean = False
    Private Shared Sub 添加日志(信息 As String, 颜色 As Color)
        If 日志窗口.InvokeRequired Then
            日志窗口.Invoke(Sub() 日志窗口.添加日志(信息, 颜色))
        Else
            日志窗口.添加日志(信息, 颜色)
        End If
    End Sub
    Public Sub 连接RCON(地址 As String, 端口 As Integer, 密码 As String, 服务器序号 As String) ' 连接到 RCON 服务端
        RCON客户端 = New TcpClient()
        Try
            添加日志($"[Action]正在连接到RCON{服务器序号}服务端", Color.Orange)
            RCON客户端.Connect(地址, 端口)
        Catch
            添加日志($"[ERROR]RCON{服务器序号}客户端无法连接到指定的服务器，请检查网络连接和配置文件。", Color.Red)
            Return
        End Try
        添加日志($"[Success]RCON{服务器序号}连接成功", Color.Green)
        数据流 = RCON客户端.GetStream()
        添加日志($"[INFO]正在尝试登录至RCONRCON{服务器序号}服务器", Color.Black)
        登录到RCON(密码, 服务器序号)
    End Sub
    Private Sub 登录到RCON(密码 As String, 服务器序号 As String) ' 认证（发送密码）
        添加日志($"[INFO]RCON{服务器序号}客户端正在构建登录信息数据包", Color.Black)
        Dim 登录数据包 = 构建数据包(3, 密码)
        添加日志($"[INFO]RCON{服务器序号}客户端正在发送登录信息数据包", Color.Black)
        数据流.WriteAsync(登录数据包, 0, 登录数据包.Length, CancellationToken.None)
        添加日志($"[INFO]RCON{服务器序号}客户端正在读取返回数据包", Color.Black)
        Dim 登录数据包返回值 = 读取返回数据包(服务器序号)
        If 登录数据包返回值.返回的数据包请求ID = -1 Then
            添加日志($"[ERROR]RCON{服务器序号}认证失败，密码错误", Color.Red)
        Else
            连接状态 = True
            添加日志($"[Success]RCON{服务器序号}认证成功", Color.Green)
        End If
    End Sub
    Public Sub 发送指令并返回响应(指令 As String, 服务器序号 As String) ' 发送命令并返回响应
        If Not 连接状态 Then Return
        If 指令 = "" Then
            MsgBox("指令不能为空", MsgBoxStyle.Critical, "错误")
            添加日志($"[ERROR]RCON{服务器序号}客户端指令不能为空", Color.Red)
            Return
        End If
        添加日志($"[Info]RCON{服务器序号}客户端要发送的指令:" + 指令, Color.Orange)
        请求ID += 1
        添加日志($"[INFO]RCON{服务器序号}客户端正在构建指令数据包", Color.Black)
        Dim 指令数据包 = 构建数据包(2, 指令)
        添加日志($"[INFO]RCON{服务器序号}客户端正在发送指令数据包", Color.Black)
        数据流.WriteAsync(指令数据包, 0, 指令数据包.Length, CancellationToken.None) ' 发送数据包
        添加日志($"[INFO]RCON{服务器序号}客户端正在等待返回结果", Color.Black)
        If 指令 = "stop" Then
            Thread.Sleep(500)
        Else
            Thread.Sleep(3000) ' 等待数据包到达
        End If
        添加日志($"[INFO]RCON{服务器序号}客户端正在读取返回数据包", Color.Black)
        Dim 指令返回值 = 读取返回数据包(服务器序号)
        添加日志($"[Info]RCON{服务器序号}服务器指令返回信息: " + 指令返回值.返回的有效数据, Color.Orange)
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
    Private Function 读取返回数据包(服务器序号 As String) As (返回的数据包请求ID As Integer, 返回的有效数据 As String) ' 读取并解析响应数据包
        Dim 返回的数据包(4096) As Byte
        Dim 返回数据包长度记录 = 数据流.Read(返回的数据包, 0, 4) ' 读取数据包长度（前4个字节）
        If 返回数据包长度记录 < 4 Then 添加日志($"[ERROR]RCON{服务器序号}客户端无法读取完整数据包长度", Color.Red)
        Dim 真实总长度 = BitConverter.ToInt32(返回的数据包, 0) ' 解析长度
        返回数据包长度记录 = 数据流.Read(返回的数据包.AsSpan(0, 真实总长度))
        If 返回数据包长度记录 < 真实总长度 Then 添加日志($"[ERROR]RCON{服务器序号}客户端接收到的数据包不完整", Color.Red)
        Using 读取缓冲区 As New MemoryStream(返回的数据包, 0, 真实总长度) ' 读取剩余数据
            Using 读取器 As New BinaryReader(读取缓冲区)
                Dim 返回的数据包请求ID = 读取器.ReadInt32()
                Dim ptype = 读取器.ReadInt32()
                Dim 有效数据 = 读取器.ReadBytes(真实总长度 - 4 - 4 - 2) ' 排除请求ID、类型和空字节
                Return (返回的数据包请求ID, Encoding.UTF8.GetString(有效数据))
            End Using
        End Using
    End Function
    Public Sub 断开连接(服务器序号 As String)  ' 关闭连接
        If Not 连接状态 Then Return
        数据流?.Close()
        RCON客户端?.Close()
        添加日志($"[Info]已断开RCON{服务器序号}服务器连接", Color.Orange)
    End Sub
End Class
Public Module 处理单个服务端
    Private Sub 添加日志(信息 As String, 颜色 As Color)
        If 日志窗口.InvokeRequired Then
            日志窗口.Invoke(Sub() 日志窗口.添加日志(信息, 颜色))
        Else
            日志窗口.添加日志(信息, 颜色)
        End If
    End Sub
    Public Sub 处理单个服务器(地址 As String, 端口 As Integer, 密码 As String, 指令 As String, 服务器序号 As String)
        Dim RCON实例 As New RCON客户端()
        RCON实例.连接RCON(地址, 端口, 密码, 服务器序号)
        If RCON实例.连接状态 Then
            RCON实例.发送指令并返回响应(指令, 服务器序号)
            RCON实例.断开连接(服务器序号)
        Else
            添加日志($"[ERROR]RCON{服务器序号}连接失败", Color.Red)
        End If
    End Sub
End Module