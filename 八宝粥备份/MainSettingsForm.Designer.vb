' Copyright 2025 八宝粥(Email:1749861851@qq.com)
' Licensed under the Apache License, Version 2.0 (see LICENSE file).
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMainSettings
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
        ButtonSaveAndExit = New Button()
        ButtonCancle = New Button()
        SuspendLayout()
        ' 
        ' ButtonSaveAndExit
        ' 
        ButtonSaveAndExit.Location = New Point(801, 437)
        ButtonSaveAndExit.Name = "ButtonSaveAndExit"
        ButtonSaveAndExit.Size = New Size(93, 50)
        ButtonSaveAndExit.TabIndex = 0
        ButtonSaveAndExit.Text = "保存并关闭"
        ButtonSaveAndExit.UseVisualStyleBackColor = True
        ' 
        ' ButtonCancle
        ' 
        ButtonCancle.Location = New Point(681, 437)
        ButtonCancle.Name = "ButtonCancle"
        ButtonCancle.Size = New Size(93, 50)
        ButtonCancle.TabIndex = 1
        ButtonCancle.Text = "取消"
        ButtonCancle.UseVisualStyleBackColor = True
        ' 
        ' FormMainSettings
        ' 
        AcceptButton = ButtonSaveAndExit
        AutoScaleDimensions = New SizeF(8F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = ButtonCancle
        ClientSize = New Size(936, 523)
        Controls.Add(ButtonCancle)
        Controls.Add(ButtonSaveAndExit)
        Font = New Font("Microsoft YaHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        Name = "FormMainSettings"
        StartPosition = FormStartPosition.CenterScreen
        Text = "主程序配置"
        ResumeLayout(False)
    End Sub

    Friend WithEvents ButtonSaveAndExit As Button
    Friend WithEvents ButtonCancle As Button
End Class
