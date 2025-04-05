' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class 显示日志的窗口
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(显示日志的窗口))
        LogsRichTextBox = New RichTextBox()
        位置同步Timer = New Timer(components)
        SuspendLayout()
        ' 
        ' LogsRichTextBox
        ' 
        LogsRichTextBox.BackColor = SystemColors.Window
        LogsRichTextBox.Dock = DockStyle.Fill
        LogsRichTextBox.Location = New Point(0, 0)
        LogsRichTextBox.Name = "LogsRichTextBox"
        LogsRichTextBox.Size = New Size(708, 432)
        LogsRichTextBox.TabIndex = 21
        LogsRichTextBox.Text = ""
        ' 
        ' 位置同步Timer
        ' 
        位置同步Timer.Enabled = True
        位置同步Timer.Interval = 10
        ' 
        ' 显示日志的窗口
        ' 
        AutoScaleDimensions = New SizeF(8F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(708, 432)
        Controls.Add(LogsRichTextBox)
        DoubleBuffered = True
        Font = New Font("Microsoft YaHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "显示日志的窗口"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "日志窗口"
        ResumeLayout(False)
    End Sub

    Friend WithEvents LogsRichTextBox As RichTextBox
    Friend WithEvents 位置同步Timer As Timer
End Class
