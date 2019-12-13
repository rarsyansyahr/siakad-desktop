Public Class MainMenu

    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        Dim konfirmasi As Integer = MessageBox.Show("Yakin untuk keluar dari aplikasi ?", "Pesan Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If konfirmasi = 6 Then
            Dim ok As Integer = MessageBox.Show("Terima kasih telah menggunakan aplikasi kami.. :)", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If ok = 1 Then
                Me.Close()
                Login.Close()
            End If
        End If
    End Sub

    Private Sub DataDosenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataDosenToolStripMenuItem.Click
        Dim dosen = New MasterDosen()
        dosen.MdiParent = Me
        dosen.Show()
    End Sub
End Class