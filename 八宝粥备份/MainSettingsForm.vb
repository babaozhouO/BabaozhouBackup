Public Class FormMainSettings
    Private Sub ButtonCancle_Click(sender As Object, e As EventArgs) Handles ButtonCancle.Click
        Dim result As Integer = MessageBox.Show("是否放弃保存设置并退出?", "提示", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub ButtonSaveAndExit_Click(sender As Object, e As EventArgs) Handles ButtonSaveAndExit.Click
        Dim result As Integer = MessageBox.Show("是否保存设置并退出?", "提示", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Yes Then
            '将textbox中的内容保存到配置文件（未实现）
            Me.Close()
        End If
    End Sub

    Private Sub FormMainSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class