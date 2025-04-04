﻿' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        NowTimer = New Timer(components)
        IntroductionLabel = New Label()
        LogsLabel = New Label()
        ExitButton = New Button()
        TestsftpButton = New Button()
        ServiceButton = New Button()
        SettingsButton = New Button()
        Button7z = New Button()
        SftpButton = New Button()
        ClearlogButton = New Button()
        ButtonRCON = New Button()
        TestRCONButton = New Button()
        RunButton = New Button()
        StopButton = New Button()
        ToolsButton = New Button()
        ButtonSightseeing = New Button()
        ReturnButton = New Button()
        ChanegeImageTimer = New Timer(components)
        PictureBox = New PictureBox()
        倒计时进度条 = New ProgressBar()
        倒计时数字显示 = New Label()
        CType(PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' NowTimer
        ' 
        NowTimer.Enabled = True
        NowTimer.Interval = 1000
        ' 
        ' IntroductionLabel
        ' 
        IntroductionLabel.AutoSize = True
        IntroductionLabel.BackColor = Color.Transparent
        IntroductionLabel.ForeColor = Color.Turquoise
        IntroductionLabel.Location = New Point(30, 446)
        IntroductionLabel.Name = "IntroductionLabel"
        IntroductionLabel.Size = New Size(557, 57)
        IntroductionLabel.TabIndex = 1
        IntroductionLabel.Text = "程序名称:八宝粥备份        作者:八宝粥" & vbCrLf & "程序功能:可定时自动(关闭MC服务端)增量备份文件并发送至远程sftp服务端(并开启MC服务端)" & vbCrLf & "Github仓库链接:https://github.com/babaozhouO/BabaozhouBackup"
        ' 
        ' LogsLabel
        ' 
        LogsLabel.AutoSize = True
        LogsLabel.BackColor = Color.Transparent
        LogsLabel.Location = New Point(30, 9)
        LogsLabel.Name = "LogsLabel"
        LogsLabel.Size = New Size(35, 19)
        LogsLabel.TabIndex = 2
        LogsLabel.Text = "日志"
        ' 
        ' ExitButton
        ' 
        ExitButton.BackColor = SystemColors.Control
        ExitButton.BackgroundImageLayout = ImageLayout.None
        ExitButton.Location = New Point(710, 330)
        ExitButton.Name = "ExitButton"
        ExitButton.Size = New Size(100, 50)
        ExitButton.TabIndex = 3
        ExitButton.Text = "退出"
        ExitButton.UseVisualStyleBackColor = False
        ' 
        ' TestsftpButton
        ' 
        TestsftpButton.Location = New Point(710, 90)
        TestsftpButton.Name = "TestsftpButton"
        TestsftpButton.Size = New Size(100, 50)
        TestsftpButton.TabIndex = 4
        TestsftpButton.Text = "测试sftp" & vbCrLf & "服务器连接"
        TestsftpButton.UseVisualStyleBackColor = True
        ' 
        ' ServiceButton
        ' 
        ServiceButton.BackColor = SystemColors.Control
        ServiceButton.BackgroundImageLayout = ImageLayout.None
        ServiceButton.Location = New Point(830, 30)
        ServiceButton.Name = "ServiceButton"
        ServiceButton.Size = New Size(100, 50)
        ServiceButton.TabIndex = 5
        ServiceButton.Text = "安装/卸载" & vbCrLf & "系统服务"
        ServiceButton.UseVisualStyleBackColor = False
        ' 
        ' SettingsButton
        ' 
        SettingsButton.Location = New Point(830, 90)
        SettingsButton.Name = "SettingsButton"
        SettingsButton.Size = New Size(100, 50)
        SettingsButton.TabIndex = 6
        SettingsButton.Text = "主程序" & vbCrLf & "配置界面"
        SettingsButton.UseVisualStyleBackColor = True
        ' 
        ' Button7z
        ' 
        Button7z.Location = New Point(830, 150)
        Button7z.Name = "Button7z"
        Button7z.Size = New Size(100, 50)
        Button7z.TabIndex = 7
        Button7z.Text = "7-Zip" & vbCrLf & "配置界面"
        Button7z.UseVisualStyleBackColor = True
        ' 
        ' SftpButton
        ' 
        SftpButton.Location = New Point(830, 210)
        SftpButton.Name = "SftpButton"
        SftpButton.Size = New Size(100, 50)
        SftpButton.TabIndex = 8
        SftpButton.Text = "内置sftp(cli)" & vbCrLf & "配置界面"
        SftpButton.UseVisualStyleBackColor = True
        ' 
        ' ClearlogButton
        ' 
        ClearlogButton.Location = New Point(710, 270)
        ClearlogButton.Name = "ClearlogButton"
        ClearlogButton.Size = New Size(100, 50)
        ClearlogButton.TabIndex = 9
        ClearlogButton.Text = "清除日志"
        ClearlogButton.UseVisualStyleBackColor = True
        ' 
        ' ButtonRCON
        ' 
        ButtonRCON.Location = New Point(830, 270)
        ButtonRCON.Name = "ButtonRCON"
        ButtonRCON.Size = New Size(100, 50)
        ButtonRCON.TabIndex = 11
        ButtonRCON.Text = "RCON(cli)" & vbCrLf & "配置界面"
        ButtonRCON.UseVisualStyleBackColor = True
        ' 
        ' TestRCONButton
        ' 
        TestRCONButton.BackColor = SystemColors.Control
        TestRCONButton.Location = New Point(710, 30)
        TestRCONButton.Name = "TestRCONButton"
        TestRCONButton.Size = New Size(100, 50)
        TestRCONButton.TabIndex = 12
        TestRCONButton.Text = "测试RCON" & vbCrLf & "服务器连接"
        TestRCONButton.UseVisualStyleBackColor = False
        ' 
        ' RunButton
        ' 
        RunButton.Location = New Point(710, 150)
        RunButton.Name = "RunButton"
        RunButton.Size = New Size(100, 50)
        RunButton.TabIndex = 13
        RunButton.Text = "启动"
        RunButton.UseVisualStyleBackColor = True
        ' 
        ' StopButton
        ' 
        StopButton.Location = New Point(710, 210)
        StopButton.Name = "StopButton"
        StopButton.Size = New Size(100, 50)
        StopButton.TabIndex = 14
        StopButton.Text = "停止"
        StopButton.UseVisualStyleBackColor = True
        ' 
        ' ToolsButton
        ' 
        ToolsButton.Location = New Point(830, 330)
        ToolsButton.Name = "ToolsButton"
        ToolsButton.Size = New Size(100, 50)
        ToolsButton.TabIndex = 15
        ToolsButton.Text = "没用的" & vbCrLf & "小工具"
        ToolsButton.UseVisualStyleBackColor = True
        ' 
        ' ButtonSightseeing
        ' 
        ButtonSightseeing.Location = New Point(710, 390)
        ButtonSightseeing.Name = "ButtonSightseeing"
        ButtonSightseeing.Size = New Size(220, 80)
        ButtonSightseeing.TabIndex = 17
        ButtonSightseeing.Text = "你想看风景嘛"
        ButtonSightseeing.UseVisualStyleBackColor = True
        ' 
        ' ReturnButton
        ' 
        ReturnButton.Font = New Font("微软雅黑", 5.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        ReturnButton.Location = New Point(922, 476)
        ReturnButton.Name = "ReturnButton"
        ReturnButton.Size = New Size(30, 30)
        ReturnButton.TabIndex = 18
        ReturnButton.Text = "不看了"
        ReturnButton.UseVisualStyleBackColor = True
        ReturnButton.Visible = False
        ' 
        ' ChanegeImageTimer
        ' 
        ChanegeImageTimer.Enabled = True
        ChanegeImageTimer.Interval = 60000
        ' 
        ' PictureBox
        ' 
        PictureBox.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox.Dock = DockStyle.Fill
        PictureBox.ErrorImage = CType(resources.GetObject("PictureBox.ErrorImage"), Image)
        PictureBox.InitialImage = CType(resources.GetObject("PictureBox.InitialImage"), Image)
        PictureBox.Location = New Point(0, 0)
        PictureBox.Name = "PictureBox"
        PictureBox.Size = New Size(964, 511)
        PictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox.TabIndex = 19
        PictureBox.TabStop = False
        ' 
        ' 倒计时进度条
        ' 
        倒计时进度条.Location = New Point(736, 486)
        倒计时进度条.Name = "倒计时进度条"
        倒计时进度条.Size = New Size(180, 20)
        倒计时进度条.TabIndex = 21
        ' 
        ' 倒计时数字显示
        ' 
        倒计时数字显示.AutoSize = True
        倒计时数字显示.BackColor = Color.Transparent
        倒计时数字显示.ForeColor = Color.Cyan
        倒计时数字显示.Location = New Point(603, 487)
        倒计时数字显示.Name = "倒计时数字显示"
        倒计时数字显示.Size = New Size(127, 19)
        倒计时数字显示.TabIndex = 22
        倒计时数字显示.Text = "N/A秒后切换下一张"
        ' 
        ' MainForm
        ' 
        AutoScaleMode = AutoScaleMode.None
        AutoScroll = True
        AutoSize = True
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(964, 511)
        Controls.Add(倒计时数字显示)
        Controls.Add(倒计时进度条)
        Controls.Add(IntroductionLabel)
        Controls.Add(ReturnButton)
        Controls.Add(ButtonSightseeing)
        Controls.Add(ToolsButton)
        Controls.Add(StopButton)
        Controls.Add(RunButton)
        Controls.Add(TestRCONButton)
        Controls.Add(ButtonRCON)
        Controls.Add(ClearlogButton)
        Controls.Add(SftpButton)
        Controls.Add(Button7z)
        Controls.Add(SettingsButton)
        Controls.Add(ServiceButton)
        Controls.Add(TestsftpButton)
        Controls.Add(ExitButton)
        Controls.Add(LogsLabel)
        Controls.Add(PictureBox)
        DoubleBuffered = True
        Font = New Font("微软雅黑", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MaximumSize = New Size(980, 550)
        MinimumSize = New Size(980, 550)
        Name = "MainForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "八宝粥备份"
        CType(PictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents NowTimer As Timer
    Friend WithEvents IntroductionLabel As Label
    Friend WithEvents LogsLabel As Label
    Friend WithEvents ExitButton As Button
    Friend WithEvents TestsftpButton As Button
    Friend WithEvents ServiceButton As Button
    Friend WithEvents SettingsButton As Button
    Friend WithEvents Button7z As Button
    Friend WithEvents SftpButton As Button
    Friend WithEvents ClearlogButton As Button
    Friend WithEvents ButtonRCON As Button
    Friend WithEvents TestRCONButton As Button
    Friend WithEvents RunButton As Button
    Friend WithEvents StopButton As Button
    Friend WithEvents ToolsButton As Button
    Friend WithEvents ButtonSightseeing As Button
    Friend WithEvents ReturnButton As Button
    Friend WithEvents ChanegeImageTimer As Timer
    Friend WithEvents PictureBox As PictureBox
    Friend WithEvents 倒计时进度条 As ProgressBar
    Friend WithEvents 倒计时数字显示 As Label

End Class
