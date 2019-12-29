Imports System.Data.SqlClient

Public Class KelolaKRM
    Private id As Byte
    Private nidn As String
    Private nama As String
    Private fungsi As New Fungsi()

    Public Sub SetDosen(id As Byte, detail As String)
        Dim rows() As String = detail.Split("-")

        Me.id = id
        Me.nidn = rows(0).ToString()
        Me.nama = rows(1).ToString()
    End Sub

    Private Sub SetMatkul()
        Dim sql As String = "select id, nama from matakuliah order by nama"
        Me.fungsi.setList(sql, "id", "nama", Me.cklMatkul)
    End Sub

    Private Sub Create()
        Dim list As List(Of Byte) = New List(Of Byte)

        For i As Integer = 0 To Me.cklMatkul.CheckedItems.Count - 1
            Dim id As Byte = DirectCast(Me.cklMatkul.CheckedItems.Item(i), KeyValuePair(Of Byte, String)).Key

            Dim sql As String = "insert into krm (iddosen, idmatakuliah) values('" & Me.id & "', '" & id & "')"
            Dim status As Integer = Me.fungsi.eQuery(sql)
            If status = 1 Then
                list.Add(id)
            End If

        Next
    End Sub

    Private Sub Delete()
        Dim sql As String = "delete from krm where iddosen='" & Me.id & "'"
        Me.fungsi.eQuery(sql)
    End Sub

    Private Sub Save()
        Dim sql As String = "select id from krm where iddosen='" & Me.id & "'"
        Dim reader As SqlDataReader = Me.fungsi.eReader(sql)

        If reader.HasRows = True Then
            Me.Delete()
        End If

        Me.Create()
        Me.Dispose()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Me.Save()
    End Sub

    Private Sub KelolaKRM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lblNidn.Text = ": " & Me.nidn
        Me.lblNama.Text = ": " & Me.nama
        Me.SetMatkul()
    End Sub
End Class