Imports MySql.Data.MySqlClient

Module Module1
    Public CONN As MySqlConnection 'mengelola koneksi ke basis data MySQL.
    Public CMD As MySqlCommand 'menjalankan perintah SQL ke basis data MySQL.
    Public DA As MySqlDataAdapter ' mengisi dan memperbarui data dalam dataset dan menyinkronkan data dengan basis data MySQL.
    ' String ini berisi parameter seperti nama server, nama pengguna, kata sandi, nama basis data, dan pengkodean karakter.
    Public STR As String = "server=localhost;userid=root;password=;database=dbpemvis;charset=utf8mb4"
    'membaca baris data dari hasil kueri yang dijalankan pada basis data MySQL.
    Public LoggedInUsername As Integer
    Public RD As MySqlDataReader 'membaca baris data dari hasil kueri yang dijalankan pada basis data MySQL.

    'membuka koneksi ke basis data MySQL
    Public Sub koneksi()
        Try
            If CONN Is Nothing Then
                CONN = New MySqlConnection(STR)
            End If

            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'menutup koneksi ke basis data MySQL
    Public Sub TutupKoneksi()
        Try
            If CONN IsNot Nothing AndAlso CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Module
