' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SevenZipSettingsForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SevenZipSettingsForm))
		label压缩格式 = New Label()
		label压缩级别 = New Label()
		ButtonCancle = New Button()
		ButtonSaveAndExit = New Button()
		选择压缩格式 = New ComboBox()
		选择压缩级别 = New ComboBox()
		Label1 = New Label()
		Button1 = New Button()
		TextBox2 = New TextBox()
		CheckBox1 = New CheckBox()
		Button2 = New Button()
		TextBox1 = New TextBox()
		Label2 = New Label()
		CheckBox2 = New CheckBox()
		CPU线程数 = New TextBox()
		Label3 = New Label()
		SuspendLayout()
		' 
		' label压缩格式
		' 
		label压缩格式.AutoSize = True
		label压缩格式.Location = New Point(46, 38)
		label压缩格式.Name = "label压缩格式"
		label压缩格式.Size = New Size(61, 19)
		label压缩格式.TabIndex = 1
		label压缩格式.Text = "压缩格式"
		' 
		' label压缩级别
		' 
		label压缩级别.AutoSize = True
		label压缩级别.Location = New Point(46, 70)
		label压缩级别.Name = "label压缩级别"
		label压缩级别.Size = New Size(61, 19)
		label压缩级别.TabIndex = 2
		label压缩级别.Text = "压缩等级"
		' 
		' ButtonCancle
		' 
		ButtonCancle.Location = New Point(613, 470)
		ButtonCancle.Name = "ButtonCancle"
		ButtonCancle.Size = New Size(93, 50)
		ButtonCancle.TabIndex = 5
		ButtonCancle.Text = "取消"
		ButtonCancle.UseVisualStyleBackColor = True
		' 
		' ButtonSaveAndExit
		' 
		ButtonSaveAndExit.Location = New Point(733, 470)
		ButtonSaveAndExit.Name = "ButtonSaveAndExit"
		ButtonSaveAndExit.Size = New Size(93, 50)
		ButtonSaveAndExit.TabIndex = 4
		ButtonSaveAndExit.Text = "保存并关闭"
		ButtonSaveAndExit.UseVisualStyleBackColor = True
		' 
		' 选择压缩格式
		' 
		选择压缩格式.FormattingEnabled = True
		选择压缩格式.Items.AddRange(New Object() {"7z", "bzip2", "gzip", "tar", "wim", "xz", "zip"})
		选择压缩格式.Location = New Point(113, 35)
		选择压缩格式.MaxDropDownItems = 7
		选择压缩格式.Name = "选择压缩格式"
		选择压缩格式.Size = New Size(185, 27)
		选择压缩格式.TabIndex = 6
		' 
		' 选择压缩级别
		' 
		选择压缩级别.FormattingEnabled = True
		选择压缩级别.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
		选择压缩级别.Location = New Point(113, 67)
		选择压缩级别.Name = "选择压缩级别"
		选择压缩级别.Size = New Size(185, 27)
		选择压缩级别.TabIndex = 7
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Location = New Point(46, 163)
		Label1.Name = "Label1"
		Label1.Size = New Size(87, 19)
		Label1.TabIndex = 8
		Label1.Text = "备份输出目录"
		' 
		' Button1
		' 
		Button1.Location = New Point(274, 160)
		Button1.Name = "Button1"
		Button1.Size = New Size(24, 24)
		Button1.TabIndex = 119
		Button1.UseVisualStyleBackColor = True
		' 
		' TextBox2
		' 
		TextBox2.Location = New Point(139, 160)
		TextBox2.Name = "TextBox2"
		TextBox2.Size = New Size(129, 24)
		TextBox2.TabIndex = 118
		' 
		' CheckBox1
		' 
		CheckBox1.AutoSize = True
		CheckBox1.Location = New Point(46, 190)
		CheckBox1.Name = "CheckBox1"
		CheckBox1.Size = New Size(106, 23)
		CheckBox1.TabIndex = 120
		CheckBox1.Text = "是否增量备份"
		CheckBox1.UseVisualStyleBackColor = True
		' 
		' Button2
		' 
		Button2.Location = New Point(274, 130)
		Button2.Name = "Button2"
		Button2.Size = New Size(24, 24)
		Button2.TabIndex = 123
		Button2.UseVisualStyleBackColor = True
		' 
		' TextBox1
		' 
		TextBox1.Location = New Point(152, 130)
		TextBox1.Name = "TextBox1"
		TextBox1.Size = New Size(116, 24)
		TextBox1.TabIndex = 122
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Location = New Point(46, 133)
		Label2.Name = "Label2"
		Label2.Size = New Size(100, 19)
		Label2.TabIndex = 121
		Label2.Text = "自定义备份目录"
		' 
		' CheckBox2
		' 
		CheckBox2.AutoSize = True
		CheckBox2.Location = New Point(162, 190)
		CheckBox2.Name = "CheckBox2"
		CheckBox2.Size = New Size(119, 23)
		CheckBox2.TabIndex = 124
		CheckBox2.Text = "备份自定义目录"
		CheckBox2.UseVisualStyleBackColor = True
		' 
		' CPU线程数
		' 
		CPU线程数.Location = New Point(167, 100)
		CPU线程数.Name = "CPU线程数"
		CPU线程数.Size = New Size(131, 24)
		CPU线程数.TabIndex = 126
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Location = New Point(46, 103)
		Label3.Name = "Label3"
		Label3.Size = New Size(115, 19)
		Label3.TabIndex = 125
		Label3.Text = "使用的CPU线程数"
		' 
		' SevenZipSettingsForm
		' 
		AutoScaleDimensions = New SizeF(8F, 19F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(884, 561)
		ControlBox = False
		Controls.Add(CPU线程数)
		Controls.Add(Label3)
		Controls.Add(CheckBox2)
		Controls.Add(Button2)
		Controls.Add(TextBox1)
		Controls.Add(Label2)
		Controls.Add(CheckBox1)
		Controls.Add(Button1)
		Controls.Add(TextBox2)
		Controls.Add(Label1)
		Controls.Add(选择压缩级别)
		Controls.Add(选择压缩格式)
		Controls.Add(ButtonCancle)
		Controls.Add(ButtonSaveAndExit)
		Controls.Add(label压缩级别)
		Controls.Add(label压缩格式)
		Font = New Font("Microsoft YaHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
		Icon = CType(resources.GetObject("$this.Icon"), Icon)
		Location = New Point(800, 300)
		Name = "SevenZipSettingsForm"
		StartPosition = FormStartPosition.Manual
		Text = "7-Zip配置"
		ResumeLayout(False)
		PerformLayout()
	End Sub
	Friend WithEvents label压缩格式 As Label
    Friend WithEvents label压缩级别 As Label
    Friend WithEvents ButtonCancle As Button
    Friend WithEvents ButtonSaveAndExit As Button
    Friend WithEvents 选择压缩格式 As ComboBox
    Friend WithEvents 选择压缩级别 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBox2 As CheckBox
	Friend WithEvents CPU线程数 As TextBox
	Friend WithEvents Label3 As Label
End Class
