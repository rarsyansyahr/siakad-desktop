Imports System.Data.SqlClient

Public Class KartuRencanaMengajar
    Dim fungsi As New Fungsi()
    Private table As DataTable
    Private adapter As SqlDataAdapter
    Private sql As String
    Private id As Integer

    Private Sub SetDosen()
        Dim sql As String = "select id, concat(nidn, ' - ', nama) as nama from dosen order by nidn"
        Me.fungsi.setList(sql, "id", "nama", Me.cmbDosen)
    End Sub

    Private Sub Read(id As Byte)
        Dim sql As String = "select id, nama, sks from v_krm where v_krm.iddosen='" & id.ToString() & "'"
        'Me.fungsi.MsgBox(sql, "SQL", "information")
        Me.adapter = fungsi.readSql(sql)
        Me.table = New DataTable
        Me.adapter.Fill(Me.table)
        Me.dgData.DataSource = Me.table

        Dim lebar() As Integer = {0, 255, 91}

        For idx As Integer = 0 To (Me.dgData.ColumnCount - 1)
            Me.dgData.Columns(idx).Width = lebar(idx)
        Next

        With Me.dgData
            .RowHeadersVisible = False
            .Columns(0).Visible = False
            .Columns(1).HeaderCell.Value = "Mata Kuliah"
            .Columns(2).HeaderCell.Value = "Jumlah SKS"
        End With
    End Sub

    Private Sub btnKelola_Click(sender As Object, e As EventArgs) Handles btnKelola.Click
        If Me.cmbDosen.SelectedIndex.Equals(-1) Then
            Console.WriteLine("0")
        Else
            Dim id As Byte = Byte.Parse(DirectCast(Me.cmbDosen.SelectedItem, KeyValuePair(Of Byte, String)).Key)

            Dim kelola = New KelolaKRM()
            kelola.SetDosen(id, Me.cmbDosen.Text)
            Me.cmbDosen.SelectedIndex = -1
            Me.Read(0)
            kelola.ShowDialog()
        End If
    End Sub

    Private Sub KartuRencanaMengajar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetDosen()
        Me.cmbDosen.SelectedIndex = -1
    End Sub

    Private Sub cmbDosen_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbDosen.SelectionChangeCommitted
        If Me.cmbDosen.SelectedIndex.Equals(-1) Then
            Console.WriteLine("0")
        Else
            Dim id As Byte = Byte.Parse(DirectCast(Me.cmbDosen.SelectedItem, KeyValuePair(Of Byte, String)).Key)
            Me.Read(id)
        End If
    End Sub
End Class