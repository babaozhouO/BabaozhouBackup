' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UselessToolsForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UselessToolsForm))
		安装7Zip = New Button()
		退出 = New Button()
		SendCommand = New Button()
		ComboBoxRCON = New ComboBox()
		Command = New TextBox()
		Label1 = New Label()
		ComboBoxSftp = New ComboBox()
		ChooseFile = New Button()
		FileSend = New Button()
		选择文件 = New OpenFileDialog()
		Label2 = New Label()
		Label3 = New Label()
		Label4 = New Label()
		远程目录 = New TextBox()
		启动MC服务端 = New Button()
		SuspendLayout()
		' 
		' 安装7Zip
		' 
		安装7Zip.Location = New Point(32, 191)
		安装7Zip.Name = "安装7Zip"
		安装7Zip.Size = New Size(226, 49)
		安装7Zip.TabIndex = 0
		安装7Zip.Text = "安装7-Zip(需要以管理员身份运行本程序)"
		安装7Zip.UseVisualStyleBackColor = True
		' 
		' 退出
		' 
		退出.Location = New Point(550, 306)
		退出.Name = "退出"
		退出.Size = New Size(132, 73)
		退出.TabIndex = 1
		退出.Text = "关掉这个破玩意"
		退出.UseVisualStyleBackColor = True
		' 
		' SendCommand
		' 
		SendCommand.Location = New Point(148, 41)
		SendCommand.Name = "SendCommand"
		SendCommand.Size = New Size(110, 54)
		SendCommand.TabIndex = 2
		SendCommand.Text = "发送"
		SendCommand.UseVisualStyleBackColor = True
		' 
		' ComboBoxRCON
		' 
		ComboBoxRCON.FormattingEnabled = True
		ComboBoxRCON.Location = New Point(32, 41)
		ComboBoxRCON.Name = "ComboBoxRCON"
		ComboBoxRCON.Size = New Size(110, 27)
		ComboBoxRCON.TabIndex = 3
		' 
		' Command
		' 
		Command.Location = New Point(32, 71)
		Command.Name = "Command"
		Command.Size = New Size(110, 24)
		Command.TabIndex = 4
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.BackColor = Color.Transparent
		Label1.ForeColor = SystemColors.ControlDark
		Label1.Location = New Point(57, 98)
		Label1.Name = "Label1"
		Label1.Size = New Size(61, 19)
		Label1.TabIndex = 5
		Label1.Text = "无需斜杠"
		' 
		' ComboBoxSftp
		' 
		ComboBoxSftp.FormattingEnabled = True
		ComboBoxSftp.Location = New Point(345, 41)
		ComboBoxSftp.Name = "ComboBoxSftp"
		ComboBoxSftp.Size = New Size(110, 27)
		ComboBoxSftp.TabIndex = 6
		' 
		' ChooseFile
		' 
		ChooseFile.Location = New Point(345, 71)
		ChooseFile.Name = "ChooseFile"
		ChooseFile.Size = New Size(110, 24)
		ChooseFile.TabIndex = 7
		ChooseFile.Text = "选择文件"
		ChooseFile.UseVisualStyleBackColor = True
		' 
		' FileSend
		' 
		FileSend.Location = New Point(461, 41)
		FileSend.Name = "FileSend"
		FileSend.Size = New Size(110, 54)
		FileSend.TabIndex = 8
		FileSend.Text = "发送"
		FileSend.UseVisualStyleBackColor = True
		' 
		' 选择文件
		' 
		选择文件.ShowHiddenFiles = True
		选择文件.Title = "选择要发送的文件"
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Location = New Point(32, 19)
		Label2.Name = "Label2"
		Label2.Size = New Size(213, 19)
		Label2.TabIndex = 9
		Label2.Text = "向选中的MC服务器发送自定义指令"
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Location = New Point(345, 19)
		Label3.Name = "Label3"
		Label3.Size = New Size(127, 19)
		Label3.TabIndex = 10
		Label3.Text = "向选中的Sftp服务器"
		' 
		' Label4
		' 
		Label4.AutoSize = True
		Label4.Location = New Point(595, 19)
		Label4.Name = "Label4"
		Label4.Size = New Size(87, 19)
		Label4.TabIndex = 11
		Label4.Text = "目录发送文件"
		' 
		' 远程目录
		' 
		远程目录.Location = New Point(478, 16)
		远程目录.Name = "远程目录"
		远程目录.Size = New Size(111, 24)
		远程目录.TabIndex = 12
		' 
		' 启动MC服务端
		' 
		启动MC服务端.Location = New Point(32, 132)
		启动MC服务端.Name = "启动MC服务端"
		启动MC服务端.Size = New Size(226, 35)
		启动MC服务端.TabIndex = 13
		启动MC服务端.Text = "启动已启用的MC服务端"
		启动MC服务端.UseVisualStyleBackColor = True
		' 
		' UselessToolsForm
		' 
		AutoScaleDimensions = New SizeF(8F, 19F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(694, 391)
		ControlBox = False
		Controls.Add(启动MC服务端)
		Controls.Add(远程目录)
		Controls.Add(Label4)
		Controls.Add(Label3)
		Controls.Add(Label2)
		Controls.Add(FileSend)
		Controls.Add(ChooseFile)
		Controls.Add(ComboBoxSftp)
		Controls.Add(Label1)
		Controls.Add(Command)
		Controls.Add(ComboBoxRCON)
		Controls.Add(SendCommand)
		Controls.Add(退出)
		Controls.Add(安装7Zip)
		Font = New Font("Microsoft YaHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
		Icon = CType(resources.GetObject("$this.Icon"), Icon)
		Location = New Point(800, 300)
		Name = "UselessToolsForm"
		StartPosition = FormStartPosition.Manual
		Text = "没用的小工具"
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents 安装7Zip As Button
    Friend WithEvents 退出 As Button
    Friend WithEvents SendCommand As Button
    Friend WithEvents ComboBoxRCON As ComboBox
    Friend WithEvents Command As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBoxSftp As ComboBox
    Friend WithEvents ChooseFile As Button
    Friend WithEvents FileSend As Button
    Friend WithEvents 选择文件 As OpenFileDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents 远程目录 As TextBox
	Friend WithEvents 启动MC服务端 As Button
End Class
