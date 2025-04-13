Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Public Module SevenZip
    Public Class SevenZIP压缩功能
        Private ReadOnly 程序路径 As String = Path.Combine(Application.StartupPath, "资源", "7z.exe")
        Public 输出路径 As String
        Private MC服务端序号 As String = ""
        ' 执行压缩操作
        Public Function 执行压缩(输入目录 As String, 输出路径 As String, Optional 附加参数 As String = "", Optional 要备份的RCON序号 As String = "") As Boolean
            If Not 验证参数(输入目录, 输出路径) Then Return False
            MC服务端序号 = 要备份的RCON序号
                If MC服务端序号 = "" Then
                    If 是否增量备份 Then
                        添加日志($"[Info]开始执行压缩操作", Color.Orange)
                    Else
                        添加日志($"[Info]开始执行增量备份操作", Color.Orange)
                    End If
                Else
                    If 是否增量备份 Then
                        添加日志($"[Info]开始执行MC服务端{MC服务端序号}完整备份操作", Color.Orange)
                    Else
                        添加日志($"[Info]开始执行MC服务端{MC服务端序号}增量备份操作", Color.Orange)
                    End If
                End If
            Dim 参数 = 生成压缩参数(输入目录, 输出路径, 附加参数)
            Return 运行压缩进程(参数)
        End Function
        Private Function 验证参数(输入目录 As String, 输出路径 As String) As Boolean
            添加日志($"[Info]正在检查基本压缩参数", Color.Black)
            If String.IsNullOrWhiteSpace(输入目录) Then 添加日志("[ERROR]输入目录不能为空", Color.Red) : Return False
            If String.IsNullOrWhiteSpace(输出路径) Then 添加日志("[ERROR]输出路径不能为空", Color.Red) : Return False
            If Not Directory.Exists(输入目录) Then 添加日志($"[ERROR]输入目录不存在：{输入目录}", Color.Red) : Return False
            If Not File.Exists(程序路径) Then 添加日志($"[ERROR]7z程序不存在：{程序路径}", Color.Red) : Return False
            添加日志($"[Success]基本压缩参数检查完成", Color.DarkGreen)
            Return True
        End Function
        Private Shared Function 转义路径(路径 As String) As String
            Return """" & 路径.Replace("""", "\""") & """"
        End Function
        Private Shared Function 生成压缩参数(输入目录 As String, 输出路径 As String, 附加参数 As String) As String
            添加日志($"[Info]生成完整压缩参数中", Color.Black)
            Dim 转义输入目录 = 转义路径(输入目录)
            Dim 转义输出路径 = 转义路径(输出路径)
            Dim 参数 As New List(Of String) From {
            "a",
            "-r",
            $"-t{压缩格式}",
            $"-mx{压缩级别}",
            "-aoa",
            "-m0=LZMA2:d=48m:fb=273",
            $"-mmt{线程数}",
            转义输出路径,
            转义输入目录,
            "-xr!""cache\""",
            "-xr!""tmp\""",
            "-x!""Thumbs.db""",
            "-x!""$RECYCLE.BIN"""
            }

            If Not String.IsNullOrWhiteSpace(附加参数) Then
                参数.AddRange(解析附加参数(附加参数))
            End If
            添加日志("[Success]完整压缩参数生成完成}", Color.DarkGreen)
            添加日志($"[Debug]7z完整参数：{String.Join(" ", 参数)}", Color.Gray)
            Return String.Join(" ", 参数)
        End Function
        Public Shared Function 解析附加参数(输入的附加参数 As String) As IEnumerable(Of String)
            添加日志($"[Info]正在解析附加参数：{输入的附加参数}", Color.Black)
            ' 使用正则表达式匹配带引号的参数或不带引号的参数
            Dim 匹配集合 = Regex.Matches(输入的附加参数, "(""([^""]*)""|(\S+))")
            Return 匹配集合.Cast(Of Match)().Select(Function(m) m.Value.Trim(""""c))
        End Function
        Private Function 运行压缩进程(参数 As String) As Boolean
            Try
                Using 进程 As New Process()
                    进程.StartInfo = New ProcessStartInfo With {.FileName = 程序路径, .Arguments = 参数, .UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True, .RedirectStandardError = True}
                    添加日志($"[Info]7z正在启动，启动命令：{程序路径} {参数}", Color.Orange)
                    进程.Start()
                    Dim 完成 = 进程.WaitForExit(600000) ' 10分钟
                    If Not 完成 Then
                        If Not 进程.HasExited Then
                            进程.Kill()
                            添加日志("[ERROR]压缩超时，进程已终止。", Color.Red)
                            Return False
                        End If
                    End If
                    Dim 输出 = 进程.StandardOutput.ReadToEnd()
                    Dim 错误信息 = 进程.StandardError.ReadToEnd()
                    If Not String.IsNullOrEmpty(输出) Then 添加日志($"[Info]7z输出：{输出}", Color.Orange)
                    If Not String.IsNullOrEmpty(错误信息) Then 添加日志($"[ERROR]7z错误：{错误信息}", Color.Red)
                    Return 进程.ExitCode = 0
                End Using
            Catch ex As Exception
                添加日志($"[ERROR]压缩过程中发生错误:{ex}", Color.Red)
                Return False
            End Try
        End Function
        Private Shared Sub 添加日志(信息 As String, 颜色 As Color)
            If 日志窗口.InvokeRequired Then
                日志窗口.Invoke(Sub() 日志窗口.添加日志(信息, 颜色))
            Else
                日志窗口.添加日志(信息, 颜色)
            End If
        End Sub
    End Class
    Public Class 增量备份管理器
        Private 上次备份时间 As DateTime = DateTime.MinValue
        Private Const 时间记录文件 As String = "LastBackup.time"
        Private ReadOnly 压缩器 As New SevenZIP压缩功能

        Public Sub 执行增量备份(输入目录 As String, 输出目录 As String, Optional 压缩包前缀 As String = "增量备份", Optional 排除文件参数 As String = "")
            Dim Time As DateTime = DateTime.Now
            读取上次备份时间(输出目录)
            ' 初始化压缩器
            Dim 输出路径 = Path.Combine(输出目录, $"{压缩包前缀}_{Time:yyyyMMdd-HHmmss}.7z")
            Try
                If 上次备份时间 > DateTime.MinValue Then
                    添加日志("[Info]找到上次备份时间，将执行增量备份", Color.Blue)
                    If 压缩器.执行压缩(增量文件临时存放目录(输入目录, 上次备份时间), 输出路径, 生成排除文件参数(排除文件参数, 输入目录)) Then
                        记录备份时间(输出目录, Time)
                        添加日志($"[Success] 备份完成：{压缩器.输出路径}", Color.Green)
                    Else
                        添加日志("[ERROR] 压缩过程返回错误", Color.Red)
                    End If
                Else
                    添加日志("[Info]未找到上次备份时间，将执行完整备份", Color.Blue)
                    If 压缩器.执行压缩(输入目录, 输出路径, 生成排除文件参数(排除文件参数, 输入目录)) Then
                        记录备份时间(输出目录, Time)
                        添加日志($"[Success] 备份完成：{压缩器.输出路径}", Color.Green)
                    Else
                        添加日志("[ERROR] 压缩过程返回错误", Color.Red)
                    End If
                End If
                Directory.Delete(Path.Combine(备份输出目录, "增量文件"))
                If Directory.Exists(Path.Combine(备份输出目录, "增量文件")) Then
                    添加日志($"[ERROR]临时文件夹删除失败", Color.Red)
                Else
                    添加日志($"[Success]临时文件夹删除成功", Color.Green)
                End If
            Catch ex As Exception
                添加日志($"[ERROR]备份时发生错误：{ex.Message}", Color.Red)
            End Try
        End Sub
        Private Function 生成排除文件参数(排除文件参数 As String, 输入目录 As String) As String
            Dim 参数 As New List(Of String)
            参数.AddRange(SevenZIP压缩功能.解析附加参数(排除文件参数)) ' 解析排除参数
            Return String.Join(" ", 参数)
        End Function
        Private Function 增量文件临时存放目录(源路径 As String, 上次备份时间 As DateTime) As String
            Dim 复制器 As New 文件复制器()
            ' 注册进度事件
            AddHandler 复制器.进度更新,
                Sub(当前进度, 总数量)
                    添加日志($"进度: {当前进度}/{总数量} ({(当前进度 / 总数量):P})", Color.Black)
                End Sub
            Dim 临时路径 = Path.Combine(备份输出目录, "增量文件\")
            Try
                Dim 成功数量 = 复制器.复制修改时间后的文件(源路径, 临时路径, 上次备份时间)
                添加日志($"[Debug]成功复制{成功数量}个文件到临时目录", Color.DarkGreen)
                Return 临时路径
            Catch ex As Exception
                添加日志($"[ERROR]执行复制增量文件时出错：{ex.Message}", Color.Red)
                Return ""
            End Try
        End Function
        Private Shared Sub 记录备份时间(输出目录 As String, 备份时间 As DateTime)
            Dim 时间文件 = Path.Combine(输出目录, 时间记录文件)
            File.WriteAllText(时间文件, 备份时间.ToString("o"))
        End Sub

        Private Sub 读取上次备份时间(输出目录 As String)
            Dim 时间文件 = Path.Combine(输出目录, 时间记录文件)
            If File.Exists(时间文件) Then
                DateTime.TryParse(File.ReadAllText(时间文件), 上次备份时间)
            End If
        End Sub

        Private Shared Sub 添加日志(信息 As String, 颜色 As Color)
            If 日志窗口.InvokeRequired Then
                日志窗口.Invoke(Sub() 日志窗口.添加日志(信息, 颜色))
            Else
                日志窗口.添加日志(信息, 颜色)
            End If
        End Sub
    End Class
    Public Class 完整备份管理器
        Public Sub 执行完整备份(输入目录 As String, 输出目录 As String, Optional 压缩包前缀 As String = "完整备份", Optional 排除文件参数 As String = "")
            ' 初始化压缩器
            Dim 压缩器 As New SevenZIP压缩功能
            Dim 输出路径 = Path.Combine(输出目录, $"{压缩包前缀}_{DateTime.Now:yyyyMMdd-HHmmss}.7z")
            Try
                If 压缩器.执行压缩(输入目录, 输出路径, 生成完整参数(排除文件参数)) Then
                    添加日志($"[Success] 完整备份完成：{压缩器.输出路径}", Color.Green)
                Else
                    添加日志("[ERROR] 压缩过程返回错误", Color.Red)
                End If
            Catch ex As Exception
                添加日志($"[ERROR]备份失败：{ex.Message}", Color.Red)
            End Try
        End Sub
        Private Shared Function 生成完整参数(排除文件参数 As String) As String
            Dim 参数 As New List(Of String)
            ' 解析排除参数确保正确处理空格
            参数.AddRange(SevenZIP压缩功能.解析附加参数(排除文件参数))
            Return String.Join(" ", 参数)
        End Function
        Private Shared Sub 添加日志(信息 As String, 颜色 As Color)
            If 日志窗口.InvokeRequired Then
                日志窗口.Invoke(Sub() 日志窗口.添加日志(信息, 颜色))
            Else
                日志窗口.添加日志(信息, 颜色)
            End If
        End Sub
    End Class
    Public Class 文件复制器
        Public Event 进度更新 As Action(Of Integer, Integer)
        Private Shared Sub 添加日志(信息 As String, 颜色 As Color)
            If 日志窗口.InvokeRequired Then
                日志窗口.Invoke(Sub() 日志窗口.添加日志(信息, 颜色))
            Else
                日志窗口.添加日志(信息, 颜色)
            End If
        End Sub
        ''' <summary>
        ''' 复制指定时间后修改的文件到临时目录并保留相对路径结构
        ''' </summary>
        Public Function 复制修改时间后的文件(源目录 As String, 临时目录 As String, 时间阈值 As DateTime) As Integer
            ' 1. 验证输入路径
            If Not Directory.Exists(源目录) Then 添加日志($"源目录不存在: {源目录}", Color.Red) : Return 0
            Directory.CreateDirectory(临时目录) ' 确保目标目录存在
            ' 2. 规范化路径格式
            Dim 规范化的源路径 = Path.GetFullPath(源目录)
            If Not 规范化的源路径.EndsWith(Path.DirectorySeparatorChar) Then 规范化的源路径 &= Path.DirectorySeparatorChar

            Dim 已复制数量 = 0
            Try
                ' 3. 获取文件列表（使用栈结构分批处理）
                Dim 文件列表 As New List(Of String)
                Dim 目录栈 As New Stack(Of String)
                目录栈.Push(规范化的源路径)

                While 目录栈.Count > 0
                    Dim 当前目录 = 目录栈.Pop()
                    Try
                        ' 添加子目录到栈
                        For Each 子目录 In Directory.GetDirectories(当前目录)
                            目录栈.Push(子目录)
                        Next

                        ' 处理当前目录文件
                        For Each 文件 In Directory.GetFiles(当前目录)
                            If File.GetLastWriteTimeUtc(文件) > 时间阈值.ToUniversalTime() Then
                                文件列表.Add(文件)
                            End If
                        Next
                    Catch ex As UnauthorizedAccessException
                        添加日志($"[Warning]跳过无权限目录: {当前目录}", Color.DarkOrange)
                    End Try
                End While

                ' 4. 执行复制操作
                For i = 0 To 文件列表.Count - 1
                    Dim 源文件路径 = 文件列表(i)
                    Try
                        ' 计算相对路径（兼容旧框架）
                        Dim 相对路径 = 源文件路径.Substring(规范化的源路径.Length)
                        Dim 目标文件路径 = Path.Combine(临时目录, 相对路径)

                        ' 创建目标目录结构
                        Dim 目标目录路径 = Path.GetDirectoryName(目标文件路径)
                        Directory.CreateDirectory(目标目录路径)

                        ' 执行文件复制（带重试机制）
                        Try
                            File.Copy(源文件路径, 目标文件路径, True)
                            已复制数量 += 1
                        Catch ex As IOException When ex.HResult = -2147024864
                            Thread.Sleep(500)  ' 等待500毫秒后重试
                            File.Copy(源文件路径, 目标文件路径, True)
                            已复制数量 += 1
                        End Try
                    Catch ex As Exception
                        添加日志($"[Warning]文件复制失败 [{Path.GetFileName(源文件路径)}]: {ex.Message}", Color.DarkOrange)
                    End Try

                    ' 触发进度更新事件
                    RaiseEvent 进度更新(i + 1, 文件列表.Count)
                Next
            Catch ex As Exception
                添加日志($"[ERROR]操作异常中止: {ex.Message}", Color.Red)
                Throw
            End Try
            Return 已复制数量
        End Function

        ''' <summary>
        ''' 使用示例
        ''' </summary>
        Public Shared Sub 测试用例()
            Dim 复制器 As New 文件复制器()

            ' 注册进度事件
            AddHandler 复制器.进度更新,
                Sub(当前进度, 总数量)
                    Console.WriteLine($"进度: {当前进度}/{总数量} ({(当前进度 / 总数量):P})")
                End Sub
            Dim 源路径 = "C:\测试数据"
            Dim 临时路径 = Path.GetTempPath() & "备份缓存\"
            Dim 最后备份时间 = DateTime.Now.AddHours(-1) ' 假设1小时前做过备份
            Try
                Dim 成功数量 = 复制器.复制修改时间后的文件(源路径, 临时路径, 最后备份时间)
                Console.WriteLine($"✅ 成功复制 {成功数量} 个文件到临时目录")
            Catch ex As Exception
                Console.WriteLine($"💥 操作失败: {ex.Message}")
            End Try
        End Sub
    End Class
End Module