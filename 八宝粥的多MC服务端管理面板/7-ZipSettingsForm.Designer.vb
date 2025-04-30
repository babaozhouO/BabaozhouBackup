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
		Label4 = New Label()
		Label5 = New Label()
		选择压缩方法 = New ComboBox()
		TextBox3 = New TextBox()
		Label6 = New Label()
		Label7 = New Label()
		选择单词大小 = New ComboBox()
		Label8 = New Label()
		选择字典大小 = New ComboBox()
		Label9 = New Label()
		Label10 = New Label()
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
		选择压缩格式.Items.AddRange(New Object() {"7z-压缩率最高,兼容性稍差", "tar-仅打包(需要配合gzip使用)", "wim-仅打包(7z对wim方法支持较差)", "zip-兼容性最好,压缩率中等"})
		选择压缩格式.Location = New Point(113, 35)
		选择压缩格式.MaxDropDownItems = 7
		选择压缩格式.Name = "选择压缩格式"
		选择压缩格式.Size = New Size(185, 27)
		选择压缩格式.TabIndex = 6
		' 
		' 选择压缩级别
		' 
		选择压缩级别.FormattingEnabled = True
		选择压缩级别.Items.AddRange(New Object() {"0-仅存储(取决于硬盘速度,最快)", "1-极速压缩", "2", "3-快速压缩", "4", "5-标准压缩", "6", "7-最大压缩", "8", "9-极限压缩(取决于CPU等硬件,最慢)"})
		选择压缩级别.Location = New Point(113, 67)
		选择压缩级别.Name = "选择压缩级别"
		选择压缩级别.Size = New Size(185, 27)
		选择压缩级别.TabIndex = 7
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Location = New Point(491, 68)
		Label1.Name = "Label1"
		Label1.Size = New Size(87, 19)
		Label1.TabIndex = 8
		Label1.Text = "备份输出目录"
		' 
		' Button1
		' 
		Button1.Location = New Point(719, 65)
		Button1.Name = "Button1"
		Button1.Size = New Size(24, 24)
		Button1.TabIndex = 119
		Button1.UseVisualStyleBackColor = True
		' 
		' TextBox2
		' 
		TextBox2.Location = New Point(584, 65)
		TextBox2.Name = "TextBox2"
		TextBox2.Size = New Size(129, 24)
		TextBox2.TabIndex = 118
		' 
		' CheckBox1
		' 
		CheckBox1.AutoSize = True
		CheckBox1.Location = New Point(491, 95)
		CheckBox1.Name = "CheckBox1"
		CheckBox1.Size = New Size(106, 23)
		CheckBox1.TabIndex = 120
		CheckBox1.Text = "是否增量备份"
		CheckBox1.UseVisualStyleBackColor = True
		' 
		' Button2
		' 
		Button2.Location = New Point(719, 35)
		Button2.Name = "Button2"
		Button2.Size = New Size(24, 24)
		Button2.TabIndex = 123
		Button2.UseVisualStyleBackColor = True
		' 
		' TextBox1
		' 
		TextBox1.Location = New Point(597, 35)
		TextBox1.Name = "TextBox1"
		TextBox1.Size = New Size(116, 24)
		TextBox1.TabIndex = 122
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Location = New Point(491, 38)
		Label2.Name = "Label2"
		Label2.Size = New Size(100, 19)
		Label2.TabIndex = 121
		Label2.Text = "自定义备份目录"
		' 
		' CheckBox2
		' 
		CheckBox2.AutoSize = True
		CheckBox2.Location = New Point(603, 95)
		CheckBox2.Name = "CheckBox2"
		CheckBox2.Size = New Size(119, 23)
		CheckBox2.TabIndex = 124
		CheckBox2.Text = "备份自定义目录"
		CheckBox2.UseVisualStyleBackColor = True
		' 
		' CPU线程数
		' 
		CPU线程数.Location = New Point(167, 199)
		CPU线程数.Name = "CPU线程数"
		CPU线程数.Size = New Size(131, 24)
		CPU线程数.TabIndex = 126
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Location = New Point(46, 202)
		Label3.Name = "Label3"
		Label3.Size = New Size(115, 19)
		Label3.TabIndex = 125
		Label3.Text = "使用的CPU线程数"
		' 
		' Label4
		' 
		Label4.AutoSize = True
		Label4.Font = New Font("Microsoft YaHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
		Label4.Location = New Point(46, 319)
		Label4.Name = "Label4"
		Label4.Size = New Size(812, 62)
		Label4.TabIndex = 127
		Label4.Text = "使用LZMA/LZMA2压缩方法压缩产生的压缩包请使用7z打开" & vbCrLf & "使用其它软件可能无法打开，若没有7z可在没用的小工具窗口中点击安装7z"
		' 
		' Label5
		' 
		Label5.AutoSize = True
		Label5.Location = New Point(46, 103)
		Label5.Name = "Label5"
		Label5.Size = New Size(61, 19)
		Label5.TabIndex = 128
		Label5.Text = "压缩方法"
		' 
		' 选择压缩方法
		' 
		选择压缩方法.FormattingEnabled = True
		选择压缩方法.Location = New Point(113, 100)
		选择压缩方法.Name = "选择压缩方法"
		选择压缩方法.Size = New Size(185, 27)
		选择压缩方法.TabIndex = 129
		' 
		' TextBox3
		' 
		TextBox3.Location = New Point(143, 229)
		TextBox3.Name = "TextBox3"
		TextBox3.Size = New Size(127, 24)
		TextBox3.TabIndex = 131
		' 
		' Label6
		' 
		Label6.AutoSize = True
		Label6.Location = New Point(46, 232)
		Label6.Name = "Label6"
		Label6.Size = New Size(91, 19)
		Label6.TabIndex = 130
		Label6.Text = "压缩超时时长:"
		' 
		' Label7
		' 
		Label7.AutoSize = True
		Label7.Location = New Point(276, 232)
		Label7.Name = "Label7"
		Label7.Size = New Size(22, 19)
		Label7.TabIndex = 132
		Label7.Text = "秒"
		' 
		' 选择单词大小
		' 
		选择单词大小.FormattingEnabled = True
		选择单词大小.Location = New Point(113, 166)
		选择单词大小.Name = "选择单词大小"
		选择单词大小.Size = New Size(185, 27)
		选择单词大小.TabIndex = 136
		' 
		' Label8
		' 
		Label8.AutoSize = True
		Label8.Location = New Point(46, 169)
		Label8.Name = "Label8"
		Label8.Size = New Size(61, 19)
		Label8.TabIndex = 135
		Label8.Text = "单词大小"
		' 
		' 选择字典大小
		' 
		选择字典大小.FormattingEnabled = True
		选择字典大小.Items.AddRange(New Object() {"0-仅存储(取决于硬盘速度,最快)", "1-极速压缩", "2", "3-快速压缩", "4", "5-标准压缩", "6", "7-最大压缩", "8", "9-极限压缩(取决于CPU等硬件,最慢)"})
		选择字典大小.Location = New Point(113, 133)
		选择字典大小.Name = "选择字典大小"
		选择字典大小.Size = New Size(185, 27)
		选择字典大小.TabIndex = 134
		' 
		' Label9
		' 
		Label9.AutoSize = True
		Label9.Location = New Point(46, 136)
		Label9.Name = "Label9"
		Label9.Size = New Size(61, 19)
		Label9.TabIndex = 133
		Label9.Text = "字典大小"
		' 
		' Label10
		' 
		Label10.AutoSize = True
		Label10.Font = New Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
		Label10.Location = New Point(46, 396)
		Label10.Name = "Label10"
		Label10.Size = New Size(499, 44)
		Label10.TabIndex = 137
		Label10.Text = "建议设置压缩参数时，右键任意文件夹选择7-zip的添加到压缩包选项" & vbCrLf & "选择好合适的压缩参数再转移到本程序内(注意内存占用)"
		' 
		' SevenZipSettingsForm
		' 
		AutoScaleDimensions = New SizeF(8F, 19F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(884, 561)
		ControlBox = False
		Controls.Add(Label10)
		Controls.Add(选择单词大小)
		Controls.Add(Label8)
		Controls.Add(选择字典大小)
		Controls.Add(Label9)
		Controls.Add(Label7)
		Controls.Add(TextBox3)
		Controls.Add(Label6)
		Controls.Add(选择压缩方法)
		Controls.Add(Label5)
		Controls.Add(Label4)
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
	Friend WithEvents Label4 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents 选择压缩方法 As ComboBox
	Friend WithEvents TextBox3 As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents 选择单词大小 As ComboBox
	Friend WithEvents Label8 As Label
	Friend WithEvents 选择字典大小 As ComboBox
	Friend WithEvents Label9 As Label
	Friend WithEvents Label10 As Label
End Class
