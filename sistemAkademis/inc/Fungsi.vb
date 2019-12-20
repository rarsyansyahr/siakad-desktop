Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fungsi

    Private conn As SqlConnection
    Private koneksi As New Koneksi()
    Private cmd As SqlCommand
    Private adapter As SqlDataAdapter
    Private reader As SqlDataReader

    Public Function eQuery(sql As String) As Integer
        Me.conn = Me.koneksi.getConn()
        Me.conn.Open()
        Me.cmd = New SqlCommand(sql, Me.conn)
        Return Me.cmd.ExecuteNonQuery()
        Me.conn.Close()
    End Function

    Public Function readSql(sql As String) As SqlDataAdapter
        Me.conn = Me.koneksi.getConn()
        Me.adapter = New SqlDataAdapter(sql, Me.conn)
        Me.conn.Close()
        Return Me.adapter
    End Function

    Public Function eReader(sql As String) As SqlDataReader
        Me.conn = Me.koneksi.getConn()
        Me.conn.Open()
        Me.cmd = New SqlCommand(sql, Me.conn)
        Me.reader = Me.cmd.ExecuteReader()
        Return Me.reader
    End Function

    Public Sub MsgBox(message As String, title As String, icon As String)
        Dim ikon As MessageBoxIcon

        Select Case icon
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

    Public Function ConfirmBox(message As String, title As String) As Boolean
        Dim konfirmasi As Integer = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Dim conf As Boolean

        If konfirmasi = 6 Then
            conf = True
        Else
            conf = False
        End If

        Return conf
    End Function

    Public Sub setComboBox(sql As String, idx As String, val As String, cbx As ComboBox)
        Dim dict = New Dictionary(Of Byte, String)
        Me.reader = Me.eReader(sql)

        If Me.reader.HasRows Then
            While Me.reader.Read()
                Dim x As Byte = Byte.Parse(Me.reader.Item(idx).ToString())
                Dim y As String = Me.reader.Item(val).ToString()
                dict.Add(x, y)
            End While

            cbx.DataSource = New BindingSource(dict, Nothing)
            cbx.DisplayMember = "Value"
            cbx.ValueMember = "Key"
        End If
    End Sub

    Public Function Validation(input As Control, err As ErrorProvider, message As String) As Boolean
        Dim status As Boolean

        If input.Text.Length = 0 Then
            err.SetError(input, message)
            status = False
        Else
            status = True
        End If

        Return status
    End Function

End Class
