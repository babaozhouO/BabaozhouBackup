' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainSettingsForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainSettingsForm))
		ButtonSaveAndExit = New Button()
		ButtonCancle = New Button()
		LabelRuntime = New Label()
		TextBoxhour = New TextBox()
		Labelhour = New Label()
		Labelminute = New Label()
		TextBoxminute = New TextBox()
		Labelsecond = New Label()
		TextBoxsecond = New TextBox()
		Label1 = New Label()
		Label2 = New Label()
		Days = New TextBox()
		CheckBox是否关服备份 = New CheckBox()
		SuspendLayout()
		' 
		' ButtonSaveAndExit
		' 
		ButtonSaveAndExit.Location = New Point(800, 440)
		ButtonSaveAndExit.Name = "ButtonSaveAndExit"
		ButtonSaveAndExit.Size = New Size(93, 50)
		ButtonSaveAndExit.TabIndex = 0
		ButtonSaveAndExit.Text = "保存并关闭"
		ButtonSaveAndExit.UseVisualStyleBackColor = True
		' 
		' ButtonCancle
		' 
		ButtonCancle.Location = New Point(680, 440)
		ButtonCancle.Name = "ButtonCancle"
		ButtonCancle.Size = New Size(93, 50)
		ButtonCancle.TabIndex = 1
		ButtonCancle.Text = "取消"
		ButtonCancle.UseVisualStyleBackColor = True
		' 
		' LabelRuntime
		' 
		LabelRuntime.AutoSize = True
		LabelRuntime.Location = New Point(43, 77)
		LabelRuntime.Name = "LabelRuntime"
		LabelRuntime.Size = New Size(97, 19)
		LabelRuntime.TabIndex = 2
		LabelRuntime.Text = "运行时间(当天)"
		' 
		' TextBoxhour
		' 
		TextBoxhour.Location = New Point(146, 74)
		TextBoxhour.Name = "TextBoxhour"
		TextBoxhour.Size = New Size(21, 24)
		TextBoxhour.TabIndex = 3
		TextBoxhour.Text = "04"
		' 
		' Labelhour
		' 
		Labelhour.AutoSize = True
		Labelhour.Location = New Point(173, 77)
		Labelhour.Name = "Labelhour"
		Labelhour.Size = New Size(22, 19)
		Labelhour.TabIndex = 4
		Labelhour.Text = "时"
		' 
		' Labelminute
		' 
		Labelminute.AutoSize = True
		Labelminute.Location = New Point(228, 77)
		Labelminute.Name = "Labelminute"
		Labelminute.Size = New Size(22, 19)
		Labelminute.TabIndex = 6
		Labelminute.Text = "分"
		' 
		' TextBoxminute
		' 
		TextBoxminute.Location = New Point(201, 74)
		TextBoxminute.Name = "TextBoxminute"
		TextBoxminute.Size = New Size(21, 24)
		TextBoxminute.TabIndex = 5
		TextBoxminute.Text = "00"
		' 
		' Labelsecond
		' 
		Labelsecond.AutoSize = True
		Labelsecond.Location = New Point(283, 77)
		Labelsecond.Name = "Labelsecond"
		Labelsecond.Size = New Size(22, 19)
		Labelsecond.TabIndex = 8
		Labelsecond.Text = "秒"
		' 
		' TextBoxsecond
		' 
		TextBoxsecond.Location = New Point(256, 74)
		TextBoxsecond.Name = "TextBoxsecond"
		TextBoxsecond.Size = New Size(21, 24)
		TextBoxsecond.TabIndex = 7
		TextBoxsecond.Text = "00"
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Location = New Point(43, 49)
		Label1.Name = "Label1"
		Label1.Size = New Size(22, 19)
		Label1.TabIndex = 9
		Label1.Text = "每"
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Location = New Point(110, 49)
		Label2.Name = "Label2"
		Label2.Size = New Size(74, 19)
		Label2.TabIndex = 10
		Label2.Text = "天运行一次"
		' 
		' Days
		' 
		Days.Location = New Point(71, 46)
		Days.Name = "Days"
		Days.Size = New Size(33, 24)
		Days.TabIndex = 11
		' 
		' CheckBox是否关服备份
		' 
		CheckBox是否关服备份.AutoSize = True
		CheckBox是否关服备份.Location = New Point(43, 103)
		CheckBox是否关服备份.Name = "CheckBox是否关服备份"
		CheckBox是否关服备份.Size = New Size(80, 23)
		CheckBox是否关服备份.TabIndex = 13
		CheckBox是否关服备份.Text = "关服备份"
		CheckBox是否关服备份.UseVisualStyleBackColor = True
		' 
		' MainSettingsForm
		' 
		AcceptButton = ButtonSaveAndExit
		AutoScaleDimensions = New SizeF(8F, 19F)
		AutoScaleMode = AutoScaleMode.Font
		CancelButton = ButtonCancle
		ClientSize = New Size(934, 521)
		ControlBox = False
		Controls.Add(CheckBox是否关服备份)
		Controls.Add(Days)
		Controls.Add(Label2)
		Controls.Add(Label1)
		Controls.Add(Labelsecond)
		Controls.Add(TextBoxsecond)
		Controls.Add(Labelminute)
		Controls.Add(TextBoxminute)
		Controls.Add(Labelhour)
		Controls.Add(TextBoxhour)
		Controls.Add(LabelRuntime)
		Controls.Add(ButtonCancle)
		Controls.Add(ButtonSaveAndExit)
		Font = New Font("Microsoft YaHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
		Icon = CType(resources.GetObject("$this.Icon"), Icon)
		Location = New Point(800, 300)
		MaximizeBox = False
		MinimizeBox = False
		Name = "MainSettingsForm"
		StartPosition = FormStartPosition.Manual
		Text = "主程序配置"
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents ButtonSaveAndExit As Button
    Friend WithEvents ButtonCancle As Button
    Friend WithEvents LabelRuntime As Label
    Friend WithEvents TextBoxhour As TextBox
    Friend WithEvents Labelhour As Label
    Friend WithEvents Labelminute As Label
    Friend WithEvents TextBoxminute As TextBox
    Friend WithEvents Labelsecond As Label
    Friend WithEvents TextBoxsecond As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Days As TextBox
	Friend WithEvents CheckBox是否关服备份 As CheckBox
End Class
