Public Class FormService
    Private Sub Buttondone_Click(sender As Object, e As EventArgs) Handles Buttondone.Click
        Me.Close()
    End Sub

    Private Sub SetupButton_Click(sender As Object, e As EventArgs) Handles SetupButton.Click
        MessageBox.Show($"尚未实现", "等等吧", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ButtonUninstall_Click(sender As Object, e As EventArgs) Handles ButtonUninstall.Click
        MessageBox.Show($"尚未实现", "等等吧", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class