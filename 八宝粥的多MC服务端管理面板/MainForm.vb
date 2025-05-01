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
Public Class MainForm
    Private ReadOnly 图片目录 As String = Path.Combine(程序数据目录, "背景图片")
    Private ReadOnly 支持的文件格式 As String() = {".jpg", ".png", ".bmp"}
    Private 图片列表 As New List(Of String)()
    Private 图片序号 As Integer = 0
    Private 下一次切换的时间点 As DateTime ' 下一次切换的时间点
    Private 服务 As 间隔任务执行器
    Private Sub 主窗口_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        日志窗口.Show()
        '-------------------------------------初始化控件关系-------------------------------------
        日志窗口.Owner = Me
        SevenZipSettingsForm.Owner = Me
        MainSettingsForm.Owner = Me
        MCServerSettingsForm.Owner = Me
        ServiceSettingsForm.Owner = Me
        SftpSettingsForm.Owner = Me
        UselessToolsForm.Owner = Me
        IntroductionLabel.Parent = PictureBox
        LogsLabel.Parent = PictureBox
        倒计时数字显示.Parent = PictureBox
        Label1.Parent = PictureBox
        Label2.Parent = PictureBox
        执行中的主任务.Parent = PictureBox
        执行中的分任务.Parent = PictureBox
        '--------------------------------初始化背景图片--------------------------------
        加载图片列表()
        If 图片列表.Count > 0 Then
            加载图片(图片列表(图片序号))
            下一次切换的时间点 = DateTime.Now.AddMinutes(1)
            更新图片切换倒计时显示()
        Else
            添加日志("[Warning]未找到图片文件！", Color.Orange)
        End If
        Application.DoEvents()
        AddHandler Me.FormClosing, AddressOf 窗体关闭确认
    End Sub
    Private Sub 主窗口_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        日志窗口.更新停靠位置(Me)
        日志窗口.日志输出软件信息()
        日志窗口.日志输出主程序配置()
        日志窗口.日志输出MC服务端配置()
        日志窗口.日志输出SFTP配置()
        日志窗口.日志输出7zip配置()
        添加日志("-------------------------------------------------------------------------------------", Color.Black)
        MessageBox.Show("因为异步执行需要重构各种功能模块，所以暂且搁置，现在暂时使用CPU占用较高的循环更新UI方法维持(默认)25帧(可自由设置帧数)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub MainForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        日志窗口.更新停靠位置(Me) ' 更新日志窗口位置
    End Sub
    Private Sub MainForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        NowTimer.Stop() ' 窗体关闭时释放资源
        ChanegeImageTimer.Stop()
        PictureBox.Image?.Dispose()
        If 服务 IsNot Nothing Then 服务.停止任务()
    End Sub
    Private Sub 窗体关闭确认(sender As Object, e As FormClosingEventArgs)
        ' 判断关闭原因是否是用户操作（点击关闭按钮/Alt+F4）
        If e.CloseReason = CloseReason.UserClosing Then
            ' 创建确认对话框
            Dim 结果 As DialogResult = MessageBox.Show(
                "确定退出？",
                "你真的要关闭八宝粥备份吗",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
            ' 如果选择否，取消关闭操作
            If 结果 = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
    '--------------------------------------------左一列按钮事件------------------------------
    Private Sub ServiceButton_Click(sender As Object, e As EventArgs) Handles ServiceButton.Click
        添加日志("[Action]打开安装/卸载系统服务窗口", Color.Black)
        ServiceSettingsForm.Show()
        日志窗口.更新停靠位置(ServiceSettingsForm)
    End Sub
    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        添加日志("[Action]打开主程序配置界面", Color.Black)
        MainSettingsForm.Show()
        日志窗口.更新停靠位置(MainSettingsForm)
    End Sub
    Private Sub Button7z_Click(sender As Object, e As EventArgs) Handles Button7z.Click
        添加日志("[Action]打开7z压缩程序配置界面", Color.Black)
        SevenZipSettingsForm.Show()
        日志窗口.更新停靠位置(SevenZipSettingsForm)
    End Sub
    Private Sub SftpButton_Click(sender As Object, e As EventArgs) Handles SftpButton.Click
        添加日志("[Action]打开内置sftp客户端配置界面", Color.Black)
        SftpSettingsForm.Show()
        日志窗口.更新停靠位置(SftpSettingsForm)
    End Sub
    Private Sub ButtonMC_Click(sender As Object, e As EventArgs) Handles ButtonMC.Click
        添加日志("[Action]打开MC服务器配置界面", Color.Black)
        MCServerSettingsForm.Show()
        日志窗口.更新停靠位置(MCServerSettingsForm)
    End Sub
    Private Sub ToolsButton_Click(sender As Object, e As EventArgs) Handles ToolsButton.Click
        添加日志("[Action]打开没用的小工具界面", Color.Black)
        UselessToolsForm.Show()
        日志窗口.更新停靠位置(UselessToolsForm)
    End Sub
    Private Sub ButtonSightseeing_Click(sender As Object, e As EventArgs) Handles ButtonSightseeing.Click
        日志窗口隐藏状态 = True
        Me.IntroductionLabel.Visible = False
        日志窗口.Visible = False
        Me.ExitButton.Visible = False
        Me.ClearlogButton.Visible = False
        Me.ServiceButton.Visible = False
        Me.SettingsButton.Visible = False
        Me.Button7z.Visible = False
        Me.SftpButton.Visible = False
        Me.TestsftpButton.Visible = False
        Me.TestRCONButton.Visible = False
        Me.RunButton.Visible = False
        Me.ButtonSightseeing.Visible = False
        Me.ServiceButton.Visible = False
        Me.ToolsButton.Visible = False
        Me.StopButton.Visible = False
        Me.LogsLabel.Visible = False
        Me.ButtonMC.Visible = False
        Me.ReturnButton.Visible = True
        Me.RunImmediately.Visible = False
        Me.LogsFolder.Visible = False
        Me.ConfigFolder.Visible = False
        Me.PicturesFolder.Visible = False
    End Sub
    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        日志窗口隐藏状态 = False
        Me.IntroductionLabel.Visible = True
        日志窗口.Visible = True
        Me.ExitButton.Visible = True
        Me.ClearlogButton.Visible = True
        Me.ServiceButton.Visible = True
        Me.SettingsButton.Visible = True
        Me.Button7z.Visible = True
        Me.SftpButton.Visible = True
        Me.TestsftpButton.Visible = True
        Me.TestRCONButton.Visible = True
        Me.RunButton.Visible = True
        Me.ButtonSightseeing.Visible = True
        Me.RunButton.Visible = True
        Me.ServiceButton.Visible = True
        Me.ToolsButton.Visible = True
        Me.StopButton.Visible = True
        Me.LogsLabel.Visible = True
        Me.ButtonMC.Visible = True
        Me.ReturnButton.Visible = False
        Me.RunImmediately.Visible = True
        Me.LogsFolder.Visible = True
        Me.ConfigFolder.Visible = True
        Me.PicturesFolder.Visible = True
    End Sub
    '--------------------------------------------左二列按钮事件------------------------------
    Private Sub TestRCONButton_Click(sender As Object, e As EventArgs) Handles TestRCONButton.Click
        添加日志("[Action]正在测试RCON服务器连接", Color.Black)
        RCON服务器测试器()
    End Sub
    Private Sub TestsftpButton_Click(sender As Object, e As EventArgs) Handles TestsftpButton.Click
        添加日志("[Action]正在测试sftp服务器连接", Color.Black)
        Sftp服务器测试器()
    End Sub
    Private Sub RunButton_Click(sender As Object, e As EventArgs) Handles RunButton.Click
        添加日志("[Action]正在启动服务", Color.Black)
        添加日志("[Info]正在读取配置文件", Color.Black)
        日志窗口.日志输出主程序配置()
        日志窗口.日志输出MC服务端配置()
        日志窗口.日志输出7zip配置()
        日志窗口.日志输出SFTP配置()
        添加日志("-------------------------------------------------------------------------------------", Color.Black)
        添加日志("[Warning]尚未经过严格测试，谨慎使用", Color.Red)
        If String.IsNullOrEmpty(间隔天数) Then 间隔天数 = "1"
        服务 = New 间隔任务执行器()
        添加日志("[Action]服务已启动", Color.Black)
        添加日志("[提示]:在等待执行时可更改配置(最好不要踩点修改)", Color.Orange)
        RunButton.Enabled = False
        StopButton.Enabled = True
    End Sub
    Private Sub RunImmediately_Click(sender As Object, e As EventArgs) Handles RunImmediately.Click
        Dim H As New 核心功能类()
        H.核心功能方法()
    End Sub
    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        Me.服务.停止任务()
        添加日志("[Action]已停止服务", Color.Black)
        主任务进度条.Maximum = 100
        主任务进度条.Value = 0
        执行中的主任务.Text = "无"
        Me.RunButton.Enabled = True
        Me.StopButton.Enabled = False
    End Sub
    Private Sub ClearlogButton_Click(sender As Object, e As EventArgs) Handles ClearlogButton.Click
        日志窗口.LogsRichTextBox.Clear()
        添加日志("[Action]已清空日志", Color.Green)
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
    '--------------------------------------------左侧按钮事件---------------------------------
    Private Sub LogsPath_Click(sender As Object, e As EventArgs) Handles LogsFolder.Click
        Process.Start("explorer.exe", Path.Combine(程序数据目录, "日志"))
    End Sub
    Private Sub ConfigFolder_Click(sender As Object, e As EventArgs) Handles ConfigFolder.Click
        Process.Start("explorer.exe", Path.Combine(程序数据目录, "配置文件"))
    End Sub
    Private Sub PicturesFolder_Click(sender As Object, e As EventArgs) Handles PicturesFolder.Click
        Process.Start("explorer.exe", Path.Combine(程序数据目录, "背景图片"))
    End Sub

    Private Sub NowTimer_Tick(sender As Object, e As EventArgs) Handles NowTimer.Tick
        更新图片切换倒计时显示()
        更新任务执行倒计时显示()
    End Sub
    Public Shared Sub 服务运行时更改控件状态(运行状态 As Boolean)
        If 运行状态 Then
            MainForm.ExitButton.Enabled = False
            MainForm.TestRCONButton.Enabled = False
            MainForm.TestsftpButton.Enabled = False
            MainForm.ServiceButton.Enabled = False
            MainForm.SettingsButton.Enabled = False
            MainForm.Button7z.Enabled = False
            MainForm.SftpButton.Enabled = False
            If 服务运行状态 Then
                MainForm.StopButton.Enabled = True '区分立即运行和定时运行
            Else
                MainForm.StopButton.Enabled = False
            End If
            MainForm.ToolsButton.Enabled = False
            MainForm.ButtonMC.Enabled = False
            MainForm.RunImmediately.Enabled = False
            MainForm.执行中的主任务.Text = "无" '重置
            MainForm.主任务进度条.Value = 0
            MainForm.执行中的主任务.Text = "无"
            MainForm.主任务进度条.Value = 0
        Else
            MainForm.ExitButton.Enabled = True
            MainForm.TestRCONButton.Enabled = True
            MainForm.TestsftpButton.Enabled = True
            MainForm.ServiceButton.Enabled = True
            MainForm.SettingsButton.Enabled = True
            MainForm.Button7z.Enabled = True
            MainForm.SftpButton.Enabled = True
            If 服务运行状态 Then
                MainForm.StopButton.Enabled = True '区分立即运行和定时运行
            Else
                MainForm.StopButton.Enabled = False
            End If
            MainForm.ToolsButton.Enabled = True
            MainForm.ButtonMC.Enabled = True
            MainForm.RunImmediately.Enabled = True
            MainForm.执行中的主任务.Text = "无" '重置
            MainForm.主任务进度条.Value = 0
            MainForm.执行中的主任务.Text = "无"
            MainForm.主任务进度条.Value = 0
        End If
    End Sub
    Private Sub 切换图片并重置倒计时(sender As Object, e As EventArgs) Handles ChanegeImageTimer.Tick ' 切换图片并重置倒计时
        图片序号 = (图片序号 + 1) Mod 图片列表.Count
        加载图片(图片列表(图片序号))
        下一次切换的时间点 = DateTime.Now.AddMinutes(1) ' 重置倒计时
        更新图片切换倒计时显示()
    End Sub
    Private Sub RCON服务器测试器()
        执行中的主任务.Text = $"测试MC服务端的RCON连接"
        主任务进度条.Value = 0
        Dim 任务列表 As New List(Of Integer)
        If 是否控制MC服务端1 Then
            任务列表.Add(1)
            处理单个服务器(RCON1地址, RCON1端口, RCON1密码, "list", "1")
        End If
        主任务进度条.PerformStep()
        If 是否控制MC服务端2 Then
            任务列表.Add(2)
            处理单个服务器(RCON2地址, RCON2端口, RCON2密码, "list", "2")
        End If
        主任务进度条.PerformStep()
        If 是否控制MC服务端3 Then
            任务列表.Add(3)
            处理单个服务器(RCON3地址, RCON3端口, RCON3密码, "list", "3")
        End If
        主任务进度条.PerformStep()
        If 是否控制MC服务端4 Then
            任务列表.Add(4)
            处理单个服务器(RCON4地址, RCON4端口, RCON4密码, "list", "4")
        End If
        主任务进度条.PerformStep()
        If 是否控制MC服务端5 Then
            任务列表.Add(5)
            处理单个服务器(RCON5地址, RCON5端口, RCON5密码, "list", "5")
        End If
        主任务进度条.PerformStep()
        If 是否控制MC服务端6 Then
            任务列表.Add(6)
            处理单个服务器(RCON6地址, RCON6端口, RCON6密码, "list", "6")
        End If
        主任务进度条.PerformStep()
        If 是否控制MC服务端7 Then
            任务列表.Add(7)
            处理单个服务器(RCON7地址, RCON7端口, RCON7密码, "list", "7")
        End If
        主任务进度条.PerformStep()
        If 是否控制MC服务端8 Then
            任务列表.Add(8)
            处理单个服务器(RCON8地址, RCON8端口, RCON8密码, "list", "8")
        End If
        主任务进度条.PerformStep()
        If 是否控制MC服务端9 Then
            任务列表.Add(9)
            处理单个服务器(RCON9地址, RCON9端口, RCON9密码, "list", "9")
        End If
        主任务进度条.PerformStep()
        If 是否控制MC服务端10 Then
            任务列表.Add(10)
            处理单个服务器(RCON10地址, RCON10端口, RCON10密码, "list", "10")
        End If
        主任务进度条.PerformStep()
        执行中的主任务.Text = $"无"
        主任务进度条.Value = 0
        If 任务列表.Count = 0 Then 添加日志("[ERROR]没有可用的RCON服务器", Color.Red) : Return
        Return
    End Sub
    Private Sub Sftp服务器测试器()
        执行中的主任务.Text = $"测试Sftp服务器连接"
        主任务进度条.Value = 0
        Dim 任务列表_上传 As New List(Of Integer)
        Dim 测试文件 As String = Path.Combine(程序数据目录, "八宝粥.ico")
        If Sftp1开关 Then
            任务列表_上传.Add(1)
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[INFO]正在测试SFTP1服务器", Color.Orange)
            测试单个Sftp服务端_上传和删除(Sftp1地址, Sftp1端口, Sftp1用户名, Sftp1密码, "1", 测试文件, "/", "/八宝粥.ico")
        End If
        主任务进度条.Value = 33
        If Sftp2开关 Then
            任务列表_上传.Add(2)
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[INFO]正在测试SFTP2服务器", Color.Orange)
            测试单个Sftp服务端_上传和删除(Sftp2地址, Sftp2端口, Sftp2用户名, Sftp2密码, "2", 测试文件, "/", "/八宝粥.ico")
        End If
        主任务进度条.Value = 66
        If Sftp3开关 Then
            任务列表_上传.Add(3)
            添加日志("-------------------------------------------------------------------------------------", Color.Black)
            添加日志("[INFO]正在测试SFTP3服务器", Color.Orange)
            测试单个Sftp服务端_上传和删除(Sftp3地址, Sftp3端口, Sftp3用户名, Sftp3密码, "3", 测试文件, "/", "/八宝粥.ico")
        End If
        添加日志("-------------------------------------------------------------------------------------", Color.Black)
        执行中的主任务.Text = "无"
        主任务进度条.Value = 0
        If 任务列表_上传.Count = 0 Then 添加日志("[ERROR]没有可用的SFTP服务器", Color.Red)
    End Sub
    Private Sub 添加日志(信息 As String, 颜色 As Color) ' 添加日志
        日志窗口.添加日志(信息, 颜色)
    End Sub
    ' 进度控制方法
    Public Sub 更新压缩进度(百分比 As Integer)
        分任务进度条.Value = Math.Min(百分比, 100)
    End Sub
    '--------------------------------更新倒计时显示--------------------------------
    Private Sub 更新图片切换倒计时显示() ' 更新倒计时显示
        Dim 剩余秒 As TimeSpan = 下一次切换的时间点 - DateTime.Now
        Dim 剩余秒数 As Integer = CInt(剩余秒.TotalSeconds)
        ' 显示剩余秒数
        倒计时数字显示.Text = $"{剩余秒数} 秒后切换下一张"
        倒计时进度条.Value = If(Math.Max(0, 剩余秒数) <= 60, Math.Max(0, 剩余秒数), 60)
    End Sub
    Private Sub 更新任务执行倒计时显示()
        If 服务运行状态 AndAlso Not 备份操作进行状态 Then
            Dim S As Integer = 服务.获取剩余秒数().总秒数
            Dim TS As Integer = 服务.获取剩余秒数().剩余秒数
            Dim TD As Integer = TS \ 60 \ 60 \ 24
            Dim TH As Integer = TS \ 60 \ 60
            Dim LH As Integer = TH - TD * 24
            Dim TM As Integer = TS \ 60
            Dim LM As Integer = TM - TH * 60
            Dim LS As Integer = TS - TM * 60
            Dim k As Double = S / 100
            主任务进度条.Maximum = 100
            执行中的主任务.Text = $"等待备份运行时间的到来,倒计时:[{TD}:{LH}:{LM}:{LS}]"
            主任务进度条.Value = TS / k
        End If
    End Sub
    '-----------------------------------图片轮播-------------------------------------------
    Private Sub 加载图片列表() ' 加载图片文件列表
        If Directory.Exists(图片目录) Then
            Dim 文件列表 = Directory.GetFiles(图片目录)
            图片列表 = 文件列表.Where(Function(file) 支持的文件格式.Contains(Path.GetExtension(file).ToLower())).ToList()
        End If
    End Sub
    Private Sub 加载图片(图片目录 As String) ' 加载图片
        Try
            PictureBox.Image?.Dispose()
            PictureBox.Image = Image.FromFile(图片目录)
        Catch ex As Exception
            MessageBox.Show($"加载图片失败：{ex.Message}")
        End Try
    End Sub
End Class