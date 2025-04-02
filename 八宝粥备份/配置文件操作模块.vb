' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms

Module 配置文件操作模块
    '----------------------------------------全局变量----------------------------------------
    '-----------------------主程序设置-----------------------
    Public 运行时间 As String = ""
    '-----------------------RCON1设置-----------------------
    Public RCON1服务器 As String
    Public RCON1地址 As String
    Public RCON1端口 As String
    Public RCON1密码 As String
    Public RCON1命令 As String
    '-----------------------RCON2设置-----------------------
    Public RCON2服务器 As String
    Public RCON2地址 As String
    Public RCON2端口 As String
    Public RCON2密码 As String
    Public RCON2命令 As String
    '-----------------------RCON3设置-----------------------
    Public RCON3服务器 As String
    Public RCON3地址 As String
    Public RCON3端口 As String
    Public RCON3密码 As String
    Public RCON3命令 As String
    '-----------------------7zip设置-----------------------
    Public 压缩格式 As String
    Public 压缩等级 As String
    Public 压缩密码 As String
    '-----------------------Sftp1设置-----------------------
    Public Sftp1名称 As String
    Public Sftp1地址 As String
    Public Sftp1端口 As String
    Public Sftp1用户名 As String
    Public Sftp1密码 As String
    '-----------------------Sftp2设置-----------------------
    Public Sftp2名称 As String
    Public Sftp2地址 As String
    Public Sftp2端口 As String
    Public Sftp2用户名 As String
    Public Sftp2密码 As String
    '-----------------------Sftp3设置-----------------------
    Public Sftp3名称 As String
    Public Sftp3地址 As String
    Public Sftp3端口 As String
    Public Sftp3用户名 As String
    Public Sftp3密码 As String
    '-----------------------配置文件操作函数-----------------------
    <DllImport("kernel32", CharSet:=CharSet.Unicode)>
    Private Function GetPrivateProfileString(section As String, key As String, def As String, retVal As StringBuilder, Size As Integer, filePath As String) As Integer '调用ini读取的系统函数
    End Function '函数声明结束
    <DllImport("kernel32", CharSet:=CharSet.Unicode)>
    Public Function WritePrivateProfileString(section As String, key As String, val As String, filePath As String) As Integer '调用ini写入的系统函数
    End Function
    Public Function 读取配置(section As String, key As String, def As String, filePath As String) As String '读取配置文件功能
        Dim result As New StringBuilder(1024)
        GetPrivateProfileString(section, key, def, result, 1024, filePath) '读取配置项
        Return result.ToString() '返回配置项值
    End Function
    Public Function 写入配置(section As String, key As String, val As String, filePath As String) As Integer '写入配置文件功能
        Return WritePrivateProfileString(section, key, val, filePath) '写入配置项
    End Function
    '-----------------------读取主程序配置功能-----------------------
    Public Sub 读取主程序配置()
        运行时间 = 读取配置("MainSettings", "Runtime", "03:00:00", "配置文件/MainConfig.ini")
    End Sub
    '-----------------------读取RCON1配置功能-----------------------
    Public Sub 读取RCON1配置()
        RCON1服务器 = 读取配置("RCONConfig", "Server1Name", "Server1", "配置文件/RCONConfig.ini")
        RCON1地址 = 读取配置("RCONConfig", "Server1IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON1端口 = 读取配置("RCONConfig", "Server1Port", "25575", "配置文件/RCONConfig.ini")
        RCON1密码 = 读取配置("RCONConfig", "Server1Password", "空", "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------读取RCON2配置功能-----------------------
    Public Sub 读取RCON2配置()
        RCON2服务器 = 读取配置("RCONConfig", "Server2Name", "Server3", "配置文件/RCONConfig.ini")
        RCON2地址 = 读取配置("RCONConfig", "Server2IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON2端口 = 读取配置("RCONConfig", "Server2Port", "25576", "配置文件/RCONConfig.ini")
        RCON2密码 = 读取配置("RCONConfig", "Server2Password", "空", "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------读取RCON3配置功能-----------------------
    Public Sub 读取RCON3配置()
        RCON3服务器 = 读取配置("RCONConfig", "Server3Name", "Server3", "配置文件/RCONConfig.ini")
        RCON3地址 = 读取配置("RCONConfig", "Server3IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON3端口 = 读取配置("RCONConfig", "Server3Port", "25577", "配置文件/RCONConfig.ini")
        RCON3密码 = 读取配置("RCONConfig", "Server3Password", "空", "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------读取7zip配置功能-----------------------
    Public Sub 读取7zip配置()
        压缩格式 = 读取配置("7zipConfig", "Format", "7z", "配置文件/7zipConfig.ini")
        压缩等级 = 读取配置("7zipConfig", "Level", "5", "配置文件/7zipConfig.ini")
        压缩密码 = 读取配置("7zipConfig", "Password", "空", "配置文件/7zipConfig.ini")
    End Sub
    '-----------------------读取Sftp1配置功能-----------------------
    Public Sub 读取Sftp1配置()
        Sftp1名称 = 读取配置("SFTPConfig", "Sftp1Name", "SFTP1", "配置文件/SFTPConfig.ini")
        Sftp1地址 = 读取配置("SFTPConfig", "Sftp1IP", "127.0.0.1", "配置文件/SFTPConfig.ini")
        Sftp1端口 = 读取配置("SFTPConfig", "Sftp1Port", "22", "配置文件/SFTPConfig.ini")
        Sftp1用户名 = 读取配置("SFTPConfig", "Sftp1User", "default", "配置文件/SFTPConfig.ini")
        Sftp1密码 = 读取配置("SFTPConfig", "Sftp1Password", "default", "配置文件/SFTPConfig.ini")
    End Sub
    '-----------------------读取Sftp2配置功能-----------------------
    Public Sub 读取Sftp2配置()
        Sftp2名称 = 读取配置("SFTPConfig", "Sftp2Name", "SFTP2", "配置文件/SFTPConfig.ini")
        Sftp2地址 = 读取配置("SFTPConfig", "Sftp2IP", "127.0.0.1", "配置文件/SFTPConfig.ini")
        Sftp2端口 = 读取配置("SFTPConfig", "Sftp2Port", "22", "配置文件/SFTPConfig.ini")
        Sftp2用户名 = 读取配置("SFTPConfig", "Sftp2User", "default", "配置文件/SFTPConfig.ini")
        Sftp2密码 = 读取配置("SFTPConfig", "Sftp2Password", "default", "配置文件/SFTPConfig.ini")
    End Sub
    '-----------------------读取Sftp3配置功能-----------------------
    Public Sub 读取Sftp3配置()
        Sftp3名称 = 读取配置("SFTPConfig", "Sftp3Name", "SFTP3", "配置文件/SFTPConfig.ini")
        Sftp3地址 = 读取配置("SFTPConfig", "Sftp3IP", "127.0.0.1", "配置文件/SFTPConfig.ini")
        Sftp3端口 = 读取配置("SFTPConfig", "Sftp3Port", "22", "配置文件/SFTPConfig.ini")
        Sftp3用户名 = 读取配置("SFTPConfig", "Sftp3User", "default", "配置文件/SFTPConfig.ini")
        Sftp3密码 = 读取配置("SFTPConfig", "Sftp3Password", "default", "配置文件/SFTPConfig.ini")
    End Sub
    '-----------------------写入主程序配置功能-----------------------
    Public Function 写入主程序配置(time As String)
        Dim Logs As String
        写入配置（"MainSettings", "Runtime", time, "配置文件/MainConfig.ini")
        If time = 读取配置("MainSettings", "Runtime", "03:00:00", "配置文件/MainConfig.ini") Then
            Logs = "[Succeess]主程序配置写入成功"
        Else
            Logs = "[Failure]主程序配置写入失败"
        End If
        Return Logs
    End Function
End Module
