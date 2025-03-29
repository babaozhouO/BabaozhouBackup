' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Imports System.Runtime.InteropServices
Imports System.Text

Public Module 主程序设置
    Public 运行时间 As String = ""
End Module
Public Module RCON设置
    Public RCON服务器 As String = ""
    Public RCON地址 As String = ""
    Public RCON端口 As String = ""
    Public RCON密码 As String = ""
    Public RCON命令 As String = ""
End Module
Public Module 七zip设置
    Public 压缩格式 As String = ""
    Public 压缩等级 As String = ""
    Public 压缩密码 As String = ""
    Public 压缩文件 As String = ""
End Module
Public Module Sftp设置
    Public Sftp地址 As String = ""
    Public Sftp端口 As String = ""
    Public Sftp用户名 As String = ""
    Public Sftp密码 As String = ""
    Public Sftp文件 As String = ""
End Module
Public Module 配置文件操作
    <DllImport("kernel32", CharSet:=CharSet.Unicode)>'声明API函数
    Private Function GetPrivateProfileString(section As String, key As String, def As String, retVal As StringBuilder, Size As Integer, filePath As String) As Integer
    End Function '函数声明结束
    <DllImport("kernel32", CharSet:=CharSet.Unicode)>
    Public Function WritePrivateProfileString(section As String, key As String, val As String, filePath As String) As Integer '写入配置项
    End Function
    Public Function 读取配置(section As String, key As String, def As String, filePath As String) As String '读取配置文件
        Dim result As New StringBuilder(1024)
        GetPrivateProfileString(section, key, def, result, 1024, filePath) '读取配置项
        Return result.ToString() '返回配置项值

    End Function
    Public Function 写入配置(section As String, key As String, val As String, filePath As String) As Integer '写入配置文件
        Return WritePrivateProfileString(section, key, val, filePath) '写入配置项
    End Function
End Module