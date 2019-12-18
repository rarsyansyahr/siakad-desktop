Imports System.Data.SqlClient

Public Class Koneksi
    Private koneksi As String
    Private sql As String
    Private conn As SqlConnection

    Public Function getConn() As SqlConnection
        Dim source As String = "Data Source=localhost\RAR;Initial Catalog=db_siakad;Integrated Security=True"
        Me.conn = New SqlClient.SqlConnection(source)
        Return Me.conn
    End Function

End Class
