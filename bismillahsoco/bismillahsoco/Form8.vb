Imports MySql.Data.MySqlClient

Public Class Form8
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataIntoDataGridView()
    End Sub

    Private Sub LoadDataIntoDataGridView()
        Try
            Module1.koneksi()
            Dim query As String = "SELECT ID, Brand, Jenis, Shade, Harga, Kategori, Gambar, Deskripsi FROM tbform1"
            Using cmd As New MySqlCommand(query, Module1.CONN)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridView1.DataSource = table
                FormatDataGridView(DataGridView1)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Data Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatDataGridView(dataGridView As DataGridView)
        dataGridView.Columns("Gambar").DefaultCellStyle.NullValue = Nothing
        Dim imgColumn As DataGridViewImageColumn = TryCast(dataGridView.Columns("Gambar"), DataGridViewImageColumn)
        If imgColumn IsNot Nothing Then
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        End If
        dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        For Each row As DataGridViewRow In dataGridView.Rows
            row.Height = 90
        Next
    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Me.Hide()
        Form7.Show()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim keyword As String = txtSearch.Text.Trim()

        If Not String.IsNullOrEmpty(keyword) Then
            Try
                Module1.koneksi()
                Dim query As String = "SELECT * FROM tbform1 WHERE Brand LIKE @Brand"
                Using cmd As New MySqlCommand(query, CONN)
                    cmd.Parameters.AddWithValue("@Brand", "%" & keyword & "%")
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    DataGridView1.DataSource = table
                End Using
            Catch ex As Exception
                MessageBox.Show("Gagal Mencari Data: " & ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Masukkan kata kunci pencarian", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = DataGridView1.Columns("btnTambahWishlist").Index AndAlso e.RowIndex >= 0 Then
            Dim idProduk As Integer = Convert.ToInt32(DataGridView1.Rows(e.RowIndex).Cells("id").Value)
            AddToWishlist(idProduk)
        End If
    End Sub

    Private Sub AddToWishlist(idProduk As Integer)
        Try
            Module1.koneksi()
            Dim checkQuery As String = "SELECT COUNT(*) FROM tbwishlist WHERE id = @id AND id_makeup = @id_makeup"
            Using checkCmd As New MySqlCommand(checkQuery, Module1.CONN)
                checkCmd.Parameters.AddWithValue("@id", Module1.LoggedInUsername)
                checkCmd.Parameters.AddWithValue("@id_makeup", idProduk)
                Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("Produk Ini Sudah Ada Dalam Wishlist Anda", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            End Using
            Dim insertQuery As String = "INSERT INTO tbwishlist (id, id_makeup) VALUES (@id, @id_makeup)"
            Using cmd As New MySqlCommand(insertQuery, Module1.CONN)
                cmd.Parameters.AddWithValue("@id", Module1.LoggedInUsername)
                cmd.Parameters.AddWithValue("@id_makeup", idProduk)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Produk Ditambahkan Ke Wishlist", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Gagal Menambahkan Produk Ke Wishlist Anda", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
            'End Using
        Catch ex As Exception
            MessageBox.Show("Error adding product to wishlist: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnWishlist_Click(sender As Object, e As EventArgs) Handles btnWishlist.Click
        Dim selectedRow As DataGridViewRow = DataGridView1.CurrentRow
        If selectedRow IsNot Nothing Then
            Dim idProduk As Integer = Convert.ToInt32(selectedRow.Cells("id").Value) 'System.ArgumentException: 'Column named id cannot be found.Parameter Name: columnName '
            AddToWishlist(idProduk)
        Else
            MessageBox.Show("Pilih Baris Produk yang akan ditambahkan ke Wishlist", "Tidak Ada Produk Yang Dipilih", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form7.Show()
    End Sub
End Class