<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class 主窗口
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(主窗口))
        LogsTextBox = New TextBox()
        IntroductionLabel = New Label()
        LogsLabel = New Label()
        ExitButton = New Button()
        TestsftpButton = New Button()
        ServiceButton = New Button()
        SettingsButton = New Button()
        Button7z = New Button()
        SftpButton = New Button()
        ClearlogButton = New Button()
        NowTimer = New Timer(components)
        SuspendLayout()
        ' 
        ' LogsTextBox
        ' 
        LogsTextBox.Cursor = Cursors.IBeam
        LogsTextBox.Location = New Point(30, 30)
        LogsTextBox.MaxLength = 1000000000
        LogsTextBox.Multiline = True
        LogsTextBox.Name = "LogsTextBox"
        LogsTextBox.ScrollBars = ScrollBars.Vertical
        LogsTextBox.Size = New Size(650, 410)
        LogsTextBox.TabIndex = 0
        ' 
        ' IntroductionLabel
        ' 
        IntroductionLabel.AutoSize = True
        IntroductionLabel.Location = New Point(30, 446)
        IntroductionLabel.Name = "IntroductionLabel"
        IntroductionLabel.Size = New Size(577, 57)
        IntroductionLabel.TabIndex = 1
        IntroductionLabel.Text = "程序名称:八宝粥备份        作者:八宝粥" & vbCrLf & "程序功能:可定时自动(关闭MC服务端)增量备份文件并发送至远程sftp服务端(并开启MC服务端)" & vbCrLf & "Github项目链接:------------------------------------------------------------------------------"
        ' 
        ' LogsLabel
        ' 
        LogsLabel.AutoSize = True
        LogsLabel.Location = New Point(30, 9)
        LogsLabel.Name = "LogsLabel"
        LogsLabel.Size = New Size(35, 19)
        LogsLabel.TabIndex = 2
        LogsLabel.Text = "日志"
        ' 
        ' ExitButton
        ' 
        ExitButton.Location = New Point(707, 390)
        ExitButton.Name = "ExitButton"
        ExitButton.Size = New Size(100, 50)
        ExitButton.TabIndex = 3
        ExitButton.Text = "退出"
        ExitButton.UseVisualStyleBackColor = True
        ' 
        ' TestsftpButton
        ' 
        TestsftpButton.Location = New Point(707, 330)
        TestsftpButton.Name = "TestsftpButton"
        TestsftpButton.Size = New Size(100, 50)
        TestsftpButton.TabIndex = 4
        TestsftpButton.Text = "测试sftp" & vbCrLf & "服务器连接"
        TestsftpButton.UseVisualStyleBackColor = True
        ' 
        ' ServiceButton
        ' 
        ServiceButton.Location = New Point(707, 30)
        ServiceButton.Name = "ServiceButton"
        ServiceButton.Size = New Size(100, 50)
        ServiceButton.TabIndex = 5
        ServiceButton.Text = "安装/卸载" & vbCrLf & "系统服务"
        ServiceButton.UseVisualStyleBackColor = True
        ' 
        ' SettingsButton
        ' 
        SettingsButton.Location = New Point(707, 90)
        SettingsButton.Name = "SettingsButton"
        SettingsButton.Size = New Size(100, 50)
        SettingsButton.TabIndex = 6
        SettingsButton.Text = "主程序" & vbCrLf & "配置界面"
        SettingsButton.UseVisualStyleBackColor = True
        ' 
        ' Button7z
        ' 
        Button7z.Location = New Point(707, 150)
        Button7z.Name = "Button7z"
        Button7z.Size = New Size(100, 50)
        Button7z.TabIndex = 7
        Button7z.Text = "7-Zip" & vbCrLf & "配置界面"
        Button7z.UseVisualStyleBackColor = True
        ' 
        ' SftpButton
        ' 
        SftpButton.Location = New Point(707, 210)
        SftpButton.Name = "SftpButton"
        SftpButton.Size = New Size(100, 50)
        SftpButton.TabIndex = 8
        SftpButton.Text = "内置sftp(cli)" & vbCrLf & "配置界面"
        SftpButton.UseVisualStyleBackColor = True
        ' 
        ' ClearlogButton
        ' 
        ClearlogButton.Location = New Point(707, 270)
        ClearlogButton.Name = "ClearlogButton"
        ClearlogButton.Size = New Size(100, 50)
        ClearlogButton.TabIndex = 9
        ClearlogButton.Text = "清除日志"
        ClearlogButton.UseVisualStyleBackColor = True
        ' 
        ' NowTimer
        ' 
        NowTimer.Enabled = True
        NowTimer.Interval = 1000
        ' 
        ' 主窗口
        ' 
        AutoScaleMode = AutoScaleMode.None
        AutoScroll = True
        AutoSize = True
        ClientSize = New Size(834, 511)
        Controls.Add(ClearlogButton)
        Controls.Add(SftpButton)
        Controls.Add(Button7z)
        Controls.Add(SettingsButton)
        Controls.Add(ServiceButton)
        Controls.Add(TestsftpButton)
        Controls.Add(ExitButton)
        Controls.Add(LogsLabel)
        Controls.Add(IntroductionLabel)
        Controls.Add(LogsTextBox)
        Font = New Font("微软雅黑", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MaximumSize = New Size(850, 550)
        MinimumSize = New Size(100, 100)
        Name = "主窗口"
        StartPosition = FormStartPosition.CenterScreen
        Text = "八宝粥备份"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LogsTextBox As TextBox
    Friend WithEvents IntroductionLabel As Label
    Friend WithEvents LogsLabel As Label
    Friend WithEvents ExitButton As Button
    Friend WithEvents TestsftpButton As Button
    Friend WithEvents ServiceButton As Button
    Friend WithEvents SettingsButton As Button
    Friend WithEvents Button7z As Button
    Friend WithEvents SftpButton As Button
    Friend WithEvents ClearlogButton As Button
    Friend WithEvents NowTimer As Timer
End Class
