Public Class Login

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtPassword.UseSystemPasswordChar = True
    End Sub

    Public Sub Close()
        Me.Close()
    End Sub

    Private Sub btnMasuk_Click(sender As Object, e As EventArgs) Handles btnMasuk.Click
        Dim mm = New MainMenu()
        mm.Show()
        Me.Hide()
    End Sub
End Class