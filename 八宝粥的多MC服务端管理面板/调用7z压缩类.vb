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
Imports System.Text.RegularExpressions
Imports System.Threading
'操作模式
'a: 添加文件到压缩包
'b: 性能测试
'd: 从压缩包中删除文件
'e: 解压文件（不保留目录结构）
'h: 计算文件哈希值
'i: 显示支持格式信息
'l: 列出压缩包内容
'rn: 重命名压缩包内文件
't: 测试压缩包完整性
'u: 更新文件到压缩包
'x: 完整路径解压文件
'<开关>
'  -- : 停止解析开关和@列表文件
'  -ai[r[-|0]][m[-|2]][w[-]]{@列表文件|!通配符} : 包含其他压缩包
'  -ax[r[-|0]][m[-|2]][w[-]]{@列表文件|!通配符} : 排除其他压缩包
'  -ao{a|s|t|u} : 设置覆盖模式（覆盖 / 跳过 / 重命名 / 更新）
'  -an : 禁用压缩包名称字段
'  -bb[0-3] : 设置日志输出级别
'  -bd : 禁用进度指示器
'  -bs{o|e|p}{0|1|2} : 设置输出流（标准输出 / 错误 / 进度）
'  -bt : 显示执行时间统计
'  -i[r[-|0]][m[-|2]][w[-]]{@列表文件|!通配符} : 包含文件
'  -m{参数} : 设置压缩方法
'    -mmt[N] : 设置CPU线程数
'    -mx[N] : 设置压缩级别 ： -mx1（最快）... -mx9（最强）
'  -o{目录} : 设置输出目录
'  -p{密码} : 设置密码
'  -r[-|0] : 递归子目录搜索
'  -sa{a|e|s} : 设置压缩包命名模式
'  -scc{UTF-8|WIN|DOS} : 设置控制台输入/ 输出字符集
'  -scs{UTF-8|UTF-16LE|UTF-16BE|WIN|DOS|{id}} : 设置列表文件字符集
'  -scrc[CRC32|CRC64|SHA256|SHA1|XXH64|*] : 设置哈希算法（用于x / e / h命令）
'  -sdel : 压缩后删除源文件
'  -seml[.] : 通过邮件发送压缩包
'  -sfx[{名称}] : 创建自解压包
'  -si[{名称}] : 从标准输入读取数据
'  -slp : 启用大内存页模式
'  -slt : 显示技术信息（配合l命令）
'  -snh : 保留硬链接
'  -snl : 保留符号链接
'  -sni : 保留NT安全信息
'  -sns[-] : 保留NTFS备用数据流
'  -so : 输出到标准输出
'  -spd : 禁用文件名通配符匹配
'  -spe : 解压时消除根目录重复
'  -spf[2] : 使用完整文件路径
'  -ssc[-] : 启用大小写敏感模式
'  -sse : 无法打开文件时停止创建压缩包
'  -ssp : 不更改源文件最后访问时间
'  -ssw : 压缩已打开的文件
'  -stl : 使用最新修改时间设置压缩包时间戳
'  -stm{十六进制掩码} : 设置CPU线程亲和掩码
'  -stx{类型} : 排除指定类型压缩包
'  -t{类型} : 设置压缩包类型
'  -u[-][p#][q#][r#][x#][y#][z#][!新压缩包名] : 更新选项
'  -v{大小}[b|k|m|g] : 分卷压缩
'  -w[{路径}] : 设置工作目录（空路径表示临时目录）
'  -x[r[-|0]][m[-|2]][w[-]]{@列表文件|!通配符} : 排除文件
'  -y : 对所有询问自动回答"是"


