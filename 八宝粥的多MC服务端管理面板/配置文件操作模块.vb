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
Imports System.Text

Module 配置文件操作模块
#If MSI_Version Then
    Public ReadOnly Property 程序数据目录 As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "八宝粥的单人团队", "八宝粥的多MC服务端管理面板")
#Else
    Public ReadOnly Property 程序数据目录 As String = Application.StartupPath
#End If
    Public ReadOnly Property 配置文件目录 As String = Path.Combine(程序数据目录, "配置文件")
    '----------------------------------------全局变量----------------------------------------
    '-----------------------主程序设置-----------------------
    Public Property 运行时间 As String
    Public Property 间隔天数 As String
    ''' <summary>
    ''' true=每{间隔天数}天备份模式，false=每{间隔时长}备份模式
    ''' </summary>
    Public Property 运行模式 As Boolean
    Public Property 是否关服备份 As Boolean
    Public Property 等待服务端关闭时长 As Integer
    Public Property 日志窗口隐藏状态 As Boolean = False
    Public Property 帧数 As Integer
    Public Property 延时毫秒数 As Integer
    Public Property 是否循环更新界面 As Boolean
    Public Property 服务运行状态 As Boolean
    Public Property 备份操作进行状态 As Boolean
    '-----------------------RCON1设置-----------------------
    Public Property 是否控制MC服务端1 As Boolean
    Public Property MC服务端1名称 As String
    Public Property RCON1地址 As String
    Public Property RCON1端口 As String
    Public Property RCON1密码 As String
    Public Property MC服务端1路径 As String
    Public Property MC服务端1启动脚本名称 As String
    Public Property 备份MC服务端1排除文件参数 As String
    '-----------------------RCON2设置-----------------------
    Public Property 是否控制MC服务端2 As Boolean
    Public Property MC服务端2名称 As String
    Public Property RCON2地址 As String
    Public Property RCON2端口 As String
    Public Property RCON2密码 As String
    Public Property MC服务端2路径 As String
    Public Property MC服务端2启动脚本名称 As String
    Public Property 备份MC服务端2排除文件参数 As String
    '-----------------------RCON3设置-----------------------
    Public Property 是否控制MC服务端3 As Boolean
    Public Property MC服务端3名称 As String
    Public Property RCON3地址 As String
    Public Property RCON3端口 As String
    Public Property RCON3密码 As String
    Public Property MC服务端3路径 As String
    Public Property MC服务端3启动脚本名称 As String
    Public Property 备份MC服务端3排除文件参数 As String
    '-----------------------RCON4设置-----------------------
    Public Property 是否控制MC服务端4 As Boolean
    Public Property MC服务端4名称 As String
    Public Property RCON4地址 As String
    Public Property RCON4端口 As String
    Public Property RCON4密码 As String
    Public Property MC服务端4路径 As String
    Public Property MC服务端4启动脚本名称 As String
    Public Property 备份MC服务端4排除文件参数 As String
    '-----------------------RCON5设置-----------------------
    Public Property 是否控制MC服务端5 As Boolean
    Public Property MC服务端5名称 As String
    Public Property RCON5地址 As String
    Public Property RCON5端口 As String
    Public Property RCON5密码 As String
    Public Property MC服务端5路径 As String
    Public Property MC服务端5启动脚本名称 As String
    Public Property 备份MC服务端5排除文件参数 As String
    '-----------------------RCON6设置-----------------------
    Public Property 是否控制MC服务端6 As Boolean
    Public Property MC服务端6名称 As String
    Public Property RCON6地址 As String
    Public Property RCON6端口 As String
    Public Property RCON6密码 As String
    Public Property MC服务端6路径 As String
    Public Property MC服务端6启动脚本名称 As String
    Public Property 备份MC服务端6排除文件参数 As String
    '-----------------------RCON7设置-----------------------
    Public Property 是否控制MC服务端7 As Boolean
    Public Property MC服务端7名称 As String
    Public Property RCON7地址 As String
    Public Property RCON7端口 As String
    Public Property RCON7密码 As String
    Public Property MC服务端7路径 As String
    Public Property MC服务端7启动脚本名称 As String
    Public Property 备份MC服务端7排除文件参数 As String
    '-----------------------RCON8设置-----------------------
    Public Property 是否控制MC服务端8 As Boolean
    Public Property MC服务端8名称 As String
    Public Property RCON8地址 As String
    Public Property RCON8端口 As String
    Public Property RCON8密码 As String
    Public Property MC服务端8路径 As String
    Public Property MC服务端8启动脚本名称 As String
    Public Property 备份MC服务端8排除文件参数 As String
    '-----------------------RCON9设置-----------------------
    Public Property 是否控制MC服务端9 As Boolean
    Public Property MC服务端9名称 As String
    Public Property RCON9地址 As String
    Public Property RCON9端口 As String
    Public Property RCON9密码 As String
    Public Property MC服务端9路径 As String
    Public Property MC服务端9启动脚本名称 As String
    Public Property 备份MC服务端9排除文件参数 As String
    '-----------------------RCON10设置-----------------------
    Public Property 是否控制MC服务端10 As Boolean
    Public Property MC服务端10名称 As String
    Public Property RCON10地址 As String
    Public Property RCON10端口 As String
    Public Property RCON10密码 As String
    Public Property MC服务端10路径 As String
    Public Property MC服务端10启动脚本名称 As String
    Public Property 备份MC服务端10排除文件参数 As String
    '-----------------------7zip设置-----------------------
    ' 基本参数
    Public Property 压缩格式 As String
    Public Property 压缩级别 As Integer
    Public Property 压缩方法 As String
    Public Property 字典大小 As String
    Public Property 单词大小 As String
    Public Property 线程数 As String
    Public Property 超时时长 As Integer
    Public Property 备份输出目录 As String
    Public Property 自定义备份目录 As String
    Public Property 是否增量备份 As Boolean
    Public Property 是否备份自定义目录 As Boolean
    '-----------------------Sftp1设置-----------------------
    Public Property Sftp1开关 As Boolean
    Public Property Sftp1名称 As String
    Public Property Sftp1地址 As String
    Public Property Sftp1端口 As String
    Public Property Sftp1用户名 As String
    Public Property Sftp1密码 As String
    '-----------------------Sftp2设置-----------------------
    Public Property Sftp2开关 As Boolean
    Public Property Sftp2名称 As String
    Public Property Sftp2地址 As String
    Public Property Sftp2端口 As String
    Public Property Sftp2用户名 As String
    Public Property Sftp2密码 As String
    '-----------------------Sftp3设置-----------------------
    Public Property Sftp3开关 As Boolean
    Public Property Sftp3名称 As String
    Public Property Sftp3地址 As String
    Public Property Sftp3端口 As String
    Public Property Sftp3用户名 As String
    Public Property Sftp3密码 As String
	''-----------------------配置文件操作函数-----------------------
	'<DllImport("kernel32", CharSet:=CharSet.Unicode)>
	'Private Function GetPrivateProfileString(section As String, key As String, def As String, retVal As StringBuilder, Size As Integer, filePath As String) As Integer '调用ini读取的系统函数
	'End Function '函数声明结束
	'<DllImport("kernel32", CharSet:=CharSet.Unicode)>
	'Public Function WritePrivateProfileString(section As String, key As String, val As String, filePath As String) As Integer '调用ini写入的系统函数
	'End Function
	'Public Function 读取配置(section As String, key As String, def As String, filePath As String) As String '读取配置文件功能
	'    Dim result As New StringBuilder(1024)
	'    GetPrivateProfileString(section, key, def, result, 1024, filePath) '读取配置项
	'    Return result.ToString() '返回配置项值
	'End Function
	'Public Function 写入配置(section As String, key As String, val As String, filePath As String) As Integer '写入配置文件功能
	'    Return WritePrivateProfileString(section, key, val, filePath) '写入配置项
	'End Function
	'-----------------------读取主程序配置功能-----------------------
	Public Sub 读取主程序配置()
        Dim 主程序配置文件 As New Ini文件(Path.Combine(程序数据目录, "配置文件", "MainConfig.ini"))
        间隔天数 = 主程序配置文件.获取值("MainSettings", "Days", "1")
		运行时间 = 主程序配置文件.获取值("MainSettings", "Runtime", "03:00:00")
		是否关服备份 = 主程序配置文件.获取值("MainSettings", "StopMCServer", "True")
        等待服务端关闭时长 = CInt(主程序配置文件.获取值("MainSettings", "WaitingSeconds", "60"))
        运行模式 = 主程序配置文件.获取值("MainSettings", "RunMode", "True")
        帧数 = CInt(主程序配置文件.获取值("MainSettings", "FPS", "25"))
        转换帧数为延时毫秒数()
    End Sub
    '转换帧数为延时毫秒数
    Public Sub 转换帧数为延时毫秒数()
        If 帧数 = 0 Then
            是否循环更新界面 = False
            Exit Sub
        Else
            If 帧数 > 1000 Then
                帧数 = 1000
            End If
            延时毫秒数 = 1000 \ 帧数
            是否循环更新界面 = True
        End If
    End Sub
    '-----------------------读取MC服务端配置功能-----------------------
    Public Sub 读取MC服务端配置()
        Dim MC服务器配置文件 As New Ini文件(Path.Combine(程序数据目录, "配置文件", "MCServerConfig.ini"))
        '-----------------------读取MC服务端1配置-----------------------
        是否控制MC服务端1 = MC服务器配置文件.获取值("MCServer1Config", "Enable", "False")
        MC服务端1名称 = MC服务器配置文件.获取值("MCServer1Config", "Name", "MC服务器1")
        RCON1地址 = MC服务器配置文件.获取值("MCServer1Config", "RCONIP", "25575")
        RCON1端口 = MC服务器配置文件.获取值("MCServer1Config", "RCONPort", "127.0.0.1")
        RCON1密码 = MC服务器配置文件.获取值("MCServer1Config", "RCONPassword", "")
        MC服务端1路径 = MC服务器配置文件.获取值("MCServer1Config", "ServerPath", "")
        MC服务端1启动脚本名称 = MC服务器配置文件.获取值("MCServer1Config", "StartBatPath", "")
        备份MC服务端1排除文件参数 = MC服务器配置文件.获取值("MCServer1Config", "BackupServerExcludedFile", "")
        '-----------------------读取MC服务端2配置-----------------------
        是否控制MC服务端2 = MC服务器配置文件.获取值("MCServer2Config", "Enable", "False")
        MC服务端2名称 = MC服务器配置文件.获取值("MCServer2Config", "Name", "MC服务器2")
        RCON2地址 = MC服务器配置文件.获取值("MCServer2Config", "RCONIP", "25576")
        RCON2端口 = MC服务器配置文件.获取值("MCServer2Config", "RCONPort", "127.0.0.1")
        RCON2密码 = MC服务器配置文件.获取值("MCServer2Config", "RCONPassword", "")
        MC服务端2路径 = MC服务器配置文件.获取值("MCServer2Config", "ServerPath", "")
        MC服务端2启动脚本名称 = MC服务器配置文件.获取值("MCServer2Config", "StartBatPath", "")
        备份MC服务端2排除文件参数 = MC服务器配置文件.获取值("MCServer2Config", "BackupServerExcludedFile", "")
        '-----------------------读取MC服务端3配置-----------------------
        是否控制MC服务端3 = MC服务器配置文件.获取值("MCServer3Config", "Enable", "False")
        MC服务端3名称 = MC服务器配置文件.获取值("MCServer3Config", "Name", "MC服务器3")
        RCON3地址 = MC服务器配置文件.获取值("MCServer3Config", "RCONIP", "25577")
        RCON3端口 = MC服务器配置文件.获取值("MCServer3Config", "RCONPort", "127.0.0.1")
        RCON3密码 = MC服务器配置文件.获取值("MCServer3Config", "RCONPassword", "")
        MC服务端3路径 = MC服务器配置文件.获取值("MCServer3Config", "ServerPath", "")
        MC服务端3启动脚本名称 = MC服务器配置文件.获取值("MCServer3Config", "StartBatPath", "")
        备份MC服务端3排除文件参数 = MC服务器配置文件.获取值("MCServer3Config", "BackupServerExcludedFile", "")
        '-----------------------读取MC服务端4配置-----------------------
        是否控制MC服务端4 = MC服务器配置文件.获取值("MCServer4Config", "Enable", "False")
        MC服务端4名称 = MC服务器配置文件.获取值("MCServer4Config", "Name", "MC服务器4")
        RCON4地址 = MC服务器配置文件.获取值("MCServer4Config", "RCONIP", "25578")
        RCON4端口 = MC服务器配置文件.获取值("MCServer4Config", "RCONPort", "127.0.0.1")
        RCON4密码 = MC服务器配置文件.获取值("MCServer4Config", "RCONPassword", "")
        MC服务端4路径 = MC服务器配置文件.获取值("MCServer4Config", "ServerPath", "")
        MC服务端4启动脚本名称 = MC服务器配置文件.获取值("MCServer4Config", "StartBatPath", "")
        备份MC服务端4排除文件参数 = MC服务器配置文件.获取值("MCServer4Config", "BackupServerExcludedFile", "")
        '-----------------------读取MC服务端5配置-----------------------
        是否控制MC服务端5 = MC服务器配置文件.获取值("MCServer5Config", "Enable", "False")
        MC服务端5名称 = MC服务器配置文件.获取值("MCServer5Config", "Name", "MC服务器5")
        RCON5地址 = MC服务器配置文件.获取值("MCServer5Config", "RCONIP", "25579")
        RCON5端口 = MC服务器配置文件.获取值("MCServer5Config", "RCONPort", "127.0.0.1")
        RCON5密码 = MC服务器配置文件.获取值("MCServer5Config", "RCONPassword", "")
        MC服务端5路径 = MC服务器配置文件.获取值("MCServer5Config", "ServerPath", "")
        MC服务端5启动脚本名称 = MC服务器配置文件.获取值("MCServer5Config", "StartBatPath", "")
        备份MC服务端5排除文件参数 = MC服务器配置文件.获取值("MCServer5Config", "BackupServerExcludedFile", "")
        '-----------------------读取MC服务端6配置-----------------------
        是否控制MC服务端6 = MC服务器配置文件.获取值("MCServer6Config", "Enable", "False")
        MC服务端6名称 = MC服务器配置文件.获取值("MCServer6Config", "Name", "MC服务器6")
        RCON6地址 = MC服务器配置文件.获取值("MCServer6Config", "RCONIP", "25580")
        RCON6端口 = MC服务器配置文件.获取值("MCServer6Config", "RCONPort", "127.0.0.1")
        RCON6密码 = MC服务器配置文件.获取值("MCServer6Config", "RCONPassword", "")
        MC服务端6路径 = MC服务器配置文件.获取值("MCServer6Config", "ServerPath", "")
        MC服务端6启动脚本名称 = MC服务器配置文件.获取值("MCServer6Config", "StartBatPath", "")
        备份MC服务端6排除文件参数 = MC服务器配置文件.获取值("MCServer6Config", "BackupServerExcludedFile", "")
        '-----------------------读取MC服务端7配置-----------------------
        是否控制MC服务端7 = MC服务器配置文件.获取值("MCServer7Config", "Enable", "False")
        MC服务端7名称 = MC服务器配置文件.获取值("MCServer7Config", "Name", "MC服务器7")
        RCON7地址 = MC服务器配置文件.获取值("MCServer7Config", "RCONIP", "25581")
        RCON7端口 = MC服务器配置文件.获取值("MCServer7Config", "RCONPort", "127.0.0.1")
        RCON7密码 = MC服务器配置文件.获取值("MCServer7Config", "RCONPassword", "")
        MC服务端7路径 = MC服务器配置文件.获取值("MCServer7Config", "ServerPath", "")
        MC服务端7启动脚本名称 = MC服务器配置文件.获取值("MCServer7Config", "StartBatPath", "")
        备份MC服务端7排除文件参数 = MC服务器配置文件.获取值("MCServer7Config", "BackupServerExcludedFile", "")
        '-----------------------读取MC服务端8配置-----------------------
        是否控制MC服务端8 = MC服务器配置文件.获取值("MCServer8Config", "Enable", "False")
        MC服务端8名称 = MC服务器配置文件.获取值("MCServer8Config", "Name", "MC服务器8")
        RCON8地址 = MC服务器配置文件.获取值("MCServer8Config", "RCONIP", "25582")
        RCON8端口 = MC服务器配置文件.获取值("MCServer8Config", "RCONPort", "127.0.0.1")
        RCON8密码 = MC服务器配置文件.获取值("MCServer8Config", "RCONPassword", "")
        MC服务端8路径 = MC服务器配置文件.获取值("MCServer8Config", "ServerPath", "")
        MC服务端8启动脚本名称 = MC服务器配置文件.获取值("MCServer8Config", "StartBatPath", "")
        备份MC服务端8排除文件参数 = MC服务器配置文件.获取值("MCServer8Config", "BackupServerExcludedFile", "")
        '-----------------------读取MC服务端9配置-----------------------
        是否控制MC服务端9 = MC服务器配置文件.获取值("MCServer9Config", "Enable", "False")
        MC服务端9名称 = MC服务器配置文件.获取值("MCServer9Config", "Name", "MC服务器9")
        RCON9地址 = MC服务器配置文件.获取值("MCServer9Config", "RCONIP", "25583")
        RCON9端口 = MC服务器配置文件.获取值("MCServer9Config", "RCONPort", "127.0.0.1")
        RCON9密码 = MC服务器配置文件.获取值("MCServer9Config", "RCONPassword", "")
        MC服务端9路径 = MC服务器配置文件.获取值("MCServer9Config", "ServerPath", "")
        MC服务端9启动脚本名称 = MC服务器配置文件.获取值("MCServer9Config", "StartBatPath", "")
        备份MC服务端9排除文件参数 = MC服务器配置文件.获取值("MCServer9Config", "BackupServerExcludedFile", "")
        '-----------------------读取MC服务端10配置-----------------------
        是否控制MC服务端10 = MC服务器配置文件.获取值("MCServer10Config", "Enable", "False")
        MC服务端10名称 = MC服务器配置文件.获取值("MCServer10Config", "Name", "MC服务器10")
        RCON10地址 = MC服务器配置文件.获取值("MCServer10Config", "RCONIP", "25584")
        RCON10端口 = MC服务器配置文件.获取值("MCServer10Config", "RCONPort", "127.0.0.1")
        RCON10密码 = MC服务器配置文件.获取值("MCServer10Config", "RCONPassword", "")
        MC服务端10路径 = MC服务器配置文件.获取值("MCServer10Config", "ServerPath", "")
        MC服务端10启动脚本名称 = MC服务器配置文件.获取值("MCServer10Config", "StartBatPath", "")
        备份MC服务端10排除文件参数 = MC服务器配置文件.获取值("MCServer10Config", "BackupServerExcludedFile", "")
    End Sub
    '-----------------------读取7zip配置功能-----------------------
    Public Sub 读取7zip配置()
        Dim 七zip配置文件 As New Ini文件(Path.Combine(程序数据目录, "配置文件", "7-ZipConfig.ini"))
        压缩格式 = 七zip配置文件.获取值("7zipConfig", "CompressionFormat", "7z")
        压缩级别 = CInt(七zip配置文件.获取值("7zipConfig", "CompressionLevel", "9"))
        压缩方法 = 七zip配置文件.获取值("7zipConfig", "CompressionMethod", "LZMA2")
		字典大小 = 七zip配置文件.获取值("7zipConfig", "DictionarySize", "64KB")
        单词大小 = 七zip配置文件.获取值("7zipConfig", "WordSize", "8")
        线程数 = 七zip配置文件.获取值("7zipConfig", "ThreadsCounts", "1")
        超时时长 = CInt(七zip配置文件.获取值("7zipConfig", "TimeOut", "600"))
        备份输出目录 = 七zip配置文件.获取值("7zipConfig", "BackupOutputDir", "")
        是否备份自定义目录 = 七zip配置文件.获取值("7zipConfig", "BackupCustomizedDir", "False")
        自定义备份目录 = 七zip配置文件.获取值("7zipConfig", "BackupDir", "")
        是否增量备份 = 七zip配置文件.获取值("7zipConfig", "IncrementalBackup", "True")
    End Sub
    '-----------------------读取Sftp配置功能-----------------------
    Public Sub 读取Sftp配置()
        Dim Sftp配置文件 As New Ini文件(Path.Combine(程序数据目录, "配置文件", "SFTPConfig.ini"))
        '-----------------------读取Sftp1配置功能-----------------------
        Sftp1开关 = Sftp配置文件.获取值("SFTP1Config", "Enable", True)
        Sftp1名称 = Sftp配置文件.获取值("SFTP1Config", "Name", "SFTP1")
        Sftp1地址 = Sftp配置文件.获取值("SFTP1Config", "IP", "127.0.0.1")
        Sftp1端口 = Sftp配置文件.获取值("SFTP1Config", "Port", "22")
        Sftp1用户名 = Sftp配置文件.获取值("SFTP1Config", "User", "admin")
        Sftp1密码 = Sftp配置文件.获取值("SFTP1Config", "Password", "")
        '-----------------------读取Sftp2配置功能-----------------------
        Sftp2开关 = Sftp配置文件.获取值("SFTP2Config", "Enable", "False")
        Sftp2名称 = Sftp配置文件.获取值("SFTP2Config", "Name", "SFTP2")
        Sftp2地址 = Sftp配置文件.获取值("SFTP2Config", "IP", "127.0.0.1")
        Sftp2端口 = Sftp配置文件.获取值("SFTP2Config", "Port", "22")
        Sftp2用户名 = Sftp配置文件.获取值("SFTP2Config", "User", "admin")
        Sftp2密码 = Sftp配置文件.获取值("SFTP2Config", "Password", "")
        '-----------------------读取Sftp3配置功能-----------------------
        Sftp3开关 = Sftp配置文件.获取值("SFTP3Config", "Enable", "False")
        Sftp3名称 = Sftp配置文件.获取值("SFTP3Config", "Name", "SFTP3")
        Sftp3地址 = Sftp配置文件.获取值("SFTP3Config", "IP", "127.0.0.1")
        Sftp3端口 = Sftp配置文件.获取值("SFTP3Config", "Port", "22")
        Sftp3用户名 = Sftp配置文件.获取值("SFTP3Config", "User", "admin")
        Sftp3密码 = Sftp配置文件.获取值("SFTP3Config", "Password", "")
    End Sub
    '-----------------------写入主程序配置功能-----------------------
    Public Sub 写入主程序配置(间隔天数 As String, 运行时间 As String, 是否关服备份 As Boolean, 关服等待时长 As Integer, 帧数 As Integer, 运行模式 As Boolean)
        Dim 主程序配置文件 As New Ini文件(Path.Combine(程序数据目录, "配置文件", "MainConfig.ini"))
        主程序配置文件.设置值("MainSettings", "Runtime", 运行时间) _
        .设置值("MainSettings", "Days", 间隔天数) _
        .设置值("MainSettings", "StopMCServer", 是否关服备份) _
        .设置值("MainSettings", "WaitingSeconds", 关服等待时长) _
        .设置值("MainSettings", "RunMode", 运行模式) _
        .设置值("MainSettings", "FPS", 帧数.ToString) _
        .保存()
        主程序配置文件.保存()
    End Sub
    '-----------------------写入RCON配置功能-----------------------
    Public Sub 写入MC服务端配置(MC服务器序号 As String, 开关状态 As String, 服务器名称 As String, 地址 As String, 端口 As String, 密码 As String, 路径 As String, 启动脚本 As String, 排除文件参数 As String)
        Dim MC服务器配置文件 As New Ini文件(Path.Combine(程序数据目录, "配置文件", "MCServerConfig.ini"))
        MC服务器配置文件 _
            .设置值($"MCServer{MC服务器序号}Config", "Enable", 开关状态) _
            .设置值($"MCServer{MC服务器序号}Config", "Name", 服务器名称) _
            .设置值($"MCServer{MC服务器序号}Config", "IP", 地址) _
            .设置值($"MCServer{MC服务器序号}Config", "RCONPort", 端口) _
            .设置值($"MCServer{MC服务器序号}Config", "RCONPassword", 密码) _
            .设置值($"MCServer{MC服务器序号}Config", "ServerPath", 路径) _
            .设置值($"MCServer{MC服务器序号}Config", "StartBatPath", 启动脚本) _
            .设置值($"MCServer{MC服务器序号}Config", "ExcludedFile", 排除文件参数) _
            .保存()
    End Sub
    '-----------------------写入7zip配置功能-----------------------
    Public Sub 写入7zip配置(压缩格式 As String, 压缩级别 As Integer, 压缩方法 As String, 字典大小 As String, 单词大小 As String, 超时时长 As Integer, 自定义备份目录 As String, 备份目录 As String, 是否增量备份 As Boolean, 是否备份自定义目录 As String, 线程数 As String)
        Dim 七Zip配置文件 As New Ini文件(Path.Combine(程序数据目录, "配置文件", "7-ZipConfig.ini"))
        七Zip配置文件 _
            .设置值("7zipConfig", "CompressionFormat", 压缩格式) _
            .设置值("7zipConfig", "CompressionLevel", 压缩级别.ToString) _
            .设置值("7zipConfig", "CompressionMethod", 压缩方法) _
            .设置值("7zipConfig", "DictionarySize", 字典大小) _
            .设置值("7zipConfig", "WordSize", 单词大小) _
            .设置值("7zipConfig", "ThreadsCounts", 线程数) _
            .设置值("7zipConfig", "TimeOut", 超时时长.ToString) _
            .设置值("7zipConfig", "BackupDir", 自定义备份目录) _
            .设置值("7zipConfig", "BackupOutputDir", 备份目录) _
            .设置值("7zipConfig", "IncrementalBackup", 是否增量备份) _
            .设置值("7zipConfig", "BackupCustomizedDir", 是否备份自定义目录) _
            .保存()
    End Sub
    '-----------------------写入Sftp配置功能-----------------------
    Public Sub 写入Sftp配置(Sftp服务器序号 As String, 开关状态 As String, 服务器名称 As String, 地址 As String, 端口 As String, 用户名 As String, 密码 As String)
        Dim Sftp配置文件 As New Ini文件(Path.Combine(程序数据目录, "配置文件", "SFTPConfig.ini"))
        Sftp配置文件 _
            .设置值($"SFTP{Sftp服务器序号}Config", "Enable", 开关状态) _
            .设置值($"SFTP{Sftp服务器序号}Config", "Name", 服务器名称) _
            .设置值($"SFTP{Sftp服务器序号}Config", "IP", 地址) _
            .设置值($"SFTP{Sftp服务器序号}Config", "Port", 端口) _
            .设置值($"SFTP{Sftp服务器序号}Config", "User", 用户名) _
            .设置值($"SFTP{Sftp服务器序号}Config", "Password", 密码) _
            .保存()
    End Sub
    Public Class Ini文件
        ' 配置文件的完整路径
        Private ReadOnly 文件路径 As String
        ' 存储节区与键值对的字典结构
        Private ReadOnly 节区字典 As New Dictionary(Of String, Dictionary(Of String, String))()
        Public Sub New(路径 As String)
            文件路径 = 路径
            If File.Exists(文件路径) Then
                加载()
            End If
        End Sub
        ' 从文件加载配置到内存
        Private Sub 加载()
            Dim 当前节区 As String = ""
            For Each 原始行 In File.ReadAllLines(文件路径, Encoding.UTF8)
                Dim 处理后行 = 原始行.Trim()
                If 处理后行.StartsWith("["c) AndAlso 处理后行.EndsWith("]"c) Then
                    ' 提取节区名称（去除方括号）
                    当前节区 = 处理后行.Substring(1, 处理后行.Length - 2)
                    节区字典(当前节区) = New Dictionary(Of String, String)()
                ElseIf Not String.IsNullOrEmpty(处理后行) AndAlso Not 处理后行.StartsWith(";"c) Then
                    ' 分割键值对（允许值中包含等号）
                    Dim 键值对 = 处理后行.Split("="c, 2)
                    If 键值对.Length = 2 Then
                        节区字典(当前节区)(键值对(0).Trim()) = 键值对(1).Trim()
                    End If
                End If
            Next
        End Sub
        ' 将内存中的配置保存回文件
        Public Sub 保存()
            Using 写入器 As New StreamWriter(文件路径)
                Try
                    For Each 节区 In 节区字典
                        写入器.WriteLine($"[{节区.Key}]", Encoding.UTF8)
                        For Each 键值 In 节区.Value
                            写入器.WriteLine($"{键值.Key}={键值.Value}", Encoding.UTF8)
                        Next
                        写入器.WriteLine() ' 添加空行分隔不同节区
                    Next
                Catch ex As Exception
                    日志窗口.添加日志($"[ERROR]配置文件写入失败：{ex}", Color.Red）
                End Try
            End Using
        End Sub

        ' 获取指定节区的键值（不存在时返回默认值）
        Public Function 获取值(节区 As String, 键 As String, Optional 默认值 As String = "") As String
            If 节区字典.ContainsKey(节区) AndAlso 节区字典(节区).ContainsKey(键) Then
                If String.IsNullOrEmpty(节区字典(节区)(键)) Then
                    Return 默认值
                Else
                    Return 节区字典(节区)(键)
                End If
            End If
            Return 默认值
        End Function

        ' 设置指定节区的键值（自动创建不存在的节区）
        ' 修改类方法，返回自身实例以支持链式调用
        Public Function 设置值(节区 As String, 键 As String, 值 As String) As Ini文件
            If Not 节区字典.ContainsKey(节区) Then
                节区字典(节区) = New Dictionary(Of String, String)()
            End If
            节区字典(节区)(键) = 值
            Return Me
        End Function
    End Class
End Module
