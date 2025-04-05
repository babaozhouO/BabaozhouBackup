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
        选择压缩格式.Size = New Size(87, 27)
        选择压缩格式.TabIndex = 6
        ' 
        ' 选择压缩级别
        ' 
        选择压缩级别.FormattingEnabled = True
        选择压缩级别.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
        选择压缩级别.Location = New Point(113, 67)
        选择压缩级别.Name = "选择压缩级别"
        选择压缩级别.Size = New Size(87, 27)
        选择压缩级别.TabIndex = 7
        ' 
        ' SevenZipSettingsForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(884, 561)
        ControlBox = False
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
End Class
