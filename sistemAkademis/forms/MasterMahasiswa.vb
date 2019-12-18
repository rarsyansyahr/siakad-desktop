Imports System.Data.SqlClient

Public Class masterMahasiswa

    Private fungsi As New Fungsi()
    Private table As DataTable
    Private adapter As SqlDataAdapter
    Private sql As String

    Private Sub Read(ByRef sql As String)
        Me.adapter = fungsi.readSql(sql)
        Me.table = New DataTable
        Me.adapter.Fill(Me.table)
        Me.dgData.DataSource = Me.table
    End Sub

    Private Sub ReadAll()
        Me.sql = "select * from mahasiswa order by nim"
        Me.Read(Me.sql)
    End Sub

    Private Sub Search()
        Dim cari As String = Me.txtPencarian.Text
        Me.sql = "select * from mahasiswa where nim like '%" &
            cari & "%' or nama like '%" &
            cari & "%' or alamat like '%" &
            cari & "%'order by nim"
        Me.Read(Me.sql)
    End Sub

    Private Sub Create()
        Me.sql = "insert into mahasiswa (nim, nama, alamat) values('" &
            Me.txtNim.Text &
            Me.txtAlamat.Text &
        "')"
        Dim status As Integer = Me.fungsi.eQuery(Me.sql)

        If status = 1 Then
            Me.fungsi.MsgBox("Berhasil menambahkan data baru !", "Pesan Informasi", "information")
        Else
            Me.fungsi.MsgBox("Gagal menambahkan data baru !", "Pesan Error", "error")
        End If

        Me.Clear()
        Me.ReadAll()

    End Sub

    Private Sub Clear()
        Me.txtNim.Clear()
        Me.txtNama.Clear()
        Me.txtAlamat.Clear()
    End Sub

    Private Sub masterMahasiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReadAll()
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        Me.Clear()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Me.Create()
    End Sub
End Class