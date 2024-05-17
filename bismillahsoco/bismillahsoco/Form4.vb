Imports MySql.Data.MySqlClient
Public Class Form4
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilData()
    End Sub

    Private Function IsTableEmpty() As Boolean
        Dim isEmpty As Boolean = True
        Try
            Module1.koneksi()
            If Module1.CONN.State = ConnectionState.Open Then
                Dim query As String = "SELECT COUNT(*) FROM tbbrand"
                Dim cmd As New MySqlCommand(query, Module1.CONN)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                isEmpty = (count = 0)
            Else
                MessageBox.Show("Connection is not open.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Module1.TutupKoneksi()
        End Try

        Return isEmpty
    End Function

    Private Sub TampilData()
        Try
            Module1.koneksi()
            Using CONN As New MySqlConnection(Module1.STR)
                CONN.Open()
                Dim query As String = "SELECT * FROM tbbrand"
                Dim data As New DataTable()
                Using DA As New MySqlDataAdapter(query, CONN)
                    DA.Fill(data)
                End Using
                DataGridView1.DataSource = data
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Module1.TutupKoneksi()
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            Dim jenisValue As String = txtJenis.Text.Trim()

            ' Mengecek apakah jenisValue kosong atau hanya berisi huruf, angka, dan spasi
            If String.IsNullOrWhiteSpace(jenisValue) OrElse Not System.Text.RegularExpressions.Regex.IsMatch(jenisValue, "^[a-zA-Z0-9 ]+$") Then
                MessageBox.Show("Brand hanya boleh berisi huruf, angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Mengecek apakah jenisValue bernilai "0"
            If jenisValue = "0" Then
                MessageBox.Show("Jenis tidak boleh bernilai 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Module1.koneksi()
            Using CONN As New MySqlConnection(Module1.STR)
                CONN.Open()
                Dim query As String = "INSERT INTO tbbrand (brand) VALUES (@brand)"
                Using cmd As New MySqlCommand(query, CONN)
                    cmd.Parameters.AddWithValue("@brand", txtJenis.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Data Berhasil Disimpan")
            TampilData()
            Kosong()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Module1.TutupKoneksi()
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Try
            Dim searchText As String = txtCari.Text.Trim()

            If String.IsNullOrWhiteSpace(searchText) Then
                MessageBox.Show("Masukkan ID yang ingin dihapus.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim id As String = searchText.Trim()
            ' Mengecek apakah id kosong atau hanya berisi angka
            If String.IsNullOrWhiteSpace(id) OrElse Not System.Text.RegularExpressions.Regex.IsMatch(id, "^[0-9]+$") Then
                MessageBox.Show("ID harus berupa angka.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Module1.koneksi()
            Using CONN As New MySqlConnection(Module1.STR)
                CONN.Open()
                Dim query As String = "DELETE FROM tbbrand WHERE id = @id"
                Using cmd As New MySqlCommand(query, CONN)
                    cmd.Parameters.AddWithValue("@id", id)
                    Dim affectedRows As Integer = cmd.ExecuteNonQuery()
                    If affectedRows > 0 Then
                        MessageBox.Show("Data Berhasil Dihapus.")
                        TampilData()
                        Kosong()
                    Else
                        MessageBox.Show("Data Tidak Ditemukan.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Module1.TutupKoneksi()
        End Try
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        If txtCari.Text <> "" Then
            Try
                Module1.koneksi()
                Dim query As String = "SELECT * FROM tbbrand WHERE id LIKE '%" & txtCari.Text & "%'"
                Dim data As New DataTable()
                Using CONN As New MySqlConnection(Module1.STR)
                    CONN.Open()
                    Using DA As New MySqlDataAdapter(query, CONN)
                        DA.Fill(data)
                    End Using
                End Using
                DataGridView1.DataSource = data
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                Module1.TutupKoneksi()
            End Try
        Else
            TampilData()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If String.IsNullOrWhiteSpace(txtJenis.Text) Then
                MessageBox.Show("Jenis tidak boleh kosong")
                txtJenis.Focus()
                Return
            End If

            ' Validasi input tidak boleh bernilai 0
            Dim jenisValue As String = txtJenis.Text.Trim()

            ' Mengecek apakah jenisValue kosong atau hanya berisi huruf, angka, dan spasi
            If String.IsNullOrWhiteSpace(jenisValue) OrElse Not System.Text.RegularExpressions.Regex.IsMatch(jenisValue, "^[a-zA-Z0-9 ]+$") Then
                MessageBox.Show("Brand hanya boleh berisi huruf, angka, dan spasi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Mengecek apakah jenisValue bernilai "0"
            If jenisValue = "0" Then
                MessageBox.Show("Jenis tidak boleh bernilai 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If textboxid.Text = Nothing Then
                MsgBox("Pilih ID")
                textboxid.Focus()
                Return
            End If

            Module1.koneksi()
            Using CONN As New MySqlConnection(Module1.STR)
                CONN.Open()
                Dim ubah As String = "UPDATE tbbrand SET brand = @brand WHERE id = @id"
                Using cmd As New MySqlCommand(ubah, CONN)
                    cmd.Parameters.AddWithValue("@brand", txtJenis.Text)
                    cmd.Parameters.AddWithValue("@id", textboxid.Text)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Data Berhasil Diubah")
                    TampilData()
                    Kosong()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Module1.TutupKoneksi()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim id As String = DataGridView1.Rows(e.RowIndex).Cells("id").Value.ToString()
            Dim jenis As String = DataGridView1.Rows(e.RowIndex).Cells("brand").Value.ToString()

            textboxid.Text = id
            txtJenis.Text = jenis
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        Form10.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Kosong()
    End Sub
    Private Sub Kosong()
        txtJenis.Clear()
        textboxid.Clear()
    End Sub

End Class
