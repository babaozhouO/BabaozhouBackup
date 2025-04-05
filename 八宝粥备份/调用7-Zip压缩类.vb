' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
Imports System.IO
Imports System.Diagnostics
Imports System.Text
Public Class 七Zip压缩
    ''' 执行7-Zip压缩操作
    Public Shared Function 执行压缩(ByVal 参数 As String, ByVal 输入路径 As String, ByVal 输出路径 As String) As Boolean
        Dim 七z路径 As String = Path.Combine(Application.StartupPath, "资源", "7z.exe")
        ' 路径验证
        If Not File.Exists(七z路径) Then
            Throw New FileNotFoundException("7z.exe未找到", 七z路径)
        End If
        If Not Directory.Exists(Path.GetDirectoryName(输出路径)) Then
            Directory.CreateDirectory(Path.GetDirectoryName(输出路径))
        End If
        ' 构建完整命令行
        Dim 压缩命令 As String = $"a -t7z {参数} ""{输出路径}"" ""{输入路径}"""
        Try
            Using 进程 As New Process()
                With 进程.StartInfo
                    .FileName = 七z路径
                    .Arguments = 压缩命令
                    .UseShellExecute = False
                    .CreateNoWindow = True
                    .RedirectStandardOutput = True
                    .RedirectStandardError = True
                End With

                进程.Start()
                进程.WaitForExit(600000) ' 等待最多10分钟
                ' 检查退出代码 (0表示成功)
                Return 进程.ExitCode = 0
            End Using
        Catch ex As Exception
            Console.WriteLine($"压缩失败：{ex.Message}")
            Return False
        End Try
    End Function
    '压缩参数生成器
    Public Class 压缩参数生成器
        Public Function 生成参数() As String
            Dim 参数 As New StringBuilder()
            ' 基本参数
            参数.Append($"-t{压缩格式} ")
            ' 压缩级别
            参数.Append($"-mx={压缩级别} ")
            ' 压缩算法设置
            参数.Append($"-m0={压缩算法} ")
            参数.Append($"-md={字典大小} ")
            参数.Append($"-ms={固实模式} ")
            If 固实模式 Then 参数.Append("-ms=on ")
            ' 多线程
            If 多线程 Then 参数.Append("-mmt=on ")
            ' 密码保护
            If Not String.IsNullOrEmpty(压缩密码) Then
                参数.Append($"-p{压缩密码} ")
                If 加密文件名 Then 参数.Append("-mhe=on ")
            End If
            ' 分卷压缩
            If Not String.IsNullOrEmpty(分卷大小) Then
                参数.Append($"-v{分卷大小} ")
            End If
            ' 排除文件
            For Each 文件掩码 In 排除文件
                参数.Append($"-x!{文件掩码} ")
            Next
            ' 覆盖模式
            参数.Append($"-ao={覆盖模式} ")
            ' 高级设置
            If 压缩算法 = "LZMA" OrElse 压缩算法 = "LZMA2" Then
                参数.Append($"-mfb={快速字节数} ")
            End If
            If 快速排序模式 Then 参数.Append("-mqs=on ")
            If 保留创建时间 Then 参数.Append("-mtc=on ")
            Return 参数.ToString().Trim()
        End Function
    End Class
End Class
