<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServiceForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServiceForm))
        Label1 = New Label()
        SetupButton = New Button()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(45, 30)
        Label1.Name = "Label1"
        Label1.Size = New Size(300, 19)
        Label1.TabIndex = 0
        Label1.Text = "安装为系统服务可自动运行,服务名称:BBZBackup"
        ' 
        ' SetupButton
        ' 
        SetupButton.Location = New Point(54, 128)
        SetupButton.Name = "SetupButton"
        SetupButton.Size = New Size(100, 50)
        SetupButton.TabIndex = 1
        SetupButton.Text = "安装服务"
        SetupButton.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(229, 128)
        Button1.Name = "Button1"
        Button1.Size = New Size(100, 50)
        Button1.TabIndex = 2
        Button1.Text = "卸载服务"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ServiceForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 19.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(384, 261)
        Controls.Add(Button1)
        Controls.Add(SetupButton)
        Controls.Add(Label1)
        Font = New Font("Microsoft YaHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        ForeColor = SystemColors.ControlText
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "ServiceForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "安装/卸载系统服务"
        TopMost = True
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents SetupButton As Button
    Friend WithEvents Button1 As Button
End Class
