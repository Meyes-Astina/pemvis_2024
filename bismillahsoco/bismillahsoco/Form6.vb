Imports MySql.Data.MySqlClient

Public Class Form6
    Private Sub btnRegis_Click(sender As Object, e As EventArgs) Handles btnRegis.Click
        ' Get input values
        Dim username As String = txtusername.Text.Trim()
        Dim password As String = txtPw.Text.Trim()

        ' validasi inputs
        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("ID, username, dan password harus diisi.", "Registrasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' validasi username length
        If username.Length < 6 Then
            MessageBox.Show("Username harus memiliki minimal 6 karakter.", "Registrasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Module1.koneksi()

            ' Check if ID already exists
            Dim checkIdQuery As String = "SELECT COUNT(*) FROM tbacc WHERE username = @username"
            Using checkUnameCmd As New MySqlCommand(checkIdQuery, Module1.CONN)
                checkUnameCmd.Parameters.AddWithValue("@username", username)
                Dim idCount As Integer = Convert.ToInt32(checkUnameCmd.ExecuteScalar())
                If idCount > 0 Then
                    MessageBox.Show("Username sudah digunakan. Silakan pilih Username lain.", "Registrasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End Using

            ' Jika ID tidak ada, lanjutkan ke pendaftaran
            Dim insertQuery As String = "INSERT INTO tbacc (username, password) VALUES (@username, @password)"
            Using cmd As New MySqlCommand(insertQuery, Module1.CONN)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Registrasi berhasil.", "Registrasi Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' Menghapus kolom input setelah pendaftaran berhasil
                    txtusername.Clear()
                    txtPw.Clear()
                    ' Tampilkan Formulir5 setelah pendaftaran berhasil
                    Dim form5 As New Form5()
                    form5.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Registrasi Gagal.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnkembali_Click(sender As Object, e As EventArgs) Handles btnkembali.Click
        Dim form5 As New Form5()
        form5.Show()
        Me.Close()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tambahkan KeyDown event handler untuk semua inputan
        AddHandler txtusername.KeyDown, AddressOf Input_KeyDown
        AddHandler txtPw.KeyDown, AddressOf Input_KeyDown
    End Sub

    Private Sub Input_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnRegis.PerformClick()
        ElseIf e.KeyCode = Keys.Down Then
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub
End Class
