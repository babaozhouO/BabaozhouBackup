' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms

Public Module 主程序设置
    Public 运行时间 As String = ""
End Module
Public Module RCON1设置
    Public RCON1服务器 As String
    Public RCON1地址 As String
    Public RCON1端口 As String
    Public RCON1密码 As String
    Public RCON1命令 As String
End Module
Public Module RCON2设置
    Public RCON2服务器 As String
    Public RCON2地址 As String
    Public RCON2端口 As String
    Public RCON2密码 As String
    Public RCON2命令 As String
End Module
Public Module RCON3设置
    Public RCON3服务器 As String
    Public RCON3地址 As String
    Public RCON3端口 As String
    Public RCON3密码 As String
    Public RCON3命令 As String
End Module
Public Module 七zip设置
    Public 压缩格式 As String = ""
    Public 压缩等级 As String = ""
    Public 压缩密码 As String = ""
    Public 压缩文件 As String = ""
End Module
Public Module Sftp1设置
    Public Sftp1名称 As String
    Public Sftp1地址 As String
    Public Sftp1端口 As String
    Public Sftp1用户名 As String
    Public Sftp1密码 As String
End Module
Public Module Sftp2设置
    Public Sftp2名称 As String
    Public Sftp2地址 As String
    Public Sftp2端口 As String
    Public Sftp2用户名 As String
    Public Sftp2密码 As String
End Module
Public Module Sftp3设置
    Public Sftp3名称 As String
    Public Sftp3地址 As String
    Public Sftp3端口 As String
    Public Sftp3用户名 As String
    Public Sftp3密码 As String
End Module
Public Module 配置文件操作
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
End Module