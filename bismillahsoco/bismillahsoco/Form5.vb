Imports MySql.Data.MySqlClient

Public Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler txtUsername.KeyDown, AddressOf TextBox_KeyDown
        AddHandler txtPw.KeyDown, AddressOf TextBox_KeyDown
        AddHandler CheckBox1.CheckedChanged, AddressOf CheckBox1_CheckedChanged
        txtPw.UseSystemPasswordChar = True ' Default to masked password
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Login()
    End Sub

    Private Sub Login()
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPw.Text.Trim()

        Try
            If username = "soco" AndAlso password = "socostore" Then
                MessageBox.Show("Selamat Datang, Admin SOCO!")
                Dim form10 As New Form10()
                form10.Show()
                Me.Hide()
                ClearTextBoxes()
            Else
                Dim userId As Integer = GetUserId(username, password)
                If userId > 0 Then
                    MessageBox.Show("Login Berhasil!")
                    Module1.LoggedInUsername = userId
                    Dim form7 As New Form7()
                    form7.Show()
                    Me.Hide()
                    ClearTextBoxes()
                Else
                    Throw New Exception("Username/Password Anda Salah Atau Akun Tidak Terdaftar!")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetUserId(ByVal username As String, ByVal password As String) As Integer
        Dim userId As Integer = -1
        Try
            Module1.koneksi()
            Dim query As String = "SELECT id FROM tbacc WHERE username = @username AND password = @password"
            Using cmd As New MySqlCommand(query, Module1.CONN)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    userId = Convert.ToInt32(result)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return userId
    End Function

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim form6 As New Form6()
        form6.Show()
        Me.Hide()
    End Sub

    Private Sub ClearTextBoxes()
        txtUsername.Text = ""
        txtPw.Text = ""
    End Sub

    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Login()
        ElseIf e.KeyCode = Keys.Down Then
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        If CheckBox1.Checked Then
            txtPw.UseSystemPasswordChar = False
        Else
            txtPw.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub
End Class
