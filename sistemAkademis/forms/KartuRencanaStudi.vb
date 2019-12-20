Public Class KartuRencanaStudi
    Dim fungsi As New Fungsi()

    Private Sub SetMahasiswa()
        Dim sql As String = "select id, concat(nim, ' - ', nama) as nama from mahasiswa order by nim"
        Me.fungsi.setComboBox(sql, "id", "nama", Me.cmbMahasiswa)
    End Sub

    Private Sub btnKelola_Click(sender As Object, e As EventArgs) Handles btnKelola.Click
        Dim id As Byte = Byte.Parse(DirectCast(Me.cmbMahasiswa.SelectedItem, KeyValuePair(Of Byte, String)).Key)

        Dim kelola = New KelolaKRS()
        kelola.setMahasiswa(id, Me.cmbMahasiswa.Text)
        kelola.ShowDialog()
    End Sub

    Private Sub KartuRencanaStudi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetMahasiswa()
    End Sub

End Class