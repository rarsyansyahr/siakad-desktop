Public Class MainMenu

    Private id As Byte
    Private nama As String

    Public Sub SetSession(id As Byte, nama As String)
        Me.id = id
        Me.nama = nama
    End Sub

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

    Private Sub DataMahasiswaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataMahasiswaToolStripMenuItem.Click
        Dim mahasiswa = New masterMahasiswa()
        mahasiswa.MdiParent = Me
        mahasiswa.Show()
    End Sub

    Private Sub DataMataKuliahToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataMataKuliahToolStripMenuItem.Click
        Dim matkul = New MasterMatkul()
        matkul.MdiParent = Me
        matkul.Show()
    End Sub

    Private Sub TentangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TentangToolStripMenuItem.Click
        Dim tentang = New Tentang()
        tentang.MdiParent = Me
        tentang.Show()
    End Sub

    Private Sub MataKuliahMahasiswaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MataKuliahMahasiswaToolStripMenuItem.Click
        Dim krs = New KartuRencanaStudi()
        krs.MdiParent = Me
        krs.Show()
    End Sub

    Private Sub MataKuliahDosenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MataKuliahDosenToolStripMenuItem.Click
        Dim krm = New KartuRencanaMengajar()
        krm.MdiParent = Me
        krm.Show()
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.mnNama.Text = "Admin : " & Me.nama
    End Sub
End Class