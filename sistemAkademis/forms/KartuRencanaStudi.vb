Imports System.Data.SqlClient

Public Class KartuRencanaStudi
    Dim fungsi As New Fungsi()
    Private table As DataTable
    Private adapter As SqlDataAdapter
    Private sql As String
    Private id As Integer

    Private Sub SetMahasiswa()
        Dim sql As String = "select id, concat(nim, ' - ', nama) as nama from mahasiswa order by nim"
        Me.fungsi.setList(sql, "id", "nama", Me.cmbMahasiswa)
        Me.cmbMahasiswa.SelectedIndex = -1
    End Sub

    Private Sub Read(id As Byte)
        Dim sql As String = "select id, matkul, dosen from v_krs where v_krs.idmahasiswa='" & id.ToString() & "'"
        Me.adapter = fungsi.readSql(sql)
        Me.table = New DataTable
        Me.adapter.Fill(Me.table)
        Me.dgData.DataSource = Me.table

        Dim lebar() As Integer = {0, 205, 141}

        For idx As Integer = 0 To (Me.dgData.ColumnCount - 1)
            Me.dgData.Columns(idx).Width = lebar(idx)
        Next

        With Me.dgData
            .RowHeadersVisible = False
            .Columns(0).Visible = False
            .Columns(1).HeaderCell.Value = "Mata Kuliah"
            .Columns(2).HeaderCell.Value = "Dosen Pengampu"
        End With
    End Sub

    Private Sub btnKelola_Click(sender As Object, e As EventArgs) Handles btnKelola.Click
        If Me.cmbMahasiswa.SelectedIndex.Equals(-1) Then
            Console.WriteLine("0")
        Else
            Dim id As Byte = Byte.Parse(DirectCast(Me.cmbMahasiswa.SelectedItem, KeyValuePair(Of Byte, String)).Key)

            Dim kelola = New KelolaKRS()
            kelola.SetMahasiswa(id, Me.cmbMahasiswa.Text)
            Me.cmbMahasiswa.SelectedIndex = -1
            Me.Read(0)
            kelola.ShowDialog()
            'Me.fungsi.MsgBox(Me.cmbMahasiswa.Text, "Info", "information")
        End If
    End Sub

    Private Sub KartuRencanaStudi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetMahasiswa()
    End Sub

    Private Sub cmbMahasiswa_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbMahasiswa.SelectionChangeCommitted
        If Me.cmbMahasiswa.SelectedIndex.Equals(-1) Then
            Console.WriteLine("0")
        Else
            Dim id As Byte = Byte.Parse(DirectCast(Me.cmbMahasiswa.SelectedItem, KeyValuePair(Of Byte, String)).Key)
            Me.Read(id)
        End If
    End Sub
End Class