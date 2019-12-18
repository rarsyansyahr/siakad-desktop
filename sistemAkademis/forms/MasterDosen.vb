Imports System.Data.SqlClient

Public Class MasterDosen

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

        Dim lebar() As Integer = {0, 65, 130, 192}

        For idx As Integer = 0 To 3
            Me.dgData.Columns(idx).Width = lebar(idx)
        Next

        With Me.dgData
            .RowHeadersVisible = True
            .Columns(0).Visible = False
            .Columns(1).HeaderCell.Value = "NIDN"
            .Columns(2).HeaderCell.Value = "Nama Dosen"
            .Columns(3).HeaderCell.Value = "Alamat"
        End With
    End Sub

    Private Sub ReadAll()
        Me.sql = "select * from dosen order by nidn"
        Me.Read(Me.sql)
    End Sub

    Private Sub Search()
        Dim cari As String = Me.txtPencarian.Text
        Me.sql = "select * from dosen where nidn like '%" &
            cari & "%' or nama like '%" &
            cari & "%' or alamat like '%" &
            cari & "%'order by nidn"
        Me.Read(Me.sql)
    End Sub

    Private Sub Create()
        Me.sql = "insert into dosen (nidn, nama, alamat) values('" &
            Me.txtNidn.Text & "', '" &
            Me.txtNama.Text & "', '" &
            Me.txtAlamat.Text & "')"
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
        Me.sql = "update dosen set nidn='" &
            Me.txtNidn.Text & "', nama='" &
            Me.txtNama.Text & "', alamat='" &
            Me.txtAlamat.Text & "' where id='" &
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
        Me.sql = "delete from dosen where id='" & Me.id & "'"
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
        Me.txtNidn.Clear()
        Me.txtNama.Clear()
        Me.txtAlamat.Clear()
        Me.txtNidn.Focus()
    End Sub

    Private Sub MasterDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReadAll()
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        Me.Clear()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Me.Create()
    End Sub

    Private Sub dgData_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgData.CellMouseClick
        Dim rowIdx As Byte = e.RowIndex
        Me.id = Me.dgData.Rows(rowIdx).Cells(0).Value
        Dim nidn As String = Me.dgData.Rows(rowIdx).Cells(1).Value.ToString()
        Dim nama As String = Me.dgData.Rows(rowIdx).Cells(2).Value.ToString()
        Dim alamat As String = Me.dgData.Rows(rowIdx).Cells(3).Value.ToString()

        Me.txtNidn.Text = nidn
        Me.txtNama.Text = nama
        Me.txtAlamat.Text = alamat
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
End Class