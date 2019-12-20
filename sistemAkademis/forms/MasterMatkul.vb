Imports System.Data.SqlClient

Public Class MasterMatkul

    Private fungsi As New Fungsi()
    Private table As DataTable
    Private adapter As SqlDataAdapter
    Private sql As String
    Private id As Integer

    Private Sub Read(sql As String)
        Me.adapter = fungsi.readSql(sql)
        Me.table = New DataTable
        Me.adapter.Fill(Me.table)
        Me.dgData.DataSource = Me.table

        Dim lebar() As Integer = {0, 65, 222, 100}

        For idx As Integer = 0 To 3
            Me.dgData.Columns(idx).Width = lebar(idx)
        Next

        With Me.dgData
            .RowHeadersVisible = True
            .Columns(0).Visible = False
            .Columns(1).HeaderCell.Value = "Kode"
            .Columns(2).HeaderCell.Value = "Nama Mata Kuliah"
            .Columns(3).HeaderCell.Value = "Jumlah SKS"
        End With
    End Sub

    Private Sub ReadAll()
        Me.sql = "select * from matakuliah order by kode"
        Me.Read(Me.sql)
    End Sub

    Private Sub Search()
        Dim cari As String = Me.txtPencarian.Text
        Me.sql = "select * from matakuliah where kode like '%" &
            cari & "%' or nama like '%" &
            cari & "%' or sks like '%" &
            cari & "%'order by kode"
        Me.Read(Me.sql)
    End Sub

    Private Sub Create()
        Me.sql = "insert into matakuliah (kode, nama, sks) values('" &
            Me.txtKode.Text & "', '" &
            Me.txtNama.Text & "', '" &
            Me.txtJumlah.Text & "')"
        Dim status As Byte = Me.fungsi.eQuery(Me.sql)

        If status = 1 Then
            Me.fungsi.MsgBox("Berhasil menambahkan data baru !", "Pesan Informasi", "information")
        Else
            Me.fungsi.MsgBox("Gagal menambahkan data baru !", "Pesan Error", "error")
        End If

        Me.Clear()
        Me.ReadAll()

    End Sub

    Private Overloads Sub Update()
        Me.sql = "update matakuliah set kode='" &
            Me.txtKode.Text & "', nama='" &
            Me.txtNama.Text & "', sks='" &
            Me.txtJumlah.Text & "' where id='" &
            Me.id & "'"
        Dim status As Byte = Me.fungsi.eQuery(Me.sql)

        If status = 1 Then
            Me.fungsi.MsgBox("Berhasil menyimpan perubahan data !", "Pesan Informasi", "information")
        Else
            Me.fungsi.MsgBox("Gagal menyimpan perubahan data !", "Pesan Error", "error")
        End If

        Me.Clear()
        Me.ReadAll()

    End Sub

    Private Sub Delete()
        Me.sql = "delete from matakuliah where id='" & Me.id & "'"
        Dim status As Byte = Me.fungsi.eQuery(Me.sql)

        If status = 1 Then
            Me.fungsi.MsgBox("Berhasil menghapus data !", "Pesan Informasi", "information")
        Else
            Me.fungsi.MsgBox("Gagal menghapus data !", "Pesan Error", "error")
        End If

        Me.Clear()
        Me.ReadAll()

    End Sub

    Private Sub Clear()
        Me.txtKode.Clear()
        Me.txtNama.Clear()
        Me.txtJumlah.Clear()
        Me.txtKode.Focus()
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        Me.Clear()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Me.Create()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Me.Update()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim konfirmasi As Boolean = Me.fungsi.ConfirmBox("Yakin untuk menghapus data ini ?", "Pesan Konfirmasi")

        Select Case konfirmasi
            Case True
                Me.Delete()
            Case False
                Me.fungsi.MsgBox("Batal menghapus data.", "Pesan Informasi", "information")
                Me.Clear()
        End Select
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Me.Search()
    End Sub

    Private Sub txtPencarian_Leave(sender As Object, e As EventArgs) Handles txtPencarian.Leave
        If Me.txtPencarian.Text.Length = 0 Then
            Me.ReadAll()
        End If
    End Sub

    Private Sub dgData_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgData.CellMouseClick
        Dim rowIdx As Byte = e.RowIndex
        Me.id = Me.dgData.Rows(rowIdx).Cells(0).Value
        Dim kode As String = Me.dgData.Rows(rowIdx).Cells(1).Value.ToString()
        Dim nama As String = Me.dgData.Rows(rowIdx).Cells(2).Value.ToString()
        Dim sks As String = Me.dgData.Rows(rowIdx).Cells(3).Value.ToString()

        Me.txtKode.Text = kode
        Me.txtNama.Text = nama
        Me.txtJumlah.Text = sks
    End Sub

    Private Sub MasterMatkul_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReadAll()
    End Sub
End Class