Public Class KelolaKRS
    Private id As Byte
    Private nim As String
    Private nama As String

    Public Sub SetMahasiswa(id As Byte, detail As String)
        Dim rows() As String = detail.Split("-")

        Me.id = id
        Me.nim = rows(0).ToString()
        Me.nama = rows(1).ToString()
    End Sub
End Class