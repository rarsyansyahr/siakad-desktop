Imports System.Data.SqlClient

Public Class Login

    Dim fungsi As New Fungsi()

    Private Sub Auth()
        Dim sql As String = "select id, nama from pengguna where username='" & Me.txtUsername.Text &
                            "' and password = '" & Me.txtPassword.Text & "'"
        Dim reader As SqlDataReader = Me.fungsi.eReader(sql)

        If reader.HasRows = True Then
            reader.Read()

            Dim id As Byte = Byte.Parse(reader.Item("id").ToString())
            Dim nama As String = reader.Item("nama").ToString()
            Dim mm = New MainMenu()
            mm.SetSession(id, nama)

            Me.fungsi.MsgBox("Selamat, login berhasil !", "Pesan Informasi", "information")
            mm.Show()
            Me.Hide()
        Else
            Me.fungsi.MsgBox("Login Gagal, username / password yang Anda masukan salah.", "Peringatan", "warning")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub btnMasuk_Click(sender As Object, e As EventArgs) Handles btnMasuk.Click
        Me.Auth()
    End Sub
End Class