Imports System.Data.SqlClient


Public Class Fungsi

    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private adapter As SqlDataAdapter

    Private Sub Fungsi()
        Dim koneksi As New Koneksi
        Me.conn = koneksi.getConn()
    End Sub

    Public Function eQuery(ByRef sql As String) As Integer
        Me.cmd = New SqlCommand(sql)
        Return Me.cmd.ExecuteNonQuery
    End Function

    Public Function readSql(ByRef sql As String) As SqlDataAdapter
        Me.adapter = New SqlDataAdapter(sql, Me.conn)
        Return Me.adapter
    End Function

    Public Sub MsgBox(ByRef message As String, ByRef title As String, ByRef icon As String)
        Dim ikon As MessageBoxIcon

        Select Case ikon
            Case "information"
                ikon = MessageBoxIcon.Information
            Case "warning"
                ikon = MessageBoxIcon.Warning
            Case "error"
                ikon = MessageBoxIcon.Error
            Case Else
                ikon = MessageBoxIcon.None
        End Select

        MessageBox.Show(message, title, MessageBoxButtons.OK, ikon)
    End Sub

End Class
