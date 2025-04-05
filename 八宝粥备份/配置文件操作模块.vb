' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms

Module 配置文件操作模块
    '----------------------------------------全局变量----------------------------------------
    '-----------------------主程序设置-----------------------
    Public 运行时间 As String
    '-----------------------RCON1设置-----------------------
    Public RCON1开关 As String
    Public RCON1名称 As String
    Public RCON1地址 As String
    Public RCON1端口 As String
    Public RCON1密码 As String
    '-----------------------RCON2设置-----------------------
    Public RCON2开关 As String
    Public RCON2名称 As String
    Public RCON2地址 As String
    Public RCON2端口 As String
    Public RCON2密码 As String
    '-----------------------RCON3设置-----------------------
    Public RCON3开关 As String
    Public RCON3名称 As String
    Public RCON3地址 As String
    Public RCON3端口 As String
    Public RCON3密码 As String
    '-----------------------RCON4设置-----------------------
    Public RCON4开关 As String
    Public RCON4名称 As String
    Public RCON4地址 As String
    Public RCON4端口 As String
    Public RCON4密码 As String
    '-----------------------RCON5设置-----------------------
    Public RCON5开关 As String
    Public RCON5名称 As String
    Public RCON5地址 As String
    Public RCON5端口 As String
    Public RCON5密码 As String
    '-----------------------RCON6设置-----------------------
    Public RCON6开关 As String
    Public RCON6名称 As String
    Public RCON6地址 As String
    Public RCON6端口 As String
    Public RCON6密码 As String
    '-----------------------RCON7设置-----------------------
    Public RCON7开关 As String
    Public RCON7名称 As String
    Public RCON7地址 As String
    Public RCON7端口 As String
    Public RCON7密码 As String
    '-----------------------RCON8设置-----------------------
    Public RCON8开关 As String
    Public RCON8名称 As String
    Public RCON8地址 As String
    Public RCON8端口 As String
    Public RCON8密码 As String
    '-----------------------RCON9设置-----------------------
    Public RCON9开关 As String
    Public RCON9名称 As String
    Public RCON9地址 As String
    Public RCON9端口 As String
    Public RCON9密码 As String
    '-----------------------RCON10设置-----------------------
    Public RCON10开关 As String
    Public RCON10名称 As String
    Public RCON10地址 As String
    Public RCON10端口 As String
    Public RCON10密码 As String
    '-----------------------7zip设置-----------------------
    ' 基本参数
    Public Property 压缩格式 As String = "7z"
    Public Property 覆盖模式 As String = "a" ' a=覆盖, s=跳过, t=重命名, u=更新
    ' 压缩级别
    Public Property 压缩级别 As String = "9" ' 0-9
    ' 压缩算法
    Public Property 压缩算法 As String = "LZMA2"
    Public Property 字典大小 As String = "64m" ' 如: 32m, 64m, 128m
    Public Property 单词大小 As Integer = 273
    Public Property 固实模式 As Boolean = True
    Public Property 多线程 As Boolean = True
    ' 密码保护
    Public Property 压缩密码 As String = ""
    Public Property 加密文件名 As Boolean = False
    ' 分卷压缩
    Public Property 分卷大小 As String = "" ' 如: "500m", "1g"
    ' 文件管理
    Public Property 排除文件 As New List(Of String) ' 要排除的文件掩码列表
    ' 高级设置
    Public Property 快速字节数 As Integer = 273 ' LZMA算法专用
    Public Property 快速排序模式 As Boolean = False
    Public Property 保留创建时间 As Boolean = True
    '-----------------------Sftp1设置-----------------------
    Public Sftp1开关 As String
    Public Sftp1名称 As String
    Public Sftp1地址 As String
    Public Sftp1端口 As String
    Public Sftp1用户名 As String
    Public Sftp1密码 As String
    '-----------------------Sftp2设置-----------------------
    Public Sftp2开关 As String
    Public Sftp2名称 As String
    Public Sftp2地址 As String
    Public Sftp2端口 As String
    Public Sftp2用户名 As String
    Public Sftp2密码 As String
    '-----------------------Sftp3设置-----------------------
    Public Sftp3开关 As String
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
    '-----------------------读取RCON配置功能-----------------------
    Public Sub 读取RCON配置()
        读取RCON1配置()
        读取RCON2配置()
        读取RCON3配置()
        读取RCON4配置()
        读取RCON5配置()
        读取RCON6配置()
        读取RCON7配置()
        读取RCON8配置()
        读取RCON9配置()
        读取RCON10配置()
    End Sub
    '-----------------------读取RCON1配置功能-----------------------
    Public Sub 读取RCON1配置()
        RCON1开关 = 读取配置("RCONConfig", "Server1", "ON", "配置文件/RCONConfig.ini")
        RCON1名称 = 读取配置("RCONConfig", "Server1Name", "Server1", "配置文件/RCONConfig.ini")
        RCON1地址 = 读取配置("RCONConfig", "Server1IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON1端口 = 读取配置("RCONConfig", "Server1Port", "25575", "配置文件/RCONConfig.ini")
        RCON1密码 = 读取配置("RCONConfig", "Server1Password", "空", "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------读取RCON2配置功能-----------------------
    Public Sub 读取RCON2配置()
        RCON2开关 = 读取配置("RCONConfig", "Server2", "OFF", "配置文件/RCONConfig.ini")
        RCON2名称 = 读取配置("RCONConfig", "Server2Name", "Server3", "配置文件/RCONConfig.ini")
        RCON2地址 = 读取配置("RCONConfig", "Server2IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON2端口 = 读取配置("RCONConfig", "Server2Port", "25576", "配置文件/RCONConfig.ini")
        RCON2密码 = 读取配置("RCONConfig", "Server2Password", "空", "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------读取RCON3配置功能-----------------------
    Public Sub 读取RCON3配置()
        RCON3开关 = 读取配置("RCONConfig", "Server3", "OFF", "配置文件/RCONConfig.ini")
        RCON3名称 = 读取配置("RCONConfig", "Server3Name", "Server3", "配置文件/RCONConfig.ini")
        RCON3地址 = 读取配置("RCONConfig", "Server3IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON3端口 = 读取配置("RCONConfig", "Server3Port", "25577", "配置文件/RCONConfig.ini")
        RCON3密码 = 读取配置("RCONConfig", "Server3Password", "空", "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------读取RCON4配置功能-----------------------
    Public Sub 读取RCON4配置()
        RCON4开关 = 读取配置("RCONConfig", "Server4", "OFF", "配置文件/RCONConfig.ini")
        RCON4名称 = 读取配置("RCONConfig", "Server4Name", "Server4", "配置文件/RCONConfig.ini")
        RCON4地址 = 读取配置("RCONConfig", "Server4IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON4端口 = 读取配置("RCONConfig", "Server4Port", "25578", "配置文件/RCONConfig.ini")
        RCON4密码 = 读取配置("RCONConfig", "Server4Password", "空", "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------读取RCON5配置功能-----------------------
    Public Sub 读取RCON5配置()
        RCON5开关 = 读取配置("RCONConfig", "Server5", "OFF", "配置文件/RCONConfig.ini")
        RCON5名称 = 读取配置("RCONConfig", "Server5Name", "Server4", "配置文件/RCONConfig.ini")
        RCON5地址 = 读取配置("RCONConfig", "Server5IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON5端口 = 读取配置("RCONConfig", "Server5Port", "25579", "配置文件/RCONConfig.ini")
        RCON5密码 = 读取配置("RCONConfig", "Server5Password", "空", "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------读取RCON6配置功能-----------------------
    Public Sub 读取RCON6配置()
        RCON6开关 = 读取配置("RCONConfig", "Server6", "OFF", "配置文件/RCONConfig.ini")
        RCON6名称 = 读取配置("RCONConfig", "Server6Name", "Server4", "配置文件/RCONConfig.ini")
        RCON6地址 = 读取配置("RCONConfig", "Server6IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON6端口 = 读取配置("RCONConfig", "Server6Port", "25580", "配置文件/RCONConfig.ini")
        RCON6密码 = 读取配置("RCONConfig", "Server6Password", "空", "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------读取RCON7配置功能-----------------------
    Public Sub 读取RCON7配置()
        RCON7开关 = 读取配置("RCONConfig", "Server7", "OFF", "配置文件/RCONConfig.ini")
        RCON7名称 = 读取配置("RCONConfig", "Server7Name", "Server3", "配置文件/RCONConfig.ini")
        RCON7地址 = 读取配置("RCONConfig", "Server7IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON7端口 = 读取配置("RCONConfig", "Server7Port", "25581", "配置文件/RCONConfig.ini")
        RCON7密码 = 读取配置("RCONConfig", "Server7Password", "空", "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------读取RCON8配置功能-----------------------
    Public Sub 读取RCON8配置()
        RCON8开关 = 读取配置("RCONConfig", "Server8", "OFF", "配置文件/RCONConfig.ini")
        RCON8名称 = 读取配置("RCONConfig", "Server8Name", "Server4", "配置文件/RCONConfig.ini")
        RCON8地址 = 读取配置("RCONConfig", "Server8IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON8端口 = 读取配置("RCONConfig", "Server8Port", "25582", "配置文件/RCONConfig.ini")
        RCON8密码 = 读取配置("RCONConfig", "Server8Password", "空", "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------读取RCON9配置功能-----------------------
    Public Sub 读取RCON9配置()
        RCON9开关 = 读取配置("RCONConfig", "Server9", "OFF", "配置文件/RCONConfig.ini")
        RCON9名称 = 读取配置("RCONConfig", "Server9Name", "Server4", "配置文件/RCONConfig.ini")
        RCON9地址 = 读取配置("RCONConfig", "Server9IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON9端口 = 读取配置("RCONConfig", "Server9Port", "25583", "配置文件/RCONConfig.ini")
        RCON9密码 = 读取配置("RCONConfig", "Server9Password", "空", "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------读取RCON10配置功能-----------------------
    Public Sub 读取RCON10配置()
        RCON10开关 = 读取配置("RCONConfig", "Server10", "OFF", "配置文件/RCONConfig.ini")
        RCON10名称 = 读取配置("RCONConfig", "Server10Name", "Server4", "配置文件/RCONConfig.ini")
        RCON10地址 = 读取配置("RCONConfig", "Server10IP", "127.0.0.1", "配置文件/RCONConfig.ini")
        RCON10端口 = 读取配置("RCONConfig", "Server10Port", "25584", "配置文件/RCONConfig.ini")
        RCON10密码 = 读取配置("RCONConfig", "Server10Password", "空", "配置文件/RCONConfig.ini")
    End Sub

    '-----------------------读取7zip配置功能-----------------------
    Public Sub 读取7zip配置()
        压缩格式 = 读取配置("7zipConfig", "ArchiveType", "7z", "配置文件/7-ZipConfig.ini")
        压缩级别 = 读取配置("7zipConfig", "CompressionLevel", "9", "配置文件/7-ZipConfig.ini")
    End Sub
    '-----------------------读取Sftp配置功能-----------------------
    Public Sub 读取Sftp配置()
        读取Sftp1配置()
        读取Sftp2配置()
        读取Sftp3配置()
    End Sub
    '-----------------------读取Sftp1配置功能-----------------------
    Public Sub 读取Sftp1配置()
        Sftp1开关 = 读取配置("SFTPConfig", "Sftp1", "ON", "配置文件/SFTPConfig.ini")
        Sftp1名称 = 读取配置("SFTPConfig", "Sftp1Name", "SFTP1", "配置文件/SFTPConfig.ini")
        Sftp1地址 = 读取配置("SFTPConfig", "Sftp1IP", "127.0.0.1", "配置文件/SFTPConfig.ini")
        Sftp1端口 = 读取配置("SFTPConfig", "Sftp1Port", "22", "配置文件/SFTPConfig.ini")
        Sftp1用户名 = 读取配置("SFTPConfig", "Sftp1User", "default", "配置文件/SFTPConfig.ini")
        Sftp1密码 = 读取配置("SFTPConfig", "Sftp1Password", "default", "配置文件/SFTPConfig.ini")
    End Sub
    '-----------------------读取Sftp2配置功能-----------------------
    Public Sub 读取Sftp2配置()
        Sftp2开关 = 读取配置("SFTPConfig", "Sftp2", "OFF", "配置文件/SFTPConfig.ini")
        Sftp2名称 = 读取配置("SFTPConfig", "Sftp2Name", "SFTP2", "配置文件/SFTPConfig.ini")
        Sftp2地址 = 读取配置("SFTPConfig", "Sftp2IP", "127.0.0.1", "配置文件/SFTPConfig.ini")
        Sftp2端口 = 读取配置("SFTPConfig", "Sftp2Port", "22", "配置文件/SFTPConfig.ini")
        Sftp2用户名 = 读取配置("SFTPConfig", "Sftp2User", "default", "配置文件/SFTPConfig.ini")
        Sftp2密码 = 读取配置("SFTPConfig", "Sftp2Password", "default", "配置文件/SFTPConfig.ini")
    End Sub
    '-----------------------读取Sftp3配置功能-----------------------
    Public Sub 读取Sftp3配置()
        Sftp3开关 = 读取配置("SFTPConfig", "Sftp3", "OFF", "配置文件/SFTPConfig.ini")
        Sftp3名称 = 读取配置("SFTPConfig", "Sftp3Name", "SFTP3", "配置文件/SFTPConfig.ini")
        Sftp3地址 = 读取配置("SFTPConfig", "Sftp3IP", "127.0.0.1", "配置文件/SFTPConfig.ini")
        Sftp3端口 = 读取配置("SFTPConfig", "Sftp3Port", "22", "配置文件/SFTPConfig.ini")
        Sftp3用户名 = 读取配置("SFTPConfig", "Sftp3User", "default", "配置文件/SFTPConfig.ini")
        Sftp3密码 = 读取配置("SFTPConfig", "Sftp3Password", "default", "配置文件/SFTPConfig.ini")
    End Sub
    '-----------------------写入主程序配置功能-----------------------
    Public Sub 写入主程序配置(运行时间 As String)
        写入配置（"MainSettings", "Runtime", 运行时间, "配置文件/MainConfig.ini")
        If 运行时间 = 读取配置("MainSettings", "Runtime", "03:00:00", "配置文件/MainConfig.ini") Then
            MainForm.日志窗口.添加日志("[Succeess]主程序配置写入成功", Color.Green)
            MainForm.日志窗口.添加日志("新运行时间=" + 运行时间, Color.Blue)
        Else
            MainForm.日志窗口.添加日志("[Failure]主程序配置写入失败", Color.Red)
        End If
    End Sub
    '-----------------------写入RCON配置功能-----------------------
    Public Sub 写入RCON配置(RCON服务器序号 As String, 开关状态 As String, 服务器名称 As String, 地址 As String, 端口 As String, 密码 As String)
        写入配置("RCONConfig", "Server" + RCON服务器序号, 开关状态, "配置文件/RCONConfig.ini")
        写入配置("RCONConfig", "Server" + RCON服务器序号 + "Name", 服务器名称, "配置文件/RCONConfig.ini")
        写入配置("RCONConfig", "Server" + RCON服务器序号 + "IP", 地址, "配置文件/RCONConfig.ini")
        写入配置("RCONConfig", "Server" + RCON服务器序号 + "Port", 端口, "配置文件/RCONConfig.ini")
        写入配置("RCONConfig", "Server" + RCON服务器序号 + "Password", 密码, "配置文件/RCONConfig.ini")
    End Sub
    '-----------------------写入7zip配置功能-----------------------
    Public Sub 写入7zip配置(压缩格式 As String, 压缩级别 As String)
        写入配置("7zipConfig", "ArchiveType", 压缩格式, "配置文件/7-ZipConfig.ini")
        写入配置("7zipConfig", "CompressionLevel", 压缩级别, "配置文件/7-ZipConfig.ini")
    End Sub
    '-----------------------写入Sftp配置功能-----------------------
    Public Sub 写入Sftp配置(Sftp服务器序号 As String, 开关状态 As String, 服务器名称 As String, 地址 As String, 端口 As String, 用户名 As String, 密码 As String)
        写入配置("SFTPConfig", "Sftp" + Sftp服务器序号, 开关状态, "配置文件/SFTPConfig.ini")
        写入配置("SFTPConfig", "Sftp" + Sftp服务器序号 + "Name", 服务器名称, "配置文件/SFTPConfig.ini")
        写入配置("SFTPConfig", "Sftp" + Sftp服务器序号 + "IP", 地址, "配置文件/SFTPConfig.ini")
        写入配置("SFTPConfig", "Sftp" + Sftp服务器序号 + "Port", 端口, "配置文件/SFTPConfig.ini")
        写入配置("SFTPConfig", "Sftp" + Sftp服务器序号 + "User", 用户名, "配置文件/SFTPConfig.ini")
        写入配置("SFTPConfig", "Sftp" + Sftp服务器序号 + "Password", 密码, "配置文件/SFTPConfig.ini")
    End Sub
End Module