Public Module SevenZip
    Public Class SevenZIP
        Private ReadOnly 程序路径 As String = Path.Combine(程序数据目录, "资源", "7z.exe")
        ' 执行压缩操作
        Public Function 调用7Zip(操作模式 As String, 附加参数 As String, 输出路径 As String, 输入目录 As String, Optional 要备份的MC服务端序号 As Integer = -1) As Integer
            添加日志($"[Info]正在检查输出输入路径", Color.Black)
            If String.IsNullOrWhiteSpace(输入目录) Then 添加日志("[ERROR]输入目录为空", Color.Red) : Return False
            If String.IsNullOrWhiteSpace(输出路径) Then 添加日志("[ERROR]输出路径为空", Color.Red) : Return False
            If Not Directory.Exists(输入目录) Then 添加日志($"[ERROR]输入目录不存在：{输入目录}", Color.Red) : Return False
            If Not File.Exists(程序路径) Then 添加日志($"[ERROR]7z程序不存在：{程序路径}", Color.Red) : Return False
            添加日志($"[Success]输出输入路径有效", Color.DarkGreen)
            Dim O As String = If(是否增量备份, "增量备份", "完整备份")
            MainForm.执行中的分任务.Text = $"执行MC服务端{要备份的MC服务端序号}{O}操作"
            MainForm.分任务进度条.Value = 10
            If 要备份的MC服务端序号 = -1 Then
                If 是否增量备份 Then
                    添加日志($"[Info]开始执行自定义文件夹增量备份操作", Color.Orange)
                Else
                    添加日志($"[Info]开始执行自定义文件夹完整备份操作", Color.Orange)
                End If
            Else
                If 是否增量备份 Then
                    添加日志($"[Info]开始执行MC服务端{要备份的MC服务端序号}增量备份操作", Color.Orange)
                Else
                    添加日志($"[Info]开始执行MC服务端{要备份的MC服务端序号}完整备份操作", Color.Orange)
                End If
            End If
            Dim 参数 = 生成压缩参数(操作模式, 附加参数, 输出路径, 输入目录)
            MainForm.分任务进度条.Value = 15
            If String.IsNullOrEmpty(参数) Then
                添加日志($"[Warning]用户取消了操作", Color.Black)
                MainForm.执行中的分任务.Text = $"无"
                MainForm.分任务进度条.Value = 0
                Return False
            End If
            Return 运行压缩进程(参数)
        End Function
        Private Shared Function 生成压缩参数(操作模式 As String, 附加参数 As String, 输出路径 As String, 输入目录 As String) As String
            添加日志($"[Info]生成完整压缩参数中", Color.Black)
            Dim 转义输出路径 = """" & 输出路径.Replace("""", "\""") & """"
            Dim 转义输入目录 = """" & 输入目录.Replace("""", "\""") & """"
            Dim 完整参数集合 As New List(Of String) From {操作模式}
            If Not String.IsNullOrWhiteSpace(附加参数) Then
                添加日志($"[Info]正在解析附加参数：{附加参数}", Color.Black)
                ' 使用正则表达式匹配带引号的参数或不带引号的参数
                Dim 附加参数集合 = Regex.Matches(附加参数, "(?:\s*("".*?""|\S+))")
                Dim f = 附加参数集合.Cast(Of Match)().Select(Function(m) m.Groups(1).Value.Trim()).ToList
                完整参数集合.AddRange(f)
            Else
                添加日志($"[Warning]无附加参数", Color.Black)
                Dim 用户选择 As DialogResult = MessageBox.Show("附加参数为空,是否确认执行操作", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If 用户选择 = DialogResult.No Then Return ""
            End If
            完整参数集合.Add(转义输出路径)
            完整参数集合.Add(转义输入目录)
            Dim 完整参数 As String = String.Join(" ", 完整参数集合)
            添加日志("[Success]完整压缩参数生成完成", Color.DarkGreen)
            添加日志($"[Debug]完整参数：{完整参数}", Color.Gray)
            Return 完整参数
        End Function
        Private WithEvents KillCountDownTimer As New Timers.Timer With {.AutoReset = False, .Interval = 超时时长 * 1000}
        Private ReadOnly 进程 As New Process
        Private 进程是否被杀死 As Boolean = False
        Private Sub Kill() Handles KillCountDownTimer.Elapsed
            uiContext.Post(Sub()
                               If Not 进程.HasExited Then
                                   进程.Kill()
                                   进程是否被杀死 = True
                                   添加日志("[ERROR]压缩超时终止", Color.Red)
                               End If
                               KillCountDownTimer.Dispose()
                           End Sub, Nothing)
        End Sub
        'Private WithEvents 模拟压缩耗时 As New Timers.Timer With {.AutoReset = True, .Interval = 1000}
        'Private Sub Tick() Handles 模拟压缩耗时.Elapsed
        '    uiContext.Post(Sub()
        '                       MainForm.分任务进度条.Value += If(MainForm.分任务进度条.Value < 93, 1, 0)
        '                   End Sub, Nothing)
        'End Sub
        Public Function 运行压缩进程(参数 As String) As Integer
            Try
                If 是否循环更新界面 Then
                    '' 异步读取绑定
                    AddHandler 进程.OutputDataReceived,
                    Sub(sender, 收到的输出)
                        If Not String.IsNullOrEmpty(收到的输出.Data) Then
                            解析输出数据(收到的输出.Data)
                        End If
                    End Sub
                    AddHandler 进程.ErrorDataReceived,
                    Sub(sender, 收到的输出)
                        If Not String.IsNullOrEmpty(收到的输出.Data) Then
                            解析输出数据(收到的输出.Data)
                        End If
                    End Sub
                End If
                进程.StartInfo = New ProcessStartInfo With {
                    .FileName = 程序路径,
                    .Arguments = 参数,
                    .UseShellExecute = False,
                    .CreateNoWindow = True,
                    .RedirectStandardOutput = True,
                    .RedirectStandardError = True}
                添加日志($"[Info]7z正在启动，启动命令：{程序路径} {参数}", Color.Orange)
                If 进程.Start() Then
                    MainForm.分任务进度条.Value = 50
                    If 是否循环更新界面 Then
                        KillCountDownTimer.Enabled = True
                        添加日志($"[Info]7z已启动,请耐心等待压缩完成(超时时长:{超时时长}秒)", Color.Orange)
                        进程.BeginOutputReadLine()
                        进程.BeginErrorReadLine()
                        Dim C As Integer = 超时时长 * 帧数
                        Dim S As Double = 40 / C
                        Dim i As Integer = 0
                        While Not 进程.HasExited
                            i += 1
                            MainForm.分任务进度条.Value = If(50 + CInt(S * i) <= 90, 50 + CInt(S * i), 90)
                            Application.DoEvents() ' 允许 UI 响应操作
                            Thread.Sleep(延时毫秒数) ' 降低 CPU 占用
                        End While
                    Else
                        If Not 进程.WaitForExit(超时时长 * 1000) Then
                            进程.Kill()
                            MainForm.分任务进度条.Value = 90
                            进程是否被杀死 = True
                        End If
                        Dim 输出 = 进程.StandardOutput.ReadToEnd()
                        Dim 错误信息 = 进程.StandardError.ReadToEnd()
                        If Not String.IsNullOrEmpty(输出) Then 添加日志($"[Info]7z输出：{输出}", Color.Orange)
                        If Not String.IsNullOrEmpty(错误信息) Then 添加日志($"[ERROR]7z错误：{错误信息}", Color.Red)
                    End If
                    MainForm.分任务进度条.Value = 100
                Else
                    添加日志($"[ERROR]7z启动失败", Color.Red)
                    Return 2
                End If
                If 进程是否被杀死 Then
                    Return 2
                Else
                    Select Case 进程.ExitCode
                        Case 0
                            Return 0
                        Case Else
                            If 进程.ExitCode = 1 Then
                                If 进程是否被杀死 Then
                                    添加日志("[Warning]压缩过程中7z进程被杀死", Color.Orange)
                                Else
                                    添加日志("[Warning]压缩过程中发生非致命错误", Color.Orange)
                                End If
                            ElseIf 进程.ExitCode = 2 Then
                                If 进程是否被杀死 Then
                                    添加日志("[Warning]压缩过程中7z进程被杀死", Color.Orange)
                                End If
                                添加日志("[ERROR]压缩过程中发生致命错误", Color.Red)
                            End If
                            Return 进程.ExitCode
                    End Select
                End If
            Catch ex As Exception
                添加日志($"[ERROR]压缩过程中发生错误:{ex.Message}", Color.Red)
            End Try
            Return 2
        End Function
        Private ReadOnly uiContext As SynchronizationContext = SynchronizationContext.Current
        Private Sub 解析输出数据(原始数据 As String)
            Dim 当前进度 As Integer = -1
            Dim 当前文件 As String = ""
            Dim 压缩速度 As String = ""
            ' 进度百分比
            Dim 进度匹配 = Regex.Match(原始数据, "\s+(\d+)%")
            If 进度匹配.Success Then
                Dim 新进度 = Integer.Parse(进度匹配.Groups(1).Value)
                If 新进度 <> 当前进度 Then
                    当前进度 = 新进度
                End If
            End If
            ' 当前文件
            If 原始数据.Trim().StartsWith("Compressing") Then
                当前文件 = 原始数据.Replace("Compressing", "").Trim()
            End If
            ' 压缩速度
            Dim 速度匹配 = Regex.Match(原始数据, "(\d+\.?\d* [KM]?B/s)")
            If 速度匹配.Success Then
                压缩速度 = 速度匹配.Value
            End If
            ' 将解析结果打包到匿名对象
            Dim 数据包 As New With {原始数据, .进度 = 当前进度, .文件 = 当前文件, .速度 = 压缩速度}
            ' 通过UI线程上下文提交更新
            uiContext.Post(Sub(state)
                               Dim packet = DirectCast(state, Object)
                               UI更新(packet.原始数据, packet.进度, packet.文件, packet.速度)
                           End Sub, 数据包)
        End Sub
        Private Shared Sub UI更新(原始数据 As String, Optional 当前进度 As Integer = -1, Optional 压缩中文件 As String = "", Optional 压缩速度 As String = "")
            添加日志($"[原始输出]:{原始数据}", Color.Gray)
            MainForm.分任务进度条.Value = 100
            If Not 当前进度 = -1 Then
                添加日志($"[Progress]当前进度：{当前进度}%", Color.Green)
                MainForm.更新压缩进度(当前进度)
            End If
            If Not String.IsNullOrEmpty(压缩中文件) Then
                添加日志($"[File]正在处理：{压缩中文件}", Color.DarkBlue)
                MainForm.执行中的分任务.Text = $"正在压缩:{压缩中文件}"
            End If
            If Not String.IsNullOrEmpty(压缩速度) Then
                添加日志($"[Speed]当前速度：{压缩速度}", Color.DarkCyan)
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
    Public Class 增量备份管理器
        Private 上次备份时间 As DateTime = DateTime.MinValue
        Private 附加参数 As String
        Private Const 时间记录文件 As String = "LastBackup.time"
        Private ReadOnly 压缩器 As New SevenZIP
        Public Sub 执行增量备份(输入目录 As String, 输出目录 As String, Optional 压缩文件说明 As String = "某文件", Optional 排除文件参数 As String = "", Optional MC服务端序号 As Integer = -1)
            Dim 备份时间 As DateTime = DateTime.Now
            Dim 时间文件 = Path.Combine(输出目录, 时间记录文件)
            ' 读取上次备份时间
            If File.Exists(时间文件) Then
                Dim t As String = File.ReadAllText(时间文件)
                If Not DateTime.TryParse(t, 上次备份时间) Then
                    添加日志("[ERROR]含日期时间数据的字符串转换为日期时间数据类型数据时出错,你是不是对时间记录文件下毒手了！", Color.Red)
                End If
            End If
            ' 初始化压缩器
            Dim 临时目录 As String = Path.Combine(备份输出目录, "增量文件")
            Dim 输出路径 = Path.Combine(输出目录, $"{压缩文件说明}的增量备份_{备份时间:yyyyMMdd-HHmmss}.7z")
            Try
                If 上次备份时间 > DateTime.MinValue Then
                    添加日志("[Info]找到上次备份时间，将执行增量备份", Color.Blue)
                    Dim 增量文件临时存放目录 = 复制增量文件到临时存放目录并输出目录(输入目录, 上次备份时间)
                    MainForm.分任务进度条.Value = 40
                    If 压缩级别 = 0 Then
                        If 压缩方法 = "GNU" Or 压缩方法 = "POSIX" Then 'tar
                            附加参数 = $" -r -aoa -sdel -t{压缩格式} -mx0 -mo={压缩方法} -xr!""cache\*"" -xr!""tmp\*"" -x!""Thumbs.db"" -xr!""$RECYCLE.BIN\*"" {排除文件参数}"
                        ElseIf 压缩方法 = "" Then 'wim
                            附加参数 = $" -r -aoa -sdel -twim -xr!""cache\*"" -xr!""tmp\*"" -x!""Thumbs.db"" -xr!""$RECYCLE.BIN\*"" {排除文件参数}"
                        Else
                            附加参数 = $" -r -aoa -sdel -t{压缩格式} -mx{压缩级别} -xr!""cache\*"" -xr!""tmp\*"" -x!""Thumbs.db"" -xr!""$RECYCLE.BIN\*"" {排除文件参数}"
                        End If
                    Else
                        附加参数 = $" -r -aoa -sdel -t{压缩格式} -mx{压缩级别} -m0={压缩方法}:d={字典大小.TrimEnd("B"c)}:fb={单词大小} -ms -mmt{线程数} -xr!""cache\*"" -xr!""tmp\*"" -x!""Thumbs.db"" -xr!""$RECYCLE.BIN\*"" {排除文件参数}"
                    End If
                    If String.IsNullOrEmpty(增量文件临时存放目录) Then
                        添加日志($"[ERROR]复制增量文件到临时存放目录失败或无更新文件,已终止操作", Color.Red)
                        Return
                    End If
                    Dim R As Integer = 压缩器.调用7Zip("a", 附加参数, 输出路径, 增量文件临时存放目录, MC服务端序号)
                    If R = 0 Or R = 1 Then
                        File.WriteAllText(时间文件, 备份时间.ToString("o"))
                        添加日志($"[Success]备份完成：{输出路径}", Color.Green)
                    Else
                        添加日志("[ERROR]压缩过程返回错误", Color.Red)
                        If File.Exists(输出路径) Then
                            File.Delete(输出路径)
                            If File.Exists(输出路径) Then 添加日志($"[Info]出错的压缩文件删除成功", Color.Green)
                        End If
                    End If
                    If Directory.Exists(临时目录) Then
                        Directory.Delete(临时目录)
                        If Directory.Exists(临时目录) Then
                            添加日志($"[ERROR]临时文件夹删除失败", Color.Red)
                            添加日志($"[ERROR]请手动删除{临时目录}", Color.Red)
                        Else
                            添加日志($"[Success]临时文件夹删除成功", Color.Green)
                        End If
                    Else
                        添加日志($"[Success]临时文件夹删除成功", Color.Green)
                    End If
                Else
                    添加日志("[Info]未找到上次备份时间，将执行完整备份", Color.Blue)
                    MainForm.分任务进度条.Value = 40
                    If 压缩级别 = 0 Then
                        If 压缩方法 = "GNU" Or 压缩方法 = "POSIX" Then 'tar
                            附加参数 = $" -r -aoa -t{压缩格式} -mx0 -mo={压缩方法} -xr!""cache\*"" -xr!""tmp\*"" -x!""Thumbs.db"" -xr!""$RECYCLE.BIN\*"" {排除文件参数}"
                        ElseIf 压缩方法 = "" Then 'wim
                            附加参数 = $" -r -aoa -twim -xr!""cache\*"" -xr!""tmp\*"" -x!""Thumbs.db"" -xr!""$RECYCLE.BIN\*"" {排除文件参数}"
                        Else
                            附加参数 = $" -r -aoa -t{压缩格式} -mx{压缩级别} -xr!""cache\*"" -xr!""tmp\*"" -x!""Thumbs.db"" -xr!""$RECYCLE.BIN\*"" {排除文件参数}"
                        End If
                    Else
                        附加参数 = $" -r -aoa -t{压缩格式} -mx{压缩级别} -m0={压缩方法}:d={字典大小.TrimEnd("B"c)}:fb={单词大小} -ms -mmt{线程数} -xr!""cache\*"" -xr!""tmp\*"" -x!""Thumbs.db"" -xr!""$RECYCLE.BIN\*"" {排除文件参数}"
                    End If
                    Dim R As Integer = 压缩器.调用7Zip("a", 附加参数, 输出路径, 输入目录, MC服务端序号)
                    If R = 0 Or R = 1 Then
                        File.WriteAllText(时间文件, 备份时间.ToString("o"))
                        添加日志($"[Success]备份完成：{输出路径}", Color.Green)
                    Else
                        添加日志("[ERROR]压缩过程返回错误", Color.Red)
                        If File.Exists(输出路径) Then
                            File.Delete(输出路径)
                            If File.Exists(输出路径) Then 添加日志($"[Info]出错的压缩文件删除成功", Color.Green)
                        End If
                    End If
                End If
            Catch ex As Exception
                添加日志($"[ERROR]备份时发生错误：{ex.Message}", Color.Red)
            End Try
        End Sub
        Private Shared Function 复制增量文件到临时存放目录并输出目录(源路径 As String, 上次备份时间 As DateTime) As String
            Dim 原主任务 As String = MainForm.执行中的主任务.Text
            Dim 原主进度 As Integer = MainForm.主任务进度条.Value
            Dim 原分任务 As String = MainForm.执行中的分任务.Text
            Dim 原分进度 As Integer = MainForm.分任务进度条.Value
            MainForm.执行中的主任务.Text = 原分任务
            MainForm.主任务进度条.Value = 原分进度
            MainForm.执行中的分任务.Text = "复制增量文件到临时存放目录"
            Dim 复制器 As New 文件复制器()
            Dim k As Double
            Dim y As Integer
            ' 注册进度事件
            AddHandler 复制器.进度更新,
                Sub(当前进度, 总数量)
                    k = 总数量 / 100
                    y = If(CInt（当前进度 / k） <= 100, CInt(当前进度 / k）, 100)
                    MainForm.分任务进度条.Value = y
                    添加日志($"进度: {当前进度}/{总数量} ({(当前进度 / 总数量):P})", Color.Black)
                End Sub
            Dim 临时路径 = Path.Combine(备份输出目录, "增量文件")
            Try
                Dim 成功数量 = 复制器.复制修改时间后的文件(源路径, 临时路径, 上次备份时间)
                添加日志($"[Debug]成功复制{成功数量}个文件到临时目录", Color.DarkGreen)
                If 成功数量 = 0 Then Return ""
                Return 临时路径
            Catch ex As Exception
                添加日志($"[ERROR]执行复制增量文件时出错：{ex.Message}", Color.Red)
                Return ""
            Finally
                MainForm.执行中的主任务.Text = 原主任务
                MainForm.主任务进度条.Value = 原主进度
                MainForm.执行中的分任务.Text = 原分任务
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
    Public Class 完整备份管理器
        Private Const 时间记录文件 As String = "LastBackup.time"
        Public Sub 执行完整备份(输入目录 As String, 输出目录 As String, Optional 压缩文件说明 As String = "某文件", Optional 排除文件参数 As String = "", Optional MC服务端序号 As Integer = -1)
            Dim 备份时间 As DateTime = DateTime.Now
            Dim 时间文件 = Path.Combine(输出目录, 时间记录文件)
            ' 初始化压缩器
            Dim 压缩器 As New SevenZIP
            Dim 输出路径 = Path.Combine(输出目录, $"{压缩文件说明}的完整备份_{DateTime.Now:yyyyMMdd-HHmmss}.7z")
            Dim 附加参数 As String
            If 压缩级别 = 0 Then
                If 压缩方法 = "GNU" Or 压缩方法 = "POSIX" Then 'tar
                    附加参数 = $" -r -aoa -t{压缩格式} -mx0 -mo={压缩方法} -xr!""cache\*"" -xr!""tmp\*"" -x!""Thumbs.db"" -xr!""$RECYCLE.BIN\*"" {排除文件参数}"
                ElseIf 压缩方法 = "" Then 'wim
                    附加参数 = $" -r -aoa -twim -xr!""cache\*"" -xr!""tmp\*"" -x!""Thumbs.db"" -xr!""$RECYCLE.BIN\*"" {排除文件参数}"
                Else
                    附加参数 = $" -r -aoa -t{压缩格式} -mx{压缩级别} -xr!""cache\*"" -xr!""tmp\*"" -x!""Thumbs.db"" -xr!""$RECYCLE.BIN\*"" {排除文件参数}"
                End If
            Else
                附加参数 = $" -r -aoa -t{压缩格式} -mx{压缩级别} -m0={压缩方法}:d={字典大小.TrimEnd("B"c)}:fb={单词大小} -ms -mmt{线程数} -xr!""cache\*"" -xr!""tmp\*"" -x!""Thumbs.db"" -xr!""$RECYCLE.BIN\*"" {排除文件参数}"
            End If
            MainForm.分任务进度条.Value = 40
            Try
                Dim R As Integer = 压缩器.调用7Zip("a", 附加参数, 输出路径, 输入目录, MC服务端序号)
                If R = 0 Or R = 1 Then
                    添加日志($"[Success] 完整备份完成：{输出路径}", Color.Green)
                    File.WriteAllText(时间文件, 备份时间.ToString("o"))
                Else
                    添加日志("[ERROR] 压缩过程返回错误", Color.Red)
                    If File.Exists(输出路径) Then
                        File.Delete(输出路径)
                        If File.Exists(输出路径) Then
                            添加日志($"[Info]出错的压缩文件删除成功", Color.Green)
                        Else
                            添加日志($"[Waring]出错的压缩文件删除失败:{输出路径}", Color.Green)
                        End If
                    Else
                        添加日志($"[Info]出错的压缩文件删除成功", Color.Green)
                    End If
                End If
            Catch ex As Exception
                添加日志($"[ERROR]备份中发生异常：{ex.Message}", Color.Red)
            End Try
        End Sub
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
        Private Shared Sub 使用示例(源路径 As String, 最后备份时间 As Date, Optional 临时路径 As String = "")
            Dim 复制器 As New 文件复制器()
            ' 注册进度事件
            AddHandler 复制器.进度更新,
                Sub(当前进度, 总数量)
                    Console.WriteLine($"进度: {当前进度}/{总数量} ({(当前进度 / 总数量):P})")
                End Sub
            If String.IsNullOrEmpty(临时路径) Then
                临时路径 = Path.Combine(Path.GetTempPath(), "备份缓存\")
            End If
            Try
                Dim 成功数量 = 复制器.复制修改时间后的文件(源路径, 临时路径, 最后备份时间)
                Console.WriteLine($"✅ 成功复制 {成功数量} 个文件到临时目录")
            Catch ex As Exception
                Console.WriteLine($"💥 操作失败: {ex.Message}")
            End Try
        End Sub
    End Class
End Module